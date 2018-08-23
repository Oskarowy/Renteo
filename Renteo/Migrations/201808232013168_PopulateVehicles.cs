namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Opel', 'Insignia', 2017, 'Unleaded', 1)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('BMW', '5 series', 2018, 'Hybrid', 2)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Volkswagen', 'Sharan', 2016, 'Diesel', 3)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Jeep', 'Grand Cherokee', 2017, 'Diesel', 4)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Dodge', 'Viper', 2014, 'Unleaded', 5)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Volkswagen', 'Transporter', 2018, 'Diesel', 6)");
            Sql("INSERT INTO Vehicles ( Make, Model, ProductionYear, FuelType, VehicleTypeId) VALUES ('Toyota', 'Auris', 2018, 'Hybrid', 2)");
        }

        public override void Down()
        {
        }
    }
}
