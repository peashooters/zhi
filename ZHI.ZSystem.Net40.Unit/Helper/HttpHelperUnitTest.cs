using System;
using System.Collections.Generic;
using System.Net;

namespace ZHI.ZSystem.Net40.Unit
{
    public class HttpHelperUnitTest : BaseUnitTest
    {
        public override void Test()
        {   
            //
            Console.WriteLine("HttpHelperUnitTest（Http请求帮助类单元测试）");
            Console.WriteLine();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)0x300 | (SecurityProtocolType)0xC00;
            //测试数据
            var url = string.Empty;//地址
            var response = string.Empty;//响应结果
            var headers = new Dictionary<string, string>();//请求头
            var timeout = 10;
            //请求头
            headers.Add("method", "GET");
            headers.Add("path", "/langdetect");
            headers.Add("scheme", "https");
            headers.Add("accept-language", "zh-CN,zh;q=0.9");
            //发起POST请求
            url = "https://fanyi.baidu.com/langdetect";
            var body = "query=1";

            response = HttpHelper.HttpPost(url, null, null, null, 10);
            response = HttpHelper.HttpPost(url, body, null, null, 10);
            response = HttpHelper.HttpPost(url, body, "application/x-www-form-urlencoded; charset=UTF-8", null, timeout);
            response = HttpHelper.HttpPost(url, body, "application/x-www-form-urlencoded; charset=UTF-8", headers, timeout);
            //异步请求
            response = HttpHelper.HttpPostAsync(url, null, null, null, 10).Result;
            response = HttpHelper.HttpPostAsync(url, body, null, null, 10).Result;
            response = HttpHelper.HttpPostAsync(url, body, "application/x-www-form-urlencoded; charset=UTF-8", null, timeout).Result;
            response = HttpHelper.HttpPostAsync(url, body, "application/x-www-form-urlencoded; charset=UTF-8", headers, timeout).Result;
            Console.WriteLine("POST请求测试", response);
            Console.WriteLine("地址：{0}", url);
            Console.WriteLine("结果：{0}", response);
            Console.WriteLine();
            //发送GET请求
            url = "https://fanyi.baidu.com/langdetect?query=1";
            response = HttpHelper.HttpGet(url, null, timeout);
            response = HttpHelper.HttpGet(url, headers, timeout);
            //异步请求
            response = HttpHelper.HttpGetAsync(url, null, timeout).Result;
            response = HttpHelper.HttpGetAsync(url, headers, timeout).Result;

            Console.WriteLine("GET请求测试", response);
            Console.WriteLine("地址：{0}", url);
            Console.WriteLine("结果：{0}", response);

           
        }
    }
}
