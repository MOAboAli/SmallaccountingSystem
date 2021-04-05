using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.AdminPages
{
    public partial class AddUser : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridbind();
            }

        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            User user1 = new User();
            user1.Username = TextBoxusername.Text;
            user1.Name = TextBoxusername.Text;
            user1.password = TextBoxPaswword.Text;
            user1.IsAdmin = CheckBoxisadmin.Checked;
            user1.ISDisable = CheckBoxisdisable.Checked;

            DB.Users.InsertOnSubmit(user1);
            DB.SubmitChanges();

            gridbind();
        }

        protected void SelectGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var user1 = DB.Users.Where(a => a.ID.Equals(ID)).SingleOrDefault();



            TextBoxusername.Text = user1.Username;

            TextBoxPaswword.Text = user1.password;
            CheckBoxisadmin.Checked = Convert.ToBoolean(user1.IsAdmin);
            CheckBoxisdisable.Checked = Convert.ToBoolean(user1.ISDisable);



        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var user1 = DB.Users.Where(a => a.ID.Equals(ID)).SingleOrDefault();

            user1.Username = TextBoxusername.Text;
            user1.Name = TextBoxusername.Text;
            user1.password = TextBoxPaswword.Text;
            user1.IsAdmin = CheckBoxisadmin.Checked;
            user1.ISDisable = CheckBoxisdisable.Checked;

            DB.Users.DefaultIfEmpty(user1);
            DB.SubmitChanges();
            gridbind();


        }

        protected void gridbind()
        {
            GridView1.DataSource = DB.Users.Select(a => new { ID = a.ID, Name = a.Name, a.Username, Admin = a.IsAdmin,a.ISDisable }); ;
            GridView1.DataBind();
        }
    }
}