namespace Kiss.Infrastructure.Test.IoC.Classes
{
    class ParameterTestClass : TestClass
    {
        #region Constructors

        public ParameterTestClass(IParameter parameter)
        {
            Parameter = parameter;
        }

        #endregion

        #region Properties

        public IParameter Parameter
        {
            get;
            private set;
        }

        #endregion
    }
}