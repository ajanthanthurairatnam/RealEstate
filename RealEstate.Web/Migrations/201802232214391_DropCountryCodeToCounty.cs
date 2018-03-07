namespace RealEstate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCountryCodeToCounty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Country", "CountryCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Country", "CountryCode", c => c.String());
        }
    }
}
