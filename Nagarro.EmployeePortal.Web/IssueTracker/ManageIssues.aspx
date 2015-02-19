<%@ Page Title="Manage Issues" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="ManageIssues.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.IssueTracker.ManageIssues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2>
        Manage Issues
    </h2>
    <asp:Panel id="pnlButtonPanel" HorizontalAlign="Right" runat="server">
        <asp:Button ID="btnAddIssueButton" Text="Add New Issue" CssClass="button" runat="server" OnClick="AddIssueButton_Click" />
    </asp:Panel>
    <div>
        <asp:GridView ID="grvwIssueList" runat="server" EmptyDataText="No Issues" AutoGenerateColumns="False" EnableModelValidation="True" OnRowDeleting="RowDeleted" OnPageIndexChanged="GridviewPageChanged" OnPageIndexChanging="GridviewPageChanging" >
            <Columns>
                <asp:BoundField DataField="IssueId" HeaderText="Issue Id" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="DatePosted" HeaderText="Posted On" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:BoundField DataField="PostedByName" HeaderText="Posted By" />
                <asp:BoundField DataField="StatusText" HeaderText="Status" />
                <asp:HyperLinkField DataNavigateUrlFormatString="~/IssueTracker/EditIssue.aspx?IssueId={0}" Text="Edit" DataNavigateUrlFields="IssueId" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbtnDeleteButton" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure want to delete?');" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>          
        </asp:GridView>
    </div>
</asp:Content>