using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web
{
    /// <summary>
    /// class for EditEmployee page
    /// </summary>
    public partial class EditEmployee : System.Web.UI.Page
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
        /// loads the details of the employee by employee id from either session or query string
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BLL.Employee employee = new BLL.Employee();
                try
                {
                    this.ViewState["EmployeeId"] = int.Parse(Request.QueryString["EmployeeId"]);
                    if (!((EPPrincipal)Session["CurrentPrincipal"]).IsInRole("Admin"))
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    employee = BLL.Employee.GetEmployee((int)this.ViewState["EmployeeId"]);
                    this.ViewState["address"] = "~/Employee/ManageEmployees.aspx";
                }
                catch(ArgumentException)
                {
                    this.ViewState["EmployeeId"] = ((EPPrincipal)Session["CurrentPrincipal"]).EmployeeId;
                    employee = BLL.Employee.GetEmployee((int)this.ViewState["EmployeeId"]);
                    this.rdoUser.Visible = false;
                    this.rdoAdmin.Visible = false;
                    this.lblRole.Visible = false;
                    this.ViewState["address"] = "~/Default.aspx";
                }

                this.LoadControlsData(employee);
                this.RegisterClientScript();
            }
        }

        /// <summary>
        /// updates the details of employee in the database and redirects the user to DetailsUpdated page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Update_Click(object sender, EventArgs e)
        {
            DateTime date;
            BLL.Employee employee = new BLL.Employee();
            employee.EmployeeId = (int)this.ViewState["EmployeeId"];
            employee.EmployeeCode = this.lblEmployeeCode.Text;
            employee.FirstName = this.txtFirstName.Text;
            employee.LastName = this.txtLastName.Text;
            employee.Email = this.txtEmailId.Text;
            employee.Password = this.txtPassword.Text;
            employee.Department.DepartmentId = int.Parse(this.ddlDropDownList1.SelectedValue);
            employee.DateOfBirth = DateTime.TryParse(this.txtDateOfBirth.Text, out date) ? date : DateTime.Now;
            employee.DateOfJoining = DateTime.TryParse(this.lblDateOfJoining.Text, out date) ? (DateTime?)date : (DateTime?)null;
            if (this.rdoUser.Checked == true)
            {
                employee.Role = 'U';
            }
            else if (this.rdoAdmin.Checked == true)
            {
                employee.Role = 'A';
            }

            if (this.txtConfirmPassword.Text == this.txtPassword.Text && employee.Save())
            {
                Response.Redirect("DetailsUpdated.aspx");
            }
            else
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "UpdatedFunction", "<script type=\"Text/javascript\"> alert('Invalid Details'); </script>");
            }
        }

        /// <summary>
        /// redirects the user to previous page on click of cancel page
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)this.ViewState["address"]);
        }

        /// <summary>
        /// registers the client side function to match the password and confirm password fields
        /// </summary>
        private void RegisterClientScript()
        {
            string key = "PasswordMatchFunction";
            ClientScriptManager cs = this.ClientScript;
            Type type = this.GetType();
            string script = "<script type=\"text/javascript\"> function Validate(osrc, args){ args.IsValid = (args.Value == document.getElementById('ctl00_mainContentPlaceHolder_txtPassword').value);} </script>";
            cs.RegisterClientScriptBlock(type, key, script);
        }

        /// <summary>
        /// loads the details into controls
        /// </summary>
        /// <param name="employee">Employee having details</param>
        private void LoadControlsData(BLL.Employee employee)
        {
            this.lblEmployeeCode.Text = employee.EmployeeCode;
            this.lblDateOfJoining.Text = ((DateTime)(employee.DateOfJoining)).ToString("dd/MMM/yyyy");
            this.txtFirstName.Text = employee.FirstName;
            this.txtLastName.Text = employee.LastName;
            if (employee.Role == 'U')
            {
                this.rdoUser.Checked = true;
            }
            else if (employee.Role == 'A')
            {
                this.rdoAdmin.Checked = true;
            }

            this.valDateOfBirthRange.MaximumValue = ((DateTime)employee.DateOfJoining).ToString("d");
            this.valDateOfBirthRange.MinimumValue = DateTime.MinValue.ToString("d");
            this.txtDateOfBirth.Text = employee.DateOfBirth.ToString("MM/dd/yyyy");
            this.txtEmailId.Text = employee.Email;
            this.txtPassword.Attributes.Add("value", employee.Password);
            this.txtConfirmPassword.Attributes.Add("value", employee.Password);
            List<Department> list = BLL.DepartmentList.GetAllDepartment();
            this.ddlDropDownList1.DataSource = list;
            this.ddlDropDownList1.DataTextField = "DepartmentName";
            this.ddlDropDownList1.DataValueField = "DepartmentId";
            this.ddlDropDownList1.SelectedIndex = employee.Department.DepartmentId - 1;
            this.ddlDropDownList1.DataBind();
        }
    }
}