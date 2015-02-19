<%@ Page Title="Edit Notice" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="EditNotice.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.NoticeBoard.EditNotice" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div>
        <h2>
            Edit Notice
        </h2>
       <asp:Panel id="pnlButtonDiv" HorizontalAlign="Right" runat="server">
            <asp:Button ID="btnBack" Text="Back" CssClass="button" OnClick="Back_Click" runat="server" SkinID="rightSideButton" />
        </asp:Panel>
        <asp:Panel ID="pnlDetailsPanel" HorizontalAlign="Center" runat="server" >
        <asp:Table ID="tblEditNoticeTable" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Notice ID" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblNoticeId" runat="server" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Title" runat="server" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtNoticeTitle" runat="server" MaxLength="32" placeholder="max.32 chars"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="valTitleRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtNoticeTitle" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Description" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox id="txtDescription" TextMode="MultiLine" runat="server" Rows="5" Columns="16"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="valDescriptionRequired" runat="server" ErrorMessage="Can't be left blank" ControlToValidate="txtDescription" ValidationGroup="FirstGroup"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Start Date" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtStartDate" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" runat="server"></asp:CalendarExtender>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RangeValidator ID="valStartDateRange" runat="server" Type="Date" ControlToValidate="txtStartDate" ErrorMessage="Invalid Date" ValidationGroup="FirstGroup"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Expiration Date" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEndDate" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                     <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" runat="server"></asp:CalendarExtender>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RangeValidator ID="valEndDateRange" runat="server" Type="Date" ControlToValidate="txtEndDate" ErrorMessage="Invalid Date" ValidationGroup="FirstGroup"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label Text="Posted By" runat="server"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPostedBy" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnUpdate" Text="Update" CssClass="button" OnClick="Update_Click" runat="server" ValidationGroup="FirstGroup" />
        <asp:Button ID="btnCancel" Text="Cancel" CssClass="button" OnClick="Cancel_Click" runat="server" />
        </asp:Panel>
    </div>
</asp:Content>
