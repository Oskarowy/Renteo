namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalCostClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalCosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalId = c.Int(nullable: false),
                        RentalLength = c.Int(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rentals", t => t.RentalId, cascadeDelete: true)
                .Index(t => t.RentalId);
            
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalCosts", "RentalId", "dbo.Rentals");
            DropIndex("dbo.RentalCosts", new[] { "RentalId" });
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropTable("dbo.RentalCosts");
        }
    }
}
