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
		                    <li>|</li>
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
                                <li class="span">&nbsp;</li>
                                <li class=""><a href="courseIntrod.aspx">课程概述</a></li>
                                <li class="span">&nbsp;</li>
                                <li class=""><a href="knowledge.aspx">知识管理</a></li>
                                <li class="span">&nbsp;</li>
                                <li class=""><a href="onDemand.aspx">微课点播</a></li>
                                <li class="span">&nbsp;</li>
                                <li class=""><a href="evaluation.aspx">学习评价</a></li>
                                <li class="span">&nbsp;</li>
                                <li class=""><a href="practiceTeaching.aspx">实例教学</a></li>
                                <li class="span">&nbsp;</li>
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
                <div class="one floatLeft col-md-8">
                    <div class="banner1">
                        <ul>
                            <li>
                                <img alt="bannerImg" src="img/homeBigPic/mainPic1.jpg" /></li>
                            <li>
                                <img alt="bannerImg" src="img/homeBigPic/mainPic2.jpg" /></li>
                        </ul>
                    </div>
                    <a href="javascript:void(0);" class="unslider-arrow1 prev"></a> <a href="javascript:void(0);"
                        class="unslider-arrow1 next"></a>
                </div>
                <!-- 书轮播
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
                </div> !-->
                <div class="aboutJava floatLeft panel panel-default col-md-4">
                    <div class="text">
                         Java 语言诞生于1995年，Java的名字来源于印度尼西亚爪哇岛的英文名称，因盛产咖啡而闻名，Java的标志正是一杯冒着热气的咖啡。Java是一种可以撰写跨平台应用软件的面向对象的程序设计语言，也是目前编程的主流语言。
                    </div>
                    <a class="more" href="courseIntrod.aspx"><img src="img/little2.jpg"/></a>
                </div>
                <div class="communityMessage floatLeft panel panel-default col-md-4">
                    <a class="cmsg_1" href="onDemand.aspx">【视频】最新视频上线，可以点播</a>
                    <a class="cmsg_2" href="onDemand.aspx">【通知】交流社区开通，欢迎大家参与交流分享</a>
                    <a class="cmsg_3" href="onDemand.aspx">【案例】最新程序设计案例：计算器</a>
                    <a class="cmsg_4" href="onDemand.aspx">【通知】学习评价系统，可以在线测验，欢迎点击测试</a>
                    <a class="more" href="community.aspx"><img src="img/little2.jpg"/></a>
                </div>
                <div class="three floatLeft panel panel-default col-md-4">
                     <div class="panel-heading">
                        <h3 class="panel-title">
                            导学频道</h3>
                    </div>
                    <div class="panel-body">
                          Java程序设计是计算机专业学生的必修科目，也是学习后续课程的基础。开发本学习社区的初衷正是为了更好地帮助学习者完成Java课程的学习任务。在本社区,同学们可以完成相应知识点的预习、复习；可以反复观看微课点播模块的教学视频，对于不懂的内容，可以在相应的模块下提问，会得到任课教师的解答；还可以在学习评价模块对自己学习效果进行检测；在社区交流模块，还为所有学习者提供了交流讨论的空间。
                          </div>
                    <div class="panel-footer"><a href="courseIntrod.aspx">查看更多</a></div>
                </div>
                <div class="four floatLeft panel panel-default col-md-4">
                   <div class="panel-heading">
                        <h3 class="panel-title">
                            案例精选</h3>
                    </div>
                    <div class="panel-body">
                       贪吃蛇是一款非常经典的小游戏，玩过贪吃蛇游戏的朋友一定不会陌生了，这款游戏既简单又耐玩。通过控制蛇头方向，尽可能多的吃到东西，每吃一口就能得到一定的积分，使得蛇变长，身子越长玩的难度就越大，不能碰墙，不能咬到自己的身体，更不能咬自己的尾巴，等到了一定的分数，就能过关，然后继续玩下一关。在学习完Java后，我们也可以开发出这样有趣的游戏噢。喜欢贪吃蛇小游戏的朋友们，快来挑战一下吧!
                    </div>
                    <div class="panel-footer"><a href="practiceTeaching.aspx">查看更多</a></div>
                </div>
                <div class="five floatLeft panel panel-default col-md-4">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            资源下载</h3>
                    </div>
                    <div class="panel-body">
                        <ul>
                          <li><a href="http://docs.oracle.com/javase/7/docs/" target="_blank">JDK 7.0</a></li>
                          <li><a href="http://www.oracle.com/technetwork/cn/java/javase/documentation/api-jsp-136079-zhs.html" target="_blank">Java SE API 中文文档</a></li>
                          <li><a href="http://www.oracle.com/technetwork/cn/java/javaee/overview/index.html" target="_blank">Java2EE API 中文文档</a></li>
                          <li><a href="http://www.eclipse.org/downloads/" target="_blank">Eclipse (Java ADT)</a></li>
                          <li><a href="http://maven.apache.org/download.cgi" target="_blank">Maven</a></li>
                          <li><a href="http://www.mysql.com/downloads/" target="_blank">MySql Database</a></li>
                          <li><a href="https://www.oracle.com/downloads/index.html" target="_blank">Oracle Database</a></li>
                          <li><a href="http://msdn.itellyou.cn/" target="_blank">各类开发人员工具</a></li>
                        </ul>
                    </div>
                    <div class="panel-footer"><a href="http://www.oracle.com/technetwork/cn/java/javase/documentation/index.html" target="_blank">查看更多</a></div>
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
