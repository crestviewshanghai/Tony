using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Api.Data
{
    public class Sql
    {
        #region  ��������
        string _Connect;
        public string Connect
        {
            get { return _Connect; }
            set { _Connect = value; }
        }
        string _Server;
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        string _UserID;
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        string _Database;
        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }
        string _Error;
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        #endregion

        #region  ��ȡ��Ϣ

        /// <summary>
        /// ��ȡSql���Ӵ���Ϣ
        /// </summary>
        /// <param name="conn">Sql�����ִ����磺server=localhost;user id=sa;password=123456;database=myDB;</param>
        public void GetInfo(string conn)
        {
            _Server = cut(conn, "server=", ";");
            _UserID = cut(conn, "user id=", ";");
            _Password = cut(conn, "password=", ";");
            _Database = cut(conn, "database=", ";");
        }

        public string cut(string str, string bg, string ed)
        {
            string sub;
            sub = str.Substring(str.IndexOf(bg) + bg.Length);
            sub = sub.Substring(0, sub.IndexOf(";"));
            return sub;
        }

        #endregion

        #region  �������ݿ�

        /// <summary>
        /// �������ݿ�
        /// </summary>
        public void CreateDB()
        {
            SqlConnection conn = new SqlConnection(_Connect);
            SqlCommand cmd = new SqlCommand("CREATE DATABASE [" + _Database + "] COLLATE Chinese_PRC_CI_AS;", conn);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _Error = e.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        #endregion

        #region  �������ݿ�

        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="backupPath">�����ļ����Ŀ¼���磺C:\Web\Data\Backup\</param>
        /// <returns></returns>
        public bool BackupDB(string backupPath)
        {
            string name = _Database + DateTime.Now.ToString("yyyyMMddHHmmss");
            string procname;
            string sql;

            SqlConnection conn = new SqlConnection(_Connect);
            conn.Open();
            //ɾ���߼������豸��������ɾ�����ݵ����ݿ��ļ� 
            procname = "sp_dropdevice";
            SqlCommand sqlcmd1 = new SqlCommand(procname, conn);
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlpar = new SqlParameter();
            sqlpar = sqlcmd1.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);
            sqlpar.Direction = ParameterDirection.Input;
            sqlpar.Value = _Database;
            try//����߼��豸�����ڣ���ȥ���� 
            {
                sqlcmd1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _Error = e.Message;
            }
            //�����߼������豸 
            procname = "sp_addumpdevice";
            SqlCommand sqlcmd2 = new SqlCommand(procname, conn);
            sqlcmd2.CommandType = CommandType.StoredProcedure;
            sqlpar = sqlcmd2.Parameters.Add("@devtype", SqlDbType.VarChar, 20);
            sqlpar.Direction = ParameterDirection.Input;
            sqlpar.Value = "disk";
            sqlpar = sqlcmd2.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);//�߼��豸�� 
            sqlpar.Direction = ParameterDirection.Input;
            sqlpar.Value = _Database;
            sqlpar = sqlcmd2.Parameters.Add("@physicalname", SqlDbType.NVarChar, 260);//�����豸�� 
            sqlpar.Direction = ParameterDirection.Input;
            sqlpar.Value = backupPath + name + ".bak";
            try
            {
                int i = sqlcmd2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _Error = e.Message;
            }
            //�������ݿ⵽ָ�������ݿ��ļ�(��ȫ����) 
            sql = "BACKUP DATABASE " + _Database + " TO " + _Database + " WITH INIT";
            SqlCommand sqlcmd3 = new SqlCommand(sql, conn);
            sqlcmd3.CommandType = CommandType.Text;
            try
            {
                sqlcmd3.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _Error = e.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        #endregion

        #region  ��ԭ���ݿ�

        /// <summary>
        /// ��ԭ���ݿ�
        /// </summary>
        /// <param name="filePath">�����ļ�������·�������磺C:\Web\Data\Backup\myDB.bak</param>
        /// <returns></returns>
        public bool RestoreDB(string filePath)
        {
            SqlConnection conn = new SqlConnection(_Connect);
            //��ԭָ�������ݿ��ļ� 
            string sql = string.Format("use master ;declare @s varchar(8000);select @s=isnull(@s,'')+' kill '+rtrim(spID) from master..sysprocesses where dbid=db_id('{0}');select @s;exec(@s) ;RESTORE DATABASE {1} FROM DISK = N'{2}' with replace", _Database, _Database, filePath);
            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.CommandType = CommandType.Text;
            conn.Open();
            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                _Error = err.Message;
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        #endregion
    }
}
