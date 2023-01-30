using Newtonsoft.Json;
using NetElasticsearch.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetApplication.Common.Model.EsModel;

namespace NetElasticsearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticsearchHandleController : ControllerBase
    {
        [HttpGet("EsQueryAsync")]
        public async Task<string> EsQueryAsync([FromServices] IElasticsearchBaseService service)
        {
            var record = new EsPassRecord()
            {
                No = "X000001",
                Name = "零零一"
            };

            var result = await service.Query<EsPassRecord>();

            if (result == null || result.Count < 1)
                await service.Add(record);

            return result == null ? "" : JsonConvert.SerializeObject(result);
        }

        [HttpPost("EsAddAsync")]
        public async Task<bool> EsAddAsync([FromBody] EsPassRecord record, [FromServices] IElasticsearchBaseService service)
        {
            var result = await service.QueryWhere<EsPassRecord>(e => e.Term("No", record.No));

            if (result == null || result.Count < 1)
            {
                await service.Add(record);
                return true;
            }

            return false;
        }

        [HttpDelete("EsDelAsync")]
        public async Task<bool> EsDelAsync(string no, [FromServices] IElasticsearchBaseService service)
        {
            var result = await service.Del<EsPassRecord>(no);
            return result;
        }
    }
}
