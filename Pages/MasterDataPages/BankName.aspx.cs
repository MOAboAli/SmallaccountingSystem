using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class BankName : System.Web.UI.Page
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
            if (TextBoxBankName.Text != "" || TextBoxAccountNo.Text != "")
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

            Bank_Name object1 = new Bank_Name();

            object1.AccountNo =( TextBoxAccountNo.Text);
            object1.Bank_Name1 = TextBoxBankName.Text;
            object1.Bank_Name_Notes = TextBoxNote.Text;
            object1.DateOfOpen  =Convert.ToDateTime( datepicker.Text);
            object1.IsDisable = false;
            object1.Loation = TextBoxLocation.Text;
            object1.PersonInCharge = TextBoxPersonInCharge.Text;
            object1.Phone = TextBoxPhone.Text;
            object1.Phone_PersonInCharge = TextBoxPhonePIC.Text;
            object1.RecTime = DateTime.Now;
            object1.UserId =Convert.ToInt32( Session["userid"]);
            

            DB.Bank_Names.InsertOnSubmit(object1);
            DB.SubmitChanges();




        }

        protected void databind()
        {
            GridView1.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID=a.BankName_Id,Name = a.Bank_Name1, a.AccountNo, DateOFOpen = a.DateOfOpen ,a.Phone,a.Loation,a.PersonInCharge,a.Phone_PersonInCharge,Note=a.Bank_Name_Notes }); ;
            GridView1.DataBind();
        }   

        protected void cleartools()
        {
            TextBoxAccountNo.Text = "";
            TextBoxBankName.Text = "";
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var object1 = DB.Bank_Names.Where(a => a.BankName_Id.Equals(ID)).SingleOrDefault();
            object1.AccountNo = (TextBoxAccountNo.Text);
            object1.Bank_Name1 = TextBoxBankName.Text;
            object1.Bank_Name_Notes = TextBoxNote.Text;
            object1.DateOfOpen = Convert.ToDateTime(datepicker.Text);
            object1.IsDisable = false;
            object1.Loation = TextBoxLocation.Text;
            object1.PersonInCharge = TextBoxPersonInCharge.Text;
            object1.Phone = TextBoxPhone.Text;
            object1.Phone_PersonInCharge = TextBoxPhonePIC.Text;
            object1.RecTime = DateTime.Now;
            object1.UserId =Convert.ToInt32( Session["userid"]);
            DB.Bank_Names.DefaultIfEmpty(object1);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Bank_Names.Where(a => a.BankName_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Bank_Names.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }

    }
}