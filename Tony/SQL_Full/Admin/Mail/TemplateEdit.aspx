<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="TemplateEdit.aspx.cs" Inherits="Admin_Mail_TemplateEdit" %>

<%@ Register Src="../Controls/CKeditor.ascx" TagName="CKeditor" TagPrefix="MojoCube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            模板管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">模板管理</li>
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
                            <label><asp:Label ID="Label3" runat="server" Text="模板名称"></asp:Label></label>
                            <asp:TextBox ID="txtTemplateName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="form-group">
                            <label><asp:Label ID="Label1" runat="server" Text="邮件主题"></asp:Label></label>
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                  
                        <div class="form-group">
                            <label><asp:Label ID="Label2" runat="server" Text="替换说明"></asp:Label></label>
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
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


