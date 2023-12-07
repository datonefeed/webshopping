<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="sanpham.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.sanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Danh sách sản phẩm</h1>
    <asp:DataList ID="dl1" runat="server" RepeatColumns="2">
        <ItemTemplate>
            <div class="grid-box-small">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Eval("HINHANH") %>' CommandArgument='<%# Eval("MALOAI") %>' OnClick="ImageButton1_Click" />
            </div>
            <br />
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TENSANPHAM") %>'></asp:Label>
            </br>
            <asp:Label ID="Label2" runat="server" Text='<%#"Giá tiền:" + Eval("GIA") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
