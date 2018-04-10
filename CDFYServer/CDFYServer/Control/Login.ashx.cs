using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CDFYServer.Control
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Stream stream = context.Request.InputStream;
            if (stream.Length > 0)
            {
                StreamReader sr = new StreamReader(stream);
                string strJson = sr.ReadToEnd();
                Dictionary<string, string> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(strJson);
                var p = dic["FunctionName"];
                context.Response.Write(SwitchFunction(p, context)); 
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string SwitchFunction(string sw, HttpContext context)
        {
            switch (sw)
            {
                case "DoLogin":
                    return DoLogin(context);

                default:
                    return "false";
            }
        
        }

        private string DoLogin(HttpContext context)
        {
            //解析参数
            string str = context.Request.Form["1"];
            return null;
        }
        
    }
}