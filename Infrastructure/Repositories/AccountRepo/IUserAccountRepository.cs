using BTMAppUI.Data.Models;
using DAL.Models;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories.AccountRepo
{
	public interface IUserAccountRepository: IRepository<User>
	{
		Task<User> GetByUserName(string userName);
		Task RegisterAccount(User user);
	}
}