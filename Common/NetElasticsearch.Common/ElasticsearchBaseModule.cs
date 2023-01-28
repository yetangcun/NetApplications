using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using NetApplication.Common.Model.Options;
using Microsoft.Extensions.DependencyInjection;
using NetApplication.Common.Model.EsModel;

namespace NetElasticsearch.Common
{
    public static class ElasticsearchBaseModule
    {
        /// <summary>
        /// 初始化注册注入
        /// </summary>
        public static void EsModuleInitial(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient();
            services.AddSingleton<IElasticsearchBaseService, ElasticsearchBaseService>();

            var esConfig = config.GetSection("EsServerOption").Get<ElasticsearchOptions>();
            services.Configure<ElasticsearchOptions>(opt =>
            {
                opt.EsServerIp = esConfig.EsServerIp;
                opt.EsServerPort = esConfig.EsServerPort;
            });
        }

        /// <summary>
        /// 初始化调用
        /// </summary>
        public static void EsApplicationInitial(this IHost host, IConfiguration config)
        {
            var esService = host.Services.GetService<IElasticsearchBaseService>();

            esService.EsMapping<EsPassRecord>();
        }
    }
}
