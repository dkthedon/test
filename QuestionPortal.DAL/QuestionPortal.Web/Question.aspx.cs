using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionPortal.Web
{
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblQuestion.Text = BLL.Question.GetQuestion(int.Parse(Request.QueryString["ID"])).QuestionString;
            }
        }
    }
}