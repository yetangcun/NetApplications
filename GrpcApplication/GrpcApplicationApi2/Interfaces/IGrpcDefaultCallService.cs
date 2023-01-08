namespace GrpcApplicationApi2.Interfaces
{
    public interface IGrpcDefaultCallService
    {
        Task GrpcInitial(string serverIp, int serverPort);
    }
}
