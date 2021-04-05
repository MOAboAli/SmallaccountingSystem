using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Collecting
{
    public partial class CollectingSearch : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            databind();
        }
        protected void databind()
        {


            if (TxtCollecting_No.Text != "" && datepicker.Text == "")
            {
                GridView1.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false) && a.Collecting_No.Equals(TxtCollecting_No.Text)).Select(a => new { ID = a.Collecting_Id, Collecting_No = a.Collecting_No, Date = a.Collecting_Date, a.Rectime });
                GridView1.DataBind();

            }
            else if (TxtCollecting_No.Text == "" && datepicker.Text != "")
            {
                GridView1.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false) && a.Collecting_No.Equals(datepicker.Text)).Select(a => new { ID = a.Collecting_Id, Collecting_No = a.Collecting_No, Date = a.Collecting_Date, a.Rectime });
                GridView1.DataBind();

            }
            else if (TxtCollecting_No.Text != "" && datepicker.Text != "")
            {
                GridView1.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false) && a.Collecting_No.Equals(TxtCollecting_No.Text) && a.Collecting_Date.Equals(datepicker.Text)).Select(a => new { ID = a.Collecting_Id, Collecting_No = a.Collecting_No, Date = a.Collecting_Date, a.Rectime });
                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = DB.Collectings.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Collecting_Id, Collecting_No = a.Collecting_No, Date = a.Collecting_Date, a.Rectime }).OrderBy(a => a.Date);
                GridView1.DataBind();
            }
        }



        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();

            Response.Redirect("Collecting.aspx?ID=" + ID);

        }
    }
}