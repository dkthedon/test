using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = BLL.User.GetUser(int.Parse(Session["ID"].ToString()));
                this.txtName.Text = user.Name;
                this.txtEmail.Text = user.Email;
                this.txtPassword.Value = user.Password;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = this.txtName.Text;
            user.Email = this.txtEmail.Text;
            user.Password = this.txtPassword.Value;
            user.ID = int.Parse(Session["ID"].ToString());
            if (user.Save())
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}