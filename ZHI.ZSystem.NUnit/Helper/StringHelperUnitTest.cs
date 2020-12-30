using NUnit.Framework;
using System;
using ZHI.ZSystem;

namespace ZHI.ZSystem.NUnit.Helper
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
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(6));
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomString(1, 10));
            //CreateRandomNumberString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateRandomNumberString(6));
            //CreateCharacterNumberString
            Console.WriteLine("CreateRandomString：{0}", StringHelper.CreateCharacterNumberString(6));
        }
    }
}
