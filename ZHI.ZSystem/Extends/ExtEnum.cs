using System;
using System.ComponentModel;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 枚举扩展（Enum Extension）
    /// </summary>
    public static class ExtEnum
    {
        /// <summary>
        /// 将当前枚举实例转为int32（Converts the current enumeration instance to int）
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns></returns>
        public static int ToInt(this Enum value)
        {
            return Convert.ToInt32(value);
        }
        /// <summary>
        /// 获取特性 (DisplayAttribute) 的说明，如果未使用该特性，则返回枚举的名称（Gets the description of the attribute (displayattribute); if not used, returns the name of the enumeration）
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var members = type.GetMember(value.ToString());
            if (members != null && members.Length > 0)
            {
                var attrs = members[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                return (attrs != null && attrs.Length > 0) ? attrs[0].Description : string.Empty;
            }
            return string.Empty;
        }
    }
}
