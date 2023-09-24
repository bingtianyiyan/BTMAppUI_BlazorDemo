namespace DAL.Contracts
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task InsertData<T>(string sql, T parameters);
        Task DeleteData<T>(string sql, T parameters);
		Task UpdateData<T>(string sql, T parameters);
	}
}