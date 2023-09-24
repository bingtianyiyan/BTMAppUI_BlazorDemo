using DAL.Contracts;
using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	/*
	 This talks directly to the database - ISQLDataAccess
	 */
	public class ProductRepository : IProductRepository
	{
		private readonly ISQLDataAccess _db;

		public ProductRepository(ISQLDataAccess db)
		{
			_db = db;
		}

		public Task Add(Product product)
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

		public Task<List<Product>> All()
		{
			string sql = "SELECT * FROM dbo.Products ORDER BY Product_Id DESC";

			var products = _db.LoadData<Product, dynamic>(sql, new { });
			return products;

        }

		public void Delete(Product entity)
		{

		}

		public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Product Get(int id)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

		public void Update(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}