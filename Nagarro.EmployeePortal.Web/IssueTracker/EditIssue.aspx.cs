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
    /// class for EditIssue page
    /// </summary>
    public partial class EditIssue : System.Web.UI.Page
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
        /// loads the details of issue by issueId from the query string
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadControlsData();
            }
        }

        /// <summary>
        /// updates the details of the issue in the database and redirects to ManageIssues page on click of upadate button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            Issue issue = new Issue();
            issue.IssueId = int.Parse(this.lblIssueId.Text);
            issue = Issue.GetIssue(issue.IssueId);
            issue.Title = this.txtIssueTitle.Text;
            issue.Description = this.txtDescription.Text;
            issue.Comment = this.txtComment.Text;
            issue.Priority = short.Parse(this.ddlPriority.SelectedValue);
            issue.AssignedTo = int.Parse(this.ddlAssignedToList.SelectedValue);
            if (issue.Save())
            {
                this.SendMail(issue);
                Response.Redirect("~/IssueTracker/ManageIssues.aspx");
            }
            else
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
            }
        }

        /// <summary>
        /// redirects the user to ManageIssues page on click of cancel button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IssueTracker/ManageIssues.aspx");
        }

        /// <summary>
        /// redirects the user to ManageIssues page on click of back button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IssueTracker/ManageIssues.aspx");
        }

        /// <summary>
        /// loads the details into controls
        /// </summary>
        private void LoadControlsData()
        {
            BLL.Issue issue = BLL.Issue.GetIssue(int.Parse(Request.QueryString["IssueId"]));
            this.lblIssueId.Text = issue.IssueId.ToString();
            this.txtIssueTitle.Text = issue.Title;
            this.txtDescription.Text = issue.Description;
            this.ddlPriority.SelectedIndex = (short)issue.Priority;
            EmployeeList employeeList = EmployeeList.GetAllEmployees();
            var assignedToList = from employee in employeeList
                                 where employee.Role == 'A'
                                 select employee;
            this.ddlAssignedToList.DataSource = assignedToList;
            this.ddlAssignedToList.DataTextField = "EmployeeCode";
            this.ddlAssignedToList.DataValueField = "EmployeeId";
            this.ddlAssignedToList.DataBind();
            this.ddlAssignedToList.SelectedValue = issue.AssignedTo.ToString();
        }

        /// <summary>
        /// sends a mail with details to the employee who had posted the issue
        /// </summary>
        /// <param name="issue">Issue having details</param>
        /// <returns>true if mail is sent</returns>
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
                mail.Body = issue.Description + "\n" + issue.Comment + "\n" + "Status changed to" + issue.StatusText.ToString() + "\n" + "This is a system generated mail. Don't reply to this mail.";
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