namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToPhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "DateAdded");
        }
    }
}
