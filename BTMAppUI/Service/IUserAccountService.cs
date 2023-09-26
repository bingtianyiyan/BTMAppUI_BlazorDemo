using BTMAppUI.Data.Models;
using DAL.Models;
using Infrastructure.Repositories.Base;

namespace BTMAppUI.Service
{
	public interface IUserAccountService: IRepository<User>
	{
		Task<User> GetByUserName(string userName);
	}
}