using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Member
{
    public class Cart
    {
        #region 公共属性
        int _pk_Cart;
        public int pk_Cart
        {
            get { return _pk_Cart; }
            set { _pk_Cart = value; }
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
        int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }
        int _fk_ID;
        public int fk_ID
        {
            get { return _fk_ID; }
            set { _fk_ID = value; }
        }
        int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
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
                string sql = "select * from Member_Cart where pk_Cart=@pk_Cart";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Cart", SqlDbType.Int));
                comm.Parameters["@pk_Cart"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Cart = Convert.ToInt32(dr["pk_Cart"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _fk_ID = Convert.ToInt32(dr["fk_ID"].ToString());
                    _Qty = Convert.ToInt32(dr["Qty"].ToString());
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
                string sql = "insert into Member_Cart(fk_Member,TypeID,StatusID,fk_ID,Qty,CreateDate) values (@fk_Member,@TypeID,@StatusID,@fk_ID,@Qty,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
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
                string sql = "update Member_Cart set fk_Member=@fk_Member,TypeID=@TypeID,StatusID=@StatusID,fk_ID=@fk_ID,Qty=@Qty,CreateDate=@CreateDate where pk_Cart=@pk_Cart";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Cart", SqlDbType.Int));
                comm.Parameters["@pk_Cart"].Value = id;
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
            Sql.SqlQuery("delete from Member_Cart where pk_Cart=" + id);
        }

        #endregion
    }
}
