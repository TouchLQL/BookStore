<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="OrderAddOrEdit.aspx.cs" Inherits="BookShop.web.back.OrderAddOrEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pageHeader" >
        <div id="swap">
             <div id="navi">你的位置：订单管理>>订单编辑</div>
        </div>
     </div>

    <div class="divUser" >
    <table style="width:100%;" class="Fromtable">
            <tr>
                <td colspan="2" style="text-align: center" class="V">
                    <asp:Label ID="lblTitle" runat="server" Text="用户添加或修改"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="K">订单编号</td>
                <td class="V">
                    <asp:TextBox ID="txtorderid" name="txtUserId" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">用户</td>
                <td class="V">
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="userName" DataValueField="userID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BookShop %>" SelectCommand="SELECT [userID], [userName] FROM [user]"></asp:SqlDataSource>
                </td>                
            </tr>
            <tr>
                <td class="K">书名</td>
                <td class="V">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="bookName" DataValueField="bookID"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BookShop %>" SelectCommand="SELECT [bookID], [bookName] FROM [book]"></asp:SqlDataSource>
                </td>                
            </tr>
            <tr>
                <td class="K">订单时间</td>
                <td class="V">
                    <asp:TextBox ID="txtordertime" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>   
            <tr>
                <td class="K">价格</td>
                <td class="V">
                    <asp:TextBox ID="txtprice" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>       
            <tr>
                <td class="K">数量</td>
                <td class="V">
                    <asp:TextBox ID="txtnum" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">类型</td>
                <td class="V">
                    <asp:TextBox ID="txttype" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td colspan="2" style="text-align: center" class="V">
                    <asp:Button ID="btnOk" runat="server" Text="添加" CssClass="btnBlue" OnClick="btnOK_Click" />
                    <asp:Button ID="BtnReturn" runat="server" Text="返回" CssClass="btnBlue" OnClick="BtnReturn_Click"/>
                    <asp:Label ID="LblError" runat="server" ForeColor="#CC3300" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
