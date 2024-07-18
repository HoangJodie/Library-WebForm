<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LibraryWebForm.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Book Management</title>
    <style>
        /* General Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            margin: 0;
        }

        /* Container */
        .container {
            max-width: 1500px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        h1 {
            text-align: center;
            color: #333;
        }

        /* Input Fields */
        input[type="text"], input[type="password"], input[type="number"], textarea {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        /* Buttons */
        .btn {
            background-color: #007bff;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            margin-top: 10px;
            display: inline-block;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        /* GridView */
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .gridview th {
            background-color: #007bff;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Quản Lý Sách</h1>
            <div>
                <asp:TextBox ID="SearchBox" runat="server" placeholder="Search by title or author" CssClass="form-control" />
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn" OnClick="SearchButton_Click" />
                <asp:Button ID="AddNewBookButton" runat="server" Text="Thêm Sách Mới" CssClass="btn" OnClick="AddNewBookButton_Click" />
                <asp:Button ID="Logout" runat="server" Text="Đăng xuất" CssClass="btn" OnClick="LogoutButton_Click" />
            </div>
            <br /><br />
            <asp:GridView ID="BooksGridView" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                DataKeyNames="BookID"
                OnRowEditing="BooksGridView_RowEditing" OnRowDeleting="BooksGridView_RowDeleting"
                OnRowUpdating="BooksGridView_RowUpdating" OnRowCancelingEdit="BooksGridView_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="GenreId" HeaderText="Genre" />
                    <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Available" HeaderText="Available" />
                    <asp:BoundField DataField="CoverImageUrl" HeaderText="Cover Image URL" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
