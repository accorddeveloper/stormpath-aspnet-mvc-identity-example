using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using IdentityExample.StormpathIdentity;

namespace IdentitySample.Models
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class StormpathUserManager : UserManager<StormpathUser>
    {
        public StormpathUserManager(IUserStore<StormpathUser> store)
            : base(store)
        {
        }

        public static StormpathUserManager Create(IdentityFactoryOptions<StormpathUserManager> options,
            IOwinContext context)
        {
            var manager = new StormpathUserManager(new StormpathUserStore(context.Get<StormpathContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<StormpathUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.PasswordHasher = new StormpathPasswordHasher();

            manager.EmailService = new EmailService();

            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class ApplicationSignInManager : SignInManager<StormpathUser, string>
    {
        public ApplicationSignInManager(StormpathUserManager userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(StormpathUser user)
        {
            return user.GenerateUserIdentityAsync((StormpathUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<StormpathUserManager>(), context.Authentication);
        }
    }
}