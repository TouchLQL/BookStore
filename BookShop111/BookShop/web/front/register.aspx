<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BookShop.web.front.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="../css/register.css" rel="stylesheet" type="text/css" />
<link href="../css/comment.css" rel="stylesheet" type="text/css" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
<link href="../css/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css" />
<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" charset="utf-8" src="../js/jquery-3.1.1.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/bootstrap.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/bootstrap-datetimepicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/register.js"></script>
<script type="text/javascript" charset="utf-8" src="../js/login.js"></script>
    <title>注册</title>


</head>
<body>
    <div>
	   <%-- <input id="searchBox" type="text" class="searchbook" name="bookName"/>
	  	<img src="../images/search-icon.png"  alt="搜索图标" class="img3" id="searchButton2"/>--%>
	  	<a id="login" class="h-login" >登录</a>
	  	&nbsp;&nbsp;
	  	<a href="../front/register.aspx" id="registerButton" class="fontStyle2 font">注册</a>
	  </div>
      
     <div class="maincontainer">
         <div class="form"> 
            <form class="form-horizontal" role="form" >
            	
               <div class="form-group">
                     <label for="clientNo" class="col-sm-2 control-label">用户名</label>
                     <div class="col-sm-6">
                        <input type="text" class="form-control" id="userName2" name="clientNo1" placeholder="请输入用户名" />
                     </div>
                      <label for="firstname1" class="col-sm-3 control-label1" id=""></label>
              </div>
              
              	
               <div class="form-group">
                     <label for="password" class="col-sm-2 control-label">密&nbsp;码</label>
                     <div class="col-sm-6">
                        <input type="password" class="form-control" id="password2" placeholder="请输入密码" maxlength="16" />
                     </div>
                     <label for="firstname1" class="col-sm-3 control-label1" id="passwordPrompt"></label>
              </div>  
                 <div class="form-group"> 
                    <label for="password" class="col-sm-2 control-label">性&nbsp;别</label>
                      <div class="col-sm-6">
                        <label class="radio-inline"> 
                          <input type="radio"  value="男性" name="sex"/>男性  
                        </label> 
                        <label class="radio-inline"> 
                          <input type="radio"  value="女性" name="sex"/>女性  
                        </label>                    
                    </div> 
                  </div>             
              <div class="form-group">
                     <label for="clientNo" class="col-sm-2 control-label">生&nbsp;日</label>
                     <div class="col-sm-6">
                        <input class="form_datetime form-control" id="birth" type="text"/>
                     </div>
              </div>
                <div class="form-group">
                     <label for="clientNo" class="col-sm-2 control-label">邮&nbsp;箱</label>
                     <div class="col-sm-6">
                        <input type="text" class="form-control" id="mail" name="clientNo1" placeholder="请输入账号" />
                     </div>
                      <label for="firstname1" class="col-sm-3 control-label1" id=""></label>
              </div>
                <div class="form-group">
                     <label for="clientNo" class="col-sm-2 control-label">真实姓名</label>
                     <div class="col-sm-6">
                        <input type="text" class="form-control" id="realName" name="clientNo1" placeholder="请输入账号"  />
                     </div>
                      <label for="firstname1" class="col-sm-3 control-label1" id=""></label>
              </div>
               <div class="form-group">
                     <label for="mobilePhone" class="col-sm-2 control-label">收货地址</label>
                     <div class="col-sm-6">
                        <input type="text" class="form-control" id="address" placeholder="请输入通讯地址"  />
                     </div>
                     <label for="firstname1" class="col-sm-3 control-label1" id="mobilePrompt"></label>
              </div>            
              
                <div class="form-group">
                     <label for="fixedTelephone" class="col-sm-2 control-label">联系电话</label>
                     <div class="col-sm-6">
                        <input type="text" class="form-control" id="telephone" placeholder="请输入联系电话"  />
                     </div>
                      <label for="firstname1" class="col-sm-3 control-label1" id="fixedPrompt"></label>
              </div>
           
              </form>
             <input type="image" src="../images/addGreenButton.png" id="register"  alt="添加按钮" class="button_style" onclick="adduser()"/>
             <input type="image" src="../images/cancel_button.png"  alt="取消按钮" class="button_style"/>
          </div>
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