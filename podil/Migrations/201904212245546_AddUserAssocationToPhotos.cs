namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAssocationToPhotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Photos", "ApplicationUserId");
            AddForeignKey("dbo.Photos", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Photos", new[] { "ApplicationUserId" });
            DropColumn("dbo.Photos", "ApplicationUserId");
        }
    }
}
