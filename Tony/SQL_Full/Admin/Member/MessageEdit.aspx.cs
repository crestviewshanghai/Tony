using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Member_MessageEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Message.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Message"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Member.Message message = new MojoCube.Web.Member.Message();
                message.GetData(int.Parse(ViewState["pk_Message"].ToString()));

                txtTitle.Text = message.Title;
                txtDescription.Text = message.Contents;

                cblReceive.Items.Add(new ListItem("&nbsp;" + message.ReceiveUserName, message.ReceiveUserID.ToString()));
                cblReceive.Items[0].Selected = true;
                cblReceive.Items[0].Enabled = false;

                this.Title = "消息编辑：" + txtTitle.Text.Trim();
            }
            else
            {
                if (Request.QueryString["uid"] != null)
                {
                    string uid = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["uid"]);

                    DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Member_List where IsLock=0 and IsCheck=1 and pk_Member in (" + uid + ")").Tables[0];
                    cblReceive.DataSource = dt;
                    cblReceive.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cblReceive.Items[i].Text = dt.Rows[i]["UserName"].ToString();
                            cblReceive.Items[i].Value = dt.Rows[i]["pk_Member"].ToString();
                            cblReceive.Items[i].Selected = true;
                        }
                    }
                }
                else
                {
                    cblReceive.Items.Add(new ListItem("&nbsp;所有会员", "0"));
                    cblReceive.Items[0].Selected = true;
                    cblReceive.Items[0].Enabled = false;
                }

                this.Title = "消息编辑";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("danger", "请填写标题");
            return;
        }

        MojoCube.Web.Member.Message message = new MojoCube.Web.Member.Message();

        //修改
        if (ViewState["pk_Message"] != null)
        {
            message.GetData(int.Parse(ViewState["pk_Message"].ToString()));
            message.Title = txtTitle.Text.Trim();
            message.Contents = txtDescription.Text.Trim();
            message.UpdateData(message.pk_Message);

            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
        }
        //新增
        else
        {
            message.Title = txtTitle.Text.Trim();
            message.Contents = txtDescription.Text.Trim();
            message.Link = string.Empty;
            message.CreateUserID = int.Parse(Session["UserID"].ToString());
            message.CreateUserName = Session["UserName"].ToString();
            message.CreateDate = DateTime.Now.ToString();
            message.IsRead = false;
            message.IsDeleted = false;
            message.IsAdminSend = true;
            message.IsAdminReceive = true;
            message.StatusID = 0;
            message.IsReply = false;
            message.ReplyID = 0;

            if (cblReceive.Items[0].Value == "0")
            {
                DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Member_List where IsLock=0 and IsCheck=1").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        message.TypeID = 0;
                        message.ReceiveUserID = int.Parse(dt.Rows[i]["pk_Member"].ToString());
                        message.ReceiveUserName = dt.Rows[i]["UserName"].ToString();
                        message.ReceiveDate = DateTime.Now.ToString();
                        message.InsertData();
                    }
                }
            }
            else
            {
                for (int i = 0; i < cblReceive.Items.Count; i++)
                {
                    if (cblReceive.Items[i].Selected == true)
                    {
                        message.TypeID = 1;
                        message.ReceiveUserID = int.Parse(cblReceive.Items[i].Value);
                        message.ReceiveUserName = cblReceive.Items[i].Text;
                        message.ReceiveDate = DateTime.Now.ToString();
                        message.InsertData();
                    }
                }
            }

            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "消息发送成功");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Message.aspx?active=" + Request.QueryString["active"]);
    }
}