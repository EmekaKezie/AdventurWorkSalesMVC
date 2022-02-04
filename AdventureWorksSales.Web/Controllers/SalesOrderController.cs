using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksSales.Web.Controllers
{
    public class SalesOrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}