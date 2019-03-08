using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Menu : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            Nav.InnerHtml = GetNav(strLanguage);
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetNav(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteTopNav_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteTopNav_" + language] = CreateNav();
        }
        return HttpRuntime.Cache["MojoCube_SiteTopNav_" + language].ToString();
    }

    /// <summary>
    /// 创建导航
    /// </summary>
    /// <returns></returns>
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Site_Menu where TypeID=0 and Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            sb.Append("<nav class=\"navbar navbar-static-top navbar-default\">");
            sb.Append("<div class=\"container\">");
            sb.Append("<div class=\"navbar-header\">");
            sb.Append("<button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\">");
            sb.Append("<span class=\"sr-only\">Toggle navigation</span>");
            sb.Append("<span class=\"icon-bar\"></span>");
            sb.Append("<span class=\"icon-bar\"></span>");
            sb.Append("<span class=\"icon-bar\"></span>");
            sb.Append("</button>");
            sb.Append("<a class=\"navbar-brand\" href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[0]["Url"].ToString(), strLanguage) + "\"></a>");
            sb.Append("<span id=\"smallSearch\" class=\"glyphicon glyphicon-search\" aria-hidden=\"true\"></span>");
            sb.Append("</div>");
            sb.Append("<div id=\"navbar\" class=\"collapse navbar-collapse\">");
            sb.Append("<ul class=\"nav navbar-nav\">");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ParentID"].ToString() == "0")
                {
                    string url = MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage);

                    DataRow[] dr = dt.Select("ParentID=" + dt.Rows[i]["pk_Menu"].ToString());
                    if (dr.Length > 0)
                    {
                        sb.Append("<li class=\"dropdown\">");
                        sb.Append("<a href=\"" + url + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a>");
                        sb.Append("<a href=\"" + url + "\" id=\"app_menudown\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-expanded=\"false\"><span class=\"glyphicon glyphicon-menu-down btn-xs\"></span></a>");
                        sb.Append("<ul class=\"dropdown-menu\" role=\"menu\">");

                        for (int j = 0; j < dr.Length; j++)
                        {
                            url = MojoCube.Web.Site.Cache.GetUrlExtension(dr[j]["Url"].ToString(), strLanguage);

                            sb.Append("<li><a href=\"" + url + "\">" + dr[j]["MenuName"].ToString() + "</a></li>");
                        }

                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("<li><a href=\"" + url + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a></li>");
                    }
                }
            }

            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</nav>");
        }

        return sb.ToString();
    }
}