using System;
using System.Collections.Generic;
using System.Text;
#if NET40
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
#else
using System.Net.Http;
using System.Threading.Tasks;
#endif

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

#if NET40 

        #region .NET Framework 4.0 编译时函数（function for .NET Framework 4.0）
        /// <summary>
        /// 证书验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="x509Certificate">提供使用 X.509 v.3 证书的方法</param>
        /// <param name="x509Chain">表示 X509Certificate2 证书的链生成引擎</param>
        /// <param name="sslPolicyErrors">枚举安全套接字层 (SSL) 策略错误</param>
        /// <returns></returns>
        private static bool CertificateValidation(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
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
            var encoding = Encoding.UTF8;
            //Http Request
            var httpWebRequest = (HttpWebRequest)null;
            //HTTPS
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificateValidation);
                httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            }
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = timeOut * 1000;

            //Http Header
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    //User-Agent
                    if (header.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.UserAgent = header.Value;
                        continue;
                    }
                    //Content-Type
                    if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("ContentType", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.ContentType = header.Value;
                        continue;
                    }
                    //Other
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (!contentType.IsNullOrWhiteSpace())
                httpWebRequest.ContentType = contentType;

            //Http Content
            if (body.IsNullOrWhiteSpace())
            {
                httpWebRequest.ContentLength = 0;
            }
            else
            {
                using (var requestStream = httpWebRequest.GetRequestStream())
                using (var streamWriter = new StreamWriter(requestStream, encoding))
                    streamWriter.Write(body);
            }
            //Http Response
            var responseString = (string)null;
            var httpWebResponse =(await httpWebRequest.GetResponseAsync()) as HttpWebResponse;
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream, encoding))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }
            return responseString;
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
            return await HttpGetAsync(url, null, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP GET请求（Launch HTTP GET request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求内容</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers)
        {
            return await HttpGetAsync(url, headers, _defaultTimeOut);
        }
        /// <summary>
        /// 异步发起HTTP GET请求（Launch HTTP GET request async）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">请求内容</param>
        /// <param name="timeOut">超时时间（秒）</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers, int timeOut)
        {
            var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = timeOut * 1000;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    //User-Agent
                    if (header.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.UserAgent = header.Value;
                        continue;
                    }
                    //Headers
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }
            
            var responseString = (string)null;
            var httpWebResponse = (await httpWebRequest.GetResponseAsync()) as HttpWebResponse;
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }
            return responseString;
        }

        #endregion

        #endregion

        #region ====同步（Sync）

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
            var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = timeOut * 1000;
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    //User-Agent
                    if (header.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.UserAgent = header.Value;
                        continue;
                    }
                    //Headers
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }
            var responseString = (string)null;
            var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }
            return responseString;
        }
        #endregion

        #region HttpPost
        /// <summary>
        /// 同步发起HTTP POST请求（Launch HTTP POST request sync）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="body">请求内容</param>
        /// <returns></returns>
        public static string HttpPost(string url, string body)
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
        public static string HttpPost(string url, string body, string contentType, Dictionary<string, string> headers, int timeOut)
        {
            var encoding = Encoding.UTF8;
            //Http Request
            var httpWebRequest = (HttpWebRequest)null;
            //HTTPS
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificateValidation);
                httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            }
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = timeOut * 1000;

            //Http Header
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    //User-Agent
                    if (header.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.UserAgent = header.Value;
                        continue;
                    }
                    //Content-Type
                    if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase) || header.Key.Equals("ContentType", StringComparison.OrdinalIgnoreCase))
                    {
                        httpWebRequest.ContentType = header.Value;
                        continue;
                    }
                    //Other
                    httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (!contentType.IsNullOrWhiteSpace())
                httpWebRequest.ContentType = contentType;

            //Http Content
            if (body.IsNullOrWhiteSpace())
            {
                httpWebRequest.ContentLength = 0;
            }
            else
            {
                using (var requestStream = httpWebRequest.GetRequestStream())
                using (var streamWriter = new StreamWriter(requestStream, encoding))
                    streamWriter.Write(body);
            }
            //Http Response
            var responseString = (string)null;
            var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            using (var responseStream = httpWebResponse.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream, encoding))
                {
                    responseString = streamReader.ReadToEnd();
                }
            }
            return responseString;
        }
        #endregion

        #endregion
#else
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
#endif
    }
}
