<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryWebForm.AddBook" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm Sách Mới</title>
    <style>
        /* General Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 20px;
        }

        /* Container */
        .container {
            max-width: 800px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Thêm Sách Mới</h1>
            <asp:TextBox ID="TitleBox" runat="server" placeholder="Title" CssClass="form-control" />
            <asp:TextBox ID="AuthorBox" runat="server" placeholder="Author" CssClass="form-control" />
            <asp:TextBox ID="PublisherBox" runat="server" placeholder="Publisher" CssClass="form-control" />
            <asp:TextBox ID="ISBNBox" runat="server" placeholder="ISBN" CssClass="form-control" />
            <asp:TextBox ID="GenreBox" runat="server" placeholder="Genre" CssClass="form-control" />
            <asp:TextBox ID="PublicationYearBox" runat="server" placeholder="Publication Year" CssClass="form-control" />
            <asp:TextBox ID="QuantityBox" runat="server" placeholder="Quantity" CssClass="form-control" />
            <asp:TextBox ID="AvailableBox" runat="server" placeholder="Available" CssClass="form-control" />
            <asp:TextBox ID="CoverImageUrlBox" runat="server" placeholder="Cover Image URL" CssClass="form-control" />
            <asp:TextBox ID="DescriptionBox" runat="server" placeholder="Description" TextMode="MultiLine" Rows="4" CssClass="form-control" />
            <asp:Button ID="AddButton" runat="server" Text="Thêm Sách" CssClass="btn" OnClick="AddButton_Click" />
        </div>
    </form>
</body>
</html>
