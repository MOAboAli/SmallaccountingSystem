using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.AdminPages
{
    public partial class PageAccess : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.DataSource = DB.Users.Select(a => new { a.ID, Name = a.Username });
                DropDownList1.DataBind();
                DropDownList2.DataSource = DB.Page2s.Select(a => new { a.ID, Name = a.PageName });
                DropDownList2.DataBind();

                gridbind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            PagewUser p = new PagewUser();
            p.pageID =Convert.ToInt32( DropDownList2.SelectedValue);
            p.userid = Convert.ToInt32(DropDownList1.SelectedValue);

            DB.PagewUsers.InsertOnSubmit(p);
            DB.SubmitChanges();

            gridbind();
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            var user1 = DB.PagewUsers.Where(a => a.ID.Equals(ID)).SingleOrDefault();

         

            DB.PagewUsers.DeleteOnSubmit(user1);
            DB.SubmitChanges();

            gridbind();


        }

        protected void gridbind()
        {
            GridView1.DataSource =  from u in  DB.Users.Where(a=>a.ID.Equals(DropDownList1.SelectedValue))
                                        join pu in DB.PagewUsers on u.ID equals pu.userid
                                        join p in DB.Page2s on pu.pageID equals p.ID
                                      select (new { ID = u.ID,p.PageName,u.Username}); ;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridbind();
        }
    }
}