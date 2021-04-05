using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Report.Cash_Bank
{
    public partial class Cash_BankReport : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dropdownlistcashbank();
                gridbind();

               
            }
        }

        protected void DropDownListbankcash_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownlistcashbank();
        }


        protected void dropdownlistcashbank()
        {
            if (DropDownListbankcash.SelectedValue == "0")
            {
                DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, name = a.Bank_Name1 });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Bank Names";

                gridbind();
            }
            else
            {
                DropDownListbankcashtype.DataSource = DB.Cash_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cash_Type_Id, name = a.Cash_Type_Name });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Cash Types";

                gridbind();
            }


        }

        protected void DropDownListbankcashtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridbind();
        }


        public void gridbind()
        {

            if (DropDownListbankcash.SelectedValue == "0")
            {
                bsclass bs = new bsclass();
                Labelstatus.Text = "Current Balance =" + bs.checkblance(true, Convert.ToInt32( DropDownListbankcashtype.SelectedValue));
                var banks = DB.Banks.Where(a => a.BankName_ID.Equals(DropDownListbankcashtype.SelectedValue));

                DataTable dt = new DataTable();
                
                dt.Columns.Add("Type");
                dt.Columns.Add("No.");
                dt.Columns.Add("+/-");
                dt.Columns.Add("DateTime");
                dt.Columns.Add("InvoiceNo.");
                dt.Columns.Add("DateInvoice");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Contact");
                
                foreach(var bank in banks)
                {

                    if(bank.Collecting_Id != 0)
                    {
                        var collect = DB.Collectings.Where(a => a.Collecting_Id.Equals(bank.Collecting_Id)).SingleOrDefault();
                        if(collect.Invoice_Id != 0)
                        {
                            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(collect.Invoice_Id)).SingleOrDefault();
                            if(invoice.Invoice_Type_Id == 1)
                            {
                                DataRow _ravi = dt.NewRow();
                                _ravi["Type"] = "تحصيل فاتورة بيع";
                                _ravi["No."] = collect.Collecting_No;
                                _ravi["+/-"] = "+";
                                _ravi["DateTime"] = collect.Collecting_Date;
                                _ravi["InvoiceNo."] = invoice.Invoice_No;
                                _ravi["DateInvoice"] = invoice.Invoice_Date;
                                _ravi["Amount"] = collect.Collecting_Amount;
                                _ravi["Contact"] = DB.Contact2s.Where(a=>a.Contact_Id.Equals(invoice.Contact_Id)).SingleOrDefault().Contact_Name;
                                dt.Rows.Add(_ravi);
                            }
                            else if (invoice.Invoice_Type_Id == 2)
                            {
                                DataRow _ravi = dt.NewRow();
                                _ravi["Type"] = "دفع فاتورة شراء";
                                _ravi["No."] = collect.Collecting_No;
                                _ravi["+/-"] = "-";
                                _ravi["DateTime"] = collect.Collecting_Date;
                                _ravi["InvoiceNo."] = invoice.Invoice_No;
                                _ravi["DateInvoice"] = invoice.Invoice_Date;
                                _ravi["Amount"] = collect.Collecting_Amount;
                                _ravi["Contact"] = DB.Contact2s.Where(a => a.Contact_Id.Equals(invoice.Contact_Id)).SingleOrDefault().Contact_Name;
                                dt.Rows.Add(_ravi);
                            }
                        }
                        else if (collect.Contact_Id != 0)
                        {
                            var contact = DB.Contact2s.Where(a => a.Contact_Id.Equals(collect.Contact_Id)).SingleOrDefault();
                            
                            DataRow _ravi = dt.NewRow();
                            _ravi["Type"] = "حساب الشركاء";
                            _ravi["No."] = collect.Collecting_No;

                            if (collect.Operation_Type_Id ==1)
                                _ravi["+/-"] = "+";
                            else if (collect.Operation_Type_Id == 2)
                                _ravi["+/-"] = "-";

                            _ravi["DateTime"] = collect.Collecting_Date;
                            _ravi["InvoiceNo."] = "";
                            _ravi["DateInvoice"] = "";
                            _ravi["Amount"] = collect.Collecting_Amount;
                            _ravi["Contact"] = contact.Contact_Name;
                            dt.Rows.Add(_ravi);
                        }

                    }
                    else if (bank.Expenses_Id != 0)
                    {
                        var expense = DB.Expenses.Where(a => a.Expenses_Id.Equals(bank.Expenses_Id)).SingleOrDefault();

                        DataRow _ravi = dt.NewRow();
                        _ravi["Type"] = "مصروف";
                        _ravi["No."] = expense.Expenses_No;
                        _ravi["+/-"] = "-";
                        _ravi["DateTime"] = expense.Expenses_Date;
                        _ravi["InvoiceNo."] = "";
                        _ravi["DateInvoice"] = "";
                        _ravi["Amount"] = expense.Expenses_Total;
                        _ravi["Contact"] = expense.Expenses_From;
                        dt.Rows.Add(_ravi);

                    }



                   

                }


                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {

                bsclass bs = new bsclass();
                Labelstatus.Text = "Current Balance =" + bs.checkblance(false, Convert.ToInt32(DropDownListbankcashtype.SelectedValue));
                var banks = DB.Cashes.Where(a => a.CashID.Equals(DropDownListbankcashtype.SelectedValue));

                DataTable dt = new DataTable();

                dt.Columns.Add("Type");
                dt.Columns.Add("No.");
                dt.Columns.Add("+/-");
                dt.Columns.Add("DateTime");
                dt.Columns.Add("InvoiceNo.");
                dt.Columns.Add("DateInvoice");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Contact");

                foreach (var bank in banks)
                {

                    if (bank.Collecting_Id != 0)
                    {
                        var collect = DB.Collectings.Where(a => a.Collecting_Id.Equals(bank.Collecting_Id)).SingleOrDefault();
                        if (collect.Invoice_Id != 0)
                        {
                            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(collect.Invoice_Id)).SingleOrDefault();
                            if (invoice.Invoice_Type_Id == 1)
                            {
                                DataRow _ravi = dt.NewRow();
                                _ravi["Type"] = "تحصيل فاتورة بيع";
                                _ravi["No."] = collect.Collecting_No;
                                _ravi["+/-"] = "+";
                                _ravi["DateTime"] = collect.Collecting_Date;
                                _ravi["InvoiceNo."] = invoice.Invoice_No;
                                _ravi["DateInvoice"] = invoice.Invoice_Date;
                                _ravi["Amount"] = collect.Collecting_Amount;
                                _ravi["Contact"] = DB.Contact2s.Where(a => a.Contact_Id.Equals(invoice.Contact_Id)).SingleOrDefault().Contact_Name;
                                dt.Rows.Add(_ravi);
                            }
                            else if (invoice.Invoice_Type_Id == 2)
                            {
                                DataRow _ravi = dt.NewRow();
                                _ravi["Type"] = "دفع فاتورة شراء";
                                _ravi["No."] = collect.Collecting_No;
                                _ravi["+/-"] = "-";
                                _ravi["DateTime"] = collect.Collecting_Date;
                                _ravi["InvoiceNo."] = invoice.Invoice_No;
                                _ravi["DateInvoice"] = invoice.Invoice_Date;
                                _ravi["Amount"] = collect.Collecting_Amount;
                                _ravi["Contact"] = DB.Contact2s.Where(a => a.Contact_Id.Equals(invoice.Contact_Id)).SingleOrDefault().Contact_Name;
                                dt.Rows.Add(_ravi);
                            }
                        }
                        else if (collect.Contact_Id != 0)
                        {
                            var contact = DB.Contact2s.Where(a => a.Contact_Id.Equals(collect.Contact_Id)).SingleOrDefault();

                            DataRow _ravi = dt.NewRow();
                            _ravi["Type"] = "حساب الشركاء";
                            _ravi["No."] = collect.Collecting_No;

                            if (collect.Operation_Type_Id == 1)
                                _ravi["+/-"] = "+";
                            else if (collect.Operation_Type_Id == 2)
                                _ravi["+/-"] = "-";

                            _ravi["DateTime"] = collect.Collecting_Date;
                            _ravi["InvoiceNo."] = "";
                            _ravi["DateInvoice"] = "";
                            _ravi["Amount"] = collect.Collecting_Amount;
                            _ravi["Contact"] = contact.Contact_Name;
                            dt.Rows.Add(_ravi);
                        }

                    }
                    else if (bank.Expenses_Id != 0)
                    {
                        var expense = DB.Expenses.Where(a => a.Expenses_Id.Equals(bank.Expenses_Id)).SingleOrDefault();

                        DataRow _ravi = dt.NewRow();
                        _ravi["Type"] = "مصروف";
                        _ravi["No."] = expense.Expenses_No;
                        _ravi["+/-"] = "-";
                        _ravi["DateTime"] = expense.Expenses_Date;
                        _ravi["InvoiceNo."] = "";
                        _ravi["DateInvoice"] = "";
                        _ravi["Amount"] = expense.Expenses_Total;
                        _ravi["Contact"] = expense.Expenses_From;
                        dt.Rows.Add(_ravi);

                    }





                }


                GridView1.DataSource = dt;
                GridView1.DataBind();

            }





        }
    }
}