using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.User user = BLL.User.GetUser(int.Parse(Request.QueryString["ID"]));
                this.lblID.Text = user.ID.ToString();
                this.txtName.Text = user.Name;
                this.txtEmail.Text = user.Email;
                this.txtPassword.Value = user.Password;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BLL.User user = BLL.User.GetUser(int.Parse(Request.QueryString["ID"]));
            user.Name = this.txtName.Text;
            user.Email = this.txtEmail.Text;
            user.Password = this.txtPassword.Value;
            if (user.Save())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
            }
        }
    }
}