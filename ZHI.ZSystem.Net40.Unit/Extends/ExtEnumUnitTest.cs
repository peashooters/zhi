using System;
using System.ComponentModel;

namespace ZHI.ZSystem.Net40.Unit
{
    public class ExtEnumUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            //单元测试启动配置
            var iAmHappy = AreYouHappy.Yes;
            //ToInt
            Console.WriteLine("ToInt：{0}", iAmHappy.ToInt());
            //GetDescription
            Console.WriteLine("GetDescription：{0}", iAmHappy.GetDescription());
        }
    }

    #region ====测试枚举（test enum）
    public enum AreYouHappy
    {
        [Description("No, I'm not happy")]
        No = 0,
        [Description("Yes, I'm happy")]
        Yes = 1,
    }
    #endregion
}
