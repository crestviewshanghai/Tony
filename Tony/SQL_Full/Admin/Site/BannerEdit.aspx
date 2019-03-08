<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="BannerEdit.aspx.cs" Inherits="Admin_Site_BannerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            网站横幅
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">网站横幅</li>
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
                    <label><asp:Label ID="Label5" runat="server" Text="类型"></asp:Label></label>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label1" runat="server" Text="标题"></asp:Label></label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="排序"></asp:Label></label>
                    <asp:TextBox ID="txtSortID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="链接"></asp:Label></label>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="描述"></asp:Label></label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="显示"></asp:Label></label>
                    <br />
                    <asp:CheckBox ID="cbVisible" runat="server"></asp:CheckBox>
                  </div>
                  
              </div>
              
            <div class="row">
              
                <hr />
              
                <div class="col-md-6 form-group">
                <label><asp:Label ID="Label25" runat="server" Text="横幅图片"></asp:Label></label>
                <div class="showimg">
                    <asp:Image ID="imgBanner" runat="server" Width="250px" style="display:none"></asp:Image>
                    <div class="showimg-del">
                        <asp:LinkButton ID="lnbRemoveImage" runat="server" onclick="lnbRemoveImage_Click" OnClientClick="{return confirm('确定删除图片吗？');}" Visible="false"><span class="label label-danger"><i class="fa fa-remove"></i> 移除</span></asp:LinkButton>
                    </div>
                </div>
                <div class="form-group">
                    <div class="btn btn-default btn-file">
                        <i class="fa fa-upload"></i> 上传图片
                        <asp:FileUpload ID="fuBanner" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgBanner);"></asp:FileUpload>
                    </div>
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


