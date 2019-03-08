using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Banner : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            BannerDiv.InnerHtml = GetBanner(strLanguage);
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetBanner(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteBanner_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteBanner_" + language] = CreateBanner();
        }
        return HttpRuntime.Cache["MojoCube_SiteBanner_" + language].ToString();
    }

    /// <summary>
    /// 创建横幅
    /// </summary>
    /// <returns></returns>
    private string CreateBanner()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Site_Banner where TypeID=0 and Visible=1 and Language='" + strLanguage + "' order by SortID asc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            sb.Append("<div class=\"slider\">");
            sb.Append("<ul class=\"slider__wrapper\">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li class=\"slider__item\"><a target=\"" + dt.Rows[i]["Target"].ToString() + "\" alt=\"" + dt.Rows[i]["Title"].ToString() + "\" href=\"" + dt.Rows[i]["Url"].ToString() + "\" style=\"background-image:url(Files/" + dt.Rows[i]["FilePath"].ToString() + ")\"><img src=\"images/0.png\" /></a></li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");
        }

        return sb.ToString();
    }
}