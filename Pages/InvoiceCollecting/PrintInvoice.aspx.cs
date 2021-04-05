using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class PrintInvoice : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            if (id != "" && id != null)
            {

                databind(id);

            }
            else
            {

            }

            

        }

        public void databind(string id)
        {

            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(id)).SingleOrDefault();
            var contact = DB.Contact2s.Where(a => a.Contact_Id.Equals(invoice.Contact_Id)).SingleOrDefault();

            Labelinvoiceno.Text = Convert.ToString(invoice.Invoice_No);
            LabelInvoiceDate.Text = Convert.ToString(invoice.Invoice_Date.Date.Day)+"/" + Convert.ToString(invoice.Invoice_Date.Date.Month) + "/" + Convert.ToString(invoice.Invoice_Date.Date.Year) ;
            Labelaccountno.Text = Convert.ToString(contact.AccountID);
            Labeltotaldue.Text = Convert.ToString(invoice.Invoice_AfterDiscountprice_ATax);
            LabelName.Text = Convert.ToString(contact.Contact_Name);
            Labelmobile.Text = Convert.ToString(contact.Contact_Mobile);
            Labeladdress.Text = Convert.ToString(contact.Contact_Location);

            Labeltotaldue2.Text = Convert.ToString(invoice.Invoice_AfterDiscountprice_ATax);
            Labeldiscount.Text = Convert.ToString(Convert.ToDecimal(invoice.Invoice_Price) - Convert.ToDecimal(invoice.Invoice_AfterDiscountprice));
            Labeltax.Text = Convert.ToString(Convert.ToDecimal(invoice.Invoice_AfterDiscountprice_ATax) - Convert.ToDecimal(invoice.Invoice_AfterDiscountprice));
            Labelsubtotal.Text = Convert.ToString(invoice.Invoice_Price);
           


            var detials =from d in  DB.Invoice_Details.Where(a => a.Invoice_Id.Equals(invoice.Invoice_Id))
                         join i in DB.Items on d.Item_ID equals i.Items_Id
                         select (new {i.Items_Name,d.After_Disount_Price,d.Quantity,d.Total_Price });

            DataTable dt = new DataTable();
            dt.Columns.Add("ItemDescription");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");


          


            foreach(var det in detials)
            {
                DataRow dr = dt.NewRow();
                dr[0] = det.Items_Name ;
                dr[1] = det.After_Disount_Price;
                dr[2] = det.Quantity;
                dr[3] = det.Total_Price;

                dt.Rows.Add(dr);
            }
           


            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}