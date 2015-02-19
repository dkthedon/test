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
    /// class for ManageNotices page
    /// </summary>
    public partial class ManageNotices : System.Web.UI.Page
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
        /// loads the notices into the gridview when page loads
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindDataToGridview();
        }

        /// <summary>
        /// redirects the user to add notice page on click of Add Notice button
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">EventArgs parameter</param>
        protected void AddNoticeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NoticeBoard/AddNotice.aspx");
        }

        /// <summary>
        /// deletes the selected notice from the database and reloads the ManageNotice page on click of Delete Command field
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridViewDeleteEventArgs parameter</param>
        protected void RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            Notice.DeleteNotice(int.Parse(this.grvwNoticeList.Rows[e.RowIndex].Cells[0].Text));
            Response.Redirect("~/NoticeBoard/ManageNotices.aspx");
        }

        /// <summary>
        /// method for the page index changing event of the gridview
        /// </summary>
        /// <param name="sender">object which raised the event</param>
        /// <param name="e">GridviewPageEventArgs parameter</param>
        protected void GridviewPageChanging(object sender, GridViewPageEventArgs e)
        {
            this.grvwNoticeList.PageIndex = e.NewPageIndex;
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
            BLL.NoticeList noticeList = BLL.NoticeList.GetAllNotices();
            this.grvwNoticeList.DataSource = noticeList;
            this.grvwNoticeList.DataBind();
        }
    }
}