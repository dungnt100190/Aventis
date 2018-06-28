namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class ExceptionDTO
    {
        public string Message { get; set; }
        public string TypeFullname { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}