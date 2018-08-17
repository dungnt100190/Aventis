using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;

namespace Kiss.Model
{
    /// <summary>
    /// Helper methods for reading the KiSS metamodel.
    /// </summary>
    public class MetaModelHelper
    {
        #region Fields

        #region Private Static Fields

        private static MetadataWorkspace _mws;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CONCEPTUAL_MODEL = "res://*/KiSS.csdl";

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// The Kiss MetadataWorkspace.
        /// </summary>
        private static MetadataWorkspace Worksapce
        {
            get { return _mws ?? (_mws = GetMetadataWorksapce()); }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Returns the name of the primary key property of the entity. 
        /// 
        /// If there is no primary property, it returns null.
        /// If there is more than one primary key property, it returns null.
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <returns>The name of the primary-Key property</returns>
        public static string GetPrimaryKeyProperty<T>()
        {
            var items = Worksapce.GetItems<EntityType>(DataSpace.CSpace);
            var itemX = items.Where(x => x.Name == typeof(T).Name).Single();

            if (itemX.KeyMembers.Count != 1)
            {
                return null;
            }

            return itemX.KeyMembers.Single().Name;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Creates a metadata-workspace. 
        /// Works without objectcontext.
        /// </summary>
        /// <returns>a newly created metadataworkspace.</returns>
        private static MetadataWorkspace GetMetadataWorksapce()
        {
            IList<string> paths = new List<string> { CONCEPTUAL_MODEL };
            IList<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return new MetadataWorkspace(paths, assemblies);
        }

        #endregion

        #endregion
    }
}