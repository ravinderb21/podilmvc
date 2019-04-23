namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCategoryTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CategoryTypes (Id, Category) VALUES (1, 'Adventure') ");
            Sql("INSERT INTO CategoryTypes (Id, Category) VALUES (2, 'Celebration') ");
            Sql("INSERT INTO CategoryTypes (Id, Category) VALUES (3, 'Family') ");
            Sql("INSERT INTO CategoryTypes (Id, Category) VALUES (4, 'Party') ");
            Sql("INSERT INTO CategoryTypes (Id, Category) VALUES (5, 'Vacation') ");
        }
        
        public override void Down()
        {
        }
    }
}
