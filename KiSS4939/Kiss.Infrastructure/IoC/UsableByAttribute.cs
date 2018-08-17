using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kiss.Infrastructure.IoC
{
    public class UsableByAttribute : Attribute
    {
        #region Constructors

        public UsableByAttribute(params Type[] types)
        {
            Types = types;
        }

        #endregion

        #region Properties

        public string[] ClassNames
        {
            get;
            set;
        }

        public Type[] Types
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public string GetTypesString()
        {
            var types = new Collection<Type>(Types);
            var str = types.Aggregate(string.Empty, (current, type) => current + (type.Namespace + "." + type.Name + ", "));
            return str.Substring(0, str.Length - 2);
        }

        public bool IsUsableBy(Type type)
        {
            return Types.Contains(type) ||
                (ClassNames != null && ClassNames.Any(x => type.FullName != null && type.FullName.StartsWith(x)));
        }

        #endregion

        #endregion
    }
}