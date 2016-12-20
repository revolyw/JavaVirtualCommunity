<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseIntrod.aspx.cs" Inherits="courseIntrod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>课程概述</title>
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
    <link rel="stylesheet" href="css/CourseIntrod.css" />

    <script src="dist/js/bootstrap.min.js"></script>

    <!--钉住导航-->
    <!--
    <script src="js/stickUp.min.js"></script>-->
    <!--affix插件-->

    <script src="js/affix.js"></script>

    <!--公共js代码-->

    <script src="js/public.js"></script>

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
                                <li class="span">&nbsp;&nbsp;</li>
                                <li class="active"><a href="courseIntrod.aspx">课程概述</a></li>
                                <li class="span">&nbsp;&nbsp;</li>
                                <li class=""><a href="knowledge.aspx">知识管理</a></li>
                                <li class="span">&nbsp;&nbsp;</li>
                                <li class=""><a href="onDemand.aspx">微课点播</a></li>
                                <li class="span">&nbsp;&nbsp;</li>
                                <li class=""><a href="evaluation.aspx">学习评价</a></li>
                                <li class="span">&nbsp;&nbsp;</li>
                                <li class=""><a href="practiceTeaching.aspx">实例教学</a></li>
                                <li class="span">&nbsp;&nbsp;</li>
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
            <div id="nav_position">
                <img src="img/icon1.png" style="padding:0 0 5px 5px;"/>
                <ul class="breadcrumb">
                    <li>您的位置：</li>
                    <li><a href="home.aspx">首页</a> </li>
                    <li><a href="courseIntrod.aspx" class="active">课程概述</a> </li>
                </ul>
            </div>
            <div class="row">    
                <div id="catalogue_frame"></div>
                <div class="col-md-3" >
                    <div class="sidebar ">
                        <div id="toc">
                            <!--<div class="top_img"></div>-->
                            <ul class="nav sidenav nav-tabs nav-stacked">
                                <li class="active"><a href="#knowledgeMap">知识地图</a></li>
                                <li class=""><a href="#know-java">了解Java</a></li>
                                <li class=""><a href="#teach-outline">教学大纲</a></li>
                                <li><a href="#teach-calendar">教学日历</a></li>
                                <li><a href="#test-way">考核方式</a> </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--内容展示-->
                <div class="col-md-9" role="main">
                    <div id="content_frame" class="col-md-9" role="main">
                        <!--
                        <ul class="breadcrumb">
                            <li><a href="home.aspx">首页</a> </li>
                            <li><a href="courseIntrod.aspx" class="active">课程概述</a> </li>
                        </ul>-->
                        <div class="dividing">
                            <h2>
                                <label class="skew" id="knowledgeMap">
                                    <i>知识地图</i></label></h2>
                        </div>
                         <div class="docs-section">
                            <img src="img/knowledgeMap.png" style="width:100%;height:700px" />
                         </div>
                        <div class="dividing">
                            <h2>
                                <label class="skew" id="know-java">
                                    <i>了解Java</i></label></h2>
                        </div>
                        <div class="docs-section">
                            <span style="font-size:13px">Java 是几乎所有类型的网络应用程序的基础，也是开发和提供嵌入式和移动应用程序、游戏、基于 Web 的内容和企业软件的全球标准。Java 在全球各地有超过900万的开发人员，使您能够高效地开发、部署和使用精彩的应用程序和服务。从笔记本电脑到数据中心，从游戏控制台到科学超级计算机，从手机到互联网，Java 无处不在！</span>
                            <pre style="word-break: break-word;
    white-space: normal;">
