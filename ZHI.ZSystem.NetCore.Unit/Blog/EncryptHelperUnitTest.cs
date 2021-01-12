using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetCore.Unit.Blog
{
    public class EncryptHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// 单元测试 记得引用ZHI.ZSystem库
        /// </summary>
        [Test]
        public void Test()
        {
            //把如下代码贴进单元测试方法后，“运行测试”就可查看加密解密结果啦！
            //AES KEY 128 BIT
            var aes_key = "afbbc5713904a815";
            //AES IV 16 BYTE
            var aes_iv = "9420f687309c817c";
            // plaintext
            var plaintext = "我们来进行单元测试咯！.}|/=@#￥%……&*（）——+~··";
            //BASE64 输出
            var ciphertext_base_64_output = EncryptHelper.AESEncryptToBase64(plaintext, aes_key, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            //Hex 输出（十六进制输出）
            var ciphertext_hex_output = EncryptHelper.AESEncryptToHex(plaintext, aes_key, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            //AES 解密 BASE64
            var base_64_decrypt = EncryptHelper.AESDecryptFromBase64(ciphertext_base_64_output, aes_key, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);
            //AES 解密 Hex
            var hex_decrypt = EncryptHelper.AESDecryptFromHex(ciphertext_hex_output, aes_key, aes_iv, AesCipherMode.CBC, AesPaddingMode.PKCS7Padding);

            Console.WriteLine("CBC密码模式");
            Console.WriteLine("     加密结果base64输出：{0}", ciphertext_base_64_output);
            Console.WriteLine("     加密结果hex输出：{0}", ciphertext_hex_output);
            Console.WriteLine("     解密base64：{0}", base_64_decrypt);
            Console.WriteLine("     解密hex：{0}", hex_decrypt);
            Console.WriteLine();
            //BASE64 输出
            ciphertext_base_64_output = EncryptHelper.AESEncryptToBase64(plaintext, aes_key, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            //Hex 输出（十六进制输出）
            ciphertext_hex_output = EncryptHelper.AESEncryptToHex(plaintext, aes_key, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            //AES 解密 BASE64
            base_64_decrypt = EncryptHelper.AESDecryptFromBase64(ciphertext_base_64_output, aes_key, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            //AES 解密 Hex
            hex_decrypt = EncryptHelper.AESDecryptFromHex(ciphertext_hex_output, aes_key, aes_iv, AesCipherMode.CFB, AesPaddingMode.PKCS7Padding);
            Console.WriteLine("CFB密码模式");
            Console.WriteLine("     加密结果base64输出：{0}", ciphertext_base_64_output);
            Console.WriteLine("     加密结果hex输出：{0}", ciphertext_hex_output);
            Console.WriteLine("     解密base64：{0}", base_64_decrypt);
            Console.WriteLine("     解密hex：{0}", hex_decrypt);
            Console.WriteLine();
        }
    }
}
