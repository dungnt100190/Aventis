namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class InsufficientPermissionException : ValidationException
    {
        public InsufficientPermissionException(string message)
            : base(message)
        {
        }
    }
}