<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.chitiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="Dl_chitiet" runat="server">
        <ItemTemplate>
            <div class="grid-box-small border-out">
                <div>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("HINHANH") %>' />
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("TENSANPHAM") %>'></asp:Label>
                    </br>
                    </br>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("MOTA") %>'></asp:Label>
                    </br>
                    </br>
                    <asp:Label ID="Label3" runat="server" Text='<%#"Đơn Giá: "+Eval("GIA") %>'></asp:Label>
                    </br>
                    <asp:Label ID="Label4" runat="server" Text='<%#"Số lượng tồn kho: "+Eval("SOLUONG") %>'></asp:Label>
                    </br>
                    <asp:Label ID="Label5" runat="server" Text="Số hàng đã mua: " Visible="false"></asp:Label>
                    <asp:Label ID="soluong" runat="server" Text="Số Lượng: "></asp:Label>
                    <asp:TextBox ID="txtsoluong" runat="server"></asp:TextBox>
                    </br>
                    </br>
                    <asp:Button ID="Button1" runat="server" Text="Mua" OnClick="Button2_Click" CommandArgument='<%# Eval("MASANPHAM") %>' />
                    <asp:Button ID="Button2" runat="server" Text="Xem giỏ hàng" OnClick="Button3_Click" />
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="panel panel-primary" style="margin: 20px;">
        <div class="panel-body">
            <div class="col-md-6 col-sm-6">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="commentbox">
                            <b>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("TENKHACHHANG") %>'>'></asp:Label></b><br />
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Comment") %>'></asp:Label><br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-12 col-sm-12">
                <div class="form-group col-md-6 col-sm-6">
                    <label for="mobile">Comment*</label>
                    <textarea class="form-control  input-sm" id="comment" placeholder="" cols="3" rows="3" runat="server"> 
                </textarea>
                </div>
                <div class="form-group col-md-6 col-sm-6">
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Post" CssClass="btn  btn-success" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>
</asp:Content>
