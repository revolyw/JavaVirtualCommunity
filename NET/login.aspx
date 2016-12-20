<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<meta charset="utf-8" content="charset"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<title>Login</title>

<!-- Bootstrap core CSS -->
<link href="dist/css/bootstrap.css" rel="stylesheet"/>
<link href="css/signin.css" rel="stylesheet"/>
</head>

<body>
<div class="container">
		<form runat="server" class="form-signin" role="form" action="" target="_parent" >
		        <img src="img/login2.png" style="position:absolute; top:9%; left:15%; width:40px;height:40px;" />
		        <img src="img/login3.png" style="position:absolute; top:25%; left:15%; width:40px;height:40px;"/>
		        <br />
				<input runat="server" id="userName" type="text" class="form-control" placeholder="帐号" />
				<br />
				<input runat="server" id="passWord" type="password" class="form-control" placeholder="密码" />
				<label class="checkbox">
						<input type="checkbox" value="remember-me" />
						记住密码 </label>
				<asp:Button ID="Button1" runat="server" 
					class="btn btn-lg btn-success btn-block" style="background:url(img/login_bt.jpg) no-repeat; background-size:100% 100%; border:0; width:300px;" type="submit" onclick="Button1_Click1" />
		</form>
</div>
<!-- /container --> 

</body>
</html>
