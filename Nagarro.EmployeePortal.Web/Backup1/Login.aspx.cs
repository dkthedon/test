using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

		protected void mainLogin_Authenticate(object sender, AuthenticateEventArgs e)
		{
			EPPrincipal principal = new EPPrincipal();
			e.Authenticated = principal.Login(mainLogin.UserName, mainLogin.Password);
			Session["CurrentPrincipal"] = principal;
		}
    }
}