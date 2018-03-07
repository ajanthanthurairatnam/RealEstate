namespace RealEstate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertiser",
                c => new
                    {
                        AdvertiserId = c.Int(nullable: false, identity: true),
                        IsSeller = c.Boolean(nullable: false),
                        AdvertiserName = c.String(),
                        AdvertiserEmail = c.String(),
                        AdvertiserPhone = c.String(),
                        AdvertiserMobile = c.String(),
                    })
                .PrimaryKey(t => t.AdvertiserId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        PropertyIsForSale = c.Boolean(nullable: false),
                        PropertyPrice = c.Decimal(precision: 18, scale: 2),
                        WeeklyRent = c.Decimal(precision: 18, scale: 2),
                        PropertyTypeId = c.Int(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        SuburburbId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                        ContactMobile = c.String(),
                        PropertyLandSize = c.Decimal(precision: 18, scale: 2),
                        PropertyMap = c.String(),
                        PropertyBedRooms = c.Int(nullable: false),
                        PropertyCarParks = c.Int(nullable: false),
                        BathRooms = c.Int(nullable: false),
                        PropertyDescription = c.String(),
                        PropertyInspectionDetail = c.String(),
                        AdvertiserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.Advertiser", t => t.AdvertiserId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.PropertyType", t => t.PropertyTypeId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.Suburb", t => t.SuburburbId)
                .Index(t => t.PropertyTypeId)
                .Index(t => t.SuburburbId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId)
                .Index(t => t.AdvertiserId);
            
            CreateTable(
                "dbo.PropertyType",
                c => new
                    {
                        PropertyTypeID = c.Int(nullable: false, identity: true),
                        PropertyTypeTitle = c.String(),
                        PropertyTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.PropertyTypeID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Suburb",
                c => new
                    {
                        SuburbID = c.Int(nullable: false, identity: true),
                        SuburbName = c.String(),
                        StateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuburbID)
                .ForeignKey("dbo.State", t => t.StateID)
                .Index(t => t.StateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Property", "SuburburbId", "dbo.Suburb");
            DropForeignKey("dbo.Suburb", "StateID", "dbo.State");
            DropForeignKey("dbo.Property", "StateId", "dbo.State");
            DropForeignKey("dbo.State", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Property", "PropertyTypeId", "dbo.PropertyType");
            DropForeignKey("dbo.Property", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Property", "AdvertiserId", "dbo.Advertiser");
            DropIndex("dbo.Suburb", new[] { "StateID" });
            DropIndex("dbo.State", new[] { "CountryID" });
            DropIndex("dbo.Property", new[] { "AdvertiserId" });
            DropIndex("dbo.Property", new[] { "CountryId" });
            DropIndex("dbo.Property", new[] { "StateId" });
            DropIndex("dbo.Property", new[] { "SuburburbId" });
            DropIndex("dbo.Property", new[] { "PropertyTypeId" });
            DropTable("dbo.Suburb");
            DropTable("dbo.State");
            DropTable("dbo.PropertyType");
            DropTable("dbo.Property");
            DropTable("dbo.Country");
            DropTable("dbo.Advertiser");
        }
    }
}
