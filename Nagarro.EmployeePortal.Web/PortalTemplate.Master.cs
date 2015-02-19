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
    /// class for the master page of the portal
    /// </summary>
    public partial class PortalTemplate : System.Web.UI.MasterPage
    {
        /// <summary>
        /// method for page load event
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
