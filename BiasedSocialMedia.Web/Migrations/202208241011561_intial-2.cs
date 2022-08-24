namespace BiasedSocialMedia.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
