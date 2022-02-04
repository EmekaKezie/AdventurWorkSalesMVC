using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventureWorksSales.Web.Utility;
using AdventureWorksSales.Web.Models;
using System.Data.SqlClient;


namespace AdventureWorksSales.Web.Modules
{
    public class ProductCategoryModule : DBConn
    {
        public static List<ProductCategory> GetProductCategory()
        {
            List<ProductCategory> data = new List<ProductCategory>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetCategories, con))
                    {
                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data.Add(new ProductCategory
                                {
                                    Id = Convert.ToInt32(i["ProductCategoryID"]),
                                    Name = i["Name"].ToString(),
                                    UniqueId = i["rowguid"].ToString(),
                                    EntryDate = Convert.ToDateTime(i["ModifiedDate"])
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


        public static ProductCategory GetCategoryById(string Id)
        {
            ProductCategory data = new ProductCategory();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.GetCategory, con))
                    {
                        cmd.Parameters.AddWithValue("@rowguid", Id);

                        SqlDataReader i = cmd.ExecuteReader();
                        if (i.HasRows)
                        {
                            while (i.Read())
                            {
                                data = new ProductCategory
                                {
                                    Name = i["Name"].ToString(),
                                    UniqueId = i["rowguid"].ToString(),
                                    EntryDate = Convert.ToDateTime(i["ModifiedDate"])
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


        public static bool AddCategory(string categoryName)
        {
            bool data = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.CreateCategory, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", categoryName);
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

                throw e;
            }

            return data;
        }


        public static bool UpdateCategory(string name, string id)
        {
            bool data = false;

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.UpdateCategory, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@rowguid", id);

                        int update = cmd.ExecuteNonQuery();
                        if (update > 0)
                        {
                            data = true;
                        }

                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return data;
        }
    }
}