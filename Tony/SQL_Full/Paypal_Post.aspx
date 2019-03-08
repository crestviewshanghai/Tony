<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paypal_Post.aspx.cs" Inherits="Paypal_Post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            document.forms.PayPal.submit();
        }
    </script>
</head>
<body>

    <form id="PayPal" action="<%=strUrl%>" method="post" target="_blank">
        <input type="hidden" name="cmd" value="_xclick" /> 
        <input type="hidden" name="business" value="<%=business%>" />
        <input type="hidden" name="item_name" value="<%=item_name%>" />
        <input type="hidden" name="item_number" value="<%=ordersn%>" />
        <input type="hidden" name="amount" value="<%=amount%>" />
        <input type="hidden" name="currency_code" value="<%=currency_code%>" />
        <input type="hidden" name="on0" value="Customer" />
        <input type="hidden" name="os0" value="<%=username%>" />
        <input type="hidden" name="notify_url" value="<%=notify_url%>" />
        <input type="hidden" name="cancel_return" value="<%=cancel_return%> " />
        <input type="hidden" name="return" value="<%=success_return%>" />
        <input name="Paypal" type="button" value="PayPal付款" style="display:none;" />
    </form> 

</body>
</html>
