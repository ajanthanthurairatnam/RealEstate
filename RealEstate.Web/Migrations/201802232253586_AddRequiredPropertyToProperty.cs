namespace RealEstate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredPropertyToProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Property", "ContactName", c => c.String(nullable: false));
            AlterColumn("dbo.Property", "ContactEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Property", "ContactPhone", c => c.String(nullable: false));
            AlterColumn("dbo.Property", "ContactMobile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Property", "ContactMobile", c => c.String());
            AlterColumn("dbo.Property", "ContactPhone", c => c.String());
            AlterColumn("dbo.Property", "ContactEmail", c => c.String());
            AlterColumn("dbo.Property", "ContactName", c => c.String());
        }
    }
}
