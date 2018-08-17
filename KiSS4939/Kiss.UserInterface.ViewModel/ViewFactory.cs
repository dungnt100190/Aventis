using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Interfaces;

using IViewModel = Kiss.UserInterface.ViewModel.Interfaces.IViewModel;

namespace Kiss.UserInterface.ViewModel
{
    ///<summary>
    /// Factory for creating WPF View/ViewModels
    /// </summary>
    public class ViewFactory
    {
        private readonly IList<XClass> _wpfViewConfigurations;

        /// <summary>
        /// Creates a ViewFactory
        /// </summary>
        public ViewFactory()
        {
            var classService = Container.Resolve<XClassService>();
            _wpfViewConfigurations = classService.GetWpfViews();
        }

        public static bool IsViewModel(Type type)
        {
            return type != null && typeof(IViewModel).IsAssignableFrom(type);
        }

        /// <summary>
        /// Überprüft, ob ein Eintrag in der Tabelle "XClass" eine WPF Maske ist.
        /// </summary>
        /// <returns></returns>
        public static bool IsWpfView(Type type)
        {
            return type != null && typeof(UIElement).IsAssignableFrom(type);
        }

        /// <summary>
        /// Creates the View/ViewModel configured in the database with <paramref name="xClassID"/>
        /// </summary>
        /// <param name="xClassID">ID of view to create</param>
        /// <param name="initParameters">Common parameters for initialisation like BaPersonID, FaLeistungID</param>
        /// <param name="retryIfFailed">true: retry if the construction failed</param>
        /// <returns>View with intialised ViewModel</returns>
        public UIElement CreateView(int xClassID, InitParameters? initParameters = null, bool retryIfFailed = true)
        {
            var classEntry = _wpfViewConfigurations.FirstOrDefault(vew => vew.XClassID == xClassID);
            if (classEntry == null)
            {
                throw new ArgumentException(string.Format("Could not resolve XClassID {0}", xClassID), "xClassID");
            }
            var viewType = Type.GetType(classEntry.ClassName);
            var viewModelType = Type.GetType(classEntry.ClassNameViewModel);
            return CreateView(viewType, viewModelType, initParameters, retryIfFailed);
        }

        public int? GetClassID(string viewType)
        {
            var xclass = _wpfViewConfigurations.FirstOrDefault(cfg => cfg.ClassName == viewType);
            if (xclass != null)
            {
                return xclass.XClassID;
            }
            return null;
        }

        /// <summary>
        /// Creates a View/ViewModel using the types received via parameters
        /// </summary>
        /// <param name="viewType"><see cref="Type"/> of the View</param>
        /// <param name="viewModelType"><see cref="Type"/> of the ViewModel</param>
        /// <param name="initParameters">Common parameters for initialisation like BaPersonID, FaLeistungID</param>
        /// <param name="retryIfFailed">true: retry if the construction failed</param>
        /// <returns>View with intialised ViewModel</returns>
        private static UIElement CreateView(Type viewType, Type viewModelType, InitParameters? initParameters = null, bool retryIfFailed = true)
        {
            if (!IsWpfView(viewType) || !IsViewModel(viewModelType))
            {
                throw new SystemException(string.Format("Type of view '{0}' and type of viewmodel '{1}' cannot be used to construct a WPF view/viewmodel", viewType, viewModelType));
            }

            try
            {
                var view = Container.Resolve(viewType) as IViewWithViewModel;
                var viewModel = Container.Resolve(viewModelType) as IViewModel;

                if (viewModel != null && view != null)
                {
                    viewModel.Init(initParameters);
                    view.ViewModel = viewModel;
                }
                return view as UIElement;
            }
            catch (TargetInvocationException ex)
            {
                // Damit wir im Fehlerdialog eine aussagekräftigere Fehlermeldung anzeigen können.
                var innerException = ex.InnerException;

                if (innerException != null)
                {
                    if (retryIfFailed)
                    {
                        return CreateView(viewType, viewModelType, initParameters, false);
                    }
                    throw innerException;
                }
                throw;
            }
        }
    }
}