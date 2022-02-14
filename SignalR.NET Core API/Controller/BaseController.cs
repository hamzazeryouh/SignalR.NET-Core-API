using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.NET_Core_API.Controller
{
    public class BaseController<T> : ControllerBase
    {
        protected readonly ILogger<T> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController{T}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        protected BaseController(ILoggerFactory factory)
        {
            Logger = factory.CreateLogger<T>();
        }
    }
}
