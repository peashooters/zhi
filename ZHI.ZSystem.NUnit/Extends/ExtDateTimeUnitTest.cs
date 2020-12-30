using NUnit.Framework;
using System;

namespace ZHI.ZSystem.NUnit.Extends
{
    public class ExtDateTimeUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //
            var datetime = DateTime.Now;
            //ToUtcTimeStamp
            var valueUtcTimeStamp = datetime.ToUtcTimeStamp();
            Console.WriteLine(valueUtcTimeStamp);
        }
    }
}
