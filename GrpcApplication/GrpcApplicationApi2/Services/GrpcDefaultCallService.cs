using GrpcApplicationApi2.Common.Const;
using GrpcApplicationApi2.Enum;
using GrpcApplicationApi2.Interfaces;
using NetGrpcCore.Common;

namespace GrpcApplicationApi2.Services
{
    public class GrpcDefaultCallService : IGrpcDefaultCallService
    {
        private ILogger<GrpcDefaultCallService> _logger;
        private IServiceProvider _serviceProvider;

        public GrpcDefaultCallService(
            ILogger<GrpcDefaultCallService> logger, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task GrpcInitial(string serverIp, int serverPort)
        {
            if (GrpcServerHandle.GrpcServerStart(serverIp, serverPort,
                req =>
                {
                    var optType = (GrpcOptType)req.Opt;
                    var handler = GetGrpcHandler(optType);
                    if (handler != null)
                    {
                        var res = handler.GrpcHandler(req).Result;
                        return res;
                    }

                    return new GrpcBaseCore.Services.GrpcBaseRes() { Opt = req.Opt };
                },
                ex =>
                {
                    _logger.LogError($"Grpc 启动失败：{ex.Message}-{ex.StackTrace}-{ex.InnerException}\r\n");
                }))
            {
                Console.WriteLine($"Grpc 启动成功: {serverIp}:{serverPort}");
            }
        }

        public bool SetGrpcHandler(GrpcOptType optType, Type handlerType)
        {
            if (!ModuleConsts.GrpcHandleDic.ContainsKey(optType))
                ModuleConsts.GrpcHandleDic.TryAdd(optType, handlerType);

            return true;
        }

        public IGrpcBaseHandleService GetGrpcHandler(GrpcOptType optType)
        {
            ModuleConsts.GrpcHandleDic.TryGetValue(optType, out var handlerType);

            IGrpcBaseHandleService handleService = null;

            if (handlerType != null)
                handleService = (IGrpcBaseHandleService)_serviceProvider.GetService(handlerType);

            return handleService;
        }
    }
}
