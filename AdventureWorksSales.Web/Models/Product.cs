using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string UniqueId { get; set; }
        public DateTime EntryDate { get; set; }
    }

    public class ProductList
    {
        public List<Product> Products { get; set; }
    }

    public class ProductData
    {
        public Product Product { get; set; }
    }
}