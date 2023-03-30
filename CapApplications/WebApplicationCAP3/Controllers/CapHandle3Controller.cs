using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCAP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapHandle3Controller : ControllerBase
    {
        public static int runNums = 0;

        [NonAction]
        [CapSubscribe("cap2back.services.show.times")]
        public async Task CapSubWithEfcoreTransHandle(DateTime dateTime)
        {
            if (runNums < 4)
            {
                runNums++;
                throw new Exception("test adonet errors");
            }

        }
    }
}
