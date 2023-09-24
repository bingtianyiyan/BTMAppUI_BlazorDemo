using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repositories.Generics
{
    //Uses Polymorphism and interface inheritance
    public abstract class GenericRepository<T> : IRepository<T> where T : class
	{
		private readonly ISQLDataAccess _db;

		public GenericRepository(ISQLDataAccess db)
        {
			_db = db;
		}
        public virtual Task Add(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task<List<T>> All()
		{
			throw new NotImplementedException();
		}

		public virtual Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public virtual T Get(int id)
		{
			throw new NotImplementedException();
		}

		public virtual void SaveChanges()
		{
			throw new NotImplementedException();
		}

		public virtual Task Update(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task<List<Product>> SearchData(string keyword)
		{
			throw new NotImplementedException();
		}
	}
}
