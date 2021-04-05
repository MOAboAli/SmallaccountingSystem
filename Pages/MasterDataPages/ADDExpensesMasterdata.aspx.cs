using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class ADDExpensesMasterdata : System.Web.UI.Page
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

            Expenses_Type newobject = new Expenses_Type();
            newobject.Expenses_Type_Name = TextBoxContacttype.Text;
            newobject.Rectime = DateTime.Now;
            newobject.Expenses_Type_Rectime = DateTime.Now;
            newobject.UserId =Convert.ToInt32( Session["userid"]);
            newobject.IsDisable = false;

            DB.Expenses_Types.InsertOnSubmit(newobject);
            DB.SubmitChanges();




        }

        protected void databind()
        {
            GridView1.DataSource = DB.Expenses_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Expenses_Type_Id, Name = a.Expenses_Type_Name, DateOfRec = a.Expenses_Type_Rectime }); ;
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
            var objecttable = DB.Expenses_Types.Where(a => a.Expenses_Type_Id.Equals(ID)).SingleOrDefault();
            
            objecttable.Expenses_Type_Name = TextBoxContacttype.Text;
            DB.Expenses_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Expenses_Types.Where(a => a.Expenses_Type_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Expenses_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }
    }
}