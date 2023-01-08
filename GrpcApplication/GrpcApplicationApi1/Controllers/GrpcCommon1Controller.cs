using System.Text;
using Newtonsoft.Json;
using NetGrpcCore.Common;
using GrpcBaseCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GrpcApplicationApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcCommon1Controller : ControllerBase
    {
        [HttpGet("GrpcCallTestAsync")]
        public async Task<string> GrpcCallTest()
        {
            var channelKey = "ModuleApiChannelKey";

            var reqParams = new GrpcBaseReq()
            {
                Opt = 1
            };

            var res = await GrpcClientHandle.GrpcGeneralCall("192.168.12.99", 52001, reqParams, channelKey);

            var bytes = new byte[res.Bts.Length];

            res.Bts.CopyTo(bytes, 0);

            var realData = Encoding.UTF8.GetString(bytes);

            return JsonConvert.SerializeObject(res);
        }
    }
}
