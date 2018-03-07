namespace RealEstate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        ApplicationUserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationUserID);
            
            AddColumn("dbo.Advertiser", "ApplicationUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertiser", "ApplicationUserID");
            AddForeignKey("dbo.Advertiser", "ApplicationUserID", "dbo.ApplicationUser", "ApplicationUserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertiser", "ApplicationUserID", "dbo.ApplicationUser");
            DropIndex("dbo.Advertiser", new[] { "ApplicationUserID" });
            DropColumn("dbo.Advertiser", "ApplicationUserID");
            DropTable("dbo.ApplicationUser");
        }
    }
}
