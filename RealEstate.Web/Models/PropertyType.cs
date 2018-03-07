using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class PropertyType
    {
        public int PropertyTypeID { get; set; }
        public string PropertyTypeTitle { get; set; }
        public string PropertyTypeDescription { get; set; }
    }
}