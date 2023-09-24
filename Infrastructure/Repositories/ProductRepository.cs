using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Generics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	/*
	 B - Class Inheritance and Polymorphism
	 */
	public class ProductRepository : GenericRepository<Product>
	{
		private readonly ISQLDataAccess _db;

		public ProductRepository(ISQLDataAccess db) : base(db)
		{
			_db = db;
		}

		public override Task Add(Product product)
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
						  ,@category_id);";

			return _db.SaveData(sql, product);
		}

		public override Task<List<Product>> All()
		{
			string sql = "SELECT * FROM dbo.Products ORDER BY Product_Id DESC";

			var products = _db.LoadData<Product, dynamic>(sql, new { });
			return products;

        }

		public override void Delete(int id)
		{
			string sql = $"DELETE FROM dbo.Products WHERE Product_Id =" + id;
			var products = _db.DeleteData(sql, id);

		}
	}
}