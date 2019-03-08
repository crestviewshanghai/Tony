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
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class Files : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetFile();
        }
    }

    private void GetFile()
    {
        try
        {
            if (Request.QueryString["image"] != null)
            {
                string sPath = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["image"]);

                string path = "";

                if (sPath.Length > 0)
                {
                    if (sPath == "no_image.jpg")
                    {
                        path = Server.MapPath("~/Images/no_image.jpg");
                    }
                    else
                    {
                        path = Server.MapPath("~/Files/" + sPath);
                    }
                }
                else
                {
                    path = Server.MapPath("~/Images/blank.png");
                }

                ///////////////////////////////////////////////把图片文档缓存起来（开始）///////////////////////////////////////////////////////
                //获取实体的日期和时间
                DateTime input = System.IO.File.GetLastWriteTime(path);
                // 格式化日期时间，去掉毫秒和微秒：
                DateTime dt = new DateTime(input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second);
                // 获取浏览器发出的日期和时间
                string s = Request.Headers["If-Modified-Since"];

                // 判断是否修改过
                DateTime TempDate;
                if (((s != null) && DateTime.TryParse(s, out TempDate)) && (TempDate >= dt))
                {
                    // 没有修改过，使用浏览器缓存
                    Response.StatusCode = 0x130;
                }
                // 修改过，在Http头增加浏览器缓存控制
                else if (dt.ToUniversalTime() < DateTime.UtcNow)
                {
                    HttpCachePolicy cache = Response.Cache;
                    cache.SetCacheability(HttpCacheability.Public);
                    cache.SetLastModified(dt);
                }
                ///////////////////////////////////////////////把图片文档缓存起来（结束）///////////////////////////////////////////////////////

                byte[] bFile = null;

                System.Drawing.Image img = System.Drawing.Image.FromFile(path);

                int width = img.Width;
                int height = img.Height;

                //按比例缩图
                if (Request.QueryString["w"] != null && Request.QueryString["h"] != null && sPath.Length > 0)
                {
                    if (width > height && width > int.Parse(Request.QueryString["w"]))
                    {
                        width = int.Parse(Request.QueryString["w"]);
                        height = img.Height * width / img.Width;
                    }
                    else if (height > width && height > int.Parse(Request.QueryString["h"]))
                    {
                        height = int.Parse(Request.QueryString["h"]);
                        width = img.Width * height / img.Height;
                    }
                    else if (width == height)
                    {
                        height = int.Parse(Request.QueryString["h"]);
                        width = img.Width * height / img.Height;
                    }
                }

                System.Drawing.Image bitmap = null;

                //缩图并裁剪
                if (Request.QueryString["cut"] != null)
                {
                    System.IO.FileInfo myFile = new System.IO.FileInfo(path);
                    byte[] bytelist = CutPhoto(myFile, Request.QueryString["cut"]);
                    MemoryStream ms1 = new MemoryStream(bytelist);
                    bitmap = (Bitmap)System.Drawing.Image.FromStream(ms1);
                    ms1.Close(); 
                }
                else
                {
                    bitmap = new Bitmap(width, height);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, new System.Drawing.Rectangle(0, 0, width, height));
                }

                //是否显示水印
                MojoCube.Web.Site.Config config = new MojoCube.Web.Site.Config();
                config.GetData(1, MojoCube.Api.UI.Language.GetLanguage());

                if (width == 582)
                {
                    config.WM_IsShow = false;
                }

                if (config.WM_IsShow && width > config.WM_Show_W || config.WM_IsShow && height > config.WM_Show_H)
                {
                    int WM_Bottom = config.WM_Bottom;
                    int WM_Right = config.WM_Right;
                    int WM_Alpha = config.WM_Alpha;
                    int WM_Red = config.WM_Red;
                    int WM_Green = config.WM_Green;
                    int WM_Blue = config.WM_Blue;
                    int WM_Rotate = config.WM_Rotate;
                    int WM_Size = config.WM_Size;

                    //文字模式
                    if (!config.WM_Mode)
                    {
                        string WM_Text = config.WM_Text;
                        string WM_Font = config.WM_Font;
                        int WM_FontSize = config.WM_FontSize;

                        Graphics grPhoto = Graphics.FromImage(bitmap);

                        //消除锯齿
                        grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                        grPhoto.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                        Font crFont = new Font(WM_Font, WM_FontSize, FontStyle.Bold);
                        SizeF crSize = grPhoto.MeasureString(WM_Text, crFont);

                        int iRotate = WM_Rotate;

                        float pCenterX = 0;
                        float pCenterY = 0;
                        //设置字体在图片中的位置
                        float yPosFromBottom = 0;
                        float xCenterOfImg = 0;
                        switch (WM_Size)
                        {
                            case 0: //center
                                yPosFromBottom = height / 2 - (crSize.Height / 2);
                                pCenterX = xCenterOfImg = width / 2;
                                pCenterY = height / 2;
                                break;
                            case 1: //top left
                                pCenterY = yPosFromBottom = crSize.Height / 2 - WM_Bottom;
                                pCenterX = xCenterOfImg = crSize.Width / 2 + WM_Right;
                                break;
                            case 2: //top right
                                pCenterY = yPosFromBottom = crSize.Height / 2 - WM_Bottom;
                                pCenterX = xCenterOfImg = width - crSize.Width / 2 - WM_Right;
                                break;
                            case 3: //bottom left
                                pCenterY = yPosFromBottom = height - WM_Bottom - (crSize.Height);
                                pCenterX = xCenterOfImg = crSize.Width / 2 + WM_Right;
                                break;
                            case 4: //bottom right
                                pCenterY = yPosFromBottom = height - WM_Bottom - (crSize.Height);
                                pCenterX = xCenterOfImg = width - WM_Right - (crSize.Width / 2);
                                break;
                        }

                        //设置字体居中
                        StringFormat StrFormat = new StringFormat();
                        StrFormat.Alignment = StringAlignment.Center;

                        //设置绘制文本的颜色和纹理 (Alpha=153)
                        SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(WM_Alpha, WM_Red, WM_Green, WM_Blue));

                        //旋转水印
                        PointF pCenter = new PointF(pCenterX, pCenterY);
                        grPhoto.TranslateTransform(pCenter.X, pCenter.Y);
                        grPhoto.RotateTransform(iRotate);
                        grPhoto.TranslateTransform(-pCenter.X, -pCenter.Y);

                        //将版权信息绘制到图象上
                        grPhoto.DrawString(WM_Text, crFont, semiTransBrush2, new PointF(xCenterOfImg, yPosFromBottom), StrFormat);
                    }
                    //图片模式
                    else
                    {
                        int iMarkRightSpace = 0;
                        int iMarkButtomSpace = 0;
                        //创建一个需要填充水银的Image对象
                        System.Drawing.Image imgWatermark = new Bitmap(Server.MapPath("~/Files/" + config.WM_ImagePath));
                        int iMarkWidth = imgWatermark.Width;
                        int iMarkmHeight = imgWatermark.Height;

                        Graphics grWatermark = null;

                        //将位图bmWatermark加载到Graphics对象
                        grWatermark = Graphics.FromImage(bitmap);
                        ImageAttributes imageAttributes = new ImageAttributes();

                        ColorMap colorMap = new ColorMap();

                        colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                        colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

                        ColorMap[] remapTable = { colorMap };

                        imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

                        float[][] colorMatrixElements = { 
                        new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f}, 
                        new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f}, 
                        new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f}, 
                        new float[] {0.0f, 0.0f, 0.0f, (float)((WM_Alpha/50)*20)/100f, 0.0f},    //设置透明度
                        new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f}};
                        ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

                        imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        iMarkRightSpace = width - iMarkWidth - WM_Right;
                        iMarkButtomSpace = height - iMarkmHeight - WM_Bottom;

                        grWatermark.DrawImage(imgWatermark, new Rectangle(iMarkRightSpace, iMarkButtomSpace, iMarkWidth, iMarkmHeight), 0, 0, iMarkWidth, iMarkmHeight, GraphicsUnit.Pixel, imageAttributes);
                    }
                }

                MemoryStream stream = new MemoryStream();

                string fileType = MojoCube.Api.File.Function.GetContentType(sPath);

                if (fileType == "image/png")
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                    bitmap.Save(stream, info[1], ep);
                }

                bFile = stream.ToArray();

                Response.Clear();
                Response.ContentType = fileType;
                string fileName = Server.HtmlEncode(sPath.Substring(sPath.LastIndexOf('/') + 1));
                Response.AddHeader("Content-Disposition", "inline;filename=\"" + fileName + "\"");

                Response.Charset = "";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.AddHeader("Connection", "close");
                Response.BinaryWrite(bFile);

                //Response.Clear();
                bitmap.Dispose();
                stream.Dispose();
                img.Dispose();
            }
            else if (Request.QueryString["file"] != null)
            {
                string sPath = MojoCube.Api.Text.Security.DecryptString(Request.QueryString["file"]);
                byte[] bFile = null;

                System.IO.FileInfo File = new System.IO.FileInfo(Server.MapPath("~/Files/" + sPath));
                System.IO.FileStream FS = File.OpenRead();
                System.IO.BinaryReader BR = new System.IO.BinaryReader(FS);
                bFile = BR.ReadBytes((int)FS.Length);
                FS.Dispose();
                BR.Close();

                Response.Clear();
                Response.ContentType = MojoCube.Api.File.Function.GetContentType(sPath);
                string fileName = Server.HtmlEncode(sPath.Substring(sPath.LastIndexOf('/') + 1));
                Response.AddHeader("Content-Disposition", "inline;filename=\"" + fileName + "\"");

                Response.Charset = "";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.AddHeader("Connection", "close");
                Response.BinaryWrite(bFile);
            }
        }
        catch
        {
            Response.Write("Error!");
        }
    }

    private int cutWidth = 0;
    private int cutHeight = 0;
    private void FormatCutSize(string text)
    {
        string[] size = text.Split(',');
        if (size.Length > 1)
        {
            cutWidth = int.Parse(size[0].ToString());
            cutHeight = int.Parse(size[1].ToString());
        }
        else
        {
            cutWidth = cutHeight = int.Parse(size[0].ToString());
        }
    }

    #region  等比例切图

    public byte[] CutPhoto(System.IO.FileInfo file, string text)
    {
        byte[] Byte = null;
        int cutWidth = 0;
        int cutHeight = 0;

        string[] size = text.Split(',');
        if (size.Length > 1)
        {
            cutWidth = int.Parse(size[0].ToString());
            cutHeight = int.Parse(size[1].ToString());
        }
        else
        {
            cutWidth = cutHeight = int.Parse(size[0].ToString());
        }

        int side = cutWidth;

        //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
        System.Drawing.Image initImage = System.Drawing.Image.FromFile(file.FullName);

        //原图宽高均小于模版，不作处理，直接保存
        if (initImage.Width <= side && initImage.Height <= side)
        {
            FileStream stream = file.OpenRead();
            Byte = new Byte[stream.Length];
            //从流中读取字节块并将该数据写入给定缓冲区buffer中
            stream.Read(Byte, 0, Convert.ToInt32(stream.Length));

            return Byte;
        }
        else
        {
            //原始图片的宽、高
            int initWidth = initImage.Width;
            int initHeight = initImage.Height;

            //非正方型先裁剪为正方型
            if (initWidth != initHeight)
            {
                //截图对象
                System.Drawing.Image pickedImage = null;
                System.Drawing.Graphics pickedG = null;

                //宽大于高的横图
                if (initWidth > initHeight)
                {
                    //对象实例化
                    pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                    pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                    //设置质量
                    pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //定位
                    Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                    Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                    //画图
                    pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                    //重置宽
                    initWidth = initHeight;
                }
                //高大于宽的竖图
                else
                {
                    //对象实例化
                    pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                    pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                    //设置质量
                    pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //定位
                    Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                    Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                    //画图
                    pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                    //重置高
                    initHeight = initWidth;
                }

                initImage.Dispose();

                //将截图对象赋给原图
                initImage = (System.Drawing.Image)pickedImage.Clone();

                //释放截图资源
                pickedG.Dispose();
                pickedImage.Dispose();
            }

            //缩略图对象
            System.Drawing.Image resultImage = new System.Drawing.Bitmap(side, side);
            System.Drawing.Graphics resultG = System.Drawing.Graphics.FromImage(resultImage);
            //设置质量
            resultG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            resultG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //用指定背景色清空画布
            resultG.Clear(Color.White);
            //绘制缩略图
            resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);

            //关键质量控制
            //获取系统编码类型数组,包含了jpeg,bmp,png,gif,tiff
            ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo i in icis)
            {
                if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                {
                    ici = i;
                }
            }
            EncoderParameters ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);

            System.IO.MemoryStream FS = new System.IO.MemoryStream();
            FS.Position = 0;

            //保存缩略图
            resultImage.Save(FS, ici, ep);

            Byte = FS.ToArray();
            FS.Dispose();

            resultG.Dispose();
            resultImage.Dispose();
            initImage.Dispose();

            return Byte;
        }
    }

    #endregion
}
