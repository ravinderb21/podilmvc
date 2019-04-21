namespace podil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoAndCategoryModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId, cascadeDelete: true)
                .Index(t => t.CategoryTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "CategoryTypeId", "dbo.CategoryTypes");
            DropIndex("dbo.Photos", new[] { "CategoryTypeId" });
            DropTable("dbo.Photos");
            DropTable("dbo.CategoryTypes");
        }
    }
}
