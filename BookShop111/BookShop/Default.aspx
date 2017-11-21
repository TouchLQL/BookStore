<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookShop.Default" %>
<%@ PreviousPageType VirtualPath="~/LeftMenu.aspx"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <title>book store</title>
    <link href="dwzThemes/default/style.css" rel="stylesheet" type="text/css" media="screen"/>
    <link href="dwzThemes/css/core.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="dwzThemes/css/print.css" rel="stylesheet" type="text/css" media="print"/>
    <!--[if IE]>
     <link href="themes/css/ieHack.css" rel="stylesheet" type="text/css" media="screen"/>
    <![endif]-->
    <style>
        .tabsPageContent .page
        {
            overflow:auto;
            height:100%;
        }
        .page iframe
        {
            height:100%;
            width:100%;
        } 
        a#exitLogo
        {
            color:Blue;
            text-decoration:none;
        }
        a#exitLogo:hover
        {
            color:Red;
        }
        ul#themeList li
        {
            height:20px;
            line-height:20px;
        }           
    </style>
    <script src="dwzJs/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="dwzJs/dwz_min.js" type="text/javascript"></script>
    <script src="dwzJs/dwz.regional.zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            DWZ.init("dwz.frag.xml", {
                loginUrl: "login_dialog.html", loginTitle: "登录", // 弹出登录对话框
                //		loginUrl:"login.html",	// 跳到登录页面
                statusCode: { ok: 200, error: 300, timeout: 301 }, //【可选】
                pageInfo: { pageNum: "pageNum", numPerPage: "numPerPage", orderField: "orderField", orderDirection: "orderDirection" }, //【可选】
                debug: false, // 调试模式 【true|false】
                callback: function () {
                    initEnv();
                    $("#themeList").theme({ themeBase: "themes" }); // themeBase 相对于index页面的主题base路径
                    //setTimeout(function () { $("#sidebar .toggleCollapse div").trigger("click"); }, 10);
                }
            });
        });
    </script>
    <script>
        //以iframe形式新建一个navTab
        function myOpenTab(tabId, url, title) {
            navTab.openTab(tabId, url, { title: title, fresh: true, external: true, data: {} });
        }
    </script>
</head>
<body scroll="no">
        <div id="layout">
            <%--头部--%>
            <div id="header">
                <div class="headerNav">
                    <a class="logo" href="javascript:void(0)" style=" width:800px;">标志</a>
                   
                    <ul class="themeList" id="themeList">
                         <li>
                            <span style=" color:Black;" id="state-exit1">当前用户:</span>
                            <span style=" color:Black;" id="state-exit2"><%=LoginName %>&nbsp;|&nbsp;</span>
                            <a href="web/back/backLogin.aspx?reLogo=1" id="exitLogo">退出</a>
                         </li>
                         <li style="width:50px"></li>
                    </ul>
                </div>
            </div>
            <%--菜单--%>
            <div id="leftside">
                <div id="sidebar_s" style="display: none;">
                    <div class="collapse">
                        <div class="toggleCollapse">
                            <div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="sidebar" style="background:url(web/images/back_background.png) no-repeat 4px 5px;">
                    <div class="toggleCollapse">
                        <h2>主&nbsp;菜&nbsp;单</h2>   
                        <div>收缩</div>
                    </div>
                    <div class="accordion" fillSpace="sidebar" >
                        <%=GetLeftMenu()%>
                    </div>
                </div>
            </div>
            <%--显示部分--%>
            <div id="container" >
                <div id="navTab"  class="tabsPage">
                    <div class="tabsPageHeader">
                        <div class="tabsPageHeaderContent">
                            <!-- 显示左右控制时添加 class="tabsPageHeaderMargin" -->
                            <ul class="navTab-tab">
                                <li tabid="main" class="main"><a href="javascript:void(0)"><span><span class="home_icon">
                                    欢迎界面</span></span></a></li>
                            </ul>
                        </div>
                        <div class="tabsLeft">left</div><!-- 禁用只需要添加一个样式 class="tabsLeft tabsLeftDisabled" -->
				     	<div class="tabsRight">right</div><!-- 禁用只需要添加一个样式 class="tabsRight tabsRightDisabled" -->
				    	<div class="tabsMore">more</div>
                    </div>
                    <ul class="tabsMoreList">
                        <li><a href="javascript:void(0)">欢迎界面</a></li>
                    </ul>
                    <div class="navTab-panel tabsPageContent layoutBox">
                        <div class="page unitBox">                           
                            <iframe src="Welcome.aspx" style="width:100%;height:100%;position:absolute;z-index:2;border:0px" frameborder="0">         
                            </iframe>
                            <div class="accountInfo" style="margin:0px;padding:0px;height:100%;display:none">                             
                            </div>
                            <div class="pageFormContent" layoutH="80" style="margin-right:230px">
						    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--版权--%>
        <div id="footer">
          <form runat="server">
                <div style="width:65%;float:left;text-align:right;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Copyright &copy; 2016 &nbsp;&nbsp;&nbsp; Screen:1280*800&nbsp; ↑  </div>
                <div style="width:30%;float:left;text-align:right;">
                    <font>当前时间:</font>
                    <span id="nowTime"></span>
                </div>
            </form>
         </div>
        <script>
            var t; //计时器
            var showTimeSpan = document.getElementById("nowTime");
            function getNowTime() {
                var myDate = new Date();
                var year = myDate.getFullYear();
                var mouth = getNum_2(myDate.getMonth() + 1);
                var day = getNum_2(myDate.getDate());
                var hours = getNum_2(myDate.getHours());
                var Minutes = getNum_2(myDate.getMinutes());
                var Seconds = getNum_2(myDate.getSeconds());
                showTimeSpan.innerHTML = year + "-" + mouth + "-" + day + "&nbsp;" + hours + ":" + Minutes + ":" + Seconds;
                t = setTimeout("getNowTime()", "1000");
            }

            function getNum_2(o) {
                if (o.toString().length == 1)
                    return "0" + o.toString();
                return o.toString();
            }
            getNowTime();
         </script>
</body>
</html>
