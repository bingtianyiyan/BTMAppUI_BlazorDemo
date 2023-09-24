using DAL.Models;

namespace DAL.Contracts
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts();
    }
}