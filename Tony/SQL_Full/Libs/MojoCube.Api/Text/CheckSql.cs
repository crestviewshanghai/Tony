using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MojoCube.Api.Text
{
    /// <summary>
    /// 该类为防止Sql字串注入的一些过滤方法
    /// </summary>
    public class CheckSql
    {
        #region  过滤HTML
        public static string NoHTML(string Htmlstring)
        {
            if (Htmlstring == null)
            {
                return "0";
            }
            else
            {

                //删除脚本
                Htmlstring = Htmlstring.Replace("\r\n", "");
                Htmlstring = Regex.Replace(Htmlstring, @"<script.*?</script>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<style.*?</style>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<.*?>", "", RegexOptions.IgnoreCase);
                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("'", "");
                Htmlstring = Htmlstring.Replace("--", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                //删除与数据库相关的词
                Htmlstring = Regex.Replace(Htmlstring, "select", "s", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "i", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "d", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "c", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "d", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "t", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "a", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "m", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "c", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "x", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "e", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "n", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "a", RegexOptions.IgnoreCase);

                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

                if (Htmlstring == string.Empty)
                {
                    Htmlstring = "0";
                }

                return Htmlstring;

            }
        }
        #endregion

        public static string Format(string text)
        {
            text = text.Replace("'", "''");
            return text;
        }

        public static string Format(string text, string exception)
        {
            if (text != exception)
            {
                text = text.Replace("'", "''");
            }
            else
            {
                text = string.Empty;
            }
            return text;
        }

        public static string Filter(string text)
        {
            if ((text == null) || (text == ""))
            {
                return null;
            }
            string text1 = text.ToLower();
            string output = text;
            string pattern = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(text1, Regex.Escape(pattern), RegexOptions.IgnoreCase).Success)
            {
                output = output.Replace(text, "''");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }
    }
}
