using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NUnit.Extends
{
    public class ExtObjectUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test()
        {
            object number = 1;
            object character = "character";
            object datetime = "2020-11-19";
            //ToUInt16
            Console.WriteLine("ToUInt16：{0}", number.ToUInt16());
            Console.WriteLine("ToUInt16：{0}", character.ToUInt16());
            //ToUInt32
            Console.WriteLine("ToUInt32：{0}", number.ToUInt32());
            Console.WriteLine("ToUInt32：{0}", character.ToUInt32());
            //ToUInt64
            Console.WriteLine("ToUInt64：{0}", number.ToUInt64());
            Console.WriteLine("ToUInt64：{0}", character.ToUInt64());
            //ToInt16
            Console.WriteLine("ToInt16：{0}", number.ToInt16());
            Console.WriteLine("ToInt16：{0}", character.ToInt16());
            //ToInt32
            Console.WriteLine("ToInt32：{0}", number.ToInt32());
            Console.WriteLine("ToInt32：{0}", character.ToInt32());
            //ToInt64
            Console.WriteLine("ToInt64：{0}", number.ToInt64());
            Console.WriteLine("ToInt64：{0}", character.ToInt64());
            //ToDecimal
            Console.WriteLine("ToInt64：{0}", number.ToDecimal());
            Console.WriteLine("ToInt64：{0}", character.ToDecimal());
            //ToDouble
            Console.WriteLine("ToDouble：{0}", number.ToDouble());
            Console.WriteLine("ToDouble：{0}", character.ToDouble());
            //ToSingle
            Console.WriteLine("ToSingle：{0}", number.ToSingle());
            Console.WriteLine("ToSingle：{0}", character.ToSingle());
            //ToBoolean
            Console.WriteLine("ToBoolean：{0}", number.ToBoolean());
            Console.WriteLine("ToBoolean：{0}", character.ToBoolean());
            //ToDateTime
            Console.WriteLine("ToDateTime：{0}", number.ToDateTime());
            Console.WriteLine("ToDateTime：{0}", datetime.ToDateTime());
        }
    }
}
