using SqlSugar;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetApplication.Common.Enum.Common;
using NetApplication.Common.Model.Options;
using NetApplication.Common.Model.General;

namespace NetSqlSugar.Common
{
    public class SqlSugarScopeHandle
    {
        private ILogger<SqlSugarScopeHandle> _logger;

        private static SqlSugarScope _sugarScope = null;

        public SqlSugarScopeHandle(
            ILogger<SqlSugarScopeHandle> logger,
            IOptions<List<SqlsugarOptions>> options)
        {
            _logger = logger;

            if (_sugarScope == null)
            {
                var sugarOptions = options.Value;
                var configLists = new List<ConnectionConfig>();

                foreach (SqlsugarOptions sugarOption in sugarOptions)
                {
                    DbType? dbType = null;

                    switch (sugarOption.DbType)
                    {
                        case DataBaseType.Sqlite: dbType = DbType.Sqlite; break;
                        case DataBaseType.Sqlserver: dbType = DbType.SqlServer; break;
                        case DataBaseType.Postgresql: dbType = DbType.PostgreSQL; break;
                        case DataBaseType.Mysql:
                        default: dbType = DbType.MySql; break;
                    }

                    var connConfig = new ConnectionConfig()
                    {
                        DbType = dbType.Value,
                        ConfigId = sugarOption.BusinessCode,
                        ConnectionString = sugarOption.MasterConnectionStrings,
                        SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                        {
                            new SlaveConnectionConfig()
                            {
                                ConnectionString = string.IsNullOrWhiteSpace(sugarOption.SlaveConnectionStrings)?
                                sugarOption.MasterConnectionStrings:sugarOption.SlaveConnectionStrings
                            }
                        },
                        IsAutoCloseConnection = true
                    };

                    configLists.Add(connConfig);
                }

                _sugarScope = new SqlSugarScope(configLists, db =>
                {
                    db.Aop.OnLogExecuting = (sql, parameters) =>
                    {
                        var paramStr = ((parameters == null) ? "" : JsonConvert.SerializeObject(parameters));
                        _logger.LogInformation($"{sql},{paramStr}");
                    };
                });
            }
        }

        public async Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> funcs, BusinessType businessType)
        {
            var dbConn = _sugarScope.GetConnection(businessType);
            var lists = await dbConn.Queryable<T>().Where(funcs).ToListAsync();
            return lists;
        }

        public async Task<List<T>> QueryPageAsync<T>(
            Expression<Func<T, bool>> funcs,
            PageGeneralModel pageModel, 
            BusinessType businessType)
        {
            var dbConn = _sugarScope.GetConnection(businessType);
            var lists = await dbConn.Queryable<T>().Where(funcs).ToPageListAsync(pageModel.PageIndex, pageModel.PageSize);
            return lists;
        }

        public async Task<List<T>> QueryAsync<T>(string sql, BusinessType businessType) where T : class, new()
        {
            var dbConn = _sugarScope.GetConnection(businessType);
            var lists = await dbConn.SqlQueryable<T>(sql).ToListAsync();
            return lists;
        }

        public async Task<List<T>> QueryPageAsync<T>(
            string sql, PageGeneralModel pageModel, 
            BusinessType businessType) where T : class, new()
        {
            var dbConn = _sugarScope.GetConnection(businessType);
            var lists = await dbConn.SqlQueryable<T>(sql).ToPageListAsync(pageModel.PageIndex, pageModel.PageSize);
            return lists;
        }
    }
}
