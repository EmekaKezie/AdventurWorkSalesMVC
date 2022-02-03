using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductOrder
    {
        public string Name { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Special Offer Number")]
        public int SpecialOfferID { get; set; }

        [DisplayName("Price")]
        public double UnitPrice { get; set; }

        [DisplayName("Discount Price")]
        public double UnitPriceDiscount { get; set; }

        [DisplayName("Line Total")]
        public double LineTotal { get; set; }
    }
}