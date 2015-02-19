<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuestionPortal.Web.Login" Theme="MainTheme"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>Discussion Portal</title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
     <asp:Image ID="Image1" runat="server" ImageUrl="Images/home.jpg" />
    <div class="loginDiv">
        <asp:Label runat="server">Enter the Username and password to login</asp:Label>
        <br />
        <br />
        <asp:Table runat="server" CellSpacing="5" CellPadding="0">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox" placeholder="Username"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <input type="password" id="txtPaswword" runat="server" class="textBox" placeholder="Password" />
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button ID="btnLogin" runat="server" Text="Submit" CssClass="button" OnClick="btnLogin_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
            </center>
    </form>
    <div class="footerDiv" align="center">
        <asp:Label runat="server">© Copyright 2014 MNNIT Allahbad</asp:Label>
    </div>
</body>
</html>
