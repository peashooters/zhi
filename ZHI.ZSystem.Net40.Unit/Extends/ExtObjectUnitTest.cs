using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class ExtObjectUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            To();
            TryTo();
        }
        private void To()
        {
            var number = (object)100;
            var boolean = (object)true;
            var datetime = (object)"2020-01-01";
            Console.WriteLine("常规转换测试");
            Console.WriteLine("ToUInt16：{0}", number.ToUInt16());
            Console.WriteLine("ToUInt32：{0}", number.ToUInt32());
            Console.WriteLine("ToUInt64：{0}", number.ToUInt64());
            Console.WriteLine("ToInt16：{0}", number.ToInt16());
            Console.WriteLine("ToInt32：{0}", number.ToInt32());
            Console.WriteLine("ToInt64：{0}", number.ToInt64());
            Console.WriteLine("ToSingle：{0}", number.ToSingle());
            Console.WriteLine("ToDouble：{0}", number.ToDouble());
            Console.WriteLine("ToDecimal：{0}", number.ToDecimal());
            Console.WriteLine("ToBoolean：{0}", boolean.ToBoolean());
            Console.WriteLine("ToDateTime：{0}", datetime.ToDateTime());
            Console.WriteLine();

        }
        private void TryTo()
        {
            var character = "ABCD";
            var number = (object)100;
            var boolean = (object)true;
            var datetime = (object)"2020-01-01";
            Console.WriteLine("安全转换测试");
            Console.WriteLine("TryToUInt16：{0} \t\t {1}", character.TryToUInt16(), character.TryToUInt16().HasValue ? "结果错误":"结果正确");
            Console.WriteLine("TryToUInt32：{0} \t\t {1}", character.TryToUInt32(), character.TryToUInt32().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToUInt64：{0} \t\t {1}", character.TryToUInt64(), character.TryToUInt64().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToInt16：{0} \t\t {1}", character.TryToInt16(), character.TryToInt16().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToInt32：{0} \t\t {1}", character.TryToInt32(), character.TryToInt32().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToInt64：{0} \t\t {1}", character.TryToInt64(), character.TryToInt64().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToSingle：{0} \t\t {1}", character.TryToSingle(), character.TryToSingle().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToDouble：{0} \t\t {1}", character.TryToDouble(), character.TryToDouble().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToDecimal：{0} \t\t {1}", character.TryToDecimal(), character.TryToDecimal().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToBoolean：{0} \t\t {1}", character.TryToBoolean(), character.TryToBoolean().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine("TryToDateTime：{0} \t {1}", character.TryToDateTime(), character.TryToDateTime().HasValue ? "结果错误" : "结果正确");
            Console.WriteLine();
            Console.WriteLine("TryToUInt16：{0}", number.TryToUInt16());
            Console.WriteLine("TryToUInt32：{0}", number.TryToUInt32());
            Console.WriteLine("TryToUInt64：{0}", number.TryToUInt64());
            Console.WriteLine("TryToInt16：{0}", number.TryToInt16());
            Console.WriteLine("TryToInt32：{0}", number.TryToInt32());
            Console.WriteLine("TryToInt64：{0}", number.TryToInt64());
            Console.WriteLine("TryToSingle：{0}", number.TryToSingle());
            Console.WriteLine("TryToDouble：{0}", number.TryToDouble());
            Console.WriteLine("TryToDecimal：{0}", number.TryToDecimal());
            Console.WriteLine("TryToBoolean：{0}", boolean.TryToBoolean());
            Console.WriteLine("TryToDateTime：{0}", datetime.TryToDateTime());
        }
    }
}
