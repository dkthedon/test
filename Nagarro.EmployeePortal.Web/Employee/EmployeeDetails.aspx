<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Employee.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div>
        <h2>
            Employee Detail
        </h2>
        <asp:Panel ID="pnlBackButtonPanel" HorizontalAlign="Right" runat="server">
            <asp:Button runat="server" CssClass="button" ID="btnBack" Text="Back" OnClick="Back_Click" />
        </asp:Panel>
        <asp:Table Id="tblDetailsTable" runat="server" >
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Employee Code" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Date Of Joining"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblDateOfJoining" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="First Name" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblFirstName" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Last Name" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblLastName" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Date Of Birth"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblDateOfBirth" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Email Id" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblEmailId" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Department" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="lblDepartment" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:AnimationExtender ID="TableAnimation" runat="server" TargetControlID="tblDetailsTable">
            <Animations>
                <OnLoad>
                    <FadeIn Duration="1.0" fps="20" />
                </OnLoad>
            </Animations>
        </asp:AnimationExtender>
    </div>
</asp:Content>
