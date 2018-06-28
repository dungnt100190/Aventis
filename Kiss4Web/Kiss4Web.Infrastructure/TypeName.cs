namespace Kiss4Web.Infrastructure
{
    public struct TypeName
    {
        public TypeName(string typeName)
            : this()
        {
            Content = typeName;
        }

        public string Content { get; set; }
    }
}