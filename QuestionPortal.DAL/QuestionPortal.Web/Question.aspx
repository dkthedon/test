<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="QuestionPortal.Web.Question" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageHolder" runat="server">
    <center>
    <div class="questionPageDiv">
        <asp:Label runat="server" ID="lblQuestion" Font-Underline="true"></asp:Label>
        <hr />
        <asp:Repeater runat="server" ID="repAnswers" DataSourceID="obdsAnswersList">
            <ItemTemplate>
                <div class="answerDiv">
                    <asp:Label runat="server" Text="Answer: " ForeColor="Red"></asp:Label>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AnswerString") %>'></asp:Label>
                <br />
                    <asp:Label runat="server" Text="Posted By " ForeColor="Red"></asp:Label> 
                <asp:Label runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "UserName")  %>' ></asp:Label>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource runat="server" ID="obdsAnswersList" TypeName="QuestionPortal.BLL.AnswerList" SelectMethod="GetAnswers">
            <SelectParameters>
                <asp:QueryStringParameter Name="questionId" QueryStringField="ID" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </center>
</asp:Content>
