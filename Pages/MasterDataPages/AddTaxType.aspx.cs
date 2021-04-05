using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class AddTaxType : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {
            GridView1.DataSource = DB.Taxes.Where(a => a.IsDisable.Equals(false)).Select(a => new { ID = a.Tax_Id, Name = a.Tax_Name, DateOfRec = a.Rectime }); ;
            GridView1.DataBind();
        }
    }
}