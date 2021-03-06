using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class ProductCategory
    {
       public  int Id { get; set; }
       public  string Name { get; set; }
       public  string UniqueId { get; set; }
       public  DateTime EntryDate { get; set; }
    }

    public class ProductCategoryCollection
    {
        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class ProductCategoryObj
    {
        public ProductCategory ProductCategory { get; set; }
    }
}