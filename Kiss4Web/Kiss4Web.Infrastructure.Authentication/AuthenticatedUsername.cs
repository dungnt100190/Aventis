namespace Kiss4Web.Infrastructure.Authentication
{
    public class AuthenticatedUsername
    {
        private readonly string _username;

        public AuthenticatedUsername(string username)
        {
            _username = username;
        }

        public static implicit operator AuthenticatedUsername(string username)
        {
            return new AuthenticatedUsername(username);
        }

        public static implicit operator string(AuthenticatedUsername username)
        {
            return username._username;
        }
    }
}