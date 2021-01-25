namespace ZHI.ZSystem
{
    /// <summary>
    /// 经纬坐标范围
    /// </summary>
    public class PositionRange
    {
        #region ====私有属性（private property）
        /// <summary>
        /// 最小经度
        /// </summary>
        private double _minlongitude;
        /// <summary>
        /// 最小纬度
        /// </summary>
        private double _minlatitude;
        /// <summary>
        /// 最大经度
        /// </summary>
        private double _maxlongitude;
        /// <summary>
        /// 最大纬度
        /// </summary>
        private double _maxlatitude;
        #endregion

        /// <summary>
        /// 设置经纬范围值
        /// </summary>
        /// <param name="minLongitude">最小经度</param>
        /// <param name="minLatitude">最小纬度</param>
        /// <param name="maxLongitude">最大经度</param>
        /// <param name="maxLatitude">最大纬度</param>
        internal void SetPositionRange(double minLongitude,double minLatitude, double maxLongitude, double maxLatitude)
        {
            this._minlongitude = minLongitude;
            this._minlatitude = minLatitude;
            this._maxlongitude = maxLongitude;
            this._maxlatitude = maxLatitude;
        }

        /// <summary>
        /// 最小经度
        /// </summary>
        public double MinLongitude
        {
            get
            {
                return this._minlongitude;
            }
        }
        /// <summary>
        /// 最小纬度
        /// </summary>
        public double MinLatitude
        {
            get
            {
                return this._minlatitude;
            }
        }
        /// <summary>
        /// 最大经度
        /// </summary>
        public double MaxLongitude
        {
            get
            {
                return this._maxlongitude;
            }
        }
        /// <summary>
        /// 最大纬度
        /// </summary>
        public double MaxLatitude
        {
            get
            {
                return this._maxlatitude;
            }
        }
    }
}
