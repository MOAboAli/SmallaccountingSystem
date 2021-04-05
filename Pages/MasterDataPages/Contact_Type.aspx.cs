using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    
    public partial class Contact_Type : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            
            Contat_T NewContactType = new Contat_T();
            NewContactType.Contat_T_Name = TextBoxContacttype.Text;
            NewContactType.Contat_T_RecTime = DateTime.Now;
            NewContactType.Contat_T_Note = "";
            NewContactType.UserID =Convert.ToInt32( Session["userid"]);
            NewContactType.IsDisable = false;

            DB.Contat_Ts.InsertOnSubmit(NewContactType);
            DB.SubmitChanges();




        }

        protected void databind()
        {
            GridView1.DataSource = DB.Contat_Ts.Where(a=>a.IsDisable.Equals(false)).Select(a => new {ID=a.Contat_T_Id,Name=a.Contat_T_Name,DateOfRec=a.Contat_T_RecTime  }); ;
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
            var objecttable = DB.Contat_Ts.Where(a => a.Contat_T_Id.Equals(ID)).SingleOrDefault();
            objecttable.Contat_T_Note = objecttable.Contat_T_Note + "  " + objecttable.Contat_T_Name;
            objecttable.Contat_T_Name = TextBoxContacttype.Text;            
            DB.Contat_Ts.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Contat_Ts.Where(a => a.Contat_T_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Contat_Ts.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }

        }
    }