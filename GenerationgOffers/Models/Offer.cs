using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenerationgOffers.Models
{
    public class Offer
    {
        public int limitAmount { get; set; } 
        public string companyEmail { get; set; } 
        public string companyName { get; set; } 
        public string telNumber { get; set; } 
        public string line { get; set; } 
        public int sellValue { get; set; }
    }
}