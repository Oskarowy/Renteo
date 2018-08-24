namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToForms : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "ProductionYear", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "FuelType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "FuelType", c => c.String());
            AlterColumn("dbo.Vehicles", "ProductionYear", c => c.String());
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
        }
    }
}
