<%@ Control AutoEventWireup="true" Codebehind="MenuControl.ascx.cs" Inherits="Nagarro.EmployeePortal.Web.Controls.MenuControl"
    Language="C#" %>
<div align="left">
    <asp:Menu ID="mainMenu" runat="server" DataSourceID="siteMapSource" BackColor="#f5f5f5"
        StaticDisplayLevels="10" Width="100%">
        <StaticSelectedStyle CssClass="menuNodeSelected,themecolor" />
        <LevelMenuItemStyles>
            <asp:MenuItemStyle Font-Bold="True" Font-Underline="False" CssClass="Level1Node" />
        </LevelMenuItemStyles>
        <LevelSelectedStyles>
            <asp:MenuItemStyle Font-Bold="True" Font-Underline="False" BackColor="Blue" />
            <asp:MenuItemStyle Font-Bold="True" Font-Underline="False" CssClass="selectedcolor" />
        </LevelSelectedStyles>
        <StaticMenuItemStyle CssClass="menuNode" />
    </asp:Menu>
    <asp:SiteMapDataSource ID="siteMapSource" runat="server" ShowStartingNode="False" />
</div>
