using System;
using System.Collections.Generic;
using System.Text;

namespace MojoCube.Api.Date
{
    public class Get
    {
        /// <summary>
        /// 获取中文星期
        /// </summary>
        /// <returns></returns>
        public static string ChineseWeek()
        {
            string enWeek = DateTime.Now.DayOfWeek.ToString();
            string value = "";
            switch (enWeek)
            {
                case "Monday":
                    value = "星期一";
                    break;
                case "Tuesday":
                    value = "星期二";
                    break;
                case "Wednesday":
                    value = "星期三";
                    break;
                case "Thursday":
                    value = "星期四";
                    break;
                case "Friday":
                    value = "星期五";
                    break;
                case "Saturday":
                    value = "星期六";
                    break;
                case "Sunday":
                    value = "星期日";
                    break;
            }
            return value;
        }

        /// <summary>
        /// 输入几月第几个星期几，获得具体日期 start:GetWeekDate("2011|3|2|Sunday|02:00:00") / end:GetWeekDate("2011|11|1|Sunday|02:00:00")
        /// </summary>
        /// <param name="strTime">字符串</param>
        /// <returns></returns>
        private DateTime WeekDate(string strTime)
        {
            DateTime nTime = DateTime.Now;

            if (strTime.Length > 1)
            {
                int y = int.Parse(strTime.Split('|')[0]);
                int m = int.Parse(strTime.Split('|')[1]);
                int w = int.Parse(strTime.Split('|')[2]);
                string sWeek = strTime.Split('|')[3];
                string h = strTime.Split('|')[4];

                int week = 0;
                int j = DateTime.DaysInMonth(y, m);

                if (w == 0) //0表示最后一个星期几
                {
                    for (int i = 0; i < j; i++)
                    {
                        if (Convert.ToDateTime(y + "-" + m + "-" + (i + 1).ToString() + " " + h).DayOfWeek.ToString() == sWeek)
                        {
                            w++;
                        }
                    }
                }

                for (int i = 0; i < j; i++)
                {
                    DateTime now = Convert.ToDateTime(y + "-" + m + "-" + (i + 1).ToString() + " " + h);
                    if (now.DayOfWeek.ToString() == sWeek)
                    {
                        week++;
                        if (week == w)
                        {
                            nTime = now;
                        }
                    }
                }
            }

            return nTime;
        }

    }
}
