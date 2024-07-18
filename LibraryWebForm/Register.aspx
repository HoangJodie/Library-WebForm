<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryWebForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
        <h2>Đăng ký</h2>
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
            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Xác nhận mật khẩu:"></asp:Label>
            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="RegisterButton" runat="server" Text="Đăng ký" OnClick="RegisterButton_Click" />
        </div>
    </div>
    </form>
</body>
</html>
