using Kiss.Interfaces.UI;

namespace Kiss.DbContext.DTO.KissSystem
{
    public class MaskenRechtDTO : IViewRight
    {
        public static MaskenRechtDTO Default
        {
            get
            {
                return new MaskenRechtDTO
                           {
                               CanDelete = false,
                               CanInsert = false,
                               CanUpdate = false
                           };
            }
        }

        #region Properties

        public bool CanDelete
        {
            get;
            set;
        }

        public bool CanInsert
        {
            get;
            set;
        }

        public bool CanUpdate
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            return string.Format("I:{0}, U:{1}, D:{2}", CanInsert, CanUpdate, CanDelete);
        }

        #endregion

        #endregion
    }
}