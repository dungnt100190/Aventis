using System;

namespace Kiss.Interfaces.BL
{
    public interface IValidating<T>
    {
        #region Properties

        Func<T, KissServiceResult> Validator
        {
            get; set;
        }

        #endregion
    }
}