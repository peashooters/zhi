using NUnit.Framework;
using System;
using ZHI.ZSystem;

namespace ZHI.ZSystem.NetCore.Unit.Helper
{
    public class StringHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //CreateRandomString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.GenerateRandomString(3));
            Console.WriteLine("CreateRandomString：{0}", StringHelper.GenerateRandomString(1, 3));
            Console.WriteLine("GenerateCharacterString：{0}", StringHelper.GenerateCharacterString(3));
            Console.WriteLine("GenerateCharacterString：{0}", StringHelper.GenerateCharacterString(1, 3));
            Console.WriteLine("GenerateRandomNumberString：{0}", StringHelper.GenerateRandomNumberString(3));
            Console.WriteLine("GenerateRandomNumberString：{0}", StringHelper.GenerateRandomNumberString(1, 3));
            Console.WriteLine("Obsolete");
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(6));
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(1, 10));
            //CreateRandomNumberString
            Console.WriteLine("CreateRandomNumberString：{0}", StringHelper.CreateRandomNumberString(6));
            //CreateCharacterNumberString
            Console.WriteLine("CreateCharacterNumberString：{0}", StringHelper.CreateCharacterNumberString(6));
        }
    }
}
