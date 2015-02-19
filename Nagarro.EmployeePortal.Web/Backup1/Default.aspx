<%@ Page AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Default"
    Language="C#" MasterPageFile="~/PortalTemplate.Master" Theme="MainTheme" Title="Home" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <h2>
        Home</h2>
    <div align="left">
        <!-- Page Content Here-->
        <h3>Notice Board</h3>
        <div>
            <i>Current notices will be displayed here.</i>
        </div>
        <h3>
            My Open Issues</h3>
        <div>
            <i>Currently opened issues will be displayed here.</i>
        </div>
    </div>
</asp:Content>
