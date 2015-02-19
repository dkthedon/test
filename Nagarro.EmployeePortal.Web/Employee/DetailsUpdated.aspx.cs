using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nagarro.EmployeePortal.Web.Employee
{
    /// <summary>
    /// class for the DetailsUpdated page
    /// </summary>
    public partial class DetailsUpdated : System.Web.UI.Page
    {
        /// <summary>
        /// sets the theme of the page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Theme = this.Session["Theme"].ToString();
        }

        /// <summary>
        /// method for the page load event
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}