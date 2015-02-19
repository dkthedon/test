<%@ Page Title="Issue Details" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="IssueDetails.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.IssueTracker.IssueDetails"
    
     %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div>
        <h2>
            Issue Detail
        </h2>
        <asp:Panel ID="pnlBackButtonPanel" HorizontalAlign="Right" runat="server" >
            <asp:Button ID="btnBackButton" CssClass="button" Text="Back" runat="server" OnClick="Back_Click" />
        </asp:Panel>
        <asp:Table ID="tblIssueDetaiTable" HorizontalAlign="Center" runat="server" Height="160px" Width="228px" >
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Title" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblIssueTitle" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Posted On" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPostedOn" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Posted By" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPostedBy" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Status" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblStatus" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Description" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDescription" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
