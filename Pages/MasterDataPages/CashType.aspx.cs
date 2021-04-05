using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class CashType : System.Web.UI.Page
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
            if (TextBoxCashtype.Text != "")
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

            Cash_Type NewContactType = new Cash_Type();
            NewContactType.Cash_Type_Name = TextBoxCashtype.Text;
            NewContactType.Rectime = DateTime.Now;
            NewContactType.Cash_Type_Rectime = DateTime.Now;
            NewContactType.Cash_Type_Notes = 0;
            NewContactType.UserId =Convert.ToInt32( Session["userid"]);
            NewContactType.IsDisable = false;

            DB.Cash_Types.InsertOnSubmit(NewContactType);
            DB.SubmitChanges();




        }

        protected void databind()
        {
            GridView1.DataSource = DB.Cash_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cash_Type_Id, Name = a.Cash_Type_Name, DateOfRec = a.Cash_Type_Rectime }); ;
            GridView1.DataBind();
        }

        protected void cleartools()
        {
            TextBoxCashtype.Text = "";
            TextBoxNote.Text = "";
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Cash_Types.Where(a => a.Cash_Type_Id.Equals(ID)).SingleOrDefault();
            objecttable.Cash_Type_Notes = 0;
            objecttable.Cash_Type_Name = TextBoxCashtype.Text;
            //objecttable.Cash_Type_Notes = TextBoxNote.Text;
            DB.Cash_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Cash_Types.Where(a => a.Cash_Type_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Cash_Types.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }
    }
}