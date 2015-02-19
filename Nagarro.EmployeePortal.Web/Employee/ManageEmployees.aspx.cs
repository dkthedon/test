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
    /// class for ManageEmployees page
    /// </summary>
    public partial class ManageEmployees : System.Web.UI.Page
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
        /// loads the list of employees in gridview when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindDataToGridview();
        }

        /// <summary>
        /// redirects the user to AddEmployee page on click of Add New Employee Button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/AddEmployee.aspx");
        }

        /// <summary>
        /// Deletes the selected employee from the database and reloads the page on click of delete command field
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridViewDeleteEventArgs parameter</param>
        protected void RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(this.grvwEmployeesList.DataKeys[e.RowIndex]["EmployeeId"].ToString());
            if (id == ((EPPrincipal)Session["CurrentPrincipal"]).EmployeeId)
            {
                ClientScriptManager cs = this.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "ErrorDelete", "<script type=\"Text/javascript\">alert('Can not delete.');</script>");
            }
            else
            {
                BLL.Employee.DeleteEmployee(id);
                Response.Redirect("~/Employee/ManageEmployees.aspx");
            }
        }

        /// <summary>
        /// method for page index changing event of gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridviewPageEventArgs parameter</param>
        protected void GridviewPageChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvwEmployeesList.PageIndex = e.NewPageIndex;
            this.BindDataToGridview();
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
        private void BindDataToGridview()
        {
            EmployeeList employeeList = EmployeeList.GetAllEmployees();
            this.grvwEmployeesList.DataSource = employeeList;
            this.grvwEmployeesList.DataBind();
        }
    }
}