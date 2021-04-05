using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.ContactPages
{
    public partial class Contact : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdownlistbind();
                gridbind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            add();
            gridbind();
        }

        protected void add()
        {
            Contact2 newobject = new Contact2();
            newobject.Client_Type =Convert.ToInt32( DropDownList1.SelectedValue);
            newobject.Contact_Location = TextBoxlocation.Text;
            newobject.Contact_ManinCharge = TextBoxpicname.Text;
            newobject.Contact_Mobile = TextBoxmobile.Text;
            newobject.Contact_Mobile_ManinChaarge = TextBoxpicphone.Text;
            newobject.Contact_Name = TextBoxContactName.Text;
            newobject.Contact_Note = TextBoxNote.Text;
            newobject.Contact_Phone = TextBoxphone.Text;
            newobject.Contact_Rectime = DateTime.Now;
            newobject.Contact_Website = TextBoxwebsite.Text;
            newobject.IsDisable = false;
            newobject.Rectime = DateTime.Now;
            newobject.UserID =Convert.ToInt32( Session["userid"]);

            DB.Contact2s.InsertOnSubmit(newobject);
            DB.SubmitChanges();




        }

        protected void dropdownlistbind()
        {
            DropDownList1.DataSource = DB.Contat_Ts.Where(a => a.IsDisable.Equals(false)).Select(a=> new {a.Contat_T_Id,a.Contat_T_Name });
            DropDownList1.DataBind();
        }
        protected void gridbind()
        {
            GridView1.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Contact_Id, Name = a.Contact_Name, a.Contact_Mobile,  a.Contact_Phone, a.Contact_Location, a.Contact_ManinCharge, a.Contact_Mobile_ManinChaarge, Note = a.Contact_Note }); ;
            GridView1.DataBind();
        }

        protected void SelectGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Contact2s.Where(a => a.Contact_Id.Equals(ID)).SingleOrDefault();


            DropDownList1.SelectedValue=Convert.ToString(newobject.Client_Type);
            TextBoxlocation.Text = newobject.Contact_Location;
             TextBoxpicname.Text= newobject.Contact_ManinCharge;
             TextBoxmobile.Text= newobject.Contact_Mobile;
              TextBoxpicphone.Text= newobject.Contact_Mobile_ManinChaarge;
             TextBoxContactName.Text= newobject.Contact_Name;
             TextBoxNote.Text= newobject.Contact_Note;
              TextBoxphone.Text= newobject.Contact_Phone;
            
            TextBoxwebsite.Text = newobject.Contact_Website;
            

        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Contact2s.Where(a => a.Contact_Id.Equals(ID)).SingleOrDefault();
            newobject.Client_Type = Convert.ToInt32(DropDownList1.SelectedValue);
            newobject.Contact_Location = TextBoxlocation.Text;
            newobject.Contact_ManinCharge = TextBoxpicname.Text;
            newobject.Contact_Mobile = TextBoxmobile.Text;
            newobject.Contact_Mobile_ManinChaarge = TextBoxpicphone.Text;
            newobject.Contact_Name = TextBoxContactName.Text;
            newobject.Contact_Note = TextBoxNote.Text;
            newobject.Contact_Phone = TextBoxphone.Text;
            newobject.Contact_Rectime = DateTime.Now;
            newobject.Contact_Website = TextBoxwebsite.Text;
            newobject.Rectime = DateTime.Now;
            newobject.UserID =Convert.ToInt32( Session["userid"]);
            DB.Contact2s.DefaultIfEmpty(newobject);
            DB.SubmitChanges();
            gridbind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Contact2s.Where(a => a.Contact_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Contact2s.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            gridbind();
        }
    }
}