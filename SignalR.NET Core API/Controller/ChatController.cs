using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SignalR.NET_Core_API.Controller
{
    public class ChatController : BaseController<ChatController>
    {
        /// <summary>
        /// The logger.
        /// </summary>
        protected ChatController(ILoggerFactory factory) : base(factory)
        {

        }



    }
}
