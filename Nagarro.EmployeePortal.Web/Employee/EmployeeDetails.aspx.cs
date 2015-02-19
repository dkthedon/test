using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nagarro.EmployeePortal.Web.Employee
{
    /// <summary>
    /// class for EmployeeDetails page
    /// </summary>
    public partial class EmployeeDetails : System.Web.UI.Page
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
        /// loads the details of employee by employeeId from the query string
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BLL.Employee employee = BLL.Employee.GetEmployee(int.Parse(Request.QueryString["EmployeeId"]));
                this.lblEmployeeCode.Text = employee.EmployeeCode;
                this.lblDateOfJoining.Text = ((DateTime)employee.DateOfJoining).ToString("d");
                this.lblFirstName.Text = employee.FirstName;
                this.lblLastName.Text = employee.LastName;
                this.lblDateOfBirth.Text = employee.DateOfBirth.ToString("d");
                this.lblEmailId.Text = employee.Email;
                this.lblDepartment.Text = employee.Department.DepartmentName;
            }
        }

        /// <summary>
        /// redirects the user to SearchEmployee page on click of back button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/SearchEmployee.aspx");
        }
    }
}