using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathUserStore : IUserStore<StormpathUser>,
        IUserLoginStore<StormpathUser>,
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

        public Task CreateAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<StormpathUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<StormpathUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<StormpathUser> FindByNameAsync(string userName)
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
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(StormpathUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(StormpathUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StormpathUser user)
        {
            throw new NotImplementedException();
        }
    }
}
