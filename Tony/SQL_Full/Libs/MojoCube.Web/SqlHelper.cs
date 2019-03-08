using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MojoCube.Web
{
    public class SqlHelper
    {
        #region  构建参数化查询

        //使用方法：
        //ArrayList parameter = new ArrayList();
        //parameter.Add(CreateParameter("@pk_AdminUserID", TextBox1.Text.Trim(), SqlDbType.Int));
        //DataTable dt = SqlQueryDS("select * from adminuser where pk_AdminUserID=@pk_AdminUserID", parameter).Tables[0];

        public static System.Data.SqlClient.SqlParameter CreateParameter(string parameterName, object value, SqlDbType dbType)
        {
            System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter(parameterName, dbType);
            parameter.Value = value;
            return parameter;
        }

        public static void SqlQuery(string strSql, ArrayList parameter)
        {
            System.Data.SqlClient.SqlParameter[] parameters = null;

            if (parameter.Count > 0)
            {
                parameters = new System.Data.SqlClient.SqlParameter[parameter.Count];
                for (int i = 0; i < parameter.Count; i++)
                {
                    parameters[i] = (System.Data.SqlClient.SqlParameter)parameter[i];
                }
            }

            SqlConnection conn = new SqlConnection(Connection.ConnString());
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Transaction = trans;
                comm.Connection = conn;
                comm.CommandText = strSql;

                if (parameters != null && parameters.Length > 0)
                {
                    foreach (SqlParameter parameterItem in parameters)
                    {
                        comm.Parameters.Add(parameterItem);
                    }
                }

                comm.ExecuteNonQuery();
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet SqlQueryDS(string strSql, ArrayList parameter)
        {
            System.Data.SqlClient.SqlParameter[] parameters = null;

            if (parameter.Count > 0)
            {
                parameters = new System.Data.SqlClient.SqlParameter[parameter.Count];
                for (int i = 0; i < parameter.Count; i++)
                {
                    parameters[i] = (System.Data.SqlClient.SqlParameter)parameter[i];
                }
            }

            SqlConnection conn = new SqlConnection(Connection.ConnString());
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                comm.CommandText = strSql;

                if (parameters != null && parameters.Length > 0)
                {
                    foreach (SqlParameter parameterItem in parameters)
                    {
                        comm.Parameters.Add(parameterItem);
                    }
                }

                da.SelectCommand = comm;
                da.Fill(ds);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        #endregion
    }
}
