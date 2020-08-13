using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using log4net;
using System.Reflection;
using System.Linq;

namespace ConsoleUI.Classes
{
    public class SaveData
    {
        public static void DataBase(DataTable dataTable)
        {
            try
            {
                using (var dbContext = new ApplicationDBContext())
                {
                    List< InvoiceHeader > invoiceHeaderList = new List<InvoiceHeader>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        //define header line
                        InvoiceHeader invoiceHeader = new InvoiceHeader
                        {
                            InvoiceNumber = row["Invoice Number"].ToString(),
                            InvoiceDate = Convert.ToDateTime(row["Invoice Date"].ToString(),CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat),
                            Address = row["Address"].ToString(),
                            InvoiceTotal = Single.Parse(row["Invoice Total Ex VAT"].ToString(), CultureInfo.InvariantCulture.NumberFormat)
                        };

                        //check for duplications
                        if(!(invoiceHeaderList.Any(x=>x.InvoiceNumber == invoiceHeader.InvoiceNumber)))
                        {
                            //add headerline to database
                            dbContext.InvoiceHeaders.Add(invoiceHeader);
                            dbContext.SaveChanges();
                      
                        }
                        invoiceHeaderList.Add(invoiceHeader);    

                        
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        //define new invoice line 
                        InvoiceLine invoiceLine = new InvoiceLine
                        {
                            InvoiceNumber = row["Invoice Number"].ToString(),
                            Description = row["Line description"].ToString(),
                            Quantity = Single.Parse(row["Invoice Quantity"].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                            UnitSellingPriceExVAT = Single.Parse(row["Unit selling price ex VAT"].ToString(), CultureInfo.InvariantCulture.NumberFormat)
                        };

                        //Add line to data base
                        dbContext.InvoiceLines.Add(invoiceLine);
                        dbContext.SaveChanges();
                    }
                }

            }
            catch (Exception)
            {
                //throw exeption to the calling function 
                throw;
            }
        }
    }
}
