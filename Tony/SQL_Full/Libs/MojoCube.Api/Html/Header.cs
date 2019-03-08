using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MojoCube.Api.Html
{
    /// <summary>
    /// 动态添加head的标签
    /// </summary>
    public class Header
    {
        public Page _page;

        public Header(Page page)
        {
            _page = page;
        }

        #region  动态添加Literal
        public void AddLiteral(string Literal)
        {
            Literal li = new Literal();
            li.Text = Literal + "\n";
            _page.Header.Controls.Add(li);
        }
        #endregion

        #region  动态添加Meta信息
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

        #region  动态添加CSS样式
        public void AddCSS(string url)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("href", url);
            _page.Header.Controls.Add(link);
        }
        #endregion

        #region  动态添加JS
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
