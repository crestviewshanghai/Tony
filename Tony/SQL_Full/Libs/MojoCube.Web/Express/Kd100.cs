using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MojoCube.Web.Express
{
    public class Kd100
    {
        //电商ID
        public string AppID;
        //电商加密私钥，注意保管，不要泄漏
        public string KeyCode;
        //请求url
        public string Gateway;
        //快递公司代码
        public string ShipperCode;
        //快递单号
        public string LogisticCode;

        /// <summary>
        /// Json方式 查询订单物流轨迹
        /// </summary>
        /// <returns></returns>
        public string getOrderTracesByJson()
        {
            #region  快递公司代码转换

            if (ShipperCode == "HHTT")
            {
                ShipperCode = "tiantian";
            }
            if (ShipperCode == "DBL")
            {
                ShipperCode = "debangwuliu";
            }
            if (ShipperCode == "DHL")
            {
                ShipperCode = "dhl";
            }
            if (ShipperCode == "FEDEX")
            {
                ShipperCode = "fedex";
            }
            if (ShipperCode == "JXD")
            {
                ShipperCode = "jixianda";
            }
            if (ShipperCode == "FAST")
            {
                ShipperCode = "kuaijiesudi";
            }
            if (ShipperCode == "LB")
            {
                ShipperCode = "longbanwuliu";
            }
            if (ShipperCode == "QRT")
            {
                ShipperCode = "quanritongkuaidi";
            }
            if (ShipperCode == "UAPEX")
            {
                ShipperCode = "quanyikuaidi";
            }
            if (ShipperCode == "SURE")
            {
                ShipperCode = "suer";
            }
            if (ShipperCode == "HOAU")
            {
                ShipperCode = "tiandihuayu";
            }
            if (ShipperCode == "XFEX")
            {
                ShipperCode = "xinfengwuliu";
            }
            if (ShipperCode == "YFSD")
            {
                ShipperCode = "yafengsudi";
            }
            if (ShipperCode == "UC")
            {
                ShipperCode = "youshuwuliu";
            }
            if (ShipperCode == "YTO")
            {
                ShipperCode = "yuantong";
            }
            if (ShipperCode == "YD")
            {
                ShipperCode = "yunda";
            }
            if (ShipperCode == "YTKD")
            {
                ShipperCode = "yuntongkuaidi";
            }
            if (ShipperCode == "ZJS")
            {
                ShipperCode = "zhaijisong";
            }
            if (ShipperCode == "ZTO")
            {
                ShipperCode = "zhongtong";
            }

            #endregion

            string apiurl = Gateway.Replace("[KeyCode]", KeyCode).Replace("[ShipperCode]", ShipperCode).Replace("[LogisticCode]", LogisticCode);

            WebRequest request = WebRequest.Create(@apiurl);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Encoding encode = Encoding.UTF8;
            StreamReader reader = new StreamReader(stream, encode);
            string result = reader.ReadToEnd();

            return result;
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetContent(string content)
        {
            JObject jos = (JObject)JsonConvert.DeserializeObject(content);
            content = "";
            try
            {
                string str = jos["data"].ToString();
                JArray ja = (JArray)JsonConvert.DeserializeObject(str);
                foreach (JObject o in ja)
                {
                    content += "<div class='express'>" + o["context"] + "<span>【" + o["time"] + "】</span></div>";
                }
            }
            catch { }
            return content;
        }

        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static DataTable GetDT(string content)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Content");
            dt.Columns.Add("Time");

            JObject jos = (JObject)JsonConvert.DeserializeObject(content);
            content = "";
            try
            {
                string str = jos["data"].ToString();
                JArray ja = (JArray)JsonConvert.DeserializeObject(str);
                foreach (JObject o in ja)
                {
                    DataRow dr = dt.NewRow();
                    dr["Content"] = o["context"];
                    dr["Time"] = o["time"];
                    dt.Rows.Add(dr);
                }
            }
            catch { }
            return dt;
        }
    }
}
