using System;
using System.Collections.Generic;
using System.Text;

namespace MojoCube.Api.Date
{
    public class Get
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public static string ChineseWeek()
        {
            string enWeek = DateTime.Now.DayOfWeek.ToString();
            string value = "";
            switch (enWeek)
            {
                case "Monday":
                    value = "����һ";
                    break;
                case "Tuesday":
                    value = "���ڶ�";
                    break;
                case "Wednesday":
                    value = "������";
                    break;
                case "Thursday":
                    value = "������";
                    break;
                case "Friday":
                    value = "������";
                    break;
                case "Saturday":
                    value = "������";
                    break;
                case "Sunday":
                    value = "������";
                    break;
            }
            return value;
        }

        /// <summary>
        /// ���뼸�µڼ������ڼ�����þ������� start:GetWeekDate("2011|3|2|Sunday|02:00:00") / end:GetWeekDate("2011|11|1|Sunday|02:00:00")
        /// </summary>
        /// <param name="strTime">�ַ���</param>
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

                if (w == 0) //0��ʾ���һ�����ڼ�
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
