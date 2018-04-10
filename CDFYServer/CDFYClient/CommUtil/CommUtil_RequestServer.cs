using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CDFYClient.CommUtil
{
    class CommUtil_RequestServer
    {
        /// <summary>
        /// 发送请求，并获取响应
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ob"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static HttpWebResponse PostHttpRequest(string url, object obj, int timeout, IDictionary<string, string> parameters)
        {
            HttpWebRequest request = null;

            request = WebRequest.Create(url) as HttpWebRequest;

            if(request == null) return null;

            request.Method = "POST";

            request.ContentType = "application/json";//"application/x-www-form-urlencoded";

            request.Timeout = timeout;

            //发送POST请求
            if (parameters != null && parameters.Count != 0)
            {
                //测试：字典集合拼接传递到后台的数据
                //string[] strArray = new string[parameters.Count];
                //int index = 0;
                //foreach (string key in parameters.Keys)
                //{
                //    strArray[index] = string.Format("{0}={1}", key, parameters[key]);
                //    index++;
                //}
                //string sbBuffer = string.Join("&", strArray);

                //使用Newtonsoft.Json 自动的将对象序列化
                string json = JsonConvert.SerializeObject(obj);
                byte[] dataByte = Encoding.ASCII.GetBytes(json);
                using(Stream st = request.GetRequestStream())
                {
                    st.Write(dataByte,0,dataByte.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }

        public static string GetResponseString(HttpWebResponse webResponse)
        { 
            using(Stream st = webResponse.GetResponseStream())
            {
                StreamReader stReader = new StreamReader(st, Encoding.UTF8);
                return stReader.ReadToEnd();
            }
        }
    }
}
