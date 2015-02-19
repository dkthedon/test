using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.IssueTracker
{
    /// <summary>
    /// class for PostIssue page
    /// </summary>
    public partial class PostIssue : System.Web.UI.Page
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
            if (!this.IsPostBack)
            {
                BLL.EmployeeList employeesList = EmployeeList.GetAllEmployees();
                var adminsList = from employee in employeesList
                                 where employee.Role == 'A'
                                 select employee;
                this.ddlAssignedToList.DataSource = adminsList;
                this.ddlAssignedToList.DataTextField = "EmployeeCode";
                this.ddlAssignedToList.DataValueField = "EmployeeId";
                this.ddlAssignedToList.DataBind();
            }
        }

        /// <summary>
        /// adds the issue in database and redirects the user to home page on click of update button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            BLL.Issue issue = new BLL.Issue();
            issue.Title = this.txtIssueTitle.Text;
            issue.Description = this.txtDescription.Text;
            issue.Priority = short.Parse(this.ddlPriority.SelectedValue);
            issue.Status = 1;
            issue.PostedBy = ((EPPrincipal)Session["CurrentPrincipal"]).EmployeeId;
            issue.AssignedTo = int.Parse(this.ddlAssignedToList.SelectedValue);
            if (issue.Save())
            {
                this.SendMail(issue);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
            }
        }

        /// <summary>
        /// Redirects the user to home page on click of cancel button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
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

        /// <summary>
        /// sends details of the issue to the employee who is posting the issue
        /// </summary>
        /// <param name="issue">Issue having details</param>
        /// <returns>true if sent successfully</returns>
        private bool SendMail(BLL.Issue issue)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                mail.From = new MailAddress("portalemployee08@gmail.com");
                BLL.Employee employee = BLL.Employee.GetEmployee(issue.PostedBy);
                mail.To.Add(employee.Email);
                mail.Subject = issue.Title;
                mail.Body = issue.Description + "\n" + "This is a system generated mail. Don't reply to this mail.";
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch(SmtpException)
            {
                return false;
            }
        }
    }
}