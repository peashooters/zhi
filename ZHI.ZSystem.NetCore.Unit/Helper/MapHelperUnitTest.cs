using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZHI.ZSystem.NetCore.Unit.Helper
{
    public class MapHelperUnitTest
    {
        [SetUp]
        public void SetUp()
        {

        } 
        [Test]
        public void Test()
        {
            Example();
        }

        private void Example()
        {
            //夏威夷 经纬度  
            var lntA = -157.84087657928467;
            var latA = 21.287834858307562;
            //重庆 经纬度
            var lntB = 106.55;
            var latB = 29.57;
            var distance = MapHelper.CalcDistance(lntA, latA, lntB, latB);
            Console.WriteLine("经纬度（夏威夷）：\t\t{0} \t{1}", lntA, latA);
            Console.WriteLine("经纬度（重庆）：\t{0} \t{1}", lntB, latB);
            Console.WriteLine("距离梦想的天堂（米）：{0}", distance);
            Console.WriteLine();
        }
    }
}
