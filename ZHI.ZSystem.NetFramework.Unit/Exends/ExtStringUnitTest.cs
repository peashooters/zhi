using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Exends
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
