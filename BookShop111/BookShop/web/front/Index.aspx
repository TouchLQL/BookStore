<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookShop.web.front.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<link href="../css/index.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" charset="utf-8" src="../js/jquery-1.11.1.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/jquery-3.1.1.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/index.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/login.js"></script>
    <title>首页</title>
</head>
<body>
   
	  <div>
	    <%--<input id="searchBox" type="text" class="searchbook" name="bookName"/>
	  	<img src="../images/search-icon.png"  alt="搜索图标" class="img3" id="searchButton2"/>--%>
	  	<a id="login" class="h-login" >登录</a>
        <asp:Label ID="Label1" class="h-login2" runat="server" Text=""></asp:Label>
	  	&nbsp;&nbsp;
	  	<a href="../front/register.aspx" id="registerButton" class="fontStyle2 font">注册</a>
	  </div>
      <ul id="bookMenu" >
          <li class="listyle1" aria-valuetext="all" ><a href="index.aspx">全部分类</a></li>
          <li class="listyle" aria-valuetext="计算机类" onclick="getbytype(this)">计算机类</li>
          <li class="listyle" aria-valuetext="小说类" onclick="getbytype(this)">小说类</li>
          <li class="listyle" aria-valuetext="科技类" onclick="getbytype(this)">科技类</li>
          <li class="listyle" aria-valuetext="其他类" onclick="getbytype(this)">其他类</li>
	  </ul>
	  <div id="bookPictures" class="bookPictures"></div>
    
    
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
