using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
	public interface IRepository<T>// : IProductUploadProcessor, ICategory, ISubcategory, ISearchFilterQueries
    {
        Task Add(T entity);
        void Update(T entity);
        T Get(int id);
        void Delete(T entity);
        Task<List<T>> All();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
