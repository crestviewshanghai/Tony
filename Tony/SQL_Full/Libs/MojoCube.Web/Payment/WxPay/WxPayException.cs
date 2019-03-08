using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MojoCube.Web.Payment.WxPay
{
    /// <summary>
    /// WxPayException 的摘要说明
    /// </summary>
    public class WxPayException : Exception
    {
        public WxPayException(string msg)
            : base(msg)
        {

        }
    }
}
