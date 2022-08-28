namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital5 : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.PostMediaMaps", "PostsPostID", "dbo.Posts");
            DropIndex("dbo.PostMediaMaps", new[] { "PostsPostID" });
            DropTable("dbo.PostMediaMaps");
        }
    }
}
