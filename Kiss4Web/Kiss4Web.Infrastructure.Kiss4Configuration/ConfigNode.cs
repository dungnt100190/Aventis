namespace Kiss4Web.Infrastructure.Kiss4Configuration
{
    public class ConfigNode<T>
    {
        public ConfigNode(string keyPath, T defaultValue = default(T))
        {
            KeyPath = keyPath;
            DefaultValue = defaultValue;
        }

        public T DefaultValue { get; }

        public string KeyPath { get; }

        public override string ToString()
        {
            return KeyPath;
        }
    }
}