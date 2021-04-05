using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class InvoiceType : System.Web.UI.Page
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
            Invoice_T newobject = new Invoice_T();
            newobject.Invoice_T_Name = TextBoxInvoiceType.Text;
            newobject.Invoice_T_PayOrGain =Convert.ToByte( CheckBoxpaygain.Checked);
            newobject.Invoice_T_Note = TextBoxNote.Text;
            newobject.IsDisable = false;
            newobject.Rectime = DateTime.Now;
            newobject.UserID =Convert.ToInt32( Session["userid"]);
            newobject.Invoice_T_Rectime = DateTime.Now;

            DB.Invoice_Ts.InsertOnSubmit(newobject);
            DB.SubmitChanges();

            
        }

        
        protected void gridbind()
        {
            GridView1.DataSource = DB.Invoice_Ts.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Invoice_T_Id, Name = a.Invoice_T_Name,  a.Invoice_T_PayOrGain, Note = a.Invoice_T_Note }); ;
            GridView1.DataBind();
        }

        protected void SelectGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(ID)).SingleOrDefault();



            TextBoxInvoiceType.Text = newobject.Invoice_T_Name;
            CheckBoxpaygain.Checked = Convert.ToBoolean(newobject.Invoice_T_PayOrGain);
            TextBoxNote.Text = newobject.Invoice_T_Note;
            
            


        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(ID)).SingleOrDefault();
            newobject.Invoice_T_Name = TextBoxInvoiceType.Text;
            newobject.Invoice_T_PayOrGain = Convert.ToByte(CheckBoxpaygain.Checked);
            newobject.Invoice_T_Note = TextBoxNote.Text;
            newobject.Rectime = DateTime.Now;
            newobject.UserID =Convert.ToInt32( Session["userid"]);
            DB.Invoice_Ts.DefaultIfEmpty(newobject);
            DB.SubmitChanges();
            gridbind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Invoice_Ts.Where(a => a.Invoice_T_Id.Equals(ID)).SingleOrDefault();
            newobject.IsDisable = true;
            DB.Invoice_Ts.DefaultIfEmpty(newobject);
            DB.SubmitChanges();
            gridbind();
        }
    }
}