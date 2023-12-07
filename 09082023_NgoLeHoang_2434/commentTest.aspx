<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="commentTest.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.commentTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-primary" style="margin: 20px;">
            <div class="panel-heading">
                <h3 class="panel-title">Comment Form</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-6 col-sm-6">
                    <div class="form-group col-md-6 col-sm-6">
                        <label for="name">Name*     </label>
                        <asp:TextBox ID="name" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6 col-sm-6">
                        <label for="email">Item ID*</label>
                        <asp:TextBox ID="email" runat="server" CssClass="form-control  input-sm"></asp:TextBox>
                    </div>
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
                <div class="col-md-6 col-sm-6">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="commentbox">
                                <b>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'>'></asp:Label></b>&nbsp;
                            (<asp:Label ID="Label2" runat="server" Text='<%#Eval("MASANPHAM") %>'>'></asp:Label>):<br />
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Comment") %>'></asp:Label><br />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="lbthongbao" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
