<%@ Page Language="C#" AutoEventWireup="true" CodeFile="community.aspx.cs" Inherits="community" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Java 论坛</title>
    <meta http-equiv="Content-Type" content="text/html" />
    <meta charset="utf-8" content="charset" />
    <meta name="description" content="Java 虚拟学习社区" />
    <meta name="author" content="yW" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) 调用jquery引擎 -->

    <script src="dist/jquery.min.js"></script>

    <!-- bootstrap开源库-->
    <link rel="stylesheet" href="dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/flat-ui.css" />
    <!-- 自己定制的样式 -->
    <link rel="stylesheet" href="css/public.css" />
    <link rel="stylesheet" href="css/community.css" />

    <script src="dist/js/bootstrap.min.js"></script>

    <!--钉住导航-->
    <!--
    <script src="js/stickUp.min.js"></script>-->
    <!--affix插件-->

    <script src="js/affix.js"></script>

    <!--自定义js代码-->

    <script src="js/public.js"></script>
    <script type="text/javascript" src="js/pageTool.js"></script>
    
    <script src="js/community.js"></script>
    

</head>
<body>
    <form id="Form1" runat="server">
    <div class="btn btn-default view_tiezi_back displayNone">
        返回</div>
    <div class="btn btn-danger view_tiezi_liuyan displayNone">
        评论</div>
    <div class="btn btn-primary scrollToTop">
        回顶</div>
    <div class="opacity">
        <div class="decorate_left_top"></div>
        <div class="view_tiezi displayNone">
        </div>
    </div>
    <!--页头logo--><!--
    <div class="container bodySize">
        <div class="demo-headline header">
            <asp:Label ID="display_lg_off" class="show-off" runat="server">
	                    <ul class="sign-in">
		                    <li><a data-toggle="modal" data-target="#LoginModal" href="#">
			                	登录
		                        </a></li>
	                    	<li><a data-toggle="modal" data-target="#RegModal" href="#">
			                	注册
		                        </a></li>
	                    </ul>
            </asp:Label>
            <asp:Label ID="display_lg_on" class="show-off" runat="server">
                <ul class="sign-in">
                    <li>
                        <asp:Label ID="s_u_name" runat="server" Text="" Style="color: WindowText"></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="loginOff" runat="server">注销</asp:LinkButton>
                    </li>
                </ul>
            </asp:Label>
        </div>
        <!--导航-->
        <!--
        <div class="navbar-inverse">
            <div class="navwrapper navbar-static-top">
                <div class="navbar navbar-inverse">
                    <div class="container">
                        <div class="navbar-collapse collapse">
                            <ul class="nav navbar-nav">
                                <li class=""><a href="home.aspx">首页</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="courseIntrod.aspx">课程概述</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="knowledge.aspx">知识管理</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="onDemand.aspx">微课点播</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="practiceTeaching.aspx">实验教学</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="evaluation.aspx">学习评价</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class="active"><a href="community.aspx" target="_blank">社区交流</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>-->
    <!-- 页面主体部分  -->
    <div id="wrap">
        
        <div class="bg container bodySize">
            <div class="top_bg"></div>
            <div id="top" class="col-md-12">
                <!--<div class="community_top_bkg"><img src="img/community_top.jpg" /></div>-->
                <ul>
                    <li id="nav_kantie" class="active">看帖</li>
                    <li id="nav_fatie">发帖</li>
                    <li id="nav_dongtai">动态</li>
                </ul>
                <div id="search">
                    <input id="input_search" type="text" placeholder="帖子搜索" />
                    <a href="javascript:void(0);" class="search_img"></a>
                </div>
                <div class="top_logo">
                    <a href="home.aspx"><img src="img/communityLogo.png" style="border:1px solid #e8e8e8;" /></a>
                </div>
                <div class="top_btn"><a href="home.aspx">去社区学习</a></div>
            </div>
            <div id="bottom" class="col-md-12">
                <ul>
                    <!--<li>
                        <div class="tie_left">
                            <div class="hot">
                                <span class="hot_txt">2048</span>
                            </div>
                        </div>
                        <div class="tie_center">
                            <div class="tie_center_top">
                                <span id="title_txt">J2EE中过滤器的用法</span>
                            </div>
                            <div class="tie_center_bottom">
                                <span id="tie_main">J2EE中的过滤器到底该如何使用呢？ 今天我们就来探讨一下，这里是这片帖子的摘要</span>
                            </div>
                        </div>
                        <div class="tie_right">
                            <div class="tie_right_top">
                                <span id="user_txt">骑大象抢内衣</span>
                            </div>
                            <div class="tie_right_bottom">
                                <span id="time_txt">2015-04-08 14:00</span>
                            </div>
                        </div>
                    </li>-->
                    <li style="line-height:100px; text-align:center;">
                       <img src="img/loading1.gif" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- 页面主体部分  -->
    <!-- 固定在底部的页脚 -->
    <div id="footer">
        <div class="container">
            <p class="text-muted text-center">
                Copyright © 2014 njujlxy & Design By yW & Optimize For Web Page By Bootstrap
            </p>
        </div>
    </div>
    </form>
</body>
</html>
