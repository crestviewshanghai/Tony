<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxPay.aspx.cs" Inherits="WxPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript">

        var appId = '<%=appId%>';
        var prepayId = '<%=prepayId%>';
        var nonceStr = '<%=nonceStr%>';
        var timeStamp = '<%=timeStamp%>';
        var sign = '<%=sign%>';

        function onBridgeReady() {
            WeixinJSBridge.invoke(
                'getBrandWCPayRequest', {
                    "appId": appId,     //公众号名称，由商户传入     
                    "timeStamp": timeStamp,         //时间戳，自1970年以来的秒数     
                    "nonceStr": nonceStr, //随机串     
                    "package": "prepay_id=" + prepayId,
                    "signType": "MD5",         //微信签名方式  
                    "paySign": sign //微信签名 
                },
                function (res) {
                    // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                    switch (res.err_msg) {
                        case "get_brand_wcpay_request:ok":
                            alert("支付成功");
                            break;
                        case "get_brand_wcpay_request:cancel":
                            alert("支付取消");
                            break;
                        default:
                            alert("支付失败");
                            break;
                    }
                }
            );
        }

        if (typeof WeixinJSBridge == "undefined") {
            if (document.addEventListener) {
                document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
            } else if (document.attachEvent) {
                document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
                document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
            }
        } else {
            onBridgeReady();
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
