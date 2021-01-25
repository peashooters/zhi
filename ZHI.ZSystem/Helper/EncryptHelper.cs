using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 加密帮助类（Encrypt Helper）
    /// </summary>
    public static class EncryptHelper
    {
        #region ====private functions
        /// <summary>
        /// AES KEY 长度（位）
        /// </summary>
        private static readonly int[] _aes_key_size_array = { 128, 192, 256 };
        /// <summary>
        /// MD5计算指定字符串哈希值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static byte[] MD5ComputeHash(string input, Encoding encoding = null)
        {
            //编码格式
            encoding = encoding ?? Encoding.UTF8;
            using (var provider = MD5.Create())
            {
                return provider.ComputeHash(encoding.GetBytes(input));
            }
        }
        #endregion

        #region ====MD5
        /// <summary>
        /// MD5加密字符串并得到16位的结果（MD5 encrypts the string and gets a 16 byte result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        public static string MD5EncryptTo16(string input)
        {
            var ciphertext = MD5EncryptTo32(input);
            return ciphertext.Substring(8,16);
        }
        /// <summary>
        /// MD5加密字符串并得到32位的结果（MD5 encrypts the string and gets a 32 byte result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        public static string MD5EncryptTo32(string input)
        {
            var bytes = MD5ComputeHash(input, Encoding.UTF8);
            var builder = new StringBuilder();
            foreach (var byteValue in bytes)
                builder.Append(byteValue.ToString("x2"));
            return builder.ToString();
        }
        #endregion

        #region ====AES
        /// <summary>
        /// 生成AES KEY（Generate AES KEY）
        /// </summary>
        /// <param name="keySize">AES KEY 长度（128-bit、192-bit、256-bit）</param>
        /// <returns></returns>
        public static string AESGenerateKey(AesKeySize keySize)
        {
            return AESGenerateKey(keySize.ToInt());
        }
        /// <summary>
        /// 生成AES KEY（Generate AES KEY）
        /// </summary>
        /// <param name="keySize">AES KEY 长度（128-bit、192-bit、256-bit）</param>
        /// <returns></returns>
        public static string AESGenerateKey(int keySize = 128)
        {
            if (!_aes_key_size_array.Contains(keySize))
                throw new ArgumentOutOfRangeException(paramName:nameof(keySize),"指定的密钥长度不被允许，仅允许生成128位、192位、256位的AES KEY（The specified key length is not allowed. Only 128 bit, 192 bit and 256 bit AES key can be generated）");
            
            //1英文字符占1byte = 8bit
            var bytelen = keySize / 8;

            var key = StringHelper.GenerateRandomString(bytelen);

            return key;
        }
        /// <summary>
        /// 生成AES IV（Generate AES IV）
        /// </summary>
        /// <returns>16字节长度字符串（a 16 byte string）</returns>
        public static string AESGenerateIV()
        {
            var iv = StringHelper.GenerateRandomString(16);
            return iv;
        }
        /// <summary>
        /// AES加密字符串并获取字节数组结果（AES encrypts the string and gets the byte array result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static byte[] AESEncryptToBtyes(string input, string key, string iv = null, AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            //AES 加密算法
            var algorithm = string.Format("{0}/{1}/{2}", "AES", cipherMode.ToString(), paddingMode.GetDescription());
            //AES 算法实例
            var cipher = CipherUtilities.GetCipher(algorithm);

            //ECB模式下 传入IV无效
            if (cipherMode == AesCipherMode.ECB)
                iv = null;

            if (string.IsNullOrWhiteSpace(iv))
            {
                cipher.Init(true, ParameterUtilities.CreateKeyParameter("AES", Encoding.UTF8.GetBytes(key)));
            }
            else
            {
                cipher.Init(true, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", Encoding.UTF8.GetBytes(key)), Encoding.UTF8.GetBytes(iv)));
            }
            var bytes = cipher.DoFinal(Encoding.UTF8.GetBytes(input));

            return bytes;
        }
        /// <summary>
        /// AES加密字符串并获得base64字符串结果（AES encrypts the string and gets the base64 string result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static string AESEncryptToBase64(string input, string key, string iv = null, AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            var bytes = AESEncryptToBtyes(input, key, iv, cipherMode, paddingMode);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// AES加密字符串并获得十六进制字符串结果（AES encrypts the string and gets the hex string result）
        /// </summary>
        /// <param name="input">加密字符串</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static string AESEncryptToHex(string input, string key, string iv = null, AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            var bytes = AESEncryptToBtyes(input, key, iv, cipherMode, paddingMode);

            var builder = new StringBuilder();

            foreach (var @byte in bytes)
            {
                builder.AppendFormat("{0:x2}", @byte);
            }

            return builder.ToString();
        }
        /// <summary>
        /// AES解密字节数组并获得结果（AES decrypts the byte array and gets the result）
        /// </summary>
        /// <param name="input">字节数组</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static string AESDecryptFromBytes(byte[] input, string key, string iv = null, AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            //AES 加密算法
            var algorithm = string.Format("{0}/{1}/{2}", "AES", cipherMode.ToString(), paddingMode.GetDescription());
            //AES 算法实例
            var cipher = CipherUtilities.GetCipher(algorithm);

            //ECB模式下 传入IV无效
            if (cipherMode == AesCipherMode.ECB)
                iv = null;

            if (string.IsNullOrWhiteSpace(iv))
            {
                cipher.Init(false, ParameterUtilities.CreateKeyParameter("AES", Encoding.UTF8.GetBytes(key)));
            }
            else
            {
                cipher.Init(false, new ParametersWithIV(ParameterUtilities.CreateKeyParameter("AES", Encoding.UTF8.GetBytes(key)), Encoding.UTF8.GetBytes(iv)));
            }

            var bytes = cipher.DoFinal(input);

            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// AES解密十六进制字符串并获得结果（AES decrypts the hex string and gets the result）
        /// </summary>
        /// <param name="input">解密字符串</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static string AESDecryptFromHex(string input, string key, string iv = null, AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            var bytes = new byte[input.Length / 2];
            for (int index = 0; index < input.Length / 2; index++)
            {
                var @char = input.Substring(index * 2, 2);
                bytes[index] = Convert.ToByte(@char, 16);
            }
            return AESDecryptFromBytes(bytes, key, iv, cipherMode, paddingMode);
        }
        /// <summary>
        /// AES解密base64字符串并获得结果（AES decrypts the base64 string and gets the result）
        /// </summary>
        /// <param name="input">解密字符串</param>
        /// <param name="key">AES KEY</param>
        /// <param name="iv">AES IV</param>
        /// <param name="cipherMode">密码模式</param>
        /// <param name="paddingMode">填充模式</param>
        /// <returns></returns>
        public static string AESDecryptFromBase64(string input, string key, string iv = "", AesCipherMode cipherMode = AesCipherMode.CBC, AesPaddingMode paddingMode = AesPaddingMode.PKCS7Padding)
        {
            var bytes = Convert.FromBase64String(input);
            return AESDecryptFromBytes(bytes, key, iv, cipherMode, paddingMode);
        }
        #endregion

        #region ====RSA

        #endregion
    }
}

