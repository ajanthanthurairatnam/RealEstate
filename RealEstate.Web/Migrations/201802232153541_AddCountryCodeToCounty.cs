namespace RealEstate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryCodeToCounty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Country", "CountryCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Country", "CountryCode");
        }
    }
}
