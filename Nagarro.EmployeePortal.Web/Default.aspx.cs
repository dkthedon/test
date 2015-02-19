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
    /// class for the home page
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// sets the theme of the page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Random randomThemeNumber = new Random();
            if (randomThemeNumber.Next(1, 3) == 1)
            {
                this.Session["Theme"] = "MainTheme";
            }
            else
            {
                this.Session["Theme"] = "SecondTheme";
            }

            this.Theme = Session["Theme"].ToString();
        }

        /// <summary>
        /// loads the list of open issue of the logged in user in gridview when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindDataToGridview();
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        /// <summary>
        /// method for page index changing event of gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridviewpageEventArgs parameter</param>
        protected void GridviewPageChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvwOpenIssuesList.PageIndex = e.NewPageIndex;
            this.BindDataToGridview();
        }

        /// <summary>
        /// method for page index changed event of gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void GridviewPageChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// binds the data to gridview
        /// </summary>
        private void BindDataToGridview()
        {
            this.grvwOpenIssuesList.DataSource = IssueList.GetUserOpenIssues(((EPPrincipal)Session["CurrentPrincipal"]).EmployeeId);
            this.grvwOpenIssuesList.DataBind();
        }
    }
}
