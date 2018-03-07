using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Web.Models
{
    public class ApplicationUser
    {
        public int ApplicationUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }

    }
}