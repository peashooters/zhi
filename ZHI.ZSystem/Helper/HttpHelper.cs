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
        /// <summary>
        /// 异步发起HTTP POST请求（Launch HTTP POST request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string body)
        {
            return await HttpPostAsync(url, body, null, null, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP POST请求（Launch HTTP POST request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string body, string contentType)
        {
            return await HttpPostAsync(url, body, contentType, null, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP POST请求（Launch HTTP POST request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string body, string contentType, Dictionary<string, string> headers)
        {
            return await HttpPostAsync(url, body, contentType, headers, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP POST请求（Launch HTTP POST request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <param name="headers">请求头</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
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
        /// <summary>
        /// 异步发起HTTP GET请求（Launch HTTP GET request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url)
        {
            return await HttpGetAsync(url,null,_defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP GET请求（Launch HTTP GET request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers)
        {
            return await HttpGetAsync(url, headers, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP GET请求（Launch HTTP GET request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求头</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
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
        /// <summary>
        /// 同步发起HTTP POST请求（Launch HTTP POST request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body )
        {
            return HttpPost(url, body, null, null, _defaultTimeOut);
        }
        /// <summary>
        /// 同步发起HTTP POST请求（Launch HTTP POST request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body, string contentType)
        {
            return HttpPost(url, body, contentType, null, _defaultTimeOut);
        }
        /// <summary>
        /// 同步发起HTTP POST请求（Launch HTTP POST request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body, string contentType, Dictionary<string, string> headers)
        {
            return HttpPost(url, body, contentType, headers, _defaultTimeOut);
        }
        /// <summary>
        /// 同步发起HTTP POST请求（Launch HTTP POST request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <param name="contentType">内容类型（请求头：Content-Type）</param>
        /// <param name="headers">请求头</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
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
        /// <summary>
        /// 同步发起HTTP GET请求（Launch HTTP GET request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            return HttpGet(url, null, _defaultTimeOut);
        }
        /// <summary>
        /// 同步发起HTTP GET请求（Launch HTTP GET request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求内容</param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> headers)
        {
            return HttpGet(url, headers, _defaultTimeOut);
        }
        /// <summary>
        /// 同步发起HTTP GET请求（Launch HTTP GET request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求内容</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
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
