<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyQuestions.aspx.cs" Inherits="QuestionPortal.Web.MyQuestions" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <asp:Repeater runat="server" DataSourceID="obdsMyQuestions">
            <ItemTemplate>
                <div class="questionDiv">
                    <asp:Label runat="server" Text="Question  " Font-Size="14" ForeColor="Red"></asp:Label>
                    <asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QuestionString")  %>' NavigateUrl='<%# "Question.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID")  %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" CssClass="floatRight" runat="server" Font-Bold="true" NavigateUrl='<%# "Post.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>' Font-Underline="true" Text="Edit question"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource runat="server" ID="obdsMyQuestions" TypeName="QuestionPortal.BLL.QuestionList" SelectMethod="GetUserQuestions" >
            <SelectParameters>
                <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
        </center>
</asp:Content>
