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
            //ToEmptyIfNull
            Console.WriteLine("ToEmptyIfNull：{0}", value.ToEmptyIfNull());
            //IsNullOrWhiteSpace
            Console.WriteLine("ToEmptyIfNull：{0}", value.IsNullOrWhiteSpace());
        }
    }
}
