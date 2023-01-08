using NetApplication.Common.Model.Options;
using NetSqlSugar.Common;

namespace ApplicationWebApi
{
    public static class ApplicationWebModule
    {
        /// <summary>
        /// 模块注册、注入
        /// </summary>
        public static void ApplicationWebModuleInitial(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<SqlSugarClientHandle>();
            services.AddSingleton<SqlSugarScopeHandle>();

            services.Configure<List<SqlsugarOptions>>(config.GetSection("SqlsugarOptions"));
        }

        /// <summary>
        /// 程序运行初始化
        /// </summary>
        public static void ApplicationWebInitial()
        {

        }
    }
}
