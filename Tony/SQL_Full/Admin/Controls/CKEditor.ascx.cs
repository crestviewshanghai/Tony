using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Controls_CKEditor : System.Web.UI.UserControl
{
    public string Text
    {
        get
        {
            return CKEditor.Text;
        }
        set
        {
            CKEditor.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}