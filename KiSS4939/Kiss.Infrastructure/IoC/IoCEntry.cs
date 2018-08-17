namespace Kiss.Infrastructure.IoC
{
    public class IoCEntry
    {
        #region Constructors

        public IoCEntry()
        {
            InstanceScope = Container.DEFAULT_SCOPE;
        }

        #endregion

        #region Properties

        public string ConcreteTypeAssemblyName
        {
            get;
            set;
        }

        public string ConcreteTypeName
        {
            get;
            set;
        }

        public string ConcreteTypeNamespace
        {
            get;
            set;
        }

        public InstanceScope InstanceScope
        {
            get;
            set;
        }

        public string LookupTypeAssemblyName
        {
            get;
            set;
        }

        public string LookupTypeName
        {
            get;
            set;
        }

        public string LookupTypeNamespace
        {
            get;
            set;
        }

        #endregion
    }
}