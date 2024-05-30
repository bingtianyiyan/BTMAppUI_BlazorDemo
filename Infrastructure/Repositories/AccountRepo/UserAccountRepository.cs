using BTMAppUI.Data.Models;
using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.AccountRepo
{
	public class UserAccountRepository : BaseRepository<User>,IUserAccountRepository
	{
		private readonly ISQLDataAccess _db;

		public UserAccountRepository(ISQLDataAccess db)
		{
			this._db = db;
		}

		public override Task<int> Add(User user)
		{
			string sql = @"INSERT INTO Users" +
						 "(UserName,Password,Role)" +
						 "VALUES (?UserName, ?Password, ?Role);";
			return _db.InsertData(sql, user);
		}

		public override async Task<bool> Find(User user)
		{
			string sql = @"SELECT 1 FROM Users 
							WHERE Lower(username) ='" + user.UserName + "'";
			var result = await _db.GetData<bool, dynamic>(sql, new { });
			return result;
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
	}
}
