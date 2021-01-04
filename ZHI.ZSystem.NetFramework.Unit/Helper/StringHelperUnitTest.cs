using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Helper
{
    [TestClass]
    public class StringHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            //CreateRandomString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(6));
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(1, 10));
            //CreateRandomNumberString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomNumberString(6));
            //CreateCharacterNumberString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateCharacterNumberString(6));
        }
    }
}
