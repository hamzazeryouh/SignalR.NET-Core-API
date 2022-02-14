
using Microsoft.AspNetCore.Identity;
using System;

namespace API.Domain.Entities
{
   public class User: IdentityUser<Guid>
    {
        public string Pseudo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public DateTime? BirthDate { get; set; } = null;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public DateTime? DeletedAt { get; set; } = null;

        public string? ImageUrl { get; set; }
        public string? Bio { get; set; }
    }
}



