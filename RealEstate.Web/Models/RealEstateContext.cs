using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext() : base("RealEstateContext")
        {
        }

        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Advertiser> Advertiser { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
        }
    }
}