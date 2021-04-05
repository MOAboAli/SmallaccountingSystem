using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class TaxInvoice : System.Web.UI.Page
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
                    dropdownlist();
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
            GridView1.DataSource = DB.InvoiceTaxes.Where(a => a.IsDisable.Equals(false) && a.Invoice_ID.Equals(id)).Select(a => new { ID = a.InvoiceTax_Id, Amount = a.InvoiceTax_Amount, Date = a.InvoiceTax_RecTime, a.InvoiceTax_Percentage }); ;
            GridView1.DataBind();
        }

        protected void dropdownlist()
        {
            DropDownListtax.DataSource = DB.Taxes.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.Tax_Id,name=a.Tax_Name });
            DropDownListtax.DataBind();
        }

        protected void add()
        {
            InvoiceTax detials = new InvoiceTax();

            detials.InvoiceTax_Amount = Convert.ToDouble(TextBoxdamount.Text);
            detials.InvoiceTax_Percentage = Convert.ToDouble(TextBoxdpercentage.Text);
            detials.InvoiceTax_RecTime = DateTime.Now;
            
            detials.Tax_Id = Convert.ToInt32(DropDownListtax.SelectedValue);
            
            detials.Invoice_ID = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;
           
            detials.Rectime = DateTime.Now;

            DB.InvoiceTaxes.InsertOnSubmit(detials);
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

            var discount = DB.DiscountInvoice2s.Where(a => a.Invoice_Id.Equals(invoice.Invoice_Id) && a.IsDisable.Equals(false));
            foreach (var item in discount)
            {
                amount = amount + Convert.ToDecimal(item.DiscountInvoice_Amount);
                percentage = percentage + (Convert.ToDecimal(item.DiscountInvoice_Percentage) * Convert.ToDecimal(invoice.Invoice_Price)) / 100;

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
            var objecttable = DB.InvoiceTaxes.Where(a => a.InvoiceTax_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.InvoiceTaxes.DefaultIfEmpty(objecttable);
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

        protected void DropDownListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxdpercentage.Text =Convert.ToString( DB.Taxes.Where(a => a.Tax_Id.Equals(DropDownListtax.SelectedValue)).SingleOrDefault().Tax_Percentage);
        }

        protected void SuccessbtnInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInvoice.aspx?ID=" + Labelid.Text);
        }
    }
}