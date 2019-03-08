using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_KindEditor : System.Web.UI.UserControl
{
    public string Text
    {
        get
        {
            return content1.Value;
        }
        set
        {
            content1.Value = value;
        }
    }

    public int _Height;
    public int Height
    {
        get
        {
            return _Height;
        }
        set
        {
            _Height = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        content1.Attributes.Add("style", "width:100%;height:" + _Height.ToString() + "px;visibility:hidden;");
    }
}
