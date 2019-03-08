using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data;
using System.Xml;

namespace MojoCube.Api.UI
{
    public class Language
    {
        /// <summary>
        /// 初始化语言
        /// </summary>
        public static void InitLanguage()
        {
            HttpCookie LanguageCookie = HttpContext.Current.Request.Cookies["MojoCube_Language"];
            string UILanguage = "";

            //cookie为空，获取用户浏览器设置
            if (LanguageCookie == null)
            {
                Language language = new Language();
                DataTable dt = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));

                if (dt.Rows.Count > 0)
                {
                    UILanguage = dt.Rows[0]["name"].ToString();
                    language.ChangeLanguage(UILanguage);
                }
            }
            else
            {
                UILanguage = LanguageCookie.Value;
            }

            System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo(UILanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = CI;
        }

        /// <summary>
        /// 获取当前语言
        /// </summary>
        /// <returns></returns>
        public static string GetLanguage()
        {
            HttpCookie LanguageCookie = HttpContext.Current.Request.Cookies["MojoCube_Language"];
            string UILanguage = "";

            //cookie为空，获取用户浏览器设置
            if (LanguageCookie == null)
            {
                Language language = new Language();
                DataTable dt = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));

                if (dt.Rows.Count > 0)
                {
                    UILanguage = dt.Rows[0]["name"].ToString();
                    language.ChangeLanguage(UILanguage);
                }
            }
            else
            {
                UILanguage = LanguageCookie.Value;
            }

            return UILanguage;
        }

        /// <summary>
        /// 切换语言
        /// </summary>
        /// <param name="language">如："zh-cn", "zh-tw", "en"</param>
        public void ChangeLanguage(string language)
        {
            HttpContext.Current.Response.Cookies["MojoCube_Language"].Value = language;
            HttpContext.Current.Response.Cookies["MojoCube_Language"].Expires = DateTime.Now.AddYears(1);
            System.Globalization.CultureInfo CI = new System.Globalization.CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = CI;
        }

        #region  读取语言XML
        public DataTable LanguageDT(string url)
        {
            try
            {
                DataTable Dt = new DataTable();
                DataColumn name = new DataColumn("name", typeof(string));
                DataColumn icon = new DataColumn("icon", typeof(string));
                DataColumn title = new DataColumn("title", typeof(string));
                Dt.Columns.Add(name);
                Dt.Columns.Add(icon);
                Dt.Columns.Add(title);

                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

                System.IO.Stream smStream = myResponse.GetResponseStream();
                System.Xml.XmlDocument smDoc = new System.Xml.XmlDocument();
                smDoc.Load(smStream);

                XmlElement rootElem = smDoc.DocumentElement;   //获取根节点  
                System.Xml.XmlNodeList smItems = rootElem.GetElementsByTagName("language");

                foreach (XmlNode node in smItems)
                {
                    DataRow Row = Dt.NewRow();

                    XmlNodeList smNode;

                    //名称
                    smNode = ((XmlElement)node).GetElementsByTagName("name");
                    if (smNode.Count == 1)
                    {
                        Row["name"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["name"] = "";
                    }

                    //图标
                    smNode = ((XmlElement)node).GetElementsByTagName("icon");
                    if (smNode.Count == 1)
                    {
                        Row["icon"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["icon"] = "";
                    }

                    //标题
                    smNode = ((XmlElement)node).GetElementsByTagName("title");
                    if (smNode.Count == 1)
                    {
                        Row["title"] = smNode[0].InnerText;
                    }
                    else
                    {
                        Row["title"] = "";
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
