using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZHI.ZSystem.Net45.Unit.Helper
{
    [TestClass]
    public class IPHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            var ip = "192.168.0.1";
            var number = (long)987654321;
            Console.WriteLine("IpToLong：{0}", IPHelper.IpToLong(ip));
            Console.WriteLine("LongToIp：{0}", IPHelper.LongToIp(number));
        }
    }
}
