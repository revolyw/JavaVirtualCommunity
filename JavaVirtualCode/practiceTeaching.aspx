<%@ Page Language="C#" AutoEventWireup="true" CodeFile="practiceTeaching.aspx.cs"
    Inherits="practiceTeaching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实验教学</title>
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
    <link rel="stylesheet" href="css/practice.css" />

    <script src="dist/js/bootstrap.min.js"></script>

    <!--affix插件-->
    
    <script src="js/affix.js"></script>

    <script src="js/public.js"></script>
    <script type="text/javascript" src="js/pageTool.js"></script>
    <script src="js/practice.js"></script>
    

    
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
                                <li class=""><a href="onDemand.aspx">微课点播</a></li>
                                <li class="span">&nbsp;|</li>
                                <li class="active"><a href="practiceTeaching.aspx">实验教学</a></li>
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
            <div class="row container">
                <div id="LastContent1">
                    <ul id="big_ulist">
                        <li>
                            <img src="img/loading1.gif" />
                        <!--
                            <div class="li-up">
                                <a href="resource/practice/practice_01.htm" target='_blank'>
                                    <img src="resource/practice/practice_01.files/image001.jpg"><div class="uinfo">
                                        <strong>画板</strong><br>
                                        <span class="gray">上传时间</span> 2012-03-04 23:38:12</div>
                                </a>
                            </div>
                            <div class="li-down">
                                Java 小程序——画板</div>-->
                        </li>
                    </ul>
                    <!-- END AllUser -->
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
