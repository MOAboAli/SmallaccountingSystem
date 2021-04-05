using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Cash
{
    public partial class Cash : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void ddExpensesOrCollecting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddExpensesOrCollecting.SelectedValue == "0")
            {
                ddCollectingExpenses.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Collecting_Id, name = a.Collecting_Name });
                ddCollectingExpenses.DataBind();
                lblCollectingExpenses.Text = "Collecting Names";
            }
            else
            {
                ddCollectingExpenses.DataSource = DB.Expenses.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Expenses_Id, name = a.Expenses_No });
                ddCollectingExpenses.DataBind();
                lblCollectingExpenses.Text = "Expenses Types";
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            insertdata();
            cleartools();
        }
        protected void insertdata()
        {
            BsolutionWebApp.Cash object1 = new BsolutionWebApp.Cash();

            object1.Cash_Amount = float.Parse(txtCashAmount.Text);
            object1.PersonInCharge = TextPersonInCharge.Text;
            object1.Operation_Type = int.Parse(ddOperationType.SelectedValue);
            object1.Cash_Date = Convert.ToDateTime(datepicker.Text);
            if (ddExpensesOrCollecting.SelectedValue == "0")
            {
                object1.Collecting_Id = int.Parse(ddCollectingExpenses.SelectedValue);
                object1.Expenses_Id = null;
            }
            else
            {
                object1.Expenses_Id = int.Parse(ddCollectingExpenses.SelectedValue);
                object1.Collecting_Id = null;
            }
            object1.IsDisable = false;
            object1.PersonInCharge = TextPersonInCharge.Text;
            object1.Rectime = DateTime.Now;
            object1.UserId =Convert.ToInt32( Session["userid"]);
            DB.Cashes.DefaultIfEmpty(object1);
            DB.SubmitChanges();
        }
        protected void cleartools()
        {
            txtCashAmount.Text = "";
            TextPersonInCharge.Text = "";
            TextBoxNote.Text = "";
        }
        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var object1 = DB.Cashes.Where(a => a.Cash_Id.Equals(ID)).SingleOrDefault();
            object1.Cash_Amount = float.Parse(txtCashAmount.Text);
            object1.PersonInCharge = TextPersonInCharge.Text;
            object1.Operation_Type = int.Parse(ddOperationType.SelectedValue);
            object1.Cash_Date = Convert.ToDateTime(datepicker.Text);
            if (ddExpensesOrCollecting.SelectedValue=="0")
            {
                object1.Collecting_Id = int.Parse(ddCollectingExpenses.SelectedValue);
                object1.Expenses_Id = null;
            }
            else
            {
                object1.Expenses_Id = int.Parse(ddCollectingExpenses.SelectedValue);
                object1.Collecting_Id = null;
            }
            object1.IsDisable = false;
            object1.PersonInCharge = TextPersonInCharge.Text;
            object1.Rectime = DateTime.Now;
            object1.UserId =Convert.ToInt32( Session["userid"]);
            DB.Cashes.DefaultIfEmpty(object1);
            DB.SubmitChanges();
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var objecttable = DB.Cashes.Where(a => a.Cash_Id.Equals(ID)).SingleOrDefault();
            objecttable.IsDisable = true;
            DB.Cashes.DefaultIfEmpty(objecttable);
            DB.SubmitChanges();
            databind();
        }
        protected void databind()
        {
            GridView1.DataSource = DB.Cashes.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.CashID, Name = a.Cash_Amount, a.PersonInCharge, DateOFOpen = a.Cash_Date, a.Cash_Notes }); ;
            GridView1.DataBind();
        }
    }
}