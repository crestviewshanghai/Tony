using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace MojoCube.Api.File
{
    public class IO
    {
        //��ȡ�ļ��л��ļ����ݼ�
        //ʹ�÷�����
        //�ļ��У�Directory.GetDirectories(Server.MapPath("../../../Themes/"));
        //�ļ���  Directory.GetFiles(Server.MapPath("."), "*.rar");

        public static DataSet GetDirectoryDS(string[] files)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("FileName");     //�ļ���
            dt.Columns.Add("FileFullPath"); //�ļ����ڵ�����·��
            dt.Columns.Add("FileLength");   //�ļ���С
            dt.Columns.Add("Modified");     //�޸�ʱ��
            dt.Columns.Add("FileSize");     //�޸�ʱ��

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

        //��ȡ�ļ�����޸�ʱ��
        public static string GetModifiedTime(string path)
        {
            string date = "";
            FileInfo info = new FileInfo(path);
            date = info.LastWriteTime.ToString();
            return date;
        }

        //�����ļ�����޸�ʱ��
        public static string SetModifiedTime(string path)
        {
            string date = "";
            FileInfo info = new FileInfo(path);
            info.LastWriteTime = DateTime.Now;
            date = info.LastWriteTime.ToString();
            return date;
        }

        //ɾ���ļ�
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
        /// ���ɾ��Ŀ¼��ʾ��System.IO.IOException: Ŀ¼���ǿյġ�
        /// ɾ��һ��Ŀ¼���ȱ���ɾ�����������ļ���Ŀ¼���ݹ飩
        /// </summary>
        /// <param name="path">·��</param>
        /// <returns>�Ƿ��Ѿ�ɾ��</returns>
        public static bool DeleteDirectory(string path)
        {
            string[] strTemp;
            try
            {
                //��ɾ����Ŀ¼�µ��ļ�
                strTemp = System.IO.Directory.GetFiles(path);
                foreach (string str in strTemp)
                {
                    System.IO.File.Delete(str);
                }
                //ɾ����Ŀ¼���ݹ�
                strTemp = System.IO.Directory.GetDirectories(path);
                foreach (string str in strTemp)
                {
                    DeleteDirectory(str);
                }
                //ɾ����Ŀ¼
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
