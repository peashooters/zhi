using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 时间帮助类（DateTime Helper）
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 时间转为时间戳（datetime to timestamp）
        /// </summary>
        /// <param name="value">时间</param>
        /// <param name="unit">单位</param>
        /// <returns></returns>
        public static long DateTimeToTimeStamp(DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
            return value.ToUtcTimeStamp(unit);
        }
        /// <summary>
        /// 时间戳转为时间（timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime TimeStampToDateTime(long value)
        {
            return ZConvert.ToDateTimeFromTimeStamp(value);
        }
        /// <summary>
        /// 时间戳转为时间（timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime TimeStampToDateTime(string value)
        {
            return ZConvert.ToDateTimeFromTimeStamp(value);
        }
    }
}
