using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages
{
    public partial class Cheque : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
            GridView1.DataSource = DB.Cheques.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cheque_Id, Name = a.Cheque_Bank_Name, a.Cheque_No, DateOFOpen = a.Cheque_Date, a.Cheque_Notes }); ;
            GridView1.DataBind();
        }
        protected void cleartools()
        {
            TextChequeNo.Text = "";
            TextPersonInCharge.Text = "";
            TextBoxNote.Text = "";
            
        }
        protected void insertdata()
        {
            BsolutionWebApp.Cheque object_Cheque = new BsolutionWebApp.Cheque();

            object_Cheque.Cheque_No = (TextChequeNo.Text);
            object_Cheque.Cheque_Bank_Name = ddBankName.SelectedItem.ToString();
            object_Cheque.Cheque_Notes = TextBoxNote.Text;
            object_Cheque.Cheque_Date = Convert.ToDateTime(datepicker.Text);
            object_Cheque.IsDisable = false;
            object_Cheque.PersonInCharge = TextPersonInCharge.Text;
            object_Cheque.RecTime = DateTime.Now;
            object_Cheque.UserId =Convert.ToInt32( Session["userid"]);
            DB.Cheques.InsertOnSubmit(object_Cheque);
            DB.SubmitChanges();
        }
        protected void insertdata( int Collecting_Id)
        {
            BsolutionWebApp.Cheque object_Cheque = new BsolutionWebApp.Cheque();
            object_Cheque.Collecting_Id = Collecting_Id;
            object_Cheque.Cheque_No = (TextChequeNo.Text);
            object_Cheque.Cheque_Bank_Name = ddBankName.SelectedItem.ToString();
            object_Cheque.Cheque_Notes = TextBoxNote.Text;
            object_Cheque.Cheque_Date = Convert.ToDateTime(datepicker.Text);
            object_Cheque.IsDisable = false;
            object_Cheque.PersonInCharge = TextPersonInCharge.Text;
            object_Cheque.RecTime = DateTime.Now;
            object_Cheque.UserId =Convert.ToInt32( Session["userid"]);
            DB.Cheques.InsertOnSubmit(object_Cheque);
            DB.SubmitChanges();
        }
        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var object1 = DB.Cheques.Where(a => a.Cheque_Id.Equals(ID)).SingleOrDefault();
            object1.Cheque_No = (TextChequeNo.Text);
            object1.Cheque_Bank_Name = ddBankName.SelectedValue;
            object1.Cheque_Notes = TextBoxNote.Text;
            object1.Cheque_Date = Convert.ToDateTime(datepicker.Text);
            object1.IsDisable = false;
            object1.PersonInCharge = TextPersonInCharge.Text;
            object1.RecTime = DateTime.Now;
            object1.UserId =Convert.ToInt32( Session["userid"]);
            DB.Cheques.DefaultIfEmpty(object1);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Cheques.Where(a => a.Cheque_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Cheques.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            if (id != "" && id != null)
            {
                insertdata(int.Parse(id));
            }
            else
            {
                insertdata();
                cleartools();
            }
        }
    }
}