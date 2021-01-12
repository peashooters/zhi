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
            var numbers = "123456";
            //Base64Encode
            var base64 = EncodeHelper.Base64Encode(numbers);
            Console.WriteLine("Base64Encode：{0}", base64);
            //Base64Decode
            Console.WriteLine("Base64Decode：{0}", EncodeHelper.Base64Decode(base64));
        }
    }
}
