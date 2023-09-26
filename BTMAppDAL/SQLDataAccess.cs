using DAL.Contracts;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

		public string ConnectionStringName { get; set; } = "Default";
        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
		}
        /// <summary>
        /// Get list of object. Re-usable method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<T>> GetList<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task InsertData<T>(string sql, T parameters)
        {
			await Save(sql, parameters);
		}

        public async Task DeleteData<T>(string sql, T parameters)
        {
			await Save(sql, parameters);
		}

		public async Task UpdateData<T>(string sql, T parameters)
		{
            await Save(sql, parameters);
		}

        public async Task<List<T>> SearchData<T, U>(string sql, U parameters)
        {
			string connectionString = _config.GetConnectionString(ConnectionStringName);

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				var data = await connection.QueryAsync<T>(sql, parameters);
				return data.ToList();
			}
		}

		private async Task Save<T>(string sql, T parameters)
        {
			string connectionString = _config.GetConnectionString(ConnectionStringName);

			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				await connection.ExecuteAsync(sql, parameters);
			}
		}
        /// <summary>
        /// Get single object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<T> GetData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.FirstOrDefault();
            }
        }
    }
}
