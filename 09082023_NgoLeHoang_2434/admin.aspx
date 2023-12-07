<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <title>Admin Page</title>
    <style type="text/css">
        th {
            background-color: #eef4fa;
            border-top: solid 1px #9dbbcc;
            border-bottom: solid 1px #9dbbcc;
        }

        .itemSeparator {
            border-right: 1px solid #ccc
        }

        .groupSeparator {
            height: 1px;
            background-color: #cccccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <h3>DataPager Example</h3>

        <!-- The first DataPager control. -->
        <asp:DataPager runat="server" ID="BeforeListDataPager"
            PagedControlID="ProductsListView"
            PageSize="18">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowFirstPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false" />
                <asp:NumericPagerField ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowLastPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>

        <asp:ListView ID="ProductsListView"
            GroupItemCount="3"
            runat="server" OnSelectedIndexChanged="ProductsListView_SelectedIndexChanged">
            <LayoutTemplate>
                <table cellpadding="2" width="640px" id="tbl1" runat="server">
                    <tr>
                        <th colspan="5">PRODUCTS LIST</th>
                    </tr>
                    <tr runat="server" id="groupPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="tr1">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <GroupSeparatorTemplate>
                <tr runat="server">
                    <td colspan="5">
                        <div class="groupSeparator">
                            <hr>
                        </div>
                    </td>
                </tr>
            </GroupSeparatorTemplate>
            <ItemTemplate>
                <td align="center" runat="server">
                    <asp:HyperLink ID="ProductLink" runat="server"
                        Text='<%# Eval("TENSANPHAM") %>'
                        NavigateUrl='<%# "chitiet.aspx?ml=" + Eval("MASANPHAM") %>' /><br />
                    <asp:Image ID="ProductImage" runat="server"
                        ImageUrl='<%#Eval("HINHANH") %>' /><br />
                    <b>Giá:</b> <%# Eval("GIA", "{0:c}")%>
                    <br />
                    <b>Số lượng:</b> <%# Eval("SOLUONG")%>
                    <br />
                    <b>Mã sản phẩm:</b> <%# Eval("MASANPHAM")%>
                    <br />
                    <b>Mã loại:</b> <%# Eval("MALOAI")%>
                    <br />
                    <asp:Button ID="Button4" OnClick="ProductsListView_SelectedIndexChanged" CommandArgument='<%# Eval("MASANPHAM") %>' runat="server" Text="Xóa" />
                </td>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <td class="itemSeparator" runat="server">&nbsp;</td>
            </ItemSeparatorTemplate>
        </asp:ListView>
        <div>
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Thêm loại hàng" />
            </div>
            <div>
                <div ="form-group">
                    <asp:Label ID="l11" runat="server" Visible="false" Text="Mã loại"></asp:Label>
                    <asp:TextBox ID="t11" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
                </div>
                <div ="form-group">
                    <asp:Label ID="l12" Visible="false" runat="server" Text="Tên loại"></asp:Label>
                    <asp:TextBox ID="t12" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="b1" runat="server" Text="Update" Visible="false" OnClick="b1_Click" />
                </div>
            </div>
        </div>

        <div>
            <asp:Button ID="Button2" runat="server" Text="Thêm hàng tồn kho" OnClick="Button2_Click" />
        </div>
        <div>
            <div ="form-group">
                <asp:Label ID="l21" runat="server" Visible="false" Text="Mã hàng"></asp:Label>
                <asp:TextBox ID="t21" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div ="form-group">
                <asp:Label ID="l22" Visible="false" runat="server" Text="Số lượng"></asp:Label>
                <asp:TextBox ID="t22" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="b2" runat="server" Text="Update" Visible="false" OnClick="b2_Click" />
            </div>
        </div>
        <div>
            <asp:Button ID="Button3" runat="server" Text="Thêm hàng mới" OnClick="Button3_Click" />
        </div>
        <div>
            <div class="form-group">
                <asp:Label ID="l31" runat="server" Visible="false" Text="Mã sản phẩm"></asp:Label>
                <asp:TextBox ID="t31" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="l32" Visible="false" runat="server" Text="Tên sản phẩm"></asp:Label>
                <asp:TextBox ID="t32" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="l33" runat="server" Visible="false" Text="Mô tả"></asp:Label>
                <asp:TextBox ID="t33" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="l34" runat="server" Visible="false" Text="Giá"></asp:Label>
                <asp:TextBox ID="t34" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="l35" runat="server" Visible="false" Text="Hình ảnh"></asp:Label>
                <asp:FileUpload ID="FileUpload1" Visible="false" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label ID="l36" runat="server" Visible="false" Text="Mã loại"></asp:Label>
                <asp:TextBox ID="t36" Visible="false" runat="server" CssClass="form-control" aria-label="Default"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="l37" Visible="false" runat="server" Text="Số lượng"></asp:Label>
                <asp:TextBox ID="t37" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="b3" runat="server" Text="Update" Visible="false" OnClick="b3_Click" />
            </div>
        </div>
        <asp:Label ID="lbthongbao" runat="server" Text=""></asp:Label>

        <!-- The second DataPager control. -->
        <asp:DataPager runat="server" ID="AfterListDataPager"
            PagedControlID="ProductsListView"
            PageSize="18">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowFirstPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false" />
                <asp:NumericPagerField ButtonCount="10" />
                <asp:NextPreviousPagerField ButtonType="Image"
                    ShowLastPageButton="true"
                    ShowNextPageButton="false"
                    ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>


    </form>
</body>
</html>
