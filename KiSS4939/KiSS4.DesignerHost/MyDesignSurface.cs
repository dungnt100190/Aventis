using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;

namespace KiSS4.DesignerHost
{
    public class MyDesignSurface : DesignSurface, IServiceContainer, IDesignerEventService
    {
        public MyDesignSurface()
        {
            this.AddServices();
        }

        public MyDesignSurface(IServiceProvider parentProvider) : base(parentProvider)
        {
            this.AddServices();
        }

        private void AddServices()
        {
            this.AddService(typeof(IDesignerEventService), this);  // Show Events in Property-Tab

            // And services that we demand create.
            ServiceCreatorCallback callback = new ServiceCreatorCallback(this.OnCreateService);

            ReplaceService(typeof(ITypeDescriptorFilterService), callback);
            ReplaceService(typeof(ISelectionService), callback);
            ReplaceService(typeof(IToolboxService), callback);
            ReplaceService(typeof(IMenuCommandService), callback);
        }

        private void ReplaceService(Type serviceType, ServiceCreatorCallback callback)
        {
            this.ServiceContainer.RemoveService(serviceType);
            this.ServiceContainer.AddService(serviceType, callback);
        }

        private void ReplaceService(Type serviceType, object serviceInstance)
        {
            this.ServiceContainer.RemoveService(serviceType);
            this.ServiceContainer.AddService(serviceType, serviceInstance);
        }

        /// Creates some of the more infrequently used services
        private object OnCreateService(IServiceContainer container, Type serviceType)
        {
            // Create SelectionService
            if (serviceType == typeof(ITypeDescriptorFilterService))
            {
                return new MyTypeDescriptorFilterService(this.GetService(typeof(IDesignerHost)) as IDesignerHost);
            }
            else if (serviceType == typeof(ISelectionService))
            {
                return new MySelectionService((IDesignerHost)this.GetService(typeof(IDesignerHost)));
            }
            else if (serviceType == typeof(IToolboxService))
            {
                return new MyToolboxService(this.GetService(typeof(IDesignerHost)) as IDesignerHost);
            }
            else if (serviceType == typeof(IMenuCommandService))
            {
                return new MyMenuCommandService(this);
            }

            Debug.Fail("Service type " + serviceType.FullName + " requested but we don't support it");
            return null;
        }


        public IDesigner GetDesigner(System.ComponentModel.IComponent component)
        {
            return ((IDesignerHost)this.GetService(typeof(IDesignerHost))).GetDesigner(component);
        }

        public System.ComponentModel.IComponent RootComponent
        {
            get { return ((IDesignerHost)this.GetService(typeof(IDesignerHost))).RootComponent; }
        }

        protected override object CreateInstance(Type type)
        {
            IToolboxService toolBox = (IToolboxService)this.GetService(typeof(IToolboxService));
            MyToolboxItem toolBoxItem = null;

            if (this.IsLoaded)
            {
                if (toolBox != null)
                    toolBoxItem = toolBox.GetSelectedToolboxItem() as MyToolboxItem;

                if (toolBoxItem != null && toolBoxItem.Type == type && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    type = typeof(Gui.KissLabel);
            }

            object obj = base.CreateInstance(type);

            if (toolBoxItem != null)
                toolBoxItem.SetProperty(obj);

            return obj;
        }

        protected override void OnLoaded(LoadedEventArgs e)
        {
            base.OnLoaded(e);

            foreach (Component cmp in this.ComponentContainer.Components)
            {
                
                PropertyDescriptor prop = TypeDescriptor.GetProperties(cmp)["Locked"];
                if (prop != null)
                    prop.SetValue(cmp, false);
            }
        }

        /// The IDesignerEventService is responsible for designer events. Since we have only
        /// our one designer host, we always return it when asked for the ActiveDesigner or
        /// Designers. 
        #region Implementation of IDesignerEventService

        public DesignerCollection Designers
        {
            get
            {
                return new DesignerCollection(new IDesignerHost[] { this.ActiveDesigner });
            }
        }

        public event System.ComponentModel.Design.DesignerEventHandler DesignerDisposed;

        public IDesignerHost ActiveDesigner
        {
            get { return this.GetService(typeof(IDesignerHost)) as IDesignerHost; }
        }

        public event System.ComponentModel.Design.DesignerEventHandler DesignerCreated;

        public event System.ComponentModel.Design.ActiveDesignerEventHandler ActiveDesignerChanged;

        public event System.EventHandler SelectionChanged;

        #endregion

        #region IServiceContainer Members

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
        {
            this.ServiceContainer.AddService(serviceType, callback, promote);
        }

        public void AddService(Type serviceType, ServiceCreatorCallback callback)
        {
            this.ServiceContainer.AddService(serviceType, callback);
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            this.ServiceContainer.AddService(serviceType, serviceInstance, promote);
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            this.ServiceContainer.AddService(serviceType, serviceInstance);
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            this.ServiceContainer.RemoveService(serviceType, promote);
        }

        public void RemoveService(Type serviceType)
        {
            this.ServiceContainer.RemoveService(serviceType);
        }

        #endregion
    }
}
