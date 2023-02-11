using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NetDapper.Common
{
    public interface IDbUtil : IDisposable
    {
        Task<T> GetAsync<T>(string sql) where T : class;

        Task<List<T>> GetListAsync<T>(string sql) where T : class;
    }
}
