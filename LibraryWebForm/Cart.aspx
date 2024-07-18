<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LibraryWebForm.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-container {
            margin: 20px;
            padding: 20px;
            background-color: #282828;
            border-radius: 10px;
            color: white;
        }
        .cart-item {
            display: flex;
            justify-content: space-between;
            margin-bottom: 10px;
            padding: 10px;
            background-color: #444;
            border-radius: 5px;
        }
        .cart-item img {
            max-width: 50px;
            border-radius: 5px;
        }
        .cart-item .title {
            flex: 1;
            margin-left: 10px;
        }
        .cart-item .remove-button {
            background-color: #ff4c4c;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 5px 10px;
            cursor: pointer;
        }
        .cart-item .remove-button:hover {
            background-color: #ff1a1a;
        }
        .checkout-button {
            display: inline-block;
            padding: 10px 20px;
            color: white;
            background-color: #4caf50;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
        }
        .checkout-button:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="cart-container">
        <h1>Giỏ hàng</h1>
        <asp:Repeater ID="CartRepeater" runat="server">
            <ItemTemplate>
                <div class="cart-item">
                    <img src='<%# Eval("CoverImageUrl") %>' alt='<%# Eval("Title") %>' />
                    <div class="title"><%# Eval("Title") %></div>
                    <asp:Button ID="RemoveButton" runat="server" Text="Remove" CommandArgument='<%# Eval("BookID") %>' OnClick="RemoveButton_Click" CssClass="remove-button" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <a href="#" class="checkout-button">Thanh toán</a>
    </div>
</asp:Content>