<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="QuestionPortal.Web.Post" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <asp:Label runat="server" Text="Post your Question" Font-Size="20" ForeColor="Red"></asp:Label>
        <hr />
        <asp:Table runat="server" CellSpacing="5">
            <asp:TableRow>
                <asp:TableCell>
        <asp:Label runat="server" Text="Question"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
        <asp:TextBox runat="server" TextMode="MultiLine" Rows="10" ID="txtQuestion"></asp:TextBox>
                    </asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
        <asp:Button runat="server" Text="Post" ID="btnPost" CssClass="button" OnClick="btnPost_Click" />
                    </asp:TableCell>
                </asp:TableRow>
        </asp:Table>
    </div>
    </center>
</asp:Content>
