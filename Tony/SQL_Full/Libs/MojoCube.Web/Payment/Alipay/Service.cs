using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections;

namespace MojoCube.Web.Payment.Alipay
{
    /// <summary>
    /// 类名：alipay_service
    /// 功能：支付宝外部服务接口控制
    /// 详细：该页面是请求参数核心处理文件，不需要修改
    /// 版本：3.0
    /// 修改日期：2010-06-30
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考
    /// </summary>
    public class Service
    {
        private string gateway = "";                //网关地址
        private string _key = "";                    //交易安全校验码
        private string _input_charset = "";         //编码格式
        private string _sign_type = "";              //加密方式（签名方式）
        private string mysign = "";                 //加密结果（签名结果）
        private ArrayList sPara = new ArrayList();  //需要加密的已经过滤后的参数数组

        /// <summary>
        /// 构造函数
        /// 从配置文件及入口文件中初始化变量
        /// </summary>
        /// <param name="partner">合作身份者ID</param>
        /// <param name="seller_email">签约支付宝账号或卖家支付宝帐户</param>
        /// <param name="return_url">付完款后跳转的页面 要用 以http开头格式的完整路径，不允许加?id=123这类自定义参数</param>
        /// <param name="notify_url">交易过程中服务器通知的页面 要用 以http开格式的完整路径，不允许加?id=123这类自定义参数</param>
        /// <param name="show_url">网站商品的展示地址，不允许加?id=123这类自定义参数</param>
        /// <param name="out_trade_no">请与贵网站订单系统中的唯一订单号匹配</param>
        /// <param name="subject">订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。</param>
        /// <param name="body">订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里</param>
        /// <param name="price">订单总金额，显示在支付宝收银台里的“商品单价”里</param>
        /// <param name="logistics_fee">物流费用，即运费。</param>
        /// <param name="logistics_type">物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）</param>
        /// <param name="logistics_payment">物流支付方式，三个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）</param>
        /// <param name="quantity">商品数量，建议默认为1，不改变值，把一次交易看成是一次下订单而非购买一件商品。</param>
        /// <param name="receive_name">收货人姓名，如：张三</param>
        /// <param name="receive_address">收货人地址，如：XX省XXX市XXX区XXX路XXX小区XXX栋XXX单元XXX号</param>
        /// <param name="receive_zip">收货人邮编，如：123456</param>
        /// <param name="receive_phone">收货人电话号码，如：0571-81234567</param>
        /// <param name="receive_mobile">收货人手机号码，如：13312341234</param>
        /// <param name="logistics_fee_1">第二组物流费用，即运费。</param>
        /// <param name="logistics_type_1">第二组物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）</param>
        /// <param name="logistics_payment_1">第二组物流支付方式，三个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）</param>
        /// <param name="logistics_fee_2">第三组物流费用，即运费。</param>
        /// <param name="logistics_type_2">第三组物流类型，三个值可选：EXPRESS（快递）、POST（平邮）、EMS（EMS）</param>
        /// <param name="logistics_payment_2">第三组物流支付方式，三个值可选：SELLER_PAY（卖家承担运费）、BUYER_PAY（买家承担运费）</param>
        /// <param name="buyer_email">默认买家支付宝账号</param>
        /// <param name="discount">折扣，是具体的金额，而不是百分比。若要使用打折，请使用负数，并保证小数点最多两位数</param>
        /// <param name="key">安全检验码</param>
        /// <param name="input_charset">字符编码格式 目前支持 gb2312 或 utf-8</param>
        /// <param name="sign_type">加密方式 不需修改</param>
        public Service(string partner,
            string seller_email,
            string return_url,
            string notify_url,
            string show_url,
            string out_trade_no,
            string subject,
            string body,
            string price,
            string logistics_fee,
            string logistics_type,
            string logistics_payment,
            string quantity,
            string receive_name,
            string receive_address,
            string receive_zip,
            string receive_phone,
            string receive_mobile,
            string logistics_fee_1,
            string logistics_type_1,
            string logistics_payment_1,
            string logistics_fee_2,
            string logistics_type_2,
            string logistics_payment_2,
            string buyer_email,
            string discount,
            string key,
            string input_charset,
            string sign_type,
            string service)
        {
            gateway = "https://www.alipay.com/cooperate/gateway.do?";
            _key = key.Trim();
            _input_charset = input_charset.ToLower();
            _sign_type = sign_type.ToUpper();

            //构造加密参数数组，以下顺序请不要更改（由a到z排序）
            sPara.Add("_input_charset=" + _input_charset);
            sPara.Add("body=" + body);
            sPara.Add("buyer_email=" + buyer_email);
            sPara.Add("discount=" + discount);
            sPara.Add("logistics_fee=" + logistics_fee);
            sPara.Add("logistics_fee_1=" + logistics_fee_1);
            sPara.Add("logistics_fee_2=" + logistics_fee_2);
            sPara.Add("logistics_payment=" + logistics_payment);
            sPara.Add("logistics_payment_1=" + logistics_payment_1);
            sPara.Add("logistics_payment_2=" + logistics_payment_2);
            sPara.Add("logistics_type=" + logistics_type);
            sPara.Add("logistics_type_1=" + logistics_type_1);
            sPara.Add("logistics_type_2=" + logistics_type_2);
            sPara.Add("notify_url=" + notify_url);
            sPara.Add("out_trade_no=" + out_trade_no);
            sPara.Add("partner=" + partner);
            sPara.Add("payment_type=1");
            sPara.Add("price=" + price);
            sPara.Add("quantity=" + quantity);
            sPara.Add("receive_address=" + receive_address);
            sPara.Add("receive_mobile=" + receive_mobile);
            sPara.Add("receive_name=" + receive_name);
            sPara.Add("receive_phone=" + receive_phone);
            sPara.Add("receive_zip=" + receive_zip);
            sPara.Add("return_url=" + return_url);
            sPara.Add("seller_email=" + seller_email);
            //sPara.Add("service=create_partner_trade_by_buyer");
            sPara.Add("service=" + service);
            sPara.Add("show_url=" + show_url);
            sPara.Add("subject=" + subject);
            //构造加密参数数组，以上顺序请不要更改（由a到z排序）

            sPara = Function.Para_filter(sPara);
            //获得签名结果
            mysign = Function.Build_mysign(sPara, _key, _sign_type, _input_charset);
        }

