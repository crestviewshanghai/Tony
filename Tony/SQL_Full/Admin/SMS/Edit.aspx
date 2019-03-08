<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_SMS_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            短信接口
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">短信接口</li>
          </ol>
        </section>

        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
              </h3>
            </div>

            <div class="box-body">
              <div class="row">
              
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="类型"></asp:Label></label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="标题"></asp:Label></label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="描述"></asp:Label></label>
                    <asp:TextBox ID="txtSubtitle" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="模板"></asp:Label></label>
                    <asp:TextBox ID="txtContents" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label9" runat="server" Text="请求地址"></asp:Label></label>
                    <span class="tips">如：https://www.api.com/gateway.aspx</span>
                    <asp:TextBox ID="txtGateway" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="模板ID"></asp:Label></label>
                    <asp:TextBox ID="txtAppID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label14" runat="server" Text="AppKey"></asp:Label></label>
                    <asp:TextBox ID="txtKeyCode" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label16" runat="server" Text="排序"></asp:Label></label>
                    <asp:TextBox ID="txtSortID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label17" runat="server" Text="使用"></asp:Label></label>
                    <br />
                    <asp:CheckBox ID="cbVisible" runat="server"></asp:CheckBox>
                  </div>
                  
              </div>
              
            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn btn-default" onclick="btnCancel_Click"></asp:Button>
            </div>

          </div>

        </section>

      </div>

</asp:Content>


