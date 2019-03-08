<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Order_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            订单管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">订单管理</li>
          </ol>
        </section>

        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
                  <asp:HyperLink ID="hlPrint" runat="server" NavigateUrl="javascript:McPrintHide('.box-title,.box-footer');"><span class="label label-primary"><i class="fa fa-print"></i> 打印</span></asp:HyperLink>
              </h3>
            </div>

            <div class="box-body">
              <div class="row">
              
                <div class="box-body">
                  <div class="mailbox-read-info">
                    <h5><asp:Label ID="lblTitle" runat="server" CssClass="mailbox-read-time"></asp:Label><asp:Label ID="lblDate" runat="server" CssClass="mailbox-read-time pull-right"></asp:Label></h5>
                  </div>
                  <div class="mailbox-read-message">
                      <asp:Label ID="lblDescription" runat="server"></asp:Label>
                      <asp:Label ID="lblHistory" runat="server"></asp:Label>
                      <asp:Label ID="lblComments" runat="server"></asp:Label>
                      <asp:Label ID="lblNote" runat="server"></asp:Label>
                  </div>
                </div>

              </div>

              <hr />

              <div class="row">
              
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="状态"></asp:Label></label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="金额"></asp:Label></label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="物流公司"></asp:Label></label>
                    <asp:DropDownList ID="ddlExpress" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="运单编号"></asp:Label></label>
                    <asp:TextBox ID="txtLogisticCode" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="订单编号"></asp:Label></label>
                    <asp:TextBox ID="txtNumber" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="商家备注"></asp:Label></label>
                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
              </div>

            </div>
            
            <div class="box-footer">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                <asp:Button ID="btnBack" runat="server" Text="返回" CssClass="btn btn-default" onclick="btnBack_Click"></asp:Button>
            </div>

          </div>

        </section>

      </div>

</asp:Content>


