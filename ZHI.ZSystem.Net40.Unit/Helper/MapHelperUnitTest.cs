using System;

namespace ZHI.ZSystem.Net40.Unit
{
    public class MapHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {
            //天安门 经纬度
            var lntA = 116.403972;
            var latA = 39.915111;
            //人民英雄纪念碑 经纬度
            var lntB = 116.40406;
            var latB = 39.91125;
            var distance = MapHelper.CalcDistance(lntA, latA, lntB, latB);
            Console.WriteLine("经纬度（天安门）：\t\t{0} \t{1}", lntA, latA);
            Console.WriteLine("经纬度（人民英雄纪念碑）：\t{0} \t{1}", lntB, latB);
            Console.WriteLine("距离（米）：{0}", distance);
            Console.WriteLine();
        }
    }
}
