namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountIdInCustomerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AccountId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AccountId");
        }
    }
}
