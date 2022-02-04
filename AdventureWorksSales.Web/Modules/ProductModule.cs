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


        public static Product GetProduct(int Id)
        {
            Product data = new Product();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", Id);

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


        public static ProductOrder GetProductForOrder(int Id)
        {
            ProductOrder data = new ProductOrder();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", Id);

                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data = new ProductOrder
                                {
                                    Name = i["Name"].ToString(),
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


        public static bool OrderProduct(int ProductId, ProductOrder model)
        {
            bool data = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.OrderProduct, con))
                    {
                        cmd.Parameters.AddWithValue("@SalesOrderID", Util.GenerateRandomNumber());
                        cmd.Parameters.AddWithValue("@OrderQty", model.Quantity);
                        cmd.Parameters.AddWithValue("@ProductID", ProductId);
                        cmd.Parameters.AddWithValue("@SpecialOfferID", model.SpecialOfferID);
                        cmd.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
                        cmd.Parameters.AddWithValue("@UnitPriceDiscount", model.UnitPriceDiscount);
                        cmd.Parameters.AddWithValue("@LineTotal", model.LineTotal);
                        cmd.Parameters.AddWithValue("@rowguid", Guid.NewGuid().ToString());
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                        int insert = cmd.ExecuteNonQuery();
                        if (insert > 0)
                        {
                            data = true;
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

