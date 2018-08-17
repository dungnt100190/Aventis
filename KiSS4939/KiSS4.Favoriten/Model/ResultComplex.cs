using KiSS4.Favoriten.Interface;

namespace KiSS4.Favoriten.Model
{
    public class ResultComplex<T> : Result, IResultComplex<T>
    {
        #region Properties

        public T Data
        {
            get;
            set;
        }

        #endregion
    }
}