using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MojoCube.Api.Http
{
    public class Cookies
    {
        public static void Create(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
            HttpContext.Current.Response.Cookies[key].Value = HttpContext.Current.Session[key].ToString();
            HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddYears(1);
        }

        public static string GetValue(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
