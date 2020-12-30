using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NUnit.Extends
{
    public class ExtEnumUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var iAmHappy = AreYouHappy.Yes;
            //ToInt
            Console.WriteLine(iAmHappy.ToInt());
            //GetDescription
            Console.WriteLine(iAmHappy.GetDescription());
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
