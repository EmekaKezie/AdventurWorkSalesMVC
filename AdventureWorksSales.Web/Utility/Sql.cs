using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Utility
{
    public class Sql
    {
        #region PRODUCT CATEGORIES
        public const string GetCategories = "SELECT ProductCategoryID, Name, rowguid, ModifiedDate FROM ProductCategory";
        public const string GetCategory = "SELECT Name, rowguid, ModifiedDate FROM ProductCategory WHERE rowguid =  @rowguid";
        public const string CreateCategory = "INSERT INTO ProductCategory(Name, rowguid, ModifiedDate) VALUES(@Name, @rowguid, @ModifiedDate)";
        public const string UpdateCategory = "UPDATE ProductCategory SET Name = @Name, ModifiedDate = @ModifiedDate WHERE rowguid = @rowguid";
        #endregion


        #region SALES ORDER
        public const string GetTotalSalesOrders = @"SELECT DISTINCT 
                                                 (SELECT COUNT(1) FROM SalesOrder) TotalOrder, 
                                                 (SELECT MAX(LineTotal) FROM SalesOrder) HighestLineTotal, 
                                                 (SELECT SUM(OrderQty) FROM SalesOrder WHERE ProductID IN (SELECT ProductID FROM Product WHERE Name = @Name)) FrontBrakeSales 
                                                 FROM SalesOrder";
        #endregion


        #region PRODUCTS
        public const string GetProducts = "SELECT ProductID, Name, ProductNumber, rowguid, ModifiedDate FROM Product ORDER BY Name ASC";
        public const string GetProduct = "SELECT ProductID, Name, ProductNumber, rowguid, ModifiedDate FROM Product WHERE ProductID = @ProductID";
        public const string OrderProduct = "INSERT INTO SalesOrder (SalesOrderID, OrderQty, ProductID, SpecialOfferID, UnitPrice, UnitPriceDiscount, LineTotal, rowguid, ModifiedDate) VALUES (@SalesOrderID, @OrderQty, @ProductID, @SpecialOfferID, @UnitPrice, @UnitPriceDiscount, @LineTotal, @rowguid, @ModifiedDate)";
        #endregion
    }
}