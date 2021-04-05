using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.InvoiceCollecting
{
    public partial class InvoiceSearch : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListinvoicetype.DataSource = DB.Invoice_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Invoice_T_Id, name = a.Invoice_T_Name });
                DropDownListinvoicetype.DataBind();

                if (DropDownListinvoicetype.SelectedValue == "1")
                {
                    DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(1)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                    DropDownListcontac.DataBind();

                    DropDownListcontacttype2.SelectedValue = "1";
                }
                else if (DropDownListinvoicetype.SelectedValue == "2")
                {
                    DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(3)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                    DropDownListcontac.DataBind();

                    DropDownListcontacttype2.SelectedValue = "3";
                }

                DropDownListItem.DataSource = DB.Items.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Items_Id, Name = a.Items_Name });
                DropDownListItem.DataBind();

                
                DropDownListItem.Items.Insert(0, new ListItem("Choose", "0"));
                DropDownListcontac.Items.Insert(0, new ListItem("Choose", "0"));

                DropDownListcontacttype2.DataSource = DB.Contat_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new { a.Contat_T_Id, a.Contat_T_Name });
                DropDownListcontacttype2.DataBind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
               
                databind();
               
          
        }
        
        protected void databind()
        {
            Labelstatus.Text = "";

            if (DropDownListcontac.SelectedValue !="0" && datepicker.Text == "")
            {
                GridView1.DataSource =from a in  DB.Invoices.Where(a => a.IsDisable.Equals(false)&& a.Invoice_Type_Id.Equals(DropDownListinvoicetype.SelectedValue) && a.Contact_Id.Equals(DropDownListcontac.SelectedValue))
                                      join c in DB.Contact2s on a.Contact_Id equals c.Contact_Id
                                      join t in DB.Invoice_Ts on a.Invoice_Type_Id equals t.Invoice_T_Id
                                      select ( new { Contact = c.Contact_Name, Date = a.Invoice_Date, Invoicetype = t.Invoice_T_Name, TotalInvoice = a.Invoice_AfterDiscountprice_ATax,Opened=a.Invoice_IsDone, ID = a.Invoice_Id }); 
                GridView1.DataBind();

            }
            else if (DropDownListcontac.SelectedValue == "0" && datepicker.Text != "" )
            {
                GridView1.DataSource = from a in DB.Invoices.Where(a => a.IsDisable.Equals(false) && a.Invoice_Date > Convert.ToDateTime(datepicker.Text).AddDays(-1) && a.Invoice_Date < Convert.ToDateTime(datepicker.Text).AddDays(1))
                                       join c in DB.Contact2s on a.Contact_Id equals c.Contact_Id
                                       join t in DB.Invoice_Ts on a.Invoice_Type_Id equals t.Invoice_T_Id
                                       select (new { Contact = c.Contact_Name, Date = a.Invoice_Date, Invoicetype = t.Invoice_T_Name, TotalInvoice = a.Invoice_AfterDiscountprice_ATax, Opened = a.Invoice_IsDone, ID = a.Invoice_Id });

                GridView1.DataBind();

            }
            else if(DropDownListcontac.SelectedValue != "0" && datepicker.Text != "")
            {
                GridView1.DataSource = from a in DB.Invoices.Where(a => a.IsDisable.Equals(false) && a.Invoice_Type_Id.Equals(DropDownListinvoicetype.SelectedValue) && a.Invoice_Date > Convert.ToDateTime(datepicker.Text).AddDays(-1) && a.Invoice_Date < Convert.ToDateTime(datepicker.Text).AddDays(1) && a.Contact_Id.Equals(DropDownListcontac.SelectedValue))
                                       join c in DB.Contact2s on a.Contact_Id equals c.Contact_Id
                                       join t in DB.Invoice_Ts on a.Invoice_Type_Id equals t.Invoice_T_Id
                                       select (new { Contact = c.Contact_Name, Date = a.Invoice_Date, Invoicetype = t.Invoice_T_Name, TotalInvoice = a.Invoice_AfterDiscountprice_ATax, Opened = a.Invoice_IsDone, ID = a.Invoice_Id });

                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = from a in DB.Invoices.Where(a => a.IsDisable.Equals(false) && a.Invoice_Type_Id.Equals(DropDownListinvoicetype.SelectedValue))
                                       join c in DB.Contact2s on a.Contact_Id equals c.Contact_Id
                                       join t in DB.Invoice_Ts on a.Invoice_Type_Id equals t.Invoice_T_Id
                                       select (new { Contact = c.Contact_Name, Date = a.Invoice_Date, Invoicetype = t.Invoice_T_Name, TotalInvoice = a.Invoice_AfterDiscountprice_ATax, Opened = a.Invoice_IsDone, ID = a.Invoice_Id });



                GridView1.DataBind();
            }
        }

        

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Response.Redirect("AddInvoice.aspx?ID="+ID);

        }


        protected void Collecting_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Response.Redirect("~/Pages/Collecting/CollectingPageAdd.aspx?ID=" + ID);

        }

        protected void DropDownListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Labelstatus.Text = "";
            if (DropDownListItem.SelectedValue != "0")
            {
                GridView1.DataSource = from a in DB.Invoices.Where(a => a.IsDisable.Equals(false))
                                       join d in DB.Invoice_Details.Where(d => d.Item_ID.Equals(DropDownListItem.SelectedValue)) on a.Invoice_Id equals d.Invoice_Id
                                       join c in DB.Contact2s on a.Contact_Id equals c.Contact_Id
                                       join t in DB.Invoice_Ts on a.Invoice_Type_Id equals t.Invoice_T_Id
                                       select (new {  Contact =c.Contact_Name, Date = a.Invoice_Date,Invoicetype=t.Invoice_T_Name, TotalInvoice = a.Invoice_AfterDiscountprice_ATax, Opened = a.Invoice_IsDone, ID = a.Invoice_Id });
                GridView1.DataBind();
            }
        }

        protected void Successbtnadd_Click(object sender, EventArgs e)
        {
            Labelstatus.Text = "";
            if (DropDownListcontac.SelectedValue != "0")
            {

                Invoice object1 = new Invoice();

                object1.Invoice_AfterDiscountprice = 0;
                object1.Invoice_AfterDiscountprice_ATax = 0;
                object1.Invoice_Date = Convert.ToDateTime(datepicker.Text);
                //object1.Invoice_IsDone = Convert.ToByte(CheckBoxDone.Checked);
                object1.Invoice_No = Convert.ToInt32(Convert.ToString(Convert.ToInt32(DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault().Invoice) + 1));

                object1.Invoice_Price = Convert.ToDouble(0);
                object1.Invoice_Rectime = DateTime.Now;
                object1.Invoice_TotalCost = Convert.ToDouble(0);
                object1.Invoice_Type_Id = Convert.ToInt32(DropDownListinvoicetype.SelectedValue);
                object1.Contact_Id = Convert.ToInt32(DropDownListcontac.SelectedValue);
                object1.IsDisable = false;

                DB.Invoices.InsertOnSubmit(object1);
                DB.SubmitChanges();




                bsclass bs = new bsclass();
                //if (object1.Invoice_Type_Id == 1)
                //    bs.Addtransaction(2, "Invoice+", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price - object1.Invoice_TotalCost, "");
                //else if (object1.Invoice_Type_Id == 2)
                //    bs.Addtransaction(4, "Invoice-", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_Price, object1.Invoice_Price - object1.Invoice_TotalCost, "");

                bs.invoicetransaction(Convert.ToString( object1.Invoice_Id));



                var serical = DB.Invoice_Serial_Collects.Where(a => a.Invoice_Serial_Collect_Collecting.Equals(DropDownListinvoicetype.SelectedValue)).SingleOrDefault();
                serical.Invoice++;
                DB.Invoice_Serial_Collects.DefaultIfEmpty(serical);
                DB.SubmitChanges();

                Response.Redirect("AddInvoice.aspx?ID=" + object1.Invoice_Id);
            }
            else
            {

                Labelstatus.Text = "Please Choose A Contact ";
            }
        }

        protected void DropDownListinvoicetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListinvoicetype.SelectedValue == "1")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(1)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                DropDownListcontac.DataBind();

                DropDownListcontac.Items.Insert(0, new ListItem("Choose", "0"));
            }
            else if (DropDownListinvoicetype.SelectedValue == "2")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(3)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name });
                DropDownListcontac.DataBind();

                DropDownListcontac.Items.Insert(0, new ListItem("Choose", "0"));
            }
        }


        protected void Print_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Response.Redirect("~/Pages/InvoiceCollecting/PrintInvoice.aspx?ID=" + ID);
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
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(1)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name }).OrderByDescending(a => a.ID);
                DropDownListcontac.DataBind();


            }
            else if (DropDownListinvoicetype.SelectedValue == "2")
            {
                DropDownListcontac.DataSource = DB.Contact2s.Where(a => a.IsDisable.Equals(false) && a.Client_Type.Equals(3)).Select(a => new { ID = a.Contact_Id, name = a.Contact_Name }).OrderByDescending(a => a.ID); ;
                DropDownListcontac.DataBind();


            }

        }


    }
}