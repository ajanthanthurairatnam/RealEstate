using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class Suburb
    {
        public int SuburbID { get; set; }
        public string SuburbName { get; set; }

        [ForeignKey("State")]
        public int StateID { get; set; }
        public State State { get; set; }
    }
}