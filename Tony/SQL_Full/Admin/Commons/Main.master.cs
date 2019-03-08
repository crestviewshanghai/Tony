using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

public partial class Admin_Commons_Main : System.Web.UI.MasterPage
{
    public string skin = "";
    public string skinCss = "";

    protected void Page_Init(object sender, EventArgs e)
    {
        MojoCube.Web.User.Login.ChkLogin();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.Title != "")
            {
                MojoCube.Web.User.Log.AddLog(this.Page.Title);
            }

            //用户信息
            MojoCube.Web.User.List user = new MojoCube.Web.User.List();
            user.GetData(int.Parse(Session["UserID"].ToString()));

            LeftMenu.InnerHtml = CreateLeftMenu();
            MyHistory.InnerHtml = CreateHistory(user.ShowHistory);
            lblYear.Text = DateTime.Now.Year.ToString();
            hlCopyright.NavigateUrl = "http://www.mojocube.com/";
            hlCopyright.Text = "MojoCube";
            hlCopyright.Target = "_blank";
            Welcome.InnerHtml = DateTime.Now.ToString("yyyy年MM月dd日") + ", " + MojoCube.Api.Date.Get.ChineseWeek();

            ViewState["Skin"] = user.Skin;

            lblFullName1.Text = lblFullName2.Text = user.FullName;
            if (user.ImagePath1 != "")
            {
                imgPortrait1.ImageUrl = imgPortrait2.ImageUrl = imgPortrait3.ImageUrl = "~/Admin/Files.aspx?image=" + MojoCube.Api.Text.Security.EncryptString(user.ImagePath1);
            }
            else
            {
                imgPortrait1.ImageUrl = imgPortrait2.ImageUrl = imgPortrait3.ImageUrl = "~/Admin/Images/user.png";
            }

            //职位
            MojoCube.Web.User.Position position = new MojoCube.Web.User.Position();
            position.GetData(user.Position);
            lblPosition.Text = position.Title;

            //部门
            MojoCube.Web.User.Department department = new MojoCube.Web.User.Department();
            department.GetData(user.fk_Department);
            lblDepartment.Text = department.DepartmentName;

            //角色
            MojoCube.Web.Role.Name role = new MojoCube.Web.Role.Name();
            role.GetData(user.RoleValue);
            lblRoleName.Text = role.RoleName_CHS;
        }

        this.Page.Title = "MojoCube";

        //界面皮肤
        if (ViewState["Skin"] != null)
        {
            skin = ViewState["Skin"].ToString();
        }
        else
        {
            skin = "blue";
        }
        skinCss = "<link rel=\"stylesheet\" href=\"../Skins/dist/css/skins/skin-" + skin + ".min.css\" /><link rel=\"stylesheet\" href=\"../Skins/plugins/iCheck/flat/" + skin + ".css\" />";
    }

    #region  历史记录

    private string CreateHistory(int showHistory)
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        dt = MojoCube.Web.Sql.SqlQueryDS("select top " + showHistory + " * from View_MyHistory where fk_User=" + Session["UserID"].ToString() + " and TypeID=0 order by CreateDate desc").Tables[0];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<li>");
                sb.Append("<a href=\"../../" + dt.Rows[i]["Url"].ToString() + "\">");
                sb.Append("<span class=\"control-sidebar-subheading\">" + dt.Rows[i]["Title"].ToString() + "</span>");
                sb.Append("<small>" + DateTime.Parse(dt.Rows[i]["CreateDate"].ToString()).ToString("MM-dd HH:mm") + "</small>");
                sb.Append("</a>");
                sb.Append("</li>");
            }
        }

        return sb.ToString();
    }

    #endregion

    #region  左侧菜单

    protected void lnbSearch_Click(object sender, EventArgs e)
    {
        LeftMenu.InnerHtml = CreateLeftMenu();
    }

    private string CreateLeftMenu()
    {
        StringBuilder sb = new StringBuilder();

        DataTable dt = new DataTable();

        ArrayList parameter = new ArrayList();
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@fk_RoleName", Session["RoleValue"].ToString(), SqlDbType.Int));
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@Name_CHS", txtKeyword.Text.Trim(), SqlDbType.NVarChar));
        parameter.Add(MojoCube.Web.SqlHelper.CreateParameter("@Tag_CHS", txtKeyword.Text.Trim(), SqlDbType.NVarChar));
        dt = MojoCube.Web.SqlHelper.SqlQueryDS("select * from View_Menu where fk_RoleName=@fk_RoleName and IsUse=1 and TypeID=0 and Visible=1 and (Name_CHS like '%'+@Name_CHS+'%' or Tag_CHS like '%'+@Tag_CHS+'%') order by SortID asc", parameter).Tables[0];

        sb.Append("<ul class=\"sidebar-menu\">");

        if (dt.Rows.Count > 0)
        {
            string active = "";
            string actice2 = "";

            #region  获取焦点ID

            if (Request.QueryString["active"] != null)
            {
                try
                {
                    string[] IDs = Request.QueryString["active"].ToString().Trim().Split(',');
                    if (IDs.Length > 1)
                    {
                        active = IDs[0];
                        actice2 = IDs[1];
                    }
                    else
                    {
                        active = IDs[0];
                    }
                }
                catch
                { }
            }

            #endregion

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ParentID"].ToString() == "0")
                {
                    DataRow[] dr = dt.Select("ParentID=" + dt.Rows[i]["pk_Menu"].ToString());
                    if (dr.Length > 0)
                    {
                        if (active == dt.Rows[i]["pk_Menu"].ToString())
                        {
                            sb.Append("<li class=\"active treeview\">");
                        }
                        else
                        {
                            sb.Append("<li class=\"treeview\">");
                        }
                        sb.Append("<a href=\"../.." + dt.Rows[i]["Url"].ToString() + "?active=" + dt.Rows[i]["pk_Menu"].ToString() + "\"><i class=\"fa " + dt.Rows[i]["Icon"].ToString() + "\"></i> <span>" + dt.Rows[i]["Name_CHS"].ToString() + "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>");
                        sb.Append("<ul class=\"treeview-menu\">");

                        for (int j = 0; j < dr.Length; j++)
                        {
                            if (actice2 == dr[j]["pk_Menu"].ToString())
                            {
                                sb.Append("<li class=\"active\">");
                            }
                            else
                            {
                                sb.Append("<li>");
                            }
                            sb.Append("<a href=\"../.." + dr[j]["Url"].ToString() + "?active=" + dr[j]["ParentID"].ToString() + "," + dr[j]["pk_Menu"].ToString() + "\"><i class=\"fa " + dr[j]["Icon"].ToString() + "\"></i> " + dr[j]["Name_CHS"].ToString() + "</a></li>");
                        }
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    else
                    {
                        if (active == dt.Rows[i]["pk_Menu"].ToString())
                        {
                            sb.Append("<li class=\"active\">");
                        }
                        else
                        {
                            sb.Append("<li>");
                        }
                        sb.Append("<a href=\"../.." + dt.Rows[i]["Url"].ToString() + "?active=" + dt.Rows[i]["pk_Menu"].ToString() + "\"><i class=\"fa " + dt.Rows[i]["Icon"].ToString() + "\"></i> <span>" + dt.Rows[i]["Name_CHS"].ToString() + "</span></a></li>");
                    }
                }
            }
        }

        sb.Append("</ul>");

        return sb.ToString();
    }

    #endregion
}
