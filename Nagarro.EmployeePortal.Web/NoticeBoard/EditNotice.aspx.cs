using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.NoticeBoard
{
    /// <summary>
    /// class for EditNotice page
    /// </summary>
    public partial class EditNotice : System.Web.UI.Page
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
        /// loads the content into controls when page load event occurs
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BLL.Notice notice = BLL.Notice.GetNotice(int.Parse(Request.QueryString["NoticeId"]));
                this.lblNoticeId.Text = notice.NoticeId.ToString();
                this.txtNoticeTitle.Text = notice.Title;
                this.txtDescription.Text = notice.Description;
                this.txtStartDate.Text = notice.StartDate.ToString("d");
                this.txtEndDate.Text = notice.ExpirationDate.ToString("d");
                this.lblPostedBy.Text = notice.PostedByName;
                this.valStartDateRange.MaximumValue = DateTime.MaxValue.ToString("d");
                this.valEndDateRange.MaximumValue = DateTime.MaxValue.ToString("d");
                this.valStartDateRange.MinimumValue = DateTime.Now.ToString("d");
                this.valEndDateRange.MinimumValue = DateTime.Now.ToString("d");
            }
        }

        /// <summary>
        /// Updates the details of Notice in the database and redirects the user to ManageNotices page on click of update button
        /// </summary>
        /// <param name="sender">object which raised the evnet</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            DateTime date;
            Notice notice = new Notice();
            notice.Title = this.txtNoticeTitle.Text;
            notice.Description = this.txtDescription.Text;
            notice.StartDate = DateTime.TryParse(this.txtStartDate.Text, out date) ? date : DateTime.Now;
            notice.ExpirationDate = DateTime.TryParse(this.txtEndDate.Text, out date) ? date : DateTime.Now;
            notice.NoticeId = int.Parse(this.lblNoticeId.Text);
            if (notice.Save())
            {
                Response.Redirect("~/NoticeBoard/ManageNotices.aspx");
            }
            else
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
            }
        }

        /// <summary>
        /// Redirects the user to ManageNotices page on click of cancel button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NoticeBoard/ManageNotices.aspx");
        }

        /// <summary>
        /// Redirects the user to ManageNotices page on click of back button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NoticeBoard/ManageNotices.aspx");
        }
    }
}