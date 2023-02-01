using Newtonsoft.Json;
using NetElasticsearch.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetElasticsearch.Common.Model;
using Nest;

namespace NetElasticsearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticsearchHandleController : ControllerBase
    {
        [HttpGet("EsQueryAsync")]
        public async Task<string> EsQueryAsync([FromServices] IElasticsearchBaseService service)
        {
            var result = await service.Query<EsPassRecord>();

            if (result == null || result.Count < 1)
                await service.Add(new EsPassRecord()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    No = "X000001",
                    Name = "零零一"
                });

            return result == null ? "" : JsonConvert.SerializeObject(result);
        }

        [HttpPost("EsQueryWhereAsync")]
        public async Task<string> EsQueryWhereAsync([FromBody] EsPassRecord record, [FromServices] IElasticsearchBaseService service)
        {
            QueryContainer querys = null;
            if (!string.IsNullOrWhiteSpace(record.No))
            {
                var condition = new QueryContainerDescriptor<EsPassRecord>().Term(p => p.No, record.No);
                querys = condition;
            }

            if (!string.IsNullOrWhiteSpace(record.Name))
            {
                var condition = new QueryContainerDescriptor<EsPassRecord>().Term(p => p.Name, record.Name);
                querys = (querys == null ? condition : querys && condition);
            }

            if (querys == null)
                return string.Empty;

            var result = await service.QueryWhere<EsPassRecord>(querys);
            if ((result == null || result.Count < 1) && !string.IsNullOrWhiteSpace(record.No))
                await service.Add(new EsPassRecord()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    No = record.No,
                    Name = "零零一"
                });

            return result == null ? "" : JsonConvert.SerializeObject(result);
        }

        [HttpPost("EsAddAsync")]
        public async Task<bool> EsAddAsync([FromBody] EsPassRecord record, [FromServices] IElasticsearchBaseService service)
        {
            var result = await service.QueryWhere<EsPassRecord>(e => e.Term(p => p.No, record.No));

            if (result == null || result.Count < 1)
            {
                record.Id = Guid.NewGuid().ToString("N");
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
