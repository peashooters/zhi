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
        public static ushort ToUInt16(this object value)
        {
            return Convert.ToUInt16(value);
        }
        /// <summary>
        /// 将对象实例转换为UInt32（Convert object instance to UInt32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static uint ToUInt32(this object value)
        {
            return Convert.ToUInt16(value);
        }
        /// <summary>
        /// 将对象实例转换为UInt64（Convert object instance to UInt64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ulong ToUInt64(this object value)
        {
            return Convert.ToUInt64(value);
        }
        /// <summary>
        /// 将对象实例转换为Int16（Convert object instance to Int16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static short ToInt16(this object value)
        {
            return Convert.ToInt16(value);
        }
        /// <summary>
        /// 将对象实例转换为Int32（Convert object instance to Int32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static int ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }
        /// <summary>
        /// 将对象实例转换为Int64（Convert object instance to Int64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static long ToInt64(this object value)
        {
            return Convert.ToInt64(value);
        }
        /// <summary>
        /// 将对象实例转换为Decimal（Convert object instance to Decimal）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object value)
        {
            return Convert.ToDecimal(value);
        }
        /// <summary>
        /// 将对象实例转换为Double（Convert object instance to Double）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static double ToDouble(this object value)
        {
            return Convert.ToDouble(value);
        }
        /// <summary>
        /// 将对象实例转换为float（Convert object instance to float）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static float ToSingle(this object value)
        {
            return Convert.ToSingle(value);
        }
        /// <summary>
        /// 将对象实例转换为Boolean（Convert object instance to Boolean）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static bool ToBoolean(this object value)
        {
            return Convert.ToBoolean(value);
        }
        /// <summary>
        /// 将对象实例转换为DateTime（Convert object instance to DateTime）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }
        #endregion

        #region ====TryTo
        /// <summary>
        /// 将对象实例转换为UInt16（Convert object instance to UInt16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ushort? TryToUInt16(this object value)
        {
            try
            {
                return value.ToUInt16();
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
        public static uint? TryToUInt32(this object value)
        {
            try
            {
                return value.ToUInt32();
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
        public static ulong? TryToUInt64(this object value)
        {
            try
            {
                return value.ToUInt64();
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
        public static short? TryToInt16(this object value)
        {
            try
            {
                return value.ToInt16();
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
        public static int? TryToInt32(this object value)
        {
            try
            {
                return value.ToInt32();
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
        public static long? TryToInt64(this object value)
        {
            try
            {
                return value.ToInt64();
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
        public static decimal? TryToDecimal(this object value)
        {
            try
            {
                return value.ToDecimal();
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
        public static double? TryToDouble(this object value)
        {
            try
            {
                return value.ToDouble();
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
        public static float? TryToSingle(this object value)
        {
            try
            {
                return value.ToSingle();
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
        public static bool? TryToBoolean(this object value)
        {
            try
            {
                return value.ToBoolean();
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
        public static DateTime? TryToDateTime(this object value)
        {
            try
            {
                return value.ToDateTime();
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
