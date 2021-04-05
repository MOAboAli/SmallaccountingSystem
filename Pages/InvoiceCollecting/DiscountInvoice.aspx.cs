using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class DiscountInvoice : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                if (id != "" && id != null)
                {
                    Labelid.Text = id;
                    datepicker.Text =Convert.ToString( DateTime.Now);
                    
                    databind(id);
                }

            }

        }
        
        protected void Successbtn_Click(object sender, EventArgs e)
        {
            add();
        }

        protected void databind(string id)
        {
            GridView1.DataSource =  DB.DiscountInvoice2s.Where(a => a.IsDisable.Equals(false) && a.Invoice_Id.Equals(id)).Select (a=>new { ID = a.DiscountInvoice_Id, Amount = a.DiscountInvoice_Amount, Date = a.DiscountInvoice_RecTime, a.DiscountInvoice_Percentage, a.IsFromCollecting, a.DiscountInvoice_Notes }); ;
            GridView1.DataBind();
        }

        protected void dropdownlist()
        {
            
        }

        protected void add()
        {
            DiscountInvoice2 detials = new DiscountInvoice2();

            detials.DiscountInvoice_Amount =Convert.ToDouble( TextBoxdamount.Text);
            detials.DiscountInvoice_Date = Convert.ToDateTime(datepicker.Text);
            detials.DiscountInvoice_Notes = TextBoxNote0.Text;
            detials.DiscountInvoice_Percentage =Convert.ToDouble( TextBoxdpercentage.Text);
            detials.DiscountInvoice_RecTime = DateTime.Now;
            detials.Invoice_Id = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;
            detials.IsFromCollecting =Convert.ToByte( CheckBoxcollecting.Checked);
            detials.Rectime = DateTime.Now;
            
            DB.DiscountInvoice2s.InsertOnSubmit(detials);
            DB.SubmitChanges();


            editinvoicemoney(Labelid.Text);
            databind(Labelid.Text);
        }



        private void editinvoicemoney(string id)
        {

            decimal amount = 0;
            decimal percentage = 0;
            decimal taxamount = 0;
            decimal taxpercentage = 0;
            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();

            var discount = DB.DiscountInvoice2s.Where(a => a.Invoice_Id.Equals(invoice.Invoice_Id)&& a.IsDisable.Equals(false));
            foreach(var item in discount)
            {
                amount = amount + Convert.ToDecimal( item.DiscountInvoice_Amount);
                percentage = percentage + (Convert.ToDecimal(item.DiscountInvoice_Percentage) * Convert.ToDecimal(invoice.Invoice_Price))/100;

            }

            invoice.Invoice_AfterDiscountprice = Convert.ToDouble(Convert.ToDecimal(invoice.Invoice_Price) - Convert.ToDecimal(amount + percentage));

            var taxvalue = DB.InvoiceTaxes.Where(a => a.Invoice_ID.Equals(invoice.Invoice_Id) && a.IsDisable.Equals(false));
            foreach (var item in taxvalue)
            {
                taxamount = taxamount + Convert.ToDecimal(item.InvoiceTax_Amount);
                taxpercentage = taxpercentage + (Convert.ToDecimal(item.InvoiceTax_Percentage) * Convert.ToDecimal(invoice.Invoice_AfterDiscountprice)) / 100;


            }

            invoice.Invoice_AfterDiscountprice_ATax = Convert.ToDouble(Convert.ToDecimal(invoice.Invoice_AfterDiscountprice) + Convert.ToDecimal(taxamount + taxpercentage));



            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();

            bsclass bs = new bsclass();
            bs.invoicetransaction(Labelid.Text);

        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.DiscountInvoice2s.Where(a => a.DiscountInvoice_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.DiscountInvoice2s.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();

            //var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();
            //invoice.Invoice_TotalCost = invoice.Invoice_TotalCost - objecttable.Total_Cost;
            //invoice.Invoice_Price = invoice.Invoice_Price - objecttable.Total_Price;
            //invoice.totalPrice = invoice.totalPrice - Convert.ToDecimal(objecttable.Total_Price);

            //DB.Invoices.DefaultIfEmpty(invoice);
            //DB.SubmitChanges();

            editinvoicemoney(Labelid.Text);
            databind(Labelid.Text);


        }

        protected void SuccessbtnInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInvoice.aspx?ID=" + Labelid.Text);
        }
    }
}