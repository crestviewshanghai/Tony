using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MojoCube.Web.SMS
{
    public class GetInfo
    {
        //JSON:{"reason":"操作成功","result":{"sid":"1000722233951153100","fee":1,"count":1},"error_code":0}

        public string reason = "";
        public string sid = "";  //短信ID
        public int fee = 0; //扣除条数
        public int count = 0;   //发送数量
        public int error_code = 0;
        //错误代码：0 表示成功
        //205401	错误的手机号码
        //205402	错误的短信模板ID
        //205403	网络错误,请重试
        //205404	发送失败，具体原因请参考返回reason
        //205405	号码异常/同一号码发送次数过于频繁
        //205406	不被支持的模板

        public void GetContent(string content)
        {
            JObject jos = (JObject)JsonConvert.DeserializeObject(content);
            try
            {
                reason = jos["reason"].ToString();
                error_code = int.Parse(jos["error_code"].ToString());
                string str = "[" + jos["result"].ToString() + "]";
                JArray ja = (JArray)JsonConvert.DeserializeObject(str);
                foreach (JObject o in ja)
                {
                    sid = (string)o["sid"];
                    fee = (int)o["fee"];
                    count = (int)o["count"];
                }
            }
            catch { }
        }
    }
}
