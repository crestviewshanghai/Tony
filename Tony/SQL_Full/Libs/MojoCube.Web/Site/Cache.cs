using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using MojoCube.Api.UI;
using System.Text.RegularExpressions;

namespace MojoCube.Web.Site
{
    /// <summary>
    /// 网站缓存
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key">key</param>
        public static void RemoveCache(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            System.Collections.IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            while (CacheEnum.MoveNext())
            {
                al.Add(CacheEnum.Key);
            }
            foreach (string key in al)
            {
                _cache.Remove(key);
            }
        }

        /// <summary>
        /// 获取网站所有缓存信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCacheDS()
        {
            System.Collections.IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("CacheKey");

            while (CacheEnum.MoveNext())
            {
                DataRow dr = dt.NewRow();
                dr["CacheKey"] = CacheEnum.Key;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            return ds;
        }

        /// <summary>
        /// 获取语言集合
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLanguageDT()
        {
            if (HttpRuntime.Cache["MojoCube_LanguageDT"] == null)
            {
                Language language = new Language();
                HttpRuntime.Cache["MojoCube_LanguageDT"] = language.LanguageDT(HttpContext.Current.Server.MapPath("~/App_LocalResources/config.xml"));
            }
            return (DataTable)HttpRuntime.Cache["MojoCube_LanguageDT"];
        }

        /// <summary>
        /// 获取网站是否锁定IP
        /// </summary>
        /// <returns></returns>
        public static string GetIsBoundIP(string language)
        {
            if (HttpRuntime.Cache["MojoCube_IsBoundIP_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_IsBoundIP_" + language] = config.IsBoundIP.ToString();
            }
            return HttpRuntime.Cache["MojoCube_IsBoundIP_" + language].ToString();
        }

        /// <summary>
        /// 获取网站锁定IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetBoundIP(string language)
        {
            if (HttpRuntime.Cache["MojoCube_BoundIP_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_BoundIP_" + language] = config.BoundIP;
            }
            return HttpRuntime.Cache["MojoCube_BoundIP_" + language].ToString();
        }

        /// <summary>
        /// 获取网页路径的扩展名
        /// </summary>
        /// <returns></returns>
        public static string GetUrlExtension(string language)
        {
            if (HttpRuntime.Cache["MojoCube_UrlExtension_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_UrlExtension_" + language] = config.UrlExtension;
            }
            return HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString();
        }

        /// <summary>
        /// 获取网页路径的扩展名
        /// </summary>
        /// <param name="url">传入路径</param>
        /// <returns></returns>
        public static string GetUrlExtension(string url, string language)
        {
            if (url == "#")
            {
                return url;
            }

            string s = @"http://([\w-]+\.)+[\w-]+(/[\w-\./?%=]*)?";
            Regex reg = new Regex(s);
            Match mch = reg.Match(url);
            if (mch.Success)
            {
                //这是以 http:// 开头的
                url = url.Trim();
            }
            else
            {
                //这不是以 http:// 开头的
                url = url.Split('.')[0].ToLower();

                if (HttpRuntime.Cache["MojoCube_UrlExtension_" + language] == null)
                {
                    Config config = new Config();
                    config.GetData(1, language);
                    HttpRuntime.Cache["MojoCube_UrlExtension_" + language] = config.UrlExtension;
                }

                switch (HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString())
                {
                    case "":
                        url = url.Trim() + "/";
                        break;
                    default:
                        url = url.Trim() + "." + HttpRuntime.Cache["MojoCube_UrlExtension_" + language].ToString();
                        break;
                }
            }
            return url;
        }

        /// <summary>
        /// 获取网站域名
        /// </summary>
        /// <returns></returns>
        public static string GetDomain(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Domain_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Domain_" + language] = config.SiteUrl;
            }
            return HttpRuntime.Cache["MojoCube_Domain_" + language].ToString();
        }

