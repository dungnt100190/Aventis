namespace Kiss4Web.Infrastructure.Authentication.UserId
{
    public interface IUserIdProvider
    {
        int? UserId { get; }
        bool IsUserAdmin { get; }
        bool IsUserSuperAdmin { get; }
    }
}