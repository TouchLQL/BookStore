<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassword.aspx.cs" Inherits="BookShop.web.front.FindPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../css/find.css" rel="stylesheet" type="text/css" />
<link href="../css/comment.css" rel="stylesheet" type="text/css" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" charset="utf-8" src="../js/jquery-3.1.1.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/bootstrap.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/find.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/login.js"></script>

    <title>找回密码</title>
</head>
<body>
    <div>
	    <%--<input id="searchBox" type="text" class="searchbook" name="bookName"/>
	  	<img src="../images/search-icon.png"  alt="搜索图标" class="img3" id="searchButton2"/>--%>
	  	<a id="login" class="h-login" >登录</a>
	  	&nbsp;&nbsp;
	  	<a href="../front/register.aspx" id="registerButton" class="fontStyle2 font">注册</a>
	  </div>

    <div class="center">
        请致电62567788联系管理员重置密码！
    </div>

    <div id="curtain"></div>
	<div id="alertBox">
        <input id="userName" name="userName" type="text" class="inputStyle1"/>
		<input id="password" name="password" type="text" class="inputStyle2"/>
        <a class="forget" href="FindPassword.aspx">忘记密码?</a>
        <a class="zhuce" href="register.aspx">注册?</a>
		<input type="image" alt="登录按钮" id="loginButton" src="../images/login_button.png" onclick="login()"/>
		<div id="cancelButton" class="close">
			<img src="../images/cancel_button2.png"/>
		</div>
	</div>
</body>
</html>
