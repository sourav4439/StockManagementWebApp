namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class track : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockOuts", "Track_Id", "dbo.Tracks");
            DropIndex("dbo.StockOuts", new[] { "Track_Id" });
            DropColumn("dbo.StockOuts", "TrackId");
            RenameColumn(table: "dbo.StockOuts", name: "Track_Id", newName: "TrackId");
            AlterColumn("dbo.StockOuts", "TrackId", c => c.Byte(nullable: false));
            AlterColumn("dbo.StockOuts", "TrackId", c => c.Byte(nullable: false));
            CreateIndex("dbo.StockOuts", "TrackId");
            AddForeignKey("dbo.StockOuts", "TrackId", "dbo.Tracks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOuts", "TrackId", "dbo.Tracks");
            DropIndex("dbo.StockOuts", new[] { "TrackId" });
            AlterColumn("dbo.StockOuts", "TrackId", c => c.Byte());
            AlterColumn("dbo.StockOuts", "TrackId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.StockOuts", name: "TrackId", newName: "Track_Id");
            AddColumn("dbo.StockOuts", "TrackId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockOuts", "Track_Id");
            AddForeignKey("dbo.StockOuts", "Track_Id", "dbo.Tracks", "Id");
        }
    }
}
