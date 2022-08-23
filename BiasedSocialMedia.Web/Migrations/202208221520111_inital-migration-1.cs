namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Posts_PostID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Posts_PostID)
                .Index(t => t.Posts_PostID);
            
            CreateTable(
                "dbo.LoginLogs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        LastLogin = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.MediaInfo",
                c => new
                    {
                        MediaID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        MediaURL = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.MediaID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostContent = c.String(),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        isDeleted = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ProfilePhotoID = c.Int(nullable: false),
                        Password = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Posts_PostID", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "Posts_PostID" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.MediaInfo");
            DropTable("dbo.LoginLogs");
            DropTable("dbo.Comments");
        }
    }
}
