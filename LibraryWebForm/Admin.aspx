<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LibraryWebForm.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Book Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Book Management</h1>
            <asp:TextBox ID="SearchBox" runat="server" placeholder="Search by title or author" />
            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
            <br /><br />
            <asp:GridView ID="BooksGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="BooksGridView_RowEditing" OnRowDeleting="BooksGridView_RowDeleting" OnRowUpdating="BooksGridView_RowUpdating" OnRowCancelingEdit="BooksGridView_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" />
                    <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Available" HeaderText="Available" />
                    <asp:BoundField DataField="CoverImageUrl" HeaderText="Cover Image URL" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <br /><br />
            <asp:TextBox ID="TitleBox" runat="server" placeholder="Title" />
            <asp:TextBox ID="AuthorBox" runat="server" placeholder="Author" />
            <asp:TextBox ID="PublisherBox" runat="server" placeholder="Publisher" />
            <asp:TextBox ID="ISBNBox" runat="server" placeholder="ISBN" />
            <asp:TextBox ID="GenreBox" runat="server" placeholder="Genre" />
            <asp:TextBox ID="PublicationYearBox" runat="server" placeholder="Publication Year" />
            <asp:TextBox ID="QuantityBox" runat="server" placeholder="Quantity" />
            <asp:TextBox ID="AvailableBox" runat="server" placeholder="Available" />
            <asp:TextBox ID="CoverImageUrlBox" runat="server" placeholder="Cover Image URL" />
            <asp:TextBox ID="DescriptionBox" runat="server" placeholder="Description" TextMode="MultiLine" Rows="4" />
            <asp:Button ID="AddButton" runat="server" Text="Add Book" OnClick="AddButton_Click" />
        </div>
    </form>
</body>
</html>
