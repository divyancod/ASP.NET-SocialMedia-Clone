namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
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
                "dbo.Followers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentUserID = c.Int(nullable: false),
                        FollowerUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.FollowerUserId, cascadeDelete: true)
                .Index(t => t.FollowerUserId);
            
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
                        Gender = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        PhoneNumber = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LikeUnlikeStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        LikedById = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.LikedById, cascadeDelete: true)
                .Index(t => t.LikedById);
            
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
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NType = c.Int(nullable: false),
                        ForUser = c.Int(nullable: false),
                        ByUserID = c.Int(nullable: false),
                        NPostPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ByUserID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.NPostPostId)
                .Index(t => t.ByUserID)
                .Index(t => t.NPostPostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PostContent = c.String(),
                        CreatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedAt = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        isDeleted = c.Boolean(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        UnLikeCount = c.Int(nullable: false),
                        CommentCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostMediaMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostsPostID = c.Int(nullable: false),
                        PostMediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostsPostID, cascadeDelete: true)
                .Index(t => t.PostsPostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "NPostPostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.PostMediaMaps", "PostsPostID", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Posts_PostID", "dbo.Posts");
            DropForeignKey("dbo.Notifications", "ByUserID", "dbo.Users");
            DropForeignKey("dbo.LikeUnlikeStatus", "LikedById", "dbo.Users");
            DropForeignKey("dbo.Followers", "FollowerUserId", "dbo.Users");
            DropIndex("dbo.PostMediaMaps", new[] { "PostsPostID" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "NPostPostId" });
            DropIndex("dbo.Notifications", new[] { "ByUserID" });
            DropIndex("dbo.LikeUnlikeStatus", new[] { "LikedById" });
            DropIndex("dbo.Followers", new[] { "FollowerUserId" });
            DropIndex("dbo.Comments", new[] { "Posts_PostID" });
            DropTable("dbo.PostMediaMaps");
            DropTable("dbo.Posts");
            DropTable("dbo.Notifications");
            DropTable("dbo.MediaInfo");
            DropTable("dbo.LoginLogs");
            DropTable("dbo.LikeUnlikeStatus");
            DropTable("dbo.Users");
            DropTable("dbo.Followers");
            DropTable("dbo.Comments");
        }
    }
}
