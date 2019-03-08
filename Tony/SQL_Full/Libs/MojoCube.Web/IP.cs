using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MojoCube.Web
{
    public class IP
    {
        /// <summary>
        /// 获取IP地址
        /// </summary>
        /// <returns></returns>
        public static string Get()
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            return ip;
        }

        /// <summary>
        /// 列出受限制IP地址，判断是否限制IP
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns></returns>
        public static bool IsBound(string language)
        {
            bool bound = false;
            if (bool.Parse(Site.Cache.GetIsBoundIP(language)))
            {
                string ip = IP.Get();
                string boundIP = Site.Cache.GetBoundIP(language);
                string[] list = boundIP.Split('|');
                if (list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (ip == list[i])
                        {
                            bound = true;
                        }
                    }
                }
            }
            return bound;
        }
    }
}
