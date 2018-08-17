using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using Kiss.BL;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;
using KiSS.Context;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.WordAutomation;
using KiSS4.Gui;
using KiSS4.Main;
using KiSS4.Messages;

using Application = System.Windows.Forms.Application;

namespace Kiss.Integration
{
    public class Initializer
    {
        public IEnumerable<ResourceDictionary> GetAppDictionaries()
        {
            return new[] { new ResourceDictionary { Source = new Uri("/DevExpress.Xpf.Themes.Kiss.v14.1;component/Themes/Constants.xaml", UriKind.Relative)},
                           new ResourceDictionary { Source = new Uri("/Kiss.UI.Controls;component/GlobalResources.xaml", UriKind.Relative)},
                           new ResourceDictionary { Source = new Uri("/Kiss.UI.Controls;component/Themes/Generic.xaml", UriKind.Relative)} };
        }

        public void Initialize(string connectionstring, string logonName, string password, int userID, bool singleSignOn, IKiss4MessageHandler messageHandler, IMessagePresenter messagePresenter)
        {
            //Let KiSS4 functionality know it is running inside KiSS 5
            Session.IsKiss5Mode = true;

            // Enable visual styles for Windows Forms Controls
            Application.EnableVisualStyles();

            // Supress ApplicationFacade.DoEvents() because it causes Exceptions in WindowsFormsHost
            ApplicationFacade.SuppressDoEvents = true;

            var environment = new Env("Kiss4Initializer", EnvType.Prod, connectionstring);

            // KiSS4.exe must be loaded explicitly as no project references it
            // we need types from this assembly. e.g. Kiss.Main.CtlFall
            Assembly.LoadFile(CreateKiss4Path("KiSS4.exe"));

            log4net.Config.XmlConfigurator.Configure();

            // wenn Session.MainForm == null ist, meint KiSS4, es sei läuft im Hintergrund und zeigt keine Fehlermeldungen an
            var dummyMainForm = new FrmMain();
            Session.MainForm = dummyMainForm;

            // use our own GridLocalizer and EditorLocalizer due to multilanguage!
            GridLocalizer.Active = new MyGridLocalizer();
            Localizer.Active = new MyEditorLocalizer();

            FormController.Kiss4MessageHandler = messageHandler;
            DlgInfo.MessagePresenter = messagePresenter;
            DlgError.MessagePresenter = messagePresenter;
            DlgQuestion.MessagePresenter = messagePresenter;
            DlgButtons.MessagePresenter = messagePresenter;
            KissNavBarUserControl.MessagePresenter = messagePresenter;

            Session.Open(environment, logonName, password, singleSignOn, userID);
            if (!Session.Active)
            {
                throw new ArgumentException("Could not open DB-Connection for KiSS4, check connectionstring, username/pwd");
            }

            AppContext.Init(Session.ConnectionString);

            // Register the window in the IoC container
            Container.RegisterInstance<IWin32Window>(dummyMainForm);

            // KiSS4.Main.App.InitializeIoCContainer()
            Container.RegisterInheritingTypes<ServiceBase>();

            Container.RegisterType<IWordControl, WordControl>(InstanceScope.PerResolve);
            Container.RegisterType<IExcelControl, ExcelControl>(InstanceScope.PerResolve);
        }

        private static string CreateKiss4Path(string assemblyName)
        {
            return Path.Combine(Session.ApplicationStartupPath, assemblyName);
        }
    }
}