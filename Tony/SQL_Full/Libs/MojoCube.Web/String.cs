using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;

namespace MojoCube.Web
{
    public class String
    {
        #region  提示警告

        /// <summary>
        /// 提示警告
        /// </summary>
        /// <param name="type">danger/info/warning/success</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ShowAlert(string type, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"alert alert-" + type + " alert-dismissable\">");
            sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>");
            sb.Append(content);
            sb.Append("</div>");
            return sb.ToString();
        }

        #endregion

        #region  删除警告

        public static void ShowDel(GridViewRowEventArgs e)
        {
            string text = "删除该记录将不能恢复，确定删除吗？";
            ((LinkButton)e.Row.FindControl("gvDelete")).OnClientClick = "{return confirm('" + text + "');}";
        }

        #endregion

        #region  字符串转换

        public static int ToInt(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region  获取中文姓名

        /// <summary>
        /// 获取中文姓名
        /// </summary>
        /// <param name="text">全名</param>
        /// <param name="isLastName">True:姓 False:名</param>
        /// <returns></returns>
        public static string GetChineseName(string text, bool isLastName)
        {
            text = text.Replace("~", "").Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "").Replace("%", "").Replace("^", "").Replace("&", "").Replace("*", "").Replace("|", "");

            if (text == "")
            {
                text = "无名氏";
            }

            int len = text.Length;
            string x = "";
            string m = "";

            switch (len)
            {
                case 1:
                    x = text.Substring(0, 1);
                    break;
                case 2:
                    x = text.Substring(0, 1);
                    m = text.Substring(1, 1);
                    break;
                case 3:
                    string fx = text.Substring(0, 2);
                    if (fx == "欧阳" || fx == "慕容" || fx == "上官" || fx == "司马" || fx == "东方" || fx == "公孙" || fx == "吕丘" || fx == "诸葛" || fx == "夏侯" || fx == "东郭")
                    {
                        x = text.Substring(0, 2);
                        m = text.Substring(2, 1);
                    }
                    else
                    {
                        x = text.Substring(0, 1);
                        m = text.Substring(1, 2);
                    }
                    break;
                case 4:
                    x = text.Substring(0, 2);
                    m = text.Substring(2, 2);
                    break;
                case 5:
                    x = text.Substring(0, 2);
                    m = text.Substring(2, 3);
                    break;
                default:
                    x = text;
                    break;
            }

            if (isLastName)
            {
                return x;
            }
            else
            {
                return m;
            }
        }

        #endregion

        #region  分页每页显示数

        /// <summary>
        /// 分页每页显示数
        /// </summary>
        /// <returns></returns>
        public static int PageSize()
        {
            return 20;
        }

        /// <summary>
        /// 网页列表每页显示数量
        /// </summary>
        /// <param name="type">列表类型</param>
        /// <returns></returns>
        public static int PageSize(string type)
        {
            int iSize = 10;
            switch (type)
            {
                case "article":
                    {
                        iSize = 10;
                    }
                    break;
                case "product":
                    {
                        iSize = 12;
                    }
                    break;
                case "download":
                    {
                        iSize = 10;
                    }
                    break;
                case "album":
                    {
                        iSize = 12;
                    }
                    break;
                case "job":
                    {
                        iSize = 10;
                    }
                    break;
                case "comment":
                    {
                        iSize = 5;
                    }
                    break;
                case "cart":
                    {
                        iSize = 20;
                    }
                    break;
                case "message":
                    {
                        iSize = 10;
                    }
                    break;
                case "order":
                    {
                        iSize = 10;
                    }
                    break;
            }
            return iSize;
        }

        /// <summary>
        /// 分页页数按钮的数目
        /// </summary>
        /// <returns></returns>
        public static int GetNumericButtonCount()
        {
            return 5;
        }

        #endregion

        #region  获取浏览器信息

        public static string GetBrowserInfo()
        {
            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            return bc.Browser + " " + bc.Version;
        }

        #endregion

        #region  获取Url信息

        /// <summary>
        /// 以下以http://localhost:1897/News/Press/Content.aspx/123?id=1#toc为例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetUrl(int type)
        {
            string text = "";

            switch (type)
            {
                case 0:///News/Press/Content.aspx/123?id=1
                    //text = HttpContext.Current.Request.RawUrl;
                    {
                        string pageUrl = HttpContext.Current.Request.RawUrl;

                        string root = HttpContext.Current.Request.ApplicationPath;

                        if (root != "/")
                        {
                            root += "/";
                            pageUrl = pageUrl.Replace(root, "");
                        }

                        text = pageUrl;
                    }
                    break;
                case 1:///News/Press/Content.aspx
                    text = HttpContext.Current.Request.FilePath;
                    break;
                case 2:///News/Press/Content.aspx/123 
                    text = HttpContext.Current.Request.Path;
                    break;
                case 3://http://localhost:1897/News/Press/Content.aspx/123?id=1
                    text = HttpContext.Current.Request.Url.AbsoluteUri;
                    break;
                case 4://localhost
                    text = HttpContext.Current.Request.Url.Host;
                    break;
                case 5://1897
                    text = HttpContext.Current.Request.Url.Port.ToString();
                    break;
                case 6://localhost:1897
                    text = HttpContext.Current.Request.Url.Authority;
                    break;
                case 7://http
                    text = HttpContext.Current.Request.Url.Scheme;
                    break;
            }

            return text;
        }

        /// <summary>
        /// 获取相对路径
        /// </summary>
        /// <param name="path">原始路径</param>
        /// <returns></returns>
        public static string GetRelativePath(string path)
        {
            path = HttpContext.Current.Request.ApplicationPath + "/" + path;
            path = path.Replace("///", "/").Replace("//", "/");

            return path;
        }

        #endregion

        #region  格式化字串

        public static string SubString(string text, int textLong)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + "...";
            }
            return text;
        }

        #endregion

        #region  字符串和布尔类型互换

        public static string BoolToString(bool value)
        {
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static bool StringToBool(string value)
        {
            if (value == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  获取页面名

        public static string GetPageName()
        {
            string text = DateTime.Now.ToString("yyyyMMddHHmmss");
            return text;
        }

        #endregion

        #region  获取页面标题

        public static string GetTitle(string title1, string title2)
        {
            return title1 + " | " + title2;
        }

        #endregion

        #region  格式化货币

        public static string GetCurrency(decimal price)
        {
            return "¥ " + price.ToString("N1");
        }

        #endregion

        #region  获取浏览器信息

        public static string GetBrowser()
        {
            HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;
            return bc.Browser + " " + bc.Version;
        }

        #endregion
    }
}
