using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Application.DTO
{
    internal class OnlineUserResponse:User
    {
            public bool IsOnline { get; set; } = false;
    }
}
