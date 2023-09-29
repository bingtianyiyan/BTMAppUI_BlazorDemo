using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
	public class BaseRepository<T> : IRepository<T>
	{
		public virtual Task<int> Add(T entity)
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

		public virtual Task<bool> Find(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual Task<T> Get(int id)
		{
			throw new NotImplementedException();
		}

		public virtual Task<List<Product>> SearchData(string keyword)
		{
			throw new NotImplementedException();
		}

		public virtual Task Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
