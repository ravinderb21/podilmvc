namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLenghtToPhotoModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Photos", "FileName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "FileName", c => c.String());
            AlterColumn("dbo.Photos", "Description", c => c.String(nullable: false));
        }
    }
}
