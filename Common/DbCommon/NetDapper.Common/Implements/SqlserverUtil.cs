using Dapper;
using Microsoft.Data.SqlClient;

namespace NetDapper.Common.Implements
{
    public class SqlserverUtil : IDbUtil
    {
        private string _connectionString = null;

        public SqlserverUtil(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<T> GetAsync<T>(string sql) where T : class
        {
            T result = null;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                result = await conn.QueryFirstAsync<T>(sql);

                conn.Close();
            }

            return result;
        }

        public async Task<List<T>> GetListAsync<T>(string sql) where T : class
        {
            List<T> result = null;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                result = (await conn.QueryAsync<T>(sql)).ToList();

                conn.Close();
            }

            return result;
        }

        public void Dispose() { }

    }
}
