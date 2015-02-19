using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.IssueTracker
{
    /// <summary>
    /// class for IssueDetails page
    /// </summary>
    public partial class IssueDetails : System.Web.UI.Page
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
        /// loads the details of the issue by issue id from the query string
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgas parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Issue issue = Issue.GetIssue(int.Parse(Request.QueryString["IssueId"]));
                this.lblIssueTitle.Text = issue.Title;
                this.lblPostedOn.Text = issue.DatePosted.ToString("d");
                this.lblPostedBy.Text = issue.PostedByName;
                this.lblStatus.Text = issue.StatusText;
                this.lblDescription.Text = issue.Description;
            }
        }

        /// <summary>
        /// redirects the user to home page on click of back button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}