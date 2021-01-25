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

        #region 私有函数（private function）
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="seed">随机字符串种子</param>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        private static string GenerateRandomString (string seed, int minlength,int maxlength)
        {
            if (seed.IsNullOrWhiteSpace())
                throw new ArgumentOutOfRangeException(paramName:nameof(seed), "seed不能为空字符串（seed cannot be an empty string）");
            if (minlength > maxlength)
                throw new ArgumentOutOfRangeException(paramName: string.Format("{0},{1}",nameof(minlength), nameof(maxlength)), "“minlength”不能大于“maxlength”（'minlength' cannot be greater than 'maxlength'）");
            
            var builder = new StringBuilder();

            var random = new Random(Guid.NewGuid().GetHashCode());
            
            var length = random.Next(minlength, maxlength + 1);

            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, seed.Length);
                builder.Append(seed.Substring(charIndex, 1));
            }

            return builder.ToString();
        }
        #endregion

        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {
            return GenerateRandomString(_mixed_string, length, length);
        }
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string GenerateRandomString(int minlength, int maxlength)
        {
            return GenerateRandomString(_mixed_string, minlength, maxlength);
        }
        /// <summary>
        /// 生成随机字符串（数字）（Generate random strings (numbers)）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateRandomNumberString(int length)
        {
            return GenerateRandomString(_number_string, length, length);
        }
        /// <summary>
        /// 生成随机字符串（数字）（Generate random strings (numbers)）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string GenerateRandomNumberString(int minlength, int maxlength)
        {
            return GenerateRandomString(_number_string, minlength, maxlength);
        }
        /// <summary>
        /// 生成随机字符串（字符）（Generate random strings (characters)）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string GenerateCharacterString(int length)
        {
            return GenerateRandomString(_character_string, length, length);
        }
        /// <summary>
        /// 生成随机字符串（字符）（Generate random strings (characters)）
        /// </summary>
        /// <param name="minlength">最小长度</param>
        /// <param name="maxlength">最大长度</param>
        /// <returns></returns>
        public static string GenerateCharacterString(int minlength, int maxlength)
        {
            return GenerateRandomString(_character_string, minlength, maxlength);
        }

        #region ====废弃的[Obsolete]
        /// <summary>
        /// 生成随机字符串（Generate random strings）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        [Obsolete("该方法已被弃用，请使用GenerateCharacterString代替")]
        public static string CreateCharacterNumberString(int length)
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
        /// 生成随机字符串（数字）（Generate random strings (numbers)）
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns></returns>
        [Obsolete("该方法已被弃用，请使用GenerateRandomNumberString代替")]
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
        /// <param name="length"></param>
        /// <returns></returns>
        [Obsolete("该方法已被弃用，请使用GenerateCharacterString代替")]
        public static string CreateCharacterString(int length)
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
        [Obsolete("该方法已被弃用，请使用GenerateRandomString代替")]
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
        [Obsolete("该方法已被弃用，请使用GenerateRandomString代替")]
        public static string CreateRandomString(int minlength, int maxlength)
        {
            var builder = new StringBuilder();
            var random = new Random(Guid.NewGuid().GetHashCode());
            var length = random.Next(minlength, maxlength);
            for (int index = 0; index < length; index++)
            {
                var charIndex = random.Next(0, _mixed_string.Length);
                builder.Append(_mixed_string.Substring(charIndex, 1));
            }
            return builder.ToString();
        }
        #endregion
    }
}
