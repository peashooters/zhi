using System;
using System.Text;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 数据转换类（data conversion class）
    /// </summary>
    public static class ZConvert
    {
        #region ====属性（property）
        /// <summary>
        /// 时间戳起始时间
        /// </summary>
        private static readonly DateTime _unix_init_time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        #endregion

        #region ====To
        /// <summary>
        /// 字符串转为Base64字符串（From string to base64 string）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64Encode(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Base64字符串转为字符串（From Base64 string to string）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64Decode(string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// 时间戳转为时间（From timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromTimeStamp(long value)
        {
            var localInitTime = TimeZoneInfo.ConvertTimeFromUtc(_unix_init_time, TimeZoneInfo.Local);
            //
            var timestamp = value.ToString();

            if (timestamp.Length == 10)
                return localInitTime.AddSeconds(value);
            else
                return localInitTime.AddMilliseconds(value);

        }
        /// <summary>
        /// 时间戳转为时间（From timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromTimeStamp(string value)
        {
            return ToDateTimeFromTimeStamp(Convert.ToInt64(value));
        }
        /// <summary>
        /// 枚举转为Int32（From enum to int32）
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns></returns>
        public static int ToIntFromEnum(Enum value)
        {
            return value.ToInt();
        }
        /// <summary>
        /// IP地址转换为Int64（From IP address to Int64）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLongFromIp(string value)
        {
            var hosts = value.Split('.');

            if (hosts.Length != 4)
                throw new ArgumentOutOfRangeException("IP地址格式错误（IP address format error）");

            var number = Convert.ToInt64(hosts[0]) << 24 | Convert.ToInt64(hosts[1]) << 16 | Convert.ToInt64(hosts[2]) << 8 | Convert.ToInt64(hosts[3]);

            return number;
        }
        /// <summary>
        /// Int64转换为IP地址（From Int64 to IP address）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToIpFromLong(long value)
        {
            var builder = new StringBuilder();
            builder.Append(value >> 0x18 & 0xff).Append(".");
            builder.Append(value >> 0x10 & 0xff).Append(".");
            builder.Append(value >> 0x8 & 0xff).Append(".");
            builder.Append(value & 0xff);
            return builder.ToString();
        }
        /// <summary>
        /// 时间转为时间戳（From datetime to timestamp）
        /// </summary>
        /// <param name="value">时间</param>
        /// <param name="unit">精确单位</param>
        /// <returns></returns>
        public static long ToTimeStampFromDateTime(DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
            return value.ToUtcTimeStamp(unit);
        }
        /// <summary>
        /// 字符串转为Unicode字符串（From string to unicode string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToUnicodeEncode(string value)
        {
            var charArray = value.ToCharArray();
            var builder = new StringBuilder();
            byte[] bytes;
            for (int index = 0; index < charArray.Length; index++)
            {
                bytes = Encoding.Unicode.GetBytes(charArray[index].ToString());
                builder.Append(string.Format("\\u{0:X2}{1:X2}", bytes[1], bytes[0]));
            }
            return builder.ToString();
        }
        /// <summary>
        /// Unicode字符串转为字符串（From unicode string to string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string ToUnicodeDecode(string value)
        {
            var builder = new StringBuilder();
            var length = value.Length / 6;
            for (int index = 0; index <= length - 1; index++)
            {
                var character = value.Substring(0, 6).Substring(2);
                value = value.Substring(6);
                var bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(character.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(character.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                builder.Append(Encoding.Unicode.GetString(bytes));
            }
            return builder.ToString();
        }
        #endregion

        #region ====TryTo
        /// <summary>
        /// 字符串转为Base64字符串（From string to base64 string）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TryToBase64Encode(string value)
        {
            try
            {
                return ZConvert.ToBase64Encode(value);
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// Base64字符串转为字符串（From Base64 string to string）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TryToBase64Decode(string value)
        {
            try
            {
                return ZConvert.ToBase64Decode(value);
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
        public static bool? TryToBoolean(object value)
        {
            return value.TryToBoolean();
        }
        /// <summary>
        /// 将对象实例转换为DateTime（Convert object instance to DateTime）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static DateTime? TryToDateTime(object value)
        {
            return value.TryToDateTime();
        }
        /// <summary>
        /// 时间戳转为时间（From timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime? TryToDateTimeFromTimeStamp(long value)
        {
            try
            {
                return ZConvert.ToDateTimeFromTimeStamp(value);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 时间戳转为时间（From timestamp to datetime）
        /// </summary>
        /// <param name="value">时间戳</param>
        /// <returns></returns>
        public static DateTime? TryToDateTimeFromTimeStamp(string value)
        {
            try
            {
                return ToDateTimeFromTimeStamp(value);
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
        public static decimal? TryToDecimal(object value)
        {
            return value.TryToDecimal();
        }
        /// <summary>
        /// 将对象实例转换为Double（Convert object instance to Double）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static double? TryToDouble(object value)
        {
            return value.TryToDouble();
        }
        /// <summary>
        /// IP地址转换为Int64（From IP address to Int64）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long? TryToLongFromIp(string value)
        {
            try
            {
                return ZConvert.ToLongFromIp(value);
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为Int16（Convert object instance to Int16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static short? TryToInt16(object value)
        {
            return value.TryToInt16();
        }
        /// <summary>
        /// 将对象实例转换为Int32（Convert object instance to Int32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static int? TryToInt32(object value)
        {
            return value.TryToInt32();
        }
        /// <summary>
        /// 将对象实例转换为Int64（Convert object instance to Int64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static long? TryToInt64(object value)
        {
            return value.TryToInt64();
        }
        /// <summary>
        /// Int64转换为IP地址（From Int64 to IP address）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TryToIpFromLong(long value)
        {
            try
            {
                return ZConvert.ToIpFromLong(value);
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为float（Convert object instance to float）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static float? TryToSingle(object value)
        {
            return value.TryToSingle();
        }
        /// <summary>
        /// 时间转为时间戳（From datetime to timestamp）
        /// </summary>
        /// <param name="value">时间</param>
        /// <param name="unit">精确单位</param>
        /// <returns></returns>
        public static long? TryToTimeStampFromDateTime(DateTime value, TimeStampUnit unit = TimeStampUnit.Second)
        {
            try
            {
                return value.ToUtcTimeStamp(unit);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将对象实例转换为UInt16（Convert object instance to UInt16）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ushort? TryToUInt16(object value)
        {
            return value.TryToUInt16();
        }
        /// <summary>
        /// 将对象实例转换为UInt32（Convert object instance to UInt32）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static uint? TryToUInt32(object value)
        {
            return value.TryToUInt32();
        }
        /// <summary>
        /// 将对象实例转换为UInt64（Convert object instance to UInt64）
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public static ulong? TryToUInt64(object value)
        {
            return value.TryToUInt64();
        }
        /// <summary>
        /// 字符串转为Unicode字符串（From string to unicode string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string TryToUnicodeEncode(string value)
        {
            try
            {
                return ZConvert.ToUnicodeEncode(value);
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Unicode字符串转为字符串（From unicode string to string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string TryToUnicodeDecode(string value)
        {
            try
            {
                return ZConvert.ToUnicodeDecode(value);
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
