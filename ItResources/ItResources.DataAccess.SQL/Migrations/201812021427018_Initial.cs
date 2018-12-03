namespace ItResources.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Keyword",
                c => new
                    {
                        KeywordId = c.Int(nullable: false, identity: true),
                        KeywordName = c.String(),
                    })
                .PrimaryKey(t => t.KeywordId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(maxLength: 255),
                        URL = c.String(),
                        RefreshDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Contacts = c.String(maxLength: 255),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.ResourceKeywords",
                c => new
                    {
                        Resource_ResourceId = c.Int(nullable: false),
                        Keyword_KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_ResourceId, t.Keyword_KeywordId })
                .ForeignKey("dbo.Resource", t => t.Resource_ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Keyword", t => t.Keyword_KeywordId, cascadeDelete: true)
                .Index(t => t.Resource_ResourceId)
                .Index(t => t.Keyword_KeywordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceKeywords", "Keyword_KeywordId", "dbo.Keyword");
            DropForeignKey("dbo.ResourceKeywords", "Resource_ResourceId", "dbo.Resource");
            DropForeignKey("dbo.Resource", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.ResourceKeywords", new[] { "Keyword_KeywordId" });
            DropIndex("dbo.ResourceKeywords", new[] { "Resource_ResourceId" });
            DropIndex("dbo.Resource", new[] { "Category_CategoryId" });
            DropTable("dbo.ResourceKeywords");
            DropTable("dbo.Resource");
            DropTable("dbo.Keyword");
            DropTable("dbo.Category");
        }
    }
}
