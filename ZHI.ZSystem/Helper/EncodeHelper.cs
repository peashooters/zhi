namespace ZHI.ZSystem
{
    /// <summary>
    /// 编码帮助类（Encode Helper）
    /// </summary>
    public static class EncodeHelper
    {
        #region ====Base64
        /// <summary>
        /// Base64编码字符串（Base64 encoding string）
        /// </summary>
        /// <param name="value">编码字符串</param>
        /// <returns></returns>
        public static string Base64Encode(string value)
        {
            return ZConvert.ToBase64Encode(value);
        }
        /// <summary>
        /// Base64解码字符串（Base64 decode string）
        /// </summary>
        /// <param name="value">解码字符串</param>
        /// <returns></returns>
        public static string Base64Decode(string value)
        {
            return ZConvert.ToBase64Decode(value);
        }
        #endregion

        #region ====Unicode
        /// <summary>
        /// Unicode编码字符串（Unicode encoding a string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string UnicodeEncode(string value)
        {
            return ZConvert.ToUnicodeEncode(value);
        }
        /// <summary>
        /// Unicode解码字符串（Unicode decode string）
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string UnicodeDecode(string value)
        {
            return ZConvert.ToUnicodeDecode(value);
        }
        #endregion
    }
}
