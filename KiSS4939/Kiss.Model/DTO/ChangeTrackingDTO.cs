using System.Runtime.Serialization;

namespace Kiss.Model.DTO
{
    public abstract class ChangeTrackingDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private ObjectChangeTracker _changeTracker;

        #endregion

        #endregion

        #region Properties

        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = GetChangeTracker() ?? new ObjectChangeTracker();
                }

                //make sure, ChangeTrackingEnabled is set to true, as this may be reset to false after F6 (UndoChanges)
                _changeTracker.ChangeTrackingEnabled = true;

                return _changeTracker;
            }
            set { _changeTracker = value; }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected abstract ObjectChangeTracker GetChangeTracker();

        #endregion

        #endregion
    }
}