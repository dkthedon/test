<%@ Page Title="Manage Notices" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="ManageNotices.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.NoticeBoard.ManageNotices" %>
<script runat="server">
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2>
        Manage Notices
    </h2>
    <div>
        <asp:Panel ID="pnlAddButtonPanel" HorizontalAlign="Right" runat="server" >
            <asp:Button ID="btnAddNoticeButton" Text="Add New Notice" CssClass="button" runat="server" OnClick="AddNoticeButton_Click" />
        </asp:Panel>
        <asp:GridView ID="grvwNoticeList" runat="server" EmptyDataText="No Notices" AutoGenerateColumns="false" OnRowDeleting="RowDelete" OnPageIndexChanged="GridviewPageChanged" OnPageIndexChanging="GridviewPageChanging" >
            <Columns>
                <asp:BoundField DataField="NoticeId" HeaderText="Notice Id" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:BoundField DataField="PostedByName" HeaderText="Posted By" />
                <asp:HyperLinkField DataNavigateUrlFormatString="~/NoticeBoard/EditNotice.aspx?NoticeId={0}" Text="Edit" DataNavigateUrlFields="NoticeId" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbtnDeleteButton" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure want to delete?');" CommandName="Delete"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
