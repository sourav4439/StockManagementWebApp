namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        TotalQuantity = c.Int(nullable: false),
                        Track = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOuts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockOuts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.StockOuts", new[] { "ItemId" });
            DropIndex("dbo.StockOuts", new[] { "CompanyId" });
            DropTable("dbo.StockOuts");
        }
    }
}
