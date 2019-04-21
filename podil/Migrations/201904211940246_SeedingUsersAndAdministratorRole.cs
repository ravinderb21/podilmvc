namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingUsersAndAdministratorRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'91fb7b4f-df85-42ae-bf8a-c2ca746e9e4f', N'ravinder@podil.com', 0, N'AEoT4hJnYZRupe1tv9Tqui6P5WLPksV4AmSEdYLRdebSDj02wYy3Y4WNwAsnirAVDg==', N'e1fa3fe3-be13-43c3-8c93-57733faeb15a', NULL, 0, 0, NULL, 1, 0, N'ravinder@podil.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cbb63552-89ff-4c38-bf07-1b87500b8416', N'admin@podil.com', 0, N'AMFKbY5ShDkGA0g3KWLtr/9GiSS84LtzNZTOEDvK8Xz4YNCgUCWtUDCvQm1V5Mw7MA==', N'a6cf410e-9bb9-4322-bc63-e8cf9d77f76a', NULL, 0, 0, NULL, 1, 0, N'admin@podil.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5cba5232-19f5-4d76-a884-664bcde4ae7c', N'Administrator')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cbb63552-89ff-4c38-bf07-1b87500b8416', N'5cba5232-19f5-4d76-a884-664bcde4ae7c')
");
        }

        public override void Down()
        {
        }
    }
}
