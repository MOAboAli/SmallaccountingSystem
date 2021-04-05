using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class TaxType : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                gridbind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            add();
            gridbind();
        }

        protected void add()
        {
            Tax newobject = new Tax();
            newobject.Tax_Name = TextBoxTaxType.Text;
            newobject.Tax_Percentage =Convert.ToDouble( TextBoxPercentage.Text) ;
            newobject.Tax_Notes = TextBoxNote.Text;
            newobject.IsDisable2 = false;
            newobject.Rectime = DateTime.Now;
            newobject.UserId =Convert.ToInt32( Session["userid"]);
            newobject.Tax_RecTime = DateTime.Now;

            DB.Taxes.InsertOnSubmit(newobject);
            DB.SubmitChanges();


        }


        protected void gridbind()
        {
            GridView1.DataSource = DB.Taxes.Where(a => a.IsDisable2.Equals(false)).Select(a => new { ID = a.Tax_Id, Name = a.Tax_Name, a.Tax_Percentage, Note = a.Tax_Notes }); ;
            GridView1.DataBind();
        }

        protected void SelectGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Taxes.Where(a => a.Tax_Id.Equals(ID)).SingleOrDefault();



            TextBoxTaxType.Text = newobject.Tax_Name;
            TextBoxPercentage.Text = Convert.ToString(newobject.Tax_Percentage);
            TextBoxNote.Text = newobject.Tax_Notes;




        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Taxes.Where(a => a.Tax_Id.Equals(ID)).SingleOrDefault();
            newobject.Tax_Name = TextBoxTaxType.Text;
            newobject.Tax_Percentage = Convert.ToDouble(TextBoxPercentage.Text);
            newobject.Tax_Notes = TextBoxNote.Text;
            newobject.Rectime = DateTime.Now;
            newobject.UserId =Convert.ToInt32( Session["userid"]);
            DB.Taxes.DefaultIfEmpty(newobject);
            DB.SubmitChanges();
            gridbind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Taxes.Where(a => a.Tax_Id.Equals(ID)).SingleOrDefault();
            newobject.IsDisable2 = true;
            DB.Taxes.DefaultIfEmpty(newobject);
            DB.SubmitChanges();
            gridbind();
        }
    }
}