namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostMediaMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MediaInfo", "PostMediaMap_Id", c => c.Int());
            CreateIndex("dbo.MediaInfo", "PostMediaMap_Id");
            AddForeignKey("dbo.MediaInfo", "PostMediaMap_Id", "dbo.PostMediaMaps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaInfo", "PostMediaMap_Id", "dbo.PostMediaMaps");
            DropIndex("dbo.MediaInfo", new[] { "PostMediaMap_Id" });
            DropColumn("dbo.MediaInfo", "PostMediaMap_Id");
            DropTable("dbo.PostMediaMaps");
        }
    }
}
