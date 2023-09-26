using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base
{
    public interface IRepository<T>// : IProductUploadProcessor, ICategory, ISubcategory, ISearchFilterQueries
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<List<T>> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<List<Product>> SearchData(string keyword);
        Task<T> Get(int id);
    }
}
