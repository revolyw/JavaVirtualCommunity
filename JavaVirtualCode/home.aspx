<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Java 虚拟学习社区</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" content="charset" />
    <meta name="description" content="Java 虚拟学习社区" />
    <meta name="author" content="-_-" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) 调用jquery引擎 -->

    <script type="text/javascript" src="dist/jquery.min.js"></script>

    <!-- bootstrap开源库-->
    <link rel="stylesheet" href="dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/flat-ui.css" />
    <!-- 自己定制的样式 -->
    <link rel="stylesheet" href="css/public.css" />
    <link rel="stylesheet" href="css/home.css" />

    <script type="text/javascript" src="dist/js/bootstrap.min.js"></script>

    <!--
    <script type="text/javascript" src="js/stickUp.min.js"></script>-->
    <!--钉住导航-->

    <script type="text/javascript" src="js/tile-slider.js"></script>

    <!--metro图片展示-->

    <script type="text/javascript" src="js/unslider.min.js"></script>

    <!--轮播-->

    <script type="text/javascript" src="js/jquery.movingboxes.js"></script>

    <!--公用js-->
    <script src="js/public.js"></script>
    
    <script type="text/javascript" src="js/home.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="http://cdn.bootcss.com/html5shiv/3.7.0/html5shiv.min.js"></script>
        <script src="http://cdn.bootcss.com/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">

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
                                <li class="active"><a href="home.aspx">首页</a></li>
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
                <div class="one floatLeft blockBorder col-md-8">
                    <div class="banner1">
                        <ul>
                            <li>
                                <img alt="bannerImg" src="img/homeBigPic/big1.jpg" /></li>
                            <li>
                                <img alt="bannerImg" src="img/homeBigPic/big2.jpg" /></li>
                            <li>
                                <img alt="bannerImg" src="img/homeBigPic/big3.jpg" /></li>
                        </ul>
                    </div>
                    <a href="javascript:void(0);" class="unslider-arrow1 prev"></a> <a href="javascript:void(0);"
                        class="unslider-arrow1 next"></a>
                </div>
                <div class="two floatLeft blockBorder col-md-4">
                    <div class="banner2">
                        <ul>
                            <li>
                                <img alt="" src="img/JavaBooks/book1.jpg" /></li>
                            <li>
                                <img alt="" src="img/JavaBooks/book2.jpg" /></li>
                            <li>
                                <img alt="" src="img/JavaBooks/book3.jpg" /></li>
                            <li>
                                <img alt="" src="img/JavaBooks/book4.jpg" /></li>
                            <li>
                                <img alt="" src="img/JavaBooks/book5.jpg" /></li>
                        </ul>
                    </div>
                    <a href="javascript:void(0);" class="unslider-arrow2 prev"></a> <a href="javascript:void(0);"
                        class="unslider-arrow2 next"></a>
                </div>
                <div class="three floatLeft panel panel-default col-md-4">
                     <div class="panel-heading">
                        <h3 class="panel-title">
                            导学频道</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                            <strong>Java起源</strong></p>
                            Java自1995诞生，至今已经16年历史。Java的名字的来源：Java是印度尼西亚爪哇岛的英文名称，因盛产咖啡而闻名。Java语言中的许多库类名称，多与咖啡有关，如JavaBeans(咖啡豆)、NetBeans(网络豆)以及ObjectBeans
                            (对象豆)等等。SUN和JAVA的标识也正是一杯正冒着热气的咖啡。
                    </div>
                    <div class="panel-footer"><a href="courseIntrod.aspx">查看更多</a></div>
                </div>
                <div class="four floatLeft panel panel-default col-md-4">
                   <div class="panel-heading">
                        <h3 class="panel-title">
                            每周一题</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                            <strong>汉诺塔</strong></p>
                            汉诺塔：汉诺塔（又称河内塔）问题是源于印度一个古老传说的益智玩具。大梵天创造世界的时候做了三根金刚石柱子，在一根柱子上从下往上按照大小顺序摞着64片黄金圆盘。大梵天命令婆罗门把圆盘从下面开始按大小顺序重新摆放在另一根柱子上。并且规定，在小圆盘上不能放大圆盘，在三根柱子之间一次只能移动一个圆盘。
                            试用Java编写算法解决该问题
                    </div>
                    <div class="panel-footer"><a href="practiceTeaching.aspx">查看更多</a></div>
                </div>
                <div class="five floatLeft panel panel-default col-md-4">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            资源下载</h3>
                    </div>
                    <div class="panel-body">
                         <p>
                            <strong>点击下载</strong></p>
                        <ul>
                          <li><a href="http://www.oracle.com/technetwork/cn/java/javase/documentation/api-jsp-136079-zhs.html" target="_blank">Java SE API 中文文档</a></li>
                          <li><a href="http://www.oracle.com/technetwork/cn/java/javaee/overview/index.html" target="_blank">Java2EE API 中文文档</a></li>
                        </ul>
                    </div>
                    <div class="panel-footer"><a href="practiceTeaching.aspx">查看更多</a></div>
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
    <!-- 固定在底部的页脚 -->
    </form>

    <script type="text/javascript">
    var unslider1 = $('.banner1').unslider({
	speed: 500,               //  The speed to animate each slide (in milliseconds)
	delay: 3000,              //  The delay between slide animations (in milliseconds)
	complete: function() {},  //  A function that gets called after every slide animation
	keys: true,               //  Enable keyboard (left, right) arrow shortcuts
	dots: true,               //  Display dot navigation
	fluid: false              //  Support responsive design. May break non-responsive designs
});
    $('.unslider-arrow1').click(function() {
        var fn = this.className.split(' ')[1];

        //  Either do unslider.data('unslider').next() or .prev() depending on the className
        unslider1.data('unslider')[fn]();
    });

 var unslider2 = $('.banner2').unslider({
	speed: 500,               //  The speed to animate each slide (in milliseconds)
	delay: 3000,              //  The delay between slide animations (in milliseconds)
	complete: function() {},  //  A function that gets called after every slide animation
	keys: true,               //  Enable keyboard (left, right) arrow shortcuts
	dots: true,               //  Display dot navigation
	fluid: false              //  Support responsive design. May break non-responsive designs
});
    $('.unslider-arrow2').click(function() {
        var fn = this.className.split(' ')[1];

        //  Either do unslider.data('unslider').next() or .prev() depending on the className
        unslider2.data('unslider')[fn]();
    });
    </script>

</body>
</html>
