using DotNetCore.CAP;

namespace WebApplicationCap2Service
{
    public class CapSubscribeService : ICapSubscribeService, ICapSubscribe, IDisposable
    {
        public void Dispose () { }

        //[CapSubscribe("without.services.show.times")]
        //public async Task CapSubWithoutTransHandle (DateTime dateTime)
        //{
        //}

        //[CapSubscribe("adonet.services.show.times")]
        //public async Task CapSubWithAdonetTransHandle (DateTime dateTime)
        //{
        //}

        //[CapSubscribe("efcore.services.show.times")]
        //public async Task CapSubWithEfcoreTransHandle (DateTime dateTime)
        //{
        //}
    }
}