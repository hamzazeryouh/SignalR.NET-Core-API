using API.Application.Interface;
using API.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public class UserChat : Hub,IUserChat
    {
        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<UserChat> _logger;

        /// <summary>
        /// Defines the _signInManager.
        /// </summary>
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatHub"/> class.
        /// </summary>
        /// <param name="loggerFactory">The loggerFactory<see cref="ILoggerFactory"/>.</param>
        /// <param name="signInManager">The signInManager<see cref="SignInManager{UserEntity}"/>.</param>
        /// <param name="mediaService">The mediaService<see cref="IMediaService"/>.</param>
        public UserChat(ILoggerFactory loggerFactory, SignInManager<User> signInManager)
        {
            _logger = loggerFactory.CreateLogger<UserChat>();
            _signInManager = signInManager;
        }

        public async Task SendMessage(string userSend, string UserReceive, string Message)
        {
            await Clients.User(userSend).SendAsync("ClientsReceiveMessage", $"{Context.UserIdentifier}: {Message}");
        }
    }
}
