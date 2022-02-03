using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Utility
{
    public class DBConn
    {
        protected static string Connection()
        {
            string connStr = "Data Source=DESKTOP-OCH43DR;Initial Catalog=AdventureWorksSales;Integrated Security=True";
            return connStr;
        }
    }
}