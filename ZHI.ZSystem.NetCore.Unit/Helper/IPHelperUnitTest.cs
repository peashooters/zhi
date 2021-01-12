using NUnit.Framework;
using System;
using System.Net;

namespace ZHI.ZSystem.NetCore.Unit.Helper
{
    public class IPHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ip = "192.168.0.1";
            var number = (long)2130706433;
            Console.WriteLine("IpToLong：{0}", IPHelper.IpToLong(ip));
            Console.WriteLine("LongToIp：{0}", IPHelper.LongToIp(number));
        }
    }
}
