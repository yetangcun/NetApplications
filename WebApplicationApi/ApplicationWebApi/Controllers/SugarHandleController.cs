using ApplicationWebApi.Model;
using NetSqlSugar.Common;
using Newtonsoft.Json;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetApplication.Common.Enum.Common;
using NetApplication.Common.Model.General;

namespace ApplicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugarHandleController : ControllerBase
    {
        [HttpGet("GetSugarscopeAsync")]
        public async Task<IActionResult> GetsugarResult([FromServices] SqlSugarScopeHandle sugarScopeHandle)
        {
            var codeLists = new List<int>() { 7, 8 };
            Expression<Func<man_device_info, bool>> expr1 = p => !p.IsDeleted;
            Expression<Func<man_device_info, bool>> expr = p => codeLists.Contains(p.NOCode);
            var tempExpr = Expression.AndAlso(expr.Body, expr1.Body);

            Expression<Func<man_device_info, bool>> expr0 = p => p.IsDeleted;
            var lastExpr = Expression.Or(tempExpr, expr0.Body);

            var exprParams = Expression.Parameter(typeof(man_device_info));
            var expr2 = Expression.Lambda<Func<man_device_info, bool>>(lastExpr, exprParams);

            var res = await sugarScopeHandle.QueryAsync(expr2, BusinessType.CommonBusinessModule);
            var res0 = await sugarScopeHandle.QueryPageAsync(expr2, new PageGeneralModel() { PageIndex = 1, PageSize = 1 }, BusinessType.CommonBusinessModule);
            var res1 = await sugarScopeHandle.QueryAsync<man_device_info>("select * from man_device_info where IsDeleted=0;", BusinessType.CommonBusinessModule);
           
            return new JsonResult(res);
        }

        [HttpGet("GetSugarclientAsync")]
        public async Task<IActionResult> GetsugarResults([FromServices] SqlSugarClientHandle sugarClientHandle)
        {
            var codeLists = new List<int>() { 7, 8 };
            Expression<Func<man_device_info, bool>> expr1 = p => !p.IsDeleted;
            Expression<Func<man_device_info, bool>> expr = p => codeLists.Contains(p.NOCode);
            var tempExpr = Expression.AndAlso(expr.Body, expr1.Body);

            Expression<Func<man_device_info, bool>> expr0 = p => p.IsDeleted;
            var lastExpr = Expression.Or(tempExpr, expr0.Body);

            var exprParams = Expression.Parameter(typeof(man_device_info));
            var expr2 = Expression.Lambda<Func<man_device_info, bool>>(lastExpr, exprParams);

            var res = await sugarClientHandle.QueryAsync(expr2, BusinessType.CommonBusinessModule);
            var res1 = await sugarClientHandle.QueryAsync<man_device_info>("select * from man_device_info where IsDeleted=0;", BusinessType.CommonBusinessModule);
            var res2 = await sugarClientHandle.QueryPageAsync<man_device_info>(new PageGeneralModel() { PageIndex = 1, PageSize = 1 }, "select * from man_device_info where IsDeleted=0", BusinessType.CommonBusinessModule);

            return new JsonResult(res);
        }
    }
}
