using BTMAppUI.Data.Models;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.AccountRepo
{
	public class UserAccountRepository : IUserAccountRepository
	{
		private readonly ISQLDataAccess _db;

		public UserAccountRepository(ISQLDataAccess db)
		{
			this._db = db;
		}

		public Task Add(User entity)
		{
			throw new NotImplementedException();
		}

		public Task<List<User>> All()
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<User> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetByUserName(string userName)
		{
			string sql = "SELECT * FROM Users WHERE Username ='" + userName + "'";
			var user = _db.GetData<User, dynamic>(sql, new { });
			return user;
		}

		public Task<List<Product>> SearchData(string keyword)
		{
			throw new NotImplementedException();
		}

		public Task Update(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
