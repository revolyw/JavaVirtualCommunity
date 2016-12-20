<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<meta charset="utf-8" content="charset" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title>Reg</title>
	<!-- Bootstrap core CSS -->
	<link href="dist/css/bootstrap.css" rel="stylesheet" />
	<link href="css/signin.css" rel="stylesheet" />
</head>
<body>
	<div class="container" style="font-family:幼圆;">
		<form runat="server" class="form-signin" role="form" action="" target="_parent">
		<h2 style="font-family:幼圆; padding-left:35px;">
			赶紧加入我们吧！</h2>
		<div class="form-group">
			<label for="">
				帐号</label>
			<input runat="server" id="ln" type="text" class="form-control" placeholder="帐号" />
		</div>
		<div class="form-group">
			<label for="exampleInputPassword1">
				密码</label>
			<input runat="server" id="pw" type="password" class="form-control" placeholder="密码"/>
		</div>
		<div class="form-group">
			<label for="exampleInputPassword1">
				密码确认</label>
			<input runat="server" id="_pw" type="password" class="form-control" placeholder="密码确认"/>
		</div>
		<!--
		<div class="form-group">
			<label for="exampleInputPassword1">
				邮箱</label>
			<input type="email" class="form-control" placeholder="邮箱" />
		</div>-->
		<div class="form-group">
			<label for="exampleInputPassword1">
				姓名</label>
			<input runat="server" id="name" type="text" class="form-control" placeholder="姓名" />
		</div>
		<div class="form-group">
			<label for="exampleInputPassword1">
				学号</label>
			<input runat="server" id="no" type="text" class="form-control" placeholder="学号" />
		</div>
		<div class="form-group">
			<asp:Button runat="server" class="btn btn-lg btn-success btn-block" style="background:url(img/register2.png) no-repeat; background-size:100% 100%; border:0; width:300px;" type="submit"
				Text="立即注册" OnClick="Unnamed1_Click" />
		</div>
		</form>
	</div>
	<!-- /container -->
</body>
</html>
