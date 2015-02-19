using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nagarro.EmployeePortal.BLL;

namespace Nagarro.EmployeePortal.Web.Employee
{
    /// <summary>
    /// class for SearchEmployee page
    /// </summary>
    public partial class SearchEmployee : System.Web.UI.Page
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
        /// loads all departments in dropdown list when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BLL.DepartmentList departmentList = BLL.DepartmentList.GetAllDepartment();
                BLL.Department nullDepartment = new Department();
                nullDepartment.DepartmentName = "None";
                departmentList.Insert(0, nullDepartment);
                this.ddlDepartmentList.DataSource = departmentList;
                this.ddlDepartmentList.DataTextField = "DepartmentName";
                this.ddlDepartmentList.DataValueField = "DepartmentId";
                this.ddlDepartmentList.DataBind();
            }
        }

        /// <summary>
        /// loads the search result from the database on click of search button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Search_Click(object sender, EventArgs e)
        {
            this.grvwEmployeeList.PageIndex = 0;
            BLL.Employee employee = new BLL.Employee();
            employee.EmployeeCode = string.IsNullOrEmpty(this.txtEmployeeCode.Text) ? null : this.txtEmployeeCode.Text;
            employee.FirstName = string.IsNullOrEmpty(this.txtFIrstName.Text) ? null : this.txtFIrstName.Text;
            employee.LastName = string.IsNullOrEmpty(this.txtLastName.Text) ? null : this.txtLastName.Text;
            employee.DateOfJoining = string.IsNullOrEmpty(this.txtDateOfJoining.Text) ? (DateTime?)null : DateTime.Parse(this.txtDateOfJoining.Text);
            employee.Department.DepartmentId = int.Parse(this.ddlDepartmentList.SelectedValue);
            EmployeeList employeeList = BLL.EmployeeList.SearchEmployees(employee);
            this.ViewState["EmployeeList"] = employeeList;
            this.GridviewDataBind();
        }

        /// <summary>
        /// method for the page index changing event of gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridviewPageEventArgs parameter</param>
        protected void GridviewPageChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvwEmployeeList.PageIndex = e.NewPageIndex;
            this.GridviewDataBind();
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
        /// binds the data to gridview
        /// </summary>
        private void GridviewDataBind()
        {
            this.grvwEmployeeList.DataSource = (EmployeeList)this.ViewState["EmployeeList"];
            this.grvwEmployeeList.DataBind();
        }
     }
    }