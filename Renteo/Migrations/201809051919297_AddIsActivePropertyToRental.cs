namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActivePropertyToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "IsActive");
        }
    }
}
