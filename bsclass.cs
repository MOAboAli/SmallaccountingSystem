using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsolutionWebApp
{
    public class bsclass
    {
        BsolutionDBDataContext DB = new BsolutionDBDataContext();

       
        public void invoicesale(int itemid,int quantity,bool  inout,double cost)
        {
            var newobject = DB.Items.Where(a => a.Items_Id.Equals(itemid)).SingleOrDefault();

            
            var newstock = DB.Stocks.Where(a => a.Item_Id.Equals(itemid)).SingleOrDefault();




            if(inout == true)
            {

                newobject.AverageCost = ((newstock.Stock_Quantity * newobject.AverageCost) + (cost * quantity)) / (quantity + quantity);
                newstock.Stock_Quantity = newstock.Stock_Quantity + quantity;

                DB.Items.DefaultIfEmpty(newobject);
                DB.Stocks.DefaultIfEmpty(newstock);
            }
            else
            {
                newstock.Stock_Quantity = newstock.Stock_Quantity - quantity;

                
                DB.Stocks.DefaultIfEmpty(newstock);
            }

        }

        //use
        public void AddBank(int collexpid, bool collectexp, double cost, DateTime dateop, int bankID, string person, string sign, string note,double price,double profit ,bool shared)
        {

            Bank bank1 = new Bank();
           // bank1.Amount = Convert.ToDecimal(cost);
            bank1.BankName_ID = bankID;
            bank1.Bank_Notes = note;
            if (collectexp == true)
            {
                bank1.Collecting_Id = collexpid;
            }
            else
            {
                bank1.Expenses_Id = collexpid;
            }

            bank1.DateTime = DateTime.Now;
            bank1.IsDisable = false;
            if (sign == "+")
            {
                bank1.Operation_Type = 1;
                bank1.Amount = Convert.ToDecimal(price);
            }
            else if (sign == "-")
            {
                bank1.Operation_Type = 2;
                bank1.Amount = Convert.ToDecimal(cost);
            }
            bank1.PersonInCharge = person;
            bank1.RecTime = DateTime.Now;
            bank1.UserId =Convert.ToInt32( 0);

            DB.Banks.InsertOnSubmit(bank1);
            DB.SubmitChanges();

            int type = 0;
            if (shared == false)
            {
                if (collectexp != true)
                {
                    type = 7;
                }
                else if (sign == "+")
                {
                    type = 5;
                }
                else if (sign == "-")
                {
                    type = 6;
                }

            }
            else
            {
                if (sign == "+")
                {
                    type = 9;
                }
                else if (sign == "-")
                {
                    type = 8;
                }
            }

            Addtransaction(type, "ColExp", collexpid, dateop, cost, price, profit, "");



        }

        //use
        public void Addcash(int collexpid, bool collectexp, double cost, DateTime dateop, int cashID, string person, string sign, string note, double price, double profit, bool shared)
        {

            Cash bank1 = new Cash();
            
            bank1.CashID = cashID;
            bank1.Cash_Notes = note;
           
            if (collectexp == true)
            {
                bank1.Collecting_Id = collexpid;
                bank1.Expenses_Id = 0;
            }
            else
            {
                bank1.Expenses_Id = collexpid;
                bank1.Collecting_Id = 0;
            }

            bank1.Cash_RecTime = DateTime.Now;
            bank1.IsDisable = false;
            if (sign == "+")
            {
                bank1.Operation_Type = 1;
                bank1.Cash_Amount = (float)Convert.ToDouble(price);
            }
            else if (sign == "-")
            {
                bank1.Operation_Type = 2;
                bank1.Cash_Amount = (float)Convert.ToDouble(cost);
            }
            bank1.PersonInCharge = person;
            bank1.Rectime = DateTime.Now;
            bank1.UserId =Convert.ToInt32( 0);
            bank1.Cash_Date = dateop;
            DB.Cashes.InsertOnSubmit(bank1);
            DB.SubmitChanges();

            int type = 0;
            if (shared == false)
            {
                if (collectexp != true)
                {
                    type = 7;
                }
                else if (sign == "+")
                {
                    type = 5;
                }
                else if (sign == "-")
                {
                    type = 6;
                }


            }
            else
            {
                if (sign == "+")
                {
                    type = 9;
                }
                else if (sign == "-")
                {
                    type = 8;
                }
            }
            Addtransaction(type, "ColExp", collexpid, dateop, cost, price, profit, "");

        }


        public void Addtransaction(int idtype,string name,int IDoriginal,DateTime date,double cost,double price,double profit,string note)
        {
            Transaction_Detail det = new Transaction_Detail();
            det.IsDisable = false;
            det.Original_ID = IDoriginal;
            det.Rectime = DateTime.Now;
            det.Transaction_Details_Cost = cost;
            det.Transaction_Details_Date = date;
            det.Transaction_Details_Name = name;
            det.Transaction_Details_Notes = note;
            det.Transaction_Details_Price = price;
            det.Transaction_Details_Profit = profit;
            det.Transaction_Details_Rectime = DateTime.Now;
            det.Transaction_Details_UserId = 0;
            det.Transaction_Type_Id = idtype;
            det.UserID =Convert.ToInt32( 0);

            DB.Transaction_Details.InsertOnSubmit(det);
            DB.SubmitChanges();

            if(idtype ==2)
            {
                addtotaltranscation(date.Month, date.Year, price, 0, 0, 0, 0);
            }

            else if(idtype == 4)
            {
                addtotaltranscation(date.Month, date.Year, 0, cost, 0, 0, 0);
            }

            else if (idtype == 5)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, price, 0, 0);
            }
            else if (idtype == 6)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, 0, cost, 0);
            }
            else if (idtype == 7)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, 0, 0, cost);
            }
           


            

        }


        public void addtotaltranscation(int month,int year,double invoiceg, double invoicep, double colg , double colp, double exp)
        {
            var found = DB.Total_Transations.Where(a => a.Total_Transation_Year.Equals(year));
            if (found.Count() == 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    Total_Transation total = new Total_Transation();
                    total.IsDisable = false;
                    total.Rectime = DateTime.Now;
                    total.TotalCollectingGain = 0;
                    total.TotalCollectingPay = 0;
                    total.TotalExpenses = 0;
                    total.TotalInvoiceGain = 0;
                    total.TotalInvoicePay = 0;
                    total.Total_Transation_Month = i;
                    total.Total_Transation_Year = year;

                    DB.Total_Transations.InsertOnSubmit(total);
                    DB.SubmitChanges();
                }
            }
            else if (DB.Total_Transations.Where(a => a.Total_Transation_Year.Equals(year) && a.Total_Transation_Month.Equals(month)).Count() == 0)
            {
                Total_Transation total2 = new Total_Transation();
                total2.IsDisable = false;
                total2.Rectime = DateTime.Now;
                total2.TotalCollectingGain = 0;
                total2.TotalCollectingPay = 0;
                total2.TotalExpenses = 0;
                total2.TotalInvoiceGain = 0;
                total2.TotalInvoicePay = 0;
                total2.Total_Transation_Month = month;
                total2.Total_Transation_Year = year;

                DB.Total_Transations.InsertOnSubmit(total2);
                DB.SubmitChanges();



            }

            var total3 = DB.Total_Transations.Where(a => a.Total_Transation_Year.Equals(year) && a.Total_Transation_Month.Equals(month)).SingleOrDefault();
            total3.TotalCollectingGain = total3.TotalCollectingGain + colg;
            total3.TotalCollectingPay = total3.TotalCollectingPay + colp;
            total3.TotalExpenses = total3.TotalExpenses + exp;
            total3.TotalInvoiceGain = total3.TotalInvoiceGain + invoiceg;
            total3.TotalInvoicePay = total3.TotalInvoicePay + invoicep;

            DB.Total_Transations.DefaultIfEmpty(total3);
            DB.SubmitChanges();


        }

        //use
        public void editBank(int collexpid, bool collectexp, double cost, DateTime dateop, int bankID, string person, string sign, string note,double price ,double profit, bool shared)
        {

            var bank1 = DB.Banks.First() ;
            if(collectexp==true)
            {
                bank1 = DB.Banks.Where(a => a.Collecting_Id.Equals(collexpid)).SingleOrDefault();
            }
            else
            {
                bank1 = DB.Banks.Where(a => a.Expenses_Id.Equals(collexpid)).SingleOrDefault();
            }
            
            bank1.BankName_ID = bankID;
            bank1.Bank_Notes = note;
            

           
            if (sign == "+")
            { bank1.Operation_Type = 1;
                bank1.Amount = Convert.ToDecimal(price);
            }
            else if (sign == "-")
            { bank1.Operation_Type = 2;
                bank1.Amount = Convert.ToDecimal(cost);
            }
          

            DB.Banks.DefaultIfEmpty(bank1);
            DB.SubmitChanges();

            int type = 0;
            if (shared == false)
            {
                if (collectexp != true)
                {
                    type = 7;
                }
                else if (sign == "+")
                {
                    type = 5;
                }
                else if (sign == "-")
                {
                    type = 6;
                }


            }
            else
            {
                if (sign == "+")
                {
                    type = 9;
                }
                else if (sign == "-")
                {
                    type = 8;
                }
            }

            edittransaction(type, "ColExp", collexpid, dateop, cost, price, profit, "");

        }

        //use
        public void editcash(int collexpid, bool collectexp, double cost, DateTime dateop, int cashID, string person, string sign, string note, double price, double profit, bool shared)
        {
            var bank1 = DB.Cashes.First();
            if (collectexp == true)
            {
                bank1 = DB.Cashes.Where(a => a.Collecting_Id.Equals(collexpid)).SingleOrDefault();
            }
            else
            {
                bank1 = DB.Cashes.Where(a => a.Expenses_Id.Equals(collexpid)).SingleOrDefault();
            }
            
            bank1.CashID = cashID;
            bank1.Cash_Notes = note;



            if (sign == "+")
            {
                bank1.Operation_Type = 1;
                bank1.Cash_Amount = (float)Convert.ToDouble(price);
            }
            else if (sign == "-")
            {
                bank1.Operation_Type = 2;
                bank1.Cash_Amount = (float)Convert.ToDouble(cost);
            }
            bank1.PersonInCharge = person;
            
            bank1.UserId =Convert.ToInt32( 0);

            DB.Cashes.DefaultIfEmpty(bank1);
            DB.SubmitChanges();

            int type = 0;
            if (shared == false)
            {
                if (collectexp != true)
                {
                    type = 7;
                }
                else if (sign == "+")
                {
                    type = 5;
                }
                else if (sign == "-")
                {
                    type = 6;
                }


            }
            else
            {
                if (sign == "+")
                {
                    type = 9;
                }
                else if (sign == "-")
                {
                    type = 8;
                }
            }

            edittransaction(type, "ColExp", collexpid, dateop, cost, price, profit, "");


        }


        public void edittransaction(int idtype, string name, int IDoriginal, DateTime date, double cost, double price, double profit, string note)
        {

            var det = DB.Transaction_Details.Where(a => a.Transaction_Type_Id.Equals(idtype) && a.Original_ID.Equals(IDoriginal)).SingleOrDefault();

            double newprice = 0;
            double newcost = 0;
            double newprofite = 0;


            newprice = price - det.Transaction_Details_Price;
            newcost = cost - det.Transaction_Details_Cost;
            newprofite = profit - det.Transaction_Details_Profit;

            det.IsDisable = false;
            det.Original_ID = IDoriginal;
            det.Rectime = DateTime.Now;
            det.Transaction_Details_Cost = cost;
            
            det.Transaction_Details_Name = name;
            det.Transaction_Details_Notes = note;
            det.Transaction_Details_Price = price;
            det.Transaction_Details_Profit = profit;
            
            det.Transaction_Details_UserId = 0;
            det.Transaction_Type_Id = idtype;
            det.UserID =Convert.ToInt32( 0);



            if (idtype == 2)
            {
                addtotaltranscation(date.Month, date.Year, newprice, 0, 0, 0, 0);
            }

            else if (idtype == 4)
            {
                addtotaltranscation(date.Month, date.Year, 0, newcost, 0, 0, 0);
            }

            else if (idtype == 5)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, newprice, 0, 0);
            }
            else if (idtype == 6)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, 0, newcost, 0);
            }
            else if (idtype == 7)
            {
                addtotaltranscation(date.Month, date.Year, 0, 0, 0, 0, newcost);
            }

            DB.Transaction_Details.DefaultIfEmpty(det);
            DB.SubmitChanges();

        }

        public void invoicetransaction(string id)
        {
            Invoice object1 = DB.Invoices.Where(a => a.Invoice_Id.Equals(id)).SingleOrDefault();

            bsclass bs = new bsclass();

            var found = DB.Transaction_Details.Where(a => a.Original_ID.Equals(object1.Invoice_Id) && (a.Transaction_Type_Id.Equals(4) || (a.Transaction_Type_Id.Equals(2))));

            if (found.Count() == 0)
            {
                if (object1.Invoice_Type_Id == 1)
                    bs.Addtransaction(2, "Invoice+", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_AfterDiscountprice_ATax, object1.Invoice_AfterDiscountprice_ATax - object1.Invoice_TotalCost, "");
                else if (object1.Invoice_Type_Id == 2)
                    bs.Addtransaction(4, "Invoice-", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_AfterDiscountprice_ATax, object1.Invoice_AfterDiscountprice_ATax - object1.Invoice_TotalCost, "");
            }
            else
            {
                if (object1.Invoice_Type_Id == 1)
                    bs.edittransaction(2, "Invoice+", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_AfterDiscountprice_ATax, object1.Invoice_AfterDiscountprice_ATax - object1.Invoice_TotalCost, "");
                else if (object1.Invoice_Type_Id == 2)
                    bs.edittransaction(4, "Invoice-", object1.Invoice_Id, object1.Invoice_Date, object1.Invoice_TotalCost, object1.Invoice_AfterDiscountprice_ATax, object1.Invoice_AfterDiscountprice_ATax - object1.Invoice_TotalCost, "");

            }
        }


        public decimal checkblance (bool bankcash,int id)
        {
            decimal amount = 0;
            if(bankcash == true)
            {
                var banks = DB.Banks.Where(a => a.Bank_Id.Equals(id) && a.IsDisable.Equals(false));

                foreach(var bank in banks)
                {
                    if(bank.Operation_Type == 1)
                    {
                        amount = amount + bank.Amount;
                    }
                    else if (bank.Operation_Type == 2)
                    {
                        amount = amount - bank.Amount;
                    }



                }

            }
            else
            {
                var cashes = DB.Cashes.Where(a => a.CashID.Equals(id) && a.IsDisable.Equals(false));

                foreach (var cash in cashes)
                {
                    if (cash.Operation_Type == 1)
                    {
                        amount = amount + Convert.ToDecimal( cash.Cash_Amount);
                    }
                    else if (cash.Operation_Type == 2)
                    {
                        amount = amount - Convert.ToDecimal(cash.Cash_Amount);
                    }



                }
            }

            return amount;
        }

    }
}