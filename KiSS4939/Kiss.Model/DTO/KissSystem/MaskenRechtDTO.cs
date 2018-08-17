namespace Kiss.Model.DTO.KissSystem
{
    public class MaskenRechtDTO
    {
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