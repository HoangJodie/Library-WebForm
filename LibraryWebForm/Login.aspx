<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryWebForm.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
        <h2>Đăng nhập</h2>
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Tên đăng nhập:"></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Mật khẩu:"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Đăng nhập" OnClick="LoginButton_Click" />
        </div>
        <div>
            <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/Register.aspx">Đăng ký tài khoản mới</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
