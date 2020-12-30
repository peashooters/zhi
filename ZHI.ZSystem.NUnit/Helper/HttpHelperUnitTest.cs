using NUnit.Framework;
using System;
using ZHI.ZSystem;

namespace ZHI.ZSystem.NUnit.Helper
{
    public class HttpHelperUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var html = HttpHelper.HttpGet("https://www.baidu.com/");
            Console.WriteLine(html);
        }
    }
}
