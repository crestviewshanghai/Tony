using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Payment
{
    public class List
    {
        #region 公共属性
        int _pk_Payment;
        public int pk_Payment
        {
            get { return _pk_Payment; }
            set { _pk_Payment = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        string _Subtitle;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        int _TypeID;
        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        string _Gateway;
        public string Gateway
        {
            get { return _Gateway; }
            set { _Gateway = value; }
        }
        string _Service;
        public string Service
        {
            get { return _Service; }
            set { _Service = value; }
        }
        string _Account;
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }
        string _AppID;
        public string AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }
        string _Secret;
        public string Secret
        {
            get { return _Secret; }
            set { _Secret = value; }
        }
        string _PartnerID;
        public string PartnerID
        {
            get { return _PartnerID; }
            set { _PartnerID = value; }
        }
        string _KeyCode;
        public string KeyCode
        {
            get { return _KeyCode; }
            set { _KeyCode = value; }
        }
        string _SignType;
        public string SignType
        {
            get { return _SignType; }
            set { _SignType = value; }
        }
        string _InputCharset;
        public string InputCharset
        {
            get { return _InputCharset; }
            set { _InputCharset = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _Currency;
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        decimal _Rate;
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        bool _Visible;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        string _CreateDate;
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        int _CreateUserID;
        public int CreateUserID
        {
            get { return _CreateUserID; }
            set { _CreateUserID = value; }
        }
        string _ModifyDate;
        public string ModifyDate
        {
            get { return _ModifyDate; }
            set { _ModifyDate = value; }
        }
        int _ModifyUserID;
        public int ModifyUserID
        {
            get { return _ModifyUserID; }
            set { _ModifyUserID = value; }
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
                string sql = "select * from Payment_List where pk_Payment=@pk_Payment";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Payment", SqlDbType.Int));
                comm.Parameters["@pk_Payment"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Payment = Convert.ToInt32(dr["pk_Payment"].ToString());
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Gateway = dr["Gateway"].ToString();
                    _Service = dr["Service"].ToString();
                    _Account = dr["Account"].ToString();
                    _AppID = dr["AppID"].ToString();
                    _Secret = dr["Secret"].ToString();
                    _PartnerID = dr["PartnerID"].ToString();
                    _KeyCode = dr["KeyCode"].ToString();
                    _SignType = dr["SignType"].ToString();
                    _InputCharset = dr["InputCharset"].ToString();
                    _Description = dr["Description"].ToString();
                    _Currency = dr["Currency"].ToString();
                    _Rate = Convert.ToDecimal(dr["Rate"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
                    if (dr["ModifyUserID"] != DBNull.Value)
                    {
                        _ModifyUserID = Convert.ToInt32(dr["ModifyUserID"].ToString());
                    }
                    else
                    {
                        _ModifyUserID = 0;
                    }
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
        /// <param name="typeId">Type ID</param>
        public void GetDataByType(int typeId)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Payment_List where TypeID=@TypeID and Visible=1";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = typeId;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Payment = Convert.ToInt32(dr["pk_Payment"].ToString());
                    _Title = dr["Title"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _Gateway = dr["Gateway"].ToString();
                    _Service = dr["Service"].ToString();
                    _Account = dr["Account"].ToString();
                    _AppID = dr["AppID"].ToString();
                    _Secret = dr["Secret"].ToString();
                    _PartnerID = dr["PartnerID"].ToString();
                    _KeyCode = dr["KeyCode"].ToString();
                    _SignType = dr["SignType"].ToString();
                    _InputCharset = dr["InputCharset"].ToString();
                    _Description = dr["Description"].ToString();
                    _Currency = dr["Currency"].ToString();
                    _Rate = Convert.ToDecimal(dr["Rate"].ToString());
                    _Visible = Convert.ToBoolean(dr["Visible"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _CreateDate = dr["CreateDate"].ToString();
                    _CreateUserID = Convert.ToInt32(dr["CreateUserID"].ToString());
                    _ModifyDate = dr["ModifyDate"].ToString();
                    if (dr["ModifyUserID"] != DBNull.Value)
                    {
                        _ModifyUserID = Convert.ToInt32(dr["ModifyUserID"].ToString());
                    }
                    else
                    {
                        _ModifyUserID = 0;
                    }
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
                string sql = "insert into Payment_List(Title,Subtitle,TypeID,Gateway,Service,Account,AppID,Secret,PartnerID,KeyCode,SignType,InputCharset,Description,Currency,Rate,Visible,SortID,ImagePath,CreateDate,CreateUserID,ModifyDate,ModifyUserID) values (@Title,@Subtitle,@TypeID,@Gateway,@Service,@Account,@AppID,@Secret,@PartnerID,@KeyCode,@SignType,@InputCharset,@Description,@Currency,@Rate,@Visible,@SortID,@ImagePath,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Gateway", SqlDbType.NVarChar, 250));
                comm.Parameters["@Gateway"].Value = _Gateway;
                comm.Parameters.Add(new SqlParameter("@Service", SqlDbType.NVarChar, 100));
                comm.Parameters["@Service"].Value = _Service;
                comm.Parameters.Add(new SqlParameter("@Account", SqlDbType.NVarChar, 200));
                comm.Parameters["@Account"].Value = _Account;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 200));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@Secret", SqlDbType.NVarChar, 200));
                comm.Parameters["@Secret"].Value = _Secret;
                comm.Parameters.Add(new SqlParameter("@PartnerID", SqlDbType.NVarChar, 200));
                comm.Parameters["@PartnerID"].Value = _PartnerID;
                comm.Parameters.Add(new SqlParameter("@KeyCode", SqlDbType.NVarChar, 200));
                comm.Parameters["@KeyCode"].Value = _KeyCode;
                comm.Parameters.Add(new SqlParameter("@SignType", SqlDbType.VarChar, 10));
                comm.Parameters["@SignType"].Value = _SignType;
                comm.Parameters.Add(new SqlParameter("@InputCharset", SqlDbType.VarChar, 10));
                comm.Parameters["@InputCharset"].Value = _InputCharset;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.NVarChar, 10));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal));
                comm.Parameters["@Rate"].Value = _Rate;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
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
                string sql = "update Payment_List set Title=@Title,Subtitle=@Subtitle,TypeID=@TypeID,Gateway=@Gateway,Service=@Service,Account=@Account,AppID=@AppID,Secret=@Secret,PartnerID=@PartnerID,KeyCode=@KeyCode,SignType=@SignType,InputCharset=@InputCharset,Description=@Description,Currency=@Currency,Rate=@Rate,Visible=@Visible,SortID=@SortID,ImagePath=@ImagePath,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID where pk_Payment=@pk_Payment";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100));
                comm.Parameters["@Title"].Value = _Title;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@Gateway", SqlDbType.NVarChar, 250));
                comm.Parameters["@Gateway"].Value = _Gateway;
                comm.Parameters.Add(new SqlParameter("@Service", SqlDbType.NVarChar, 100));
                comm.Parameters["@Service"].Value = _Service;
                comm.Parameters.Add(new SqlParameter("@Account", SqlDbType.NVarChar, 200));
                comm.Parameters["@Account"].Value = _Account;
                comm.Parameters.Add(new SqlParameter("@AppID", SqlDbType.NVarChar, 200));
                comm.Parameters["@AppID"].Value = _AppID;
                comm.Parameters.Add(new SqlParameter("@Secret", SqlDbType.NVarChar, 200));
                comm.Parameters["@Secret"].Value = _Secret;
                comm.Parameters.Add(new SqlParameter("@PartnerID", SqlDbType.NVarChar, 200));
                comm.Parameters["@PartnerID"].Value = _PartnerID;
                comm.Parameters.Add(new SqlParameter("@KeyCode", SqlDbType.NVarChar, 200));
                comm.Parameters["@KeyCode"].Value = _KeyCode;
                comm.Parameters.Add(new SqlParameter("@SignType", SqlDbType.VarChar, 10));
                comm.Parameters["@SignType"].Value = _SignType;
                comm.Parameters.Add(new SqlParameter("@InputCharset", SqlDbType.VarChar, 10));
                comm.Parameters["@InputCharset"].Value = _InputCharset;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Currency", SqlDbType.NVarChar, 10));
                comm.Parameters["@Currency"].Value = _Currency;
                comm.Parameters.Add(new SqlParameter("@Rate", SqlDbType.Decimal));
                comm.Parameters["@Rate"].Value = _Rate;
                comm.Parameters.Add(new SqlParameter("@Visible", SqlDbType.Bit));
                comm.Parameters["@Visible"].Value = _Visible;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@pk_Payment", SqlDbType.Int));
                comm.Parameters["@pk_Payment"].Value = id;
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
            Sql.SqlQuery("delete from Payment_List where pk_Payment=" + id);
        }

        #endregion
    }
}
