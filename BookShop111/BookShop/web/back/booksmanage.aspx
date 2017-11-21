<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="booksmanage.aspx.cs" Inherits="BookShop.web.back.booksmanage" %>

<%@ Register Src="~/UserControl/PagePart2.ascx" TagPrefix="uc1" TagName="PagePart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<link href="../css/usersManage.css" rel="stylesheet" type="text/css" />

<script src="../js/jquery-1.9.1.min.js"></script>
<script src="../js/tableTemplate.js"></script>
<script src="../js/userManage.js"></script>
        <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <input id="hidId" name="hidId" type="hidden" />
       <div id="page" >
           <div class="pageHeader" >
                <div id="swap">
                     <div id="navi">你的位置：图书管理</div>
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
                            图书编号：<asp:TextBox ID="txtBookId" runat="server" CssClass="text" Width="100px"></asp:TextBox>                            
                            图书名称：<asp:TextBox ID="txtbookName" runat="server" CssClass="text"></asp:TextBox>                            
                                <asp:Button ID="Button_search" runat="server" Text="查询" CssClass=" btnBlue" OnClick="Button_search_Click" />  
	                </div>
                          
               <div class="grid" id="Div1" runat="server"><!---信息显示-->
		                <div class="gridHeader" style="width:100%;">
                            <div class="gridThead" style="position:relative;">
                                <table style="width:99%;" id="Table2" runat="server" >
                                    <thead >
			                            <tr >		                                                                    
			     	                        <th style="width:100px;">图书编号</th>
                                            <th style="width:120px;">图书名称</th>
                                            <th style="width:120px;">作者</th>
			    	                        <th style="width:100px;">出版社</th> 
                                            <th style="width:100px;">库存</th>
                                            <th style="width:100px;">价格</th>
                                            <th style="width:100px;">类型</th>
                                            <th style="width:100px;">图片</th>                                                                                
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
                                                        <%#Eval("bookID")%>
                                                          <span class="id" style="display:none"><%#Eval("bookID")%></span>
                                                    </td >                                                    
                                                    <td  style="text-align:center;width:120px;">
                                                        <%#Eval("bookName")%>
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("writer")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("press")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("stock")%>                                                        
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("price")%>
                                                    </td>
                                                    <td  style="text-align:center;width:100px;">
                                                        <%#Eval("type")%>
                                                    </td>  
                                                    <td  style="text-align:center;width:100px;">
                                                        <img style="width:30px;height:30px;" src="<%#Eval("picture")%>" />
                                                    </td>                                                                            
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                             </div>
                        </div>
                    
  	                <div class="panelBar">
		                    <uc1:PagePart2 runat="server" ControlId="Repeater2" ID="PartPages2" />
	                 </div>
                </div>
            </div>
       </div>
    </form>
</body>
</html>
