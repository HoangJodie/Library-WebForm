<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LibraryWebForm.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .book-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
        }

        .book {
            width: calc(20% - 30px); /* Adjusting for margins */
            margin: 15px;
            text-align: center;
            border: 1px solid #ddd;
            border-radius: 5px;
            overflow: hidden;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s;
        }

        .book img {
            width: 100%;
            height: auto;
        }

        .book .title {
            padding: 10px;
            font-size: 14px;
            font-weight: bold;
            background-color: #f8f8f8;
            color: #333;
        }

        .book:hover {
            transform: scale(1.05);
        }

        .search-result {
            font-size: 18px;
            color: #333;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Danh sách các cuốn sách</h1>
    <div class="search-result" runat="server" id="SearchResult"></div>
    <div class="book-container" runat="server" id="BookContainer">
        <!-- Nội dung sẽ được thêm động từ code-behind -->
    </div>
</asp:Content>
