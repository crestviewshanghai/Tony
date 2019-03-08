using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MojoCube.Api.UI
{
    public class ColorPicker
    {
        public static string MiniColorPicker(string visual)
        {
            StringBuilder sb = new StringBuilder();
            visual = visual.ToLower();

            string[] colorList = new string[] { "", "#008000", "#ff0000", "#0000ff", "#ffff00", "#ff00ff", "#000000" };

            for (int i = 0; i < colorList.Length; i++)
            {
                if (visual == colorList[i] && colorList[i] != string.Empty)
                {
                    sb.Append("<div style='float:left; width:15px; height:15px; margin:0 2px; cursor:pointer; border:solid 2px #666; background:" + colorList[i] + "' onclick=\"colorPicker(this,'" + colorList[i] + "')\"></div>");
                }
                else if (colorList[i] == string.Empty)
                {
                    sb.Append("<div id='Null' style='float:left; width:15px; height:15px; margin-right:2px; cursor:pointer;' onclick=\"colorPicker(this,'" + colorList[i] + "')\" title='нч'></div>");
                }
                else
                {
                    sb.Append("<div style='float:left; width:15px; height:15px; margin:0 2px; cursor:pointer; background:" + colorList[i] + "' onclick=\"colorPicker(this,'" + colorList[i] + "')\"></div>");
                }
            }

            sb.Append("<input id='Binded' name='ColorPicker' type='hidden' value='" + visual + "' />");

            return sb.ToString();
        }
    }
}
