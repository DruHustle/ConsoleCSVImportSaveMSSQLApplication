using ConsoleUI.Classes;
using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

                // Read content from csv file in the resource file
                string[] lines = Properties.Resources.data.Replace("\r", "").Split('\n');
                lines = lines.Take(lines.Count() - 1).ToArray();

                //Notify user path is acquired
                Console.WriteLine("\nSuccessfully loaded \"data.csv\" file into application.\n\nPress any key to proceed....");
                Console.ReadKey();
                Console.Clear();

                if (lines!=null)
                {
                    //Read CSV file
                    DataTable dataTable = ReadData.Source(lines);

                    //Clear local DB
                    DataBase.Clear();

                    //Save to database
                    SaveData.DataBase(dataTable);

                    // Display the invoice number and total quantity for all the lines on an invoice.
                    ConsoleInvoice.Print();

                    //Diplay the sum of InvoiceLines.Quantity * InvoiceLines.UnitSellingPriceExVAT.
                    ConsoleAudit.Print();
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
