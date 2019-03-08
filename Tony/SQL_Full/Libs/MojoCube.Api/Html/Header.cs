using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MojoCube.Api.Html
{
    /// <summary>
    /// ��̬���head�ı�ǩ
    /// </summary>
    public class Header
    {
        public Page _page;

        public Header(Page page)
        {
            _page = page;
        }

        #region  ��̬���Literal
        public void AddLiteral(string Literal)
        {
            Literal li = new Literal();
            li.Text = Literal + "\n";
            _page.Header.Controls.Add(li);
        }
        #endregion

        #region  ��̬���Meta��Ϣ
        public void AddMeta(string name, string content)
        {
            HtmlMeta meta = new HtmlMeta();
            HtmlHead head = (HtmlHead)_page.Header;
            meta.Name = name;
            meta.Content = content;
            head.Controls.Add(meta);
        }

        public void AddMeta(string type, string key, string content)
        {
            HtmlMeta meta = new HtmlMeta();
            HtmlHead head = (HtmlHead)_page.Header;
            switch (type.ToLower())
            {
                case "name":
                    meta.Name = key;
                    break;
                case "http-equiv":
                    meta.HttpEquiv = key;
                    break;
            }
            meta.Content = content;
            head.Controls.Add(meta);
        }
        #endregion

        #region  ��̬���CSS��ʽ
        public void AddCSS(string url)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("href", url);
            _page.Header.Controls.Add(link);
        }
        #endregion

        #region  ��̬���JS
        public void AddJS(string url)
        {
            Literal li = new Literal();
            li.Text = "<script language=\"javascript\" src=\"" + url + "\" type=\"text/javascript\"></script>\n";
            _page.Header.Controls.Add(li);
        }

        public void AddJS(string type, string script)
        {
            HtmlGenericControl include = new HtmlGenericControl("script");
            switch (type)
            {
                case "javascript":
                    include.Attributes.Add("type", "text/javascript");
                    break;
                default:
                    include.Attributes.Add("type", "text/javascript");
                    break;
            }
            include.InnerHtml = script;
            _page.Header.Controls.Add(include);
        }
        #endregion
    }
}
