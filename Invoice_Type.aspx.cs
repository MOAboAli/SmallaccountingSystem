using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp
{
    public partial class Invoice_Type : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void insertdata()
        {

            Invoice_T NewInvoiceType = new Invoice_T();
            NewInvoiceType.Invoice_T_Name = TextBoxInvoicetype.Text;
            NewInvoiceType.Invoice_T_Rectime = DateTime.Now;
            NewInvoiceType.Invoice_T_Note = "";
            NewInvoiceType.UserID =Convert.ToInt32( Session["userid"]);
            NewInvoiceType.IsDisable = false;

            DB.Invoice_Ts.InsertOnSubmit(NewInvoiceType);
            DB.SubmitChanges();
        }
        protected void databind()
        {
            GridView1.DataSource = DB.Invoice_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new { a.Invoice_T_Id, a.Invoice_T_Name, DateOfRec = a.Invoice_T_Rectime }); ;
            GridView1.DataBind();
        }
        protected void cleartools()
        {
            TextBoxInvoicetype.Text = "";
        }
        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(ID)).SingleOrDefault();
            objecttable.Invoice_T_Note = objecttable.Invoice_T_Note + "  " + objecttable.Invoice_T_Name;
            objecttable.Invoice_T_Name = TextBoxInvoicetype.Text;
            DB.Invoice_Ts.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Invoice_Ts.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }

        protected void btn_InvoiceType_Click(object sender, EventArgs e)
        {
            if (TextBoxInvoicetype.Text != "")
            {
                insertdata();
                databind();
            }
            else
            {
                Response.Write("<script language=javascript>alert('NO DataSaved');</script>");
            }
        }
    }
}