namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalStakeOfVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "RentalStake", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "RentalStake");
        }
    }
}
