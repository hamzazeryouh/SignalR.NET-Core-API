using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SignalR.NET_Core_API.Controller
{
    public class IdentityController : BaseController<IdentityController>
    {
        protected IdentityController(ILoggerFactory factory) : base(factory)
        {
        }
    }
}
