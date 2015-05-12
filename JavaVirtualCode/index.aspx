<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Java 虚拟学习社区</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<meta name="description" content="Java 虚拟学习社区"/>
<meta name="author" content="yW"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) 调用jquery引擎 -->
<script type="text/javascript" src="dist/jquery.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script type="text/javascript"  src="dist/js/bootstrap.min.js"></script>
<script type="text/javascript">
window=getQueryString("message");
//取得url中获得的错误信息
function getQueryString(name)
{
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
	var r = window.location.search.substr(1).match(reg);
	if(!r[2])
	{
		alert("未知错误！！");
	}else{
		alert(decodeURI(r[2]));
	}
}
</script>
<!-- bootstrap开源库-->
<link rel="stylesheet" href="dist/css/bootstrap.min.css"/>
<!-- 自己定制的样式 -->
<link rel="stylesheet" href="css/index.css"/>

<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
        <script src="http://cdn.bootcss.com/html5shiv/3.7.0/html5shiv.min.js"></script>
        <script src="http://cdn.bootcss.com/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>

<body>
<!-- start 固定在顶部的导航 -->
<div class="navbar navbar-default navbar-fixed-top">
		<div class="container"> 
				
				<!-- Brand and toggle get grouped for better mobile display -->
				<div class="navbar-header"> <img class="navbar-brand" alt="logo" src="img/java_coffee_cup_logo.png"/> 
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse"> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>
				</div>
				
				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
						<ul class="nav navbar-nav">
								<li class="active"> <a href="#">
										<h4><small>
												<label class="text-primary">Java 虚拟学习社区</label>
												</small></h4>
										</a> </li>
						</ul>	
						<!-- 功能模块-->
						<ul class="nav navbar-nav func-model">
										<li class="active"><a class="" href="home.aspx">Home</a></li>
										<li><a  href="#">教学动态</a></li>
										<li><a  href="#">知识地图</a></li>
										<li><a  href="#">程序范例</a></li>
										<li><a  href="#">课程视频</a></li>
										<li><a  href="#">作业平台</a></li>
										<li><a  href="#">学习评价</a></li>
										<li><a  href="#">交流社区</a></li>
						</ul>
						<ul class="nav navbar-nav navbar-right my-navbar-right">
								<li><a data-toggle="modal" data-target="#LoginModal" href="#">
										<h4><small>登录</small></h4>
										</a></li>
								<li><a data-toggle="modal" data-target="#RegModal" href="#">
										<h4><small>注册</small></h4>
										</a></li>
								<li class="dropdown"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">
										<h4><small>更多<b class="caret"></b></small></h4>
										</a>
										<ul class="dropdown-menu">
												<li><a href="#">寻求帮助</a></li>
												<li class="divider"></li>
												<li><a href="#">联系我们</a></li>
										</ul>
								</li>
						</ul>
				</div>
				<!-- /.navbar-collapse --> 
		</div>
</div>
<!-- end 固定在顶部的导航 --> 
<!-- start Modal -->
<div class="modal fade scroll-hidden" id="LoginModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
		<div class="modal-dialog">
				<div class="modal-content">
						<div class="modal-header">
								<h4 class="modal-title">登录模态窗
										<button type="button" class="close text-right"  aria-hidden="true" data-dismiss="modal">&times;</button>
								</h4>
						</div>
						<div class="modal-body">
								<iframe  class="sign-frame" src="login.aspx" frameborder="0" ></iframe>
						</div>
						<div class="modal-footer"> </div>
				</div>
				<!-- /.modal-content --> 
		</div>
		<!-- /.modal-dialog --> 
</div>
<div class="modal fade scroll-hidden" id="RegModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
		<div class="modal-dialog">
				<div class="modal-content">
						<div class="modal-header">
								<h4 class="modal-title">注册模态窗
										<button type="button" class="close text-right"  aria-hidden="true" data-dismiss="modal">&times;</button>
								</h4>
						</div>
						<div class="modal-body">
								<iframe class="sign-frame" src="reg.aspx" frameborder="0"></iframe>
						</div>
						<div class="modal-footer"> </div>
				</div>
				<!-- /.modal-content --> 
		</div>
		<!-- /.modal-dialog --> 
</div>
<!--end modal --> 
<!-- 页面主体部分  -->
<div id="wrap"> 
		<!-- Begin page content -->
		<div class="container">
				<div class="page-header"> 
						<div class="masthead">
								<h3 class="text-muted">一起开始学习Java吧！</h3>
						</div>
				</div>
				<div id="myCarousel" class="carousel slide" data-ride="carousel"> 
						<!-- Indicators 轮播的页标-->
						<ol class="carousel-indicators">
								<li data-target="#myCarousel" data-slide-to="0" class=""></li>
								<li data-target="#myCarousel" data-slide-to="1" class="active"></li>
								<li data-target="#myCarousel" data-slide-to="2" class=""></li>
						</ol>
						<div class="carousel-inner">
								<div class="item">
										<div class="container">
												<div class="text-center"> <img alt="goods" src="img/psb (7).jpg"/></div>
												<div class="carousel-caption"> </div>
										</div>
								</div>
								<div class="item active">
										<div class="container">
												<div class="carousel-caption">
														<h1>Java</h1>
														<p>java[1]是一种可以撰写跨平台应用软件的面向对象的程序设计语言，是由Sun Microsystems公司于1995年5月推出的Java程序设计语言和Java平台（即JavaEE, JavaME, JavaSE）的总称.</p>
														<p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
												</div>
										</div>
								</div>
								<div class="item">
										<div class="container">
												<div class="carousel-caption">
														<h1>Java</h1>
														<p>java[1]是一种可以撰写跨平台应用软件的面向对象的程序设计语言，是由Sun Microsystems公司于1995年5月推出的Java程序设计语言和Java平台（即JavaEE, JavaME, JavaSE）的总称.</p>
														<p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
												</div>
										</div>
								</div>
						</div>
						<a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a> <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a> </div>
				<div class="alert alert-success text-center">
						<p class="lead">下面还有哦！！！！</p>
						<p>eclipse 集成环境下载 <a href="http://www.eclipse.org">www.eclipse.org</a></p>
				</div>
				<div class="table-bordered"> </div>
				<div class="text-center"><br/>
						<p>sdsdsd</p>
				</div>
		</div>
</div>
<!-- 页面主体部分  --> 

<!-- 固定在底部的页脚 -->
<div id="footer">
		<div class="container">
				<p class="text-muted text-center">Copyright © 2014 njujlxy  & Design By yW & Optimize For Web Page By Bootstrap </p>
		</div>
</div>
<!-- 固定在底部的页脚 -->
</body>
</html>
