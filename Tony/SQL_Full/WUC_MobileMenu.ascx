<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_MobileMenu.ascx.cs" Inherits="WUC_MobileMenu" %>

<nav class="navbar navbar-default navbar-fixed-bottom footer_nav">
    <div class="foot_nav btn-group dropup">
        <a class="dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" href="#">
            <span class="glyphicon glyphicon-share btn-lg" aria-hidden="true"></span>分享
        </a>
        <div class="dropdown-menu webshare">
            <div id="ShareDiv" runat="server" style="padding:0 0 8px 8px;"></div>
        </div>
    </div>
    <div class="foot_nav"><a href="<%=phoneNumber%>"><span class="glyphicon glyphicon-phone btn-lg" aria-hidden="true"></span>手机</a></div>
    <div class="foot_nav"><a id="gotocate" href="#"><span class="glyphicon glyphicon-th-list btn-lg" aria-hidden="true"></span>分类</a></div>
    <div class="foot_nav"><a id="gototop" href="#"><span class="glyphicon glyphicon-circle-arrow-up btn-lg" aria-hidden="true"></span>顶部</a></div>
</nav>

