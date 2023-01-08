using GrpcApplicationApi2.Enum;
using System.Collections.Concurrent;
using GrpcApplicationApi2.Interfaces.GrpcHandle;

namespace GrpcApplicationApi2.Common.Const
{
    public class ModuleConsts
    {
        public static ConcurrentDictionary<GrpcOptType, Type> GrpcHandleDic = new ConcurrentDictionary<GrpcOptType, Type>();

        public static void GrpcHandleInitial()
        {
            GrpcHandleDic.TryAdd(GrpcOptType.Query, typeof(IGrpcQueryHandleService));
        }

    }
}
