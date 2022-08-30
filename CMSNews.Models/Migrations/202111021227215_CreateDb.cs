namespace CMSNews.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false, maxLength: 2000),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.T_News", t => t.NewsId, cascadeDelete: true)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.T_News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(nullable: false, maxLength: 300),
                        Description = c.String(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 100),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        See = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                        NewsGroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.T_NewsGroups", t => t.NewsGroupId, cascadeDelete: true)
                .ForeignKey("dbo.T_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.NewsGroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_NewsGroups",
                c => new
                    {
                        NewsGroupId = c.Int(nullable: false),
                        NewsGroupTitle = c.String(nullable: false, maxLength: 200),
                        ImageName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.NewsGroupId);
            
            CreateTable(
                "dbo.T_Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        MobileNumber = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 100),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_News", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_News", "NewsGroupId", "dbo.T_NewsGroups");
            DropForeignKey("dbo.T_Comments", "NewsId", "dbo.T_News");
            DropIndex("dbo.T_News", new[] { "UserId" });
            DropIndex("dbo.T_News", new[] { "NewsGroupId" });
            DropIndex("dbo.T_Comments", new[] { "NewsId" });
            DropTable("dbo.T_Users");
            DropTable("dbo.T_NewsGroups");
            DropTable("dbo.T_News");
            DropTable("dbo.T_Comments");
        }
    }
}
