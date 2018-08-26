namespace Renteo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c71914b-dc46-4a29-87b0-93e1116f41ff', N'admin@renteo.com', 0, N'AJgC5rQP62cdJ4UiCbB4mKIs/DlrJkoXZczIj5lMc/LXvSYt4d5+gIdQGMJOZ/HbOQ==', N'13ecbce0-3420-4855-a695-cb6a585593f8', NULL, 0, 0, NULL, 1, 0, N'admin@renteo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'676ed088-d0d1-4459-8fc0-f35994582da4', N'guest@renteo.com', 0, N'AOL1NX9QxWU3BYrSdyUoAFltWkhohvLmTX9AZVNOQ/UwKoBzZU2sOlS/JnXDYWd4TQ==', N'2f900e69-be17-4bbf-86c3-278669e5f9eb', NULL, 0, 0, NULL, 1, 0, N'guest@renteo.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1c52d89f-907a-4d0b-a9d5-7ed6505b4615', N'CanManageVehicles')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5c71914b-dc46-4a29-87b0-93e1116f41ff', N'1c52d89f-907a-4d0b-a9d5-7ed6505b4615')

");
        }
        
        public override void Down()
        {
        }
    }
}
