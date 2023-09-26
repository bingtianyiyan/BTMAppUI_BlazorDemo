using DAL.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base
{
    //B -Interface Inheritance. Inheriting members from IRepository interface
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<MonthlyReport>> GetMonthlyReports();
        Task<string> GetLastReportRun();

	}
}