using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Exends
{
    [TestClass]
    public class ExtEnumUnitTest
    {
        [TestMethod]
        public void Test()
        {
            var iAmHappy = AreYouHappy.Yes;
            //ToInt
            Console.WriteLine("ToInt：{0}", iAmHappy.ToInt());
            //GetDescription
            Console.WriteLine("GetDescription：{0}" , iAmHappy.GetDescription());
        }
    }
    #region ====测试枚举（test enum）
    public enum AreYouHappy
    {
        [System.ComponentModel.Description("No, I'm not happy")]
        No = 0,
        [System.ComponentModel.Description("Yes, I'm happy")]
        Yes = 1,
    }
    #endregion
}
