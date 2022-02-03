using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Modules
{
    public class HomeModule : DBConn
    {
        public static TotalSalesOrder TotalOrdersAsync()
        {
            TotalSalesOrder data = new TotalSalesOrder();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetTotalSalesOrders, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", "Front Brakes");

                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data = new TotalSalesOrder
                                {
                                    TotalOrders = Convert.ToInt32(i["TotalOrder"]),
                                    HighestLineTotal = Convert.ToInt32(i["HighestLineTotal"]),
                                    FrontBrakeSalesTotal = Convert.ToInt32(i["FrontBrakeSales"]),
                                };
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return data;
        }
    }
}