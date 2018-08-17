using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure.IoC;

namespace Kiss.BL.Test
{
    [TestClass]
    public class ParameterInjectionTest
    {
        #region Nested Interfaces

        private interface ITestService
        {
            #region Properties

            string Value
            {
                get;
            }

            #endregion
        }

        #endregion

        #region Properties

        public TestContext TestContext
        {
            get;
            set;
        }

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Container.RegisterType<TestService1>();
            Container.RegisterType<ITestService, TestService2>();
        }

        [TestMethod]
        public void ResolveParameter()
        {
            var service = Container.Resolve<TestService1>();

            Assert.IsNotNull(service);
            Assert.IsNotNull(service.Parameter);
            Assert.IsInstanceOfType(service.Parameter, typeof(TestService2));
            Assert.AreEqual("TEST", service.Parameter.Value);
        }

        #endregion

        #region Nested Types

        private class TestService1
        {
            #region Constructors

            private TestService1(ITestService parameter)
            {
                Parameter = parameter;
            }

            #endregion

            #region Properties

            public ITestService Parameter
            {
                get;
                private set;
            }

            #endregion
        }

        private class TestService2 : ITestService
        {
            #region Constructors

            private TestService2()
            {
                Value = "TEST";
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

        #endregion
    }
}