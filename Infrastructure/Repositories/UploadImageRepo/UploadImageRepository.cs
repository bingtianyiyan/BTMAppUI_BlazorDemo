using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UploadImageRepo
{
	public class UploadImageRepository : BaseRepository<ProductImage>, IUploadImageRepository
	{
		private readonly ISQLDataAccess _db;

		public UploadImageRepository(ISQLDataAccess _db)
        {
			this._db = _db;
		}

		public override Task<ProductImage> Get(int id)
		{
			string sql = "SELECT top 1 * FROM dbo.ProductImages WHERE Product_Id = " + id + " ORDER BY Image_Id DESC";
			var image = _db.GetData<ProductImage, dynamic>(sql, new { });
			return image;
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
