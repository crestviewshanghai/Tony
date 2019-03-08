using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MojoCube.Api.UI
{
    public class AdminRadioButton
    {
        public static void CheckRBL(RadioButtonList rbl, bool bTure)
        {
            switch (bTure)
            {
                case false:
                    rbl.Items[0].Selected = true;
                    break;
                case true:
                    rbl.Items[1].Selected = true;
                    break;
            }
        }
    }
}
