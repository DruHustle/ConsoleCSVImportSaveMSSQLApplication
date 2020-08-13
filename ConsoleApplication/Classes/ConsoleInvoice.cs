using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Classes
{
    public class ConsoleInvoice
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("\nInvoice number and quantity:\n");

            // Display the invoice number and total quantity for all the lines on an invoice.
            using (var dbContext = new ApplicationDBContext())
            {
                List<InvoiceLine> invoiceLines = dbContext.InvoiceLines.ToList();
                List<string> invoiceLinesDistinct = dbContext.InvoiceLines.Select(x => x.InvoiceNumber).Distinct().ToList();

                foreach (string invoiceLine in invoiceLinesDistinct)
                {
                    int invoiceCount = invoiceLines.Where(x => x.InvoiceNumber == invoiceLine).Count();
                    Console.WriteLine($"For invoice {invoiceLine}, the total quatinty is {invoiceCount}.");

                }

            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
