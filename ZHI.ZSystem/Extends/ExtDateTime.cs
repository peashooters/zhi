using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 时间扩展（DateTime Extension）
    /// </summary>
    public static class ExtDateTime
    {
        /// <summary>
        /// 获取当前DateTime实例的时间戳（Gets the timestamp of the current time instance）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToUtcTimeStamp(this DateTime value)
        {
            var timespan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timespan.TotalSeconds);
        }
    }
}
