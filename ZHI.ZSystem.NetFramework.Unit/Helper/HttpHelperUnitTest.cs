using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHI.ZSystem.NetFramework.Unit.Helper
{
    [TestClass]
    public class HttpHelperUnitTest
    {
        [TestMethod]
        public void Test()
        {
            //var html = HttpHelper.HttpGet("https://www.baidu.com/");
            //Console.WriteLine(string.Format("HttpGet:{0}", html));
            string body = string.Empty;
            //var resp = HttpHelper.HttpPost("https://www.baidu.com/", body);
            //Console.WriteLine(string.Format("HttpPost:{0}", resp));

            //Task<string> htmlAnysc = HttpHelper.HttpGetAsync("https://www.baidu.com/");
            //Console.WriteLine(string.Format("HttpGetAsync:{0}", htmlAnysc));

            Task<string> PostAnysc = HttpHelper.HttpPostAsync("https://www.baidu.com/", body);
            Console.WriteLine(string.Format("HttpGetAsync:{0}", PostAnysc));
        }
    }
}
