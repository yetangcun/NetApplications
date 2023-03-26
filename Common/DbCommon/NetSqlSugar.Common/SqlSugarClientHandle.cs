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
    public class SqlSugarClientHandle
    {
        private ILogger<SqlSugarClientHandle> _logger;

        private List<ConnectionConfig> _connectionConfigs;

        public SqlSugarClientHandle(
            ILogger<SqlSugarClientHandle> logger,
            IOptions<List<SqlsugarOptions>> options)
        {
            _logger = logger;

            if (_connectionConfigs == null)
            {
                _connectionConfigs = new List<ConnectionConfig>();

                foreach (var sugarOption in options.Value)
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
                                ConnectionString =
                                string.IsNullOrWhiteSpace(sugarOption.SlaveConnectionStrings)?
                                sugarOption.MasterConnectionStrings:sugarOption.SlaveConnectionStrings
                            }
                        },
                        IsAutoCloseConnection = true
                    };

                    _connectionConfigs.Add(connConfig);
                }
            }
        }

        private SqlSugarClient GetSugarClientInstance(
            BusinessType? businessType = null,
            ConnectionConfig connectionConfig = null)
        {
            if (businessType == null && connectionConfig == null)
                return null;

            if (
               businessType != null &&
               connectionConfig == null &&
               _connectionConfigs.Any(c => c.ConfigId == businessType))
            {
                connectionConfig = _connectionConfigs.FirstOrDefault(c => c.ConfigId == businessType);
            }

            if (connectionConfig != null)
            {
                var sugarClient = new SqlSugarClient(connectionConfig, db =>
                {
                    db.Aop.OnLogExecuting = (sql, parameters) =>
                    {
                        var paramStr = ((parameters == null) ? "" : JsonConvert.SerializeObject(parameters));
                        _logger.LogInformation($"{sql},{paramStr}");
                    };
                });

                return sugarClient;
            }

            return null;
        }

        public async Task<List<T>> QueryAsync<T>(
            Expression<Func<T, bool>> funcs,
            BusinessType? businessType = null,
            ConnectionConfig connectionConfig = null)
        {
            var sugarClient = GetSugarClientInstance(businessType, connectionConfig);

            if (sugarClient != null)
            {
                var lists = sugarClient.Queryable<T>().Where(funcs).ToList();
                return lists;
            }

            return null;
        }

        public async Task<List<T>> QueryPageAsync<T>(
            PageGeneralModel pageModel,
            Expression<Func<T, bool>> funcs,
            BusinessType? businessType = null,
            ConnectionConfig connectionConfig = null)
        {
            var sugarClient = GetSugarClientInstance(businessType, connectionConfig);

            if (sugarClient != null)
            {
                var lists = await sugarClient.Queryable<T>().Where(funcs).ToPageListAsync(pageModel.PageIndex, pageModel.PageSize);
                return lists;
            }

            return null;
        }

        public async Task<List<T>> QueryAsync<T>(
            string sql, BusinessType? businessType = null,
            ConnectionConfig connectionConfig = null) where T : class, new()
        {
            var sugarClient = GetSugarClientInstance(businessType, connectionConfig);

            if (sugarClient != null)
            {
                var lists = sugarClient.SqlQueryable<T>(sql).ToList();
                return lists;
            }

            return null;
        }

        public async Task<List<T>> QueryPageAsync<T>(
            PageGeneralModel pageModel,
            string sql, BusinessType? businessType = null,
            ConnectionConfig connectionConfig = null) where T : class, new()
        {
            var sugarClient = GetSugarClientInstance(businessType, connectionConfig);

            if (sugarClient != null)
            {
                var lists = await sugarClient.SqlQueryable<T>(sql).ToPageListAsync(pageModel.PageIndex, pageModel.PageSize);
                return lists;
            }

            return null;
        }
    }
}