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
    /// class for ManageIssues page
    /// </summary>
    public partial class ManageIssues : System.Web.UI.Page
    {
        /// <summary>
        /// sets the theme of the page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Theme = this.Session["Theme"].ToString();
            if (!((EPPrincipal)Session["CurrentPrincipal"]).IsInRole("Admin"))
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// loads the list of all issues into gridview when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindDataToGridView();
        }

        /// <summary>
        /// redirects the user to Add issue page on click of Add New Issue button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void AddIssueButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IssueTracker/PostIssue.aspx");
        }

        /// <summary>
        /// deletes the selected issue from the database on click of delete command field
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridViewDeleteEventArgs parameter</param>
        protected void RowDeleted(object sender, GridViewDeleteEventArgs e)
        {
            Issue.DeleteIssue(int.Parse(this.grvwIssueList.Rows[e.RowIndex].Cells[0].Text));
            Response.Redirect("~/IssueTracker/ManageIssues.aspx");
        }

        /// <summary>
        /// method for the page index changing event of the gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridviewPageEventArgs parameter</param>
        protected void GridviewPageChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvwIssueList.PageIndex = e.NewPageIndex;
            this.BindDataToGridView();
        }

        /// <summary>
        /// method for the page index changed event of the gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void GridviewPageChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// binds data to gridview
        /// </summary>
        private void BindDataToGridView()
        {
            BLL.IssueList issueList = BLL.IssueList.GetAllIssues();
            this.grvwIssueList.DataSource = issueList;
            this.grvwIssueList.DataBind();
        }
    }
}