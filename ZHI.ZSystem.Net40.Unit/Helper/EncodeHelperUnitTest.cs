using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class EncodeHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            var numbers = "123456";
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
