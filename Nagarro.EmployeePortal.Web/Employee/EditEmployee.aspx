<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.EditEmployee"
    MasterPageFile="~/PortalTemplate.Master" Title="Edit Employee"
     %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <h2> 
        Edit Employee </h2>
            <br />
 <center>
     <asp:Table runat="server" ID="myTable">
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Employee Code"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:Label ID="lblEmployeeCode" runat="server" Text="Label"></asp:Label>
             </asp:TableCell>
          </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Date Of joining"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:Label ID="lblDateOfJoining" runat="server" Text="Label"></asp:Label>
              </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow> 
             <asp:TableCell>
                <asp:Label runat="server" Text="First Name"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="32" placeholder="max.32 chars"></asp:TextBox>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:RequiredFieldValidator ID="valFirstNameRequired" runat="server" ErrorMessage="Can't be left Blank" ControlToValidate="txtFirstName" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
             </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Last Name"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="32" placeholder="max.32 chars"></asp:TextBox>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:RequiredFieldValidator ID="valLastNameRequired" runat="server" ErrorMessage="Can't be left Blank" ControlToValidate="txtLastName" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
             </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Date Of Birth"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox ID="txtDateOfBirth" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                  <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDateOfBirth" runat="server"></asp:CalendarExtender>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:RangeValidator ID="valDateOfBirthRange" runat="server" Type="Date" ControlToValidate="txtDateOfBirth" ErrorMessage="Invalid Date" ValidationGroup="FirstGroup"></asp:RangeValidator>
             </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Email ID"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:RequiredFieldValidator ID="valEmailIdRequired" runat="server" ErrorMessage="Can't be left Blank" ControlToValidate="TxtEmailId" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
             </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Department"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:DropDownList ID="ddlDropDownList1" runat="server">      
                </asp:DropDownList>
             </asp:TableCell>
          </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                 <asp:Label  ID="lblRole" Text="Role" runat="server" ></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:RadioButton ID="rdoUser" Text="User" runat="server" GroupName="Role" />
                 <asp:RadioButton ID="rdoAdmin" Text="Admin" runat="server" GroupName="Role" />
             </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label runat="server" Text="Password"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" Style="border-radius: 15px;" />
             </asp:TableCell><asp:TableCell>
                 <asp:RequiredFieldValidator ID="valPasswordRequired" runat="server" ErrorMessage="Can't be left Blank." ControlToValidate="txtPassword" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
             </asp:TableCell></asp:TableRow><asp:TableRow>
             <asp:TableCell>
                 <asp:Label Text="Confirm Passowrd" runat="server" ></asp:Label>
             </asp:TableCell><asp:TableCell>
                 <asp:TextBox TextMode="Password" runat="server" id="txtConfirmPassword" Style="border-radius: 15px;" />
             </asp:TableCell><asp:TableCell>
                     <asp:CustomValidator ID="valPasswordMatchValidator" runat="server" ErrorMessage="Passwords don't match" ControlToValidate="txtConfirmPassword" ClientValidationFunction="Validate" EnableClientScript="true" ValidationGroup="FirstGroup"></asp:CustomValidator> 
                 </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="btnUpdateButton" CssClass="button" runat="server" OnClick="Update_Click" Text="Update" ValidationGroup="FirstGroup" />
            &nbsp;&nbsp; <asp:Button ID="btnCancelButton" CssClass="button" runat="server" Text="Cancel" Onclick="Cancel_Click"/>
     </center>
    </asp:Content>
