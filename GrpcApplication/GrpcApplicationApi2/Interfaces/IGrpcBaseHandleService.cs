using GrpcBaseCore.Services;

namespace GrpcApplicationApi2.Interfaces
{
    public interface IGrpcBaseHandleService
    {
        Task<GrpcBaseRes> GrpcHandler(GrpcBaseReq req);
    }
}
