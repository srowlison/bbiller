using System;

namespace DC.Node.Providers
{
    public interface IPassword
    {
        //String CreatePassword();
        Byte[] CreatePassword();
    }
}
