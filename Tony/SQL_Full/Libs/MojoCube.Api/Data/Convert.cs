using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace MojoCube.Api.Data
{
    public class Convert
    {
        /// <summary>
        /// 转换为数据集
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataSet ToDataSet(DataTable dt)
        {
            DataSet ds = new DataSet();
            DataTable dtNew = null;
            dtNew = dt.Copy();
            ds.Tables.Add(dtNew);
            return ds;
        }
    }
}
