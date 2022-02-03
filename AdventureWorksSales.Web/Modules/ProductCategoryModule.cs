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

        /// <summary>
        /// Get Product Categories
        /// </summary>
        /// <returns></returns>
        public static List<ProductCategory> GetProductCategory()
        {
            List<ProductCategory> data = new List<ProductCategory>();

            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.ProductCategories, con))
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
                                    UniqeId = i["rowguid"].ToString(),
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


        public static bool AddCategory()
        {
            bool data = false;
            CreateProductCategory createProductCategory = new CreateProductCategory();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Sql.CreateProductCategory, con))
                    {
                        if(createProductCategory.CategoryName != null)
                        {
                            cmd.Parameters.AddWithValue("@Name", createProductCategory.CategoryName ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@rowguid", Guid.NewGuid().ToString());
                            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

                            int insert = cmd.ExecuteNonQuery();
                            if (insert > 0)
                            {
                                data = true;
                            }
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