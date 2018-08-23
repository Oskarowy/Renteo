namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        BodyType = c.String(),
                        PeopleCapacity = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "ProductionYear", c => c.String());
            AddColumn("dbo.Vehicles", "FuelType", c => c.String(nullable: false));
            AddColumn("dbo.Vehicles", "VehicleTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            CreateIndex("dbo.Vehicles", "VehicleTypeId");
            AddForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vehicles", "VehicleTypeId");
            DropColumn("dbo.Vehicles", "FuelType");
            DropColumn("dbo.Vehicles", "ProductionYear");
            DropTable("dbo.VehicleTypes");
        }
    }
}
