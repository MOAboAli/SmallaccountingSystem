using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.ExpensesPages
{
    public partial class AddExpenses : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdownlist();
                gridbind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            insertdata();
            gridbind();
        }

        protected void dropdownlist()
        {
            DropDownListExpenseType.DataSource = DB.Expenses_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.Expenses_Type_Id,name=a.Expenses_Type_Name });
            DropDownListExpenseType.DataBind();


            dropdownlistcashbank();
        }

        protected void dropdownlistcashbank()
        {
            if (DropDownListbankcash.SelectedValue == "0")
            {
                DropDownListbankcashtype.DataSource = DB.Bank_Names.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.BankName_Id, name = a.Bank_Name1 });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Bank Names";
            }
            else
            {
                DropDownListbankcashtype.DataSource = DB.Cash_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Cash_Type_Id, name = a.Cash_Type_Name });
                DropDownListbankcashtype.DataBind();
                Labelbankcash.Text = "Cash Types";
            }


        }

        protected void DropDownListbankcash_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownlistcashbank();
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Expenses.Where(a => a.Expenses_Id.Equals(ID)).SingleOrDefault();

            newobject.Expenses_Cost = Convert.ToDouble(TextBoxunitcost.Text);
            newobject.Expenses_Date = Convert.ToDateTime(TextBoxdate.Text);
            newobject.Expenses_PersonInCharge = Convert.ToString(TextBoxfrom.Text);
            newobject.Expenses_Quantity = Convert.ToDouble(TextBoxquantity.Text);
            newobject.Expenses_Total = Convert.ToDouble(TextBoxunitcost.Text) * Convert.ToDouble(TextBoxquantity.Text);
            newobject.Expenses_Type_Id = Convert.ToInt32(DropDownListExpenseType.SelectedValue);
            newobject.Rectime = DateTime.Now;
            newobject.Expenses_Rectime = DateTime.Now;
            newobject.UserId =Convert.ToInt32( Session["userid"]);
            newobject.IsDisable = false;
            newobject.Expenses_From = DateTime.Now;
            newobject.Note = TextBoxNote.Text;

            DB.Expenses.DefaultIfEmpty(newobject);
            DB.SubmitChanges();



        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Expenses_Types.Where(a => a.Expenses_Type_Id.Equals(ID)).SingleOrDefault();
            //objecttable.IsDisable = true;
            //DB.Expenses_Types.DefaultIfEmpty(objecttable);
            //DB.SubmitChanges();
            //databind();
        }

        protected void selectGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Expenses.Where(a => a.Expenses_Id.Equals(ID)).SingleOrDefault();

            TextBoxunitcost.Text= Convert.ToString(newobject.Expenses_Cost );
            TextBoxdate.Text = Convert.ToString(newobject.Expenses_Date );
            TextBoxfrom.Text= Convert.ToString(newobject.Expenses_PersonInCharge );
            TextBoxquantity.Text= Convert.ToString(newobject.Expenses_Quantity );
            TextBoxtotal.Text= Convert.ToString(newobject.Expenses_Total );
            DropDownListExpenseType.SelectedValue = Convert.ToString(newobject.Expenses_Type_Id );
            TextBoxNote.Text = newobject.Note;


        }

        protected void insertdata()
        {
            Labelstatus.Text = "";
            bsclass bs = new bsclass();

            decimal balance = 0;

            if (DropDownListbankcash.SelectedValue == "0")
            {
                balance= bs.checkblance(true, Convert.ToInt32(DropDownListbankcashtype.SelectedValue));
            }
            else if (DropDownListbankcash.SelectedValue == "1")
            {
                balance= bs.checkblance(false, Convert.ToInt32(DropDownListbankcashtype.SelectedValue));
            }

            if (balance >= Convert.ToDecimal(Convert.ToDouble(TextBoxunitcost.Text) * Convert.ToDouble(TextBoxquantity.Text)))
            {

                Expense newobject = new Expense();
                newobject.Expenses_No = Convert.ToInt32(TextBoxExpensesNo.Text);
                newobject.Expenses_Cost = Convert.ToDouble(TextBoxunitcost.Text);
                newobject.Expenses_Date = Convert.ToDateTime(TextBoxdate.Text);
                newobject.Expenses_PersonInCharge = Convert.ToString(TextBoxfrom.Text);
                newobject.Expenses_Quantity = Convert.ToDouble(TextBoxquantity.Text);
                newobject.Expenses_Total = Convert.ToDouble(TextBoxunitcost.Text) * Convert.ToDouble(TextBoxquantity.Text);
                newobject.Expenses_Type_Id = Convert.ToInt32(DropDownListExpenseType.SelectedValue);
                newobject.Rectime = DateTime.Now;
                newobject.Expenses_Rectime = DateTime.Now;
                newobject.UserId =Convert.ToInt32( Session["userid"]);
                newobject.IsDisable = false;
                newobject.Expenses_From = DateTime.Now;
                newobject.Note = TextBoxNote.Text;

                DB.Expenses.InsertOnSubmit(newobject);
                DB.SubmitChanges();



                if (DropDownListbankcash.SelectedValue == "0")
                {
                    bs.AddBank(newobject.Expenses_Id, false, newobject.Expenses_Total, newobject.Expenses_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), newobject.Expenses_PersonInCharge, "-", "", 0, 0, false);

                }
                else if (DropDownListbankcash.SelectedValue == "1")
                {
                    bs.Addcash(newobject.Expenses_Id, false, newobject.Expenses_Total, newobject.Expenses_Date, Convert.ToInt32(DropDownListbankcashtype.SelectedValue), newobject.Expenses_PersonInCharge, "-", "", 0, 0, false);
                }
            }
            else

            {
                Labelstatus.Text = "The Currenct Balance Doesn't allow this transaction Current Balance is :"+balance;
            }
        }

        protected void gridbind()
        {
            GridView1.DataSource = from  a in DB.Expenses.Where(a => a.IsDisable.Equals(false))
                                   join t in DB.Expenses_Types on a.Expenses_Type_Id equals t.Expenses_Type_Id                
                                   select( new {a.Expenses_No,t.Expenses_Type_Name,a.Expenses_Date,a.Expenses_Total,a.Note, ID = a.Expenses_Id });
            GridView1.DataBind();

            if (DB.Expenses.Count() != 0)
                TextBoxExpensesNo.Text = Convert.ToString(Convert.ToInt32(DB.Expenses.Max(a => a.Expenses_No).ToString()) + 1);
            else
                TextBoxExpensesNo.Text = "1";
        }

        protected void btnSumbitcontact_Click(object sender, EventArgs e)
        {
            Expenses_Type newobject = new Expenses_Type();
            newobject.Expenses_Type_Name = Convert.ToString(TextBoxContactName.Text);
        
            newobject.Expenses_Type_Rectime = DateTime.Now;

            newobject.IsDisable = false;
            newobject.Rectime = DateTime.Now;
            newobject.UserId =Convert.ToInt32( Session["userid"]);

            DB.Expenses_Types.InsertOnSubmit(newobject);
            DB.SubmitChanges();

            DropDownListExpenseType.DataSource = DB.Expenses_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Expenses_Type_Id, name = a.Expenses_Type_Name }).OrderByDescending(a=>a.ID);
            DropDownListExpenseType.DataBind();


        }
    }
}