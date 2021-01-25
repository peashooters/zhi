using NUnit.Framework;
using System;
using ZHI.ZSystem;

namespace ZHI.ZSystem.NetCore.Unit.Helper
{
    public class EncodeHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var numbers = "987654321";
            //Base64
            var base64 = EncodeHelper.Base64Encode(numbers);
            Console.WriteLine("Base64Encode：{0}", base64);
            Console.WriteLine("Base64Decode：{0}", EncodeHelper.Base64Decode(base64));
            //Unicode
            var character = "这是Unicode编码";
            var unicode = EncodeHelper.UnicodeEncode(character);
            Console.WriteLine("UnicodeEncode：{0}", unicode);
            Console.WriteLine("UnicodeDecode：{0}", EncodeHelper.UnicodeDecode(unicode));
        }
    }
}
