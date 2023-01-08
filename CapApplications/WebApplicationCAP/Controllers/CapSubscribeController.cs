using DotNetCore.CAP;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetApplication.Common.Model.Options;
using System.Data;

namespace WebApplicationCAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapSubscribeController : ControllerBase
    {
        private readonly ICapPublisher _capBus;
        private readonly DataBaseOptions _dbOption;

        public CapSubscribeController (
            ICapPublisher capBus,
            IOptions<DataBaseOptions> dbOption)
        {
            _capBus = capBus;
            _dbOption = dbOption.Value;
        }

        //[NonAction]
        //[CapSubscribe("without.services.show.times")]
        //public async Task CapSubWithoutTransHandle (DateTime dateTime)
        //{
        //    throw new Exception("test errors");
        //}

        //[NonAction]
        //[CapSubscribe("adonet.services.show.times")]
        //public async Task CapSubWithAdonetTransHandle (DateTime dateTime)
        //{
        //    using (IDbConnection conn = new MySqlConnection(_dbOption.DbConnectionString))
        //    {
        //        using (var transaction = conn.BeginTransaction(_capBus, autoCommit: false))
        //        {
        //            var sql = "insert into sys_user_role(Id,RoleId,UserId,CreationTime,IsDeleted) values(11,22,33,'2022-09-22 13:34',0);";

        //            var cmd = conn.CreateCommand();
        //            cmd.CommandText = sql;
        //            cmd.Transaction = (IDbTransaction) transaction.DbTransaction;
        //            cmd.ExecuteNonQuery();

        //            // 业务代码
        //            _capBus.Publish("adonet.services.show.times", DateTime.Now);

        //            transaction.Commit();
        //        }
        //    }

        //    throw new Exception("test adonet errors");
        //}

        //[NonAction]
        //[CapSubscribe("efcore.services.show.times")]
        //public async Task CapSubWithEfcoreTransHandle (DateTime dateTime)
        //{
        //    throw new Exception("test efcore errors");
        //}
    }
}
