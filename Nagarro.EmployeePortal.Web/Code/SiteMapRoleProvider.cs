using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Nagarro.EmployeePortal.BLL
{
    /// <summary>
    /// Class for providing role based access
    /// </summary>
    public class SiteMapRoleProvider : XmlSiteMapProvider
    {
        /// <summary>
        /// checks whether sitemap node is accessible to user or not
        /// </summary>
        /// <param name="context">current HttpContext</param>
        /// <param name="node">SiteMapNode to which access is being checked</param>
        /// <returns>true if node is accessible to the user</returns>
        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            if (node.Roles == null || node.Roles.Count == 0 || node.Roles.Contains("*"))
            {
                return true;
            }
            
            if (HttpContext.Current.Session["CurrentPrincipal"] is EPPrincipal)
            {
                EPPrincipal principal = HttpContext.Current.Session["CurrentPrincipal"] as EPPrincipal;
                foreach (string role in node.Roles)
                {
                    if (principal.IsInRole(role))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}