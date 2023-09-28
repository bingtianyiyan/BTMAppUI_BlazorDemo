using DAL.Models;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UploadImageRepo
{
	public interface IUploadImageRepository : IRepository<ProductImage>
	{
		Task<bool> UploadImageAsync(ProductImage file);
	}

}
