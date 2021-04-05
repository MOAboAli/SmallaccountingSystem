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
                string id = Request.QueryString["ID"];
                if (id != "" && id != null)
                {
                    binddata(id);
                }
                else
                {
                    databind();
                }
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            if (TextCollectingName.Text != "" && TextCollectingNo.Text != ""&& ddInvoice.SelectedValue != "")
            {
               // float Amount = float.Parse(DB.Invoices.Where(a => a.Invoice_Id==int.Parse(ddInvoice.SelectedValue)&& a.IsDisable.Equals(false)&&a.Invoice_IsDone.Equals(false)).Select(a =>  a.Invoice_TotalCost).ToString());
                var Invoice_Amount_Check = (from x in DB.Invoices    where x.Invoice_Id == int.Parse(ddInvoice.SelectedValue) && x.IsDisable.Equals(false) && x.Invoice_IsDone.Equals(false)
                           select new
                           {
                               x.Invoice_TotalCost
                           }).FirstOrDefault();
                var Collecting_Check = (from x in DB.Collectings
                           where x.Collecting_No == int.Parse(TextCollectingNo.Text) && x.Collecting_Name==TextCollectingName.Text
                           select new
                           {
                               x.Collecting_No
                           }).FirstOrDefault();
                if (Collecting_Check==null)
                {
                    if (Invoice_Amount_Check != null)
                    {
                        if (ddChequeOrCash.SelectedValue == "0")
                        {
                            insertdata();
                            databind();
                            Response.Redirect("Cheque.aspx?ID=" + Labelid.Text);
                        }
                        else
                        {
                            insertdata();
                            databind();
                            Response.Redirect("Cash.aspx?ID=" + Labelid.Text);
                        }
                        cleartools();
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('This Invoice is collecting before and all cost is completly collected');</script>");
                    }  
                }
                else
                {
                    Response.Write("<script language=javascript>alert('This collecting_No and collecting_Name is Used Before try another');</script>");
                }
                
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
            //object1.BankCashtype_Id = Int32.Parse(DropDownListbankcashtype.SelectedValue);

            object1.BankorCash = int.Parse(ddChequeOrCash.SelectedValue);
            object1.Invoice_Id = Int32.Parse(ddInvoice.SelectedValue);
            object1.Contact_Id = Int32.Parse(ddContact.SelectedValue);
            object1.Operation_Type_Id =Int32.Parse(ddOperationType.SelectedValue);
            object1.Rectime = DateTime.Now;
            object1.User_Id = 0;


            DB.Collectings.InsertOnSubmit(object1);
            DB.SubmitChanges();

            bsclass bs = new bsclass();
            if (ddChequeOrCash.SelectedValue == "0")
            {
                bs.AddBank(object1.Collecting_Id, false, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), object1.Collecting_Note, "+", "", 0, 0,false);

            }
            else if (ddChequeOrCash.SelectedValue == "1")
            {
                bs.Addcash(object1.Collecting_Id, false, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), object1.Collecting_Note, "+", "", 0, 0, false);
            }
            Labelid.Text = object1.Collecting_Id.ToString();

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
            //object1.BankCashtype_Id = Int32.Parse(DropDownListbankcashtype.SelectedValue);
            object1.BankorCash = int.Parse(ddChequeOrCash.SelectedValue);
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

        protected void DropDownListbankcash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddChequeOrCash.SelectedValue == "0")
            {
                DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, name = a.Bank_Name1 });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Bank Names";
            }
            else
            {
                DropDownListbankcashtype.DataSource = DB.Cash_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cash_Type_Id, name = a.Cash_Type_Name });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Cash Types";
            }
        }
        protected void binddata(string id)
        {
            Labelid.Text = Convert.ToString(id);
            BsolutionWebApp.Collecting object2 = DB.Collectings.Where(a => a.Collecting_Id.Equals(id)).SingleOrDefault();

            TextCollectingNo.Text = object2.Collecting_No.ToString();
            TextCollectingName.Text = object2.Collecting_Name.ToString();
            TextBoxNote.Text = object2.Collecting_Note.ToString();
            datepicker.Text = object2.Collecting_Date.ToString();
            object2.IsDisable = false;
            ddChequeOrCash.SelectedValue = object2.BankorCash.ToString();
            //DropDownListbankcashtype.SelectedValue = object2.BankCashtype_Id.ToString();
            ddInvoice.SelectedValue = object2.Invoice_Id.ToString();
            ddContact.SelectedValue = object2.Contact_Id.ToString();
            ddOperationType.SelectedValue = object2.Operation_Type_Id.ToString();
            Labelstatus.Text = "Collecting No=" + object2.Collecting_No + " -Date of Collecting" + object2.Collecting_Date;


        }
    }
}