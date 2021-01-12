using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZHI.ZSystem.Net45.Unit.Helper
{
    [TestClass]
    public class EncodeHelperUnitTest
    {
        [TestMethod]
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
