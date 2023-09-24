using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Generics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.ProductRepo
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

            return _db.InsertData(sql, product);
        }

        public override Task<List<Product>> All()
        {
            string sql = "SELECT * FROM dbo.Products ORDER BY Product_Id DESC";

            var products = _db.LoadData<Product, dynamic>(sql, new { });
            return products;
        }

        public override Task Delete(int id)
        {
            string sql = $"DELETE FROM dbo.Products WHERE Product_Id =" + id;
            _db.DeleteData(sql, id);
            return Task.CompletedTask;
        }

        public override Task Update(Product product)
        {
            string sql = @"UPDATE dbo.Products
						SET 
						  [Product_Name] =   @Product_Name,
                          [Price]			=  @Price,
                          [Date_Added]		=  @Date_Added,
                          [Date_Modified]	=  @Date_Modified,
                          [Description]		=  @Description,
                          [QuantityPerUnit]	=  @QuantityPerUnit,
                          [Date_Removed]	=  @Date_Removed,
						  [Subcategory_id]	=  @Subcategory_id,
						  [category_id] 	=  @category_id
						WHERE Product_Id = " + product.Product_Id;

            return _db.InsertData(sql, product);
        }

		public override Task<List<Product>> SearchData(string keyword)
		{
			string sql = $"SELECT * FROM dbo.Products p WHERE p.Product_Name LIKE '%" + keyword + "%' ORDER BY Product_Id DESC";

			var products = _db.SearchData<Product, dynamic>(sql, new { });
			return products;
		}
	}
}