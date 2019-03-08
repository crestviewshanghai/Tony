<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Nav.ascx.cs" Inherits="Admin_Article_Nav" %>

<div class="col-md-3">
    <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-primary btn-block margin-bottom"><i class="fa fa-pencil"></i> 新增文章</asp:HyperLink>
    <div class="box box-solid">
    <div class="box-header with-border">
        <h3 class="box-title">分类</h3>
        <asp:HyperLink ID="hlCategory" runat="server">[管理]</asp:HyperLink>
        <div class="box-tools">
        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
        </div>
    </div>
    <div id="NavDiv" runat="server" class="box-body no-padding">

    </div>
    </div>
</div>
