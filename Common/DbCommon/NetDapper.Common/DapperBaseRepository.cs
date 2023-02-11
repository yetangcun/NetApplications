using Microsoft.Extensions.Options;
using NetApplication.Common.Enum.Common;
using NetApplication.Common.Model.Options;
using NetDapper.Common.Implements;

namespace NetDapper.Common
{
    internal class DapperBaseRepository : IDapperBaseRepository
    {
        private DataBaseOptions _option;

        public DapperBaseRepository(IOptions<DataBaseOptions> options)
        {
            _option = options.Value;
        }

        private IDbUtil GetDbUtil(string connectionString = null, DataBaseType? dbType = null, bool isRead = false)
        {
            var isOptionExist = (_option != null);

            if (string.IsNullOrWhiteSpace(connectionString) && isOptionExist)
                connectionString = isRead ? _option.MasterConnectionString : _option.SlaveConnectionString;

            if (dbType == null && isOptionExist)
                dbType = _option.DbType;

            if (string.IsNullOrWhiteSpace(connectionString) || dbType == null)
                return null;

            IDbUtil dbUtil = null;

            switch (dbType)
            {
                case DataBaseType.Mysql: dbUtil = new MysqlUtil(connectionString); break;
                case DataBaseType.Sqlserver: dbUtil = new SqlserverUtil(connectionString); break;
                case DataBaseType.Postgresql: dbUtil = new PostgresqlUtil(connectionString); break;
                case DataBaseType.Sqlite: dbUtil = new SqliteUtil(connectionString); break;
                default: break;
            }

            return dbUtil;
        }

        public async Task<T> GetAsync<T>(string sql, string connectionString = null, DataBaseType? dbType = null, bool isRead = false) where T : class
        {
            using (var dbUtil = GetDbUtil(connectionString, dbType, isRead))
            {
                return await dbUtil.GetAsync<T>(sql);
            }
        }

        public async Task<List<T>> GetListAsync<T>(string sql, string connectionString = null, DataBaseType? dbType = null, bool isRead = false) where T : class
        {
            using (var dbUtil = GetDbUtil(connectionString, dbType, isRead))
            {
                return await dbUtil.GetListAsync<T>(sql);
            }
        }

    }
}
