using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;

namespace MojoCube.Web
{
    public class Connection
    {
        public static string ConnString()
        {
            string connstring = ConfigurationManager.AppSettings["Conn"];
            return (connstring);
        }
    }
}
