using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Helper
{
    [TestClass]
    public class IPHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            var ip = "192.168.0.1";
            var number = (long)2130706433;
            Console.WriteLine("IpToLong：{0}", IPHelper.IpToLong(ip));
            Console.WriteLine("LongToIp：{0}", IPHelper.LongToIp(number));
        }
    }
}
