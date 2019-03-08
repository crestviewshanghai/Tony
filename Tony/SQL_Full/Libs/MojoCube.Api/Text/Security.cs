using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;

namespace MojoCube.Api.Text
{
    public class Security
    {
        public static string sKey = "^$@%#!*&";

        /// <summary>
        /// ¼ÓÃÜ×Ö·û´®
        /// </summary>
        public static string EncryptString(string JiaMiString)
        {
            string encodestr = "";
            try
            {
                JiaMiString = sKey + JiaMiString;
                byte[] bytes = System.Text.Encoding.GetEncoding(0).GetBytes(JiaMiString);

                encodestr = Convert.ToBase64String(bytes);
            }
            catch
            {
                encodestr = JiaMiString;
            }
            return encodestr;
        }

        /// <summary>
        /// ½âÃÜ×Ö·û´®
        /// </summary>
        public static string DecryptString(string JieMiString)
        {
            string decodestr = "";
            try
            {
                byte[] bytes = Convert.FromBase64String(JieMiString);
                decodestr = System.Text.Encoding.GetEncoding(0).GetString(bytes);
                decodestr = decodestr.Replace(sKey, "");
            }
            catch
            {
                decodestr = "0";
            }
            return decodestr;
        }
    }
}
