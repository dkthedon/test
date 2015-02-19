using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.Controls
{
    /// <summary>
    /// class for HeaderControl
    /// </summary>
    public partial class HeaderControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// method for the page load event
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadData();
            }
        }

        /// <summary>
        /// logout the current user and loads the login page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">LoginCancelEventArgs parameter</param>
        protected void LoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            if (HttpContext.Current.Session["CurrentPrincipal"] is EPPrincipal)
            {
                EPPrincipal principal = HttpContext.Current.Session["CurrentPrincipal"] as EPPrincipal;
                principal.Logout();
                FormsAuthentication.SignOut();
                this.Session["CurrentPrincipal"] = principal;
            }
        }

        /// <summary>
        /// loads the welcome message
        /// </summary>
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                this.welcomeDiv.Visible = true;
                this.userInfoLabel.Text = HttpContext.Current.User.Identity.Name;
                this.userInfoLabel.ForeColor = System.Drawing.Color.DarkRed;
                this.userInfoLabel.Font.Bold = true;
                this.userInfoLabel.Font.Size = 15;
            }
            else
            {
                this.welcomeDiv.Visible = false;
            }
        }
    }
}