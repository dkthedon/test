<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Employee.ManageEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2>
        Manage Employees
    </h2>
    <div>
        <asp:Panel ID="pnlAddButtonPanel" HorizontalAlign="Right" runat="server" >
            <asp:Button ID="btnAddEmployee" Text="Add New Employee" CssClass="button" runat="server" OnClick="AddEmployee_Click" />
        </asp:Panel>
        <asp:GridView ID="grvwEmployeesList" runat="server" EmptyDataText="No Data" DataKeyNames="EmployeeId" EnableModelValidation="True" AutoGenerateColumns="False" OnRowDeleting="RowDelete" OnPageIndexChanged="GridviewPageChanged" OnPageIndexChanging="GridviewPageChanging" >
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="Employee ID" Visible="false" />
                <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate><%#Eval("FirstName")%>&nbsp;<%#Eval("LastName")%></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DateOfJoining" HeaderText="Date of Joining" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                <asp:HyperLinkField  DataNavigateUrlFormatString="~/Employee/EditEmployee.aspx?EmployeeId={0}" Text="Edit" DataNavigateUrlFields="EmployeeId" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbtnDeleteButton" Text="Delete"  runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure want to delete?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
