using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = this.txtName.Text;
            user.UserName = this.txtUsername.Text;
            user.Password = this.txtPassword.Text;
            user.Email = this.txtEmail.Text;
            if (user.Save())
            {
                Server.TransferRequest("ManageUsers.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script11", "alert('Invalid Details')", true);
            }
        }
    }
}