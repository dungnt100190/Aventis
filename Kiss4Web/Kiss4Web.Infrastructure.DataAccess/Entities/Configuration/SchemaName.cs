namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class SchemaName
    {
        private readonly string _content;

        public SchemaName(string connectionString)
        {
            _content = connectionString;
        }

        public static implicit operator string(SchemaName name)
        {
            return name._content;
        }

        public override string ToString()
        {
            return _content;
        }
    }
}