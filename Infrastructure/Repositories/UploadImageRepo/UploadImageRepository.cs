using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UploadImageRepo
{
	public class UploadImageRepository : IUploadImageRepository
	{
		private readonly ISQLDataAccess _db;

		public UploadImageRepository(ISQLDataAccess _db)
        {
			this._db = _db;
		}

		public Task<int> Add(ProductImage entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<ProductImage>> All()
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Find(ProductImage entity)
		{
			throw new NotImplementedException();
		}

		public Task<ProductImage> Get(int id)
		{
			string sql = "SELECT top 1 * FROM dbo.ProductImages WHERE Product_Id = " + id;
			var image = _db.GetData<ProductImage, dynamic>(sql, new { });
			return image;
		}

		public Task<List<Product>> SearchData(string keyword)
		{
			throw new NotImplementedException();
		}

		public Task Update(ProductImage entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UploadImage(ProductImage file)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> UploadImageAsync(ProductImage file)
		{
			string sql = @"INSERT INTO dbo.ProductImages(Image,Product_Id,File_Name)
							VALUES(@Image,@Product_Id, @File_Name)";

			await _db.InsertData(sql, file);
			return true;
		}
	}
}
