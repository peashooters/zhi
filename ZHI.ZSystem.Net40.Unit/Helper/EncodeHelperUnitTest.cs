using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class EncodeHelperUnitTest : BaseUnitTest
    {
        public override void Test()
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