97%的企业桌面运行Java美国有89%的桌面（或计算机）运行Java全球有 900 万 Java 开发人员 开发人员的头号选择 排名第一的部署平台有30亿部移动电话运行Java100%的蓝光盘播放器附带了Java有50亿张Java卡在使用1.25亿台TV设备运行Java前5个原始设备制造商均提供了JavaME
                                       </pre>
                            <div style="clear: both">
                            </div>
                        </div>
                        <div class="dividing">
                            <h2>
                                <label class="skew" id="teach-outline">
                                    <i>教学大纲</i></label></h2>
                        </div>
                        <div class="docs-section">
                            课程的性质、目的和任务
                            <pre><code class="lang-bash">《Java语言程序设计》是计算机系本科专业一门专业课。通过本课程的教学，帮助学生掌握面向对象的编程设计思想和Java的基本语法、常用技术，并能运用Java技术和基本开发工具JBuilder9.0进行程序设计。培养学生用面向对象程序设计思想和“计算机思维”方式进行计算机编程，尤其强调对学生“计算机思维”方式的训练，使学生能够运用Java语言作为一种思维工具解决处理现实问题。启发学生的创新意识，提高学生在程序设计过程中分析问题和解决问题的实际动手能力，使学生的理论知识和实践技能得到共同发展。</code></pre>
                            课程教学的基本要求
                            <pre><code class="lang-bash">通过本课程的学习，使学生达到如下知识和技能两方面目标： </br><b>（一）知识要求：</b> </br>1．理解Java语言的各种常用的基本数据类型的意义</br>2． 理解Java语言的对象，抽象与封装，类与类的继承，及类的多态性的概念</br>3． 理解Java语言有哪些基础类库，理解Java的包的含义</br>4． 理解Java语言中异常的概念</br>5． 理解Java语言中线程的概念</br>6． 理解Java语言中I/O处理的功用</br>7． 理解Java图形用户界面理解AWT、Swing的意义及AWT事件处理</br>8．理解Java小应用程序Applet，应用程序Application 各自的作用和它们的区别 </br><b>（二）能力要求：</b></br> 1． 熟练掌握Java语言的基本数据类型，运算符及表达式，控制结构，字符串的应用</br>2．会运用面向对象编程特点，使用抽象、封装、继承、多态编写简单的类和使用类对象编程 </br>3． 会定义包 </br>4． 掌握Java语言基础类、字符串类的应用</br>5．掌握异常的应用方法，进行异常处理设计 </br>6． 掌握线程的使用方法 </br>7． 掌握Java语言的I/O编程及应用方法 </br>8．会设计Java图形用户界面和图形编程</br>9． 掌握Applet小应用程序的设计方法，设计小型网络应用程序 </br>10．掌握Application应用程序的设计方法，设计小型网络应用程序</br>11．熟练掌握Java编程集成环境MyEclipse的应用。 </code></pre>
                        </div>
                        <div class="docs-section">
                            <div class="dividing">
                                <h2>
                                    <label class="skew" id="teach-calendar">
                                        <i>教学日历</i></label></h2>
                            </div>
                            教学周 教学计划
                            <pre><code class="lang-js">01周 第1章 Java语言概述 </br>02周 第2章 Java语言开发环境 </br> &nbsp;&nbsp;&nbsp;&nbsp;第3章 Java语言基础</br>03周 第4章 流程控制 </br>04周 第5章 数组与字符串 </br>05周 第6章 类与对象 </br>06周 第7章 Java语言类特性 </br>07周 第8章 继承、抽象类和接口 </br>08周 第8章 继承、抽象类和接口</br>09周 第8章 继承、抽象类和接口 </br>10周 第9章 异常处理 </br>11周 第10章 Java语言的输入输出与文件处理 </br>12周 第11章 多线程 </br>13周 第12章 图形界面设计</br>14周 第12章 图形界面设计</br>15周 第13章 事件处理 </br>16周 第14章 绘图程序设计 </br>17周 第15章 小程序Applet </code></pre>
                        </div>
                        <div class="docs-section">
                            <div class="dividing">
                                <h2>
                                    <label class="skew" id="test-way">
                                        <i>考核方式</i></label></h2>
                            </div>
                            <pre><code class="lang-bash">采用形成性评价和总结性评价相结合的考核方式。</br>课程成绩由三部分内容组成：平时作业与实验占20%，课程设计作品占40%，期末考试占40%。
                            </code></pre>
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