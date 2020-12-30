using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 对象扩展(Object Extension)
    /// </summary>
    public static class ExtObject
    {
        #region ====To
        /// <summary>
        /// 将对象实例转换为UInt16（Convert object instance to UInt16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ushort? ToUInt16(this object value)
        {
            try
            {
                return Convert.ToUInt16(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为UInt32（Convert object instance to UInt32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static uint? ToUInt32(this object value)
        {
            try
            {
                return Convert.ToUInt32(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为UInt64（Convert object instance to UInt64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ulong? ToUInt64(this object value)
        {
            try
            {
                return Convert.ToUInt64(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Int16（Convert object instance to Int16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static short? ToInt16(this object value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Int32（Convert object instance to Int32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static int? ToInt32(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Int64（Convert object instance to Int64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static long? ToInt64(this object value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Decimal（Convert object instance to Decimal）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Double（Convert object instance to Double）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static double? ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为float（Convert object instance to float）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static float? ToSingle(this object value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Boolean（Convert object instance to Boolean）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static bool? ToBoolean(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为DateTime（Convert object instance to DateTime）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
