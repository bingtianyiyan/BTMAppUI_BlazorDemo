using BTMAppUI.Data.Models;
using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.ProductRepo
{
    /*
	 B - Class Inheritance and Polymorphism
	 */
    public class ProductRepository : BaseRepository<Product>,IProductRepository
	{
        private readonly ISQLDataAccess _db;

        public ProductRepository(ISQLDataAccess db)
        {
            _db = db;
        }
        /// <summary>
        /// Add product to database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public override Task<int> Add(Product product)
        {
            string sql = @"INSERT INTO Products (Product_Name
                          ,Price
                          ,Date_Added
                          ,Date_Modified
                          ,Description
                          ,QuantityPerUnit
                          ,Date_Removed) 
                            VALUES (
						   ?Product_Name
                          ,?Price
                          ,?Date_Added
                          ,?Date_Modified
                          ,?Description
                          ,?QuantityPerUnit
                          ,?Date_Removed);SELECT LAST_INSERT_ID();";

            return _db.InsertData(sql, product);
        }
        /// <summary>
        /// Get all products from database through supplied query.
        /// </summary>
        /// <returns></returns>
        public override Task<List<Product>> All()
        {
            string sql = "SELECT * FROM Products ORDER BY Product_Id DESC";

            var products = _db.GetList<Product, dynamic>(sql, new { });
            return products;
        }

        /// <summary>
        /// Delete product from Product table in database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task Delete(int id)
        {
            string sql = $"DELETE FROM Products WHERE Product_Id =" + id;
            _db.DeleteData(sql, id);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Update a product from Product table.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public override Task Update(Product product)
        {
            string sql = @"UPDATE Products
						SET 
						  Product_Name =   ?Product_Name,
                          Price			=  ?Price,
                          Date_Modified	=  ?Date_Modified,
                          Description		=  ?Description,
                          QuantityPerUnit	=  ?QuantityPerUnit,
                          Date_Removed	=  ?Date_Removed
						WHERE Product_Id = " + product.Product_Id;

            return _db.InsertData(sql, product);
        }
        /// <summary>
        /// Searches product from Product table.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
		public Task<List<Product>> SearchData(string keyword)
		{
			string sql = $"SELECT * FROM Products p WHERE p.Product_Name LIKE '%" + keyword + "%' ORDER BY Product_Id DESC";

			var products = _db.SearchData<Product, dynamic>(sql, new { });
			return products;
		}
        /// <summary>
        /// Get single product from Product table in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<Product> Get(int id)
        {
            string sql = $"SELECT * FROM Products p WHERE p.Product_Id =" + id + " ORDER BY Product_Id DESC";

            var product = _db.GetData<Product, dynamic>(sql, new { });
            return product;
        }

        public Task<List<MonthlyReport>> GetMonthlyReports()
        {
            string sql = "SELECT COUNT(Product_Id) ProductCounts, SUM(p.Price) TotalAmount, Month(Date_Added) Month " +         
                "FROM Products p " +
                            "GROUP BY Month(Date_Added);" +
                //auditlog entry to MonthlyReportAuditLog table
                "INSERT INTO MonthlyReportAuditLog(CreationDate,MessageLog) VALUES(CURRENT_DATE, 'Report is generated.')";
			var products = _db.GetList<MonthlyReport, dynamic>(sql, new { });
            return products;
		}

        public Task<string> GetLastReportRun()
        {
            string sql = "SELECT CreationDate FROM MonthlyReportAuditLog al ORDER BY Id DESC limit 1";
			var lastAuditDate = _db.GetData<string, dynamic>(sql, new { });
			return lastAuditDate;
		}
	}
}