<%@ Page Title="Add New Notice" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="AddNotice.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.NoticeBoard.AddNotice" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2>
        Add New Notice
    </h2>
    <asp:Panel ID="pnlBackButtonPanel" HorizontalAlign="Right" runat="server" >
        <asp:Button ID="btnBackButton" Text="Back" CssClass="button" runat="server" OnClick="BackButton_Click" />
    </asp:Panel>
     <center>
    <asp:Panel ID="pnlTablePanel" runat="server" >
   <asp:Table ID="tblAddNoticeTable" runat="server">
       <asp:TableRow>
           <asp:TableCell>
               <asp:Label Text="Title" runat="server" ></asp:Label>
           </asp:TableCell>
           <asp:TableCell>
               <asp:TextBox ID="txtNoticeTitle" runat="server" MaxLength="32" placeholder="max.32 chars" ValidationGroup="FirstGroup" ></asp:TextBox>
           </asp:TableCell>
           <asp:TableCell>
               <asp:RequiredFieldValidator ID="valTitleRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtNoticeTitle" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell>
               <asp:Label Text="Description" runat="server" ></asp:Label>
           </asp:TableCell>
           <asp:TableCell>
               <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" Rows="5" Columns="16"></asp:TextBox>
           </asp:TableCell>
           <asp:TableCell>
               <asp:RequiredFieldValidator ID="valDescriptionRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtDescription" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell>
               <asp:Label Text="Start Date" runat="server" ></asp:Label>
           </asp:TableCell>
           <asp:TableCell>
               <asp:TextBox ID="txtStartDate" runat="server" placeholder="mm/dd/yyyy" ></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" runat="server"></asp:CalendarExtender>
           </asp:TableCell>
           <asp:TableCell>
               <asp:RangeValidator ID="valStartDateRange" runat="server" Type="Date" ErrorMessage="Invalid Date" ControlToValidate="txtStartDate" ValidationGroup="FirstGroup"></asp:RangeValidator>
           </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow>
           <asp:TableCell>
               <asp:Label Text="Expiration Date" runat="server" ></asp:Label>
           </asp:TableCell>
           <asp:TableCell>
               <asp:TextBox ID="txtEndDate" runat="server" placeholder="mm/dd/yyyy" ></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" runat="server"></asp:CalendarExtender>
           </asp:TableCell>
           <asp:TableCell>
               <asp:RangeValidator ID="valEndDateRange" runat="server" Type="Date" ControlToValidate="txtEndDate" ErrorMessage="Invalid Date" ValidationGroup="FirstGroup"></asp:RangeValidator>
           </asp:TableCell>
       </asp:TableRow>
   </asp:Table>
    </asp:Panel>
        <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="button" OnClick="Update_Click" ValidationGroup="FirstGroup" />
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="button" OnClick="Cancel_Click" />
        </center>
</asp:Content>
