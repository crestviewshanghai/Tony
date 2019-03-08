using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace MojoCube.Api.XML
{
    /// <summary>
    /// 生成网站地图XML文件
    /// loc 网址
    /// lastmod 最后更新时间
    /// changefreq  更新频繁程度
    /// priority    优先级,0-1
    /// </summary>
    public class SiteMap
    {
        #region  创建网站地图
        public string CreateSiteMap(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"http://www.google.com/schemas/sitemap/0.84\">");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendLine("<url>");
                    sb.AppendLine("<loc>" + dt.Rows[i]["loc"].ToString() + "</loc>");
                    if (dt.Columns.Contains("lastmod"))
                    {
                        sb.AppendLine("<lastmod>" + DateTime.Parse(dt.Rows[i]["lastmod"].ToString()).ToString("yyyy-MM-dd") + "</lastmod>");
                    }
                    if (dt.Columns.Contains("changefreq"))
                    {
                        sb.AppendLine("<changefreq>" + dt.Rows[i]["changefreq"].ToString() + "</changefreq>");
                    }
                    if (dt.Columns.Contains("priority"))
                    {
                        sb.AppendLine("<priority>" + dt.Rows[i]["priority"].ToString() + "</priority>");
                    }
                    sb.AppendLine("</url>");
                }
            }

            sb.AppendLine("</urlset>");

            return sb.ToString();
        }
        #endregion

        #region  读取网站地图
        public DataTable ReadSiteMap(string url)
        {
            try
            {
                DataTable Dt = new DataTable();
                DataColumn loc = new DataColumn("loc", typeof(string));
                DataColumn lastmod = new DataColumn("lastmod", typeof(string));
                DataColumn changefreq = new DataColumn("changefreq", typeof(string));
                DataColumn priority = new DataColumn("priority", typeof(string));
                Dt.Columns.Add(loc);
                Dt.Columns.Add(lastmod);
                Dt.Columns.Add(changefreq);
                Dt.Columns.Add(priority);

                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream smStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument smDoc = new System.Xml.XmlDocument();
                smDoc.Load(smStream);

                XmlElement rootElem = smDoc.DocumentElement;   //获取根节点  
                System.Xml.XmlNodeList smItems = rootElem.GetElementsByTagName("url");

                foreach (XmlNode node in smItems)
                {
                    DataRow Row = Dt.NewRow();

                    XmlNodeList smNode;

                    //网址
                    smNode = ((XmlElement)node).GetElementsByTagName("loc");
                    if (smNode.Count == 1)
                    {
                        Row["loc"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["loc"] = "";
                    }

                    //最后更新时间
                    smNode = ((XmlElement)node).GetElementsByTagName("lastmod");
                    if (smNode.Count == 1)
                    {
                        Row["lastmod"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["lastmod"] = "";
                    }

                    //更新频繁程度
                    smNode = ((XmlElement)node).GetElementsByTagName("changefreq");
                    if (smNode.Count == 1)
                    {
                        Row["changefreq"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["changefreq"] = "";
                    }

                    //优先级
                    smNode = ((XmlElement)node).GetElementsByTagName("priority");
                    if (smNode.Count == 1)
                    {
                        Row["priority"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["priority"] = "";
                    }

                    Dt.Rows.Add(Row);
                }

                return Dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
