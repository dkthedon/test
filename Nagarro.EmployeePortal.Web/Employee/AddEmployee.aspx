<%@ Page Title="Add New Employee" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Employee.AddEmployee" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2>
        Add New Employee
    </h2>
    <center>
    <asp:Table runat="server" ID="AddEmployeeTable">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Employee Code" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmployeeCode" runat="server" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valEmployeeCodeRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtEmployeeCode" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Date Of Joining" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDateOfJoining" runat="server" placeholder="mm/dd/yyyy" ></asp:TextBox>
                 <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDateOfJoining" runat="server"></asp:CalendarExtender>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RangeValidator ID="DateOfJoiningRangeValidator" runat="server" Type="Date" ErrorMessage="Invalid Date" ControlToValidate="txtDateOfJoining" ValidationGroup="FirstGroup"></asp:RangeValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="First Name" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="32" placeholder="max. 32 char" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valFirstNameRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtFirstName" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Last Name" runat="server"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="32" placeholder="max.32 char" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtLastName" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Date Of Birth" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDateOfBirth" runat="server" placeholder="mm/dd/yyyy" ></asp:TextBox>
                 <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDateOfBirth" runat="server"></asp:CalendarExtender>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RangeValidator ID="valDateOfBirthRange" runat="server" Type="Date" ControlToValidate="txtDateOfBirth" ErrorMessage="Invalid Date" ValidationGroup="FirstGroup"></asp:RangeValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Email Id" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmailId" runat="server" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RegularExpressionValidator ID="valRegularExpressionValidator1" ControlToValidate="txtEmailId" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" runat="server" ErrorMessage="Invalid Email"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Department" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlDepartment" runat="server" ></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="txtRole" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton ID="rdoUser" Checked="true" runat="server" Text="User" GroupName="Role" />
                <asp:RadioButton ID="rdoAdmin" Checked="false" runat="server" Text="Admin" GroupName="Role" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="Pasword" runat="server" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <input type="password" id="txtPassword" runat="server" style="border-radius: 15px;" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="valPasswordRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtPassword" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Confirm Password" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <input type="password" runat="server" id="txtConfirmPassword" style="border-radius: 15px;" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:CustomValidator ID="PasswordMatchValidator" runat="server" ErrorMessage="Password doesn't match" ControlToValidate="txtConfirmPassword" EnableClientScript="true" ClientValidationFunction="Validate" ValidationGroup="FirstGroup" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnUpdate" CssClass="submitbutton" OnClick="Update_Click" runat="server" ValidationGroup="FirstGroup"/>
            </asp:TableCell><asp:TableCell>
                <asp:Button ID="btnCancel" CssClass="cancelbutton" OnClick="Cancel_Click" runat="server"/>
            </asp:TableCell></asp:TableRow></asp:Table></center></asp:Content>