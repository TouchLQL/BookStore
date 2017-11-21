<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backLogin.aspx.cs" Inherits="BookShop.web.back.backLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<link href="../css/backlogin.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" charset="utf-8" src="../js/jquery-3.1.1.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/backlogin.js"></script>

    <title>后台登陆页面</title>
</head>
<body>
    <div id= "form5">
        <p class="center"><br/><br/>
    	    <input type="text" id="account" name="account" class="input_style1"/><br/><br/>
    	    <input type="password" id="password" name="password" class="input_style2"/><br/><br/>
        </p>
     	<input type="image" src="../images/login_button2.png"  alt="登录按钮" class="img1" id="login_button" onclick="backlogin()"/>
    </div>
</body>
</html>
