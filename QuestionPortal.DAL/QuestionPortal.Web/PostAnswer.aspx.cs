using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class PostAnswer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblQuestion.Text = BLL.Question.GetQuestion(int.Parse(Request.QueryString["ID"])).QuestionString;
                this.ViewState["ID"] = this.Request.QueryString["ID"];
            }
        }

        protected void btnPostAnswer_Click(object sender, EventArgs e)
        {
            Answer answer = new Answer();
            answer.PostedBy = int.Parse(Session["ID"].ToString());
            answer.QuestionId = int.Parse(this.ViewState["ID"].ToString());
            answer.AnswerString = this.txtAnswer.Text;
            if(answer.Save())
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}