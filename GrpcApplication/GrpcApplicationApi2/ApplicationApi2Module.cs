using GrpcApplicationApi2.Services;
using GrpcApplicationApi2.Interfaces;
using GrpcApplicationApi2.Interfaces.GrpcHandle;
using GrpcApplicationApi2.Services.GrpcHandle;
using GrpcApplicationApi2.Common.Const;

namespace GrpcApplicationApi2
{
    public static class ApplicationApi2Module
    {
        /// <summary>
        /// 项目初始化
        /// </summary>
        public static void ModuleInitial(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(typeof(IGrpcDefaultCallService), typeof(GrpcDefaultCallService));
            services.AddSingleton(typeof(IGrpcQueryHandleService), typeof(GrpcQueryHandleService));
        }

        /// <summary>
        /// 程序参数初始化
        /// </summary>
        public static async void ApplicationInitial(this IHost application, IConfiguration config)
        {
            var service = application.Services.GetService<IGrpcDefaultCallService>();
            if (service != null)
            {
                var serverIp = config.GetSection("GrpcConfig:ServerIp").Value;
                var serverPort = config.GetSection("GrpcConfig:ServerPort").Get<int>();
                await service.GrpcInitial(serverIp, serverPort);
            }

            ModuleConsts.GrpcHandleInitial();
        }
    }
}
