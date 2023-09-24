using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	public interface IRepository<T>// : IProductUploadProcessor, ICategory, ISubcategory, ISearchFilterQueries
    {
        Task Add(T entity);
        Task Update(T entity);
        T Get(int id);
        Task Delete(int id);
        Task<List<T>> All();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
