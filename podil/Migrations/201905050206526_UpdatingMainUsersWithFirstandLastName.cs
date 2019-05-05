namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingMainUsersWithFirstandLastName : DbMigration
    {
        public override void Up()
        {
            Sql(@" UPDATE [AspNetUsers] SET [FirstName] = 'Ravinder', [LastName] = 'Bhatia' WHERE Id = '91fb7b4f-df85-42ae-bf8a-c2ca746e9e4f' ");
            Sql(@" UPDATE [AspNetUsers] SET [FirstName] = 'Rav', [LastName] = 'Admin' WHERE Id = 'cbb63552-89ff-4c38-bf07-1b87500b8416' ");
        }
        
        public override void Down()
        {
        }
    }
}
