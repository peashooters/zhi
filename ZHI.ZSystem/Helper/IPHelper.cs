using System;
using System.Text;

namespace ZHI.ZSystem
{
    /// <summary>
    /// IP帮助类（IP Helper）
    /// </summary>
    public static class IPHelper
    {
        /// <summary>
        /// 将IP地址转换为Int64（Convert IP address to Int64）
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static long IpToLong(string ip)
        {
            return ZConvert.ToLongFromIp(ip);
        }
        /// <summary>
        /// 将Int64转换为IP地址（Convert Int64 to IP address）
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static string LongToIp(long ip)
        {
            return ZConvert.ToIpFromLong(ip);
        }
    }

}
