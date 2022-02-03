using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ProductList list = new ProductList();

            try
            {
                list.Products = ProductModule.GetProducts();
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(list);
        }


        public ActionResult MakeOrder(string ProductId)
        {
            ProductData productData = new ProductData();

            try
            {
                productData.Product = ProductModule.GetProduct(ProductId);
            }
            catch (Exception)
            {

                throw;
            }

            return View(productData);
        }
    }
}