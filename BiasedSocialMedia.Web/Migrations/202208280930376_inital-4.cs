namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MediaInfo", "PostMediaMap_Id", "dbo.PostMediaMaps");
            DropIndex("dbo.MediaInfo", new[] { "PostMediaMap_Id" });
            DropColumn("dbo.MediaInfo", "PostMediaMap_Id");
            DropTable("dbo.PostMediaMaps");
        }
        
        public override void Down()
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
    }
}
