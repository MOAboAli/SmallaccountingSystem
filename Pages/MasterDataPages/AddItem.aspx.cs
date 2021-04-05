using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class AddItem : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            if (TextBoxContacttype.Text != "")
            {
                insertdata();
                databind();
                cleartools();
            }
            else
            {
                Response.Write("<script language=javascript>alert('NO DataSaved');</script>");
            }
        }

        protected void insertdata()
        {

            Item_Type newobject = new Item_Type();
            newobject.Item_Type_Name = TextBoxContacttype.Text;
            newobject.RecTime = DateTime.Now;
            newobject.Item_Type_Notes = "";
            newobject.UserId =Convert.ToInt32( Session["userid"]);
            newobject.IsDisable = false;

            DB.Item_Types.InsertOnSubmit(newobject);
            DB.SubmitChanges();




        }

        protected void databind()
        {
            GridView1.DataSource = DB.Item_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Item_Type1, Name = a.Item_Type_Name, DateOfRec = a.RecTime }); ;
            GridView1.DataBind();
        }

        protected void cleartools()
        {
            TextBoxContacttype.Text = "";
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Item_Types.Where(a => a.Item_Type1.Equals(ID)).SingleOrDefault();

            objecttable.Item_Type_Name = TextBoxContacttype.Text;
            DB.Item_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Item_Types.Where(a => a.Item_Type1.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Item_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }
    }
}