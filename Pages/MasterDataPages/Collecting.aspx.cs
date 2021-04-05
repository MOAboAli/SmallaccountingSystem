using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{

    public partial class Collecting : System.Web.UI.Page
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
            if (TextCollectingName.Text != "" || TextCollectingNo.Text != "")
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
            BsolutionWebApp.Collecting object1 = new BsolutionWebApp.Collecting();
            
            object1.Collecting_No = Int32.Parse(TextCollectingNo.Text);
            object1.Collecting_Name = TextCollectingName.Text;
            object1.Collecting_Note = TextBoxNote.Text;
            object1.Collecting_Date = Convert.ToDateTime(datepicker.Text);
            object1.IsDisable = false;
            object1.Cheque_Id = Int32.Parse(ddCheque.SelectedValue);
            object1.Invoice_Id = Int32.Parse(ddInvoice.SelectedValue);
            object1.Contact_Id = Int32.Parse(ddContact.SelectedValue);
            object1.Operation_Type_Id =Int32.Parse(ddOperationType.SelectedValue);
            object1.Rectime = DateTime.Now;
            object1.User_Id = 0;


            DB.Collectings.InsertOnSubmit(object1);
            DB.SubmitChanges();

            bsclass bs = new bsclass();
            if (object1.Invoice_Type_Id == 1)
                bs.Addtransaction(2, "Invoice+", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price - object1.Invoice_TotalCost, "");
            else if (object1.Invoice_Type_Id == 2)
                bs.Addtransaction(4, "Invoice-", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price - object1.Invoice_TotalCost, "");

            var serical = DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault();
            serical.Invoice++;
            DB.Invoice_Serial_Collects.DefaultIfEmpty(serical);
            DB.SubmitChanges();

            Labelstatus.Text = "Invoice No=" + object1.Invoice_No + " -Date of Invoice" + object1.Invoice_Date;


        }

        protected void databind()
        {
            GridView1.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Collecting_Id, Name = a.Collecting_Name, a.Collecting_No, DateOFOpen = a.Collecting_Date, a.Collecting_Note, a.Collecting_Amount, a.Collecting_WhatsLeft, Note = a.Collecting_Note }); ;
            GridView1.DataBind();
        }

        protected void cleartools()
        {
            TextCollectingNo.Text = "";
            TextCollectingName.Text = "";
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var object1 = DB.Collectings.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();
            object1.Collecting_No =Int32.Parse(TextCollectingNo.Text);
            object1.Collecting_Name = TextCollectingName.Text;
            object1.Collecting_Note = TextBoxNote.Text;
            object1.Collecting_Date = Convert.ToDateTime(datepicker.Text);
            object1.IsDisable = false;
            object1.Cheque_Id = Int32.Parse(ddCheque.SelectedValue);
            object1.Invoice_Id = Int32.Parse(ddInvoice.SelectedValue);
            object1.Contact_Id = Int32.Parse(ddContact.SelectedValue);
            object1.Operation_Type_Id = Int32.Parse(ddOperationType.SelectedValue);
            object1.Rectime = DateTime.Now;
            object1.User_Id = 0;
            DB.Collectings.DefaultIfEmpty(object1);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Collectings.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Collectings.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }

    }
}