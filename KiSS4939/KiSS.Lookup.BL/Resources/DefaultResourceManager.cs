using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace KiSS.Lookup.BL.Resources
{
    public class DefaultResourceManager : ResourceManager
    {
        public DefaultResourceManager()
            : base("KiSS.Lookup.BL.Resources.Messages", typeof(DefaultResourceManager).Assembly)
        {
        }

        public const string IsNull = "isNull_error";
        public const string IdIsNotUnique = "idIsNotUnique_error";
        public const string IdAlreadyExists = "idAlreadyExsists_error";
        public const string IsEmpty = "isEmpty_error";
        public const string IsInvalid = "isInvalid_error";

        private static Func<ResourceManager> resourceManagerFunc = () => new DefaultResourceManager();

        public static ResourceManager Current
        {
            get { return resourceManagerFunc(); }
        }

        public static void SetResourceManagerProvider(Func<ResourceManager> resouceManagerProvider)
        {
            resourceManagerFunc = resouceManagerProvider;
        }
    }
}