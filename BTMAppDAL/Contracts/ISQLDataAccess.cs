namespace DAL.Contracts
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> GetList<T, U>(string sql, U parameters);
        Task InsertData<T>(string sql, T parameters);
        Task DeleteData<T>(string sql, T parameters);
		Task UpdateData<T>(string sql, T parameters);
		Task<List<T>> SearchData<T, U>(string sql, U parameters);
        Task<T> GetData<T, U>(string sql, U parameters);

    }
}