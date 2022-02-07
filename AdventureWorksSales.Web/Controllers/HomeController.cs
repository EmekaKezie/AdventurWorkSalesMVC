using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TotalSalesOrder data = new TotalSalesOrder();

            try
            {
                data = HomeModule.TotalOrdersAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

            return View(data);
        }

    }
}