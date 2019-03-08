using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Order
{
    public class Log
    {
        #region 公共属性
        int _pk_Log;
        public int pk_Log
        {
            get { return _pk_Log; }
            set { _pk_Log = value; }
        }
        string _Number;
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        string _OrderNumber;
        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }
        int _fk_Order;
        public int fk_Order
        {
            get { return _fk_Order; }
            set { _fk_Order = value; }
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
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        string _AppID;
        public string AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }
        string _TransStatus;
        public string TransStatus
        {
            get { return _TransStatus; }
            set { _TransStatus = value; }
        }
        string _TransName;
        public string TransName
        {
            get { return _TransName; }
            set { _TransName = value; }
        }
        string _ChannelType;
        public string ChannelType
        {
            get { return _ChannelType; }
            set { _ChannelType = value; }
        }
        string _ResponseCode;
        public string ResponseCode
        {
            get { return _ResponseCode; }
            set { _ResponseCode = value; }
        }
        string _ResponseMsg;
        public string ResponseMsg
        {
            get { return _ResponseMsg; }
            set { _ResponseMsg = value; }
        }
        string _OrderStartTime;
        public string OrderStartTime
        {
            get { return _OrderStartTime; }
            set { _OrderStartTime = value; }
        }
        string _OrderAmt;
        public string OrderAmt
        {
            get { return _OrderAmt; }
            set { _OrderAmt = value; }
        }
        string _OrderTimeOut;
        public string OrderTimeOut
        {
            get { return _OrderTimeOut; }
            set { _OrderTimeOut = value; }
        }
        string _OrderType;
        public string OrderType
        {
            get { return _OrderType; }
            set { _OrderType = value; }
        }
        string _DeviceType;
        public string DeviceType
        {
            get { return _DeviceType; }
            set { _DeviceType = value; }
        }
        string _ResponseTime;
        public string ResponseTime
        {
            get { return _ResponseTime; }
            set { _ResponseTime = value; }
        }
        string _CurrencyType;
        public string CurrencyType
        {
            get { return _CurrencyType; }
            set { _CurrencyType = value; }
        }
        string _Result;
        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
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
                string sql = "select * from Order_Log where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Log = Convert.ToInt32(dr["pk_Log"].ToString());
                    _Number = dr["Number"].ToString();
                    _OrderNumber = dr["OrderNumber"].ToString();
                    _fk_Order = Convert.ToInt32(dr["fk_Order"].ToString());
                    _fk_Member = Convert.ToInt32(dr["fk_Member"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Title = dr["Title"].ToString();
                    _Description = dr["Description"].ToString();
                    _Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    _AppID = dr["AppID"].ToString();
                    _TransStatus = dr["TransStatus"].ToString();
                    _TransName = dr["TransName"].ToString();
                    _ChannelType = dr["ChannelType"].ToString();
                    _ResponseCode = dr["ResponseCode"].ToString();
                    _ResponseMsg = dr["ResponseMsg"].ToString();
                    _OrderStartTime = dr["OrderStartTime"].ToString();
                    _OrderAmt = dr["OrderAmt"].ToString();
                    _OrderTimeOut = dr["OrderTimeOut"].ToString();
                    _OrderType = dr["OrderType"].ToString();
                    _DeviceType = dr["DeviceType"].ToString();
                    _ResponseTime = dr["ResponseTime"].ToString();
                    _CurrencyType = dr["CurrencyType"].ToString();
                    _Result = dr["Result"].ToString();
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
                string sql = "insert into Order_Log(Number,OrderNumber,fk_Order,fk_Member,TypeID,StatusID,Title,Description,Amount,AppID,TransStatus,TransName,ChannelType,ResponseCode,ResponseMsg,OrderStartTime,OrderAmt,OrderTimeOut,OrderType,DeviceType,ResponseTime,CurrencyType,Result,CreateDate) values (@Number,@OrderNumber,@fk_Order,@fk_Member,@TypeID,@StatusID,@Title,@Description,@Amount,@AppID,@TransStatus,@TransName,@ChannelType,@ResponseCode,@ResponseMsg,@OrderStartTime,@OrderAmt,@OrderTimeOut,@OrderType,@DeviceType,@ResponseTime,@CurrencyType,@Result,@CreateDate)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 100));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@OrderNumber"].Value = _OrderNumber;
                comm.Parameters.Add(new SqlParameter("@fk_Order", SqlDbType.Int));
                comm.Parameters["@fk_Order"].Value = _fk_Order;
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 100));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@TransStatus", SqlDbType.NVarChar, 50));
                comm.Parameters["@TransStatus"].Value = _TransStatus;
                comm.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar, 50));
                comm.Parameters["@TransName"].Value = _TransName;
                comm.Parameters.Add(new SqlParameter("@ChannelType", SqlDbType.NVarChar, 50));
                comm.Parameters["@ChannelType"].Value = _ChannelType;
                comm.Parameters.Add(new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 50));
                comm.Parameters["@ResponseCode"].Value = _ResponseCode;
                comm.Parameters.Add(new SqlParameter("@ResponseMsg", SqlDbType.NVarChar, 500));
                comm.Parameters["@ResponseMsg"].Value = _ResponseMsg;
                comm.Parameters.Add(new SqlParameter("@OrderStartTime", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderStartTime"].Value = _OrderStartTime;
                comm.Parameters.Add(new SqlParameter("@OrderAmt", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderAmt"].Value = _OrderAmt;
                comm.Parameters.Add(new SqlParameter("@OrderTimeOut", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderTimeOut"].Value = _OrderTimeOut;
                comm.Parameters.Add(new SqlParameter("@OrderType", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderType"].Value = _OrderType;
                comm.Parameters.Add(new SqlParameter("@DeviceType", SqlDbType.NVarChar, 50));
                comm.Parameters["@DeviceType"].Value = _DeviceType;
                comm.Parameters.Add(new SqlParameter("@ResponseTime", SqlDbType.NVarChar, 50));
                comm.Parameters["@ResponseTime"].Value = _ResponseTime;
                comm.Parameters.Add(new SqlParameter("@CurrencyType", SqlDbType.NVarChar, 50));
                comm.Parameters["@CurrencyType"].Value = _CurrencyType;
                comm.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 2000));
                comm.Parameters["@Result"].Value = _Result;
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
                string sql = "update Order_Log set Number=@Number,OrderNumber=@OrderNumber,fk_Order=@fk_Order,fk_Member=@fk_Member,TypeID=@TypeID,StatusID=@StatusID,Title=@Title,Description=@Description,Amount=@Amount,AppID=@AppID,TransStatus=@TransStatus,TransName=@TransName,ChannelType=@ChannelType,ResponseCode=@ResponseCode,ResponseMsg=@ResponseMsg,OrderStartTime=@OrderStartTime,OrderAmt=@OrderAmt,OrderTimeOut=@OrderTimeOut,OrderType=@OrderType,DeviceType=@DeviceType,ResponseTime=@ResponseTime,CurrencyType=@CurrencyType,Result=@Result,CreateDate=@CreateDate where pk_Log=@pk_Log";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 100));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 100));
                comm.Parameters["@OrderNumber"].Value = _OrderNumber;
                comm.Parameters.Add(new SqlParameter("@fk_Order", SqlDbType.Int));
                comm.Parameters["@fk_Order"].Value = _fk_Order;
                comm.Parameters.Add(new SqlParameter("@fk_Member", SqlDbType.Int));
                comm.Parameters["@fk_Member"].Value = _fk_Member;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                comm.Parameters["@Amount"].Value = _Amount;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 100));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@TransStatus", SqlDbType.NVarChar, 50));
                comm.Parameters["@TransStatus"].Value = _TransStatus;
                comm.Parameters.Add(new SqlParameter("@TransName", SqlDbType.NVarChar, 50));
                comm.Parameters["@TransName"].Value = _TransName;
                comm.Parameters.Add(new SqlParameter("@ChannelType", SqlDbType.NVarChar, 50));
                comm.Parameters["@ChannelType"].Value = _ChannelType;
                comm.Parameters.Add(new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 50));
                comm.Parameters["@ResponseCode"].Value = _ResponseCode;
                comm.Parameters.Add(new SqlParameter("@ResponseMsg", SqlDbType.NVarChar, 500));
                comm.Parameters["@ResponseMsg"].Value = _ResponseMsg;
                comm.Parameters.Add(new SqlParameter("@OrderStartTime", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderStartTime"].Value = _OrderStartTime;
                comm.Parameters.Add(new SqlParameter("@OrderAmt", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderAmt"].Value = _OrderAmt;
                comm.Parameters.Add(new SqlParameter("@OrderTimeOut", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderTimeOut"].Value = _OrderTimeOut;
                comm.Parameters.Add(new SqlParameter("@OrderType", SqlDbType.NVarChar, 50));
                comm.Parameters["@OrderType"].Value = _OrderType;
                comm.Parameters.Add(new SqlParameter("@DeviceType", SqlDbType.NVarChar, 50));
                comm.Parameters["@DeviceType"].Value = _DeviceType;
                comm.Parameters.Add(new SqlParameter("@ResponseTime", SqlDbType.NVarChar, 50));
                comm.Parameters["@ResponseTime"].Value = _ResponseTime;
                comm.Parameters.Add(new SqlParameter("@CurrencyType", SqlDbType.NVarChar, 50));
                comm.Parameters["@CurrencyType"].Value = _CurrencyType;
                comm.Parameters.Add(new SqlParameter("@Result", SqlDbType.NVarChar, 2000));
                comm.Parameters["@Result"].Value = _Result;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@pk_Log", SqlDbType.Int));
                comm.Parameters["@pk_Log"].Value = id;
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
            Sql.SqlQuery("delete from Order_Log where pk_Log=" + id);
        }

        #endregion
    }
}
