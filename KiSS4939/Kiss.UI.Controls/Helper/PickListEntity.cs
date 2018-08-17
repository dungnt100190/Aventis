using System;

namespace Kiss.UI.Controls.Helper
{
    /// <summary>
    /// This is a single picklist entity of either the available or assigned rows
    /// </summary>
    public class PickListEntity
    {
        #region Constructors

        /// <summary>
        /// Creates a new <see cref="PickListEntity"/> instance
        /// </summary>
        /// <param name="entity">The entity to use for this single <see cref="PickListEntity"/></param>
        /// <param name="entityType">The type of the entity</param>
        /// <param name="propertyNameId">The property name used to get the id of the entity</param>
        /// <param name="propertyNameDisplayText">The property name used to get the display text of the entity</param>
        public PickListEntity(object entity, Type entityType, string propertyNameId, string propertyNameDisplayText)
        {
            var propertyInfoId = entityType.GetProperty(propertyNameId);
            var propertyInfoDisplayText = entityType.GetProperty(propertyNameDisplayText);

            if (propertyInfoId == null)
            {
                throw new ArgumentOutOfRangeException("propertyNameId", "Invalid propertyname of the entity type used to get the id");
            }

            if (propertyInfoDisplayText == null)
            {
                throw new ArgumentOutOfRangeException("propertyNameDisplayText", "Invalid propertyname of the entity type used to get the display text");
            }

            Entity = entity;
            Id = Convert.ToInt32(propertyInfoId.GetValue(entity, null));
            DisplayText = Convert.ToString(propertyInfoDisplayText.GetValue(entity, null));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the display text of the entity
        /// </summary>
        public string DisplayText
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the assigned entity
        /// </summary>
        public object Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the id of the entity
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        #endregion
    }
}