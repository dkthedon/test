<%@ Page Title="Edit Issue" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="EditIssue.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.IssueTracker.EditIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div>
        <h2>
            Edit Issue
        </h2>
        <asp:Panel ID="pnlBackButtonPanel" HorizontalAlign="Right" runat="server">
            <asp:Button runat="server" CssClass="button" Text="Back" ID="btnBack" OnClick="Back_Click"/>
        </asp:Panel>
                <center>
        <asp:Table ID="tblPostIssuetable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Issue ID" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblIssueId" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Title"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtIssueTitle" MaxLength="32" placeholder="max.32 chars" ></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="valTitileRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtIssueTitle" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Description" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" id="txtDescription" TextMode="MultiLine" Rows="5" Columns="16"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="valDescriptionRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtDescription" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Comment" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="5" Columns="16" runat="server" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Priority" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlPriority" runat="server">
                        <asp:ListItem Text="Normal" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Immediate" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Urgent" Value="3" ></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Assigned To" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlAssignedToList" runat="server" ></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <asp:Button runat="server" ID="btnUpdate" CssClass="button" Text="Update" OnClick="Update_Click" ValidationGroup="FIrstGroup" />
            <asp:Button runat="server" ID="btnCancel" CssClass="button" Text="Cancel" OnClick="Cancel_Click" />
        </center>
    </div>
</asp:Content>
