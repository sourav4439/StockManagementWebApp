namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryIdIncompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "CategoryId");
            AddForeignKey("dbo.Companies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Companies", new[] { "CategoryId" });
            DropColumn("dbo.Companies", "CategoryId");
        }
    }
}
