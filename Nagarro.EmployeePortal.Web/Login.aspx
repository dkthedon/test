<%@ Page Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Login" Title="Employee Portal - Login" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
<h2>Login</h2>
<div align="center" style="width:100%;">
    <asp:Login ID="mainLogin" runat="server" SkinID="loginSkin" TitleText="Employee Portal Login" InstructionText="Enter your User Name and Password to login &nbsp;"
        DisplayRememberMe="False" OnAuthenticate="MainLogin_Authenticate">
        
    </asp:Login>
    <asp:AnimationExtender ID="LoginAnimation" runat="server" TargetControlID="mainLogin">
        <Animations>
            <OnLoad>                    
                <fadeIn Duration="2" fps="20" />
            </OnLoad>
        </Animations>
    </asp:AnimationExtender>
</div>
</asp:Content>