        /// <summary>
        /// 构造请求URL（GET方式请求）
        /// </summary>
        /// <returns>请求url</returns>
        public string Create_url()
        {
            string strUrl = gateway;
            string arg = Function.Create_linkstring_urlencode(sPara);	//把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            strUrl = strUrl + arg + "sign=" + mysign + "&sign_type=" + _sign_type;
            return strUrl;
        }

        /// <summary>
        /// 构造Post表单提交HTML（POST方式请求）
        /// </summary>
        /// <returns>输出 表单提交HTML文本</returns>
        public string Build_postform()
        {
            StringBuilder sbHtml = new StringBuilder();
            sbHtml.Append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + gateway + "_input_charset=" + _input_charset + "\" method=\"post\">");

            int nCount = sPara.Count;
            int i;
            for (i = 0; i < nCount; i++)
            {
                //把sArray的数组里的元素格式：变量名=值，分割开来
                int nPos = sPara[i].ToString().IndexOf('=');              //获得=字符的位置
                int nLen = sPara[i].ToString().Length;                    //获得字符串长度
                string itemName = sPara[i].ToString().Substring(0, nPos); //获得变量名
                string itemValue = "";                                    //获得变量的值
                if (nPos + 1 < nLen)
                {
                    itemValue = sPara[i].ToString().Substring(nPos + 1);
                }

                sbHtml.Append("<input type=\"hidden\" name=\"" + itemName + "\" value=\"" + itemValue + "\"/>");
            }

            sbHtml.Append("<input type=\"hidden\" name=\"sign\" value=\"" + mysign + "\"/>");
            sbHtml.Append("<input type=\"hidden\" name=\"sign_type\" value=\"" + _sign_type + "\"/></form>");

            sbHtml.Append("<input type=\"button\" name=\"v_action\" value=\"支付宝确认付款\" onClick=\"document.forms['alipaysubmit'].submit();\">");

            return sbHtml.ToString();
        }
    }
}
