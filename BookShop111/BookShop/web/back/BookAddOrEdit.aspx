<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="BookAddOrEdit.aspx.cs" Inherits="BookShop.web.back.BookAddOrEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="../css/usersManage.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="pageHeader" >
        <div id="swap">
             <div id="navi">你的位置：图书管理>>图书编辑</div>
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
                <td class="K">图书编号</td>
                <td class="V">
                    <asp:TextBox ID="txtbookID" name="txtUserId" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">书名</td>
                <td class="V">
                    <asp:TextBox ID="txtbookName" name="txtUserId" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">作者</td>
                <td class="V">
                    <asp:TextBox ID="txtwriter" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">出版社</td>
                <td class="V">
                    <asp:TextBox ID="txtPress" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>    
            <tr>
                <td class="K">价格</td>
                <td class="V">
                    <asp:TextBox ID="txtprice" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>       
            <tr>
                <td class="K">库存</td>
                <td class="V">
                    <asp:TextBox ID="txtstock" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">类型</td>
                <td class="V">
                    <asp:TextBox ID="txtType" CssClass="text" runat="server"></asp:TextBox>
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
