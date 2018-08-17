using System;

namespace Kiss.Infrastructure.Test.IoC.Classes
{
    class ParameterClass : IParameter
    {
        #region Constructors

        public ParameterClass()
        {
            Value = Guid.NewGuid().ToString();
        }

        #endregion

        #region Properties

        public string Value
        {
            get;
            private set;
        }

        #endregion
    }
}