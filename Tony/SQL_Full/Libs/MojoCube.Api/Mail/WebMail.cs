using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;

namespace MojoCube.Api.Mail
{
    public class WebMail
    {
        #region  公共属性
        string _From;
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        string _To;
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }
        string _CC;
        public string CC
        {
            get { return _CC; }
            set { _CC = value; }
        }
        string _Bcc;
        public string Bcc
        {
            get { return _Bcc; }
            set { _Bcc = value; }
        }
        string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        string _Body;
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        string _SmtpHost;
        public string SmtpHost
        {
            get { return _SmtpHost; }
            set { _SmtpHost = value; }
        }
        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        int _Port;
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        bool _EnableSsl;
        public bool EnableSsl
        {
            get { return _EnableSsl; }
            set { _EnableSsl = value; }
        }
        System.Web.Mail.MailMessage mail;
        public System.Threading.Thread thread;
        #endregion

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            mail = new System.Web.Mail.MailMessage();
            try
            {
                mail.To = _To;
                mail.Cc = _CC;
                mail.From = _From;
                mail.Subject = _Subject;
                mail.BodyFormat = System.Web.Mail.MailFormat.Html;
                mail.Body = _Body;

                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //身份验证
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", mail.From); //邮箱登录账号，这里跟前面的发送账号一样就行
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", _Password); //这个密码要注意：如果是一般账号，要用授权码；企业账号用登录密码
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", _Port);//端口
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");//SSL加密
                System.Web.Mail.SmtpMail.SmtpServer = _SmtpHost;    //企业账号用smtp.exmail.qq.com
                

                thread = new System.Threading.Thread(SendThread);
                thread.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 新开线程发送邮件，可减少等待时间
        /// </summary>
        public void SendThread()
        {
            try
            {
                System.Web.Mail.SmtpMail.Send(mail);
            }
            catch
            {
                thread.Abort();
            }
        }
    }
}
