using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NetApplication.CapServices.CapCore
{
    public interface ICapFailedHandleService
    {
        Task SendMessageNotice<T> (T data);
    }
}
