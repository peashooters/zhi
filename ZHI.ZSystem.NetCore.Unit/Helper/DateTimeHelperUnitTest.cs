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

            long timeStamp = DateTimeHelper.DateTimeToTimeStamp(time);
            Console.WriteLine("DateTimeToTimeStamp(不指定单位)：{0}", timeStamp);

            DateTime dt = DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(一般)：{0}", dt);

            timeStamp = DateTimeHelper.DateTimeToTimeStamp(time, TimeStampUnit.Millisecond);
            Console.WriteLine("DateTimeToTimeStamp(指定单位 ms)：{0}", timeStamp);

            dt = DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(指定单位 ms)：{0}", dt);

            timeStamp = DateTimeHelper.DateTimeToTimeStamp(time, TimeStampUnit.Second);
            Console.WriteLine("DateTimeToTimeStamp(指定单位 s)：{0}", timeStamp);

            dt = DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(指定单位 s)：{0}", dt);

            dt = DateTimeHelper.TimeStampToDateTime("123456789");
            Console.WriteLine("TimeStampToDateTime(长整数字符串)：{0}", dt);
        }
    }
}
