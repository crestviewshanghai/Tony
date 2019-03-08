using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace MojoCube.Api.Text
{
    public class Function
    {
        public static string SubString(string text, int textLong)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + "...";
            }
            return text;
        }

        public static string SubString(string text, int textLong, string format)
        {
            if (text.Length > textLong)
            {
                text = text.Substring(0, textLong) + format;
            }
            return text;
        }

        public static string DateTimeString(bool IsDate)
        {
            if (IsDate)
            {
                Random r = new Random();
                return (DateTime.Now.ToString("yyyyMMddHHmmssffff") + r.Next(1000, 9999).ToString());
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }

        //匿名处理
        public static string GetAnonymous(string name)
        {
            if (name.Length > 1)
            {
                name = name.Replace(name.Substring(1, 1), "*");
            }
            return name;
        }

        /// <summary>
        /// 将UrlEncode转换成大写输出
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <returns></returns>
        public static string UpperUrlEncode(string s)
        {
            char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }

        public static string ToHtmlString(string content)
        {
            content = content.Replace("\n", "<br />");
            return content;
        }
    }
}
