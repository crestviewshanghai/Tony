using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Order
{
    public class Item
    {
        #region 公共属性
        int _pk_Item;
        public int pk_Item
        {
            get { return _pk_Item; }
            set { _pk_Item = value; }
        }
        int _fk_Order;
        public int fk_Order
        {
            get { return _fk_Order; }
            set { _fk_Order = value; }
        }
        int _fk_ID;
        public int fk_ID
        {
            get { return _fk_ID; }
            set { _fk_ID = value; }
        }
        int _fk_Price;
        public int fk_Price
        {
            get { return _fk_Price; }
            set { _fk_Price = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        int _Currency;
        public int Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
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
                string sql = "select * from Order_Item where pk_Item=@pk_Item";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Item", SqlDbType.Int));
                comm.Parameters["@pk_Item"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Item = Convert.ToInt32(dr["pk_Item"].ToString());
                    _fk_Order = Convert.ToInt32(dr["fk_Order"].ToString());
                    _fk_ID = Convert.ToInt32(dr["fk_ID"].ToString());
                    _fk_Price = Convert.ToInt32(dr["fk_Price"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Title = dr["Title"].ToString();
                    _ImagePath = dr["ImagePath"].ToString();
                    _PageName = dr["PageName"].ToString();
                    _Price = Convert.ToDecimal(dr["Price"].ToString());
                    _Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    _Currency = Convert.ToInt32(dr["Currency"].ToString());
                    _Qty = Convert.ToInt32(dr["Qty"].ToString());
                    _Remark = dr["Remark"].ToString();
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
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
                string sql = "insert into Order_Item(fk_Order,fk_ID,fk_Price,TypeID,Title,ImagePath,PageName,Price,Amount,Currency,Qty,Remark,StatusID,CreateDate) values (@fk_Order,@fk_ID,@fk_Price,@TypeID,@Title,@ImagePath,@PageName,@Price,@Amount,@Currency,@Qty,@Remark,@StatusID,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Order", SqlDbType.Int));
                comm.Parameters["@fk_Order"].Value = _fk_Order;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@fk_Price", SqlDbType.Int));
                comm.Parameters["@fk_Price"].Value = _fk_Price;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                comm.Parameters["@Price"].Value = _Price;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 200));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
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
                string sql = "update Order_Item set fk_Order=@fk_Order,fk_ID=@fk_ID,fk_Price=@fk_Price,TypeID=@TypeID,Title=@Title,ImagePath=@ImagePath,PageName=@PageName,Price=@Price,Amount=@Amount,Currency=@Currency,Qty=@Qty,Remark=@Remark,StatusID=@StatusID,CreateDate=@CreateDate where pk_Item=@pk_Item";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Order", SqlDbType.Int));
                comm.Parameters["@fk_Order"].Value = _fk_Order;
                comm.Parameters.Add(new SqlParameter("@fk_ID", SqlDbType.Int));
                comm.Parameters["@fk_ID"].Value = _fk_ID;
                comm.Parameters.Add(new SqlParameter("@fk_Price", SqlDbType.Int));
                comm.Parameters["@fk_Price"].Value = _fk_Price;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                comm.Parameters["@Price"].Value = _Price;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 200));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Item", SqlDbType.Int));
                comm.Parameters["@pk_Item"].Value = id;
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
            Sql.SqlQuery("delete from Order_Item where pk_Item=" + id);
        }

        #endregion
    }
}
