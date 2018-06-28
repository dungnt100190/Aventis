using System;

namespace Kiss4Web.Infrastructure.Authentication
{
    [Flags]
    public enum IdentityProvider
    {
        Windows = 1,
        Aventis = 2,
        AzureActiveDirectory = 3,
        None = 64,
    }
}