<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuestionPortal.Web.Home" Theme="MainTheme" %>
<asp:Content ID="Content3" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <h2>
           <asp:label Text="Questions under Discussion" runat="server" ForeColor="Red"></asp:label>
        </h2>
        <hr />
        <br />
        <asp:Repeater runat="server" ID="repQuestions" DataSourceID="obdsQuestionList">
            <ItemTemplate>
                <div class="questionDiv">
                    <asp:Label runat="server" CssClass="floatLeft" Text="Question: " Font-Bold="true" ForeColor="Red"></asp:Label>
                <asp:HyperLink runat="server" CssClass="floatLeft" Font-Underline="true" NavigateUrl='<%# "Question.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>' Text='<%# DataBinder.Eval(Container.DataItem,"QuestionString") %>'></asp:HyperLink>
                <br />
                    <asp:Label runat="server" CssClass="floatLeft" Text="Posted By: " Font-Bold="true" ForeColor="Red"></asp:Label>
                <asp:Label runat="server" ID="lblPostedBy" CssClass="floatLeft" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>'></asp:Label>
                    <asp:HyperLink ID="HyperLink1" CssClass="floatRight" runat="server" Font-Bold="true" NavigateUrl='<%# "PostAnswer.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>' Font-Underline="true" Text="Answer the question"></asp:HyperLink>
                 </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource runat="server" ID="obdsQuestionList" TypeName="QuestionPortal.BLL.QuestionList" SelectMethod="GetAllQuestions">
        </asp:ObjectDataSource>
    </div>
        </center>
</asp:Content>
