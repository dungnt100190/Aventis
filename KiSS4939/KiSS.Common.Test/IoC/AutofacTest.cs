using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using Autofac.Builder;

namespace KiSS.Common.Test.IoC
{
    //könnte gebraucht werden, um alle services eines assemblies zu registrieren
    //    var builder = new ContainerBuilder();
    //var controllerTypes =
    //  from type in Assembly.Load("MyWebApp").GetTypes()
    //  where typeof(IController).IsAssignableFrom(type)
    //  select type;
    //foreach (var controllerType in controllerTypes)
    //  builder.Register(controllerType).FactoryScoped();
    internal interface IX
    {
    }

    [TestClass]
    public class AutofacTest
    {
        #region Test Methods

        [TestMethod]
        public void Autofac_ResolveNamedInstances_ShouldBeDifferentFromDefault()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder
                .Register<B>()
                .FactoryScoped();

            builder
                .Register<B>()
                .FactoryScoped()
                .Named("n");

            IContainer container = builder.Build();

            B bdefault = container.Resolve<B>();
            B bnamed = container.Resolve<B>("n");

            Assert.AreNotSame(bdefault, bnamed);
        }

        [TestMethod]
        public void Autofac_TwoContainerManagedResolve_should_be_the_same()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder
                .Register<Cx>()
                .ContainerScoped()
                .As<IX>();

            IContainer container = builder.Build();

            IX i1 = container.Resolve<IX>();
            IX i2 = container.Resolve<IX>();

            Assert.AreSame(i1, i2);
        }

        [TestMethod]
        public void inner_container_created_child_instances_should_be_disposed()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder
                .Register<Cx>()
                .ContainerScoped()    // Dispose : nicht SingletonScoped (default Scope)
                ;

            builder
                .Register<A>()      // A will create Cx
                .FactoryScoped()    // Dispose : nicht SingletonScoped (default Scope)
                ;

            IContainer container = builder.Build();

            A a;
            using (var inner = container.CreateInnerContainer())
            {
                a = inner.Resolve<A>();
                Assert.AreSame(a.CreateService(), inner.Resolve<Cx>());     // container Scoped
                Assert.AreEqual(a.IsServiceDisposed, false);
            }
            Assert.AreEqual(a.IsServiceDisposed, true);
        }

        [TestMethod]
        public void inner_container_created_instances_should_be_disposed_1()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder
                .Register<Cx>()
                .FactoryScoped()    // or ContainerScoped - nicht aber SingletonScoped
                ;

            IContainer container = builder.Build();

            Cx cx1;
            using (var inner = container.CreateInnerContainer())
            {
                cx1 = inner.Resolve<Cx>();
                Assert.AreEqual(cx1.Disposed, false);
            }
            Assert.AreEqual(cx1.Disposed, true);
        }

        #endregion
    }

    internal class A
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IContext _ctx;

        #endregion

        #region Private Fields

        private Cx _service;

        #endregion

        #endregion

        #region Constructors

        public A(IContext ctx)
        {
            _ctx = ctx;
        }

        #endregion

        #region Properties

        public bool IsServiceDisposed
        {
            get { return _service.Disposed; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public Cx CreateService()
        {
            _service = _ctx.Resolve<Cx>();
            return _service;
        }

        #endregion

        #endregion
    }

    internal class B
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _s;

        #endregion

        #endregion

        #region Constructors

        public B()
        {
            _s = DateTime.Now.Ticks.ToString();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            return _s;
        }

        #endregion

        #endregion
    }

    internal class Cx : IX, IDisposable
    {
        #region Fields

        #region Public Fields

        public bool Disposed; // public : just for the tests

        #endregion

        #endregion

        #region Destructor

        ~Cx()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!Disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }
                Disposed = true;
            }
        }

        #endregion
    }
}