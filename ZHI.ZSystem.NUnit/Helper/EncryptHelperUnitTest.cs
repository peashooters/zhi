using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NUnit.Helper
{
    public class EncryptHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //取消注释即可进行单元测试
            //MD5_Encrypt();

            #region AES 单元测试
            //####关于AES，作者有话要说：
            //####尽管尝试多种方法，作者仍未找到在.NET Core不依赖第三方组件的情况下完全实现AES算法
            //####与此同时，能百度到的案例几乎都是实现CBC密码模式 PCKS7Padding填充模式的AES加密算法（因为其企业级使用价值更高、算法实现更方便）
            //####然而我们总能有使用其他密码模式、填充模式的生产场景，作者不希望其他开发者遇到类似情况，于是将其集成进来。依赖BouncyCastle.NetCore.dll实现AES加密算法
            //####加密结果在以下几个网站综合测试：
            //https://tool.lmeee.com/jiami/aes
            //      特点：支持PKCS5Padding；自动处理iv、密钥（不足时填充\0，超长时截取）；数据块固定128-bit
            //      缺点：不支持nopadding模式；不支持CTR密码模式；
            //      模式：CBC、ECB、CFB、OFB
            //      结论：测试结果基本吻合。（无法测试nopadding填充模式、CTR加密模式）
            //
            //http://tool.chacuo.net/cryptaes
            //      特点：支持nopadding填充模式、支持CTR密码模式
            //####缺点：iv长度限制会根据数据块长度变化。NoPadding看起来是使用的ZeroPadding算法实现（实际上数据块长度变化时，应该是密码长度随之改变）
            //####
            //####https://the-x.cn/cryptography/Aes.aspx
            //####优点：功能强大、加密算法基本正确
            //####缺点：有无法访问情况。部分算法情况下加密结果是错误的，不支持nopadding
            //####
            //####https://www.ssleye.com/aes_cipher.html
            //####优点：功能齐全
            //####缺点：CTR加密模式下，IV只支持0~15byte长度。不支持nopadding（当iv在8byte~15byte的长度之间时，作者的工具类能与它的加密结果一致 ）
            //####
            //####注：没有一个网站能完全与本工具库的加密结果完全匹配，但是以上工具网站中，至少能找到一个与本工具库加密结果完全相同的算法模式与填充模式
            //AES_Example_KEY_IV();
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
            Console.WriteLine("执行函数 MD5_EncryptMD5_Encrypt()：");
            Console.WriteLine("MD5EncryptTo16：{0}", EncryptHelper.MD5EncryptTo16(empty));
            Console.WriteLine("MD5EncryptTo32：{0}", EncryptHelper.MD5EncryptTo32(empty));
        }

        public void AES_Example_KEY_IV()
        {
            Console.WriteLine("执行函数 AES_Example_KEY_IV()：");
            var aes_key_128_bit = EncryptHelper.AESGenerateKey(128);
            var aes_key_192_bit = EncryptHelper.AESGenerateKey(192);
            var aes_key_256_bit = EncryptHelper.AESGenerateKey(256);
            var aes_iv = EncryptHelper.AESGenerateIV();
            Console.WriteLine("生成128-bit AES Key：{0}", aes_key_128_bit);
            Console.WriteLine("生成192-bit AES Key：{0}", aes_key_192_bit);
            Console.WriteLine("生成256-bit AES Key：{0}", aes_key_256_bit);
            Console.WriteLine("生成AES IV：{0}", aes_iv);
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
