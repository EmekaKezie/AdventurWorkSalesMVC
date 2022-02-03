using AdventureWorksSales.Web.Models;
using AdventureWorksSales.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Modules
{
    public class ProductModule : DBConn
    {
        public static List<Product> GetProducts()
        {
            List<Product> data = new List<Product>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetProducts, con))
                    {
                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data.Add(new Product
                                {
                                    Id = Convert.ToInt32(i["ProductID"]),
                                    Name = i["Name"].ToString(),
                                    ProductNumber = i["ProductNumber"].ToString(),
                                    UniqueId = i["rowguid"].ToString(),
                                    EntryDate = Convert.ToDateTime(i["ModifiedDate"]),
                                });
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



        public static Product GetProduct(string Id)
        {
            Product data = new Product();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@rowguid", Id);

                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data = new Product
                                {
                                    Id = Convert.ToInt32(i["ProductID"]),
                                    Name = i["Name"].ToString(),
                                    ProductNumber = i["ProductNumber"].ToString(),
                                    UniqueId = i["rowguid"].ToString(),
                                    EntryDate = Convert.ToDateTime(i["ModifiedDate"]),
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

