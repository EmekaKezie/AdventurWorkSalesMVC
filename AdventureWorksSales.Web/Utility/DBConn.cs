using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Utility
{
    public class DBConn
    {
        private static string Server;
        private static string Database;
        private static string Username;
        private static string Password;
        private static bool IntegratedSecurity;

        protected static string Connection()
        {
            DBConnParam param = new DBConnParam()
            {
                Server = "DESKTOP-OCH43DR",
                Database = "AdventureWorksSales",
                Username = "",
                Password = "",
                IntegratedSecurity = true,
            };

            Server = param.Server;
            Database = param.Database;
            Username = param.Username;
            Password = param.Password;
            IntegratedSecurity = param.IntegratedSecurity;


            string connStr = $"Data Source={Server};Initial Catalog={Database};User Id={Username};Password={Password};Integrated Security={IntegratedSecurity}";
            return connStr;
        }
    }

    public class DBConnParam
    {
        internal string Server { get; set; }
        internal string Database { get; set; }
        internal bool IntegratedSecurity { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }
    }
}