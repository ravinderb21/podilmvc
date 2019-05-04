namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionAndFileNameToPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Description", c => c.String());
            AddColumn("dbo.Photos", "FileName", c => c.String());
            //DropColumn("dbo.Photos", "PhotoUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "PhotoUrl", c => c.String());
            DropColumn("dbo.Photos", "FileName");
            DropColumn("dbo.Photos", "Description");
        }
    }
}
