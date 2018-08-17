using System;

namespace Kiss.DbContext
{
    public interface ILogischesLoeschenEntity
    {
        /// <summary>
        /// Flag für Logisches Löschen.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}