<%@ Page Title="Chi tiết sách" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibraryWebForm.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .book-details-container {
            display: flex;
            justify-content: space-between;
            margin: 20px;
            padding: 20px;
            background-color: #282828;
            border-radius: 10px;
            color: white;
        }
        .book-info {
            flex: 2;
            padding-right: 20px;
        }
        .book-info h1 {
            color: #4caf50;
        }
        .book-info p {
            margin: 5px 0;
        }
        .book-info .label {
            font-weight: bold;
        }
        .book-info .tag {
            display: inline-block;
            background-color: #2196f3;
            color: white;
            padding: 5px 10px;
            margin: 5px;
            border-radius: 5px;
        }
        .book-cover {
            flex: 1;
            text-align: center;
        }
        .book-cover img {
            max-width: 100%;
            border-radius: 10px;
        }
        .button {
            display: inline-block;
            padding: 10px 20px;
            margin-top: 20px;
            color: white;
            background-color: #4caf50;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
        }
        .button:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="book-details-container">
        <div class="book-info">
            <h1><asp:Label ID="TitleLabel" runat="server"></asp:Label></h1>
            <p><span class="label">Tác giả:</span> <asp:Label ID="AuthorLabel" runat="server"></asp:Label></p>
            <p><span class="label">Nhà xuất bản:</span> <asp:Label ID="PublisherLabel" runat="server"></asp:Label></p>
            <p><span class="label">Năm xuất bản:</span> <asp:Label ID="PublicationYearLabel" runat="server"></asp:Label></p>
            <p><span class="label">Thể loại:</span> 
                <asp:Label ID="GenreLabel" runat="server"></asp:Label>
            </p>
            <p><span class="label">Nội dung:</span> <asp:Label ID="DescriptionLabel" runat="server"></asp:Label></p>
        </div>
        <div class="book-cover">
            <asp:Image ID="CoverImage" runat="server" AlternateText="Book Cover" />
            <asp:Button ID="RentButton" runat="server" Text="Thuê Sách" CssClass="button" OnClick="RentButton_Click" />
        </div>
        </div>
    </div>
</asp:Content>
