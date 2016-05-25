namespace Chirper.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "LikeCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "LikeCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Posts", "UserId");
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
