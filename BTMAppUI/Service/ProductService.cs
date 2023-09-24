using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories;
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

		public Task AddProduct(Product product)
		{
			return _productRepository.Add(product);
		}
	}
}
