using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web;

namespace MojoCube.Api.Text
{
    public class Content
    {
        /// <summary>
        /// Ssubstring截取HTML字符
        /// </summary>
        /// <param name="content">要截取的内容</param>
        /// <param name="length">要截取的长度</param>
        /// <param name="StripHTML">是否拿掉HTML</param>
        public static string GetContentSummary(string content, int length, bool StripHTML)
        {
            if (string.IsNullOrEmpty(content) || length == 0)
                return "";
            if (StripHTML)
            {
                System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex("<[^>]*>");
                content = re.Replace(content, "");
                content = content.Replace("　", "").Replace(" ", "").Replace("&nbsp;", "");
                if (content.Length <= length)
                    return content;
                else
                    return content.Substring(0, length) + "...";
            }
            else
            {
                if (content.Length <= length)
                    return content;

                int pos = 0, npos = 0, size = 0;
                bool firststop = false, notr = false, noli = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (true)
                {
                    if (pos >= content.Length)
                        break;
                    string cur = content.Substring(pos, 1);
                    if (cur == "<")
                    {
                        string next = content.Substring(pos + 1, 3).ToLower();
                        if (next.IndexOf("p") == 0 && next.IndexOf("pre") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                        }
                        else if (next.IndexOf("/p") == 0 && next.IndexOf("/pr") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br />");
                        }
                        else if (next.IndexOf("br") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br />");
                        }
                        else if (next.IndexOf("img") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                                size += npos - pos + 1;
                            }
                        }
                        else if (next.IndexOf("li") == 0 || next.IndexOf("/li") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!noli && next.IndexOf("/li") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    noli = true;
                                }
                            }
                        }
                        else if (next.IndexOf("tr") == 0 || next.IndexOf("/tr") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr && next.IndexOf("/tr") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    notr = true;
                                }
                            }
                        }
                        else if (next.IndexOf("td") == 0 || next.IndexOf("/td") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                }
                            }
                        }
                        else
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        if (npos <= pos)
                            npos = pos + 1;
                        pos = npos;
                    }
                    else
                    {
                        if (size < length)
                        {
                            sb.Append(cur);
                            size++;
                        }
                        else
                        {
                            if (!firststop)
                            {
                                sb.Append("...");
                                firststop = true;
                            }
                        }
                        pos++;
                    }

                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 内容分页：文章太长，可以用该方法对内容进行分页，分页标记自定义，例如[pager/](尖括号也可以)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="count">分页字数，可以根据你的内容页面再设置，一般不少于200字</param>
        /// <returns>分页数组</returns>
        public static string GetPageContent(string content, int count)
        {
            int page = 1;//初始页面代码，一打开显示第一页内容
            string mypage;
            mypage = HttpContext.Current.Request.QueryString["page"];
            if (mypage != null) //第一次的时候没有加载分页因此得到的结果为NULL,因此要判断一下
            {
                try
                {
                    page = Convert.ToInt32(mypage);
                }
                catch
                {
                    page = 1;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='pageContent'>");
            string[] strContent = null;
            int fileindex = 0;
            string[] splitfile = new string[count];

            while (content.Length > count && fileindex < count - 1)
            {
                if (content.IndexOf("<hr class=\"page-break\" />", count) < 0) break;

                splitfile[fileindex] = content.Substring(0, content.IndexOf("<hr class=\"page-break\" />", count));
                content = content.Remove(0, splitfile[fileindex].Length);
                fileindex++;
            }
            splitfile[fileindex] = content;
            strContent = splitfile;

            if (strContent[page - 1] != null)
            {
                sb.Append("<div>" + strContent[page - 1].ToString() + "</div>");
            }
            else
            {
                sb.Append("<div>None</div>");
            }

            string adpager = string.Empty;
            string sPath = HttpContext.Current.Request.Path;

            int npage = 0;
            string focusCss = string.Empty;
            for (int i = 0; i < strContent.Length; i++)
            {
                if (strContent[i] != null)
                {
                    npage = i + 1;
                    if (npage == page)
                    {
                        focusCss = "class='focus'";
                    }
                    else
                    {
                        focusCss = "";
                    }
                    adpager += "<a href=" + sPath + "?page=" + npage + " onfocus=\"this.blur();\" " + focusCss + "><span>" + npage + "</span></a>";
                }
            }
            if (npage > 1)
            {
                sb.Append("<div class='pager'>" + adpager.ToString() + "</div>");
            }
            sb.Append("</div>");

            return sb.ToString();
        }
    }
}
