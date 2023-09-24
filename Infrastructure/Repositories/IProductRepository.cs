using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	//B -Interface Inheritance. Inheriting members from IRepository interface
	public interface IProductRepository : IRepository<Product>
	{
	}
}