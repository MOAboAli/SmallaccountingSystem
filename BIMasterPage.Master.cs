using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp
{
    public partial class BIMasterPage : System.Web.UI.MasterPage
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               

                if (Convert.ToString( Session["userid"]) =="" || Convert.ToString(Session["userid"]) == "0")
                {
                    Session["userid"] = "0";
                    Labelusername.Text = "None, Please Login";
                    if(checkuser() !="Home")
                    Response.Redirect("~/Pages/AdminPages/Home.aspx");
                    
                }
                else
                {
                    Labelusername.Text =Convert.ToString( Session["name"]);
                    checkpage();
                }
            }
        }

        protected void user_Load(object sender, EventArgs e)
        {
            using (BsolutionDBDataContext DB = new BsolutionDBDataContext())
            {
                var button = DB.Users.Where(a => a.Username.Equals(txtUsername.Text) && a.password.Equals(txtPassword.Text));
                if (button.Count() > 0)
                {
                    var user = button.First();
                    Labelusername.Text = user.Name;
                    //Session["UserID"] = user.ID;
                    Labeluserid.Text = Convert.ToString(user.ID);
                    Session["userid"] = "" + user.ID;
                    Session["name"] = "" + user.Name;

                }
                else
                {
                    Labeluserid.Text = "0";
                    // Session["UserID"] = 0;
                    Labelusername.Text = "None, LoginFailed";
                    Labelstatuslogin.Text = "LoginFailed";
                    Session["userid"] = "0" ;
                }
            }
        }

      

        public string checkuser()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string url2 = HttpContext.Current.Request.Url.AbsolutePath;
            string url3 = HttpContext.Current.Request.Url.Host;
            string page = Path.GetFileName(url);

            return page;
        }


        public void checkpage()
        {
            int userid = Convert.ToInt32(Session["userid"]);

            var page = DB.Page2s.Where(a => a.PageName.Equals(checkuser())).SingleOrDefault();

            if (page.ISAll == true)
            {
                return;
            }
            else
            {
                var button = DB.Users.Where(a =>a.ID.Equals(userid));
                if (button.Count() > 0)
                {
                    var user = button.First();
                    
                    if(user.IsAdmin == true )
                    {
                        return;
                    }
                    else
                    {
                        var pagesuser = DB.PagewUsers.Where(a => a.userid.Equals(userid) && a.pageID.Equals(page.ID));
                        if(pagesuser.Count() > 0)
                        {
                            return;
                        }
                        else
                        {
                            Response.Redirect("~/Pages/AdminPages/AccessDenied.aspx?Page="+page.ID);
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/AdminPages/Home.aspx");
                }
            }




        }
    }
}