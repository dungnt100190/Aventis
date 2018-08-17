namespace KiSS4.Favoriten.Interface
{
    public interface IResult
    {
        #region Properties

        string ErrorMessage
        {
            get;
            set;
        }

        bool WasOperationSuccessful
        {
            get;
            set;
        }

        #endregion
    }
}