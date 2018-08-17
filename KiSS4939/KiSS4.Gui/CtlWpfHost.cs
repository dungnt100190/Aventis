using System.Collections.Specialized;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using Kiss.UserInterface.ViewModel.Interfaces;

namespace KiSS4.Gui
{
    /// <summary>
    /// Containerklasse für Kiss WPF Controls.
    /// (Das sind von KissView abgeleitete WPF User-Controls).
    /// Mit der Methode SetKissControl kann man das WPF Element  "hosten".
    ///
    /// <example>Siehe z.B. <see cref="KissNavBarForm"/></example>
    /// </summary>
    public partial class CtlWpfHost : UserControl, IKissView
    {
        #region Constructors

        /// <summary>
        /// Erstellt und initialisiert eine WPF View.
        /// </summary>
        /// <param name="classID">ID in XClass der zu erstellenden Klasse</param>
        /// <param name="initParameters">IDs zum Initialisieren des ViewModels</param>
        /// <param name="retryIfFailed"> </param>
        /// <returns>Eine initialiserte Maske (ViewModel wurde auch initialisiert)</returns>
        public CtlWpfHost(int classID, InitParameters? initParameters = null, bool retryIfFailed = true)
        {
            InitializeComponent();
            var viewFactory = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>();
            var view = viewFactory.CreateView(classID, initParameters, retryIfFailed);
            elementHost.Child = view;
            elementHost.Dock = DockStyle.Fill;
            Dock = DockStyle.Fill;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Calls the BeforeCloseView methode of the ViewModel if it's set.
        /// Returns <c>true</c> if the View can be closed
        /// </summary>
        /// <returns><c>true</c> if the ViewModel is not set or the result of ViewModel.</returns>
        public virtual bool BeforeCloseView()
        {
            var view = elementHost.Child as IViewWithViewModel;
            if (view == null)
            {
                return true;
            }

            return view.ViewModel.BeforeCloseView();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Cleanup Elementhost
            //Sonst gibt es Memory-Leak.
            try
            {
                if (elementHost != null)
                {
                    // ReSharper disable RedundantCheckBeforeAssignment
                    if (elementHost.Child != null)
                    // ReSharper restore RedundantCheckBeforeAssignment
                    {
                        elementHost.Child = null;
                    }

                    elementHost.Dispose();
                    Controls.Clear();
                }
            }
            finally
            {
                elementHost = null;
                if (disposing && (components != null))
                {
                    components.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        //public override string GetContextName()
        //{
        //    var wpfControlContext = _wpfControl as IKissContext;
        //    string result = null;

        //    if (wpfControlContext != null)
        //    {
        //        result = wpfControlContext.GetContextName();
        //    }

        //    if (string.IsNullOrEmpty(result))
        //    {
        //        result = GetType().Name;
        //    }

        //    return result;
        //}

        //public override object GetContextValue(string fieldName)
        //{
        //    var wpfControlContext = _wpfControl as IKissContext;
        //    object result = DBNull.Value;

        //    if (wpfControlContext != null)
        //    {
        //        result = wpfControlContext.GetContextValue(fieldName);
        //    }

        //    return result;
        //}

        //public override bool ReceiveMessage(HybridDictionary parameters)
        //{
        //    //if _wpfControl is an IViewMessaging, we pass ReceiveMessage to _wpfControl
        //    var wpfControlMessaging = _wpfControl as IViewMessaging;
        //    var result = false;

        //    if (wpfControlMessaging != null)
        //    {
        //        result = wpfControlMessaging.ReceiveMessage(parameters);
        //    }

        //    if (!result)
        //    {
        //        result = base.ReceiveMessage(parameters);
        //    }

        //    return result;
        //}

        #endregion

        #endregion

        public Control Control
        {
            get { return this; }
        }

        public Control ParentControl
        {
            get { return Parent; }
            set { Parent = value; }
        }

        public bool HideView()
        {
            var result = BeforeCloseView();

            if (result)
            {
                Parent = null;
            }

            return result;
        }

        public bool JumpToPath(HybridDictionary parameters)
        {
            var view = elementHost.Child as IViewWithViewModel;
            if (view != null)
            {
                return view.ViewModel.JumpToPath(parameters);
            }

            return false;
        }

        public void ShowView()
        {
            //nop
        }
    }
}