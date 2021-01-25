using System;
using System.Text;

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
        /// <param name="value">字符串</param>
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
        /// <summary>
        /// 指示当前字符串中是否存在任何值（Indicates whether any value exists in the current string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool HasAnyValue(this String value)
        {
            return value != null && value.Length != 0;
        }
        /// <summary>
        /// 指示当前字符串中是否存在非空值（Indicates whether a non null value exists in the current string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool HasNonEmptyValue(this String value)
        {
            if (value == null) return false;
            return value.Trim().Length > 0;
        }
    }
}
