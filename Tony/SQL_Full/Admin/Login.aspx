<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Login</title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link rel="shortcut icon" href="Images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="Skins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Css/font-awesome.min.css" />
    <link rel="stylesheet" href="Css/ionicons.min.css" />
    <link rel="stylesheet" href="Skins/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="Skins/dist/css/skins/skin-blue.min.css" />
    <link rel="stylesheet" href="Skins/plugins/iCheck/flat/blue.css" />
    <!--[if lt IE 9]>
        <script src="JS/html5shiv.min.js"></script>
        <script src="JS/respond.min.js"></script>
    <![endif]-->
    
    <script type="text/javascript">
        function ChangeImage() {
            var now = new Date();
            var number = now.getSeconds();
            document.getElementById('CodeImage').src = "Identify/CheckCode.aspx?id=" + number;
        }
    </script>
         
  </head>

  <body class="hold-transition login-page" style="background:url(Images/login_bg.jpg) no-repeat #222D32; background-size:100%;">
    <div class="login-box">

      <div class="login-logo">
        <a href="http://www.mojocube.com/" target="_blank"><img src="images/logo.png" /></a>
      </div>

      <div class="login-box-body" style="border-radius:10px; box-shadow: 1px 1px 1px 1px #333;">
        <p class="login-box-msg">开启购物新模式！</p>
        <form id="form1" runat="server">
        
          <div id="AlertDiv" runat="server"></div>

          <div class="form-group has-feedback">
             <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="用户名"></asp:TextBox>
             <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>

          <div class="form-group has-feedback">
             <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="密码" TextMode="Password"></asp:TextBox>
             <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          
          <div class="form-group has-feedback">
             <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" placeholder="验证码" style="width:210px; display:inline;"></asp:TextBox>
             <asp:HyperLink ID="hlChange" runat="server" ToolTip="看不清？点击换一张图片" NavigateUrl="javascript:ChangeImage();" style=""><img id="CodeImage" src="Identify/CheckCode.aspx" alt="" style="height:32px; margin-top:-3px; width:106px;" /></asp:HyperLink>
          </div>

          <div class="row">

            <div class="col-xs-8">
              <div class="checkbox icheck">
                 <asp:CheckBox ID="cbRemember" runat="server" /> 记住我
              </div>
            </div>

            <div class="col-xs-4">
                <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="btn btn-primary btn-block btn-flat" onclick="btnLogin_Click" />
            </div>

          </div>

        </form>

      </div>
    </div>

    <script src="Skins/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <script src="Skins/bootstrap/js/bootstrap.min.js"></script>
    <script src="Skins/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_flat-blue',
                radioClass: 'iradio_flat-blue',
                increaseArea: '20%'
            });
        });
    </script>

  </body>
</html>