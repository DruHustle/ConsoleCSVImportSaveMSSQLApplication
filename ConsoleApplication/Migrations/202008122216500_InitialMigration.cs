namespace ConsoleUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceHeaders",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(nullable: false, maxLength: 50),
                        InvoiceDate = c.DateTime(),
                        Address = c.String(maxLength: 50),
                        InvoiceTotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        LineId = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                        Quantity = c.Single(nullable: false),
                        UnitSellingPriceExVAT = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.LineId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.InvoiceHeaders");
        }
    }
}
