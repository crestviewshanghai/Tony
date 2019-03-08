<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Comment_Edit" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            留言管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">留言管理</li>
          </ol>
        </section>

        <section class="content">

          <div id="AlertDiv" runat="server"></div>

          <div class="box box-default">
            <div class="box-header with-border">
              <h3 class="box-title">
                  <asp:HyperLink ID="hlBack" runat="server"><span class="label label-back"><i class="fa fa-chevron-left"></i> 返回</span></asp:HyperLink>
                  <asp:HyperLink ID="hlPrint" runat="server" NavigateUrl="javascript:McPrintHide('.box-title,.col-xs-12,.box-footer');"><span class="label label-primary"><i class="fa fa-print"></i> 打印</span></asp:HyperLink>
              </h3>
            </div>

            <div class="box-body">
                <div class="mailbox-read-info">
                <h3><asp:Label ID="lblTitle" runat="server"></asp:Label></h3>
                <h5><asp:Label ID="lblFrom" runat="server" CssClass="mailbox-read-time"></asp:Label><asp:Label ID="lblDate" runat="server" CssClass="mailbox-read-time pull-right"></asp:Label></h5>
                </div>
                <div class="mailbox-read-message">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </div>
            </div>
            
            <div class="col-xs-12">
                <div class="box-body">
                    <div class="row">
                    
                        <div class="form-group">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control select2"></asp:DropDownList>
                        </div>

                        <MojoCube:CKeditor id="txtDescription" runat="server" />

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


