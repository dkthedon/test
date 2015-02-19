using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionPortal.BLL;

namespace QuestionPortal.Web
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.grvwUsersList.DataSource = UserList.GetAllUsers();
                this.grvwUsersList.DataBind();
            }
        }

        protected void grvwUsersList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(this.grvwUsersList.DataKeys[e.RowIndex]["ID"].ToString());
            BLL.User.DeleteUser(id);
        }

        protected void grvwUsersList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string url = "EditUser.aspx?ID=" + this.grvwUsersList.DataKeys[e.NewEditIndex]["ID"].ToString();
            string s = "window.open('" + url + "', 'popup_window', 'width=400,height=300,position=center,resizable=no');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void btnAdduser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

    }
}