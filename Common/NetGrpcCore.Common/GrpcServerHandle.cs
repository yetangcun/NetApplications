using Grpc.Core;
using GrpcBaseCore.Services;
using Google.Protobuf.WellKnownTypes;

namespace NetGrpcCore.Common
{
    public class GrpcServerHandle
    {
        /// <summary>
        /// 开启grpc服务侦听
        /// </summary>
        public static bool GrpcServerStart(string listenIp, int listenPort, Func<GrpcBaseReq, GrpcBaseRes> handleFunc, Action<Exception> exp)
        {
            try
            {
                if (handleFunc == null)
                {
                    exp(new Exception("处理程序不能为空!"));

                    return false;
                }

                var grpcServer = new Server()
                {
                    Ports = { new ServerPort(listenIp, listenPort, ServerCredentials.Insecure) },
                    Services = { GrpcBaseCoreService.BindService(new GrpcServerDefaultImpService(handleFunc)) }
                };

                grpcServer.Start(); return true;
            }
            catch (Exception ex)
            {
                if (exp != null)
                    exp(ex);
            }

            return false;
        }
    }


    public class GrpcServerDefaultImpService : GrpcBaseCoreService.GrpcBaseCoreServiceBase
    {
        /// <summary>
        /// 业务处理表达式
        /// </summary>
        private Func<GrpcBaseReq, GrpcBaseRes> _handler;

        public GrpcServerDefaultImpService(Func<GrpcBaseReq, GrpcBaseRes> handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// 通用调用
        /// 有入参和响应
        /// </summary>
        public async override Task<GrpcBaseRes> GrpcGeneralCall(GrpcBaseReq req, ServerCallContext context)
        {
            return _handler(req);
        }

        /// <summary>
        /// 通用调用
        /// 有入参无响应
        /// </summary>
        public async override Task<Empty> GrpcGeneralCallWithoutResponse(GrpcBaseReq req, ServerCallContext context)
        {
            _handler(req);

            return await Task.FromResult(new Empty());
        }

        /// <summary>
        /// 通用调用
        /// 无入参有响应
        /// </summary>
        public async override Task<GrpcBaseRes> GrpcGeneralCallWithoutReqparam(Empty empty, ServerCallContext context)
        {
            return _handler(null);
        }

        /// <summary>
        /// 客户端流式
        /// </summary>
        public async override Task<GrpcBaseRes> GrpcClientWayStream(IAsyncStreamReader<GrpcBaseReq> reqParams, ServerCallContext context)
        {
            return _handler(reqParams.Current);
        }

        /// <summary>
        /// 服务端流式
        /// </summary>
        public async override Task GrpcServerWayStream(GrpcBaseReq req, IServerStreamWriter<GrpcBaseRes> resResult, ServerCallContext context)
        {
            // await base.GrpcServerWayStream(req, res, context);
            // await Task.CompletedTask;

            var res = _handler(req);

            await resResult.WriteAsync(res, CancellationToken.None);
        }

        /// <summary>
        /// 双向流式
        /// </summary>
        public async override Task GrpcTwoWayStream(IAsyncStreamReader<GrpcBaseReq> reqParams, IServerStreamWriter<GrpcBaseRes> resResult, ServerCallContext context)
        {
            // await base.GrpcTwoWayStream(req, res, context);
            // await Task.CompletedTask;

            var res = _handler(reqParams.Current);

            await resResult.WriteAsync(res, CancellationToken.None);
        }
    }
}