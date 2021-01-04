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
            var hosts = ip.Split('.');

            if (hosts.Length != 4)
                throw new ArgumentOutOfRangeException("IP地址格式错误（IP address format error）");

            var number = Convert.ToInt64(hosts[0]) << 24 | Convert.ToInt64(hosts[1]) << 16 | Convert.ToInt64(hosts[2]) << 8 | Convert.ToInt64(hosts[3]);

            return number;
        }
        /// <summary>
        /// 将Int64转换为IP地址（Convert Int64 to IP address）
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static string LongToIp(long ip)
        {
            var builder = new StringBuilder();
            builder.Append(ip >> 0x18 & 0xff).Append(".");
            builder.Append(ip >> 0x10 & 0xff).Append(".");
            builder.Append(ip >> 0x8 & 0xff).Append(".");
            builder.Append(ip & 0xff);
            return builder.ToString();
        }
    }

}
