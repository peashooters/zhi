using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.Net45.Unit.Helper
{
    [TestClass]
    public class MapHelperUnitTest
    {
        [TestMethod]
        public void Test()
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
