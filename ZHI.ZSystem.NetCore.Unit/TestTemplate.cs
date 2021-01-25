using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZHI.ZSystem.NetCore.Unit
{
    public class TestTemplate
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //ToUnicode
            var value = "哈哈哈张三";
            var s = EncodeHelper.UnicodeEncode(value);
            Console.WriteLine("ToUnicode：{0}", s);
            Console.WriteLine("UnicodeDecode：{0}", EncodeHelper.UnicodeDecode(s));
        }

        public void Example()
        {
            //将字符串进行base64编码、解码
            var character = "123456ABCDE";
            var baseString1 = ZConvert.ToBase64Encode(character);
            var baseString2 = ZConvert.ToBase64Decode(baseString1);
            //将时间转为时间戳/将时间戳转为时间
            var timestamp = ZConvert.ToTimeStampFromDateTime(DateTime.Now);
            var datetime = ZConvert.ToDateTimeFromTimeStamp(timestamp);
            //得到枚举的int32值
            var enumber = ZConvert.ToIntFromEnum(TimeStampUnit.Millisecond);
            //IP转为数字/数字转为IP
            var inumber = ZConvert.ToLongFromIp("127.0.0.1");
            var ip = ZConvert.ToIpFromLong(inumber);

            //在转换过程中，你并不想在转换失败的时候抛出异常，那么建议你试试TryTo方法
            //将字符串/object转为数字
            var number = "123456";
            var number1 = ZConvert.TryToInt32(number);//也可使用：TryToInt16()、TryToInt64()
            var number2 = ZConvert.TryToUInt32(number);//也可使用：TryToUInt16()、TryToUInt64()
            //将时间转为时间戳/将时间戳转为时间
            var timestamp2 = ZConvert.TryToTimeStampFromDateTime(DateTime.Now);
            var datetime2 = ZConvert.TryToDateTimeFromTimeStamp(timestamp);
            //...
        }

        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }
        /// <summary> 
        /// 字符串转为UniCode码字符串 
        /// </summary> 
        /// <param name="s"></param> 
        /// <returns></returns> 
        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
        /// <summary> 
        /// Unicode字符串转为正常字符串 
        /// </summary> 
        /// <param name="srcText"></param> 
        /// <returns></returns> 
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
    }
}
