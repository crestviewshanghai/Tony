using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Web;

namespace MojoCube.Api.Mail
{
    public class Thread
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
        public MailMessage myMail;
        public SmtpClient smtp;
        public System.Threading.Thread thread;
        #endregion

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            try
            {
                myMail = new MailMessage();
                myMail.From = new MailAddress(_From, _DisplayName, System.Text.Encoding.UTF8);
                myMail.To.Add(new MailAddress(_To));
                if (_CC != null)
                {
                    myMail.CC.Add(new MailAddress(_CC));
                }
                if (_Bcc != null)
                {
                    myMail.Bcc.Add(new MailAddress(_Bcc));
                }
                myMail.Subject = _Subject;
                myMail.Body = _Body;
                myMail.IsBodyHtml = true;
                myMail.Priority = MailPriority.Normal;

                smtp = new SmtpClient(_SmtpHost);
                smtp.Port = _Port;
                smtp.EnableSsl = _EnableSsl;
                smtp.Credentials = new System.Net.NetworkCredential(_UserName, _Password);

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
                smtp.Send(myMail);
            }
            catch
            {
                thread.Abort();
            }
        }
    }
}
