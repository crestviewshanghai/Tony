using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

public partial class DrawQR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["data"] != null)
        {
            BarCode.CreateQR code = new BarCode.CreateQR();
            code.Data = Request.QueryString["data"];
            code.Scale = 3;
            code.Version = 6;
            Bitmap image = code.GetBitmap();
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);//JPG、GIF、PNG等均可

            Response.ClearContent();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
        }
    }
}