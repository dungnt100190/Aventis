namespace Kiss4Web.Infrastructure.Authentication.UserId
{
    public class AuthenticatedUserId
    {
        private readonly int _userId;

        public AuthenticatedUserId(int userId)
        {
            _userId = userId;
        }

        //public static AuthenticatedUserId Empty => new AuthenticatedUserId(Guid.Empty);

        //public bool IsUnknown => _userId == Guid.Empty;

        public static implicit operator AuthenticatedUserId(int id)
        {
            return new AuthenticatedUserId(id);
        }

        public static implicit operator int? (AuthenticatedUserId id)
        {
            return id._userId;
        }

        public override string ToString()
        {
            return _userId.ToString();
        }
    }
}