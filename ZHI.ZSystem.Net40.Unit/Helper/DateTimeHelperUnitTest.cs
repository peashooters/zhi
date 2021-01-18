using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class DateTimeHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            var time = DateTime.Now;
            //
            var timestamp = DateTimeHelper.DateTimeToTimeStamp(time);
            Console.WriteLine("DateTimeToTimeStamp Second：{0}", timestamp);
            //
            timestamp = DateTimeHelper.DateTimeToTimeStamp(time,TimeStampUnit.Millisecond);
            Console.WriteLine("DateTimeToTimeStamp Millisecond：{0}", timestamp);
            //
            var datetime1 = DateTimeHelper.TimeStampToDateTime(timestamp);
            Console.WriteLine("TimeStampToDateTime：{0}", datetime1);
            //
            var datetime2 = DateTimeHelper.TimeStampToDateTime(timestamp.ToString());
            Console.WriteLine("TimeStampToDateTime：{0}", datetime2);
        }
    }
}
