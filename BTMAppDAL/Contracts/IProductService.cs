using DAL.Models;

namespace DAL.Contracts
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts();
        Task Delete(int id);
		Task<string> Update(Product product);
        Task<List<Product>> SearchProducts(string keyword);
        Task<Product> GetProduct(int id);
	}
}