namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalCostsAddedToRentalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "Length", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "TotalCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropColumn("dbo.Rentals", "TotalCost");
            DropColumn("dbo.Rentals", "Length");
        }
    }
}
