using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autofac;

namespace KiSS.Common.BL
{
    /// <summary>
    /// Base class for Services. The primary goal is to implement the Disposable pattern.
    /// A Dispose will also dispose all container gerated instances.
    /// </summary>
    public abstract class ServiceBase : IDisposable
    {
        #region Fields

        #region Private Fields

        private bool disposed = false;

        #endregion

        #endregion

        #region Constructors

        protected ServiceBase(IContainer container)
        {
            // disposing a inner cointainer will also dispose all container generated objects
            Context = container.CreateInnerContainer();
        }

        #endregion

        #region Destructor

        ~ServiceBase()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                if (disposing && Context != null)
                {
                    Context.Dispose();
                }
                disposed = true;
            }
        }

        #endregion

        #region Properties

        protected virtual IContainer Context
        {
            get; set;
        }

        #endregion
    }
}