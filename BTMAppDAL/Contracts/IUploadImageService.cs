using DAL.Models;

namespace DAL.Contracts
{
	public interface IUploadImageService
	{
		bool IsSuccessful { get; set; }
		Task UploadImageAsync(ProductImage file);
		Task<ProductImage> GetImage(int product_Id);
	}
}