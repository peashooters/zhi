using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Exends
{
    [TestClass]
    public class ExtDateTimeUnitTest
    {
        [TestMethod]
        public void Test()
        {
            var datetime = DateTime.Now;
            //ToUtcTimeStamp
            var valueUtcTimeStamp = datetime.ToUtcTimeStamp();
            Console.WriteLine("ToUtcTimeStamp：{0}", valueUtcTimeStamp);
        }
    }
}
