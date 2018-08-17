using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure.IoC;

namespace Kiss.Infrastructure.Test.IoC
{
    [TestClass]
    public class UsableByAttributeTest
    {
        #region Test Methods

        [TestMethod]
        public void GetTypesString()
        {
            var attribute = new UsableByAttribute(typeof(string), typeof(int));
            var typesString = attribute.GetTypesString();
            Assert.AreEqual("System.String, System.Int32", typesString);
        }

        [TestMethod]
        public void Usable()
        {
            var result = Container.Resolve<UsableClass>();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UsableUsingTypeString()
        {
            var result = Container.Resolve<UsableClassUsingTypeString>();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void NonUsable()
        {
            Container.Resolve<NonUsableClass>();
        }

        #endregion
    }

    [UsableBy(typeof(string))]
    class NonUsableClass
    {
    }

    [UsableBy(typeof(UsableByAttributeTest))]
    class UsableClass
    {
    }

    [UsableBy(ClassNames = new[] { "Kiss.Infrastructure.Test.IoC.UsableByAttributeTest" })]
    class UsableClassUsingTypeString
    {
    }
}