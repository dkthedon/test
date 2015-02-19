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
    /// class for AddNotice page
    /// </summary>
    public partial class AddNotice : System.Web.UI.Page
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
            this.valStartDateRange.MinimumValue = DateTime.Now.ToString("d");
            this.valStartDateRange.MaximumValue = DateTime.MaxValue.ToString("d");
            this.valEndDateRange.MinimumValue = DateTime.Now.ToString("d");
            this.valEndDateRange.MaximumValue = DateTime.MaxValue.ToString("d");
        }

        /// <summary>
        /// redirects the user to ManageNotices page on click of back button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// adds the notice into the database and redirects to home page on click of update button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            DateTime date;
            BLL.Notice notice = new BLL.Notice();
            notice.Title = this.txtNoticeTitle.Text;
            notice.Description = this.txtDescription.Text;
            notice.StartDate = DateTime.TryParse(this.txtStartDate.Text, out date) ? date : DateTime.Now;
            notice.ExpirationDate = DateTime.TryParse(this.txtEndDate.Text, out date) ? date : DateTime.Now;
            notice.PostedById = ((EPPrincipal)Session["CurrentPrincipal"]).EmployeeId;
            if (notice.Save())
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
            }
        }

        /// <summary>
        /// redirects the user to home page on click of cancel button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}