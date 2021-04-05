using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BsolutionWebApp;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class InvoiceDetials : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                if (id != "" && id != null)
                {
                    Labelid.Text = id;
                    dropdownlist();
                    databind(id);
                    changedrop();
                }
               
            }

        }

        

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            bsclass cls = new bsclass();
            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();
            if (invoice.Invoice_Type_Id == 1)
            {
                var item = DB.Items.Where(a => a.Items_Id.Equals(DropDownListItem.SelectedValue)).SingleOrDefault();

                if (item.HasStock == 1)
                {
                    var newstock = DB.Stocks.Where(a => a.Item_Id.Equals(DropDownListItem.SelectedValue)).SingleOrDefault();
                    if (newstock.Stock_Quantity >= Convert.ToInt32(TextBoxquentity.Text))
                    {
                        add();
                        cls.invoicesale(Convert.ToInt32(DropDownListItem.SelectedValue), Convert.ToInt32(TextBoxquentity.Text), false, Convert.ToDouble(textboxunticost.Text));
                    }
                    else
                    {

                        Response.Write("<script language=javascript>alert('Over Stock Quanitity');</script>");
                    }
                }
                else
                {
                    add();
                }

            }
            else
            {
                add();
                var item = DB.Items.Where(a => a.Items_Id.Equals(DropDownListItem.SelectedValue)).SingleOrDefault();

                if (item.HasStock == 1)
                {
                    cls.invoicesale(Convert.ToInt32(DropDownListItem.SelectedValue), Convert.ToInt32(TextBoxquentity.Text), true, Convert.ToDouble(textboxunticost.Text));
                }
            }
            
        }

        protected void databind(string id)
        {
            GridView1.DataSource =   from a in DB.Invoice_Details.Where(a => a.IsDisable.Equals(false) && a.Invoice_Id.Equals(id)) 
                                     join b in DB.Items on a.Item_ID equals b.Items_Id
                                     select( new { ID = a.Invoice_Details_Id, Name = b.Items_Name, DateOfRec = a.Rectime,a.Quantity,a.Unit_Cost,a.Total_Price }); ;
            GridView1.DataBind();
        }

        protected void dropdownlist()
        {
            DropDownListItem.DataSource = DB.Items.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.Items_Id,Name=a.Items_Name });
            DropDownListItem.DataBind();
        }

        protected void add()
        {
            Invoice_Detail detials = new Invoice_Detail();
            detials.Item_ID =Convert.ToInt32( DropDownListItem.SelectedValue);
            detials.Invoice_Id = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;
            detials.Quantity = Convert.ToInt32(TextBoxquentity.Text);
            detials.Rectime = DateTime.Now;
            detials.Unit_Cost = Convert.ToDouble(textboxunticost.Text);
            detials.After_Disount_Price= Convert.ToDouble(TextBoxunitprice.Text);
            detials.Total_Cost= Convert.ToDouble(textboxunticost.Text)* Convert.ToInt32(TextBoxquentity.Text);
            detials.Total_Price= Convert.ToDouble(TextBoxunitprice.Text) * Convert.ToInt32(TextBoxquentity.Text);

            DB.Invoice_Details.InsertOnSubmit(detials);
            DB.SubmitChanges();

            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();
            invoice.Invoice_TotalCost = invoice.Invoice_TotalCost + detials.Total_Cost;
            invoice.Invoice_Price = invoice.Invoice_Price + detials.Total_Price;
            invoice.totalPrice = invoice.totalPrice + Convert.ToDecimal(detials.Total_Price);

            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();

            databind(Labelid.Text);
            editinvoicemoney(Labelid.Text);


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
            var objecttable = DB.Invoice_Details.Where(a => a.Invoice_Details_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Invoice_Details.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();

            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();
            invoice.Invoice_TotalCost = invoice.Invoice_TotalCost - objecttable.Total_Cost;
            invoice.Invoice_Price = invoice.Invoice_Price - objecttable.Total_Price;
            invoice.totalPrice = invoice.totalPrice - Convert.ToDecimal(objecttable.Total_Price);

            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();

            editinvoicemoney(Labelid.Text);
            databind(Labelid.Text);


        }

        protected void DropDownListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            changedrop();

        }

        private void changedrop()
        {

            var item = DB.Items.Where(a => a.Items_Id.Equals(DropDownListItem.SelectedValue)).SingleOrDefault();
            textboxunticost.Text = Convert.ToString(item.AverageCost);
            TextBoxunitprice.Text = Convert.ToString(item.Items_Price);
            if(item.HasStock == 1)
            {

                var newstock = DB.Stocks.Where(a => a.Item_Id.Equals(item.Items_Id)).SingleOrDefault();
                TextBoxquentity.Text =Convert.ToString( newstock.Stock_Quantity);
            }

        }

        protected void SuccessbtnInvoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddInvoice.aspx?ID=" + Labelid.Text);
        }

       

    }
}