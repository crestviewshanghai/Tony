<%@ Page Language="C#" MasterPageFile="../Commons/Main.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Admin_User_Profile" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">

    <script type="text/javascript">

        function resetMemo() {
            document.getElementById("ctl00_cphMain_txtMemoID").value = "";
            document.getElementById("ctl00_cphMain_txtMemoTitle").value = "";
            document.getElementById("ctl00_cphMain_txtMemoContent").value = "";
        }

        function editMemo(id, title, content) {
            document.getElementById("ctl00_cphMain_txtMemoID").value = id;
            document.getElementById("ctl00_cphMain_txtMemoTitle").value = title;
            document.getElementById("ctl00_cphMain_txtMemoContent").value = content;
        }

    </script>

      <div class="content-wrapper">
      
        <section class="content-header">
          <h1>
            用户面板
          </h1>
          <ol class="breadcrumb">
            <li><a href="../"><i class="fa fa-home"></i> 首页</a></li>
            <li class="active">用户面板</li>
          </ol>
        </section>

        <section class="content">
        
          <div id="AlertDiv" runat="server"></div>

          <div class="row">
            <div class="col-md-3">

              <div class="box box-primary">
                <div class="box-body box-profile">
                  <asp:Image ID="imgPortrait" runat="server" CssClass="profile-user-img img-responsive img-circle"></asp:Image>
                  <h3 class="profile-username text-center"><asp:Label ID="lblFullName" runat="server"></asp:Label></h3>
                  <p class="text-muted text-center"><asp:Label ID="lblPosition" runat="server"></asp:Label>（<asp:Label ID="lblDepartment" runat="server"></asp:Label>）</p>
                  <a href="#MemoDiv" class="btn btn-primary btn-block fancybox" title="写便签" onclick="resetMemo();"><b><i class="fa fa-pencil margin-r-5"></i>  写便签</b></a>
                </div>
              </div>

              <div class="box box-primary">
                <div class="box-header with-border">
                  <h3 class="box-title">基本资料</h3>
                </div>
                <div class="box-body">
                  <strong><i class="fa fa-book margin-r-5"></i>  学历</strong>
                  <p class="text-muted">
                     <asp:Label ID="lblEducation" runat="server"></asp:Label>
                  </p>

                  <hr />
                  
                  <strong><i class="fa fa-phone margin-r-5"></i> 手机</strong>
                  <p class="text-muted">
                     <asp:Label ID="lblPhone" runat="server"></asp:Label>
                  </p>

                  <hr />

                  <strong><i class="fa fa-map-marker margin-r-5"></i> 地址</strong>
                  <p class="text-muted">
                     <asp:Label ID="lblAddress" runat="server"></asp:Label>
                  </p>

                  <hr />

                  <strong><i class="fa fa-pencil margin-r-5"></i> 签名</strong>
                  <p class="text-muted">
                     <asp:Label ID="lblNote" runat="server"></asp:Label>
                  </p>

                </div>
              </div>
            </div>
            <div class="col-md-9">
              <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                  <li class="active"><a href="#memo" data-toggle="tab">我的便签</a></li>
                  <li><a href="#settings" data-toggle="tab">个人设置</a></li>
                </ul>
                <div class="tab-content">
                  
                  <div class="active tab-pane" id="memo">
                  
                  <div class="box-body">
                        <div class="row">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeader="false" GridLines="None" BorderWidth="0px" CssClass="table1" style="margin-bottom:0px; width:100%;" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                    
                                            <div class="post" style="border:dashed 1px #eee; padding:10px 10px 0 10px; background:#FFFFE0; margin:0 5px 10px 5px;">
                                                <div class="user-block">
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("pk_Memo") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblCreateUser" runat="server" Text='<%# Bind("CreateUser") %>' Visible="false"></asp:Label>
                                                    <asp:CheckBox ID="cbStar" runat="server" Checked='<%# Bind("IsStar") %>' Visible="false" />
                                                    <a href="#"><asp:Label ID="lblMemoTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                                                    <asp:LinkButton ID="gvDelete" runat="server" ToolTip="删除" CssClass="pull-right btn-box-tool" CommandName="_delete"><i class='fa fa-times'></i></asp:LinkButton>
                                                    <br />
                                                    <asp:Label ID="lblModifyDate" runat="server" Text='<%# Bind("ModifyDate") %>' style="font-size:8pt; color:#999;"></asp:Label>
                                                </div>
                                                <p>
                                                    <asp:Label ID="lblMemoDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </p>
                                                <ul class="list-inline">
                                                    <li>
                                                        <asp:LinkButton ID="gvStar" runat="server" ToolTip="标记星标" CommandName="_star"><i class="fa fa-star-o text-yellow"></i></asp:LinkButton>
                                                    </li>
                                                    <li class="pull-right">
                                                        <asp:HyperLink ID="gvEdit" runat="server" CssClass="fancybox link-black text-sm" ToolTip="便签" NavigateUrl="#MemoDiv"><i class="fa fa-edit margin-r-5"></i> 修改</asp:HyperLink>
                                                    </li>
                                                </ul>
                                            </div>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            
                            <div id="EmptyDiv" runat="server" visible="false" style="height:60px; text-align:center; padding:10px; overflow:auto;">暂无信息</div>
                    
                        </div>
                    </div>
                    
                    <div class="box-footer no-padding" style="margin-top:-10px; border:0px;">
                      <div class="mailbox-controls">
                  
                        <div id="pager" style="background:#fff; border:0px; margin-top:0px; padding:2px;">
                           <webdiyer:AspNetPager ID="ListPager" runat="server" OnPageChanged="ListPager_PageChanged"></webdiyer:AspNetPager>
                        </div>
        
                      </div>
                    </div>

                  </div>

                  <div class="tab-pane" id="settings">

                    <div class="box-body">
                      <div class="row">

                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label></label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" onfocus="this.blur()"></asp:TextBox>
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
                            <label><asp:Label ID="Label16" runat="server" Text="性别"></asp:Label></label>
                            <asp:DropDownList ID="ddlSex" runat="server" CssClass="form-control select2">
                                <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="1"></asp:ListItem>
                            </asp:DropDownList>
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
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label14" runat="server" Text="生日"></asp:Label></label>
                            <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label13" runat="server" Text="签名"></asp:Label></label>
                            <asp:TextBox ID="txtNote" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                  
                      </div>
              
                      <div class="row">
                          
                          <hr />
                      
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label11" runat="server" Text="新的密码"></asp:Label></label>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                          </div>
                  
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label12" runat="server" Text="确认密码"></asp:Label></label>
                            <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                          </div>
                  
                      </div>

                      <div class="row">
              
                          <hr />
              
                          <div class="col-md-6 form-group">
                            <label><asp:Label ID="Label17" runat="server" Text="头像"></asp:Label></label>
                            <div class="form-group">
                                <div class="btn btn-default btn-file">
                                    <i class="fa fa-upload"></i> 上传头像
                                    <asp:FileUpload ID="fuPortrait" runat="server" onchange="ChkUploadImage(this,ctl00_cphMain_imgPortrait);"></asp:FileUpload>
                                </div>
                                <p class="help-block">尺寸在512*512以内，大小在500KB以内</p>
                            </div>
                          </div>
                  
                      </div>

                    </div>
            
                    <div class="box-footer">
                        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" onclick="btnSave_Click"></asp:Button>
                    </div>


                  </div>
                </div>
              </div>
            </div>
          </div>

        </section>

      </div>
      
      <div id="MemoDiv" style="display:none; width:500px;">
            
          <div class="box-body">
          
              <div class="form-group">
                  <asp:TextBox ID="txtMemoTitle" runat="server" CssClass="form-control" placeholder="标题（选填）"></asp:TextBox>
                  <asp:TextBox ID="txtMemoID" runat="server" style="display:none;"></asp:TextBox>
              </div>
                  
              <div class="form-group">
                  <asp:TextBox ID="txtMemoContent" runat="server" CssClass="form-control" placeholder="内容（必填）" TextMode="MultiLine" Height="150px"></asp:TextBox>
              </div>
                  
              <div class="pull-right">
                  <asp:LinkButton ID="lnbSaveMemo" runat="server" CssClass="btn btn-primary" onclick="lnbSaveMemo_Click">确定</asp:LinkButton>
              </div>

          </div>

      </div>

</asp:Content>


