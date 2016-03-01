using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stormpath.SDK.Client;
using Stormpath.SDK.Directory;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathContext : IDisposable
    {
        private static readonly string ApplicationHref = "https://api.stormpath.com/v1/applications/7Ol377HU068lagCYk7U9XS";

        private static readonly Lazy<IClient> client = new Lazy<IClient>(() => Clients.Builder().Build());

        public StormpathContext()
        {
        }

        public static StormpathContext Create()
        {
            return new StormpathContext();
        }

        public async Task<IDirectory> GetDirectory()
        {
            var application = await client.Value.GetApplicationAsync(ApplicationHref);
            var directory = await application.GetDefaultAccountStoreAsync() as IDirectory;

            return directory;
        }

        public IClient GetClient() => client.Value;

        public void Dispose()
        {
        }
    }
}
