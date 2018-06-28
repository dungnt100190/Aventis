namespace Kiss4Web.Infrastructure.DataAccess
{
    public class ConnectionString
    {
        private readonly string _content;

        public ConnectionString(string connectionString)
        {
            _content = connectionString;
        }

        public static implicit operator string(ConnectionString connectionString)
        {
            return connectionString._content;
        }

        public override string ToString()
        {
            return _content;
        }
    }
}