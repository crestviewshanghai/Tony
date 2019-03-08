using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Footer : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            Nav.InnerHtml = GetNav(strLanguage);

            lblCopyRight.Text = MojoCube.Web.Site.Cache.GetSiteCopyRight(strLanguage);

            HtmlCode.InnerHtml = MojoCube.Web.Site.Cache.GetStatistics(strLanguage);
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetNav(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteBottomNav_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteBottomNav_" + language] = CreateNav();
        }
        return HttpRuntime.Cache["MojoCube_SiteBottomNav_" + language].ToString();
    }

    /// <summary>
    /// 创建导航
    /// </summary>
    /// <returns></returns>
    private string CreateNav()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Site_Menu where TypeID=1 and ParentID=0 and Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            sb.Append("<p>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage) + "\">" + dt.Rows[i]["MenuName"].ToString() + "</a>");

                if (i < dt.Rows.Count - 1)
                {
                    sb.Append("&nbsp;&nbsp;|&nbsp;&nbsp;");
                }
            }
            sb.Append("</p>");
        }

        return sb.ToString();
    }
}