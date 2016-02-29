using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathUser : IUser<string>
    {
        public StormpathUser()
        {
            this.Id = string.Empty;
        }

        //public StormpathUser(string href)
        //{
        //    this.Id = href;
        //}

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

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
