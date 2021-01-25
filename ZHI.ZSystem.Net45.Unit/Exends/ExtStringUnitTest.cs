using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ZHI.ZSystem.Net45.Unit.Exends
{
    [TestClass]
    public class ExtStringUnitTest
    {
        [TestMethod]
        public void Test()
        {

            string value = null;
            Console.WriteLine("测试value为null");
            //ToEmptyIfNull
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            //HasNonEmptyValue
            Console.WriteLine("HasNonEmptyValue：{0}", value.HasNonEmptyValue());
            Console.WriteLine();

            value = "    ";
            Console.WriteLine("测试value为空格");
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            //HasNonEmptyValue
            Console.WriteLine("HasNonEmptyValue：{0}", value.HasNonEmptyValue());
            Console.WriteLine();

            //HasAnyValue
            value = "    a    ";
            Console.WriteLine("测试value为字符");
            //IsNullOrWhiteSpace
            Console.WriteLine("IsNullOrWhiteSpace：{0}", value.IsNullOrWhiteSpace());
            //HasAnyValue
            Console.WriteLine("HasAnyValue：{0}", value.HasAnyValue());
            //HasNonEmptyValue
            Console.WriteLine("HasNonEmptyValue：{0}", value.HasNonEmptyValue());
        }
    }
}
