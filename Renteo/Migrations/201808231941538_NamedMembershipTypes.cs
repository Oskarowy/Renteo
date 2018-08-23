namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamedMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Basic' WHERE Id = 1");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Quaterly' WHERE Id = 3");
            Sql("UPDATE dbo.MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
