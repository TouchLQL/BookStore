<%@ Page Language="C#" Theme="Admin" AutoEventWireup="true" CodeBehind="UserAddOrEdit.aspx.cs" Inherits="BookShop.web.back.UserAddOrEdit" %>

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
             <div id="navi">你的位置：用户管理>>用户编辑</div>
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
                <td class="K">用户名</td>
                <td class="V">
                    <asp:TextBox ID="txtUserName" name="txtUserId" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">姓名</td>
                <td class="V">
                    <asp:TextBox ID="txtRealName" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">密码</td>
                <td class="V">
                    <asp:TextBox ID="txtPassword" CssClass="text" runat="server" TextMode="Password"></asp:TextBox>
                </td>                
            </tr>    
            <tr>
                <td class="K">年龄</td>
                <td class="V">
                    <asp:TextBox ID="Textage" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>       
            <tr>
                <td class="K">性别</td>
                <td class="V">
                    <asp:RadioButtonList ID="rblSex" CssClass="text" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>                
            </tr>
            <tr>
                <td class="K">Email</td>
                <td class="V">
                    <asp:TextBox ID="txtEmail" CssClass="text" runat="server"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="K">电话</td>
                <td class="V">
                    <asp:TextBox ID="txtTelephone" CssClass="text" runat="server"></asp:TextBox>
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
