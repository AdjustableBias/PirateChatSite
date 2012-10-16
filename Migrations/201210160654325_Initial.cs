namespace PirateChatSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfiles",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Follower_UserId = c.Int(),
                        Follows_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Follower_UserId)
                .ForeignKey("dbo.UserProfiles", t => t.Follows_UserId)
                .Index(t => t.Follower_UserId)
                .Index(t => t.Follows_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "Follows_UserId" });
            DropIndex("dbo.Contacts", new[] { "Follower_UserId" });
            DropForeignKey("dbo.Contacts", "Follows_UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Contacts", "Follower_UserId", "dbo.UserProfiles");
            DropTable("dbo.Contacts");
            DropTable("dbo.UserProfiles");
        }
    }
}
