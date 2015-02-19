using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0 && !IsPostBack)
            {
                BLL.Question question = BLL.Question.GetQuestion(int.Parse(Request.QueryString["ID"]));
                this.txtQuestion.Text = question.QuestionString;
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            BLL.Question question = new BLL.Question();
            question.QuestionString = this.txtQuestion.Text;
            if (Request.QueryString.Count != 0)
            {
                question.ID = int.Parse(Request.QueryString["ID"]);
            }
            else
            {
                question.PostedBy = int.Parse(Session["ID"].ToString());
            }
            if (question.Save())
            {
                Response.Redirect("MyQuestions.aspx");
            }
        }
    }
}