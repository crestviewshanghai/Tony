<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Payment_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            支付管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">支付管理</li>
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
                    <label><asp:Label ID="Label9" runat="server" Text="支付接口"></asp:Label></label>
                    <span class="tips">如：https://www.api.com/gateway.aspx</span>
                    <asp:TextBox ID="txtGateway" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="服务类型"></asp:Label></label>
                    <span class="tips">这个是识别是何接口实现何功能的标识，服务商提供</span>
                    <asp:TextBox ID="txtService" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="加密类型"></asp:Label></label>
                    <span class="tips">如：MD5</span>
                    <asp:TextBox ID="txtSignType" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="编码类型"></asp:Label></label>
                    <span class="tips">如：utf-8</span>
                    <asp:TextBox ID="txtInputCharset" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label7" runat="server" Text="货币类型"></asp:Label></label>
                    <span class="tips">如：RMB</span>
                    <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label8" runat="server" Text="最新汇率"></asp:Label></label>
                    <span class="tips">以人民币为基准，1人民币兑换的汇率</span>
                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label10" runat="server" Text="账号"></asp:Label></label>
                    <asp:TextBox ID="txtAccount" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="AppID"></asp:Label></label>
                    <asp:TextBox ID="txtAppID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="Secret"></asp:Label></label>
                    <asp:TextBox ID="txtSecret" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label13" runat="server" Text="PartnerID"></asp:Label></label>
                    <asp:TextBox ID="txtPartnerID" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label14" runat="server" Text="KeyCode"></asp:Label></label>
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
              
                <div class="row">
              
                    <hr />
              
                    <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label15" runat="server" Text="图标"></asp:Label></label>
                    <div class="showimg">
                        <asp:Image ID="imgMain" runat="server" Width="250px" style="display:none"></asp:Image>
                        <div class="showimg-del">
                            <asp:LinkButton ID="lnbRemoveImage" runat="server" onclick="lnbRemoveImage_Click" OnClientClick="{return confirm('确定删除图标吗？');}" Visible="false"><span class="label label-danger"><i class="fa fa-remove"></i> 移除</span></asp:LinkButton>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="btn btn-default btn-file">
                            <i class="fa fa-upload"></i> 上传图标
                            <asp:FileUpload ID="fuImage" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgMain);"></asp:FileUpload>
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


