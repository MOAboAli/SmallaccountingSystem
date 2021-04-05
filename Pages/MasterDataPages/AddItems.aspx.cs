using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsolutionWebApp.Pages.MasterDataPages
{
    public partial class AddItems : System.Web.UI.Page
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdownlist();
                databind();
            }
        }

        protected void Successbtn_Click(object sender, EventArgs e)
        {
            var newobject = DB.Items.Where(a => a.Items_Name.Equals(TextBoxName.Text));
            if (newobject .Count()== 0)
            {
                insertdata();
                databind();
                cleartools();
            }
            else
            {
                Response.Write("<script language=javascript>alert('this item aleardy excites ');</script>");
            }
        }

        protected void insertdata()
        {

            Item newobject = new Item();
           
            newobject.RecTime = DateTime.Now;
            
            newobject.User_Id = 0;
            newobject.IsDisable = false;
            newobject.AverageCost =Convert.ToDouble( TextBoxcost.Text);
            newobject.HasStock = Convert.ToInt32(CheckBoxhasstock.Checked);
            newobject.Items_Name = TextBoxName.Text;
            newobject.Items_Notes = TextBoxDetials.Text;
            newobject.Items_Price = Convert.ToDouble(textboxprice.Text);
            newobject.Type_Id = Convert.ToInt32(DropDownListitem.SelectedValue);


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




        }

        protected void databind()
        {
            GridView1.DataSource =  DB.Items.Where(a => a.IsDisable.Equals(false)).Select (a=> new { ID = a.Items_Id, Name = a.Items_Name, a.AverageCost, a.HasStock, a.Items_Price, a.Items_Notes });


            //var data = DB.Items.GroupJoin(DB.Stocks,
            //                     a => a.Items_Id, t => t.Item_Id, (i, g) => new { i = i, g = g }).SelectMany(
            //     temp => temp.g.DefaultIfEmpty(),
            //     (temp,p)=> new {i=temp.i ,p=p }


            //     );



           

            GridView1.DataBind();
        }

        protected void cleartools()
        {
            TextBoxName.Text = "";
        }

        protected void EditGrid_Click(object sender, EventArgs e)
        {
            Button objImage = (Button)sender;
            string ID = objImage.CommandName.ToString();
            var newobject = DB.Items.Where(a => a.Items_Id.Equals(ID)).SingleOrDefault();

            newobject.RecTime = DateTime.Now;

            
            newobject.AverageCost = Convert.ToDouble(TextBoxcost.Text);
            newobject.HasStock = Convert.ToInt32(CheckBoxhasstock.Checked);
            newobject.Items_Name = TextBoxName.Text;
            newobject.Items_Notes = TextBoxDetials.Text;
            newobject.Items_Price = Convert.ToDouble(textboxprice.Text);
            newobject.Type_Id = Convert.ToInt32(DropDownListitem.SelectedValue);


            DB.Items.DefaultIfEmpty(newobject);
            DB.SubmitChanges();


            if (CheckBoxhasstock.Checked == true)
            {
                var newstock = DB.Stocks.Where(a => a.Item_Id.Equals(ID)).SingleOrDefault();
                
                
                newstock.Stock_Quantity = Convert.ToInt32(TextBoxquantity.Text);
                newstock.LastModifyDate = DateTime.Now;
                newstock.Last_UserId = 0;

                DB.Stocks.DefaultIfEmpty(newstock);
                DB.SubmitChanges();
            }
            databind();


        }

        protected void DeleteGrid_Click(object sender, EventArgs e)
        {
            //Button objImage = (Button)sender;
            //string ID = objImage.CommandName.ToString();
            //var objecttable = DB.Item_Types.Where(a => a.Item_Type1.Equals(ID)).SingleOrDefault();
            //objecttable.IsDisable = true;
            //DB.Item_Types.DefaultIfEmpty(objecttable);
            //DB.SubmitChanges();
            //databind();
        }

        private void dropdownlist()
        {
            DropDownListitem.DataSource = DB.Item_Types.Where(a => a.IsDisable.Equals(false)).Select(a => new {ID=a.Item_Type1,name=a.Item_Type_Name });
            DropDownListitem.DataBind();
        }

        protected void DropDownListinvoicetype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}