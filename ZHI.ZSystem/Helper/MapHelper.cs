using System;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 
    /// </summary>
    public static class MapHelper
    {
        #region ====属性（property）
        /// <summary>
        /// 地球半径
        /// </summary>
        private const double _earth_radius = 6378137;
        #endregion

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="line">经度/纬度</param>
        /// <returns></returns>
        private static double Arc(double line)
        {
            return line * Math.PI / 180d;
        }

        /// <summary>
        /// 计算两个经纬坐标的距离（单位：m）（Calculate the distance between two longitude and latitude coordinates（m））
        /// </summary>
        /// <param name="longitudeA">第一点经度（The longitude of the first point）</param>
        /// <param name="latitudeA">第一点纬度（The latitude of the first point）</param>
        /// <param name="longitudeB">第二点经度（The longitude of the second point）</param>
        /// <param name="latitudeB">第二点纬度（The latitude of the second point）</param>
        /// <returns></returns>
        public static double CalcDistance(double longitudeA, double latitudeA, double longitudeB, double latitudeB)
        {
            //所在经纬线
            var arclntA = Arc(longitudeA);
            var arclatA = Arc(latitudeA);
            var arcLntB = Arc(longitudeB);
            var arcLatB = Arc(latitudeB);
            //经纬差
            var latDiffer = arclatA - arcLatB;
            var lntDiffer = arclntA - arcLntB;

            var distance = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(latDiffer / 2), 2) + Math.Cos(arclatA) * Math.Cos(arcLatB) * Math.Pow(Math.Sin(lntDiffer / 2), 2))) * _earth_radius;
            return Math.Round(distance, 2);
        }
    }
}
