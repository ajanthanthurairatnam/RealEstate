using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Web.Models
{
    public class Advertiser
    {
        public int AdvertiserId { get; set; }
        public bool IsSeller { get; set; }
        public string AdvertiserName { get; set; }
        public string AdvertiserEmail { get; set; }
        public string AdvertiserPhone { get; set; }
        public string AdvertiserMobile { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}