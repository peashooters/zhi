using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NetCore.Unit.Blog
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
            //数字
            var number = "100000";
            var znumber = number.ToInt32();
            Console.WriteLine("ToInt32：{0}", znumber);
            //布尔
            var boolstr = "true";
            var zbool = boolstr.ToBoolean();
            Console.WriteLine("ToBoolean：{0}", zbool);
            //时间
            var datetime = "2021-01-01 08:00:00";
            var zdatetime = datetime.ToDateTime();
            Console.WriteLine("ToDateTime：{0}", zdatetime);
            //还有更多，就不一一列举啦
            //...

            //查看差异
            //使用ZHI.ZSystem以前的写法
            var character = "if it is number";
            int num;
            var is_number = int.TryParse(character, out num);

            if (is_number)
            {
                //character是数字的业务逻辑
                //...
            }

            //使用ZHI.ZSystem以后的写法
            var value = character.TryToInt32();
            if (value.HasValue)
            {
                //character是数字的业务逻辑
                //...
            }
        }
    }
}
