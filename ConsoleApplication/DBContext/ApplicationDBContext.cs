namespace ConsoleUI.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDBContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ConsoleUI.ApplicationDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDBContext' 
        // connection string in the application configuration file.
        public ApplicationDBContext()
            : base("name=ApplicationDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
    }


}