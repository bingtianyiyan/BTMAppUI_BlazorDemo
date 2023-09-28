using BTMAppUI.Data.Models;
using DAL.Models;

namespace DAL.Contracts
{
	public interface IUserAccountService
	{
		bool UserFound { get; set; }
		Task<User> GetByUserName(string userName);
		Task Add(User user);
	}
}