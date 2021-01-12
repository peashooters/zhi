using System;
using System.Text;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 编码帮助类（Encode Helper）
    /// </summary>
    public static class EncodeHelper
    {
        #region ====Base64
        /// <summary>
        /// 将字符串转换成base64格式,使用UTF8字符集（Use utf8 character set to convert string to Base64 format）
        /// </summary>
        /// <param name="input">编码字符串</param>
        /// <returns></returns>
        public static string Base64Encode(string input)
        {
            return ZConvert.ToBase64Encode(input);
        }
        /// <summary>
        /// 将base64格式字符串，转换UTF8字符集（Extracting Base64 string content with utf8 character set）
        /// </summary>
        /// <param name="input">解码字符串</param>
        /// <returns></returns>
        public static string Base64Decode(string input)
        {
            return ZConvert.ToBase64Decode(input);
        }
        #endregion
    }
}
