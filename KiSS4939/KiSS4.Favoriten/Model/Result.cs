using KiSS4.Favoriten.Interface;

namespace KiSS4.Favoriten.Model
{
    public class Result : IResult
    {
        #region Properties

        public string ErrorMessage
        {
            get;
            set;
        }

        public bool WasOperationSuccessful
        {
            get;
            set;
        }

        #endregion
    }
}