using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class ExtDateTimeUnitTest : BaseUnitTest
    {
        public override void Test()
        {

            var datetime = new DateTime(1970,1,1,0,0,0);
            var timestamp = (long)0;
            //ToUtcTimeStamp
            timestamp = datetime.ToUtcTimeStamp();
            Console.WriteLine("ToUtcTimeStamp（Second）：{0}", timestamp);
            //ToUtcTimeStamp
            timestamp = datetime.ToUtcTimeStamp(TimeStampUnit.Millisecond);
            Console.WriteLine("ToUtcTimeStamp（Millisecond）：{0}", timestamp);
        }
    }
}
