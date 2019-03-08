using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MojoCube.Web.SMS
{
    public class Function
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="typeId">类型ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="pkId">单号ID（非必要，不用填0）</param>
        public static void Send(int typeId, int userId, int pkId)
        {
            //获取短信接口信息
            MojoCube.Web.SMS.List sms = new MojoCube.Web.SMS.List();
            sms.GetDataByType(typeId);

            if (sms.Visible)   //如果允许发送短信
            {
                MojoCube.Web.User.List user = new MojoCube.Web.User.List();
                user.GetData(userId);

                //短信结果
                string result = MojoCube.Web.SMS.Send.SendMsg(user.FullName, user.Phone1, sms.KeyCode, sms.Gateway, sms.AppID);

                MojoCube.Web.SMS.GetInfo info = new MojoCube.Web.SMS.GetInfo();
                info.GetContent(result);

                //短信记录
                MojoCube.Web.SMS.Log log = new MojoCube.Web.SMS.Log();
                log.fk_User = user.pk_User;
                log.fk_Department = user.fk_Department;
                log.fk_SMS = sms.pk_SMS;
                log.TableName = string.Empty;
                log.fk_ID = pkId;
                log.TypeID = sms.TypeID;
                log.Phone = user.Phone1;
                log.Contents = sms.Contents.Replace("#user#", user.FullName);
                log.Reason = info.reason;
                log.SID = info.sid;
                log.Fee = info.fee;
                log.Counts = info.count;
                log.Code = info.error_code;
                log.Result = result;
                log.CreateDate = DateTime.Now.ToString();
                log.InsertData();
            }
        }
    }
}
