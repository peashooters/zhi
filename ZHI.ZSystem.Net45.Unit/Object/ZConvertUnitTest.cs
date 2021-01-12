using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.Net45.Unit.Object
{
    [TestClass]
    public class ZConvertUnitTest
    {
        [TestMethod]
        public void Test()
        {
            Console.WriteLine("ZConvertUnitTest（数据转换类单元测试）");
            Console.WriteLine();
            To();
            TryTo();
        }
        private void To()
        {
            //base64
            var character = "ABCDEFG";
            var base64 = "WkhJ5qGG5p6257uE5Lu2";
            Console.WriteLine("base64");
            Console.WriteLine("     ToBase64Encode：{0}", ZConvert.ToBase64Encode(character));
            Console.WriteLine("     ToBase64Decode：{0}", ZConvert.ToBase64Decode(base64));
            //timestamp
            var timestamp = "1609430400";
            Console.WriteLine("timestamp");
            Console.WriteLine("     ToDateTimeFromTimeStamp：{0}", ZConvert.ToDateTimeFromTimeStamp(timestamp));
            Console.WriteLine("     ToTimeStampFromDateTime：{0}", ZConvert.ToTimeStampFromDateTime(DateTime.Now));
            //enum
            Console.WriteLine("enum");
            Console.WriteLine("     ToIntFromEnum：{0}", ZConvert.ToIntFromEnum(TimeStampUnit.Millisecond));
            //ip
            Console.WriteLine("ip");
            Console.WriteLine("     ToIpFromLong：{0}", ZConvert.ToIpFromLong(2130706433));
            Console.WriteLine("     ToLongFromIp：{0}", ZConvert.ToLongFromIp("127.0.0.1"));
            Console.WriteLine();
            Console.WriteLine();
        }

        private void TryTo()
        {
            //base64
            var character = "ABCDEFG";
            var base64 = "WkhJ5qGG5p6257uE5Lu2";
            Console.WriteLine("base64");
            Console.WriteLine("     TryToBase64Encode：{0}", ZConvert.TryToBase64Encode(character));
            Console.WriteLine("     TryToBase64Decode：{0}", ZConvert.TryToBase64Decode(base64));
            //timestamp
            var timestamp = "1609430400";
            Console.WriteLine("timestamp");
            Console.WriteLine("     TryToDateTimeFromTimeStamp：{0}", ZConvert.TryToDateTimeFromTimeStamp(timestamp));
            Console.WriteLine("     TryToTimeStampFromDateTime：{0}", ZConvert.TryToTimeStampFromDateTime(DateTime.Now));
            //ip
            Console.WriteLine("ip");
            Console.WriteLine("     TryToIpFromLong：{0}", ZConvert.TryToIpFromLong(2130706433));
            Console.WriteLine("     TryToLongFromIp：{0}", ZConvert.TryToLongFromIp("127.0.0.1"));
            //bool
            Console.WriteLine("bool");
            Console.WriteLine("     TryToBoolean：{0}", ZConvert.TryToBoolean("true"));
            //datetime
            Console.WriteLine("datetime");
            Console.WriteLine("     TryToDateTime：{0}", ZConvert.TryToDateTime("2021-01-01"));
            //number
            Console.WriteLine("number");
            Console.WriteLine("     TryToDecimal：{0}", ZConvert.TryToDecimal("100"));
            Console.WriteLine("     TryToDouble：{0}", ZConvert.TryToDouble("100"));
            Console.WriteLine("     TryToInt16：{0}", ZConvert.TryToInt16("100"));
            Console.WriteLine("     TryToInt32：{0}", ZConvert.TryToInt32("100"));
            Console.WriteLine("     TryToInt64：{0}", ZConvert.TryToInt64("100"));
            Console.WriteLine("     TryToSingle：{0}", ZConvert.TryToSingle("100"));
            Console.WriteLine("     TryToUInt16：{0}", ZConvert.TryToUInt16("100"));
            Console.WriteLine("     TryToUInt32：{0}", ZConvert.TryToUInt32("100"));
            Console.WriteLine("     TryToUInt64：{0}", ZConvert.TryToUInt64("100"));
        }
    }
}
