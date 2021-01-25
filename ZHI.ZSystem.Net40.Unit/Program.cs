using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //针对xxx进行单元测试
            var type = typeof(EncodeHelperUnitTest);
            Console.WriteLine("执行单元测试：{0}", type.Name);
            Console.WriteLine();
            //创建单元测试实例
            var unitTestInstance = type.Assembly.CreateInstance(type.FullName) as BaseUnitTest;
            unitTestInstance.Start();
            //
            Console.WriteLine();
            Console.WriteLine("请按任意键继续...");
            Console.ReadKey();

        }
    }
}
