using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class ExtStringUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            string value = null;
            //ToEmptyIfNull
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            //IsNullOrWhiteSpace
            Console.WriteLine("ToEmptyIfNull：{0}", value.IsNullOrWhiteSpace());
        }
    }
}
