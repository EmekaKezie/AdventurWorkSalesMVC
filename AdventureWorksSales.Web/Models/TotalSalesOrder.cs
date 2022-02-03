using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class TotalSalesOrder
    {
        public int TotalOrders { get; set; }
        public int HighestLineTotal { get; set; }
        public int FrontBrakeSalesTotal { get; set; }
    }

    public class TotalSalesOrderCollection
    {
        public TotalSalesOrder TotalSalesOrder { get; set; }
    }
}