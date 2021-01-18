using System;
using System.Text;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 字符串帮助类（StringHelper）
    /// </summary>
    public static class StringHelper
    {
        #region ====属性（property）
        /// <summary>
        /// 数字
        /// </summary>
        private const string _number_string = "1234567890";
        /// <summary>
        /// 英文
        /// </summary>
        private const string _character_string = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// 数字及英文
        /// </summary>
        private const string _mixed_string = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        #endregion

        /// <summary>
        /// 生成随机字符串（数字）（Generate random strings (numbers)）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string CreateRandomNumberString(int length)
        {
            var builder = new StringBuilder();
            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, _number_string.Length);
                builder.Append(_number_string.Substring(charIndex, 1));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 生成随机字符串（字符）（Generate random strings (characters)）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string CreateCharacterNumberString(int length)
        {
            var builder = new StringBuilder();
            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, _character_string.Length);
                builder.Append(_character_string.Substring(charIndex, 1));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string CreateRandomString(int length)
        {
            var builder = new StringBuilder();
            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, _mixed_string.Length);
                builder.Append(_mixed_string.Substring(charIndex, 1));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string CreateRandomString(int minlength, int maxlength)
        {
            var builder = new StringBuilder();
            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int index = minlength; index < maxlength; index++)
            {
                var charIndex = random.Next(0, _mixed_string.Length);
                builder.Append(_mixed_string.Substring(charIndex, 1));
            }
            return builder.ToString();
        }
    }
}
