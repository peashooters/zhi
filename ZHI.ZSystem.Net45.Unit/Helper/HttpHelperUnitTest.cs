using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace ZHI.ZSystem.Net45.Unit.Helper
{
    [TestClass]
    public class HttpHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            //未能创建 SSL/TLS 安全通道解决办法：
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)0x300 | (SecurityProtocolType)0xC00;
            //
            Console.WriteLine("HttpHelperUnitTest（Http请求帮助类单元测试）");
            Console.WriteLine();
            string html = string.Empty;
            int timeOut = 20;
            string body = "Name=Lilei";
            //请求头/内容类型
            string contentType = "application/x-www-form-urlencoded";
            //发起POST请求
            string url = "https://fanyi.baidu.com/langdetect";
            //string gurl = "https://www.baidu.com/";
            Dictionary<string, string> header = new Dictionary<string, string>();
            //请求头
            header.Add("method", "get");
            header.Add("path", "/langdetect");
            header.Add("scheme", "https");
            header.Add("accept-language", "zh-cn,zh;q=0.9");
             

            #region 同步
            #region GET
            //html = HttpHelper.HttpGet(gurl);
            //Console.WriteLine("HttpGet:{0}", html);
            //html = HttpHelper.HttpGet(gurl, header);
            //Console.WriteLine("HttpGet(自定义请求头):{0}", html);
            //html = HttpHelper.HttpGet(gurl, header, 20);
            //Console.WriteLine("HttpGet(自定义请求头和请求超时时间，单位秒s):{0}", html);
            #endregion
            #region POST
            //html = HttpHelper.HttpPost(url, body);
            //Console.WriteLine("HttpPost:{0}", html);
            html = HttpHelper.HttpPost(url, body, null,header);
            Console.WriteLine("HttpPost(自定义请求头和请求体):{0}", html);
            //html = HttpHelper.HttpPost(url,  body,  contentType, header, timeOut);
            //Console.WriteLine("HttpPost(自定义请求头和请求体、超时时间):{0}", html);
            #endregion
            #endregion


            #region 异步操作
            #region GET
            //Task<string> htmlAnysc = HttpHelper.HttpGetAsync(gurl);
            //Console.WriteLine("HttpGetAsync:{0}", htmlAnysc);
            //htmlAnysc = HttpHelper.HttpGetAsync(gurl, header);
            //Console.WriteLine("HttpGetAsync(自定义请求头):{0}", htmlAnysc);
            //htmlAnysc =HttpHelper.HttpGetAsync(gurl, header,timeOut);
            //Console.WriteLine("HttpGetAsync(自定义请求头和超时时间):{0}", htmlAnysc);
            #endregion
            #region POST
            //string AnsyBody = string.Empty;
            //Task<string> PostAnysc = HttpHelper.HttpPostAsync(url, AnsyBody);
            //Console.WriteLine("HttpGetAsync:{0}", PostAnysc);
            //PostAnysc = HttpHelper.HttpPostAsync(url, AnsyBody, contentType);
            //Console.WriteLine("HttpGetAsync(自定义请求体和请求类型):{0}", PostAnysc);
            //PostAnysc = HttpHelper.HttpPostAsync(url, AnsyBody, contentType, header);
            //Console.WriteLine("HttpGetAsync(自定义请求体、请求类型和请求头):{0}", PostAnysc);
            //PostAnysc = HttpHelper.HttpPostAsync(url, AnsyBody,  contentType, header, timeOut);
            //Console.WriteLine("HttpGetAsync(自定义请求体、请求头、请求类型和超时时间):{0}", PostAnysc);

            #endregion
            #endregion
        }
    }
}
