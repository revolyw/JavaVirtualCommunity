<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onDemand.aspx.cs" Inherits="onDemand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>微客点播</title>
    <meta http-equiv="Content-Type" content="text/html;" />
    <meta charset="utf-8" />
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
    <link rel="stylesheet" href="css/onDemand.css" />

    <script src="dist/js/bootstrap.min.js"></script>

    <!--
<script src="js/stickUp.min.js"></script><!--钉住导航-->

    <script src="js/affix.js"></script>

    <!--affix插件-->

    <script src="js/public.js"></script>

    <script type="text/javascript" src="js/pageTool.js"></script>

    <script src="js/onDemand.js"></script>

</head>
<body>
    <form id="Form1" runat="server">
    <!--页头logo-->
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
                                <li class="active"><a href="onDemand.aspx">微课点播</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="practiceTeaching.aspx">实验教学</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="evaluation.aspx">学习评价</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class=""><a href="community.aspx" target="_blank">社区交流</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 页面主体部分  -->
    <div id="wrap">
        <div class="container bodySize">
            <div class="row">
                <div id="catalogue_frame">
                </div>
                <div class="col-md-3">
                    <div class="sidebar ">
                        <div id="toc">
                            <ul class="nav sidenav sidenav nav-tabs nav-stacked">
                                <li class="active"><a href="#know-java">了解Java</a></li>
                                <li class=""><a href="#teach-outline">教学大纲</a>
                                    <ul class="nav">
                                        <li><a href="#teach-outline-">大纲1</a></li>
                                        <li><a href="#teach-outline-">大纲2</a></li>
                                        <li><a href="#teach-outline-less">大纲3</a></li>
                                        <li><a href="#teach-outline-">大纲4</a></li>
                                        <li><a href="#teach-outline-grunt">大纲5</a></li>
                                        <li><a href="#teach-outline-">大纲6</a></li>
                                    </ul>
                                </li>
                                <li><a href="#teach-calendar">教学日历</a>
                                    <ul class="nav">
                                        <li><a href="#">1</a></li>
                                    </ul>
                                </li>
                                <li><a href="#test-way">考核方式</a> </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--内容展示-->
                <div class="col-md-9" role="main">
                    <div id="content_frame" class="col-md-9" role="main">
                        <div id="video_object">
                            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                width="700" height="500">
                                <param name="movie" value="Flvplayer.swf" />
                                <param name="quality" value="high" />
                                <param name="AutoStart" value="true">
                                <param name="auto" value="true" />
                                <param name="allowFullScreen" value="true" />
                                <param name="FlashVars" value="vcastr_file=demo.flv&LogoText=iopen.com.cn&BufferTime=3" />
                                <embed src="resource/video/Flvplayer.swf" allowfullscreen="true" flashvars="vcastr_file=example_1.flv"
                                    quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                                    width="700" height="500"></embed>
                            </object>
                            </br>
                        </div>
                        <div id="teacher_info">
                        </div>
                    </div>
                </div>
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
