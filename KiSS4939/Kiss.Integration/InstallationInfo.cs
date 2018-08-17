using System;

using KiSS4.DB;

namespace Kiss.Integration
{
    public enum ProductType
    {
        /// <summary>
        /// Standard: 1
        /// </summary>
        Standard = 1,

        /// <summary>
        /// Pro Infirmis: 2
        /// </summary>
        PI = 2,

        /// <summary>
        /// Zürich: 3
        /// </summary>
        ZH = 3
    }

    public class InstallationInfo
    {
        private InstallationInfo(string ns, ProductType productType)
        {
            Namespace = ns;
            ProductType = productType;
        }

        public string Namespace
        {
            get;
            private set;
        }

        public ProductType ProductType
        {
            get;
            set;
        }

        public static InstallationInfo GetInstallationInfo()
        {
            var nameSpace = DBUtil.GetConfigString(@"System\Installation\Namespace", null);
            var productTypeInt = DBUtil.GetConfigInt(@"System\Installation\ProductType", 1);
            var productType = (ProductType)Enum.Parse(typeof(ProductType), productTypeInt.ToString());

            return new InstallationInfo(nameSpace, productType);
        }

        public bool HasNamespace(params string[] namespaces)
        {
            foreach (var ns in namespaces)
            {
                if (ns != null && ns.Equals(Namespace, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}