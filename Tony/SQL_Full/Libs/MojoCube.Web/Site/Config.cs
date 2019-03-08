using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MojoCube.Web.Site
{
    public class Config
    {
        #region 公共属性
        int _pk_Config;
        public int pk_Config
        {
            get { return _pk_Config; }
            set { _pk_Config = value; }
        }
        int _IndexID;
        public int IndexID
        {
            get { return _IndexID; }
            set { _IndexID = value; }
        }
        string _SiteName;
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }
        string _SiteTitle;
        public string SiteTitle
        {
            get { return _SiteTitle; }
            set { _SiteTitle = value; }
        }
        string _SiteKeyword;
        public string SiteKeyword
        {
            get { return _SiteKeyword; }
            set { _SiteKeyword = value; }
        }
        string _SiteDescription;
        public string SiteDescription
        {
            get { return _SiteDescription; }
            set { _SiteDescription = value; }
        }
        string _SiteContentType;
        public string SiteContentType
        {
            get { return _SiteContentType; }
            set { _SiteContentType = value; }
        }
        string _SiteUrl;
        public string SiteUrl
        {
            get { return _SiteUrl; }
            set { _SiteUrl = value; }
        }
        string _SiteLogo;
        public string SiteLogo
        {
            get { return _SiteLogo; }
            set { _SiteLogo = value; }
        }
        string _SiteCopyRight;
        public string SiteCopyRight
        {
            get { return _SiteCopyRight; }
            set { _SiteCopyRight = value; }
        }
        string _SiteContact;
        public string SiteContact
        {
            get { return _SiteContact; }
            set { _SiteContact = value; }
        }
        string _SiteNotify;
        public string SiteNotify
        {
            get { return _SiteNotify; }
            set { _SiteNotify = value; }
        }
        string _MapCode;
        public string MapCode
        {
            get { return _MapCode; }
            set { _MapCode = value; }
        }
        string _StatisticsCode;
        public string StatisticsCode
        {
            get { return _StatisticsCode; }
            set { _StatisticsCode = value; }
        }
        string _ShareCode;
        public string ShareCode
        {
            get { return _ShareCode; }
            set { _ShareCode = value; }
        }
        string _OtherMeta;
        public string OtherMeta
        {
            get { return _OtherMeta; }
            set { _OtherMeta = value; }
        }
        string _ContactUs;
        public string ContactUs
        {
            get { return _ContactUs; }
            set { _ContactUs = value; }
        }
        bool _IsSiteOpen;
        public bool IsSiteOpen
        {
            get { return _IsSiteOpen; }
            set { _IsSiteOpen = value; }
        }
        string _ClosedInfo;
        public string ClosedInfo
        {
            get { return _ClosedInfo; }
            set { _ClosedInfo = value; }
        }
        int _ShowPageSize;
        public int ShowPageSize
        {
            get { return _ShowPageSize; }
            set { _ShowPageSize = value; }
        }
        bool _AllowComment;
        public bool AllowComment
        {
            get { return _AllowComment; }
            set { _AllowComment = value; }
        }
        string _SiteLogoPath;
        public string SiteLogoPath
        {
            get { return _SiteLogoPath; }
            set { _SiteLogoPath = value; }
        }
        string _ArticleImagePath;
        public string ArticleImagePath
        {
            get { return _ArticleImagePath; }
            set { _ArticleImagePath = value; }
        }
        string _ProductImagePath;
        public string ProductImagePath
        {
            get { return _ProductImagePath; }
            set { _ProductImagePath = value; }
        }
        string _ADImagePath;
        public string ADImagePath
        {
            get { return _ADImagePath; }
            set { _ADImagePath = value; }
        }
        int _ImgSize_S_W;
        public int ImgSize_S_W
        {
            get { return _ImgSize_S_W; }
            set { _ImgSize_S_W = value; }
        }
        int _ImgSize_S_H;
        public int ImgSize_S_H
        {
            get { return _ImgSize_S_H; }
            set { _ImgSize_S_H = value; }
        }
        int _ImgSize_M_W;
        public int ImgSize_M_W
        {
            get { return _ImgSize_M_W; }
            set { _ImgSize_M_W = value; }
        }
        int _ImgSize_M_H;
        public int ImgSize_M_H
        {
            get { return _ImgSize_M_H; }
            set { _ImgSize_M_H = value; }
        }
        string _SiteTheme;
        public string SiteTheme
        {
            get { return _SiteTheme; }
            set { _SiteTheme = value; }
        }
        string _WM_Text;
        public string WM_Text
        {
            get { return _WM_Text; }
            set { _WM_Text = value; }
        }
        string _WM_Font;
        public string WM_Font
        {
            get { return _WM_Font; }
            set { _WM_Font = value; }
        }
        int _WM_FontSize;
        public int WM_FontSize
        {
            get { return _WM_FontSize; }
            set { _WM_FontSize = value; }
        }
        int _WM_Bottom;
        public int WM_Bottom
        {
            get { return _WM_Bottom; }
            set { _WM_Bottom = value; }
        }
        int _WM_Right;
        public int WM_Right
        {
            get { return _WM_Right; }
            set { _WM_Right = value; }
        }
        int _WM_Rotate;
        public int WM_Rotate
        {
            get { return _WM_Rotate; }
            set { _WM_Rotate = value; }
        }
        int _WM_Size;
        public int WM_Size
        {
            get { return _WM_Size; }
            set { _WM_Size = value; }
        }
        int _WM_Alpha;
        public int WM_Alpha
        {
            get { return _WM_Alpha; }
            set { _WM_Alpha = value; }
        }
        int _WM_Red;
        public int WM_Red
        {
            get { return _WM_Red; }
            set { _WM_Red = value; }
        }
        int _WM_Green;
        public int WM_Green
        {
            get { return _WM_Green; }
            set { _WM_Green = value; }
        }
        int _WM_Blue;
        public int WM_Blue
        {
            get { return _WM_Blue; }
            set { _WM_Blue = value; }
        }
        bool _WM_IsShow;
        public bool WM_IsShow
        {
            get { return _WM_IsShow; }
            set { _WM_IsShow = value; }
        }
        int _WM_Show_W;
        public int WM_Show_W
        {
            get { return _WM_Show_W; }
            set { _WM_Show_W = value; }
        }
        int _WM_Show_H;
        public int WM_Show_H
        {
            get { return _WM_Show_H; }
            set { _WM_Show_H = value; }
        }
        bool _WM_Mode;
        public bool WM_Mode
        {
            get { return _WM_Mode; }
            set { _WM_Mode = value; }
        }
        string _WM_ImagePath;
        public string WM_ImagePath
        {
            get { return _WM_ImagePath; }
            set { _WM_ImagePath = value; }
        }
        bool _SiteCounter;
        public bool SiteCounter
        {
            get { return _SiteCounter; }
            set { _SiteCounter = value; }
        }
        int _SiteFlow;
        public int SiteFlow
        {
            get { return _SiteFlow; }
            set { _SiteFlow = value; }
        }
        string _UrlExtension;
        public string UrlExtension
        {
            get { return _UrlExtension; }
            set { _UrlExtension = value; }
        }
        bool _IsBoundIP;
        public bool IsBoundIP
        {
            get { return _IsBoundIP; }
            set { _IsBoundIP = value; }
        }
        string _BoundIP;
        public string BoundIP
        {
            get { return _BoundIP; }
            set { _BoundIP = value; }
        }
        string _Target;
        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        int _SearchType;
        public int SearchType
        {
            get { return _SearchType; }
            set { _SearchType = value; }
        }
        bool _ShowService;
        public bool ShowService
        {
            get { return _ShowService; }
            set { _ShowService = value; }
        }
        int _ArticleTitleLength;
        public int ArticleTitleLength
        {
            get { return _ArticleTitleLength; }
            set { _ArticleTitleLength = value; }
        }
        string _Terms;
        public string Terms
        {
            get { return _Terms; }
            set { _Terms = value; }
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
        /// <param name="indexId">IndexID</param>
        /// <param name="language">Language</param>
        public void GetData(int indexId, string language)
        {
            SqlConnection conn = new SqlConnection(Connection.ConnString());
            try
            {
                conn.Open();
                string sql = "select * from Site_Config where IndexID=@IndexID and Language=@Language";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IndexID", SqlDbType.Int));
                comm.Parameters["@IndexID"].Value = indexId;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = language;
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    _pk_Config = Convert.ToInt32(dr["pk_Config"].ToString());
                    _IndexID = Convert.ToInt32(dr["IndexID"].ToString());
                    _SiteName = dr["SiteName"].ToString();
                    _SiteTitle = dr["SiteTitle"].ToString();
                    _SiteKeyword = dr["SiteKeyword"].ToString();
                    _SiteDescription = dr["SiteDescription"].ToString();
                    _SiteContentType = dr["SiteContentType"].ToString();
                    _SiteUrl = dr["SiteUrl"].ToString();
                    _SiteLogo = dr["SiteLogo"].ToString();
                    _SiteCopyRight = dr["SiteCopyRight"].ToString();
                    _SiteContact = dr["SiteContact"].ToString();
                    _SiteNotify = dr["SiteNotify"].ToString();
                    _MapCode = dr["MapCode"].ToString();
                    _StatisticsCode = dr["StatisticsCode"].ToString();
                    _ShareCode = dr["ShareCode"].ToString();
                    _OtherMeta = dr["OtherMeta"].ToString();
                    _ContactUs = dr["ContactUs"].ToString();
                    _IsSiteOpen = Convert.ToBoolean(dr["IsSiteOpen"].ToString());
                    _ClosedInfo = dr["ClosedInfo"].ToString();
                    _ShowPageSize = Convert.ToInt32(dr["ShowPageSize"].ToString());
                    _AllowComment = Convert.ToBoolean(dr["AllowComment"].ToString());
                    _SiteLogoPath = dr["SiteLogoPath"].ToString();
                    _ArticleImagePath = dr["ArticleImagePath"].ToString();
                    _ProductImagePath = dr["ProductImagePath"].ToString();
                    _ADImagePath = dr["ADImagePath"].ToString();
                    _ImgSize_S_W = Convert.ToInt32(dr["ImgSize_S_W"].ToString());
                    _ImgSize_S_H = Convert.ToInt32(dr["ImgSize_S_H"].ToString());
                    _ImgSize_M_W = Convert.ToInt32(dr["ImgSize_M_W"].ToString());
                    _ImgSize_M_H = Convert.ToInt32(dr["ImgSize_M_H"].ToString());
                    _SiteTheme = dr["SiteTheme"].ToString();
                    _WM_Text = dr["WM_Text"].ToString();
                    _WM_Font = dr["WM_Font"].ToString();
                    _WM_FontSize = Convert.ToInt32(dr["WM_FontSize"].ToString());
                    _WM_Bottom = Convert.ToInt32(dr["WM_Bottom"].ToString());
                    _WM_Right = Convert.ToInt32(dr["WM_Right"].ToString());
                    _WM_Rotate = Convert.ToInt32(dr["WM_Rotate"].ToString());
                    _WM_Size = Convert.ToInt32(dr["WM_Size"].ToString());
                    _WM_Alpha = Convert.ToInt32(dr["WM_Alpha"].ToString());
                    _WM_Red = Convert.ToInt32(dr["WM_Red"].ToString());
                    _WM_Green = Convert.ToInt32(dr["WM_Green"].ToString());
                    _WM_Blue = Convert.ToInt32(dr["WM_Blue"].ToString());
                    _WM_IsShow = Convert.ToBoolean(dr["WM_IsShow"].ToString());
                    _WM_Show_W = Convert.ToInt32(dr["WM_Show_W"].ToString());
                    _WM_Show_H = Convert.ToInt32(dr["WM_Show_H"].ToString());
                    _WM_Mode = Convert.ToBoolean(dr["WM_Mode"].ToString());
                    _WM_ImagePath = dr["WM_ImagePath"].ToString();
                    _SiteCounter = Convert.ToBoolean(dr["SiteCounter"].ToString());
                    _SiteFlow = Convert.ToInt32(dr["SiteFlow"].ToString());
                    _UrlExtension = dr["UrlExtension"].ToString();
                    _IsBoundIP = Convert.ToBoolean(dr["IsBoundIP"].ToString());
                    _BoundIP = dr["BoundIP"].ToString();
                    _Target = dr["Target"].ToString();
                    _SearchType = Convert.ToInt32(dr["SearchType"].ToString());
                    _ShowService = Convert.ToBoolean(dr["ShowService"].ToString());
                    _ArticleTitleLength = Convert.ToInt32(dr["ArticleTitleLength"].ToString());
                    _Terms = dr["Terms"].ToString();
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
                string sql = "insert into Site_Config(IndexID,SiteName,SiteTitle,SiteKeyword,SiteDescription,SiteContentType,SiteUrl,SiteLogo,SiteCopyRight,SiteContact,SiteNotify,MapCode,StatisticsCode,ShareCode,OtherMeta,ContactUs,IsSiteOpen,ClosedInfo,ShowPageSize,AllowComment,SiteLogoPath,ArticleImagePath,ProductImagePath,ADImagePath,ImgSize_S_W,ImgSize_S_H,ImgSize_M_W,ImgSize_M_H,SiteTheme,WM_Text,WM_Font,WM_FontSize,WM_Bottom,WM_Right,WM_Rotate,WM_Size,WM_Alpha,WM_Red,WM_Green,WM_Blue,WM_IsShow,WM_Show_W,WM_Show_H,WM_Mode,WM_ImagePath,SiteCounter,SiteFlow,UrlExtension,IsBoundIP,BoundIP,Target,SearchType,ShowService,ArticleTitleLength,Terms,Language) values (@IndexID,@SiteName,@SiteTitle,@SiteKeyword,@SiteDescription,@SiteContentType,@SiteUrl,@SiteLogo,@SiteCopyRight,@SiteContact,@SiteNotify,@MapCode,@StatisticsCode,@ShareCode,@OtherMeta,@ContactUs,@IsSiteOpen,@ClosedInfo,@ShowPageSize,@AllowComment,@SiteLogoPath,@ArticleImagePath,@ProductImagePath,@ADImagePath,@ImgSize_S_W,@ImgSize_S_H,@ImgSize_M_W,@ImgSize_M_H,@SiteTheme,@WM_Text,@WM_Font,@WM_FontSize,@WM_Bottom,@WM_Right,@WM_Rotate,@WM_Size,@WM_Alpha,@WM_Red,@WM_Green,@WM_Blue,@WM_IsShow,@WM_Show_W,@WM_Show_H,@WM_Mode,@WM_ImagePath,@SiteCounter,@SiteFlow,@UrlExtension,@IsBoundIP,@BoundIP,@Target,@SearchType,@ShowService,@ArticleTitleLength,@Terms,@Language)";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IndexID", SqlDbType.Int));
                comm.Parameters["@IndexID"].Value = _IndexID;
                comm.Parameters.Add(new SqlParameter("@SiteName", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteName"].Value = _SiteName;
                comm.Parameters.Add(new SqlParameter("@SiteTitle", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteTitle"].Value = _SiteTitle;
                comm.Parameters.Add(new SqlParameter("@SiteKeyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteKeyword"].Value = _SiteKeyword;
                comm.Parameters.Add(new SqlParameter("@SiteDescription", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteDescription"].Value = _SiteDescription;
                comm.Parameters.Add(new SqlParameter("@SiteContentType", SqlDbType.NVarChar, 50));
                comm.Parameters["@SiteContentType"].Value = _SiteContentType;
                comm.Parameters.Add(new SqlParameter("@SiteUrl", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteUrl"].Value = _SiteUrl;
                comm.Parameters.Add(new SqlParameter("@SiteLogo", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteLogo"].Value = _SiteLogo;
                comm.Parameters.Add(new SqlParameter("@SiteCopyRight", SqlDbType.NVarChar, -1));
                comm.Parameters["@SiteCopyRight"].Value = _SiteCopyRight;
                comm.Parameters.Add(new SqlParameter("@SiteContact", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteContact"].Value = _SiteContact;
                comm.Parameters.Add(new SqlParameter("@SiteNotify", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SiteNotify"].Value = _SiteNotify;
                comm.Parameters.Add(new SqlParameter("@MapCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@MapCode"].Value = _MapCode;
                comm.Parameters.Add(new SqlParameter("@StatisticsCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@StatisticsCode"].Value = _StatisticsCode;
                comm.Parameters.Add(new SqlParameter("@ShareCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@ShareCode"].Value = _ShareCode;
                comm.Parameters.Add(new SqlParameter("@OtherMeta", SqlDbType.NVarChar, -1));
                comm.Parameters["@OtherMeta"].Value = _OtherMeta;
                comm.Parameters.Add(new SqlParameter("@ContactUs", SqlDbType.NVarChar, -1));
                comm.Parameters["@ContactUs"].Value = _ContactUs;
                comm.Parameters.Add(new SqlParameter("@IsSiteOpen", SqlDbType.Bit));
                comm.Parameters["@IsSiteOpen"].Value = _IsSiteOpen;
                comm.Parameters.Add(new SqlParameter("@ClosedInfo", SqlDbType.NVarChar, 250));
                comm.Parameters["@ClosedInfo"].Value = _ClosedInfo;
                comm.Parameters.Add(new SqlParameter("@ShowPageSize", SqlDbType.Int));
                comm.Parameters["@ShowPageSize"].Value = _ShowPageSize;
                comm.Parameters.Add(new SqlParameter("@AllowComment", SqlDbType.Bit));
                comm.Parameters["@AllowComment"].Value = _AllowComment;
                comm.Parameters.Add(new SqlParameter("@SiteLogoPath", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteLogoPath"].Value = _SiteLogoPath;
                comm.Parameters.Add(new SqlParameter("@ArticleImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ArticleImagePath"].Value = _ArticleImagePath;
                comm.Parameters.Add(new SqlParameter("@ProductImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ProductImagePath"].Value = _ProductImagePath;
                comm.Parameters.Add(new SqlParameter("@ADImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ADImagePath"].Value = _ADImagePath;
                comm.Parameters.Add(new SqlParameter("@ImgSize_S_W", SqlDbType.Int));
                comm.Parameters["@ImgSize_S_W"].Value = _ImgSize_S_W;
                comm.Parameters.Add(new SqlParameter("@ImgSize_S_H", SqlDbType.Int));
                comm.Parameters["@ImgSize_S_H"].Value = _ImgSize_S_H;
                comm.Parameters.Add(new SqlParameter("@ImgSize_M_W", SqlDbType.Int));
                comm.Parameters["@ImgSize_M_W"].Value = _ImgSize_M_W;
                comm.Parameters.Add(new SqlParameter("@ImgSize_M_H", SqlDbType.Int));
                comm.Parameters["@ImgSize_M_H"].Value = _ImgSize_M_H;
                comm.Parameters.Add(new SqlParameter("@SiteTheme", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteTheme"].Value = _SiteTheme;
                comm.Parameters.Add(new SqlParameter("@WM_Text", SqlDbType.NVarChar, 200));
                comm.Parameters["@WM_Text"].Value = _WM_Text;
                comm.Parameters.Add(new SqlParameter("@WM_Font", SqlDbType.NVarChar, 50));
                comm.Parameters["@WM_Font"].Value = _WM_Font;
                comm.Parameters.Add(new SqlParameter("@WM_FontSize", SqlDbType.Int));
                comm.Parameters["@WM_FontSize"].Value = _WM_FontSize;
                comm.Parameters.Add(new SqlParameter("@WM_Bottom", SqlDbType.Int));
                comm.Parameters["@WM_Bottom"].Value = _WM_Bottom;
                comm.Parameters.Add(new SqlParameter("@WM_Right", SqlDbType.Int));
                comm.Parameters["@WM_Right"].Value = _WM_Right;
                comm.Parameters.Add(new SqlParameter("@WM_Rotate", SqlDbType.Int));
                comm.Parameters["@WM_Rotate"].Value = _WM_Rotate;
                comm.Parameters.Add(new SqlParameter("@WM_Size", SqlDbType.Int));
                comm.Parameters["@WM_Size"].Value = _WM_Size;
                comm.Parameters.Add(new SqlParameter("@WM_Alpha", SqlDbType.Int));
                comm.Parameters["@WM_Alpha"].Value = _WM_Alpha;
                comm.Parameters.Add(new SqlParameter("@WM_Red", SqlDbType.Int));
                comm.Parameters["@WM_Red"].Value = _WM_Red;
                comm.Parameters.Add(new SqlParameter("@WM_Green", SqlDbType.Int));
                comm.Parameters["@WM_Green"].Value = _WM_Green;
                comm.Parameters.Add(new SqlParameter("@WM_Blue", SqlDbType.Int));
                comm.Parameters["@WM_Blue"].Value = _WM_Blue;
                comm.Parameters.Add(new SqlParameter("@WM_IsShow", SqlDbType.Bit));
                comm.Parameters["@WM_IsShow"].Value = _WM_IsShow;
                comm.Parameters.Add(new SqlParameter("@WM_Show_W", SqlDbType.Int));
                comm.Parameters["@WM_Show_W"].Value = _WM_Show_W;
                comm.Parameters.Add(new SqlParameter("@WM_Show_H", SqlDbType.Int));
                comm.Parameters["@WM_Show_H"].Value = _WM_Show_H;
                comm.Parameters.Add(new SqlParameter("@WM_Mode", SqlDbType.Bit));
                comm.Parameters["@WM_Mode"].Value = _WM_Mode;
                comm.Parameters.Add(new SqlParameter("@WM_ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@WM_ImagePath"].Value = _WM_ImagePath;
                comm.Parameters.Add(new SqlParameter("@SiteCounter", SqlDbType.Bit));
                comm.Parameters["@SiteCounter"].Value = _SiteCounter;
                comm.Parameters.Add(new SqlParameter("@SiteFlow", SqlDbType.Int));
                comm.Parameters["@SiteFlow"].Value = _SiteFlow;
                comm.Parameters.Add(new SqlParameter("@UrlExtension", SqlDbType.NVarChar, 50));
                comm.Parameters["@UrlExtension"].Value = _UrlExtension;
                comm.Parameters.Add(new SqlParameter("@IsBoundIP", SqlDbType.Bit));
                comm.Parameters["@IsBoundIP"].Value = _IsBoundIP;
                comm.Parameters.Add(new SqlParameter("@BoundIP", SqlDbType.NVarChar, -1));
                comm.Parameters["@BoundIP"].Value = _BoundIP;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 50));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@SearchType", SqlDbType.Int));
                comm.Parameters["@SearchType"].Value = _SearchType;
                comm.Parameters.Add(new SqlParameter("@ShowService", SqlDbType.Bit));
                comm.Parameters["@ShowService"].Value = _ShowService;
                comm.Parameters.Add(new SqlParameter("@ArticleTitleLength", SqlDbType.Int));
                comm.Parameters["@ArticleTitleLength"].Value = _ArticleTitleLength;
                comm.Parameters.Add(new SqlParameter("@Terms", SqlDbType.NVarChar, -1));
                comm.Parameters["@Terms"].Value = _Terms;
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
                string sql = "update Site_Config set IndexID=@IndexID,SiteName=@SiteName,SiteTitle=@SiteTitle,SiteKeyword=@SiteKeyword,SiteDescription=@SiteDescription,SiteContentType=@SiteContentType,SiteUrl=@SiteUrl,SiteLogo=@SiteLogo,SiteCopyRight=@SiteCopyRight,SiteContact=@SiteContact,SiteNotify=@SiteNotify,MapCode=@MapCode,StatisticsCode=@StatisticsCode,ShareCode=@ShareCode,OtherMeta=@OtherMeta,ContactUs=@ContactUs,IsSiteOpen=@IsSiteOpen,ClosedInfo=@ClosedInfo,ShowPageSize=@ShowPageSize,AllowComment=@AllowComment,SiteLogoPath=@SiteLogoPath,ArticleImagePath=@ArticleImagePath,ProductImagePath=@ProductImagePath,ADImagePath=@ADImagePath,ImgSize_S_W=@ImgSize_S_W,ImgSize_S_H=@ImgSize_S_H,ImgSize_M_W=@ImgSize_M_W,ImgSize_M_H=@ImgSize_M_H,SiteTheme=@SiteTheme,WM_Text=@WM_Text,WM_Font=@WM_Font,WM_FontSize=@WM_FontSize,WM_Bottom=@WM_Bottom,WM_Right=@WM_Right,WM_Rotate=@WM_Rotate,WM_Size=@WM_Size,WM_Alpha=@WM_Alpha,WM_Red=@WM_Red,WM_Green=@WM_Green,WM_Blue=@WM_Blue,WM_IsShow=@WM_IsShow,WM_Show_W=@WM_Show_W,WM_Show_H=@WM_Show_H,WM_Mode=@WM_Mode,WM_ImagePath=@WM_ImagePath,SiteCounter=@SiteCounter,SiteFlow=@SiteFlow,UrlExtension=@UrlExtension,IsBoundIP=@IsBoundIP,BoundIP=@BoundIP,Target=@Target,SearchType=@SearchType,ShowService=@ShowService,ArticleTitleLength=@ArticleTitleLength,Terms=@Terms,Language=@Language where pk_Config=@pk_Config";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.Add(new SqlParameter("@IndexID", SqlDbType.Int));
                comm.Parameters["@IndexID"].Value = _IndexID;
                comm.Parameters.Add(new SqlParameter("@SiteName", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteName"].Value = _SiteName;
                comm.Parameters.Add(new SqlParameter("@SiteTitle", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteTitle"].Value = _SiteTitle;
                comm.Parameters.Add(new SqlParameter("@SiteKeyword", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteKeyword"].Value = _SiteKeyword;
                comm.Parameters.Add(new SqlParameter("@SiteDescription", SqlDbType.NVarChar, 250));
                comm.Parameters["@SiteDescription"].Value = _SiteDescription;
                comm.Parameters.Add(new SqlParameter("@SiteContentType", SqlDbType.NVarChar, 50));
                comm.Parameters["@SiteContentType"].Value = _SiteContentType;
                comm.Parameters.Add(new SqlParameter("@SiteUrl", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteUrl"].Value = _SiteUrl;
                comm.Parameters.Add(new SqlParameter("@SiteLogo", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteLogo"].Value = _SiteLogo;
                comm.Parameters.Add(new SqlParameter("@SiteCopyRight", SqlDbType.NVarChar, -1));
                comm.Parameters["@SiteCopyRight"].Value = _SiteCopyRight;
                comm.Parameters.Add(new SqlParameter("@SiteContact", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteContact"].Value = _SiteContact;
                comm.Parameters.Add(new SqlParameter("@SiteNotify", SqlDbType.NVarChar, 1000));
                comm.Parameters["@SiteNotify"].Value = _SiteNotify;
                comm.Parameters.Add(new SqlParameter("@MapCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@MapCode"].Value = _MapCode;
                comm.Parameters.Add(new SqlParameter("@StatisticsCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@StatisticsCode"].Value = _StatisticsCode;
                comm.Parameters.Add(new SqlParameter("@ShareCode", SqlDbType.NVarChar, -1));
                comm.Parameters["@ShareCode"].Value = _ShareCode;
                comm.Parameters.Add(new SqlParameter("@OtherMeta", SqlDbType.NVarChar, -1));
                comm.Parameters["@OtherMeta"].Value = _OtherMeta;
                comm.Parameters.Add(new SqlParameter("@ContactUs", SqlDbType.NVarChar, -1));
                comm.Parameters["@ContactUs"].Value = _ContactUs;
                comm.Parameters.Add(new SqlParameter("@IsSiteOpen", SqlDbType.Bit));
                comm.Parameters["@IsSiteOpen"].Value = _IsSiteOpen;
                comm.Parameters.Add(new SqlParameter("@ClosedInfo", SqlDbType.NVarChar, 250));
                comm.Parameters["@ClosedInfo"].Value = _ClosedInfo;
                comm.Parameters.Add(new SqlParameter("@ShowPageSize", SqlDbType.Int));
                comm.Parameters["@ShowPageSize"].Value = _ShowPageSize;
                comm.Parameters.Add(new SqlParameter("@AllowComment", SqlDbType.Bit));
                comm.Parameters["@AllowComment"].Value = _AllowComment;
                comm.Parameters.Add(new SqlParameter("@SiteLogoPath", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteLogoPath"].Value = _SiteLogoPath;
                comm.Parameters.Add(new SqlParameter("@ArticleImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ArticleImagePath"].Value = _ArticleImagePath;
                comm.Parameters.Add(new SqlParameter("@ProductImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ProductImagePath"].Value = _ProductImagePath;
                comm.Parameters.Add(new SqlParameter("@ADImagePath", SqlDbType.NVarChar, 100));
                comm.Parameters["@ADImagePath"].Value = _ADImagePath;
                comm.Parameters.Add(new SqlParameter("@ImgSize_S_W", SqlDbType.Int));
                comm.Parameters["@ImgSize_S_W"].Value = _ImgSize_S_W;
                comm.Parameters.Add(new SqlParameter("@ImgSize_S_H", SqlDbType.Int));
                comm.Parameters["@ImgSize_S_H"].Value = _ImgSize_S_H;
                comm.Parameters.Add(new SqlParameter("@ImgSize_M_W", SqlDbType.Int));
                comm.Parameters["@ImgSize_M_W"].Value = _ImgSize_M_W;
                comm.Parameters.Add(new SqlParameter("@ImgSize_M_H", SqlDbType.Int));
                comm.Parameters["@ImgSize_M_H"].Value = _ImgSize_M_H;
                comm.Parameters.Add(new SqlParameter("@SiteTheme", SqlDbType.NVarChar, 100));
                comm.Parameters["@SiteTheme"].Value = _SiteTheme;
                comm.Parameters.Add(new SqlParameter("@WM_Text", SqlDbType.NVarChar, 200));
                comm.Parameters["@WM_Text"].Value = _WM_Text;
                comm.Parameters.Add(new SqlParameter("@WM_Font", SqlDbType.NVarChar, 50));
                comm.Parameters["@WM_Font"].Value = _WM_Font;
                comm.Parameters.Add(new SqlParameter("@WM_FontSize", SqlDbType.Int));
                comm.Parameters["@WM_FontSize"].Value = _WM_FontSize;
                comm.Parameters.Add(new SqlParameter("@WM_Bottom", SqlDbType.Int));
                comm.Parameters["@WM_Bottom"].Value = _WM_Bottom;
                comm.Parameters.Add(new SqlParameter("@WM_Right", SqlDbType.Int));
                comm.Parameters["@WM_Right"].Value = _WM_Right;
                comm.Parameters.Add(new SqlParameter("@WM_Rotate", SqlDbType.Int));
                comm.Parameters["@WM_Rotate"].Value = _WM_Rotate;
                comm.Parameters.Add(new SqlParameter("@WM_Size", SqlDbType.Int));
                comm.Parameters["@WM_Size"].Value = _WM_Size;
                comm.Parameters.Add(new SqlParameter("@WM_Alpha", SqlDbType.Int));
                comm.Parameters["@WM_Alpha"].Value = _WM_Alpha;
                comm.Parameters.Add(new SqlParameter("@WM_Red", SqlDbType.Int));
                comm.Parameters["@WM_Red"].Value = _WM_Red;
                comm.Parameters.Add(new SqlParameter("@WM_Green", SqlDbType.Int));
                comm.Parameters["@WM_Green"].Value = _WM_Green;
                comm.Parameters.Add(new SqlParameter("@WM_Blue", SqlDbType.Int));
                comm.Parameters["@WM_Blue"].Value = _WM_Blue;
                comm.Parameters.Add(new SqlParameter("@WM_IsShow", SqlDbType.Bit));
                comm.Parameters["@WM_IsShow"].Value = _WM_IsShow;
                comm.Parameters.Add(new SqlParameter("@WM_Show_W", SqlDbType.Int));
                comm.Parameters["@WM_Show_W"].Value = _WM_Show_W;
                comm.Parameters.Add(new SqlParameter("@WM_Show_H", SqlDbType.Int));
                comm.Parameters["@WM_Show_H"].Value = _WM_Show_H;
                comm.Parameters.Add(new SqlParameter("@WM_Mode", SqlDbType.Bit));
                comm.Parameters["@WM_Mode"].Value = _WM_Mode;
                comm.Parameters.Add(new SqlParameter("@WM_ImagePath", SqlDbType.NVarChar, 200));
                comm.Parameters["@WM_ImagePath"].Value = _WM_ImagePath;
                comm.Parameters.Add(new SqlParameter("@SiteCounter", SqlDbType.Bit));
                comm.Parameters["@SiteCounter"].Value = _SiteCounter;
                comm.Parameters.Add(new SqlParameter("@SiteFlow", SqlDbType.Int));
                comm.Parameters["@SiteFlow"].Value = _SiteFlow;
                comm.Parameters.Add(new SqlParameter("@UrlExtension", SqlDbType.NVarChar, 50));
                comm.Parameters["@UrlExtension"].Value = _UrlExtension;
                comm.Parameters.Add(new SqlParameter("@IsBoundIP", SqlDbType.Bit));
                comm.Parameters["@IsBoundIP"].Value = _IsBoundIP;
                comm.Parameters.Add(new SqlParameter("@BoundIP", SqlDbType.NVarChar, -1));
                comm.Parameters["@BoundIP"].Value = _BoundIP;
                comm.Parameters.Add(new SqlParameter("@Target", SqlDbType.VarChar, 50));
                comm.Parameters["@Target"].Value = _Target;
                comm.Parameters.Add(new SqlParameter("@SearchType", SqlDbType.Int));
                comm.Parameters["@SearchType"].Value = _SearchType;
                comm.Parameters.Add(new SqlParameter("@ShowService", SqlDbType.Bit));
                comm.Parameters["@ShowService"].Value = _ShowService;
                comm.Parameters.Add(new SqlParameter("@ArticleTitleLength", SqlDbType.Int));
                comm.Parameters["@ArticleTitleLength"].Value = _ArticleTitleLength;
                comm.Parameters.Add(new SqlParameter("@Terms", SqlDbType.NVarChar, -1));
                comm.Parameters["@Terms"].Value = _Terms;
                comm.Parameters.Add(new SqlParameter("@Language", SqlDbType.VarChar, 10));
                comm.Parameters["@Language"].Value = _Language;
                comm.Parameters.Add(new SqlParameter("@pk_Config", SqlDbType.Int));
                comm.Parameters["@pk_Config"].Value = id;
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
            Sql.SqlQuery("delete from Site_Config where pk_Config=" + id);
        }

        #endregion
    }
}
