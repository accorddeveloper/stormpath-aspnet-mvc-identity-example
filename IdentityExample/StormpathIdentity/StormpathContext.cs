using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.StormpathIdentity
{
    public class StormpathContext : IDisposable
    {
        public StormpathContext()
        {
            // do some stuff
        }

        public static StormpathContext Create()
        {
            return new StormpathContext();
        }

        public void Dispose()
        {
            // noop
        }
    }
}