        /// <summary>
        /// 获取网站主题
        /// </summary>
        /// <returns></returns>
        public static string GetSiteTheme(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteTheme_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteTheme_" + language] = config.SiteTheme;
            }
            return HttpRuntime.Cache["MojoCube_SiteTheme_" + language].ToString();
        }

        /// <summary>
        /// 获取网站名称
        /// </summary>
        /// <returns></returns>
        public static string GetSiteName(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteName_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteName_" + language] = config.SiteName;
            }
            return HttpRuntime.Cache["MojoCube_SiteName_" + language].ToString();
        }

        /// <summary>
        /// 获取网站标题
        /// </summary>
        /// <returns></returns>
        public static string GetSiteTitle(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteTitle_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteTitle_" + language] = config.SiteTitle;
            }
            return HttpRuntime.Cache["MojoCube_SiteTitle_" + language].ToString();
        }

        /// <summary>
        /// 获取网站Content Type
        /// </summary>
        /// <returns></returns>
        public static string GetSiteContentType(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteContentType_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteContentType_" + language] = config.SiteContentType;
            }
            return HttpRuntime.Cache["MojoCube_SiteContentType_" + language].ToString();
        }

        /// <summary>
        /// 获取网站Keyword
        /// </summary>
        /// <returns></returns>
        public static string GetSiteKeyword(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteKeyword_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteKeyword_" + language] = config.SiteKeyword;
            }
            return HttpRuntime.Cache["MojoCube_SiteKeyword_" + language].ToString();
        }

        /// <summary>
        /// 获取网站Description
        /// </summary>
        /// <returns></returns>
        public static string GetSiteDescription(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteDescription_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteDescription_" + language] = config.SiteDescription;
            }
            return HttpRuntime.Cache["MojoCube_SiteDescription_" + language].ToString();
        }

        /// <summary>
        /// 获取统计代码
        /// </summary>
        /// <returns></returns>
        public static string GetStatistics(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Statistics_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Statistics_" + language] = config.StatisticsCode;
            }
            return HttpRuntime.Cache["MojoCube_Statistics_" + language].ToString();
        }

        /// <summary>
        /// 获取分享代码
        /// </summary>
        /// <returns></returns>
        public static string GetShare(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Share_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Share_" + language] = config.ShareCode;
            }
            return HttpRuntime.Cache["MojoCube_Share_" + language].ToString();
        }

        /// <summary>
        /// 获取网站Logo
        /// </summary>
        /// <returns></returns>
        public static string GetSiteLogo(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteLogo_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteLogo_" + language] = config.SiteLogo;
            }
            return HttpRuntime.Cache["MojoCube_SiteLogo_" + language].ToString();
        }

        /// <summary>
        /// 获取网站电话
        /// </summary>
        /// <returns></returns>
        public static string GetSiteContact(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteContact_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteContact_" + language] = config.SiteContact;
            }
            return HttpRuntime.Cache["MojoCube_SiteContact_" + language].ToString();
        }

        /// <summary>
        /// 获取联系我们
        /// </summary>
        /// <returns></returns>
        public static string GetContactUs(string language)
        {
            if (HttpRuntime.Cache["MojoCube_ContactUs_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_ContactUs_" + language] = config.ContactUs;
            }
            return HttpRuntime.Cache["MojoCube_ContactUs_" + language].ToString();
        }

        /// <summary>
        /// 获取网站版权信息
        /// </summary>
        /// <returns></returns>
        public static string GetSiteCopyRight(string language)
        {
            #region  是否开启网站
            if (HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                if (config.IsSiteOpen)
                {
                    HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] = "1"; //true
                }
                else
                {
                    HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language] = "0"; //false
                }
            }

            //如果关闭网站
            if (HttpRuntime.Cache["MojoCube_IsSiteOpen_" + language].ToString() == "0")
            {
                HttpContext.Current.Response.Redirect("~/Info.aspx?type=0");
                HttpContext.Current.Response.End();
            }
            #endregion

            #region  浏览页面是否添加进网站日志
            if (HttpRuntime.Cache["MojoCube_SiteCounter_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                if (config.SiteCounter)
                {
                    HttpRuntime.Cache["MojoCube_SiteCounter_" + language] = "1"; //true
                }
                else
                {
                    HttpRuntime.Cache["MojoCube_SiteCounter_" + language] = "0"; //false
                }
            }

            if (HttpRuntime.Cache["MojoCube_SiteCounter_" + language].ToString() == "1")
            {
                Log.InsertData(language);
            }
            #endregion

            if (HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language] = config.SiteCopyRight;
            }
            return HttpRuntime.Cache["MojoCube_SiteCopyRight_" + language].ToString();
        }

        /// <summary>
        /// 获取地图代码
        /// </summary>
        /// <returns></returns>
        public static string GetMap(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Map_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Map_" + language] = config.MapCode;
            }
            return HttpRuntime.Cache["MojoCube_Map_" + language].ToString();
        }

        /// <summary>
        /// 获取网站公告
        /// </summary>
        /// <returns></returns>
        public static string GetSiteNotify(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteNotify_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteNotify_" + language] = config.SiteNotify;
            }
            return HttpRuntime.Cache["MojoCube_SiteNotify_" + language].ToString();
        }

        /// <summary>
        /// 获取搜索类型，0为产品，1为文章
        /// </summary>
        /// <returns></returns>
        public static string GetSearchType(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SearchType_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SearchType_" + language] = config.SearchType.ToString();
            }
            return HttpRuntime.Cache["MojoCube_SearchType_" + language].ToString();
        }

        /// <summary>
        /// 获取客服显示
        /// </summary>
        /// <returns></returns>
        public static string GetSiteService(string language)
        {
            if (HttpRuntime.Cache["MojoCube_SiteService_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_SiteService_" + language] = config.ShowService;
            }
            return HttpRuntime.Cache["MojoCube_SiteService_" + language].ToString();
        }

        /// <summary>
        /// 获取文章标题字数
        /// </summary>
        /// <returns></returns>
        public static string GetArticleTitleLength(string language)
        {
            if (HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language] = config.ArticleTitleLength;
            }
            return HttpRuntime.Cache["MojoCube_ArticleTitleLength_" + language].ToString();
        }

        /// <summary>
        /// 获取网站Banner
        /// </summary>
        /// <returns></returns>
        public static string GetSiteBanner(string language, int typeId)
        {
            if (HttpRuntime.Cache["MojoCube_SiteBanner_Type_" + typeId + language] == null)
            {
                DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Site_Banner where TypeID=" + typeId + " and Visible=1 and Language='" + language + "'").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    HttpRuntime.Cache["MojoCube_SiteBanner_Type_" + typeId + language] = "<div><a href=\"" + dt.Rows[0]["Url"].ToString() + "\" target=\"" + dt.Rows[0]["Target"].ToString() + "\"><img src=\"Files/" + dt.Rows[0]["FilePath"].ToString() + "\" alt=\"" + dt.Rows[0]["Title"].ToString() + "\" /></a></div>";
                }
                else
                {
                    HttpRuntime.Cache["MojoCube_SiteBanner_Type_" + typeId + language] = "";
                }
            }
            return HttpRuntime.Cache["MojoCube_SiteBanner_Type_" + typeId + language].ToString();
        }

        /// <summary>
        /// 获取注册条款
        /// </summary>
        /// <returns></returns>
        public static string GetTerms(string language)
        {
            if (HttpRuntime.Cache["MojoCube_Terms_" + language] == null)
            {
                Config config = new Config();
                config.GetData(1, language);
                HttpRuntime.Cache["MojoCube_Terms_" + language] = config.Terms;
            }
            return HttpRuntime.Cache["MojoCube_Terms_" + language].ToString();
        }
    }
}
