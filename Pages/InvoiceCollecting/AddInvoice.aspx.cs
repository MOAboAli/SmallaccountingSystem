using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class AddInvoice : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string id = Request.QueryString["ID"];
                if (id !="" && id !=null)
                {
                    databind(id);
                    onrefresh();


                }
                else
                {

                }
            }
            onrefresh();
        }


        protected void onrefresh()
        {
            binddata(Labelid.Text);
            databinditem(Labelid.Text);
            databinddiscount(Labelid.Text);
            databindtax(Labelid.Text);
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            insertdata();
            onrefresh();
        }

        protected void insertdata()
        {
            if (Labelid.Text == "0")
            {

                Invoice object1 = new Invoice();

                object1.Invoice_AfterDiscountprice = 0;
                object1.Invoice_AfterDiscountprice_ATax = 0;
                object1.Invoice_Date = Convert.ToDateTime(datepicker.Text);
                //object1.Invoice_IsDone = Convert.ToByte(CheckBoxDone.Checked);
                object1.Invoice_No = Convert.ToInt32(TextBoxInvoiceno.Text);
                object1.Invoice_Note = TextBoxNote.Text;
                object1.Invoice_Price = Convert.ToDouble(0);
                object1.Invoice_Rectime = DateTime.Now;
                object1.Invoice_TotalCost = Convert.ToDouble(0);
                object1.Invoice_Type_Id = Convert.ToInt32(DropDownListinvoicetype.SelectedValue);
                object1.Contact_Id = Convert.ToInt32(DropDownListcontac.SelectedValue);
                object1.IsDisable = false;

                DB.Invoices.InsertOnSubmit(object1);
                DB.SubmitChanges();


                Labelid.Text = Convert.ToString(object1.Invoice_Id);

                bsclass bs = new bsclass();
                if (object1.Invoice_Type_Id == 1)
                    bs.Addtransaction(2,"Invoice+",object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price- object1.Invoice_TotalCost,"");
                else if (object1.Invoice_Type_Id == 2)
                    bs.Addtransaction(4, "Invoice-", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price - object1.Invoice_TotalCost, "");

                var serical = DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault();
                serical.Invoice++;
                DB.Invoice_Serial_Collects.DefaultIfEmpty(serical);
                DB.SubmitChanges();

                Labelstatus.Text = "Invoice No=" + object1.Invoice_No + " -Date of Invoice" + object1.Invoice_Date;
                // Response.Write("<script language=javascript>alert('Done');</script>");

            }
            else
            {
                Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();

                //object1.Invoice_AfterDiscountprice = Convert.ToDouble(TextBoxAfterDiscount.Text);
                //object1.Invoice_AfterDiscountprice_ATax = Convert.ToDouble(TextBoxTax.Text);
                object1.Invoice_Date = Convert.ToDateTime(datepicker.Text);
               // object1.Invoice_IsDone = Convert.ToByte(CheckBoxDone.Checked);
                //object1.Invoice_No = Convert.ToInt32(TextBoxInvoiceno.Text);
                object1.Invoice_Note = TextBoxNote.Text;
                //object1.Invoice_Price = Convert.ToDouble(TextBoxtotalprice.Text);
                object1.Invoice_Rectime = DateTime.Now;
                //object1.Invoice_TotalCost = Convert.ToDouble(TextBoxcost.Text);
                object1.Invoice_Type_Id = Convert.ToInt32(DropDownListinvoicetype.SelectedValue);
                object1.Contact_Id = Convert.ToInt32(DropDownListcontac.SelectedValue);

                DB.Invoices.DefaultIfEmpty(object1);
                DB.SubmitChanges();

                Labelid.Text = "0";

                //bsclass bs = new bsclass();
                //bs.invoicetransaction(Labelid.Text);

                //Response.Redirect("AddInvoice.aspx");

            }


        }

        protected void databind(string id)
        {
            Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(id)).SingleOrDefault();
            //GridView1.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, Name = a.Bank_Name1, a.AccountNo, DateOFOpen = a.DateOfOpen, a.Phone, a.Loation, a.PersonInCharge, a.Phone_PersonInCharge, Note = a.Bank_Name_Notes }); ;
            //GridView1.DataBind();


            DropDownListinvoicetype.DataSource = DB.Invoice_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Invoice_T_Id, name = a.Invoice_T_Name });
            DropDownListinvoicetype.DataBind();

            DropDownListinvoicetype.SelectedValue =Convert.ToString( object1.Invoice_Type_Id);

            DropDownListcontacttype2.DataSource = DB.Contat_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new {  a.Contat_T_Id,  a.Contat_T_Name });
            DropDownListcontacttype2.DataBind();

            if (DropDownListinvoicetype.SelectedValue == "1")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(3)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                DropDownListcontac.DataBind();

                DropDownListcontacttype2.SelectedValue = "3";
            }
            else if (DropDownListinvoicetype.SelectedValue == "2")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(1)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                DropDownListcontac.DataBind();

                DropDownListcontacttype2.SelectedValue = "1";
            }


            TextBoxInvoiceno.Text =Convert.ToString( Convert.ToInt32( DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault().Invoice)+1);

            datepicker.Text =Convert.ToString( DateTime.Now);

            DropDownListItem.DataSource = DB.Items.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Items_Id, Name = a.Items_Name });
            DropDownListItem.DataBind();

            DropDownListtax.DataSource = DB.Taxes.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Tax_Id, name = a.Tax_Name });
            DropDownListtax.DataBind();

            


            Labelid.Text = Convert.ToString(id);

            TextBoxAfterDiscount.Text = Convert.ToString(object1.Invoice_AfterDiscountprice);
            TextBoxTax.Text = Convert.ToString(object1.Invoice_AfterDiscountprice_ATax);
            datepicker.Text = Convert.ToString(object1.Invoice_Date);
            //CheckBoxDone.Checked = Convert.ToBoolean(object1.Invoice_IsDone);
            TextBoxInvoiceno.Text = Convert.ToString(object1.Invoice_No);
            TextBoxNote.Text = object1.Invoice_Note;
            TextBoxtotalprice.Text = Convert.ToString(object1.Invoice_Price);
            TextBoxcost.Text = Convert.ToString(object1.Invoice_TotalCost);
            //DropDownListinvoicetype.SelectedValue = Convert.ToString(object1.Invoice_Type_Id);
            DropDownListcontac.SelectedValue = Convert.ToString(object1.Contact_Id);


            Labelstatus.Text = "Invoice No=" + object1.Invoice_No + " -Date of Invoice" + object1.Invoice_Date;

            TextBoxtaxpercentage0.Text = Convert.ToString(DB.Taxes.Where(a => a.Tax_Id.Equals(DropDownListtax.SelectedValue)).SingleOrDefault().Tax_Percentage);


            DropDownListitem0.DataSource = DB.Item_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.Item_Type1,name=a.Item_Type_Name });
            DropDownListitem0.DataBind();

           
        }

        protected void DropDownListinvoicetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxInvoiceno.Text = Convert.ToString(Convert.ToInt32(DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault().Invoice) + 1);


        }

        protected void SuccessInvoicedetials_Click(object sender, EventArgs e)
        {
            if (Labelid.Text != "0")
            {
                Response.Redirect("InvoiceDetials.aspx?ID=" + Labelid.Text);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Must choose invoice ');</script>");
            }
        }

        protected void Successbtndiscount_Click(object sender, EventArgs e)
        {
            if (Labelid.Text != "0")
            {
                Response.Redirect("DiscountInvoice.aspx?ID=" + Labelid.Text);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Must choose invoice ');</script>");
            }
        }

        protected void Successbtntax_Click(object sender, EventArgs e)
        {
            if (Labelid.Text != "0")
            {
                Response.Redirect("TaxInvoice.aspx?ID=" + Labelid.Text);
            }
            else
            {
                Response.Write("<script language=javascript>alert('Must choose invoice ');</script>");
            }
        }

        protected void binddata(string id)
        {

            Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(id)).SingleOrDefault();
            

         

            TextBoxAfterDiscount.Text = Convert.ToString(object1.Invoice_AfterDiscountprice);
            TextBoxTax.Text = Convert.ToString(object1.Invoice_AfterDiscountprice_ATax);
           
           
            TextBoxtotalprice.Text = Convert.ToString(object1.Invoice_Price);
            TextBoxcost.Text = Convert.ToString(object1.Invoice_TotalCost);
           



        }

        protected void TextBoxquentity_TextChanged(object sender, EventArgs e)
        {

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


        /// <summary>
        ///  items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Successbtnitem_Click(object sender, EventArgs e)
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

            onrefresh();
        }

        protected void databinditem(string id)
        {
            GridViewitem.DataSource = from a in DB.Invoice_Details.Where(a => a.IsDisable.Equals(false) && a.Invoice_Id.Equals(id))
                                   join b in DB.Items on a.Item_ID equals b.Items_Id
                                   select (new { ID = a.Invoice_Details_Id, Name = b.Items_Name, DateOfRec = a.Rectime, a.Quantity, a.Total_Cost, a.Total_Price }); ;
            GridViewitem.DataBind();
        }

      
        protected void add()
        {
            Invoice_Detail detials = new Invoice_Detail();
            detials.Item_ID = Convert.ToInt32(DropDownListItem.SelectedValue);
            detials.Invoice_Id = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;
            detials.Quantity = Convert.ToInt32(TextBoxquentity.Text);
            detials.Rectime = DateTime.Now;
            detials.Unit_Cost = Convert.ToDouble(textboxunticost.Text);
            detials.After_Disount_Price = Convert.ToDouble(TextBoxunitprice.Text);
            detials.Total_Cost = Convert.ToDouble(textboxunticost.Text) * Convert.ToInt32(TextBoxquentity.Text);
            detials.Total_Price = Convert.ToDouble(TextBoxunitprice.Text) * Convert.ToInt32(TextBoxquentity.Text);

            DB.Invoice_Details.InsertOnSubmit(detials);
            DB.SubmitChanges();

            var invoice = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();
            invoice.Invoice_TotalCost = invoice.Invoice_TotalCost + detials.Total_Cost;
            invoice.Invoice_Price = invoice.Invoice_Price + detials.Total_Price;
            invoice.totalPrice = invoice.totalPrice + Convert.ToDecimal(detials.Total_Price);

            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();

           
            editinvoicemoney(Labelid.Text);


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

            if(invoice.Invoice_TotalCost < 0)
            {
                invoice.Invoice_TotalCost = 0;
            }
            if (invoice.Invoice_Price < 0)
            {
                invoice.Invoice_Price = 0;
            }

            DB.Invoices.DefaultIfEmpty(invoice);
            DB.SubmitChanges();

            editinvoicemoney(Labelid.Text);


            onrefresh();
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
            if (item.HasStock == 1)
            {

                var newstock = DB.Stocks.Where(a => a.Item_Id.Equals(item.Items_Id)).SingleOrDefault();
                TextBoxquentity.Text = Convert.ToString(newstock.Stock_Quantity);
            }

        }





        /// <summary>
        /// Discount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void SuccessbtnDiscount_Click(object sender, EventArgs e)
        {
            add2();
            onrefresh();
        }

        protected void databinddiscount(string id)
        {
            GridViewDiscount.DataSource = DB.DiscountInvoice2s.Where(a => a.IsDisable.Equals(false) && a.Invoice_Id.Equals(id)).Select(a => new { ID = a.DiscountInvoice_Id, Amount = a.DiscountInvoice_Amount, Date = a.DiscountInvoice_RecTime, a.DiscountInvoice_Percentage, a.IsFromCollecting, a.DiscountInvoice_Notes }); ;
            GridViewDiscount.DataBind();
        }

        protected void dropdownlist2()
        {

        }

        protected void add2()
        {
            DiscountInvoice2 detials = new DiscountInvoice2();

            detials.DiscountInvoice_Amount = Convert.ToDouble(TextBoxdamountdis.Text);
            detials.DiscountInvoice_Date = Convert.ToDateTime(datepicker.Text);
            detials.DiscountInvoice_Notes = TextBoxNote0.Text;
            detials.DiscountInvoice_Percentage = Convert.ToDouble(TextBoxdpercentagedis.Text);
            detials.DiscountInvoice_RecTime = DateTime.Now;
            detials.Invoice_Id = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;
            detials.IsFromCollecting = 0;
            detials.Rectime = DateTime.Now;

            DB.DiscountInvoice2s.InsertOnSubmit(detials);
            DB.SubmitChanges();


            editinvoicemoney(Labelid.Text);
           
        }



       

        protected void DeleteGrid2_Click(object sender, EventArgs e)
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
            onrefresh();

        }



        ///Tax

        protected void Successbtntax2_Click(object sender, EventArgs e)
        {
            add3();
            onrefresh();
        }

        protected void databindtax(string id)
        {
            GridViewtax.DataSource = DB.InvoiceTaxes.Where(a => a.IsDisable.Equals(false) && a.Invoice_ID.Equals(id)).Select(a => new { ID = a.InvoiceTax_Id, Amount = a.InvoiceTax_Amount, Date = a.InvoiceTax_RecTime, a.InvoiceTax_Percentage }); ;
            GridViewtax.DataBind();
        }

       

        protected void add3()
        {
            InvoiceTax detials = new InvoiceTax();

            detials.InvoiceTax_Amount = Convert.ToDouble(TextBoxdamounttax.Text);
            detials.InvoiceTax_Percentage = Convert.ToDouble(TextBoxtaxpercentage0.Text);
            detials.InvoiceTax_RecTime = DateTime.Now;

            detials.Tax_Id = Convert.ToInt32(DropDownListtax.SelectedValue);

            detials.Invoice_ID = Convert.ToInt32(Labelid.Text);
            detials.IsDisable = false;

            detials.Rectime = DateTime.Now;

            DB.InvoiceTaxes.InsertOnSubmit(detials);
            DB.SubmitChanges();


            editinvoicemoney(Labelid.Text);
            onrefresh();

        }



        

        protected void DeleteGrid3_Click(object sender, EventArgs e)
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

            onrefresh();

        }

        protected void DropDownListtax2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxtaxpercentage0.Text = Convert.ToString(DB.Taxes.Where(a => a.Tax_Id.Equals(DropDownListtax.SelectedValue)).SingleOrDefault().Tax_Percentage);
        }

        protected void SuccessbtntaxDone_Click(object sender, EventArgs e)
        {
            Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();

            //object1.Invoice_AfterDiscountprice = Convert.ToDouble(TextBoxAfterDiscount.Text);
            //object1.Invoice_AfterDiscountprice_ATax = Convert.ToDouble(TextBoxTax.Text);
            object1.Invoice_Date = Convert.ToDateTime(datepicker.Text);
            // object1.Invoice_IsDone = Convert.ToByte(CheckBoxDone.Checked);
            //object1.Invoice_No = Convert.ToInt32(TextBoxInvoiceno.Text);
            object1.Invoice_Note = TextBoxNote.Text+ " Edit On Date:"+ DateTime.Now +" ,";
            //object1.Invoice_Price = Convert.ToDouble(TextBoxtotalprice.Text);
            
            //object1.Invoice_TotalCost = Convert.ToDouble(TextBoxcost.Text);
            
            object1.Contact_Id = Convert.ToInt32(DropDownListcontac.SelectedValue);

            DB.Invoices.DefaultIfEmpty(object1);
            DB.SubmitChanges();
            Response.Redirect("InvoiceSearch.aspx");
        }

        protected void Collecting_Click(object sender, EventArgs e)
        {
            Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(Labelid.Text)).SingleOrDefault();

            //object1.Invoice_AfterDiscountprice = Convert.ToDouble(TextBoxAfterDiscount.Text);
            //object1.Invoice_AfterDiscountprice_ATax = Convert.ToDouble(TextBoxTax.Text);
            object1.Invoice_Date = Convert.ToDateTime(datepicker.Text);
            // object1.Invoice_IsDone = Convert.ToByte(CheckBoxDone.Checked);
            //object1.Invoice_No = Convert.ToInt32(TextBoxInvoiceno.Text);
            object1.Invoice_Note = TextBoxNote.Text + " Edit On Date:" + DateTime.Now + " ,";
            //object1.Invoice_Price = Convert.ToDouble(TextBoxtotalprice.Text);

            //object1.Invoice_TotalCost = Convert.ToDouble(TextBoxcost.Text);

            object1.Contact_Id = Convert.ToInt32(DropDownListcontac.SelectedValue);

            DB.Invoices.DefaultIfEmpty(object1);
            DB.SubmitChanges();

            Response.Redirect("~/Pages/Collecting/CollectingPageAdd.aspx?ID=" + Labelid.Text);


        }

        protected void btnSumbitcontact_Click(object sender, EventArgs e)
        {
            Contact2 newobject = new Contact2();
            newobject.Client_Type = Convert.ToInt32(DropDownListcontacttype2.SelectedValue);
            newobject.Contact_Location = TextBoxlocation.Text;
            
            newobject.Contact_Mobile = TextBoxmobile.Text;
            
            newobject.Contact_Name = TextBoxContactName.Text;
            newobject.Contact_Note = "Add From invoice page";
            newobject.Contact_Phone = "00000";
            newobject.Contact_Rectime = DateTime.Now;
           
            newobject.IsDisable = false;
            newobject.Rectime = DateTime.Now;
            newobject.UserID =Convert.ToInt32( Session["userid"]);

            DB.Contact2s.InsertOnSubmit(newobject);
            DB.SubmitChanges();

            if (DropDownListinvoicetype.SelectedValue == "1")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(3)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name }).OrderByDescending(a=>a.ID);
                DropDownListcontac.DataBind();

              
            }
            else if (DropDownListinvoicetype.SelectedValue == "2")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(1)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name }).OrderByDescending(a => a.ID); ;
                DropDownListcontac.DataBind();

                
            }

        }

        protected void btnSumbititem_Click(object sender, EventArgs e)
        {


            Item newobject = new Item();

            newobject.RecTime = DateTime.Now;

            newobject.User_Id = 0;
            newobject.IsDisable = false;
            newobject.AverageCost = Convert.ToDouble(TextBoxcost0.Text);
            newobject.HasStock = Convert.ToInt32(CheckBoxhasstock.Checked);
            newobject.Items_Name = TextBoxName.Text;
            newobject.Items_Notes = "ADD by invoice page";
            newobject.Items_Price = Convert.ToDouble(textboxprice.Text);
            newobject.Type_Id = Convert.ToInt32(DropDownListitem0.SelectedValue);


            DB.Items.InsertOnSubmit(newobject);
            DB.SubmitChanges();

            if (CheckBoxhasstock.Checked == true)
            {
                Stock newstock = new Stock();
                newstock.Item_Id = newobject.Items_Id;
                newstock.IsDisable = false;
                if (TextBoxquantity.Text != "")
                    newstock.Stock_Quantity = Convert.ToInt32(TextBoxquantity.Text);
                else
                    newstock.Stock_Quantity = 0;

                newstock.LastModifyDate = DateTime.Now;
                newstock.Last_UserId = 0;

                DB.Stocks.InsertOnSubmit(newstock);
                DB.SubmitChanges();
            }


            DropDownListItem.DataSource = DB.Items.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Items_Id, Name = a.Items_Name }).OrderByDescending(a=>a.ID);
            DropDownListItem.DataBind();

            changedrop();
        }

        protected void SuccessbtPrintDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/InvoiceCollecting/PrintInvoice.aspx?ID=" + Labelid.Text);
        }
    }
}