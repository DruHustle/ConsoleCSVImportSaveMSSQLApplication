using ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Classes
{
    public class DataBase
    {
        public static void Clear()
        {
            //Clearing tables before adding new data
            using (var dbContext = new ApplicationDBContext())
            {
                dbContext.InvoiceHeaders.RemoveRange(dbContext.InvoiceHeaders);
                dbContext.InvoiceLines.RemoveRange(dbContext.InvoiceLines);
                dbContext.SaveChanges();
            }
        }


    }
}
