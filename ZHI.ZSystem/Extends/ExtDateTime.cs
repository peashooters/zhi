using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 时间扩展（DateTime Extension）
    /// </summary>
    public static class ExtDateTime
    {
        #region ====属性（property）
        /// <summary>
        /// 时间戳计算起始时间
        /// </summary>
        private static readonly DateTime _unix_init_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        /// <summary>
        /// 获取当前DateTime实例的时间戳（Gets the timestamp of the current time instance）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit">精确单位</param>
        /// <returns></returns>
        public static long ToUtcTimeStamp(this DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
            var localInitTime = TimeZoneInfo.ConvertTimeFromUtc(_unix_init_time, TimeZoneInfo.Local);

            var timespan = value - localInitTime;

            if (unit == TimeStampUnit.Second)
                return Convert.ToInt64(timespan.TotalSeconds);
            else
                return Convert.ToInt64(timespan.TotalMilliseconds);
        }
    }
}
