using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Interface
{
   public interface IUserChat
    {
        Task<string> Send(string userSend,string UserReceive, string Message);
    }
}
