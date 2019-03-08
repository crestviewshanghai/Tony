using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class WUC_Article : System.Web.UI.UserControl
{
    public string strLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strLanguage = MojoCube.Api.UI.Language.GetLanguage();

            hlMore.NavigateUrl = MojoCube.Web.Site.Cache.GetUrlExtension("News", strLanguage);

            ArticleUL.InnerHtml = GetArticle(strLanguage);
        }
    }

    /// <summary>
    /// 加入到网站缓存，减少数据库连接
    /// </summary>
    /// <param name="language">语言</param>
    /// <returns></returns>
    private string GetArticle(string language)
    {
        if (HttpRuntime.Cache["MojoCube_SiteArticle_" + language] == null)
        {
            HttpRuntime.Cache["MojoCube_SiteArticle_" + language] = CreateArticle();
        }
        return HttpRuntime.Cache["MojoCube_SiteArticle_" + language].ToString();
    }

    /// <summary>
    /// 创建文章
    /// </summary>
    /// <returns></returns>
    private string CreateArticle()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select top 5 Title,PageName,CreateDate from Article_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            int leng = int.Parse(MojoCube.Web.Site.Cache.GetArticleTitleLength(strLanguage));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li><a href=\"" + MojoCube.Web.Site.Cache.GetUrlExtension("N-" + dt.Rows[i]["PageName"].ToString(), strLanguage) + "\" title=\"" + dt.Rows[i]["Title"].ToString() + "\">" + MojoCube.Web.String.SubString(dt.Rows[i]["Title"].ToString(), leng) + "</a></li>");
            }
        }

        return sb.ToString();
    }
}