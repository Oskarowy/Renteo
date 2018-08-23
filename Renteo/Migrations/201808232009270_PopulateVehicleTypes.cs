namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (1, 'limousine', 5)");
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (2, 'wagon', 5)");
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (3, 'minivan', 7)");
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (4, 'SUV', 5)");
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (5, 'coupe', 2)");
            Sql("INSERT INTO VehicleTypes ( Id, BodyType, PeopleCapacity) VALUES (6, 'multivan', 9)");
        }
        
        public override void Down()
        {
        }
    }
}
