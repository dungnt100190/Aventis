namespace Kiss.BusinessLogic.Sys.NodeEnumeration
{
    public class ConfigNode<T>
    {
        private readonly T _defaultValue;
        private readonly string _keyPath;

        public ConfigNode(string keyPath, T defaultValue = default(T))
        {
            _keyPath = keyPath;
            _defaultValue = defaultValue;
        }

        public T DefaultValue
        {
            get { return _defaultValue; }
        }

        public string KeyPath
        {
            get { return _keyPath; }
        }

        public override string ToString()
        {
            return _keyPath;
        }
    }
}