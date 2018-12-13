namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trackmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Trackname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StockOuts", "TrackId", c => c.Int(nullable: false));
            AddColumn("dbo.StockOuts", "Track_Id", c => c.Byte());
            CreateIndex("dbo.StockOuts", "Track_Id");
            AddForeignKey("dbo.StockOuts", "Track_Id", "dbo.Tracks", "Id");
            DropColumn("dbo.StockOuts", "Track");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockOuts", "Track", c => c.Int(nullable: false));
            DropForeignKey("dbo.StockOuts", "Track_Id", "dbo.Tracks");
            DropIndex("dbo.StockOuts", new[] { "Track_Id" });
            DropColumn("dbo.StockOuts", "Track_Id");
            DropColumn("dbo.StockOuts", "TrackId");
            DropTable("dbo.Tracks");
        }
    }
}
