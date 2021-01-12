using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class IPHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            var ip = "192.168.0.1";
            var number = (long)2130706433;
            Console.WriteLine("IpToLong：{0}", IPHelper.IpToLong(ip));
            Console.WriteLine("LongToIp：{0}", IPHelper.LongToIp(number));
        }
    }
}
