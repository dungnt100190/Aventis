using System;

namespace Kiss4Web.Infrastructure.Authentication
{
    public struct Login
    {
        public Login(IdentityProvider identityProvider, string identifier)
        {
            IdentityProvider = identityProvider;
            Identifier = identifier;
        }

        public string Identifier { get; }
        public IdentityProvider IdentityProvider { get; }

        public override string ToString()
        {
            return $"{Identifier} ({IdentityProvider})";
        }

        public static Login? Parse(string serialized)
        {
            var parts = serialized?.Split(new[] { '|' }, 2);
            if (parts == null || parts.Length < 2 || !Enum.TryParse(parts[0], out IdentityProvider identityProvider))
            {
                return null;
            }
            return new Login(identityProvider, parts[1]);
        }

        public string Serialize()
        {
            return $"{IdentityProvider}|{Identifier}";
        }
    }
}