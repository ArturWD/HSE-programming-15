namespace ItResources.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restrictions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resource", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.Resource", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Keyword", "KeywordName", c => c.String(nullable: false));
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Resource", "URL", c => c.String(nullable: false));
            AlterColumn("dbo.Resource", "Category_CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Resource", "Category_CategoryId");
            AddForeignKey("dbo.Resource", "Category_CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resource", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.Resource", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Resource", "Category_CategoryId", c => c.Int());
            AlterColumn("dbo.Resource", "URL", c => c.String());
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Keyword", "KeywordName", c => c.String());
            AlterColumn("dbo.Category", "CategoryName", c => c.String());
            CreateIndex("dbo.Resource", "Category_CategoryId");
            AddForeignKey("dbo.Resource", "Category_CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
