using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Models
{
    public class UserIdentifier
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AllowEmailNotifications { get; set; }
        public string ProfileImageUrl { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
    public class User: UserIdentifier
    {
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int? PasswordHashIterations { get; set; }
        public bool UsesFacebookAuth { get; set; }
        public bool UsesGoogleAuth { get; set; }
        public bool UsesMicrosoftAuth { get; set; }
    }
}
