<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_User_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            用户管理
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">用户管理</li>
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
                    <label><asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label2" runat="server" Text="电话"></asp:Label></label>
                    <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label3" runat="server" Text="真实姓名"></asp:Label></label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label4" runat="server" Text="昵称"></asp:Label></label>
                    <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label5" runat="server" Text="Email"></asp:Label></label>
                    <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label10" runat="server" Text="地址"></asp:Label></label>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label6" runat="server" Text="学历"></asp:Label></label>
                    <asp:TextBox ID="txtEducation" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label7" runat="server" Text="毕业院校"></asp:Label></label>
                    <asp:TextBox ID="txtSchool" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label8" runat="server" Text="身份证号"></asp:Label></label>
                    <asp:TextBox ID="txtIDNumber" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label9" runat="server" Text="银行账号"></asp:Label></label>
                    <asp:TextBox ID="txtBankAccount" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label11" runat="server" Text="部门"></asp:Label></label>
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label16" runat="server" Text="性别"></asp:Label></label>
                    <asp:DropDownList ID="ddlSex" runat="server" CssClass="form-control select2">
                        <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label18" runat="server" Text="职位"></asp:Label></label>
                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label12" runat="server" Text="角色"></asp:Label></label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control select2"></asp:DropDownList>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label13" runat="server" Text="工资"></asp:Label></label>
                    <asp:TextBox ID="txtWages" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label14" runat="server" Text="入职时间"></asp:Label></label>
                    <asp:TextBox ID="txtEntryTime" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label20" runat="server" Text="生日"></asp:Label></label>
                    <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label15" runat="server" Text="皮肤"></asp:Label></label>
                    <asp:DropDownList ID="ddlSkin" runat="server" CssClass="form-control select2">
                        <asp:ListItem Text="经典蓝" Value="blue" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="青草绿" Value="green"></asp:ListItem>
                        <asp:ListItem Text="中国红" Value="red"></asp:ListItem>
                        <asp:ListItem Text="商务黄" Value="yellow"></asp:ListItem>
                        <asp:ListItem Text="高贵紫" Value="purple"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                  
              </div>
              
              <div id="EditDiv" runat="server" class="row" visible="false">
              
                  <hr />
              
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label17" runat="server" Text="头像"></asp:Label></label>
                    <div class="user-edit-image"><asp:Image ID="imgPortrait" runat="server"></asp:Image></div>
                    <div class="form-group">
                        <div class="btn btn-default btn-file">
                            <i class="fa fa-upload"></i> 上传头像
                            <asp:FileUpload ID="fuPortrait" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgPortrait);"></asp:FileUpload>
                        </div>
                        <p class="help-block">尺寸在512*512以内，大小在500KB以内</p>
                    </div>
                  </div>
                  
                  <div class="col-md-6 form-group">
                    <label><asp:Label ID="Label19" runat="server" Text="重置密码"></asp:Label></label>
                    <br />
                    <asp:CheckBox ID="cbResetPsw" runat="server"></asp:CheckBox>
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


