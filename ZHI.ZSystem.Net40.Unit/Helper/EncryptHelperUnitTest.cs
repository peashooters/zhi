using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class EncryptHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            //取消注释即可进行单元测试
            //MD5_Encrypt();

            #region AES
            //AES_Example_CBC();
            //AES_Example_ECB();
            //AES_Example_OFB();
            //AES_Example_CFB();
            //AES_Example_CTR();
            //AES_Example_CTS();
            #endregion
        }

        private void MD5_Encrypt()
        {
            var empty = string.Empty;
            Console.WriteLine("MD5EncryptTo16：{0}", EncryptHelper.MD5EncryptTo16(empty));
            Console.WriteLine("MD5EncryptTo32：{0}", EncryptHelper.MD5EncryptTo32(empty));
        }

        private void AES_Example_CTS()
        {
            Console.WriteLine("执行函数 AES_Example_CTS()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTS, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();
        }

        private void AES_Example_CTR()
        {
            Console.WriteLine("执行函数 AES_Example_CTR()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CTR, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();
        }

        private void AES_Example_CFB()
        {
            Console.WriteLine("执行函数 AES_Example_CFB()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();
        }

        private void AES_Example_OFB()
        {
            Console.WriteLine("执行函数 AES_Example_OFB()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.OFB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();
        }

        private void AES_Example_ECB()
        {
            Console.WriteLine("执行函数 AES_Example_ECB()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.ECB, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

        }

        private void AES_Example_CBC()
        {
            Console.WriteLine("执行函数 AES_Example_CBC()：");
            var aes_key_128_bit = "p0sq4osjzv8w0if7";
            var aes_key_192_bit = "wc9jggderyhip1z7nmfyoqc9";
            var aes_key_256_bit = "zew6gxjxx7gknvadxc4fk6prdkcn3cew";
            var aes_iv = "nlu0cmqpugvpph0d";
            var input = "hello world!(你好，世界！)";//加密数据原文
            Console.WriteLine("         128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("         192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("         256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("         AES IV：{0}", aes_iv);
            Console.WriteLine("         需要加密数据：{0}", input);
            Console.WriteLine();

            var ciphertext_base64 = string.Empty;//base64密文
            var ciphertext_hex = string.Empty;//16进制密文
            var ciphertext_base64_website_tools = string.Empty; //三方网站加密结果Base64
            var ciphertext_hex_website_tools = string.Empty;//三方网站加密结果Hex
            var verify_url = string.Empty;

            //############################################################# 128-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("128-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("128-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            //ZeroPadding
            Console.WriteLine("128-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("128-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            //ISO10126Padding
            Console.WriteLine("128-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_128_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 192-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("192-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("192-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("192-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("192-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("192-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_192_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();

            //############################################################# 256-BIT AES KEY #############################################################
            //NoPadding
            Console.WriteLine("256-BIT AES KEY NOPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.NoPadding));
            Console.WriteLine();
            //PKCS7Padding
            Console.WriteLine("256-BIT AES KEY PKCS7PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding));
            Console.WriteLine();
            //ZeroPadding
            Console.WriteLine("256-BIT AES KEY ZEROPADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ZeroPadding));
            Console.WriteLine();
            //ANSIX923Padding
            Console.WriteLine("256-BIT AES KEY ANSIX923PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ANSIX923Padding));
            Console.WriteLine();
            //ISO10126Padding
            Console.WriteLine("256-BIT AES KEY ISO10126PADDING");
            ciphertext_base64 = EncryptHelper.AESEncryptToBase64(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            ciphertext_hex = EncryptHelper.AESEncryptToHex(input, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding);
            Console.WriteLine("         Base64 output：{0}", ciphertext_base64);
            Console.WriteLine("         Hex output：{0}", ciphertext_hex);
            Console.WriteLine("         Base64 decrypt：{0}", EncryptHelper.AESDecryptFromBase64(ciphertext_base64, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine("         Hex decrypt：{0}", EncryptHelper.AESDecryptFromHex(ciphertext_hex, aes_key_256_bit, aes_iv, AesCipherMode.CBC, AesPaddingMode.ISO10126Padding));
            Console.WriteLine();
        }
    }
}
