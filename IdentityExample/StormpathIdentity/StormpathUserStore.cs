using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Stormpath.SDK;
using Stormpath.SDK.Account;
using Stormpath.SDK.Error;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathUserStore : IUserStore<StormpathUser>,
        IUserLoginStore<StormpathUser>,
        IUserEmailStore<StormpathUser>,
        IUserPasswordStore<StormpathUser>
    {
        private readonly StormpathContext context;

        public StormpathUserStore(StormpathContext context)
        {
            this.context = context;
        }

        public Task AddLoginAsync(StormpathUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(StormpathUser user)
        {
            var account = context.GetClient().Instantiate<IAccount>();
            account.SetEmail(user.Email);
            account.SetPassword(user.Password);
            account.SetUsername(user.UserName);
            account.SetGivenName(user.FirstName);
            account.SetSurname(user.LastName);

            var directory = await context.GetDirectory();

            await directory.CreateAccountAsync(account);
        }

        public Task DeleteAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Task<StormpathUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public async Task<StormpathUser> FindByEmailAsync(string email)
        {
            var directory = await this.context.GetDirectory();

            var foundUser = await directory.GetAccounts()
                .Where(x => x.Email == email)
                .SingleOrDefaultAsync();

            return StormpathUser.MapFrom(foundUser);
        }

        public async Task<StormpathUser> FindByIdAsync(string userId)
        {
            try
            {
                var foundUser = await this.context.GetClient().GetAccountAsync(userId);

                return StormpathUser.MapFrom(foundUser);
            }
            catch (ResourceException)
            {
                return null;
            }
        }

        public async Task<StormpathUser> FindByNameAsync(string userName)
        {
            var directory = await this.context.GetDirectory();

            var foundUser = await directory.GetAccounts()
                .Where(x => x.Username == userName)
                .SingleOrDefaultAsync();

            return StormpathUser.MapFrom(foundUser);
        }

        public Task<string> GetEmailAsync(StormpathUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(StormpathUser user)
        {
            return Task.FromResult(true);
        }

        public Task RemoveLoginAsync(StormpathUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(StormpathUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(StormpathUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(StormpathUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task UpdateAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }
    }
}
