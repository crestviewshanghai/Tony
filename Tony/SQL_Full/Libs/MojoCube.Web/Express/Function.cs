using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MojoCube.Web.Express
{
    public class Function
    {
        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="shipperCode">快递公司代码</param>
        /// <param name="logisticCode">快递单号</param>
        /// <returns></returns>
        public static DataTable GetLogisticDT(string shipperCode, string logisticCode)
        {
            DataTable dt = new DataTable();

            MojoCube.Web.Express.List list = new MojoCube.Web.Express.List();
            list.GetData("asc");

            if (list.TypeID == 0)
            {
                MojoCube.Web.Express.KdNiao kdn = new MojoCube.Web.Express.KdNiao();
                kdn.AppID = list.AppID;
                kdn.KeyCode = list.KeyCode;
                kdn.Gateway = list.Gateway;
                kdn.ShipperCode = shipperCode;
                kdn.LogisticCode = logisticCode;
                dt = MojoCube.Web.Express.KdNiao.GetDT(kdn.getOrderTracesByJson());
            }
            else
            {
                MojoCube.Web.Express.Kd100 kd100 = new MojoCube.Web.Express.Kd100();
                kd100.KeyCode = list.KeyCode;
                kd100.ShipperCode = shipperCode;
                kd100.LogisticCode = logisticCode;
                kd100.Gateway = list.Gateway;
                dt = MojoCube.Web.Express.Kd100.GetDT(kd100.getOrderTracesByJson());
            }

            return dt;
        }

        /// <summary>
        /// 获取物流信息
        /// </summary>
        /// <param name="typeId">0-快递鸟，1-快递100</param>
        /// <param name="shipperCode">快递公司代码</param>
        /// <param name="logisticCode">快递单号</param>
        /// <returns></returns>
        public static DataTable GetLogisticDT(int typeId, string shipperCode, string logisticCode)
        {
            DataTable dt = new DataTable();

            MojoCube.Web.Express.List list = new MojoCube.Web.Express.List();
            list.GetData(typeId, "asc");

            if (typeId == 0)
            {
                MojoCube.Web.Express.KdNiao kdn = new MojoCube.Web.Express.KdNiao();
                kdn.AppID = list.AppID;
                kdn.KeyCode = list.KeyCode;
                kdn.Gateway = list.Gateway;
                kdn.ShipperCode = shipperCode;
                kdn.LogisticCode = logisticCode;
                dt = MojoCube.Web.Express.KdNiao.GetDT(kdn.getOrderTracesByJson());
            }
            else
            {
                MojoCube.Web.Express.Kd100 kd100 = new MojoCube.Web.Express.Kd100();
                kd100.KeyCode = list.KeyCode;
                kd100.ShipperCode = shipperCode;
                kd100.LogisticCode = logisticCode;
                kd100.Gateway = list.Gateway;
                dt = MojoCube.Web.Express.Kd100.GetDT(kd100.getOrderTracesByJson());
            }

            return dt;
        }
    }
}
