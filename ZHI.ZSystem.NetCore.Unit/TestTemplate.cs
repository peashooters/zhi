using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            Example();
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
    }
}
