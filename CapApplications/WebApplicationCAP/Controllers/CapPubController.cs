using DotNetCore.CAP;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetApplication.CapServices.EfCore;
using NetApplication.Common.Model.Options;
using System.Data;

namespace WebApplicationCAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapPubController : ControllerBase
    {
        private readonly ICapPublisher _capBus;
        private readonly DataBaseOptions _dbOption;

        public CapPubController (
            ICapPublisher capBus,
            IOptions<DataBaseOptions> dbOption)
        {
            _capBus = capBus;
            _dbOption = dbOption.Value;
        }

        [HttpPost("CappubWithoutTransHandle")]
        public async Task<IActionResult> CappubWithoutTransHandle ()
        {
            // 业务代码
            _capBus.Publish("without.services.show.times", DateTime.Now);
            return Ok();
        }

        [HttpPost("CappubWithAdonetTransHandle")]
        public async Task<IActionResult> CappubWithAdonetTransHandle ()
        {
            using (IDbConnection conn = new MySqlConnection(_dbOption.MasterConnectionString))
            {
                using (var transaction = conn.BeginTransaction(_capBus, autoCommit: false))
                {
                    var id = new Random().Next(1, 10000);
                    var sql = $"insert into sys_user_role(Id,RoleId,UserId,CreationTime,IsDeleted) values({id},2,3,'2022-09-22 11:34',0);";

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Transaction = (IDbTransaction)transaction.DbTransaction;
                    cmd.ExecuteNonQuery();

                    // 业务代码
                    _capBus.Publish("adonet.services.show.times", DateTime.Now);

                    transaction.Commit();
                }
            }
            return Ok();
        }

        [HttpPost("CappubWithEfcoreTransHandle")]
        public async Task<IActionResult> CappubWithEfcoreTransHandle ([FromServices] CapdbContext dbContext)
        {
            using (var trans = dbContext.Database.BeginTransaction(_capBus, autoCommit: true))
            {
                // your business logic code
                _capBus.Publish("efcore.services.show.times", DateTime.Now);
            }
            return Ok();
        }


        [NonAction]
        [CapSubscribe("cap2back.services.show.times")]
        public async Task CapSubWithEfcoreTransHandle (DateTime dateTime)
        {
        }
    }
}
