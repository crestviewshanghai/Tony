using System;
using System.Collections.Generic;
using System.Text;

namespace MojoCube.Api.Math
{
    public class Array
    {
        //数字排序
        public static int[] iSortArray(int[] arr1)
        {
            int j, temp;
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                j = i + 1;
            aa:
                if (arr1[i] > arr1[j])
                {
                    temp = arr1[i];
                    arr1[i] = arr1[j];
                    arr1[j] = temp;
                    goto aa;
                }
                else if (j < arr1.Length - 1)
                {
                    j++;
                    goto aa;
                }
            }
            return arr1;
        }

        //输入一个数组，合并相同元素，并统计元素数：如 >> {1,2,3,2,2,3,1,1,2,1} >> {1[4],2[4],3[2]}
        public static int intCount(int[] intList)
        {
            int ic = 0;

            Dictionary<int, int> statDic = new Dictionary<int, int>();
            foreach (int i in intList)
            {
                //还不存在于statDic中
                if (!statDic.ContainsKey(i))
                {
                    statDic.Add(i, 1);
                }
                else    //已经存在了，就在value中加一
                {
                    statDic[i] += 1;
                }
            }

            foreach (int key in statDic.Keys)
            {
                //Console.WriteLine("{0} -> {1}", key.ToString(), statDic[key].ToString());
                ic++;
            }

            return ic;
        }

        //删除数组中相同的数据，如 string[]{"aa","bb","bb","cc"} --> string[]{"aa","bb","cc"}
        public static string[] MergeArray(string[] arr)
        {
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            foreach (string s in arr)
            {
                if (list.Contains(s)) continue;
                list.Add(s);
            }
            return list.ToArray();
        }

    }
}
