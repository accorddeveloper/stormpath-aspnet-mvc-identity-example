using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Stormpath.SDK.Account;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathUser : IUser<string>
    {
        public StormpathUser()
        {
            this.Id = string.Empty;
        }

        public static StormpathUser MapFrom(IAccount account)
        {
            if (account == null)
            {
                return null;
            }

            return new StormpathUser()
            {
                Email = account.Email,
                Id = account.Href,
                UserName = account.Username,
                FirstName = account.GivenName,
                LastName = account.Surname
            };
        }

        public string Id { get; private set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<StormpathUser> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
