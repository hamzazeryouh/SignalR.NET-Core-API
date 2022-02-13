using API.Application.Interface;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public class UserChat : Hub<IUserChat>
    {
        Task<string>Send (){}
    }
}
