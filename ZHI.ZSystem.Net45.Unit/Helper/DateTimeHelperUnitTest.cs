using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.Net45.Unit.Helper
{
    [TestClass]
    public class DateTimeHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            var time = DateTime.Now;

            long timeStamp=DateTimeHelper.DateTimeToTimeStamp(time);
            Console.WriteLine("DateTimeToTimeStamp(不指定单位)：{0}", timeStamp);

            DateTime dt= DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(一般)：{0}", dt);

            timeStamp = DateTimeHelper.DateTimeToTimeStamp(time, TimeStampUnit.Millisecond);
            Console.WriteLine("DateTimeToTimeStamp(指定单位 ms)：{0}", timeStamp);

            dt = DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(指定单位 ms)：{0}", dt);

            timeStamp = DateTimeHelper.DateTimeToTimeStamp(time, TimeStampUnit.Second);
            Console.WriteLine("DateTimeToTimeStamp(指定单位 s)：{0}", timeStamp);

            dt = DateTimeHelper.TimeStampToDateTime(timeStamp);
            Console.WriteLine("TimeStampToDateTime(指定单位 s)：{0}", dt);

            dt = DateTimeHelper.TimeStampToDateTime("987654321");
            Console.WriteLine("TimeStampToDateTime(长整数字符串)：{0}", dt);

            //Console.WriteLine("DateTimeToTimeStamp默认单位到秒");
        }
    }
}
