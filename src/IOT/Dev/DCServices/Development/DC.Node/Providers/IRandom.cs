using System;
using System.Security;

namespace DC.Node.Providers
{
    public interface IRandom
    {
        String CreatePrivateKey(Int32 keySize);
    }
}
