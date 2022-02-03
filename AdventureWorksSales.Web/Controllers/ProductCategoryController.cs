using AdventureWorksSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorksSales.Web.Modules;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            ProductCategoryCollection categories = new ProductCategoryCollection();

            try
            {
                categories.ProductCategories = ProductCategoryModule.GetProductCategory();
            }
            catch (Exception e)
            {
                throw e;
            }


            return View(categories);
        }



        public ActionResult NewCategory()
        {
            if (ModelState.IsValid)
            {
                bool ret = ProductCategoryModule.AddCategory();
                try
                {
                    if (ret)
                    {
                        ViewBag["result"] = "Successfull";
                    }
                    else
                    {
                        ViewBag["result"] = "Failed";
                    }
                }
                catch (Exception e)
                {

                    throw e;
                }
            }


            return View();
        }
    }
}