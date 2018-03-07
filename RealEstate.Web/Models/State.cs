using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}