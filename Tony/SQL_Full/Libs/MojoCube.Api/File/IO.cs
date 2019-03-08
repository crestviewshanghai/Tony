using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace MojoCube.Api.File
{
    public class IO
    {
        //获取文件夹或文件数据集
        //使用方法：
        //文件夹：Directory.GetDirectories(Server.MapPath("../../../Themes/"));
        //文件：  Directory.GetFiles(Server.MapPath("."), "*.rar");

        public static DataSet GetDirectoryDS(string[] files)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("FileName");     //文件名
            dt.Columns.Add("FileFullPath"); //文件所在的物理路径
            dt.Columns.Add("FileLength");   //文件大小
            dt.Columns.Add("Modified");     //修改时间
            dt.Columns.Add("FileSize");     //修改时间

            foreach (string s in files)
            {
                DataRow dr = dt.NewRow();
                dr["FileName"] = Path.GetFileName(s);
                dr["FileFullPath"] = Path.GetFullPath(s);
                dr["FileLength"] = Path.GetFullPath(s).Length.ToString();

                try
                {
                    FileInfo info = new FileInfo(Path.GetFullPath(s));
                    dr["Modified"] = info.LastWriteTime.ToString();
                    dr["FileSize"] = FormatFileSize(info.Length.ToString());
                }
                catch
                {
                    dr["Modified"] = string.Empty;
                    dr["FileSize"] = string.Empty;
                }

                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            return ds;
        }

        public static string FormatFileSize(string a)
        {
            if (a != "")
            {
                double b = Convert.ToDouble(a) / 1024;
                if (b > 1000)
                {
                    a = F2Size((b / 1024)) + " MB";

                }
                else
                {
                    a = ((int)b).ToString() + " KB";
                }
            }
            return a;
        }

        public static string F2Size(double d)
        {
            d = d * 100;
            d = (int)d;
            d = d / 100;
            return d.ToString();
        }

        //获取文件最后修改时间
        public static string GetModifiedTime(string path)
        {
            string date = "";
            FileInfo info = new FileInfo(path);
            date = info.LastWriteTime.ToString();
            return date;
        }

        //设置文件最后修改时间
        public static string SetModifiedTime(string path)
        {
            string date = "";
            FileInfo info = new FileInfo(path);
            info.LastWriteTime = DateTime.Now;
            date = info.LastWriteTime.ToString();
            return date;
        }

        //删除文件
        public static bool DeleteFile(string path)
        {
            try
            {
                System.IO.File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 解决删除目录提示：System.IO.IOException: 目录不是空的。
        /// 删除一个目录，先遍历删除其下所有文件和目录（递归）
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>是否已经删除</returns>
        public static bool DeleteDirectory(string path)
        {
            string[] strTemp;
            try
            {
                //先删除该目录下的文件
                strTemp = System.IO.Directory.GetFiles(path);
                foreach (string str in strTemp)
                {
                    System.IO.File.Delete(str);
                }
                //删除子目录，递归
                strTemp = System.IO.Directory.GetDirectories(path);
                foreach (string str in strTemp)
                {
                    DeleteDirectory(str);
                }
                //删除该目录
                System.IO.Directory.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
