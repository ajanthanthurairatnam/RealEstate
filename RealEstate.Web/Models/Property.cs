using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public bool PropertyIsForSale { get; set; }
        public decimal? PropertyPrice { get; set; }
        public decimal? WeeklyRent { get; set; }

        [ForeignKey("PropertyType")]
        public int? PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [ForeignKey("Suburb")]
        public int SuburburbId { get; set; }
        public Suburb Suburb { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public string ContactMobile { get; set; }

        public decimal? PropertyLandSize { get; set; }
        public string PropertyMap { get; set; }
        public int PropertyBedRooms { get; set; }
        public int PropertyCarParks { get; set; }
        public int BathRooms { get; set; }

        public string PropertyDescription { get; set; }
        public string PropertyInspectionDetail { get; set; }

        [ForeignKey("Advertiser")]
        public int AdvertiserId { get; set; }
        public Advertiser Advertiser { get; set; }
    }


}