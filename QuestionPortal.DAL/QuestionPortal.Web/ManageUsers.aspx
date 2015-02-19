<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="QuestionPortal.Web.ManageUsers" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <asp:Label runat="server" Text="Manage Users" Font-Size="20" ForeColor="Red"></asp:Label>
        <asp:Button runat="server" CssClass="addButton" Text="Add User" ID="btnAdduser" OnClick="btnAdduser_Click" />
        <hr />
        <asp:GridView ID="grvwUsersList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" AlternatingRowStyle-BackColor="DarkTurquoise" OnRowEditing="grvwUsersList_RowEditing" OnRowDeleting="grvwUsersList_RowDeleting" Width="100%" HeaderStyle-BackColor="DarkTurquoise">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbtnEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" />
            </Columns>
            
        </asp:GridView>
    </div>
    </center>
</asp:Content>