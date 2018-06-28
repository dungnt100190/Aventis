namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class ErrorDto
    {
        public string Message { get; set; }

        public string PropertyName { get; set; }

        public Severity Severity { get; set; }
    }
}