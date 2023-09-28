using BTMAppUI.Data.Models;
using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base
{
    public interface IRepository<T>// : IProductUploadProcessor, ICategory, ISubcategory, ISearchFilterQueries
    {
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<List<T>> All();
        Task<bool> Find(T entity);

		Task<List<Product>> SearchData(string keyword);
        Task<T> Get(int id);
    }
}
