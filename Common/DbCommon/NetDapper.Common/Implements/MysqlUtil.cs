using Dapper;
using MySql.Data.MySqlClient;

namespace NetDapper.Common.Implements
{
    public class MysqlUtil : IDbUtil
    {
        private string _connectionString = null;

        public MysqlUtil(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<T> GetAsync<T>(string sql) where T : class
        {
            T result = null;

            using (var conn = new MySqlConnection(sql))
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

            using (var conn = new MySqlConnection(sql))
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
