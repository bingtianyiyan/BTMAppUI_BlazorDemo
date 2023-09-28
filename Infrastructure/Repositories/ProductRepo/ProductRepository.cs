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
    public class ProductRepository : IProductRepository
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
        public Task<int> Add(Product product)
        {
            string sql = @"INSERT INTO dbo.Products ([Product_Name]
                          ,[Price]
                          ,[Date_Added]
                          ,[Date_Modified]
                          ,[Description]
                          ,[QuantityPerUnit]
                          ,[Date_Removed]
						  ,Subcategory_id
						  ,category_id) 
                            VALUES (
						   @Product_Name
                          ,@Price
                          ,@Date_Added
                          ,@Date_Modified
                          ,@Description
                          ,@QuantityPerUnit
                          ,@Date_Removed
						  ,@Subcategory_id
						  ,@category_id);
            SELECT SCOPE_IDENTITY();";

            return _db.InsertData(sql, product);
        }
        /// <summary>
        /// Get all products from database through supplied query.
        /// </summary>
        /// <returns></returns>
        public Task<List<Product>> All()
        {
            string sql = "SELECT * FROM dbo.Products ORDER BY Product_Id DESC";

            var products = _db.GetList<Product, dynamic>(sql, new { });
            return products;
        }

        /// <summary>
        /// Delete product from Product table in database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(int id)
        {
            string sql = $"DELETE FROM dbo.Products WHERE Product_Id =" + id;
            _db.DeleteData(sql, id);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Update a product from Product table.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task Update(Product product)
        {
            string sql = @"UPDATE dbo.Products
						SET 
						  [Product_Name] =   @Product_Name,
                          [Price]			=  @Price,
                          [Date_Modified]	=  @Date_Modified,
                          [Description]		=  @Description,
                          [QuantityPerUnit]	=  @QuantityPerUnit,
                          [Date_Removed]	=  @Date_Removed,
						  [Subcategory_id]	=  @Subcategory_id,
						  [category_id] 	=  @category_id
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
			string sql = $"SELECT * FROM dbo.Products p WHERE p.Product_Name LIKE '%" + keyword + "%' ORDER BY Product_Id DESC";

			var products = _db.SearchData<Product, dynamic>(sql, new { });
			return products;
		}
        /// <summary>
        /// Get single product from Product table in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Product> Get(int id)
        {
            string sql = $"SELECT * FROM dbo.Products p WHERE p.Product_Id =" + id + " ORDER BY Product_Id DESC";

            var product = _db.GetData<Product, dynamic>(sql, new { });
            return product;
        }

        public Task<List<MonthlyReport>> GetMonthlyReports()
        {
            string sql = "SELECT COUNT(Product_Id) ProductCounts, SUM(p.Price) TotalAmount, Month(Date_Added) 'Month' " +         
                "FROM Products p " +
                            "GROUP BY Month(Date_Added)" +
				//auditlog entry to MonthlyReportAuditLog table
				"INSERT INTO MonthlyReportAuditLog(CreationDate,MessageLog) VALUES(GETDATE(), 'Report is generated.')";
			var products = _db.GetList<MonthlyReport, dynamic>(sql, new { });
            return products;
		}

        public Task<string> GetLastReportRun()
        {
            string sql = "SELECT TOP 1 CreationDate FROM MonthlyReportAuditLog al ORDER BY Id DESC";
			var lastAuditDate = _db.GetData<string, dynamic>(sql, new { });
			return lastAuditDate;
		}

		public Task<bool> Find(Product user)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}