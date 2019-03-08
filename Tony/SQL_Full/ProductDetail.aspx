<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<%@ Register Src="WUC_Header.ascx" TagName="WUC_Header" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Menu.ascx" TagName="WUC_Menu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Banner.ascx" TagName="WUC_Banner" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Footer.ascx" TagName="WUC_Footer" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MobileMenu.ascx" TagName="WUC_MobileMenu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Service.ascx" TagName="WUC_Service" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Article.ascx" TagName="WUC_Article" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Contact.ascx" TagName="WUC_Contact" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Product.ascx" TagName="WUC_Product" TagPrefix="MojoCube" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
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

    <!-- 内容 -->
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 col-md-9" id="rightBox">
                <div class="positionBox">
                    <div class="titleBar">
                        <h1>当前位置</h1>
                        <span>
                            <a href="./">首页</a>
                             > 
                            <asp:HyperLink ID="hlTitle" runat="server" Text="商品中心"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <div class="col-sm-12 col-md-6 pad">
                    <div class="detailGlide">
                        <div id="ImageDiv" runat="server" class="slider"></div>
                        <div id="detailNav">
                        </div>
                    </div>

                    <script type="text/javascript">
                        var glide = $('.slider').glide({ navigationImg: true, navigation: "#detailNav" });
                        $(document).ready(function () {
                            $('.slider__wrapper').lightGallery({ selector: ".real" });
                        });
                    </script>

                    <script src="JS/picturefill.min.js"></script>

                    <script src="JS/lightgallery.js"></script>

                    <script src="JS/lg-fullscreen.js"></script>

                    <script src="JS/lg-thumbnail.js"></script>

                    <script src="JS/lg-video.js"></script>

                    <script src="JS/lg-autoplay.js"></script>

                    <script src="JS/lg-zoom.js"></script>

                    <script src="JS/lg-hash.js"></script>

                    <script src="JS/lg-pager.js"></script>

                </div>
                <div class="col-sm-12 col-md-6 pad">
                    <div class="detailTitle">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </div>
                    <div id="AttributeDiv" runat="server" class="detailParameter"></div>

                    <div class="detailUrl">
                        <asp:HyperLink ID="hlCart" runat="server"><span class="glyphicon glyphicon-shopping-cart"></span> 加入购物车</asp:HyperLink>
                    </div>
                    <div class="detailUrl">
                        <asp:HyperLink ID="hlFavorite" runat="server"><span class="glyphicon glyphicon-heart"></span> 收藏该商品</asp:HyperLink>
                    </div>

                </div>

                <div class="col-sm-12 col-md-12 pad">
                    <div class="detailTitleTxt">描述</div>
                    <div class="detailContent">
                        <div id="detailvalue0" runat="server"></div>
                    </div>
                </div>
                
                <div class="col-sm-12 col-md-12 pad">
                    <div class="detailTitleTxt">评论</div>
                    <div class="detailContent">
                        <div id="CommentDiv" runat="server"></div>
                    </div>
                </div>
                
                <div class="col-sm-12 col-md-12 otherPageBox">
                    <div id="PNDiv" runat="server" class='otherPage'></div>
                    <a class="back" href="javascript:history.go(-1)">返回</a>
                </div>

                <div class="col-sm-12 col-md-12 pad">
                    
                    <!-- 产品展示 -->
                    <MojoCube:WUC_Product id="WUC_Product" runat="server" />
                
                </div>
            </div>
            <div class="col-xs-12 col-sm-4 col-md-3">
                <div class="navigationBox" id="classification">
                    <div class="classTitleBar">
                        导航栏目
                    </div>
                    <div class="list">
                        <ul id="firstpane" runat="server"></ul>
                    </div>
                    <div id="BannerDiv" runat="server" class="telBox"></div>
                </div>
                
                <!-- 新闻中心 -->
                <MojoCube:WUC_Article id="WUC_Article" runat="server" />
                
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