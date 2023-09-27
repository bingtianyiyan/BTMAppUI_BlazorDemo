using BTMAppUI.Data.Models;
using DAL.Models;
using Infrastructure.Repositories.Base;

namespace BTMAppUI.Service
{
	public interface IUserAccountService : IRepository<User>
	{
		bool UserFound { get; set; }
		Task<User> GetByUserName(string userName);
	}
}