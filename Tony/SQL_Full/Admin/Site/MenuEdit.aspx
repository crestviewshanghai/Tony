<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="MenuEdit.aspx.cs" Inherits="Admin_Site_MenuEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            网站导航
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">网站导航</li>
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
                    <label><asp:Label ID="Label1" runat="server" Text="名称"></asp:Label></label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="路径"></asp:Label></label>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="排序"></asp:Label></label>
                    <asp:TextBox ID="txtSortID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="类型"></asp:Label></label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="显示"></asp:Label></label>
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


