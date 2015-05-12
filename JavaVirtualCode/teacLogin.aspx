<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacLogin.aspx.cs" Inherits="teacLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教师登陆</title>

    <script src="dist/jquery.min.js"></script>

    <link rel="Stylesheet" href="dist/css/bootstrap.min.css" />
    <link rel="Stylesheet" href="css/teacher.css" />

    <script src="js/teacher.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="container" class="container">
        <div class="row">
            <div class="container" style="width: 100%; padding: 0;">
                <div class="row head">
                    <img src="img/javaVirtual_head1.fw.png" class="bg_img img-responsive" />
                </div>
            </div>
            <div class="container" style="width: 100%">
                <div class="row">
                    <div id="left_nav" class="col-md-12">
                        <div class="container">
                            <div class="row">
                                </br>
                                </br>
                                <div class="col-md-offset-4 col-md-4">
                                    <h2 style="color: #009966; text-align: center; font-weight: bold;">
                                        教师登录</h2>
                                    </br>
                                    <input id='ln' type='text' class='input_text form-control' placeholder="帐号" />
                                    <input id='pw' type='passWord' class='input_text form-control' placeholder="密码" /></br>
                                    <a id='btnSubmit' class="btn btn-lg btn-primary btn-block">登陆</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
        <div class="container">
        </div>
    </div>
    </form>

    <script>
        var footerStr = "<label style=\"width:100%; margin:0px; text-align:center; display:block;\">Copyright © 2014 njujlxy & Optimize For Web Page By Bootstrap</label>"+
        "<a style=\"width:100%; text-align:center; font-size:12px; height:18px; float:left;\" href=\"home.aspx\">学生界面</a>";
        $("#footer .container").html(footerStr);
    </script>

    </form>
</body>
</html>
