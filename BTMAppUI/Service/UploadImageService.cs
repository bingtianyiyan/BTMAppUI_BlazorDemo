using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.UploadImageRepo;

namespace BTMAppUI.Service
{
	public class UploadImageService : IUploadImageService
	{
		private readonly IUploadImageRepository _uploadImageRepository;
        public bool IsSuccessful { get; set; }
        public UploadImageService(IUploadImageRepository uploadImageRepository)
        {
			_uploadImageRepository = uploadImageRepository;
		}


		public async Task UploadImageAsync(ProductImage file)
		{
			if (file == null) return;

			IsSuccessful = await _uploadImageRepository.UploadImageAsync(file);
		}

		public async Task<ProductImage> GetImage(int product_Id)
		{
			if (product_Id == 0) return null;
			ProductImage image = await _uploadImageRepository.Get(product_Id);
			return image;
		}
	}
}
