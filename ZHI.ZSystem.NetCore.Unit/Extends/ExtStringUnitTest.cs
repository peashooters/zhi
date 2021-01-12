using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NetCore.Unit.Extends
{
    public class ExtStringUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test()
        {
            string value = null;
            //ToEmptyIfNull
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            //IsNullOrWhiteSpace
            Console.WriteLine("ToEmptyIfNull：{0}", value.IsNullOrWhiteSpace());
        }
    }
}
