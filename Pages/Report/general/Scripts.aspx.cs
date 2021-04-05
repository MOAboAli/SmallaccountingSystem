using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.Report.general
{
    public partial class Scripts : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownListname.DataSource = DB.Scripts.Select(a => new { id = a.ID, name = a.Name });
                DropDownListname.DataBind();
            }

        }

        protected void DropDownListname_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxquery.Text = DB.Scripts.Where(a => a.ID.Equals(DropDownListname.SelectedValue)).SingleOrDefault().Query;
            TextBoxName.Text = DB.Scripts.Where(a => a.ID.Equals(DropDownListname.SelectedValue)).SingleOrDefault().Name;
        }

        protected void Buttonshow_Click(object sender, EventArgs e)
        {

            GridView1.DataSource = getquery();
            GridView1.DataBind();

        }

        protected void Buttonedit_Click(object sender, EventArgs e)
        {
            var sc =DB.Scripts.Where(a => a.ID.Equals(DropDownListname.SelectedValue)).SingleOrDefault();

            sc.Name = TextBoxName.Text;
            sc.Query = TextBoxquery.Text;

            DB.Scripts.DefaultIfEmpty(sc);
            DB.SubmitChanges();
        }

        protected void Buttonadd_Click(object sender, EventArgs e)
        {
            Script sc = new Script();
            sc.Name = TextBoxName.Text;
            sc.Query = TextBoxquery.Text;
            sc.DateTime = DateTime.Now;
            DB.Scripts.InsertOnSubmit(sc);
            DB.SubmitChanges();
        }



        public DataTable getquery()
        {




            try
            {
                DataSet DS = new DataSet();

                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CMS;Integrated Security=True");
                SqlDataAdapter DataAdpt = new SqlDataAdapter(TextBoxquery.Text, conn);
                DataAdpt.SelectCommand.CommandType = CommandType.Text;
                DataAdpt.SelectCommand.CommandTimeout = 500;

                try
                {
                    conn.Open();
                    DataAdpt.Fill(DS);
                    //return DS.Tables[0];
                }
                catch
                {
                    try { if (conn.State == ConnectionState.Open) conn.Close(); }
                    catch { }
                    throw;
                }
                finally
                {
                    try { if (conn.State == ConnectionState.Open) conn.Close(); }
                    catch { }
                }


                try { return DS.Tables[0]; }
                catch { return null; }
            }
            catch
            {
                return null;
            }
            return null;

        }
    }
}