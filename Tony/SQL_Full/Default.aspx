<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="WUC_Header.ascx" TagName="WUC_Header" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Menu.ascx" TagName="WUC_Menu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Banner.ascx" TagName="WUC_Banner" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Footer.ascx" TagName="WUC_Footer" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MobileMenu.ascx" TagName="WUC_MobileMenu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Service.ascx" TagName="WUC_Service" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Contact.ascx" TagName="WUC_Contact" TagPrefix="MojoCube" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="applicable-device" content="pc,mobile" />
    <title></title>
</head>

<body>

    <!--[if lt IE 9]>
        <script src="JS/html5shiv.min.js" type="text/javascript"></script>
        <script src="JS/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    
    <header>

        <!-- LOGO、语言、搜索 -->
        <MojoCube:WUC_Header id="WUC_Header" runat="server" />
        
        <!-- 导航菜单 -->
        <MojoCube:WUC_Menu id="WUC_Menu" runat="server" />

    </header>
    
    <!-- Banner -->
    <MojoCube:WUC_Banner id="WUC_Banner" runat="server" />

    <div class="container" style="padding:10px 0px;">
        <div class="row" style="display:none">
            <div class="col-xs-12 col-sm-8 col-md-9" id="rightBox">
                <div class="productBox">
                    <div id="ProductDiv" runat="server" class="list"></div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-3">
                <div id="classification">
                    <div class="navigationBox">
                        <div class="classTitleBar">
                            品牌分类
                        </div>
                        <div class="list">
                            <ul id="firstpane" runat="server" class="indexFirstpane"></ul>
                        </div>
                        <div id="BannerDiv" runat="server" class="telBox"></div>
                    </div>
                </div>
            </div>
        </div>


        <div class="post-block-container">
            <a title="日本“殿堂级”设计大师，扎堆拍了部大片连火7年！竟是为孩子们......" class="post-block ng-scope" href="Product.aspx">
                <div class="post-category cat3">
                    <div class="post-category-title ng-binding">匠心独具</div>
                </div>
                <div class="post-cover"style="display: block; background-image: url('Files/Site/Banner/2016070321450453121879.jpg');"></div>
                <div class="padder padder-v-sm post-title font-bold ng-binding">日本“殿堂级”设计大师，扎堆拍了部大片连火7年！竟是为孩子们......</div>
            </a>
            <a title="日本竟然有这样的童话村庄...中国游客还未发现！" class="post-block ng-scope" href="Product.aspx">
              <div class="post-category cat5">
                <div class="post-category-title ng-binding">边走边看</div>
              </div>
              <div class="post-cover"style="display: block; background-image: url('Files/Site/Banner/2016070321450453121879.jpg');"></div>
              <div class="padder padder-v-sm post-title font-bold ng-binding">日本竟然有这样的童话村庄...中国游客还未发现！</div>
            </a>
        </div>





    </div>
    <div id="AboutDiv" runat="server" class="aboutBg" style="display:none;"></div>
    <div class="container" style="display:none;">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-8">
                <div class="newsBox">
                    <div class="titleBar">
                        <h1>新闻中心</h1>
                        <span>/News center</span> 
                        <asp:HyperLink ID="hlMore" runat="server" CssClass="rightMore">+More</asp:HyperLink>
                    </div>
                    <div class="firstNewsBox">
                        <asp:Image ID="imgArticle" runat="server" />
                        <span>
                            <asp:HyperLink ID="hlArticleTitle" runat="server"></asp:HyperLink>
                        </span>
                        <p>
                            <asp:Label ID="lblArticleSubtitle" runat="server"></asp:Label>
                        </p>
                        <span>
                            <asp:HyperLink ID="hlArticleDetail" runat="server" CssClass="more">查看详情 >></asp:HyperLink>
                        </span>
                    </div>
                    <ul id="ArticleUL" runat="server" class="newsList"></ul>
                </div>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-4">
            
                <!-- 联系我们 -->
                <MojoCube:WUC_Contact id="WUC_Contact" runat="server" />

            </div>
        </div>


        



    </div>

    <!-- 底部菜单、版权信息 -->
    <footer>
        <MojoCube:WUC_Footer id="WUC_Footer" runat="server" />
    </footer>
    
    <!--手机菜单-->
    <MojoCube:WUC_MobileMenu id="WUC_MobileMenu" runat="server" />

    <!--客服面板-->
    <MojoCube:WUC_Service id="WUC_Service" runat="server" />

</body>
</html>