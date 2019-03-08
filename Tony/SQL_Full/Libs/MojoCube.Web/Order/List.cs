using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Order
{
    public class List
    {
        #region 公共属性
        int _pk_Order;
        public int pk_Order
        {
            get { return _pk_Order; }
            set { _pk_Order = value; }
        }
        int _fk_Member;
        public int fk_Member
        {
            get { return _fk_Member; }
            set { _fk_Member = value; }
        }
        int _fk_Express;
        public int fk_Express
        {
            get { return _fk_Express; }
            set { _fk_Express = value; }
        }
        string _OrderNumber;
        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }
        string _TrackingNumber;
        public string TrackingNumber
        {
            get { return _TrackingNumber; }
            set { _TrackingNumber = value; }
        }
        string _CustomerName;
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        int _CustomerSex;
        public int CustomerSex
        {
            get { return _CustomerSex; }
            set { _CustomerSex = value; }
        }
        string _CustomerPhone1;
        public string CustomerPhone1
        {
            get { return _CustomerPhone1; }
            set { _CustomerPhone1 = value; }
        }
        string _CustomerPhone2;
        public string CustomerPhone2
        {
            get { return _CustomerPhone2; }
            set { _CustomerPhone2 = value; }
        }
        string _CustomerQQ;
        public string CustomerQQ
        {
            get { return _CustomerQQ; }
            set { _CustomerQQ = value; }
        }
        string _CustomerEmail;
        public string CustomerEmail
        {
            get { return _CustomerEmail; }
            set { _CustomerEmail = value; }
        }
        string _CustomerZip;
        public string CustomerZip
        {
            get { return _CustomerZip; }
            set { _CustomerZip = value; }
        }
        string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set { _CustomerAddress = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        string _Note;
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        decimal _Freight;
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        decimal _Premium;
        public decimal Premium
        {
            get { return _Premium; }
            set { _Premium = value; }
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
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        int _fk_Payment;
        public int fk_Payment
        {
            get { return _fk_Payment; }
            set { _fk_Payment = value; }
        }
        string _PaymentDate;
        public string PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        string _ShipmentDate;
        public string ShipmentDate
        {
            get { return _ShipmentDate; }
            set { _ShipmentDate = value; }
        }
        string _ShipperCode;
        public string ShipperCode
        {
            get { return _ShipperCode; }
            set { _ShipperCode = value; }
        }
        string _LogisticCode;
        public string LogisticCode
        {
            get { return _LogisticCode; }
            set { _LogisticCode = value; }
        }
        string _LogisticInfo;
        public string LogisticInfo
        {
            get { return _LogisticInfo; }
            set { _LogisticInfo = value; }
        }
        string _LastCheck;
        public string LastCheck
        {
            get { return _LastCheck; }
            set { _LastCheck = value; }
        }
        string _CancelDate;
        public string CancelDate
        {
            get { return _CancelDate; }
            set { _CancelDate = value; }
        }
        bool _IsPublic;
        public bool IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }
        bool _IsAssess;
        public bool IsAssess
        {
            get { return _IsAssess; }
            set { _IsAssess = value; }
        }
        bool _IsComment;
        public bool IsComment
        {
            get { return _IsComment; }
            set { _IsComment = value; }
        }
        string _Comments;
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        int _StatusID;
        public int StatusID
        {
            get { return _StatusID; }
            set { _StatusID = value; }
        }
        bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
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
                string sql = "select * from Order_List where pk_Order=@pk_Order";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Order", SqlDbType.Int));
                comm.Parameters["@pk_Order"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Order = Convert.ToInt32(dr["pk_Order"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _fk_Express = Convert.ToInt32(dr["fk_Express"].ToString());
                    _OrderNumber = dr["OrderNumber"].ToString();
                    _TrackingNumber = dr["TrackingNumber"].ToString();
                    _CustomerName = dr["CustomerName"].ToString();
                    _CustomerSex = Convert.ToInt32(dr["CustomerSex"].ToString());
                    _CustomerPhone1 = dr["CustomerPhone1"].ToString();
                    _CustomerPhone2 = dr["CustomerPhone2"].ToString();
                    _CustomerQQ = dr["CustomerQQ"].ToString();
                    _CustomerEmail = dr["CustomerEmail"].ToString();
                    _CustomerZip = dr["CustomerZip"].ToString();
                    _CustomerAddress = dr["CustomerAddress"].ToString();
                    _Description = dr["Description"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Note = dr["Note"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Freight = Convert.ToDecimal(dr["Freight"].ToString());
                    _Premium = Convert.ToDecimal(dr["Premium"].ToString());
                    _Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    _Currency = Convert.ToInt32(dr["Currency"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _EndDate = dr["EndDate"].ToString();
                    _fk_Payment = Convert.ToInt32(dr["fk_Payment"].ToString());
                    _PaymentDate = dr["PaymentDate"].ToString();
                    _ShipmentDate = dr["ShipmentDate"].ToString();
                    _ShipperCode = dr["ShipperCode"].ToString();
                    _LogisticCode = dr["LogisticCode"].ToString();
                    _LogisticInfo = dr["LogisticInfo"].ToString();
                    _LastCheck = dr["LastCheck"].ToString();
                    _CancelDate = dr["CancelDate"].ToString();
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsAssess = Convert.ToBoolean(dr["IsAssess"].ToString());
                    _IsComment = Convert.ToBoolean(dr["IsComment"].ToString());
                    _Comments = dr["Comments"].ToString();
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _IsDeleted = Convert.ToBoolean(dr["IsDeleted"].ToString());
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="orderNumber">订单编号</param>
        public void GetData(string orderNumber)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Order_List where OrderNumber=@OrderNumber";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@OrderNumber"].Value = orderNumber;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Order = Convert.ToInt32(dr["pk_Order"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _fk_Express = Convert.ToInt32(dr["fk_Express"].ToString());
                    _OrderNumber = dr["OrderNumber"].ToString();
                    _TrackingNumber = dr["TrackingNumber"].ToString();
                    _CustomerName = dr["CustomerName"].ToString();
                    _CustomerSex = Convert.ToInt32(dr["CustomerSex"].ToString());
                    _CustomerPhone1 = dr["CustomerPhone1"].ToString();
                    _CustomerPhone2 = dr["CustomerPhone2"].ToString();
                    _CustomerQQ = dr["CustomerQQ"].ToString();
                    _CustomerEmail = dr["CustomerEmail"].ToString();
                    _CustomerZip = dr["CustomerZip"].ToString();
                    _CustomerAddress = dr["CustomerAddress"].ToString();
                    _Description = dr["Description"].ToString();
                    _Remark = dr["Remark"].ToString();
                    _Note = dr["Note"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Freight = Convert.ToDecimal(dr["Freight"].ToString());
                    _Premium = Convert.ToDecimal(dr["Premium"].ToString());
                    _Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    _Currency = Convert.ToInt32(dr["Currency"].ToString());
                    _CreateDate = dr["CreateDate"].ToString();
                    _EndDate = dr["EndDate"].ToString();
                    _fk_Payment = Convert.ToInt32(dr["fk_Payment"].ToString());
                    _PaymentDate = dr["PaymentDate"].ToString();
                    _ShipmentDate = dr["ShipmentDate"].ToString();
                    _ShipperCode = dr["ShipperCode"].ToString();
                    _LogisticCode = dr["LogisticCode"].ToString();
                    _LogisticInfo = dr["LogisticInfo"].ToString();
                    _LastCheck = dr["LastCheck"].ToString();
                    _CancelDate = dr["CancelDate"].ToString();
                    _IsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());
                    _IsAssess = Convert.ToBoolean(dr["IsAssess"].ToString());
                    _IsComment = Convert.ToBoolean(dr["IsComment"].ToString());
                    _Comments = dr["Comments"].ToString();
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _IsDeleted = Convert.ToBoolean(dr["IsDeleted"].ToString());
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
                string sql = "insert into Order_List(fk_Member,fk_Express,OrderNumber,TrackingNumber,CustomerName,CustomerSex,CustomerPhone1,CustomerPhone2,CustomerQQ,CustomerEmail,CustomerZip,CustomerAddress,Description,Remark,Note,TypeID,Freight,Premium,Amount,Currency,CreateDate,EndDate,fk_Payment,PaymentDate,ShipmentDate,ShipperCode,LogisticCode,LogisticInfo,LastCheck,CancelDate,IsPublic,IsAssess,IsComment,Comments,StatusID,IsDeleted) values (@fk_Member,@fk_Express,@OrderNumber,@TrackingNumber,@CustomerName,@CustomerSex,@CustomerPhone1,@CustomerPhone2,@CustomerQQ,@CustomerEmail,@CustomerZip,@CustomerAddress,@Description,@Remark,@Note,@TypeID,@Freight,@Premium,@Amount,@Currency,@CreateDate,@EndDate,@fk_Payment,@PaymentDate,@ShipmentDate,@ShipperCode,@LogisticCode,@LogisticInfo,@LastCheck,@CancelDate,@IsPublic,@IsAssess,@IsComment,@Comments,@StatusID,@IsDeleted)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@fk_Express", SqlDbType.Int));
                comm.Parameters["@fk_Express"].Value = _fk_Express;
                comm.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@OrderNumber"].Value = _OrderNumber;
                comm.Parameters.Add(new SqlParameter("@TrackingNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@TrackingNumber"].Value = _TrackingNumber;
                comm.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerName"].Value = _CustomerName;
                comm.Parameters.Add(new SqlParameter("@CustomerSex", SqlDbType.Int));
                comm.Parameters["@CustomerSex"].Value = _CustomerSex;
                comm.Parameters.Add(new SqlParameter("@CustomerPhone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerPhone1"].Value = _CustomerPhone1;
                comm.Parameters.Add(new SqlParameter("@CustomerPhone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerPhone2"].Value = _CustomerPhone2;
                comm.Parameters.Add(new SqlParameter("@CustomerQQ", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerQQ"].Value = _CustomerQQ;
                comm.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 100));
                comm.Parameters["@CustomerEmail"].Value = _CustomerEmail;
                comm.Parameters.Add(new SqlParameter("@CustomerZip", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerZip"].Value = _CustomerZip;
                comm.Parameters.Add(new SqlParameter("@CustomerAddress", SqlDbType.NVarChar, 200));
                comm.Parameters["@CustomerAddress"].Value = _CustomerAddress;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 500));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 500));
                comm.Parameters["@Note"].Value = _Note;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@Premium", SqlDbType.Money));
                comm.Parameters["@Premium"].Value = _Premium;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
                comm.Parameters.Add(new SqlParameter("@fk_Payment", SqlDbType.Int));
                comm.Parameters["@fk_Payment"].Value = _fk_Payment;
                comm.Parameters.Add(new SqlParameter("@PaymentDate", SqlDbType.DateTime));
                comm.Parameters["@PaymentDate"].Value = _PaymentDate;
                comm.Parameters.Add(new SqlParameter("@ShipmentDate", SqlDbType.DateTime));
                comm.Parameters["@ShipmentDate"].Value = _ShipmentDate;
                comm.Parameters.Add(new SqlParameter("@ShipperCode", SqlDbType.VarChar, 20));
                comm.Parameters["@ShipperCode"].Value = _ShipperCode;
                comm.Parameters.Add(new SqlParameter("@LogisticCode", SqlDbType.NVarChar, 100));
                comm.Parameters["@LogisticCode"].Value = _LogisticCode;
                comm.Parameters.Add(new SqlParameter("@LogisticInfo", SqlDbType.NVarChar, -1));
                comm.Parameters["@LogisticInfo"].Value = _LogisticInfo;
                comm.Parameters.Add(new SqlParameter("@LastCheck", SqlDbType.DateTime));
                comm.Parameters["@LastCheck"].Value = _LastCheck;
                comm.Parameters.Add(new SqlParameter("@CancelDate", SqlDbType.DateTime));
                comm.Parameters["@CancelDate"].Value = _CancelDate;
                comm.Parameters.Add(new SqlParameter("@IsPublic", SqlDbType.Bit));
                comm.Parameters["@IsPublic"].Value = _IsPublic;
                comm.Parameters.Add(new SqlParameter("@IsAssess", SqlDbType.Bit));
                comm.Parameters["@IsAssess"].Value = _IsAssess;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Comments"].Value = _Comments;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = _IsDeleted;
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
                string sql = "update Order_List set fk_Member=@fk_Member,fk_Express=@fk_Express,OrderNumber=@OrderNumber,TrackingNumber=@TrackingNumber,CustomerName=@CustomerName,CustomerSex=@CustomerSex,CustomerPhone1=@CustomerPhone1,CustomerPhone2=@CustomerPhone2,CustomerQQ=@CustomerQQ,CustomerEmail=@CustomerEmail,CustomerZip=@CustomerZip,CustomerAddress=@CustomerAddress,Description=@Description,Remark=@Remark,Note=@Note,TypeID=@TypeID,Freight=@Freight,Premium=@Premium,Amount=@Amount,Currency=@Currency,CreateDate=@CreateDate,EndDate=@EndDate,fk_Payment=@fk_Payment,PaymentDate=@PaymentDate,ShipmentDate=@ShipmentDate,ShipperCode=@ShipperCode,LogisticCode=@LogisticCode,LogisticInfo=@LogisticInfo,LastCheck=@LastCheck,CancelDate=@CancelDate,IsPublic=@IsPublic,IsAssess=@IsAssess,IsComment=@IsComment,Comments=@Comments,StatusID=@StatusID,IsDeleted=@IsDeleted where pk_Order=@pk_Order";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@fk_Express", SqlDbType.Int));
                comm.Parameters["@fk_Express"].Value = _fk_Express;
                comm.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@OrderNumber"].Value = _OrderNumber;
                comm.Parameters.Add(new SqlParameter("@TrackingNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@TrackingNumber"].Value = _TrackingNumber;
                comm.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerName"].Value = _CustomerName;
                comm.Parameters.Add(new SqlParameter("@CustomerSex", SqlDbType.Int));
                comm.Parameters["@CustomerSex"].Value = _CustomerSex;
                comm.Parameters.Add(new SqlParameter("@CustomerPhone1", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerPhone1"].Value = _CustomerPhone1;
                comm.Parameters.Add(new SqlParameter("@CustomerPhone2", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerPhone2"].Value = _CustomerPhone2;
                comm.Parameters.Add(new SqlParameter("@CustomerQQ", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerQQ"].Value = _CustomerQQ;
                comm.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.NVarChar, 100));
                comm.Parameters["@CustomerEmail"].Value = _CustomerEmail;
                comm.Parameters.Add(new SqlParameter("@CustomerZip", SqlDbType.NVarChar, 50));
                comm.Parameters["@CustomerZip"].Value = _CustomerZip;
                comm.Parameters.Add(new SqlParameter("@CustomerAddress", SqlDbType.NVarChar, 200));
                comm.Parameters["@CustomerAddress"].Value = _CustomerAddress;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 500));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 500));
                comm.Parameters["@Remark"].Value = _Remark;
                comm.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar, 500));
                comm.Parameters["@Note"].Value = _Note;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@Premium", SqlDbType.Money));
                comm.Parameters["@Premium"].Value = _Premium;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.Int));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
                comm.Parameters.Add(new SqlParameter("@fk_Payment", SqlDbType.Int));
                comm.Parameters["@fk_Payment"].Value = _fk_Payment;
                comm.Parameters.Add(new SqlParameter("@PaymentDate", SqlDbType.DateTime));
                comm.Parameters["@PaymentDate"].Value = _PaymentDate;
                comm.Parameters.Add(new SqlParameter("@ShipmentDate", SqlDbType.DateTime));
                comm.Parameters["@ShipmentDate"].Value = _ShipmentDate;
                comm.Parameters.Add(new SqlParameter("@ShipperCode", SqlDbType.VarChar, 20));
                comm.Parameters["@ShipperCode"].Value = _ShipperCode;
                comm.Parameters.Add(new SqlParameter("@LogisticCode", SqlDbType.NVarChar, 100));
                comm.Parameters["@LogisticCode"].Value = _LogisticCode;
                comm.Parameters.Add(new SqlParameter("@LogisticInfo", SqlDbType.NVarChar, -1));
                comm.Parameters["@LogisticInfo"].Value = _LogisticInfo;
                comm.Parameters.Add(new SqlParameter("@LastCheck", SqlDbType.DateTime));
                comm.Parameters["@LastCheck"].Value = _LastCheck;
                comm.Parameters.Add(new SqlParameter("@CancelDate", SqlDbType.DateTime));
                comm.Parameters["@CancelDate"].Value = _CancelDate;
                comm.Parameters.Add(new SqlParameter("@IsPublic", SqlDbType.Bit));
                comm.Parameters["@IsPublic"].Value = _IsPublic;
                comm.Parameters.Add(new SqlParameter("@IsAssess", SqlDbType.Bit));
                comm.Parameters["@IsAssess"].Value = _IsAssess;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Comments"].Value = _Comments;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@IsDeleted", SqlDbType.Bit));
                comm.Parameters["@IsDeleted"].Value = _IsDeleted;
                comm.Parameters.Add(new SqlParameter("@pk_Order", SqlDbType.Int));
                comm.Parameters["@pk_Order"].Value = id;
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
            Sql.SqlQuery("delete from Order_List where pk_Order=" + id);
        }

        #endregion
    }
}
