using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI;

namespace MojoCube.Api.Html
{
    public class AspxToHtml
    {
        /// <summary>
        /// 将Aspx文件输出成Html文件
        /// </summary>
        /// <param name="Url">原始文件（如Index.aspx）需虚拟路径</param>
        /// <param name="Path">输出路径（如Server.MapPath("~/")）</param>
        /// <param name="FileName">输出文件（如index.html）</param>
        /// <returns></returns>
        public static bool ExecAspxToHtml(string Url, string Path, string FileName)
        {
            try
            {
                StringWriter strHTML = new StringWriter();
                System.Web.UI.Page myPage = new Page();
                myPage.Server.Execute(Url, strHTML);
                StreamWriter sw = new StreamWriter(Path + FileName, true, System.Text.Encoding.GetEncoding("utf-8"));
                sw.Write(strHTML.ToString());
                strHTML.Close();
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
