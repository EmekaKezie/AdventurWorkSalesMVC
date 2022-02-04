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

      
        public ActionResult Add(CreateProductCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool insert = ProductCategoryModule.AddCategory(model.CategoryName);
                    if (insert)
                    {
                        ViewBag.Message = "Submitted Successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(string Id)
        {
            ProductCategoryObj obj = new ProductCategoryObj();

            try
            {
                obj.ProductCategory = ProductCategoryModule.GetCategoryById(Id);
            }
            catch (Exception)
            {

                throw;
            }

            return View(obj);
        }


        [HttpPost]
        public ActionResult Edit(string id, ProductCategoryObj model)
        {
            try
            {
                bool update = ProductCategoryModule.UpdateCategory(model.ProductCategory.Name, id);
                
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}