using ConsoleUI;
using ConsoleUI.Classes;
using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Set the Console Title
                Console.Title = "Decofurn App";

                //Notify user path is acquired
                Console.WriteLine("\nLoading \"data.csv\" file into application.\n\nPress any key to proceed....");
                Console.ReadKey();
                Console.Clear();

                // Read content from csv file in the resource file
                string[] lines = Properties.Resources.data.Replace("\r", "").Split('\n');
                lines = lines.Take(lines.Count() - 1).ToArray();


                if (lines!=null)
                {
                    //Read CSV file
                    DataTable dataTable = ReadData.Source(lines);

                    //Clear local DB
                    DataBase.Clear();

                    //Save to database
                    SaveData.DataBase(dataTable);

                    // Display the invoice number and total quantity for all the lines on an invoice.
                    Console.Clear();
                    using (var dbContext = new ApplicationDBContext())
                    {              
                        List<InvoiceLine> invoiceLines = dbContext.InvoiceLines.ToList();
                        List<string> invoiceLinesDistinct = dbContext.InvoiceLines.Select(x => x.InvoiceNumber).Distinct().ToList();

                        foreach (string invoiceLine in invoiceLinesDistinct)
                        {
                            int invoiceCount = invoiceLines.Where(x => x.InvoiceNumber == invoiceLine).Count();
                            Console.WriteLine($"\nFor invoice {invoiceLine}, the total quatinty is {invoiceCount}");                            

                        }

                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    //Diplay the sum of InvoiceLines.Quantity * InvoiceLines.UnitSellingPriceExVAT.
                    Console.Clear();
                    using (var dbContext = new ApplicationDBContext())
                    {
                        float totalUnit =0;
                        List <InvoiceLine> invoiceLines = dbContext.InvoiceLines.ToList();
                        foreach (InvoiceLine invoiceLine in invoiceLines)
                        {
                            float itemQuantity = invoiceLine.Quantity;
                            float itemUnitSellingPrice = invoiceLine.UnitSellingPriceExVAT;
                            totalUnit = totalUnit + itemQuantity * itemUnitSellingPrice;                           

                        }

                        Console.WriteLine($"\nThe sum of InvoiceLines.Quantity * InvoiceLines.UnitSellingPriceExVAT is {totalUnit}.");

                    }
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("\nFile is null.");
                }
                               

            }
            catch (Exception ex)
            {               
                Console.Clear();
                Console.Beep();
                // Write the error message to console
                Console.WriteLine("\n"+ ex.Message+ "\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
        }
    }
}
