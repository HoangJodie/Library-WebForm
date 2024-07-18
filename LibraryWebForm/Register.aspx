<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryWebForm.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <style>
        /* General Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        /* Register Container */
        .register-container {
            background-color: #fff;
            padding: 20px 40px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            width: 300px;
            text-align: center;
        }

        h2 {
            margin-bottom: 20px;
            color: #333;
        }

        /* Input Fields */
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
            text-align: left;
        }

        /* Button */
        .btn {
            background-color: #007bff;
            color: #fff;
            padding: 15px 20px; /* Increase the padding to make the button larger */
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            margin-top: 10px;
            font-size: 18px; /* Increase the font size */
        }

        .btn:hover {
            background-color: #0056b3;
        }

        /* Links */
        a {
            color: #007bff;
            text-decoration: none;
            margin-top: 20px;
            display: inline-block;
        }

        a:hover {
            text-decoration: underline;
        }

        /* Error Message */
        .error-message {
            color: red;
            margin-bottom: 15px;
        }

        /* Media Queries for Responsive Design */
        @media (max-width: 600px) {
            .register-container {
                width: 90%;
                padding: 15px 20px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Đăng ký</h2>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="error-message"></asp:Label>
            <div>
                <asp:Label ID="UsernameLabel" runat="server" Text="Tên đăng nhập:"></asp:Label>
                <asp:TextBox ID="Username" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Mật khẩu:"></asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Xác nhận mật khẩu:"></asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="RegisterButton" runat="server" Text="Đăng ký" CssClass="btn" OnClick="RegisterButton_Click" />
            </div>
        </div>
    </form>
</body>
</html>
