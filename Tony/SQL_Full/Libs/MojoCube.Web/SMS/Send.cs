using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MojoCube.Web.SMS
{
    public class Send
    {
        /// <summary>
        /// 发送接口
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="mobile">接收手机号</param>
        /// <param name="key">密钥</param>
        /// <param name="formUrl">接口地址</param>
        /// <param name="tplId">模板ID</param>
        /// <returns>JSON:{"reason":"操作成功","result":{"sid":"1000722233951153100","fee":1,"count":1},"error_code":0}</returns>
        public static string SendMsg(string user, string mobile, string key, string formUrl, string tplId)
        {
            try
            {
                string value = "#user#=" + user;
                value = HttpUtility.UrlEncode(value, System.Text.Encoding.UTF8);

                string formData = "mobile=" + mobile + "&tpl_id=" + tplId + "&tpl_value=" + value + "&key=" + key;

                //注意提交的编码 这边是需要改变的 这边默认的是Default：系统当前编码
                byte[] postData = System.Text.Encoding.UTF8.GetBytes(formData);

                // 设置提交的相关参数 
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(formUrl) as System.Net.HttpWebRequest;
                System.Text.Encoding myEncoding = System.Text.Encoding.UTF8;
                request.Method = "POST";
                request.KeepAlive = false;
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR  3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.ContentLength = postData.Length;

                // 提交请求数据 
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                System.Net.HttpWebResponse response;
                System.IO.Stream responseStream;
                System.IO.StreamReader reader;
                string srcString;
                response = request.GetResponse() as System.Net.HttpWebResponse;
                responseStream = response.GetResponseStream();
                reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding("UTF-8"));
                srcString = reader.ReadToEnd();
                string result = srcString;   //返回值赋值
                reader.Close();

                return result;
            }
            catch
            {
                return "error";
            }
        }
    }
}
