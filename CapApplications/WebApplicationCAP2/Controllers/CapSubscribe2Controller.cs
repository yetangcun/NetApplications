using DotNetCore.CAP;
using System.Data;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetApplication.Common.Model.Options;

namespace WebApplicationCAP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapSubscribe2Controller : ControllerBase
    {
        public static int runNums = 0;

        private readonly DataBaseOptions _dbOptions;

        private readonly ICapPublisher _capPublisher;

        public CapSubscribe2Controller (
            ICapPublisher capPublisher,
            IOptions<DataBaseOptions> options)
        {
            _dbOptions = options.Value;
            _capPublisher = capPublisher;
        }

        [NonAction]
        [CapSubscribe("without.services.show.times")]
        public async Task CapSubWithoutTransHandle (DateTime dateTime)
        {
        }

        [NonAction]
        [CapSubscribe("adonet.services.show.times")]
        public async Task CapSubWithAdonetTransHandle (DateTime dateTime)
        {
            if (runNums < 4)
            {
                runNums++;
                throw new Exception("test adonet errors");
            }

            var id = new Random().Next(1, 10000);
            using (IDbConnection conn = new MySqlConnection(_dbOptions.MasterConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        var sql = $"insert into sys_user_role(Id,RoleId,UserId,CreationTime,IsDeleted) values({id},22,33,'2022-09-22 13:34',0);";

                        var cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }

                conn.Close();
            }

            _capPublisher.Publish("cap2back.services.show.times", DateTime.Now);

            runNums = 0;

        }

        [NonAction]
        [CapSubscribe("efcore.services.show.times")]
        public async Task CapSubWithEfcoreTransHandle (DateTime dateTime)
        {
        }
    }
}
