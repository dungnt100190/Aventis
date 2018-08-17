namespace KiSS4.Favoriten.Interface
{
    public interface IResultComplex<T> : IResult
    {
        #region Properties

        T Data
        {
            get;
            set;
        }

        #endregion
    }
}