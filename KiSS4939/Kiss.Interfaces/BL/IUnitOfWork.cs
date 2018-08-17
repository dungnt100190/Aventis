using System;
using System.Data.Objects;

namespace Kiss.Interfaces.BL
{
    /// <summary>
    /// Unit of work interface
    /// The UnitOfWork defines a context for one or more repositories that kann be saved at the same time.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Returns true if the UnitOfWork / Context has already been disposed
        /// </summary>
        /// <returns></returns>
        bool IsDisposed
        {
            get;
        }

        /// <summary>
        /// SaveChanges
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Starts Change Tracking of all entities currently in the context of this UnitOfWork (and sets them to unchanged) 
        /// </summary>
        void StartTrackingAndMarkAsUnchangedAll();
    }
}