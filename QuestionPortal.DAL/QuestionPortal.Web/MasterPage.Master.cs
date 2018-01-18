﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionPortal.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddlMenuList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlMenuList.SelectedIndex == 2)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            if (this.ddlMenuList.SelectedIndex == 1)
            {
                Response.Redirect("EditProfile.aspx");
            }
        }
    }
}