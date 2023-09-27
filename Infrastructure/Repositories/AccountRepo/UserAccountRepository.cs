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

		public Task Add(User user)
		{
			string sql = @"INSERT INTO dbo.Users" +
						 "([UserName],[Password],[Role])" +
						 "VALUES (@UserName, @Password, @Role);";
			return _db.InsertData(sql, user);
		}

		public Task<List<User>> All()
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Find(User user)
		{
			string sql = @"SELECT 1 FROM dbo.Users 
							WHERE Lower(username) ='" + user.UserName + "'";
			var result = await _db.GetData<bool, dynamic>(sql, new { });
			return result;
		}

		public Task<User> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<User> GetByUserName(string userName)
		{
			string sql = "SELECT * FROM Users WHERE Username ='" + userName + "'";
			var result = _db.GetData<User, dynamic>(sql, new { });
			return result;
		}

		public async Task RegisterAccount(User user)
		{
			await Add(user);
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
