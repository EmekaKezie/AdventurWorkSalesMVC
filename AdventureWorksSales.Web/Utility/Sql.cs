using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Utility
{
    public class Sql
    {
        #region PRODUCT CATEGORIES
        public const string ProductCategories = "SELECT ProductCategoryID, Name, rowguid, ModifiedDate FROM ProductCategory";
        public const string CreateProductCategory = "INSERT INTO ProductCategory(Name, rowguid, ModifiedDate) VALUES(@Name, @rowguid, @ModifiedDate)";
        #endregion

        #region SALES ORDER
        public const string GetTotalSalesOrders = @"SELECT DISTINCT 
                                                 (SELECT COUNT(1) FROM SalesOrder) TotalOrder, 
                                                 (SELECT MAX(LineTotal) FROM SalesOrder) HighestLineTotal, 
                                                 (SELECT SUM(OrderQty) FROM SalesOrder WHERE ProductID IN (SELECT ProductID FROM Product WHERE Name = @Name)) FrontBrakeSales 
                                                 FROM SalesOrder";
        #endregion
    }
}