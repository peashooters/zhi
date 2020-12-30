using Newtonsoft.Json;

namespace ZHI.ZSystem
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class ZObject : object
    {
        /// <summary>
        /// 将当前实例转为JSON字符串
        /// </summary>
        /// <returns></returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
