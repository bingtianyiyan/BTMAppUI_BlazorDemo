using BTMAppUI.Data.Models;
using DAL.Models;
using Infrastructure.Repositories.AccountRepo;
using System.Linq.Expressions;

namespace BTMAppUI.Service
{
	public class UserAccountService : IUserAccountService
	{
		private readonly IUserAccountRepository _userRepository;

		public UserAccountService(IUserAccountRepository userRepository)
		{
			_userRepository = userRepository;
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
			return _userRepository.GetByUserName(userName);
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
