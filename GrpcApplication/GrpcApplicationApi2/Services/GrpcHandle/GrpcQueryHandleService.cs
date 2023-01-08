using GrpcApplicationApi2.Interfaces.GrpcHandle;
using GrpcBaseCore.Services;
using System.Text;

namespace GrpcApplicationApi2.Services.GrpcHandle
{
    public class GrpcQueryHandleService : IGrpcQueryHandleService
    {
        public async Task<GrpcBaseRes> GrpcHandler(GrpcBaseReq req)
        {
            var bts = Encoding.UTF8.GetBytes("xiaoxiao军");
            return new GrpcBaseRes() { Opt = req.Opt, Msg = "哈哈", Bts = Google.Protobuf.ByteString.CopyFrom(bts) };
        }
    }
}
