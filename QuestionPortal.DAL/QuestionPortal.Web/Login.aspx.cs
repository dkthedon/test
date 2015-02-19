using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.IsAuthenticated)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = BLL.Login.GetLogin(this.txtUserName.Text, this.txtPaswword.Value);
            if (user.ID != 0)
            {
                FormsAuthentication.SetAuthCookie(this.txtUserName.Text, false);
                Session["ID"] = user.ID;
                Response.Redirect("Home.aspx");
            }
            else
            {
                this.lblError.Text = "Wrong username or password";
                this.lblError.Visible = true;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}