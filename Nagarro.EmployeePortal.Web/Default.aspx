<%@ Page AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Default"
    Language="C#" MasterPageFile="~/PortalTemplate.Master" Title="Home" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <h2>
        Home</h2>
    <div align="left">
        <!-- Page Content Here-->
        <h3>Notice Board</h3>
        <div id="NoticeDiv" runat="server">
           <asp:Repeater DataSourceID="obdsActiveNotices" runat="server">
               <ItemTemplate>
                   <asp:Label Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' runat="server"></asp:Label>
                   <br />
                   <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' ></asp:Label>
                   <hr style="border-top:dotted 1px" />
                   <asp:Label ID="Description" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' ></asp:Label>
                   <br /> <br />
               </ItemTemplate>
           </asp:Repeater>
           <asp:ObjectDataSource ID="obdsActiveNotices" runat="server" TypeName="Nagarro.EmployeePortal.BLL.NoticeList" SelectMethod="GetActiveNotices" >
           </asp:ObjectDataSource>
        </div>
        <h3>
            My Open Issues</h3>
        <div>
            <asp:GridView ID="grvwOpenIssuesList" runat="server" EmptyDataText="No Issues" AutoGenerateColumns="false" OnPageIndexChanged="GridviewPageChanged" OnPageIndexChanging="GridviewPageChanging" >
                <Columns>
                    <asp:BoundField DataField="IssueId" HeaderText="Issue Id" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="DatePosted" HeaderText="Posted On" DataFormatString="{0:dd-MMMM-yyyy}" />
                    <asp:BoundField DataField="PostedByName" HeaderText="Posted By" />
                    <asp:BoundField DataField="StatusText" HeaderText="Status" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="~/IssueTracker/IssueDetails.aspx?IssueId={0}" Text="View Details" DataNavigateUrlFields="IssueId" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
