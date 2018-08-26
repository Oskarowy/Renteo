namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRentedPropertyToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsRented", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsRented");
        }
    }
}
