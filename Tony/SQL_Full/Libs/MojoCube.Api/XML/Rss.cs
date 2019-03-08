using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;

namespace MojoCube.Api.XML
{
    public class Rss
    {
        public string RssVersion, RssTitle, RssLink, RssDescription, RssFileName;

        public string ItemTitle, ItemLink, ItemDescription, ItemDate, ItemID;

        #region  构建RSS
        public void CreateRss(DataSet ds)
        {
            XmlDocument domDoc = new XmlDocument();

            //XmlDeclaration nodeDeclar = domDoc.CreateXmlDeclaration("1.0 ", System.Text.Encoding.UTF8.BodyName, "yes ");
            XmlDeclaration nodeDeclar = domDoc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);

            domDoc.AppendChild(nodeDeclar);

            //如果rss有样式表文件的话，加上这两句

            //XmlProcessingInstruction nodeStylesheet = domDoc.CreateProcessingInstruction("xml-stylesheet", @"type='text/css'   href='rss.css' ");

            //domDoc.AppendChild(nodeStylesheet);

            XmlElement root = domDoc.CreateElement("rss");

            root.SetAttribute("version", RssVersion);     //添加属性结点

            domDoc.AppendChild(root);

            XmlElement chnode = domDoc.CreateElement("channel");

            root.AppendChild(chnode);

            XmlElement element = domDoc.CreateElement("title");

            XmlNode textNode = domDoc.CreateTextNode(RssTitle);         //文本结点

            element.AppendChild(textNode);

            chnode.AppendChild(element);

            element = domDoc.CreateElement("link");

            textNode = domDoc.CreateTextNode(RssLink);

            element.AppendChild(textNode);

            chnode.AppendChild(element);

            element = domDoc.CreateElement("description");   //引用结点

            XmlNode cDataNode = domDoc.CreateTextNode(RssDescription);

            element.AppendChild(cDataNode);

            chnode.AppendChild(element);

            DataTable dt = ds.Tables[0];           //访问数据库，获取要在rss中显示的记录 

            foreach (DataRow dr in dt.Rows)
            {
                //element = domDoc.CreateElement("item");

                ////...

                ////创建内容结点，常见的如title,description,link,pubDate,创建方法同上

                ////...

                XmlElement item = domDoc.CreateElement("item");

                chnode.AppendChild(item);

                ////chnode.AppendChild(element);

                XmlElement element1 = domDoc.CreateElement("title");

                XmlNode textNode1 = domDoc.CreateTextNode(dr[ItemTitle].ToString());         //文本结点

                element1.AppendChild(textNode1);

                item.AppendChild(element1);

                element1 = domDoc.CreateElement("link");

                textNode1 = domDoc.CreateTextNode(ItemLink.Replace("[ItemID]", dr[ItemID].ToString()));

                element1.AppendChild(textNode1);

                item.AppendChild(element1);

                element1 = domDoc.CreateElement("description");   //引用结点

                textNode1 = domDoc.CreateTextNode(dr[ItemDescription].ToString());

                element1.AppendChild(textNode1);

                item.AppendChild(element1);

                element1 = domDoc.CreateElement("pubDate");   //日期

                textNode1 = domDoc.CreateTextNode(DateTime.Parse(dr[ItemDate].ToString()).ToString("yyyy-MM-dd"));

                element1.AppendChild(textNode1);

                item.AppendChild(element1);

            }

            //输出

            //XmlTextWriter objTextWrite = new XmlTextWriter(this.Response.OutputStream, System.Text.Encoding.UTF8);
            //string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            domDoc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Feeds/" + RssFileName));

            //objTextWrite.Flush();
            //objTextWrite.Close(); 
        }
        #endregion

        #region  读取RSS
        public DataTable ReadRss(string RssURL)
        {
            try
            {
                DataTable Dt = new DataTable();
                DataColumn ID = new DataColumn("ID", typeof(string));
                DataColumn Title = new DataColumn("Title", typeof(string));
                DataColumn Author = new DataColumn("Author", typeof(string));
                DataColumn PubDate = new DataColumn("PubDate", typeof(string));
                DataColumn Link = new DataColumn("Link", typeof(string));
                DataColumn Desc = new DataColumn("Description", typeof(string));
                Dt.Columns.Add(ID);
                Dt.Columns.Add(Title);
                Dt.Columns.Add(Author);
                Dt.Columns.Add(PubDate);
                Dt.Columns.Add(Link);
                Dt.Columns.Add(Desc);

                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(RssURL);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream rssStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
                rssDoc.Load(rssStream);

                System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
                for (int i = 0; i < rssItems.Count; i++)
                {
                    DataRow Row = Dt.NewRow();
                    System.Xml.XmlNode rssDetail;
                    //
                    Row["ID"] = (i + 1).ToString();
                    //标题
                    rssDetail = rssItems.Item(i).SelectSingleNode("title");
                    if (rssDetail != null)
                    {
                        Row["Title"] = rssDetail.InnerText;
                    }
                    else
                    {
                        Row["Title"] = "";
                    }
                    //作者
                    rssDetail = rssItems.Item(i).SelectSingleNode("author");
                    if (rssDetail != null)
                    {
                        Row["Author"] = rssDetail.InnerText;
                    }
                    else
                    {
                        Row["Author"] = "";
                    }
                    //发布时间
                    rssDetail = rssItems.Item(i).SelectSingleNode("pubDate");
                    if (rssDetail != null)
                    {
                        Row["PubDate"] = Convert.ToDateTime(rssDetail.InnerText).ToString("yyyy年MM月dd日");
                    }
                    else
                    {
                        Row["PubDate"] = "";
                    }
                    //链接地址
                    rssDetail = rssItems.Item(i).SelectSingleNode("link");
                    if (rssDetail != null)
                    {
                        Row["Link"] = rssDetail.InnerText;
                    }
                    else
                    {
                        Row["Link"] = "";
                    }
                    //内容描述
                    rssDetail = rssItems.Item(i).SelectSingleNode("description");
                    if (rssDetail != null)
                    {
                        Row["Description"] = rssDetail.InnerText;
                    }
                    else
                    {
                        Row["Description"] = "";
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
