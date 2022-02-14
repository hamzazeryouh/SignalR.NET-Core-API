using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Interface
{
   public interface IUserChat
    {
        Task SendMessage(string userSend,string UserReceive, string Message);
        
    }
}
