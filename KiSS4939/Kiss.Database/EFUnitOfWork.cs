using System;
using System.Data.Objects;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.Database
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        public ObjectContext Context { get; private set; }
        private bool _isDisposed = false;

        public EFUnitOfWork(ObjectContext context)
        {
            Context = context;
           _isDisposed = false;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
            StartTrackingAndMarkAsUnchangedAll();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                _isDisposed = true;
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public bool IsDisposed
        {
            get
            {
                return _isDisposed;
            }
        }

        public void StartTrackingAndMarkAsUnchangedAll()
        {
            Context.StartTrackingAndMarkAsUnchangedAll();
        }
    }
}
