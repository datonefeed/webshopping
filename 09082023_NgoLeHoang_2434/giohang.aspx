<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="giohang.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.giohang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="LinkButton2_Click">Xóa</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên hàng" />
            <asp:BoundField DataField="MOTA" HeaderText="Mô tả" />
            <asp:BoundField DataField="GIA" HeaderText="Đơn giá" />
            <asp:TemplateField HeaderText="Số lượng">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("SOLUONG") %>' TextMode="Number"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("MASANPHAM") %>' OnClick="Button1_Click" Text="Chinh So luong" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ThanhTien" HeaderText="Thành tiền" />
        </Columns>
    </asp:GridView>
    <div>
    <asp:Button ID="bConfirm" runat="server" Text="Xác nhận"  OnClick="bConfirm_Click" />
    </div>
    <div>
    <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
