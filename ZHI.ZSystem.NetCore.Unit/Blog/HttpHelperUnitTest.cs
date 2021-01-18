using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ZHI.ZSystem.NetCore.Unit.Blog
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
            ////HTTP GET 请求
            //var taobao = "https://suggest.taobao.com/sug";
            //var timestamp = DateTime.Now.ToUtcTimeStamp(TimeStampUnit.Millisecond);//ZHI.ZSystem内置扩展函数
            //var httpResponse = string.Empty;
            ////参数q:表示查询关键词
            ////参数_:当前时间戳
            //var parameters = "code=utf-8&q=笔&extras=1area=c2c&bucketid=atb_searchpid=mm_26632258_3504122_32538762&unid=&clk1=3316c22850177cb5649f1a983455721b&callback=jsonp4&_=" + timestamp.ToString();
            //var url = string.Format("{0}?{1}", taobao, parameters);
            //httpResponse = HttpHelper.HttpGet(url);
            //Console.WriteLine("请求结果（仅地址）：{0}", httpResponse);
            //Console.WriteLine();
            //Console.WriteLine();
            //var header = new Dictionary<string, string>();
            //header.Add("referer", "https://uland.taobao.com/");
            //header.Add("authority", "suggest.taobao.com");
            //httpResponse = HttpHelper.HttpGet(url, header);
            //Console.WriteLine("请求结果（地址、请求头）：{0}", httpResponse);


            //HTTP POST 请求
            var baidu = "https://fanyi.baidu.com/langdetect";
            var parameters = "query=a";
            var httpResponse = string.Empty;
            var url = baidu;
            //发起请求
            httpResponse = HttpHelper.HttpPost(url, parameters);
            Console.WriteLine("请求结果（地址、参数）：{0}", httpResponse);
            Console.WriteLine();
            Console.WriteLine();
            var header = new Dictionary<string, string>();
            header.Add("origin", "https://fanyi.baidu.com");
            header.Add("referer", "https://fanyi.baidu.com/");
            header.Add("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            //发起请求 （携带请求头）
            httpResponse = HttpHelper.HttpPost(url, parameters, null, header);
            Console.WriteLine("请求结果（地址、参数、请求头）：{0}", httpResponse);
        }
    }
}
