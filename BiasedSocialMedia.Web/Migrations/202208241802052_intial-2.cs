namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "LikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UnLikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CommentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CommentCount");
            DropColumn("dbo.Posts", "UnLikeCount");
            DropColumn("dbo.Posts", "LikeCount");
        }
    }
}
