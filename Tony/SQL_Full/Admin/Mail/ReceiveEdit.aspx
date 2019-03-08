<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="ReceiveEdit.aspx.cs" Inherits="Admin_Mail_ReceiveEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            通知管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">通知管理</li>
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

            <div class="col-xs-12">
                <div class="box-body">
                    <div class="row">
                    
                        <div class="form-group">
                            <asp:DropDownList ID="ddlAccount" runat="server" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                        
                        <div class="form-group">
                            <label><asp:Label ID="Label3" runat="server" Text="接收邮件"></asp:Label></label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="form-group">
                            <label><asp:Label ID="Label1" runat="server" Text="昵称"></asp:Label></label>
                            <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="form-group">
                            <label><asp:Label ID="Label2" runat="server" Text="备注"></asp:Label></label>
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                  
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


