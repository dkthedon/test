<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PostAnswer.aspx.cs" Inherits="QuestionPortal.Web.PostAnswer" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <asp:Label runat="server" Text="Write an answer" Font-Size="20" ForeColor="Red"></asp:Label>
        <hr />
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Question" Font-Bold="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblQuestion"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Answer"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAnswer" Rows="5"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button runat="server" ID="btnPostAnswer" CssClass="button" Text="Post" OnClick="btnPostAnswer_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
        </center>
</asp:Content>
