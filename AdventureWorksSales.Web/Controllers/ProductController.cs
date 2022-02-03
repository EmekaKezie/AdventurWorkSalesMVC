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


        public ActionResult MakeOrder(int Id)
        {
            ProductOrder productOrder = new ProductOrder();

            try
            {
                productOrder = ProductModule.GetProductForOrder(Id);
            }
            catch (Exception)
            {

                throw;
            }

            return View(productOrder);
        }


        [HttpPost]
        public ActionResult MakeOrder(int Id, ProductOrder model)
        {
            try
            {
                bool order = ProductModule.OrderProduct(Id, model);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}