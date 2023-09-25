using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    /*
     This class talks to Repository
     */
    public class ProductService : IProductService
	{
		private readonly IRepository<Product> _productRepository;

		public ProductService(IRepository<Product> productRepository)
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

		public Task AddProduct(Product product)
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
            return _productRepository.GetData(product_Id);
        }
    }
}
