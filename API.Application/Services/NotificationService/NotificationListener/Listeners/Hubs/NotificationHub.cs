using System;
using System.Threading.Tasks;
using API.Application.DTO;
using API.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace API.NotificationListener.Listeners.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        private readonly SignInManager<User> _signInManager;


        public NotificationHub(ILoggerFactory loggerFactory, SignInManager<User> signInManager)
        {
            _logger = loggerFactory.CreateLogger<NotificationHub>();
            _signInManager = signInManager;
        }
        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("OnCOnnectedAsync"+Context.UserIdentifier);
            User user = await _signInManager.UserManager.FindByIdAsync(Context.UserIdentifier);
            OnlineUserResponse online = new OnlineUserResponse();
            online.FirstName = user?.FirstName;
            online.LastName = user?.LastName;
            online.IsOnline =true;
            online.PhoneNumber = user?.PhoneNumber;
            online.Id = user?.Id.ToString();
            online.Email = user?.Email;
            await Clients.Others.SendAsync("OnConnectedAsync", online);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Others.SendAsync("OnDisconnectedAsync", $"{Context.UserIdentifier} left.");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ClientsReceiveMessage", $"{Context.UserIdentifier}: {message}");
        }
    }
}

