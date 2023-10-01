using DAL.Models;
using Infrastructure.Repositories.Base;
using Infrastructure.Service;
using Moq;

namespace UnitTest
{
	public class ProductServiceTest
	{
		[Fact]
		public async void CanAddProduct()
		{
			//1. ARRANGE
			var mockRroductRepository = new Mock<IProductRepository>();
			var productService = new ProductService( //call controller
				mockRroductRepository.Object
			);

			//instantiate mock data
			var mockProduct = new Product
			{
				Product_Name = "Mock Test Baby Toy",
				Description = "Mock Test Baby Toy description",
				Price = 400.00m
			};

			//2. ACT
			await productService.AddProduct(mockProduct);


			//3. ASSERT
			// Verify that the Add method of the repository was called with the correct arguments
			mockRroductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once);
		}


		[Fact]
		public async void CanUpdateProduct()
		{
			//1. ARRANGE
			var mockRroductRepository = new Mock<IProductRepository>();
			var productService = new ProductService( //call controller
				mockRroductRepository.Object
			);

			//instantiate mock data
			var mockProduct = new Product
			{
				Product_Id = 1,
				Product_Name = "Mock Test Baby Toy",
				Description = "Mock Test Baby Toy description",
				Price = 400.00m
			};

			//2. ACT
			await productService.Update(mockProduct);


			//3. ASSERT
			// Verify that the Update method of the repository was called with the correct arguments
			mockRroductRepository.Verify(r => r.Update(mockProduct), Times.Once);
		}

		[Fact]
		public async void CanDeleteProduct()
		{
			//1. ARRANGE
			var mockRroductRepository = new Mock<IProductRepository>();
			var productService = new ProductService( //call controller
				mockRroductRepository.Object
			);

			//instantiate mock data
			var mockProduct = new Product
			{
				Product_Id = 1,
				Product_Name = "Mock Test Baby Toy",
				Description = "Mock Test Baby Toy description",
				Price = 400.00m
			};

			//2. ACT
			await productService.Delete(mockProduct.Product_Id);


			//3. ASSERT
			// Verify that the Delete method of the repository was called with the correct arguments
			mockRroductRepository.Verify(r => r.Delete(mockProduct.Product_Id), Times.Once);
		}
	}
}