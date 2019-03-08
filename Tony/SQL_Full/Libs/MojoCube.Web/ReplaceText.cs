using System;
using System.Collections.Generic;
using System.Text;

namespace MojoCube.Web
{
    public class ReplaceText
    {
        #region  公共属性
        string _TrueName;
        public string TrueName
        {
            get { return _TrueName; }
            set { _TrueName = value; }
        }
        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        string _CheckCode;
        public string CheckCode
        {
            get { return _CheckCode; }
            set { _CheckCode = value; }
        }
        string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        string _Price;
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        string _Amount;
        public string Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        string _Qty;
        public string Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        string _Total;
        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        string _TrackingNumber;
        public string TrackingNumber
        {
            get { return _TrackingNumber; }
            set { _TrackingNumber = value; }
        }
        #endregion

        #region  公共方法

        /// <summary>
        /// 替换内容
        /// </summary>
        /// <param name="content">原内容</param>
        /// <returns></returns>
        public string Replace(string content)
        {
            content = content.Replace("[TrueName]", _TrueName);
            content = content.Replace("[FirstName]", _FirstName);
            content = content.Replace("[LastName]", _LastName);
            content = content.Replace("[UserName]", _UserName);
            content = content.Replace("[Password]", _Password);
            content = content.Replace("[CheckCode]", _CheckCode);
            content = content.Replace("[ProductName]", _ProductName);
            content = content.Replace("[Description]", _Description);
            content = content.Replace("[Price]", _Price);
            content = content.Replace("[Amount]", _Amount);
            content = content.Replace("[Qty]", _Qty);
            content = content.Replace("[Total]", _Total);
            content = content.Replace("[TrackingNumber]", _TrackingNumber);
            return content;
        }

        /// <summary>
        /// 截取需要重复替换的内容
        /// </summary>
        /// <param name="strStart">开始标签</param>
        /// <param name="strEnd">结束标签</param>
        /// <param name="content">原内容</param>
        /// <returns></returns>
        public string GetRepeat(string strStart, string strEnd, string content)
        {
            int start = content.IndexOf(strStart);
            string repeatText = string.Empty;
            if (start > 0)
            {
                repeatText = content.Substring(start, content.IndexOf(strEnd, start + 1) - start) + strEnd;
            }
            return repeatText;
        }

        #endregion
    }
}
