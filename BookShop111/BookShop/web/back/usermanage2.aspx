<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="usermanage2.aspx.cs" Inherits="BookShop.web.back.usermanage2" %>

<%@ Register Src="~/UserControl/PagePart2.ascx" TagPrefix="uc1" TagName="PartPages2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />

    <link href="../css/usersManage.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/tableTemplate.js"></script>
    <script src="../js/userManage.js"></script>
        <title></title>
</head>

<body>
     <form id="Form1" runat="server">
       <input id="hidId" name="hidId" type="hidden" />
       <div id="page" >
           <div class="pageHeader" >
                <div id="swap">
                     <div id="navi">你的位置：用户管理</div>
                 </div>
           </div>

           <div class="pageContent">
	                <div class="panelBar"  id="divOperateButton" runat="server">
		                <ul class="toolBar">
                          <li>
                                 <asp:LinkButton ID="LinkAdd" CssClass="add" runat="server"
                                   onclick="linkOper_Click" OnClientClick="getId()" ><span>添加</span></asp:LinkButton>
                            </li>   
			                <li>
                                 <asp:LinkButton ID="linkEdit" CssClass="edit" runat="server"
                                   onclick="linkOper_Click" OnClientClick="getId()" ><span>修改</span></asp:LinkButton>
                            </li>                              
                            <li>
                                 <asp:LinkButton ID="linkDelete" CssClass="delete" runat="server"
                                   onclick="linkOper_Click" OnClientClick="getId1()"><span>删除</span></asp:LinkButton>
                            </li>                             
		                </ul>
                        &nbsp;&nbsp;                            
                            用户编号：<asp:TextBox ID="txtUserId" runat="server" CssClass="text" Width="100px"></asp:TextBox>                            
                            用户姓名：<asp:TextBox ID="txtRealName" runat="server" CssClass="text"></asp:TextBox>                            
                                <asp:Button ID="Button_search" runat="server" Text="查询" CssClass=" btnBlue" OnClick="Button_search_Click" />  
	                </div>
                          
               <div class="grid" id="Div1" runat="server"><!---信息显示-->
		                <div class="gridHeader" style="width:100%;">
                            <div class="gridThead" style="position:relative;">
                                <table style="width:99%;" id="Table2" runat="server" >
                                    <thead >
			                            <tr >		                                                                    
			     	                        <th style="width:100px;">用户编号</th>
                                            <th style="width:120px;">用户姓名</th>
                                            <th style="width:120px;">密码</th>
			    	                        <th style="width:100px;">性别</th> 
                                            <th style="width:100px;">年龄</th>
                                            <th style="width:100px;">邮箱</th>
                                            <th style="width:100px;">电话</th>
                                            <th style="width:100px;">地址</th>
                                            <th style="width:100px;">类型</th>                                                                                 
			                            </tr>
		                            </thead>
                                </table>
                            </div>
                        </div>
		                <div  class="gridScroller"  style="width:100%; overflow:auto">
                            <div  class="gridTbody">
                                <table>                                    
                                    <tbody>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("userID")%>
                                                          <span class="id" style="display:none"><%#Eval("userId")%></span>
                                                    </td >                                                    
                                                    <td  style="text-align:center;width:120px;">
                                                        <%#Eval("realName")%>
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("password")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("sex")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("age")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("email")%>
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("telephone")%>
                                                    </td>  
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("address")%>
                                                    </td>   
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("type")%>
                                                    </td>                                                                          
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                             </div>
                        </div>
                    
  	                <div class="panelBar">
		                    <uc1:PartPages2 runat="server" ControlId="Repeater2" ID="PartPages2" />
	                 </div>
                </div>
            </div>
       </div>
   </form>
</body>
</html>
