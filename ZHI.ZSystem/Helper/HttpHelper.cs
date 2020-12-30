using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem
{
    /// <summary>
    /// Http帮助类（Http Helper）
    /// </summary>
    public static class HttpHelper
    {
        #region ====属性（property）
        /// <summary>
        /// 默认超时时间（Default Timeout）
        /// </summary>
        private const int _defaultTimeOut = 30;//秒
        #endregion

        #region ====异步（Async）

        #region HttpPostAsync
        public static async Task<string> HttpPostAsync(string url, string body)
        {
            return await HttpPostAsync(url, body, null, null, _defaultTimeOut);
        }
        public static async Task<string> HttpPostAsync(string url, string body, string contentType)
        {
            return await HttpPostAsync(url, body, contentType, null, _defaultTimeOut);
        }
        public static async Task<string> HttpPostAsync(string url, string body, string contentType, Dictionary<string, string> headers)
        {
            return await HttpPostAsync(url, body, contentType, headers, _defaultTimeOut);
        }
        public static async Task<string> HttpPostAsync(string url, string body, string contentType, Dictionary<string, string> headers, int timeOut)
        {
            body = body ?? "";
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (var httpContent = new StringContent(body, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    var response = await httpClient.PostAsync(url, httpContent);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        #endregion

        #region HttpGetAsync
        public static async Task<string> HttpGetAsync(string url)
        {
            return await HttpGetAsync(url,null,_defaultTimeOut);
        }
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers)
        {
            return await HttpGetAsync(url, headers, _defaultTimeOut);
        }
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers, int timeOut)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                var response = await httpClient.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion

        #endregion

        #region ====同步（Sync）

        #region HttpPost
        public static string HttpPost(string url, string body )
        {
            return HttpPost(url, body, null, null, _defaultTimeOut);
        }
        public static string HttpPost(string url, string body, string contentType)
        {
            return HttpPost(url, body, contentType, null, _defaultTimeOut);
        }
        public static string HttpPost(string url, string body, string contentType, Dictionary<string, string> headers)
        {
            return HttpPost(url, body, contentType, headers, _defaultTimeOut);
        }
        public static string HttpPost(string url, string body , string contentType, Dictionary<string, string> headers, int timeOut)
        {
            body = body ?? "";

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (var httpContent = new StringContent(body, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    var response = httpClient.PostAsync(url, httpContent).Result;

                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        #endregion

        #region HttpGet
        public static string HttpGet(string url)
        {
            return HttpGet(url, null, _defaultTimeOut);
        }
        public static string HttpGet(string url, Dictionary<string, string> headers)
        {
            return HttpGet(url, headers, _defaultTimeOut);
        }
        public static string HttpGet(string url, Dictionary<string, string> headers, int timeOut)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                var response = httpClient.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        #endregion

        #endregion
    }
}
