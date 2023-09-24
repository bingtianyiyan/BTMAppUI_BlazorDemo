using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task Add(Product entity);
		Task<List<Product>> All();
		void Delete(Product entity);
		IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate);
		Product Get(int id);
		void SaveChanges();
		void Update(Product entity);
	}
}