namespace Kiss4Web.Infrastructure.Authorization
{
    public class UserRightsCacheKey
    {
        private readonly int _userId;

        public UserRightsCacheKey(int userId)
        {
            _userId = userId;
        }

        public override bool Equals(object obj)
        {
            return obj is UserRightsCacheKey key &&
                   _userId == key._userId;
        }

        public override int GetHashCode()
        {
            return -566744556 + _userId.GetHashCode();
        }
    }
}