namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToPhotos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "Description", c => c.String());
        }
    }
}
