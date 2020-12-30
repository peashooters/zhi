using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 字符串扩展（String Extension）
    /// </summary>
    public static class ExtString
    {
        /// <summary>
        /// 如果当前字符串实例为null，则将其转换为string.Empty（If the current string instance is null, it is converted to string.Empty）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static string ToEmptyIfNull(this String value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }
        /// <summary>
        /// 指示当前字符串实例是null、空还是仅由空格字符组成（Indicates whether the current string instance is null, empty, or only composed of space characters）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this String value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
