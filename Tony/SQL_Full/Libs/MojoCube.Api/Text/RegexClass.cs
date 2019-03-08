using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web;

namespace MojoCube.Api.Text
{
    /// <summary>
    /// ������ʽ��һЩ������
    /// </summary>
    public class RegexClass
    {
        //��ȡ����Default.aspx��ҳ���ļ���
        public static string GetUrlFileName()
        {
            string url = string.Empty;
            if (HttpContext.Current != null)
            {
                url = HttpContext.Current.Request.Path.ToString();
            }
            Regex reg = new Regex(@"\w*\.\w*");
            return reg.Match(url).Value.ToString();
        }
        //��ȡ����Default��ҳ����ļ���
        public static string GetUrlShortFileName()
        {
            string url = string.Empty;
            if (HttpContext.Current != null)
            {
                url = HttpContext.Current.Request.Path.ToString();
            }
            Regex reg = new Regex(@"([\w-]+\.)+[\w-]+(/[\w-\./?%=]*)?");
            url = reg.Match(url).Value.ToString().Split('.')[0];
            return url;
        }

        public static string GetUrlShortFileName(string url)
        {
            Regex reg = new Regex(@"([\w-]+\.)+[\w-]+(/[\w-\./?%=]*)?");
            url = reg.Match(url).Value.ToString().Split('.')[0];
            return url;
        }

        //�ж��Ƿ�Ϊ������,���ǵĻ�����0
        public static string ChkInt(string value)
        {
            if (value != null)
            {
                string s = "^\\d+$";
                Regex reg = new Regex(s);
                Match mch = reg.Match(value);

                if (mch.Success)
                {
                    return value;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
    }
}
