using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace MojoCube.Api.Text
{
    /// <summary>
    /// 解决当head遇上runat=server之后生成HTML源代码排列混乱的问题
    /// </summary>

    public class HtmlHeadAdapter : System.Web.UI.Adapters.ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine("<head>");
            RenderChildren(writer);
            writer.Write("</head>");
        }

        protected override void OnPreRender(EventArgs e)
        {
            bool hasTitle = false;
            foreach (Control cntrl in this.Control.Controls)
            {
                if (cntrl is HtmlTitle)
                {
                    hasTitle = true;
                    break;
                }
            }
            if (!hasTitle)
            {
                HtmlTitle ht = new HtmlTitle();
                ht.Text = Page.Title;
                Control.Controls.Add(ht);
            }
            base.OnPreRender(e);
        }
    }

    public class HtmlTitleAdapter : System.Web.UI.Adapters.ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlTitle htmlTitle = (HtmlTitle)this.Control;
            //writer.Indent = 1;//控制标签开始处缩进
            writer.Write("<title>");
            writer.Write(htmlTitle.Text);
            writer.WriteLine("</title>");
        }
    }

    public class HtmlLinkAdapter : System.Web.UI.Adapters.ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            AttributeCollection attributes = ((HtmlLink)this.Control).Attributes;
            if (null != attributes && attributes.Count > 0)
            {
                writer.Write("<link");
                foreach (string key in attributes.Keys)
                {
                    writer.Write(" ");
                    writer.Write(key);
                    writer.Write("=\"");
                    if (0 == String.Compare("href", key, true, CultureInfo.InvariantCulture))
                        writer.Write(this.Control.ResolveUrl(attributes[key]));
                    else
                        writer.Write(attributes[key]);
                    writer.Write("\"");
                }
                writer.WriteLine(" />");
            }
        }
    }

    public class HtmlMetaAdapter : System.Web.UI.Adapters.ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HtmlMeta metaTag = (HtmlMeta)this.Control;
            writer.Write("<meta");
            if (!String.IsNullOrEmpty(metaTag.HttpEquiv))
            {
                writer.Write(" http-equiv=\"");
                writer.Write(metaTag.HttpEquiv);
            }

            if (!String.IsNullOrEmpty(metaTag.Name))
            {
                writer.Write(" name=\"");
                writer.Write(metaTag.Name);
            }
            writer.Write("\" content=\"");
            writer.Write(metaTag.Content);
            writer.WriteLine("\" />");
        }
    }
}
