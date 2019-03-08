using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Member_MailEdit : MojoCube.Api.UI.MyPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlBack.NavigateUrl = "Mail.aspx?active=" + Request.QueryString["active"];

            if (Request.QueryString["id"] != null)
            {
                ViewState["pk_Mail"] = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["id"]);

                MojoCube.Web.Member.Mail mail = new MojoCube.Web.Member.Mail();
                mail.GetData(int.Parse(ViewState["pk_Mail"].ToString()));

                txtTitle.Text = mail.Subject;
                txtDescription.Text = mail.Contents;

                MojoCube.Web.Member.List user = new MojoCube.Web.Member.List();
                user.GetData(mail.fk_Member);

                cblReceive.Items.Add(new ListItem("&nbsp;" + user.UserName, user.pk_Member.ToString()));
                cblReceive.Items[0].Selected = true;
                cblReceive.Items[0].Enabled = false;

                this.Title = "邮件编辑：" + txtTitle.Text.Trim();
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

                MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();
                account.GetDataTypeID(3);

                MojoCube.Web.Mail.Template template = new MojoCube.Web.Mail.Template();
                template.GetDataAccountID(account.pk_Account);
                txtTitle.Text = template.Subject;
                txtDescription.Text = template.Description;

                this.Title = "邮件编辑";
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

        MojoCube.Web.Member.Mail mail = new MojoCube.Web.Member.Mail();

        //修改
        if (ViewState["pk_Mail"] != null)
        {
            mail.GetData(int.Parse(ViewState["pk_Mail"].ToString()));
            mail.Subject = txtTitle.Text.Trim();
            mail.Contents = txtDescription.Text.Trim();
            mail.UpdateData(mail.pk_Mail);

            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "数据保存成功");
        }
        //新增
        else
        {
            mail.fk_Account = 0;
            mail.fk_Template = 0;
            mail.CC = string.Empty;
            mail.Bcc = string.Empty;
            mail.Subject = txtTitle.Text.Trim();
            mail.Contents = txtDescription.Text.Trim();
            mail.StatusID = 0;
            mail.CreateDate = DateTime.Now.ToString();
            mail.CreateUserID = int.Parse(Session["UserID"].ToString());

            if (cblReceive.Items[0].Value == "0")
            {
                DataTable dt = MojoCube.Web.Sql.SqlQueryDS("select * from Member_List where IsLock=0 and IsCheck=1").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mail.TypeID = 0;
                        mail.fk_Member = int.Parse(dt.Rows[i]["pk_Member"].ToString());
                        mail.Email = dt.Rows[i]["Email"].ToString();
                        mail.ReceiveName = dt.Rows[i]["UserName"].ToString();
                        mail.IsSend = SendMail(dt.Rows[i]["Email"].ToString(), dt.Rows[i]["FirstName"].ToString(), dt.Rows[i]["LastName"].ToString(), dt.Rows[i]["UserName"].ToString());
                        mail.InsertData();
                    }
                }
            }
            else
            {
                for (int i = 0; i < cblReceive.Items.Count; i++)
                {
                    if (cblReceive.Items[i].Selected == true)
                    {
                        mail.TypeID = 1;
                        mail.fk_Member = int.Parse(cblReceive.Items[i].Value);
                        MojoCube.Web.Member.List user = new MojoCube.Web.Member.List();
                        user.GetData(mail.fk_Member);
                        mail.Email = user.Email;
                        mail.ReceiveName = cblReceive.Items[i].Text;
                        mail.IsSend = SendMail(user.Email, user.FirstName, user.LastName, user.UserName);
                        mail.InsertData();
                    }
                }
            }

            AlertDiv.InnerHtml = MojoCube.Web.String.ShowAlert("success", "邮件发送成功");
        }
    }

    //发送邮件
    private bool SendMail(string mailto, string firstName, string lastName, string userName)
    {
        MojoCube.Web.Mail.Account account = new MojoCube.Web.Mail.Account();
        account.GetDataTypeID(3);

        bool isSend = false;

        if (account.SmtpPort == 25)
        {
            MojoCube.Api.Mail.Thread mail = new MojoCube.Api.Mail.Thread();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            mail.To = mailto;
            mail.Subject = txtTitle.Text.Trim();
            mail.Body = ReplaceMailBody(txtDescription.Text.Trim(), firstName, lastName, userName);
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = false;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            isSend = mail.Send();
        }
        else
        {
            MojoCube.Api.Mail.WebMail mail = new MojoCube.Api.Mail.WebMail();
            mail.From = account.LoginName;
            mail.DisplayName = account.DisplayName;
            mail.To = mailto;
            mail.Subject = txtTitle.Text.Trim();
            mail.Body = ReplaceMailBody(txtDescription.Text.Trim(), firstName, lastName, userName);
            mail.SmtpHost = account.SmtpHost;
            mail.Port = account.SmtpPort;
            mail.EnableSsl = true;
            mail.UserName = account.LoginName;
            mail.Password = MojoCube.Api.Text.Security.DecryptString(account.Password);
            isSend = mail.Send();
        }

        return isSend;
    }

    //替换邮件内容
    private string ReplaceMailBody(string mailbody, string firstName, string lastName, string userName)
    {
        MojoCube.Web.ReplaceText replace = new MojoCube.Web.ReplaceText();
        replace.FirstName = firstName;
        replace.LastName = lastName;
        replace.UserName = userName;
        return replace.Replace(mailbody);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mail.aspx?active=" + Request.QueryString["active"]);
    }
}