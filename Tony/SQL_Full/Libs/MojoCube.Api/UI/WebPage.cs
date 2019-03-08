using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace MojoCube.Api.UI
{
    public class WebPage : System.Web.UI.Page
    {
        /// <summary>
        /// 利用SessionPageStatePersister将ViewState信息存储到服务器
        /// </summary>
        PageStatePersister _pers;
        protected override PageStatePersister PageStatePersister
        {
            get
            {
                if (_pers == null)
                {
                    _pers = new SessionPageStatePersister(this);
                }
                return _pers;
            }
        }
    }
}
