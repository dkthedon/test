<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="Nagarro.EmployeePortal.Web.Employee.SearchEmployee "
    MasterPageFile="~/PortalTemplate.Master" Title="Search Employee"
     %>
<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <h2 style="height: 22px">
        Employee Search
    </h2>
    <div class="themecolor">
    <asp:Table runat="server" Width="100%" HorizontalAlign="Right">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table runat="server" >
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:label ID="lblEmployeeCode" runat="server" Text="Employee Code"></asp:label>
                        </asp:TableCell>
                        <asp:TableCell> 
                            <asp:textbox ID="txtEmployeeCode" runat="server" Text=""></asp:textbox>
                        </asp:TableCell> 
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblFirstName" runat="server" Text="FIrst Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:textbox ID="txtFIrstName" runat="server" Text=""></asp:textbox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlDepartmentList" runat="server" Width="126px">
                            </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
               </asp:Table>
        </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                           <asp:Label ID="lblDateOfJoining" runat="server" Text="Date of Joining"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtDateOfJoining" runat="server" Text=""></asp:TextBox>
                         </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtLastName" runat="server" Text=""></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
                               <asp:Button ID="btnSearchButton" CssClass="button" runat="server" Text="Search" OnClick="Search_Click" />
                          </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
              </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
    <asp:GridView ID="grvwEmployeeList" runat="server" EmptyDataText="No Result Found" EnableModelValidation="True" AutoGenerateColumns="false" OnPageIndexChanged="GridviewPageChanged" OnPageIndexChanging="GridviewPageChanging">
        <Columns>
            <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="DateOfJoining" HeaderText="Date of Joining" DataFormatString="{0:dd-MMMM-yyyy}" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
            <asp:HyperLinkField DataNavigateUrlFormatString="~/Employee/EmployeeDetails.aspx?EmployeeId={0}" Text="View Details" DataNavigateUrlFields="EmployeeId" />
        </Columns>
    </asp:GridView>
    <asp:AnimationExtender ID="GridviewAnimation" runat="server" TargetControlID="grvwEmployeeList" >
        <Animations>
            <OnLoad>
                <FadeIn Duration="2" fps="20" />
            </OnLoad>
        </Animations>
    </asp:AnimationExtender>
</asp:Content> 