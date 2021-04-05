using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.AdminPages
{
    public partial class AccessDenied : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdminPages/Home.aspx");
        }
    }
}