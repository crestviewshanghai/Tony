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

public partial class Dev_StringBuilder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string s1 = TextBox1.Text.Trim();
        s1 = s1.Replace("\"", @"\" + "\"").Replace("\n", "|");

        string[] s2 = s1.Split('|');

        string s3 = "StringBuilder sb = new StringBuilder();\n";

        for (int i = 0; i < s2.Length; i++)
        {
            if (s2[i].Trim().Length > 0)
            {
                s3 += "sb.Append(\"" + s2[i].Trim() + "\");\n";
            }
        }


        TextBox2.Text = s3;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.Response.Write("<script>window.location.href='StringBuilder.aspx'</script>");
    }
}
