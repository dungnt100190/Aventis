namespace Kiss.Model.DTO.KissSystem
{
    public class ZugriffRechtDTO
    {
        #region Properties

        public bool Archived
        {
            get;
            set;
        }

        public bool Closed
        {
            get;
            set;
        }

        public bool IsGuest
        {
            get;
            set;
        }

        public bool IsMember
        {
            get;
            set;
        }

        public bool IsOwner
        {
            get;
            set;
        }

        public bool IsUserAdmin
        {
            get;
            set;
        }

        public bool MayDelete
        {
            get;
            set;
        }

        public bool MayInsert
        {
            get;
            set;
        }

        public bool MayRead
        {
            get;
            set;
        }

        public bool MayUpdate
        {
            get;
            set;
        }

        public int ModulID
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AllMembersTo(bool status)
        {
            Archived = status;
            Closed = status;
            IsGuest = status;
            IsMember = status;
            IsOwner = status;
            IsUserAdmin = status;
            MayDelete = status;
            MayInsert = status;
            MayRead = status;
            MayUpdate = status;
        }

        #endregion

        #endregion
    }
}