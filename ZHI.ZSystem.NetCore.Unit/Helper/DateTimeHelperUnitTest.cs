using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NetCore.Unit.Helper
{
    public class DateTimeHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var time = DateTime.Now;
            //
            var timestamp = DateTimeHelper.DateTimeToTimeStamp(time);
            Console.WriteLine("DateTimeToTimeStamp：{0}", timestamp);
            //
            var datetime = DateTimeHelper.TimeStampToDateTime(timestamp.ToString());
            Console.WriteLine("TimeStampToDateTime：{0}", datetime);
        }
    }
}
