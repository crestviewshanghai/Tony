<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<%@ Register Src="WUC_Header.ascx" TagName="WUC_Header" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Menu.ascx" TagName="WUC_Menu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Banner.ascx" TagName="WUC_Banner" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Footer.ascx" TagName="WUC_Footer" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_MobileMenu.ascx" TagName="WUC_MobileMenu" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Service.ascx" TagName="WUC_Service" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Article.ascx" TagName="WUC_Article" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Contact.ascx" TagName="WUC_Contact" TagPrefix="MojoCube" %>

<%@ Register Src="WUC_Product.ascx" TagName="WUC_Product" TagPrefix="MojoCube" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  style="font-size: 345%;">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="applicable-device" content="pc,mobile" />
    <title></title>
</head>

<body>

    <!--[if lt IE 9]>
        <script src="JS/html5shiv.min.js" type="text/javascript"></script>
        <script src="JS/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    
    <header>

        <!-- LOGO、语言、搜索 -->
        <MojoCube:WUC_Header id="WUC_Header" runat="server" />
        
        <!-- 导航菜单 -->
        <MojoCube:WUC_Menu id="WUC_Menu" runat="server" />


    </header>
    
    <!-- Banner -->
    <MojoCube:WUC_Banner id="WUC_Banner" runat="server" />

    <!-- 内容 -->
    <div class="container">
        <div class="row" style="display:none">
            <div class="col-xs-12 col-sm-8 col-md-9" id="rightBox">
                <div class="positionBox">
                    <div class="titleBar">
                        <h1>当前位置</h1>
                        <span>
                            <a href="./">首页</a>
                             > 
                            <asp:HyperLink ID="hlTitle" runat="server" Text="商品中心"></asp:HyperLink>
                        </span>
                    </div>
                </div>
                <div class="productList">
                    <ul id="ProductUL" runat="server"></ul>
                </div>
                
                <div class="pager">
                    <webdiyer:AspNetPager id="ListPager" runat="server"></webdiyer:AspNetPager>
                </div>

                <!-- 产品展示 -->
                <MojoCube:WUC_Product id="WUC_Product" runat="server" />
                
            </div>
            <div class="col-xs-12 col-sm-4 col-md-3">
                <div class="navigationBox" id="classification">
                    <div class="classTitleBar">
                        导航栏目
                    </div>
                    <div class="list">
                        <ul id="firstpane" runat="server"></ul>
                    </div>
                    <div id="BannerDiv" runat="server" class="telBox"></div>
                </div>
                
                <!-- 新闻中心 -->
                <MojoCube:WUC_Article id="WUC_Article" runat="server" />
                
                <!-- 联系我们 -->
                <MojoCube:WUC_Contact id="WUC_Contact" runat="server" />

            </div>
        </div>



        <div class="g-doc">
			<div class="g-wrap m-wrap2">
				<p class="u-topic-tlt J-title">除甲醛，这些小妙招来帮你</p>
				<div class="m-author">
					<div class="u-headpic"><img src="Images/user.png" class="headpic J-ava"></div>
					<p class="u-nickname J-uname">海外组：太阳</p>
				</div>
				<div class="m-topic-detail">
					<p class="u-detail J-content">甲醛这种空气污染物，在日常生活中无处不在。无论是人造木地板、家具，还是地毯、窗帘，都会在8~15年内缓慢的释放甲醛。哪怕是住了好几年的房子、开的车子也会在无形中散发甲醛。想要解决这个大难题？我这里有几个小妙招可以帮你～<br><br>第1个小妙招当然就是大家常用的空气净化器了，智造的这款空气净化器采用物理净化，用甲醛分解网和活性炭网来过滤甲醛，同时还能去除PM2.5等有害物质，让你在家也能呼吸到清新雨林般的新鲜空气。<br><br>第2个小妙招，是我从美国为你寻觅的这款除甲醛神器——真正分解有毒分子的除甲醛海绵。在美国，它被广泛应用于工厂、医院、学校各大机构，是得到过官方认证的实力派。和单一竹炭吸附相比，除甲醛海绵先通过活性炭吸附，再用天然凝胶去分解，把甲醛转化成水和二氧化碳。不用担心吸收满了之后再被释放出来，有效避免二次污染。而且所用原料全部都是天然植物的，安全环保。在家里、车里随时常备着，自己和家人的呼吸环境就有了保障。<br><br>之后还会上线更多新颖的包装，换上插画风或是简约风的壳子，让它无论放在哪一处，都是嗅觉和视觉的双重满足。</p>
					<div class="m-swipe-wrap" style="display:none"></div>
				</div>
			</div>
			<div class="g-wrap m-wrap5" style="display: block;">
				<div class="m-goods-gather">
					<ul class="m-goods-list">
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/2d43d642d928240ef2013e8da1c133b2.png" class="pic"> </div>
								<div class="u-desc">有效吸收甲醛、去除空间异味</div>
								<div class="u-detail">
									<p class="name f-tof">美国制造 除甲醛空气净化剂227g</p>
									<p class="price-box"><span class="price">45</span></p>
								</div>
								<p class="u-specification">美国制造</p>
							</a>
						</li>
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/534aa5bfc31d690c0cebf31f9710e5af.png" class="pic"> </div>
								<div class="u-desc">除尘、除甲醛、PM2.5指数实时显示</div>
								<div class="m-status-box">
									<p class="u-status gradientPrice">满折</p>
								</div>
								<div class="u-detail">
									<p class="name f-tof">空气净化器</p>
									<p class="price-box"><span class="price">999</span></p>
								</div>
							</a>
						</li>
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/6c089b604b114b4e330da4766722bade.png" class="pic"> </div>
								<div class="u-desc">360°立体风洞循环，400m³/h高能效净化！</div>
								<div class="u-detail">
									<p class="name f-tof">网易智造全方位空气净化器</p>
									<p class="price-box"><span class="price">1999</span></p>
								</div>
							</a>
						</li>
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/ba98e45aa559a7d75a6e392ada7736a3.png" class="pic"> </div>
								<div class="u-desc">如置身于阿尔卑斯雪山 呼吸纯净空气</div>
								<div class="m-status-box">
									<p class="u-status gradientPrice">超级闪购</p>
								</div>
								<div class="u-detail">
									<p class="name f-tof">空气净化器Pro</p>
									<p class="price-box"><span class="price">1099</span><span class="tip">¥1299</span></p>
								</div>
							</a>
						</li>
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/8113b50e29d3c5c8cc1a6c186998edaa.png" class="pic"> </div>
								<div class="u-desc">10+air新风，呼吸间，清新已达深处</div>
								<div class="u-detail">
									<p class="name f-tof">10+air 壁挂新风机</p>
									<p class="price-box"><span class="price">2498</span></p>
								</div>
							</a>
						</li>
						<li class="m-goods-item">
							<a href="ProductDetail.aspx?PageName=20160601210124" class="m-goods-con PSC_J_normal_statistics_Goods">
								<div class="u-pic"> <img src="Images/225ad2ccbeb23bc54925402c17d298f2.png" class="pic"> </div>
								<div class="u-desc">CADR值高达70m³/h</div>
								<div class="m-status-box">
									<p class="u-status gradientPrice">满折</p>
								</div>
								<div class="u-detail">
									<p class="name f-tof">车载空气净化器</p>
									<p class="price-box"><span class="price">399</span></p>
								</div>
							</a>
						</li>
					</ul>
				</div>
			</div>

			<div id="j-topicComments" class="J_topicComments">
				<div class="m-topicComments">
					<div class="m-topicComments-container">
						<div class="m-topicComments-hd">
							<div class="u-inner">
								<div class="text">精选留言</div>
								<a href="javascript:;" class="btn-add-comment J_add_comment"></a>
							</div>
						</div>
						<div class="m-topicComments-bd">
							<div class="m-commentlist">
								<div class="m-comment">
									<div class="m-comment-hd">
										<div class="u-left"> <img class="avatar" src="Images/user.png"> <span class="name">L****U</span> <span class="icon icon-v2"></span> </div>
										<div>
											<div class="u-right thumbsUpWrap"> <span class="thumbsUpNum">37</span>
												<a href="javascript:;" class="icon-thumbsUp J_thumbsUp" data-topiccommentid="101490285"></a>
											</div>
										</div>
									</div>
									<div class="m-comment-content">
										<div class="u-inner">甲醛无色无味吖！小伙伴们，但是甲醛溶于水 新买的窗帘 床品 衣物一定要先过水再使用哦！尤其是家里有宝宝的</div>
									</div>
									<div class="m-comment-time"> <span class="u-time">2018-09-10 18:11:25</span> </div>
								</div>
								<div class="m-comment">
									<div class="m-comment-hd">
										<div class="u-left"> <img class="avatar" src="Images/user.png"> <span class="name">阿****木</span> <span class="icon icon-v2"></span> </div>
										<div>
											<div class="u-right thumbsUpWrap"> <span class="thumbsUpNum">21</span>
												<a href="javascript:;" class="icon-thumbsUp J_thumbsUp" data-topiccommentid="101490255"></a>
											</div>
										</div>
									</div>
									<div class="m-comment-content">
										<div class="u-inner">我也买了，放到房间去味还是比较明显的，本来一股装修的味道，放两三天都是这个的香味了</div>
									</div>
									<div class="m-comment-time"> <span class="u-time">2018-09-07 12:30:08</span> </div>
								</div>
								<div class="m-comment">
									<div class="m-comment-hd">
										<div class="u-left"> <img class="avatar" src="Images/user.png"> <span class="name">阿****</span> <span class="icon icon-v6"></span> </div>
										<div>
											<div class="u-right thumbsUpWrap"> <span class="thumbsUpNum">15</span>
												<a href="javascript:;" class="icon-thumbsUp J_thumbsUp" data-topiccommentid="101490306"></a>
											</div>
										</div>
									</div>
									<div class="m-comment-content">
										<div class="u-inner">最近搬办公室，买了十来盒囤着，和绿萝一起配合，希望有用！</div>
									</div>
									<div class="m-comment-time"> <span class="u-time">2018-09-12 10:55:53</span> </div>
								</div>
								<div class="m-comment">
									<div class="m-comment-hd">
										<div class="u-left"> <img class="avatar" src="Images/user.png"> <span class="name">d****2</span> <span class="icon icon-v5"></span> </div>
										<div>
											<div class="u-right thumbsUpWrap"> <span class="thumbsUpNum">14</span>
												<a href="javascript:;" class="icon-thumbsUp J_thumbsUp" data-topiccommentid="101490305"></a>
											</div>
										</div>
									</div>
									<div class="m-comment-content">
										<div class="u-inner">装修好两年多了，到夏天还是感觉有味道，买了这个安心点，健康最重要</div>
									</div>
									<div class="m-comment-time"> <span class="u-time">2018-09-12 10:52:34</span> </div>
								</div>
								<div class="m-comment">
									<div class="m-comment-hd">
										<div class="u-left"> <img class="avatar" src="Images/user.png"> <span class="name">A****澜</span> <span class="icon icon-v6"></span> </div>
										<div>
											<div class="u-right thumbsUpWrap"> <span class="thumbsUpNum">10</span>
												<a href="javascript:;" class="icon-thumbsUp J_thumbsUp" data-topiccommentid="101490308"></a>
											</div>
										</div>
									</div>
									<div class="m-comment-content">
										<div class="u-inner">在家里放的都是竹炭吸附，但总是担心吸附满了甲醛不知道啥时候就又释放出来……之前就用过美国airsponge，但是都要海淘而且价格不菲，严选这么强大竟然找到人家供应商了！为严选打个call! 趁机多囤几个</div>
									</div>
									<div class="m-comment-time"> <span class="u-time">2018-09-12 11:09:57</span> </div>
								</div>
							</div>
						</div>
						<div class="m-topicComments-ft">
							<a href="javascript:;" class="u-footer J_comment_list">查看更多</a>
						</div>
					</div>
				</div>
			</div>

		</div>





    </div>
    
    <!-- 底部菜单、版权信息 -->
    <footer>
        <MojoCube:WUC_Footer id="WUC_Footer" runat="server" />
    </footer>
    
    <!--手机菜单-->
    <MojoCube:WUC_MobileMenu id="WUC_MobileMenu" runat="server" />

    <!--客服面板-->
    <MojoCube:WUC_Service id="WUC_Service" runat="server" />


</body>

</html>