using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Collecting
{
    public partial class SharedAccount : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                {
                   
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



            DropDownListcontact.DataSource = DB.Contact2s.Where(a=>a.Client_Type.Equals(5)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
            DropDownListcontact.DataBind();

            //DropDownListtype.DataSource = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(DB.Invoices.Where(b => b.Invoice_Id.Equals(Labelinvoiceid.Text)).SingleOrDefault().Invoice_Type_Id)).Select(a => new { ID = a.Invoice_T_Id, name = a.Invoice_T_Name });
            //DropDownListtype.DataBind();


            TextBoxCollectingNo.Text = Convert.ToString(DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(3)).SingleOrDefault().Collecting + 1);

          

            ondrop1change();
        }

        protected void DropDownListInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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
                DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, name = a.Bank_Name1 });
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
                if (DropDownListtype.SelectedValue == "2")
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

                    object1.BankorCash = int.Parse(DropDownList1.SelectedValue);
                    object1.Contact_Id = Int32.Parse(DropDownListcontact.SelectedValue);
                    object1.Collecting_Amount = Convert.ToDouble(TextBoxamount.Text);
                    // object1.Collecting_WhatsLeft = Convert.ToDouble(TextBoxleft.Text) - Convert.ToDouble(TextBoxamount.Text);

                    object1.Operation_Type_Id = Int32.Parse(DropDownListtype.SelectedValue);
                    object1.Rectime = DateTime.Now;
                    object1.User_Id = 0;
                    object1.Collecting_Rectime = DateTime.Now;
                    object1.Log_Date = DateTime.Now;


                    DB.Collectings.InsertOnSubmit(object1);
                    DB.SubmitChanges();

                    var serial = DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(3)).SingleOrDefault();
                    serial.Collecting = object1.Collecting_No;

                    DB.Invoice_Serial_Collects.DefaultIfEmpty(serial);
                    DB.SubmitChanges();
                }
                else
                {


                object1 = DB.Collectings.Where(a => a.Collecting_Id.Equals(Labelcollectingid.Text)).SingleOrDefault();


                Labelstatus.Text = "";
                if (DropDownListtype.SelectedValue == "2")
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


                    if ((balance+ Convert.ToDecimal( object1.Collecting_Amount)) < Convert.ToDecimal((TextBoxamount.Text)))
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


                    object1.BankorCash = int.Parse(DropDownList1.SelectedValue);

                    object1.Collecting_Amount = Convert.ToDouble(TextBoxamount.Text);
                    // object1.Collecting_WhatsLeft = Convert.ToDouble(TextBoxleft.Text) - Convert.ToDouble(TextBoxamount.Text);

                    object1.Operation_Type_Id = Int32.Parse(DropDownListtype.SelectedValue);

                    object1.User_Id = 0;
                    object1.Collecting_Rectime = DateTime.Now;
                    object1.Log_Date = DateTime.Now;

                    DB.Collectings.DefaultIfEmpty(object1);
                    DB.SubmitChanges();



                }

                {
                    bsclass bs = new bsclass();

                    if (DropDownList1.SelectedValue == "0")
                    {
                        if (DB.Banks.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id)).Count() == 0)
                        {
                            if (DropDownListtype.SelectedValue == "1")
                                bs.AddBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                            else if (DropDownListtype.SelectedValue == "2")
                                bs.AddBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                        }
                        else
                        {
                            if (DropDownListtype.SelectedValue == "1")
                                bs.editBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                            else if (DropDownListtype.SelectedValue == "2")
                                bs.editBank(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, true);

                        }

                    }
                    else if (DropDownList1.SelectedValue == "1")
                    {
                        if (DB.Cashes.Where(a => a.Collecting_Id.Equals(object1.Collecting_Id)).Count() == 0)
                        {
                            if (DropDownListtype.SelectedValue == "1")
                                bs.Addcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                            else if (DropDownListtype.SelectedValue == "2")
                                bs.Addcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                        }
                        else
                        {

                            if (DropDownListtype.SelectedValue == "1")
                                bs.editcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "+", TextBoxNote.Text, object1.Collecting_Amount, 0, true);
                            else if (DropDownListtype.SelectedValue == "2")
                                bs.editcash(object1.Collecting_Id, true, object1.Collecting_Amount, object1.Collecting_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), "", "-", TextBoxNote.Text, object1.Collecting_Amount, 0, true);

                        }
                    }
                }


                Labelcollectingid.Text = "0";
                Response.Redirect("SharedAccount.aspx");

            }
        

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Labelcollectingid.Text = ID;
            var collect = DB.Collectings.Where(a => a.Collecting_Id.Equals(ID)).SingleOrDefault();

            TextBoxCollectingNo.Text = Convert.ToString(collect.Collecting_No);
            TextBoxcollectingname.Text = collect.Collecting_Name;
            TextBoxdate.Text = Convert.ToString(collect.Collecting_Date);
           
            TextBoxamount.Text = Convert.ToString("0");
           
           

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
            GridView1.DataSource =from a in   DB.Collectings.Where(a => a.Contact_Id != null || a.Contact_Id !=0 )
                                  join i in  DB.Contact2s on a.Contact_Id equals i.Contact_Id
                                  select ( new { ID = a.Collecting_Id,i.Contact_Name,  ColletingNo = a.Collecting_No, CollectingDate = a.Collecting_Date, Amount = a.Collecting_Amount, Note = a.Collecting_Note });

            //from a in DB.Collectings.Where(i => i.Invoice_Id.Equals(Labelinvoiceid))
            //                  // join i in DB.Invoices on a.Invoice_Id equals i.Invoice_Id
            //                   select (new { InvoiceNo = a.Collecting_Amount });//,InvoiceTotal=i.Invoice_AfterDiscountprice_ATax,InvoiceDate=i.Invoice_Date,ColletingNo=a.Collecting_No,CollectingDate=a.Collecting_Date,Amount=a.Collecting_Amount,Whatsleft=a.Collecting_WhatsLeft,Note=a.Collecting_Note });
            GridView1.DataBind();
        }

        protected void RadioButtonCheque_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}