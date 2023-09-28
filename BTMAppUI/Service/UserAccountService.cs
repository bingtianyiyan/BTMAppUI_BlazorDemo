using BTMAppUI.Data.Models;
using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.AccountRepo;

namespace BTMAppUI.Service
{
	public class UserAccountService : IUserAccountService
	{
		private readonly IUserAccountRepository _userRepository;

		public UserAccountService(IUserAccountRepository userRepository)
		{
			_userRepository = userRepository;
		}
        public bool UserFound { get; set; }
        public async Task Add(User user)
		{
			if (user == null) return;

			//check existing user
			UserFound = await _userRepository.Find(user);
			if (!UserFound)
			{
				await _userRepository.Add(user);
			}
		}

		public Task<List<User>> All()
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Find(User user)
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
