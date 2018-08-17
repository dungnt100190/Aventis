using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.View.Common;

namespace Kiss.UserInterface.View
{
    public static class ViewBootstrapper
    {
        public static void RegisterTypes()
        {
            Container.RegisterType(typeof(IOpenFileService), typeof(OpenFileService));

        }
    }
}
