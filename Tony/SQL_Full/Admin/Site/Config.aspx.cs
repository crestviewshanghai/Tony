using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;

public partial class Admin_Site_Config : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["info"] != null)
            {
                AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
            }

            MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
            config.GetData(1, MojoCube.Api.UI.Language.GetLanguage());

            if (config.pk_Config > 0)
            {
                txtSiteName.Text = config.SiteName;
                txtSiteTitle.Text = config.SiteTitle;
                txtSEO_Title.Text = config.SiteTitle;
                txtSEO_Keyword.Text = config.SiteKeyword;
                txtSEO_Description.Text = config.SiteDescription;
                txtSiteUrl.Text = config.SiteUrl;
                txtContent.Text = config.SiteCopyRight;
                txtSiteContact.Text = config.SiteContact;
                txtDescription.Text = config.ContactUs;
                txtStatisticsCode.Text = config.StatisticsCode;
                txtShareCode.Text = config.ShareCode;
                txtNotify.Text = config.SiteNotify;
                txtClosedInfo.Text = config.ClosedInfo;
                txtBoundIP.Text = config.BoundIP;
                txtArticleTitleLength.Text = config.ArticleTitleLength.ToString();
                txtTerms.Text = config.Terms;

                MojoCube.Web.Sql.ddlFindByValue(ddlStatus, MojoCube.Web.String.BoolToString(config.IsSiteOpen));
                MojoCube.Web.Sql.ddlFindByValue(ddlCounter, MojoCube.Web.String.BoolToString(config.SiteCounter));
                MojoCube.Web.Sql.ddlFindByValue(ddlBoundIP, MojoCube.Web.String.BoolToString(config.IsBoundIP));
                MojoCube.Web.Sql.ddlFindByValue(ddlService, MojoCube.Web.String.BoolToString(config.ShowService));
                MojoCube.Web.Sql.ddlFindByValue(ddlExtension, config.UrlExtension);
                MojoCube.Web.Sql.ddlFindByValue(ddlSearchType, config.SearchType.ToString());

                //Logo
                if (config.SiteLogo != "")
                {
                    imgLogo.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(config.SiteLogo) + "&w=400&h=300";
                }
                else
                {
                    imgLogo.Visible = false;
                }

                txtShowWM.Text = config.WM_Text;
                txtShowFS.Text = config.WM_Font + "|" + config.WM_FontSize.ToString();
                txtPadding.Text = config.WM_Bottom.ToString() + "|" + config.WM_Right.ToString();
                txtRGB.Text = config.WM_Red.ToString() + "|" + config.WM_Green.ToString() + "|" + config.WM_Blue.ToString();
                txtShowWH.Text = config.WM_Show_W.ToString() + "|" + config.WM_Show_H.ToString();

                MojoCube.Web.Sql.ddlFindByValue(ddlRotate, config.WM_Rotate.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlSize, config.WM_Size.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlAlpha, config.WM_Alpha.ToString());
                MojoCube.Web.Sql.ddlFindByValue(ddlShowWM, MojoCube.Web.String.BoolToString(config.WM_IsShow));
                MojoCube.Web.Sql.ddlFindByValue(ddlModeWM, MojoCube.Web.String.BoolToString(config.WM_Mode));

                //水印图片
                if (config.WM_ImagePath != "")
                {
                    imgWM.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(config.WM_ImagePath) + "&w=400&h=300";
                }
                else
                {
                    imgWM.Visible = false;
                }
            }

            this.Title = "网站设置";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
        config.GetData(1, MojoCube.Api.UI.Language.GetLanguage());

        if (config.pk_Config > 0)
        {
            config.SiteName = txtSiteName.Text.Trim();
            config.SiteTitle = txtSiteTitle.Text.Trim();
            config.SiteKeyword = txtSEO_Keyword.Text.Trim();
            config.SiteDescription = txtSEO_Description.Text.Trim();
            config.SiteUrl = txtSiteUrl.Text.Trim();
            config.SiteCopyRight = txtContent.Text.Trim();
            config.SiteContact = txtSiteContact.Text.Trim();
            config.ContactUs = txtDescription.Text.Trim();
            config.StatisticsCode = txtStatisticsCode.Text.Trim();
            config.ShareCode = txtShareCode.Text.Trim();
            config.IsSiteOpen = MojoCube.Web.String.StringToBool(ddlStatus.SelectedValue);
            config.SiteCounter = MojoCube.Web.String.StringToBool(ddlCounter.SelectedValue);
            config.IsBoundIP = MojoCube.Web.String.StringToBool(ddlBoundIP.SelectedValue);
            config.BoundIP = txtBoundIP.Text.Trim();
            config.UrlExtension = ddlExtension.SelectedValue;
            config.SearchType = int.Parse(ddlSearchType.SelectedValue);
            config.SiteNotify = txtNotify.Text.Trim();
            config.ClosedInfo = txtClosedInfo.Text.Trim();

            //Logo
            string logo = GetLogo();
            if (logo != "")
            {
                config.SiteLogo = logo;
            }

            config.SiteLogoPath = "Site/Logo";
            config.ArticleImagePath = "Article/[Category]";
            config.ProductImagePath = "Product/[Category]";
            config.ADImagePath = "Site/Banner";
            config.WM_Text = txtShowWM.Text.Trim();

            //字体、大小
            if (txtShowFS.Text.Trim() != "")
            {
                config.WM_Font = txtShowFS.Text.Trim().Split('|')[0];
                config.WM_FontSize = int.Parse(txtShowFS.Text.Trim().Split('|')[1]);
            }

            //边距
            if (txtPadding.Text.Trim() != "")
            {
                config.WM_Bottom = int.Parse(txtPadding.Text.Trim().Split('|')[0]);
                config.WM_Right = int.Parse(txtPadding.Text.Trim().Split('|')[1]);
            }

            config.WM_Rotate = int.Parse(ddlRotate.SelectedValue);
            config.WM_Size = int.Parse(ddlSize.SelectedValue);
            config.WM_Alpha = int.Parse(ddlAlpha.SelectedValue);

            //RGB
            if (txtRGB.Text.Trim() != "")
            {
                config.WM_Red = int.Parse(txtRGB.Text.Trim().Split('|')[0]);
                config.WM_Green = int.Parse(txtRGB.Text.Trim().Split('|')[1]);
                config.WM_Blue = int.Parse(txtRGB.Text.Trim().Split('|')[2]);
            }

            config.WM_IsShow = MojoCube.Web.String.StringToBool(ddlShowWM.SelectedValue);

            //限制宽高
            if (txtShowWH.Text.Trim() != "")
            {
                config.WM_Show_W = int.Parse(txtShowWH.Text.Trim().Split('|')[0]);
                config.WM_Show_H = int.Parse(txtShowWH.Text.Trim().Split('|')[1]);
            }

            config.WM_Mode = MojoCube.Web.String.StringToBool(ddlModeWM.SelectedValue);

            //水印图片
            string wm = GetWM();
            if (wm != "")
            {
                config.WM_ImagePath = wm;
            }

            config.ShowService = MojoCube.Web.String.StringToBool(ddlService.SelectedValue);
            config.ArticleTitleLength = MojoCube.Web.String.ToInt(txtArticleTitleLength.Text.Trim());
            config.Terms = txtTerms.Text.Trim();

            config.UpdateData(config.pk_Config);
        }
        else
        {
            config.IndexID = 1;
            config.SiteName = txtSiteName.Text.Trim();
            config.SiteTitle = txtSiteTitle.Text.Trim();
            config.SiteKeyword = txtSEO_Keyword.Text.Trim();
            config.SiteDescription = txtSEO_Description.Text.Trim();
            config.SiteContentType = "text/html; charset=utf-8";
            config.SiteUrl = txtSiteUrl.Text.Trim();
            config.SiteLogo = GetLogo();
            config.SiteCopyRight = txtContent.Text.Trim();
            config.SiteContact = txtSiteContact.Text.Trim();
            config.SiteNotify = txtNotify.Text.Trim();
            config.MapCode = string.Empty;
            config.StatisticsCode = txtStatisticsCode.Text.Trim();
            config.ShareCode = txtShareCode.Text.Trim();
            config.OtherMeta = string.Empty;
            config.ContactUs = txtDescription.Text.Trim();
            config.IsSiteOpen = MojoCube.Web.String.StringToBool(ddlStatus.SelectedValue);
            config.ClosedInfo = txtClosedInfo.Text.Trim();
            config.ShowPageSize = 10;
            config.AllowComment = true;
            config.SiteLogoPath = "Site/Logo";
            config.ArticleImagePath = "Article/[Category]";
            config.ProductImagePath = "Product/[Category]";
            config.ADImagePath = "Site/Banner";
            config.ImgSize_S_W = 120;
            config.ImgSize_S_H = 100;
            config.ImgSize_M_W = 200;
            config.ImgSize_M_H = 200;
            config.SiteTheme = "Default";
            config.WM_Text = txtShowWM.Text.Trim();

            //字体、大小
            if (txtShowFS.Text.Trim() != "")
            {
                config.WM_Font = txtShowFS.Text.Trim().Split('|')[0];
                config.WM_FontSize = int.Parse(txtShowFS.Text.Trim().Split('|')[1]);
            }
            else
            {
                config.WM_Font = "Arial";
                config.WM_FontSize = 50;
            }

            //边距
            if (txtPadding.Text.Trim() != "")
            {
                config.WM_Bottom = int.Parse(txtPadding.Text.Trim().Split('|')[0]);
                config.WM_Right = int.Parse(txtPadding.Text.Trim().Split('|')[1]);
            }
            else
            {
                config.WM_Bottom = 10;
                config.WM_Right = 10;
            }

            config.WM_Rotate = int.Parse(ddlRotate.SelectedValue);
            config.WM_Size = int.Parse(ddlSize.SelectedValue);
            config.WM_Alpha = int.Parse(ddlAlpha.SelectedValue);

            //RGB
            if (txtRGB.Text.Trim() != "")
            {
                config.WM_Red = int.Parse(txtRGB.Text.Trim().Split('|')[0]);
                config.WM_Green = int.Parse(txtRGB.Text.Trim().Split('|')[1]);
                config.WM_Blue = int.Parse(txtRGB.Text.Trim().Split('|')[2]);
            }
            else
            {
                config.WM_Red = 255;
                config.WM_Green = 255;
                config.WM_Blue = 255;
            }

            config.WM_IsShow = MojoCube.Web.String.StringToBool(ddlShowWM.SelectedValue);

            //限制宽高
            if (txtShowWH.Text.Trim() != "")
            {
                config.WM_Show_W = int.Parse(txtShowWH.Text.Trim().Split('|')[0]);
                config.WM_Show_H = int.Parse(txtShowWH.Text.Trim().Split('|')[1]);
            }
            else
            {
                config.WM_Show_W = 300;
                config.WM_Show_H = 300;
            }

            config.WM_Mode = MojoCube.Web.String.StringToBool(ddlModeWM.SelectedValue);
            config.WM_ImagePath = GetWM();
            config.SiteCounter = MojoCube.Web.String.StringToBool(ddlCounter.SelectedValue);
            config.SiteFlow = 0;
            config.UrlExtension = ddlExtension.SelectedValue;
            config.IsBoundIP = MojoCube.Web.String.StringToBool(ddlBoundIP.SelectedValue);
            config.BoundIP = txtBoundIP.Text.Trim();
            config.Target = "_self";
            config.SearchType = int.Parse(ddlSearchType.SelectedValue);
            config.ShowService = MojoCube.Web.String.StringToBool(ddlService.SelectedValue);
            config.ArticleTitleLength = MojoCube.Web.String.ToInt(txtArticleTitleLength.Text.Trim());
            config.Terms = txtTerms.Text.Trim();
            config.Language = MojoCube.Api.UI.Language.GetLanguage();

            config.InsertData();
        }

        Response.Redirect("Config.aspx?info=1&active=" + Request.QueryString["active"]);
    }

    //上传Logo
    private string GetLogo()
    {
        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();

        upload.FilePath = "Site/Logo";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuLogo);

        if (upload.IsUpload)
        {
            imgLogo.Visible = true;
            imgLogo.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(upload.OldFilePath) + "&w=400&h=300";
            return upload.OldFilePath;
        }
        else
        {
            imgLogo.Visible = false;
            return string.Empty;
        }
    }

    //上传水印
    private string GetWM()
    {
        MojoCube.Api.File.Upload upload = new MojoCube.Api.File.Upload();

        upload.FilePath = "Site/Watermark";
        upload.FileName = MojoCube.Api.Text.Function.DateTimeString(true);
        upload.DoFileUpload(fuWM);

        if (upload.IsUpload)
        {
            imgWM.Visible = true;
            imgWM.ImageUrl = "~/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(upload.OldFilePath) + "&w=400&h=300";
            return upload.OldFilePath;
        }
        else
        {
            imgWM.Visible = false;
            return string.Empty;
        }
    }

    //生成网站地图
    protected void btnSiteMap_Click(object sender, EventArgs e)
    {
        string strLanguage = MojoCube.Api.UI.Language.GetLanguage();
        MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
        config.GetData(1, strLanguage);
        string domain = config.SiteUrl;

        #region  连接数据层
        StringBuilder strSql = new StringBuilder();
        //0：导航菜单
        strSql.Append("select * from Site_Menu where Visible=1 and Language='" + strLanguage + "' order by SortID asc");
        //1：文章类别
        strSql.Append(" select * from Article_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc");
        //2：文章列表
        strSql.Append(" select * from Article_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc");
        //3：产品类别
        strSql.Append(" select * from Product_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc");
        //4：产品列表
        strSql.Append(" select * from Product_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc");
        //5：相册类别
        strSql.Append(" select * from Album_Category where Visible=1 and Language='" + strLanguage + "' order by SortID asc");
        //6：相册列表
        strSql.Append(" select * from Album_List where Issue=1 and Language='" + strLanguage + "' order by CreateDate desc");

        DataSet ds = MojoCube.Web.Sql.SqlQueryDS(strSql.ToString());
        #endregion

        DataTable dt = new DataTable();

        DataTable dtSM = new DataTable();
        dtSM.Columns.Add("loc");
        dtSM.Columns.Add("lastmod");
        dtSM.Columns.Add("changefreq");
        dtSM.Columns.Add("priority");

        #region  生成数据表
        //导航菜单
        dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension(dt.Rows[i]["Url"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //文章类别
        dt = ds.Tables[1];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("NC-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //文章列表
        dt = ds.Tables[2];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("N-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //产品类别
        dt = ds.Tables[3];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("PC-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //产品列表
        dt = ds.Tables[4];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("P-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //相册类别
        dt = ds.Tables[5];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("AC-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }

        //相册列表
        dt = ds.Tables[6];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtSM.NewRow();
                dr["loc"] = domain + MojoCube.Web.Site.Cache.GetUrlExtension("A-" + dt.Rows[i]["PageName"].ToString(), strLanguage);
                dr["lastmod"] = DateTime.Now;
                dr["changefreq"] = "daily";
                dr["priority"] = "1.0";
                dtSM.Rows.Add(dr);
            }
        }
        #endregion

        //保存到根目录下
        MojoCube.Api.XML.SiteMap map = new MojoCube.Api.XML.SiteMap();
        string filePath = HttpContext.Current.Server.MapPath("~/sitemap.xml");
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.Write(map.CreateSiteMap(dtSM));
        }

        Response.Redirect("Config.aspx?info=1&active=" + Request.QueryString["active"]);
    }

    //恢复出厂设置
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string sql = "";

        //删除文章分类
        sql += " delete from Article_Category";
        //删除文章列表
        sql += " delete from Article_List";
        //删除产品分类
        sql += " delete from Product_Category";
        //删除产品列表
        sql += " delete from Product_List";
        //删除产品图片
        sql += " delete from Product_Image";
        //删除相册分类
        sql += " delete from Album_Category";
        //删除相册列表
        sql += " delete from Album_List";
        //删除相册图片
        sql += " delete from Album_Image";
        //删除下载分类
        sql += " delete from Download_Category";
        //删除下载列表
        sql += " delete from Download_List";
        //删除招聘分类
        sql += " delete from Job_Category";
        //删除招聘列表
        sql += " delete from Job_List";
        //删除网站留言
        sql += " delete from Comment_List";
        //删除网站内容
        sql += " delete from Content_List";
        //删除网站横幅
        sql += " delete from Site_Banner";
        //删除网站链接
        sql += " delete from Site_Link";
        //删除网站客服
        sql += " delete from Site_Service";
        //删除网站日志
        sql += " delete from Site_Log";
        //删除菜单导航
        sql += " delete from Site_Menu";
        //删除网站设置
        sql += " delete from Site_Config";
        //删除搜索记录
        sql += " delete from Site_Search";
        //删除图片分类
        sql += " delete from Image_Category";
        //删除图片列表
        sql += " delete from Image_List";
        //删除我的便签
        sql += " delete from Memo_List";
        //删除会员购物车
        sql += " delete from Member_Cart";
        //删除会员收藏夹
        sql += " delete from Member_Favorite";
        //删除会员列表
        sql += " delete from Member_List";
        //删除会员邮件
        sql += " delete from Member_Mail";
        //删除会员消息
        sql += " delete from Member_Message";
        //删除会员在线
        sql += " delete from Member_Online";
        //删除订单产品
        sql += " delete from Order_Item";
        //删除订单列表
        sql += " delete from Order_List";
        //删除交易记录
        sql += " delete from Order_Log";
        //删除短信记录
        sql += " delete from SMS_Log";

        MojoCube.Web.Sql.SqlQuery(sql);
        Response.Redirect("../Dashboard/Default.aspx");
    }
}