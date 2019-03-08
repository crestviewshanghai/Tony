using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MojoCube.Api.File
{
    public class Function
    {
        //判断文件格式，返回页面头类型ContentType
        public static string GetContentType(string Path)
        {
            string ImgType = string.Empty;
            if (Path.LastIndexOf('.') > 0)
            {
                ImgType = Path.Substring(Path.LastIndexOf('.'));
            }
            string ContentType = string.Empty;

            switch (ImgType.ToLower())
            {
                case ".jpg":
                    {
                        ContentType = "image/jpeg";
                    } break;
                case ".gif":
                    {
                        ContentType = "image/gif";
                    } break;
                case ".png":
                    {
                        ContentType = "image/png";
                    } break;
                case ".bmp":
                    {
                        ContentType = "image/bmp";
                    } break;
                case ".wmv":
                    {
                        ContentType = "application/octet-stream";
                    } break;
                case ".asf":
                    {
                        ContentType = "application/octet-stream";
                    } break;
                case ".3gp":
                    {
                        ContentType = "application/octet-stream";
                    } break;
                case ".mpg":
                    {
                        ContentType = "application/octet-stream";
                    } break;
                case ".rar":
                    {
                        ContentType = "application/x-msdownload";
                    } break;
                case ".pdf":
                    {
                        ContentType = "application/pdf";
                    } break;
                case ".zip":
                    {
                        ContentType = "application/zip";
                    } break;
                default:
                    {
                        ContentType = "*/*";
                    } break;
            }

            return ContentType;
        }

        //获取相对路径
        public static string GetRelativePath(string path)
        {
            path = HttpContext.Current.Request.ApplicationPath + "/" + path;
            path = path.Replace("///", "/").Replace("//", "/");

            return path;
        }

        //获取绝对路径
        public static string GetAbsolutePath(string path)
        {
            path = HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + "/" + HttpContext.Current.Request.ApplicationPath + path;
            path = path.Replace("///", "/").Replace("//", "/");
            path = "http://" + path;
            return path;
        }

    }
}
