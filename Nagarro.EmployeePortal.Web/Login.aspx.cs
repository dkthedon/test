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

namespace Nagarro.EmployeePortal.Web
{
    /// <summary>
    /// class for login page
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Session["Theme"] = "MainTheme";
        }

        /// <summary>
        /// method for page load event
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {         
        }

        /// <summary>
        /// authenticate the userName and password entered on click of login button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">AutenticateEventArgs parameter</param>
        protected void MainLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            EPPrincipal principal = new EPPrincipal();
            e.Authenticated = principal.Login(this.mainLogin.UserName, this.mainLogin.Password);
            this.Session["CurrentPrincipal"] = principal;
        }
    }
}