using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.Employee
{
    /// <summary>
    /// class for AddEmployee page
    /// </summary>
    public partial class AddEmployee : System.Web.UI.Page
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
        /// loads the department list in dropdown list when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                List<BLL.Department> list = BLL.DepartmentList.GetAllDepartment();
                this.ddlDepartment.DataSource = list;
                this.ddlDepartment.DataTextField = "DepartmentName";
                this.ddlDepartment.DataValueField = "DepartmentId";
                this.ddlDepartment.DataBind();
                this.RegisterScript();
                this.DateOfJoiningRangeValidator.MaximumValue = DateTime.Now.ToString("d");
                this.DateOfJoiningRangeValidator.MinimumValue = DateTime.MinValue.ToString("d");
                this.valDateOfBirthRange.MaximumValue = DateTime.Now.ToString("d");
                this.valDateOfBirthRange.MinimumValue = DateTime.MinValue.ToString("d");
            }
        }

        /// <summary>
        /// adds the employee in the database and redirects the user to ManageEmployees page on click of update button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                BLL.Employee employee = new BLL.Employee();
                employee.EmployeeCode = this.txtEmployeeCode.Text;
                DateTime date;
                employee.DateOfJoining = DateTime.TryParse(this.txtDateOfJoining.Text, out date) ? (DateTime?)date : (DateTime?)null; 
                employee.FirstName = this.txtFirstName.Text;
                employee.LastName = this.txtLastName.Text;
                employee.DateOfBirth = DateTime.TryParse(this.txtDateOfBirth.Text, out date) ? (DateTime)date : DateTime.Now;
                employee.Email = this.txtEmailId.Text;
                employee.Password = this.txtPassword.Value;
                if (this.rdoUser.Checked == true)
                {
                    employee.Role = 'U';
                }
                else if (this.rdoAdmin.Checked == true)
                {
                    employee.Role = 'A';
                }

                employee.Department.DepartmentId = int.Parse(this.ddlDepartment.SelectedValue);
                if (this.txtConfirmPassword.Value == this.txtPassword.Value && employee.Save())
                {
                    Response.Redirect("~/Employee/ManageEmployees.aspx");
                }
                else
                {
                    ClientScriptManager cs = this.ClientScript;
                    cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
                }
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

        /// <summary>
        /// Registers the cilent side function to check whether password and confirm password fields are equal
        /// </summary>
        protected void RegisterScript()
        {
            string key = "PasswordMatchFunction";
            ClientScriptManager cs = this.ClientScript;
            Type type = this.GetType();
            string script = "<script type=\"text/javascript\"> function Validate(osrc, args){ args.IsValid = (args.Value == document.getElementById('ctl00_mainContentPlaceHolder_txtPassword').value);} </script>";
            cs.RegisterClientScriptBlock(type, key, script);
        }
    }
}