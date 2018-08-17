using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Test.IoC.Classes;

namespace Kiss.Infrastructure.Test.IoC
{
    [TestClass]
    public class ContainerTest
    {
        #region Test Methods

        [TestMethod]
        public void InstanceScopeDefault()
        {
            // Re-Register the type
            Container.RegisterType<ITest, TestClass>(InstanceScope.PerResolve);
            Container.RegisterType<ITest, TestClass>();

            var obj1 = Container.Resolve<ITest>();
            var obj2 = Container.Resolve<ITest>();

            Assert.AreSame(obj1, obj2);
        }

        [TestMethod]
        public void InstanceScopePerResolve()
        {
            // Re-Register the type
            Container.RegisterType<ITest, TestClass>();
            Container.RegisterType<ITest, TestClass>(InstanceScope.PerResolve);

            var obj1 = Container.Resolve<ITest>();
            var obj2 = Container.Resolve<ITest>();

            Assert.AreNotSame(obj1, obj2);
        }

        [TestMethod]
        public void RegisterAndResolveInstance()
        {
            var obj = new TestClass();
            Container.RegisterInstance(obj);

            var result = Container.Resolve<TestClass>();
            Assert.AreSame(obj, result);
        }

        [TestMethod]
        public void RegisterAndResolveInstanceByInterface()
        {
            var obj = new TestClass();
            Container.RegisterInstance<ITest>(obj);

            var result = Container.Resolve<ITest>();
            Assert.AreSame(obj, result);
        }

        [TestMethod]
        public void RegisterAndResolveType()
        {
            Container.RegisterType<TestClass>();
            var result = Container.Resolve<TestClass>();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RegisterAndResolveTypeByInterface()
        {
            Container.RegisterType<ITest, TestClass>();
            var result = Container.Resolve<ITest>();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RegisterAndResolveTypeWithParameter()
        {
            Container.RegisterType<IParameter, ParameterClass>();
            Container.RegisterType<ITest, ParameterTestClass>();

            var result = Container.Resolve<ITest>();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ParameterTestClass));
            var paramResult = (ParameterTestClass)result;
            Assert.IsNotNull(paramResult.Parameter);
            Assert.IsNotNull(paramResult.Parameter.Value);
        }

        [TestMethod]
        public void RegisterAndResolveTypeWithSuppliedParameter()
        {
            Container.RegisterType<ITest, ParameterTestClass>();

            var param = new ParameterClass();
            var result = Container.Resolve<ITest>(param);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ParameterTestClass));
            var paramResult = (ParameterTestClass)result;
            Assert.IsNotNull(paramResult.Parameter);
            Assert.IsNotNull(paramResult.Parameter.Value);
            Assert.AreEqual(param, paramResult.Parameter);
        }

        [TestMethod]
        public void RegisterIoCEntry()
        {
            var parameterEntry = new IoCEntry
            {
                ConcreteTypeAssemblyName = "Kiss.Infrastructure.Test",
                ConcreteTypeName = "ParameterClass",
                ConcreteTypeNamespace = "Kiss.Infrastructure.Test.IoC.Classes",
                LookupTypeAssemblyName = "Kiss.Infrastructure.Test",
                LookupTypeName = "IParameter",
                LookupTypeNamespace = "Kiss.Infrastructure.Test.IoC.Classes",
                InstanceScope = InstanceScope.Singleton
            };

            var classEntry = new IoCEntry
            {
                ConcreteTypeAssemblyName = "Kiss.Infrastructure.Test",
                ConcreteTypeName = "ParameterTestClass",
                ConcreteTypeNamespace = "Kiss.Infrastructure.Test.IoC.Classes",
                LookupTypeAssemblyName = "Kiss.Infrastructure.Test",
                LookupTypeName = "ITest",
                LookupTypeNamespace = "Kiss.Infrastructure.Test.IoC.Classes",
                InstanceScope = InstanceScope.PerResolve
            };

            Container.RegisterEntry(parameterEntry);
            Container.RegisterEntry(classEntry);

            var obj1 = Container.Resolve<ITest>();
            var obj2 = Container.Resolve<ITest>();

            Assert.IsNotNull(obj1);
            Assert.IsNotNull(obj2);

            // Scope der Klasse ist PerResolve, es müssen also 2 Instanzen sein
            Assert.AreNotSame(obj1, obj2);

            // Scope des Parameter ist Singleton, es muss also die gleiche Instanz sein
            var p1 = (ParameterTestClass)obj1;
            var p2 = (ParameterTestClass)obj2;
            Assert.AreSame(p1.Parameter, p2.Parameter);
        }

        #endregion
    }
}