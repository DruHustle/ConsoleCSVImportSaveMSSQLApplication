using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Classes
{
    public class ConsoleAudit
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("\n");

            //Diplay the sum of InvoiceLines.Quantity * InvoiceLines.UnitSellingPriceExVAT.
            using (var dbContext = new ApplicationDBContext())
            {
                float totalUnit = 0;
                List<InvoiceLine> invoiceLines = dbContext.InvoiceLines.ToList();
                foreach (InvoiceLine invoiceLine in invoiceLines)
                {
                    float itemQuantity = invoiceLine.Quantity;
                    float itemUnitSellingPrice = invoiceLine.UnitSellingPriceExVAT;
                    totalUnit = totalUnit + itemQuantity * itemUnitSellingPrice;

                }

                Console.WriteLine($"The sum of InvoiceLines.Quantity * InvoiceLines.UnitSellingPriceExVAT is {totalUnit}.");

                //Check if audit passed
                if (Math.Round(totalUnit, 2) == 21860.71)
                {
                    Console.WriteLine($"\nAudit Passed!");
                }
                else
                {
                    Console.WriteLine($"\nAudit Failed");
                }

            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
