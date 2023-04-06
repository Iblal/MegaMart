using Microsoft.AspNetCore.Identity;

namespace MegaMart.Domain.Entities
{
    public sealed class User : IdentityUser
    {


        public static User Create(string email, string username, string password)
        {
            var user = new User { Email = email, UserName = username, PasswordHash = password };

            return user;
        }
    }
}
