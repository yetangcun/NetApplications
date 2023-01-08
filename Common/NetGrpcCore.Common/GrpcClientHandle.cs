using Grpc.Core;
using GrpcBaseCore.Services;
using System.Collections.Concurrent;

namespace NetGrpcCore.Common
{
    public class GrpcClientHandle
    {
        /// <summary>
        /// 通道字段
        /// 创建通道开销很大, 所以尽可能公用通道
        /// </summary>
        private static ConcurrentDictionary<string, Channel> _grpcChannelDic = new ConcurrentDictionary<string, Channel>();
        
        private static object CHANNELLOCK = new object();

        /// <summary>
        /// 获取通道对象
        /// </summary>
        public static Channel GetGrpcChannel(string sIp, int sPort, string channelKey)
        {
            if (string.IsNullOrWhiteSpace(channelKey))
                channelKey = "Net.Grpc.Default.Channel";

            Channel channel = null;

            if (_grpcChannelDic.ContainsKey(channelKey))
                channel = _grpcChannelDic[channelKey];

            if (channel == null || (channel.State != ChannelState.Ready && channel.State != ChannelState.Connecting))
            {
                lock (CHANNELLOCK)
                {
                    if (channel == null || (channel.State != ChannelState.Ready && channel.State != ChannelState.Connecting))
                    {
                        channel = new Channel(sIp, sPort, ChannelCredentials.Insecure);
                        _grpcChannelDic[channelKey] = channel;
                    }
                }
            }

            return channel;
        }

        /// <summary>
        /// 通用调用
        /// 有入参有响应
        /// </summary>
        public async static Task<GrpcBaseRes> GrpcGeneralCall(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            return await grpcClient.GrpcGeneralCallAsync(reqParam, deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));
        }

        /// <summary>
        /// 有入参无响应
        /// 此操作无啥用
        /// 最好不用
        /// </summary>
        public async static Task GrpcGeneralCallWithoutResponse(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            await grpcClient.GrpcGeneralCallWithoutResponseAsync(reqParam, deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));
        }

        /// <summary>
        /// 无入参有响应
        /// </summary>
        public async static Task<GrpcBaseRes> GrpcGeneralCallWithoutReqparam(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            return await grpcClient.GrpcGeneralCallWithoutReqparamAsync(null, deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));
        }

        /// <summary>
        /// 客户端流式
        /// </summary>
        public async static Task<GrpcBaseRes> GrpcClientWayStream(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            var res = grpcClient.GrpcClientWayStream(deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));

            await res.RequestStream.WriteAsync(reqParam);

            await res.RequestStream.CompleteAsync();

            return await res.ResponseAsync;
        }

        /// <summary>
        /// 服务端流式
        /// </summary>
        public async static Task<GrpcBaseRes> GrpcServerWayStream(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            var res = grpcClient.GrpcServerWayStream(reqParam, deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));

            //if (res.ResponseStream.MoveNext().Result)
            //    return res.ResponseStream.Current;

            return res.ResponseStream.Current;
        }

        /// <summary>
        /// 客户端服务端双向流
        /// </summary>
        public async static Task<GrpcBaseRes> GrpcTwoWayStream(string sIp, int sPort, GrpcBaseReq reqParam, string channelKey = "", int milliseconds = 4000)
        {
            var channel = GetGrpcChannel(sIp, sPort, channelKey);

            var grpcClient = new GrpcBaseCoreService.GrpcBaseCoreServiceClient(channel);

            var twoWayStream = grpcClient.GrpcTwoWayStream(deadline: DateTime.UtcNow.AddMilliseconds(milliseconds));

            await twoWayStream.RequestStream.WriteAsync(reqParam);

            var resStream = twoWayStream.ResponseStream;

            //if (resStream.MoveNext().Result)
            //    return resStream.Current;

            return resStream.Current;
        }
    }
}
