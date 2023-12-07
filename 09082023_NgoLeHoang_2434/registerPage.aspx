<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerPage.aspx.cs" Inherits="_09082023_NgoLeHoang_2434.registerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/style.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Đăng ký" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Fill in the box" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Fill in the box" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Fill in the box" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:RegularExpressionValidator Display="Dynamic"
                        ControlToValidate="TextBox1" ID="RegularExpressionValidator3"
                        ValidationExpression="^[\s\S]{8,16}$" runat="server"
                        ErrorMessage="Minimum 8 and Maximum 16 characters required for username."></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:RegularExpressionValidator Display="Dynamic"
                        ControlToValidate="TextBox3" ID="RegularExpressionValidator2"
                        ValidationExpression="^[\s\S]{8,16}$" runat="server"
                        ErrorMessage="Minimum 8 and Maximum 16 characters required for password."></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ErrorMessage="Message must contain atleast 1: uppercase character, lowercase character, number, special character (including periods, underscores, etc."
                        ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?^[a-zA-Z0-9_@.-]).{8,}$"
                        ControlToValidate="TextBox2"
                        ></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                        ErrorMessage="Message must contain atleast 1: uppercase character, lowercase character, number, special character (including periods, underscores, etc."
                        ValidationExpression="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?^[a-zA-Z0-9_@.-]).{8,}$"
                        ControlToValidate="TextBox3"
                        ></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:RegularExpressionValidator Display="Dynamic"
                        ControlToValidate="TextBox2" ID="RegularExpressionValidator1"
                        ValidationExpression="^[\s\S]{8,16}$" runat="server"
                        ErrorMessage="Minimum 8 and Maximum 16 characters required for password."></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:CompareValidator ID="CompareValidator1"
                        Display="Static"
                        runat="server"
                        ErrorMessage="Password is not the same"
                        ControlToValidate="TextBox2" ControlToCompare="TextBox3"></asp:CompareValidator>
                </div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <asp:Button ID="Button2" runat="server" Text="Quay lại" OnClick="Button2_Click" CausesValidation="false"  Visible="False" />
            </div>
        </div>
        <p>
        </p>
    </form>
</body>
</html>
