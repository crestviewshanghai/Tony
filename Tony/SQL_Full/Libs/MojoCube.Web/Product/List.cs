using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Product
{
    public class List
    {
        #region 公共属性
        int _pk_Product;
        public int pk_Product
        {
            get { return _pk_Product; }
            set { _pk_Product = value; }
        }
        int _CategoryID1;
        public int CategoryID1
        {
            get { return _CategoryID1; }
            set { _CategoryID1 = value; }
        }
        int _CategoryID2;
        public int CategoryID2
        {
            get { return _CategoryID2; }
            set { _CategoryID2 = value; }
        }
        string _Number;
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        string _Subtitle;
        public string Subtitle
        {
            get { return _Subtitle; }
            set { _Subtitle = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _Attribute;
        public string Attribute
        {
            get { return _Attribute; }
            set { _Attribute = value; }
        }
        string _SEO_Title;
        public string SEO_Title
        {
            get { return _SEO_Title; }
            set { _SEO_Title = value; }
        }
        string _SEO_Keyword;
        public string SEO_Keyword
        {
            get { return _SEO_Keyword; }
            set { _SEO_Keyword = value; }
        }
        string _SEO_Description;
        public string SEO_Description
        {
            get { return _SEO_Description; }
            set { _SEO_Description = value; }
        }
        string _Tags;
        public string Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }
        string _Visual;
        public string Visual
        {
            get { return _Visual; }
            set { _Visual = value; }
        }
        decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        string _Location;
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        int _CountryID;
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        int _ProvinceID;
        public int ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
        }
        int _CityID;
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        bool _Issue;
        public bool Issue
        {
            get { return _Issue; }
            set { _Issue = value; }
        }
        bool _IsComment;
        public bool IsComment
        {
            get { return _IsComment; }
            set { _IsComment = value; }
        }
        bool _IsRecommend;
        public bool IsRecommend
        {
            get { return _IsRecommend; }
            set { _IsRecommend = value; }
        }
        int _Clicks;
        public int Clicks
        {
            get { return _Clicks; }
            set { _Clicks = value; }
        }
        int _SortID;
        public int SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
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
        int _Score;
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        int _ScoreIn;
        public int ScoreIn
        {
            get { return _ScoreIn; }
            set { _ScoreIn = value; }
        }
        int _Sales;
        public int Sales
        {
            get { return _Sales; }
            set { _Sales = value; }
        }
        decimal _SpecialPrice;
        public decimal SpecialPrice
        {
            get { return _SpecialPrice; }
            set { _SpecialPrice = value; }
        }
        decimal _Freight;
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }
        string _StartDate;
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
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
        string _Language;
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
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
                string sql = "select * from Product_List where pk_Product=@pk_Product";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@pk_Product", SqlDbType.Int));
                comm.Parameters["@pk_Product"].Value = id;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Product = Convert.ToInt32(dr["pk_Product"].ToString());
                    _CategoryID1 = Convert.ToInt32(dr["CategoryID1"].ToString());
                    _CategoryID2 = Convert.ToInt32(dr["CategoryID2"].ToString());
                    _Number = dr["Number"].ToString();
                    _PageName = dr["PageName"].ToString();
                    _ProductName = dr["ProductName"].ToString();
                    _Subtitle = dr["Subtitle"].ToString();
                    _Description = dr["Description"].ToString();
                    _Attribute = dr["Attribute"].ToString();
                    _SEO_Title = dr["SEO_Title"].ToString();
                    _SEO_Keyword = dr["SEO_Keyword"].ToString();
                    _SEO_Description = dr["SEO_Description"].ToString();
                    _Tags = dr["Tags"].ToString();
                    _Visual = dr["Visual"].ToString();
                    _Price = Convert.ToDecimal(dr["Price"].ToString());
                    _Qty = Convert.ToInt32(dr["Qty"].ToString());
                    _Location = dr["Location"].ToString();
                    _CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    _ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                    _CityID = Convert.ToInt32(dr["CityID"].ToString());
                    _ImagePath = dr["ImagePath"].ToString();
                    _Issue = Convert.ToBoolean(dr["Issue"].ToString());
                    _IsComment = Convert.ToBoolean(dr["IsComment"].ToString());
                    _IsRecommend = Convert.ToBoolean(dr["IsRecommend"].ToString());
                    _Clicks = Convert.ToInt32(dr["Clicks"].ToString());
                    _SortID = Convert.ToInt32(dr["SortID"].ToString());
                    _TypeID = Convert.ToInt32(dr["TypeID"].ToString());
                    _StatusID = Convert.ToInt32(dr["StatusID"].ToString());
                    _Score = Convert.ToInt32(dr["Score"].ToString());
                    _ScoreIn = Convert.ToInt32(dr["ScoreIn"].ToString());
                    _Sales = Convert.ToInt32(dr["Sales"].ToString());
                    _SpecialPrice = Convert.ToDecimal(dr["SpecialPrice"].ToString());
                    _Freight = Convert.ToDecimal(dr["Freight"].ToString());
                    _StartDate = dr["StartDate"].ToString();
                    _EndDate = dr["EndDate"].ToString();
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
                    _Language = dr["Language"].ToString();
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
                string sql = "insert into Product_List(CategoryID1,CategoryID2,Number,PageName,ProductName,Subtitle,Description,Attribute,SEO_Title,SEO_Keyword,SEO_Description,Tags,Visual,Price,Qty,Location,CountryID,ProvinceID,CityID,ImagePath,Issue,IsComment,IsRecommend,Clicks,SortID,TypeID,StatusID,Score,ScoreIn,Sales,SpecialPrice,Freight,StartDate,EndDate,CreateDate,CreateUserID,ModifyDate,ModifyUserID,Language) values (@CategoryID1,@CategoryID2,@Number,@PageName,@ProductName,@Subtitle,@Description,@Attribute,@SEO_Title,@SEO_Keyword,@SEO_Description,@Tags,@Visual,@Price,@Qty,@Location,@CountryID,@ProvinceID,@CityID,@ImagePath,@Issue,@IsComment,@IsRecommend,@Clicks,@SortID,@TypeID,@StatusID,@Score,@ScoreIn,@Sales,@SpecialPrice,@Freight,@StartDate,@EndDate,@CreateDate,@CreateUserID,@ModifyDate,@ModifyUserID,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@CategoryID1", SqlDbType.Int));
                comm.Parameters["@CategoryID1"].Value = _CategoryID1;
                comm.Parameters.Add(new SqlParameter("@CategoryID2", SqlDbType.Int));
                comm.Parameters["@CategoryID2"].Value = _CategoryID2;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 100));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 100));
                comm.Parameters["@ProductName"].Value = _ProductName;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Attribute", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Attribute"].Value = _Attribute;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 100));
                comm.Parameters["@Tags"].Value = _Tags;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 10));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                comm.Parameters["@Price"].Value = _Price;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
                comm.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar, 50));
                comm.Parameters["@Location"].Value = _Location;
                comm.Parameters.Add(new SqlParameter("@CountryID", SqlDbType.Int));
                comm.Parameters["@CountryID"].Value = _CountryID;
                comm.Parameters.Add(new SqlParameter("@ProvinceID", SqlDbType.Int));
                comm.Parameters["@ProvinceID"].Value = _ProvinceID;
                comm.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int));
                comm.Parameters["@CityID"].Value = _CityID;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Score", SqlDbType.Int));
                comm.Parameters["@Score"].Value = _Score;
                comm.Parameters.Add(new SqlParameter("@ScoreIn", SqlDbType.Int));
                comm.Parameters["@ScoreIn"].Value = _ScoreIn;
                comm.Parameters.Add(new SqlParameter("@Sales", SqlDbType.Int));
                comm.Parameters["@Sales"].Value = _Sales;
                comm.Parameters.Add(new SqlParameter("@SpecialPrice", SqlDbType.Money));
                comm.Parameters["@SpecialPrice"].Value = _SpecialPrice;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
                comm.Parameters["@StartDate"].Value = _StartDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
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
                string sql = "update Product_List set CategoryID1=@CategoryID1,CategoryID2=@CategoryID2,Number=@Number,PageName=@PageName,ProductName=@ProductName,Subtitle=@Subtitle,Description=@Description,Attribute=@Attribute,SEO_Title=@SEO_Title,SEO_Keyword=@SEO_Keyword,SEO_Description=@SEO_Description,Tags=@Tags,Visual=@Visual,Price=@Price,Qty=@Qty,Location=@Location,CountryID=@CountryID,ProvinceID=@ProvinceID,CityID=@CityID,ImagePath=@ImagePath,Issue=@Issue,IsComment=@IsComment,IsRecommend=@IsRecommend,Clicks=@Clicks,SortID=@SortID,TypeID=@TypeID,StatusID=@StatusID,Score=@Score,ScoreIn=@ScoreIn,Sales=@Sales,SpecialPrice=@SpecialPrice,Freight=@Freight,StartDate=@StartDate,EndDate=@EndDate,CreateDate=@CreateDate,CreateUserID=@CreateUserID,ModifyDate=@ModifyDate,ModifyUserID=@ModifyUserID,Language=@Language where pk_Product=@pk_Product";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@CategoryID1", SqlDbType.Int));
                comm.Parameters["@CategoryID1"].Value = _CategoryID1;
                comm.Parameters.Add(new SqlParameter("@CategoryID2", SqlDbType.Int));
                comm.Parameters["@CategoryID2"].Value = _CategoryID2;
                comm.Parameters.Add(new SqlParameter("@Number", SqlDbType.NVarChar, 100));
                comm.Parameters["@Number"].Value = _Number;
                comm.Parameters.Add(new SqlParameter("@PageName", SqlDbType.NVarChar, 100));
                comm.Parameters["@PageName"].Value = _PageName;
                comm.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.NVarChar, 100));
                comm.Parameters["@ProductName"].Value = _ProductName;
                comm.Parameters.Add(new SqlParameter("@Subtitle", SqlDbType.NVarChar, 200));
                comm.Parameters["@Subtitle"].Value = _Subtitle;
                comm.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1));
                comm.Parameters["@Description"].Value = _Description;
                comm.Parameters.Add(new SqlParameter("@Attribute", SqlDbType.NVarChar, 1000));
                comm.Parameters["@Attribute"].Value = _Attribute;
                comm.Parameters.Add(new SqlParameter("@SEO_Title", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Title"].Value = _SEO_Title;
                comm.Parameters.Add(new SqlParameter("@SEO_Keyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SEO_Keyword"].Value = _SEO_Keyword;
                comm.Parameters.Add(new SqlParameter("@SEO_Description", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SEO_Description"].Value = _SEO_Description;
                comm.Parameters.Add(new SqlParameter("@Tags", SqlDbType.NVarChar, 100));
                comm.Parameters["@Tags"].Value = _Tags;
                comm.Parameters.Add(new SqlParameter("@Visual", SqlDbType.VarChar, 10));
                comm.Parameters["@Visual"].Value = _Visual;
                comm.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                comm.Parameters["@Price"].Value = _Price;
                comm.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                comm.Parameters["@Qty"].Value = _Qty;
                comm.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar, 50));
                comm.Parameters["@Location"].Value = _Location;
                comm.Parameters.Add(new SqlParameter("@CountryID", SqlDbType.Int));
                comm.Parameters["@CountryID"].Value = _CountryID;
                comm.Parameters.Add(new SqlParameter("@ProvinceID", SqlDbType.Int));
                comm.Parameters["@ProvinceID"].Value = _ProvinceID;
                comm.Parameters.Add(new SqlParameter("@CityID", SqlDbType.Int));
                comm.Parameters["@CityID"].Value = _CityID;
                comm.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@ImagePath"].Value = _ImagePath;
                comm.Parameters.Add(new SqlParameter("@Issue", SqlDbType.Bit));
                comm.Parameters["@Issue"].Value = _Issue;
                comm.Parameters.Add(new SqlParameter("@IsComment", SqlDbType.Bit));
                comm.Parameters["@IsComment"].Value = _IsComment;
                comm.Parameters.Add(new SqlParameter("@IsRecommend", SqlDbType.Bit));
                comm.Parameters["@IsRecommend"].Value = _IsRecommend;
                comm.Parameters.Add(new SqlParameter("@Clicks", SqlDbType.Int));
                comm.Parameters["@Clicks"].Value = _Clicks;
                comm.Parameters.Add(new SqlParameter("@SortID", SqlDbType.Int));
                comm.Parameters["@SortID"].Value = _SortID;
                comm.Parameters.Add(new SqlParameter("@TypeID", SqlDbType.Int));
                comm.Parameters["@TypeID"].Value = _TypeID;
                comm.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.Int));
                comm.Parameters["@StatusID"].Value = _StatusID;
                comm.Parameters.Add(new SqlParameter("@Score", SqlDbType.Int));
                comm.Parameters["@Score"].Value = _Score;
                comm.Parameters.Add(new SqlParameter("@ScoreIn", SqlDbType.Int));
                comm.Parameters["@ScoreIn"].Value = _ScoreIn;
                comm.Parameters.Add(new SqlParameter("@Sales", SqlDbType.Int));
                comm.Parameters["@Sales"].Value = _Sales;
                comm.Parameters.Add(new SqlParameter("@SpecialPrice", SqlDbType.Money));
                comm.Parameters["@SpecialPrice"].Value = _SpecialPrice;
                comm.Parameters.Add(new SqlParameter("@Freight", SqlDbType.Money));
                comm.Parameters["@Freight"].Value = _Freight;
                comm.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
                comm.Parameters["@StartDate"].Value = _StartDate;
                comm.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));
                comm.Parameters["@EndDate"].Value = _EndDate;
                comm.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime));
                comm.Parameters["@CreateDate"].Value = _CreateDate;
                comm.Parameters.Add(new SqlParameter("@CreateUserID", SqlDbType.Int));
                comm.Parameters["@CreateUserID"].Value = _CreateUserID;
                comm.Parameters.Add(new SqlParameter("@ModifyDate", SqlDbType.DateTime));
                comm.Parameters["@ModifyDate"].Value = _ModifyDate;
                comm.Parameters.Add(new SqlParameter("@ModifyUserID", SqlDbType.Int));
                comm.Parameters["@ModifyUserID"].Value = _ModifyUserID;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@pk_Product", SqlDbType.Int));
                comm.Parameters["@pk_Product"].Value = id;
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
            Sql.SqlQuery("delete from Product_List where pk_Product=" + id);
        }

        #endregion
    }
}
