using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class UpdateCategory
    {
        [Required(ErrorMessage = "Category Name is required")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public string UniqueId { get; set; }
        
    }
}