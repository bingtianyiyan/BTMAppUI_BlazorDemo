using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Service
{
	/*
     This class talks to Repository
     */
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Task<List<Product>> GetProducts()
		{
			return _productRepository.All();
		}

		public Task<List<Product>> SearchProducts(string keyword)
		{
			return _productRepository.SearchData(keyword);
		}

		public Task<int> AddProduct(Product product)
		{
			return _productRepository.Add(product);
		}

		public Task Delete(int product_Id)
		{
			_productRepository.Delete(product_Id);
			return Task.FromResult("Product was successfully removed.");
		}

		public Task<string> Update(Product product)
		{
			_productRepository.Update(product);
			return Task.FromResult("Product was successfully updated.");
		}

        public Task<Product> GetProduct(int product_Id)
        {
            return _productRepository.Get(product_Id);
        }

		public Task<List<MonthlyReport>> GetMonthlyReports()
		{
			return _productRepository.GetMonthlyReports();
		}

		public Task<string> GetLastReportRun()
		{
			return _productRepository.GetLastReportRun();
		}
	}
}
