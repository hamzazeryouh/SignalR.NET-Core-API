using API.Application.DTO;
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
        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("========OnCOnnectedAsync" + Context.UserIdentifier);
            var user = await _signInManager.UserManager.FindByIdAsync(Context.UserIdentifier);
            OnlineUserResponse online = new OnlineUserResponse();
            online.FirstName = user?.FirstName;
            online.LastName = user?.LastName;
            online.IsOnline = true;
            online.PhoneNumber = user?.PhoneNumber;
            online.Id = user.Id;
            online.Email = user?.Email;
          
            await Clients.Others.SendAsync("OnConnectedAsync", online);
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// The OnDisconnectedAsync.
        /// </summary>
        /// <param name="exception">The exception<see cref="Exception"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.SendAsync("OnDisconnectedAsync", $"{Context.UserIdentifier} left.");
            await base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessage(string userSend, string UserReceive, string Message)
        {
            await Clients.User(userSend).SendAsync("ClientsReceiveMessage", $"{Context.UserIdentifier}: {Message}");
        }
    }
}
