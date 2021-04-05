using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Collecting
{
    public partial class CollectingPageAdd : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                if (id != "" && id != null)
                {
                    Labelinvoiceid.Text = id;
                    dropdownlist();
                    gridbind();
                }
                  


            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            inser();
        }
        
        protected void dropdownlist()
        {



            DropDownListInvoice.DataSource = DB.Invoices.Where(a =>  a.Invoice_Id.Equals(Labelinvoiceid.Text)).Select(a => new { ID = a.Invoice_Id, name = "No:" + a.Invoice_No + "...Date:" + a.Invoice_Date });
            DropDownListInvoice.DataBind();

            DropDownListInvoicetype.DataSource = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(DB.Invoices.Where(b => b.Invoice_Id.Equals(Labelinvoiceid.Text)).SingleOrDefault().Invoice_Type_Id)).Select(a => new { ID = a.Invoice_T_Id, name = a.Invoice_T_Name });
            DropDownListInvoicetype.DataBind();


            TextBoxCollectingNo.Text = Convert.ToString(DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListInvoicetype.SelectedValue)).SingleOrDefault().Collecting + 1);

            getinvoicedetials();

            ondrop1change();
        }

        protected void getinvoicedetials()
        {
            double total=0,totalcollecting = 0;

            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(DropDownListInvoice.SelectedValue)).SingleOrDefault();

            TextBoxtotalinvoice.Text = invoice.Invoice_AfterDiscountprice_ATax.ToString();
            total = invoice.Invoice_AfterDiscountprice_ATax;
            var collecting = DB.Collectings.Where(a => a.Invoice_Id.Equals(DropDownListInvoice.SelectedValue));
            foreach(var collect in collecting)
            {

                totalcollecting += collect.Collecting_Amount;

            }

            TextBoxleft.Text = Convert.ToString(total-totalcollecting);


            if(Convert.ToInt32(TextBoxleft.Text) <= 0)
            {
                closeinvoice(true);
            }
            else
            {
                closeinvoice(false);
            }

        }

        protected void DropDownListInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            getinvoicedetials();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ondrop1change();
        }
        
        protected void ondrop1change()
        {
            if (DropDownList1.SelectedValue == "0")
            {
                Labelbankcash.Text = "Bank";
                DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.BankName_Id,name=a.Bank_Name1 });
                DropDownListbankcashtype.DataBind();

                //labelcheque.Visible = false;
                //TextBoxchequeno.Visible = false;

            }
            else if (DropDownList1.SelectedValue == "1")
            {
                Labelbankcash.Text = "Cash";
                DropDownListbankcashtype.DataSource = DB.Cash_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cash_Type_Id, name = a.Cash_Type_Name });
                DropDownListbankcashtype.DataBind();
                //labelcheque.Visible = false;
                //TextBoxchequeno.Visible = false;
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                //Labelbankcash.Text = "Bank";
                //DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, name = a.Bank_Name1 });
                //DropDownListbankcashtype.DataBind();
                //labelcheque.Visible = true;
                //TextBoxchequeno.Visible = true;
            }
        }
        
        protected void inser()
        {
            BsolutionWebApp.Collecting object1 = null;
            if (Labelcollectingid.Text == "0")
            {
                Labelstatus.Text = "";
                if (DropDownListInvoicetype.SelectedValue == "2")
                {
                    bsclass bs = new bsclass();

                    decimal balance = 0;

                    if (DropDownList1.SelectedValue == "0")
                    {
                        balance = bs.checkblance(true, Convert.ToInt32(DropDownListbankcashtype.SelectedValue));
                    }
                    else if (DropDownList1.SelectedValue == "1")
                    {
                        balance = bs.checkblance(false, Convert.ToInt32(DropDownListbankcashtype.SelectedValue));
                    }


                    if (balance < Convert.ToDecimal((TextBoxamount.Text)))
                    {
                        Labelstatus.Text = "The Currenct Balance Doesn't allow this transaction Current Balance is :" + balance;
                        return;
                    }
                }


                object1 = new BsolutionWebApp.Collecting();

                object1.Collecting_No = Int32.Parse(TextBoxCollectingNo.Text);
                object1.Collecting_Name = TextBoxcollectingname.Text;
                object1.Collecting_Note = TextBoxNote.Text;
                object1.Collecting_Date = Convert.ToDateTime(TextBoxdate.Text);
                object1.IsDisable = false;
                object1.Collecting_Note = Convert.ToString(DropDownListbankcashtype.SelectedValue);
                if (RadioButtonBankOrCash.Checked == true)
                    object1.BankorCash = int.Parse(DropDownList1.SelectedValue);
                object1.Invoice_Id = Int32.Parse(DropDownListInvoice.SelectedValue);
                object1.Collecting_Amount = Convert.ToDouble(TextBoxamount.Text);
                object1.Collecting_WhatsLeft = Convert.ToDouble(TextBoxleft.Text)- Convert.ToDouble(TextBoxamount.Text);

                object1.Operation_Type_Id = Int32.Parse(DropDownListInvoicetype.SelectedValue);
                object1.Rectime = DateTime.Now;
                object1.User_Id = 0;
                object1.Collecting_Rectime = DateTime.Now;
                object1.Log_Date = DateTime.Now;


                DB.Collectings.InsertOnSubmit(object1);
                DB.SubmitChanges();

                var serial = DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListInvoicetype.SelectedValue)).SingleOrDefault();
                serial.Collecting = object1.Collecting_No;

                DB.Invoice_Serial_Collects.DefaultIfEmpty(serial);
                DB.SubmitChanges();

                


            }
            else
            {

                object1 = DB.Collectings.Where(a => a.Collecting_Id.Equals(Labelcollectingid.Text)).SingleOrDefault();


                Labelstatus.Text = "";
                if (DropDownListInvoicetype.SelectedValue == "2")
                {
                    bsclass bs = new bsclass();

                    decimal balance = 0;

                    if (DropDownList1.SelectedValue == "0")
                    {
                        balance = bs.checkblance(true, Convert.ToInt32(DropDownListbankcashtype));
                    }
                    else if (DropDownList1.SelectedValue == "1")
                    {
                        balance = bs.checkblance(false, Convert.ToInt32(DropDownListbankcashtype));
                    }


                    if ((balance + Convert.ToDecimal(object1.Collecting_Amount)) < Convert.ToDecimal((TextBoxamount.Text)))
                    {
                        Labelstatus.Text = "The Currenct Balance Doesn't allow this transaction Current Balance is :" + balance;
                        return;
                    }
                }




                object1.Collecting_Name = TextBoxcollectingname.Text;
                object1.Collecting_Note = TextBoxNote.Text;
                object1.Collecting_Date = Convert.ToDateTime(TextBoxdate.Text);
                object1.IsDisable = false;
                object1.Collecting_Note = Convert.ToString(DropDownListbankcashtype.SelectedValue);

                if (RadioButtonBankOrCash.Checked == true)
                object1.BankorCash = int.Parse(DropDownList1.SelectedValue);
                
                object1.Collecting_Amount = Convert.ToDouble(TextBoxamount.Text);
                object1.Collecting_WhatsLeft = Convert.ToDouble(TextBoxleft.Text) - Convert.ToDouble(TextBoxamount.Text);

                object1.Operation_Type_Id = Int32.Parse(DropDownListInvoicetype.SelectedValue);
                
                object1.User_Id = 0;
                object1.Collecting_Rectime = DateTime.Now;
                object1.Log_Date = DateTime.Now;

                DB.Collectings.DefaultIfEmpty(object1);
                DB.SubmitChanges();



            }
            if (RadioButtonBankOrCash.Checked == true)
            {
                bsclass bs = new bsclass();
                
                if (DropDownList1.SelectedValue == "0")
                {
                    if (DB.Banks.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id)).Count() == 0)
                    {
                        if (DropDownListInvoicetype.SelectedValue == "1")
                            bs.AddBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                        else if (DropDownListInvoicetype.SelectedValue == "2")
                            bs.AddBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                    }
                    else 
                    {
                        if (DropDownListInvoicetype.SelectedValue == "1")
                            bs.editBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                        else if (DropDownListInvoicetype.SelectedValue == "2")
                            bs.editBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, false);

                    }

                }
                else if (DropDownList1.SelectedValue == "1")
                {
                    if (DB.Cashes.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id)).Count() == 0)
                    {
                        if (DropDownListInvoicetype.SelectedValue == "1")
                            bs.Addcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                        else if (DropDownListInvoicetype.SelectedValue == "2")
                            bs.Addcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                    }
                    else
                    {

                        if (DropDownListInvoicetype.SelectedValue == "1")
                            bs.editcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, false);
                        else if (DropDownListInvoicetype.SelectedValue == "2")
                            bs.editcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, false);

                    }
                }
            }
            else if (RadioButtonCheque.Checked ==true)
            {
                var cheque = DB.Cheques.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id));
                if (cheque.Count() ==0)
                {
                    BsolutionWebApp.Cheque object2 = new BsolutionWebApp.Cheque();
                    object2.Cheque_No = Convert.ToString(TextBoxchequeno.Text);
                    object2.Cheque_Bank_Name = TextBoxchequebankname.Text;
                    object2.Cheque_Date = Convert.ToDateTime(TextBoxdate.Text);
                    object2.IsDisable = false;
                    object2.Cheque_Notes = TextBoxNote.Text;
                    object2.Collecting_Id = object1.Collecting_Id;
                    object2.RecTime = DateTime.Now;
                    object2.PersonInCharge = "";
                    object2.Cheque_Notes = "";

                    

                    DB.Cheques.InsertOnSubmit(object2);
                    DB.SubmitChanges();
                }

                else
                {
                    var cheque2 = DB.Cheques.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id)).SingleOrDefault();
                    cheque2.Cheque_No = Convert.ToString(TextBoxchequeno.Text);
                    cheque2.Cheque_Bank_Name = TextBoxchequebankname.Text;
                    cheque2.Cheque_Date = Convert.ToDateTime(TextBoxdate.Text);
                    DB.Cheques.DefaultIfEmpty(cheque2);
                    DB.SubmitChanges();
                }

            }
            Labelcollectingid.Text = "0";
            Response.Redirect("CollectingPageAdd?ID="+Labelinvoiceid.Text);

        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Labelcollectingid.Text = ID;
            var collect = DB.Collectings.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();

            TextBoxCollectingNo.Text =Convert.ToString( collect.Collecting_No);
            TextBoxcollectingname.Text = collect.Collecting_Name;
            TextBoxdate.Text = Convert.ToString(collect.Collecting_Date);
            getinvoicedetials();
            TextBoxamount.Text = Convert.ToString("0");
            TextBoxleft.Text = Convert.ToString(Convert.ToInt32(TextBoxleft.Text)+ collect.Collecting_Amount);

            var cheque = DB.Cheques.Where(a => a.Collecting_Id.Equals(ID));
            if(cheque.Count() >0)
            {
                var cheque2 = cheque.SingleOrDefault();
                TextBoxchequeno.Text =Convert.ToString( cheque2.Cheque_No);
                TextBoxchequebankname.Text = Convert.ToString(cheque2.Cheque_Bank_Name);
                
            }

            if (collect.BankorCash != null && collect.BankorCash != 0)
            {
                DropDownList1.SelectedValue = Convert.ToString(collect.BankorCash);
                ondrop1change();

                if (DropDownList1.SelectedValue == "0")
                {
                    var bank = DB.Banks.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();
                    DropDownListbankcashtype.SelectedValue = Convert.ToString(bank.BankName_ID);
                }
                else if (DropDownList1.SelectedValue == "1")
                {
                    var bank = DB.Cashes.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();
                    DropDownListbankcashtype.SelectedValue = Convert.ToString(bank.CashID);
                }
            }
        }
        
        protected void gridbind()
        {
            GridView1.DataSource =from a in  DB.Collectings.Where(a=>a.Invoice_Id.Equals(Labelinvoiceid.Text))
                                  join i in DB.Invoices on a.Invoice_Id equals i.Invoice_Id
                                  select (new { ID=a.Collecting_Id , InvoiceTotal = i.Invoice_AfterDiscountprice_ATax, InvoiceDate = i.Invoice_Date, ColletingNo = a.Collecting_No, CollectingDate = a.Collecting_Date, Amount = a.Collecting_Amount, Whatsleft = a.Collecting_WhatsLeft, Note = a.Collecting_Note });
                
                //from a in DB.Collectings.Where(i => i.Invoice_Id.Equals(Labelinvoiceid))
                //                  // join i in DB.Invoices on a.Invoice_Id equals i.Invoice_Id
                //                   select (new { InvoiceNo = a.Collecting_Amount });//,InvoiceTotal=i.Invoice_AfterDiscountprice_ATax,InvoiceDate=i.Invoice_Date,ColletingNo=a.Collecting_No,CollectingDate=a.Collecting_Date,Amount=a.Collecting_Amount,Whatsleft=a.Collecting_WhatsLeft,Note=a.Collecting_Note });
            GridView1.DataBind();
        }

        protected void TextBoxleft_TextChanged(object sender, EventArgs e)
        {

        }

        protected void closeinvoice(bool yes)
        {
            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(DropDownListInvoice.SelectedValue)).SingleOrDefault();

            if(yes == true)
            invoice.Invoice_IsDone = 1;
            else
                invoice.Invoice_IsDone = 0;

            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();
        }
    }
}