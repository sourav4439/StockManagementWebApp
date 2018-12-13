namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockOutdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockOuts", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockOuts", "Date");
        }
    }
}
