using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.AdminPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            using (BsolutionDBDataContext DB = new BsolutionDBDataContext())
            {
                var button = DB.Users.Where(a => a.Username.Equals(Email.Text) && a.password.Equals(Password.Text));
                if (button.Count() > 0)
                {
                    var user = button.First();
                    //Labelusername.Text = user.Name;
                    ////Session["UserID"] = user.ID;
                    //Labeluserid.Text = Convert.ToString(user.ID);
                    Session["userid"] = ""+ user.ID;
                    Session["name"] = "" + user.Name;
                    Response.Redirect("~/Pages/AdminPages/Home.aspx");

                }
                else
                {
                    //Labeluserid.Text = "0";
                    //// Session["UserID"] = 0;
                    //Labelusername.Text = "None, Please Login";
                    Labelstatus.Text = "LoginFailed,Please Enter Password and UserName Correctly";
                }
            }
        }
    }
}