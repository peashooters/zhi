using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class StringHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            //CreateRandomString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(6));
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(1, 10));
            //CreateRandomNumberString
            Console.WriteLine("CreateRandomNumberString：{0}", StringHelper.CreateRandomNumberString(6));
            //CreateCharacterNumberString
            Console.WriteLine("CreateCharacterNumberString：{0}", StringHelper.CreateCharacterNumberString(6));
        }
    }
}
