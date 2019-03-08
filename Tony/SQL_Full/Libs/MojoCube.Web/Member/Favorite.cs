using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Member
{
    public class Favorite
    {
        #region 公共属性
        int _pk_Favorite;
        public int pk_Favorite
        {
            get { return _pk_Favorite; }
            set { _pk_Favorite = value; }
        }
        int _fk_Member;
        public int fk_Member
        {
            get { return _fk_Member; }
            set { _fk_Member = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        int _fk_ID;
        public int fk_ID
        {
            get { return _fk_ID; }
            set { _fk_ID = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        string _Url;
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="id">ID</param>
        public void GetData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Member_Favorite where pk_Favorite=@pk_Favorite";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Favorite", SqlDbType.Int));
                comm.Parameters["@pk_Favorite"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Favorite = Convert.ToInt32(dr["pk_Favorite"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _fk_ID = Convert.ToInt32(dr["fk_ID"].ToString());
                    _Title = dr["Title"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Url = dr["Url"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 新增数据，返回ID
        /// </summary>
        /// <returns></returns>
        public int InsertData()
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "insert into Member_Favorite(fk_Member,TypeID,fk_ID,Title,Remark,Url,CreateDate) values (@fk_Member,@TypeID,@fk_ID,@Title,@Remark,@Url,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.ExecuteNonQuery();
                comm.CommandText = "select @@identity";
                return Convert.ToInt32(comm.ExecuteScalar());
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id">ID</param>
        public void UpdateData(int id)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "update Member_Favorite set fk_Member=@fk_Member,TypeID=@TypeID,fk_ID=@fk_ID,Title=@Title,Remark=@Remark,Url=@Url,CreateDate=@CreateDate where pk_Favorite=@pk_Favorite";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 200));
                comm.Parameters["@Url"].Value = _Url;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Favorite", SqlDbType.Int));
                comm.Parameters["@pk_Favorite"].Value = id;
                comm.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">ID</param>
        public void DeleteData(int id)
        {
            Sql.SqlQuery("delete from Member_Favorite where pk_Favorite=" + id);
        }

        #endregion
    }
}
