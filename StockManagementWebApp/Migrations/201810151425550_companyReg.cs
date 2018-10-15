namespace StockManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyReg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "RegistrationCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String());
            DropColumn("dbo.Companies", "RegistrationCode");
        }
    }
}
