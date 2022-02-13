using API.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace API.Presistence
{
    public class ApiDbContext: IdentityDbContext<ApplicationUser>
    {
    }
}
