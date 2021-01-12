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
            //
            var timestamp = DateTimeHelper.DateTimeToTimeStamp(time);
            Console.WriteLine("DateTimeToTimeStamp：{0}", timestamp);
            //
            var datetime = DateTimeHelper.TimeStampToDateTime(timestamp.ToString());
            Console.WriteLine("TimeStampToDateTime：{0}", datetime);
        }
    }
}
