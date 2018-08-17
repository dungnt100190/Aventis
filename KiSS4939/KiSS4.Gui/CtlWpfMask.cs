using System;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;

namespace KiSS4.Gui
{
    /// <summary>
    /// Containerklasse für Kiss WPF Controls.
    /// (Das sind von KissView abgeleitete WPF User-Controls).
    /// Mit der Methode SetKissControl kann man das WPF Element  "hosten". 
    /// 
    /// <example>Siehe z.B. <see cref="KissNavBarForm"/></example>
    /// </summary>
    public partial class CtlWpfMask : KissUserControl
    {
        #region Fields

        #region Private Fields

        private IKissDataNavigator _wpfControl;
        //private ISearchable

        #endregion

        #endregion

        #region Constructors

        public CtlWpfMask()
        {
            InitializeComponent();
        }

        #endregion

        #region Dispose

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
                // ReSharper disable RedundantCheckBeforeAssignment
                if (elementHost.Child != null)
                // ReSharper restore RedundantCheckBeforeAssignment
                {
                    elementHost.Child = null;
                }
                elementHost.Dispose();
            }
            catch
            {
                elementHost = null;
            }
            finally
            {
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

        public override string GetContextName()
        {
            var wpfControlContext = _wpfControl as IKissContext;
            string result = null;

            if (wpfControlContext != null)
            {
                result = wpfControlContext.GetContextName();
            }

            if (string.IsNullOrEmpty(result))
            {
                result = GetType().Name;
            }

            return result;
        }

        public override object GetContextValue(string fieldName)
        {
            var wpfControlContext = _wpfControl as IKissContext;
            object result = DBNull.Value;

            if (wpfControlContext != null)
            {
                result = wpfControlContext.GetContextValue(fieldName);
            }

            return result;
        }

        /// <summary>
        /// Adds a new entity on wpf-control
        /// </summary>
        /// <returns><c>True</c> if having wpf control and success, otherwise <c>False</c></returns>
        public override bool OnAddData()
        {
            return _wpfControl != null && _wpfControl.AddData();
        }

        /// <summary>
        /// Deletes current entity on wpf-control
        /// </summary>
        /// <returns><c>True</c> if no wpf control or success, otherwise <c>False</c></returns>
        public override bool OnDeleteData()
        {
            return _wpfControl == null || _wpfControl.DeleteData();
        }

        public override bool OnKeyDownKiss(KeyEventArgs e)
        {
            return _wpfControl == null || _wpfControl.KeyDownKiss(e);
        }

        public override void OnMoveFirst()
        {
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.MoveFirst();
        }

        public override void OnMoveLast()
        {
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.MoveLast();
        }

        public override void OnMoveNext()
        {
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.MoveNext();
        }

        public override void OnMovePrevious()
        {
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.MovePrevious();
        }

        public override void OnRefreshData()
        {
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.RefreshData();
        }

        public override bool OnRestoreData()
        {
            return _wpfControl == null || _wpfControl.RestoreData();
        }

        /// <summary>
        /// Saves pending changes on wpf-control
        /// </summary>
        /// <returns><c>True</c> if no wpf control or success, otherwise <c>False</c></returns>
        public override bool OnSaveData()
        {
            return _wpfControl == null || _wpfControl.SaveData();
        }

        public override void OnSearch()
        {
            // Ist nur nötig, solange nicht alle WPF-Masken NavigationCommands.Search abfangen
            // Vorsicht vor doppelten Search-Aufrufen!
            if (_wpfControl == null)
            {
                return;
            }

            _wpfControl.Search();
        }

        public override void OnUndoDataChanges()
        {
            if (_wpfControl != null)
            {
                _wpfControl.UndoDataChanges();
            }
            else
            {
                var crudOperator = GetChildControlInterface<IDataCrudOperatorAsync>();
                if (crudOperator != null)
                {
                    crudOperator.UndoDataChanges().Wait();
                }
            }

        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            //if _wpfControl is an IViewMessaging, we pass ReceiveMessage to _wpfControl
            var wpfControlMessaging = _wpfControl as IViewMessaging;
            var result = false;

            if (wpfControlMessaging != null)
            {
                result = wpfControlMessaging.ReceiveMessage(parameters);
            }

            if (!result)
            {
                result = base.ReceiveMessage(parameters);
            }

            return result;
        }

        /// <summary>
        /// Erstellt und initialisiert eine WPF View.
        /// </summary>
        /// <param name="typeName">Der Klassennamen mit .xaml am Ende (vollständig, z.B. Kiss.UI.View.Vm.VmKlientenBudgetView.xaml).</param>
        /// <param name="initParameters">IDs zum Initialisieren des ViewModels</param>
        /// <returns>Eine initialiserte Maske (ViewModel wurde auch initialisiert)</returns>
        public static CtlWpfMask CreateWpfView(string typeName, InitParameters? initParameters = null)
        {
            var type = AssemblyLoader.GetType(typeName);
            return CreateWpfView(type, initParameters);
        }

        /// <summary>
        /// Erstellt und initialisiert eine WPF View.
        /// </summary>
        /// <param name="type">Der Typ der XAML View (z.B. Kiss.UI.View.Vm.VmKlientenBudgetView.xaml).</param>
        /// <param name="initParameters">IDs zum Initialisieren des ViewModels</param>
        /// <param name="retryIfFailed"> </param>
        /// <returns>Eine initialiserte Maske (ViewModel wurde auch initialisiert)</returns>
        public static CtlWpfMask CreateWpfView(Type type, InitParameters? initParameters = null, bool retryIfFailed = true)
        {
            var ctl = new CtlWpfMask();

            if (type == null)
            {
                return ctl;
            }

            if (!IsWpfView(type))
            {
                throw new Exception("Keine Wpf Klasse");
            }

            var constructorInfo = type.GetConstructor(new Type[0]);
            object view;
            try
            {
                view = constructorInfo.Invoke(new object[0]);

                dynamic dynamicView = view;

                if (initParameters != null)
                {
                    // HACK: Übergangslösung, bis alle Views IViewWithViewModel implementieren, danach diesen Code löschen
                    // kann den falschen Wert lieferen wegen bisheriger impliziter Logik
                    var value = initParameters.Value.BaPersonID ??
                                initParameters.Value.FaLeistungID ??
                                initParameters.Value.FaFallID ??
                                0;
                    if (type.FullName == "Kiss.UI.View.Vm.VmKlientenbudgetView") // HACK: Klientenbudget-Maske ist die einzige Maske die FaLeistungID als Param erwartet
                    {
                        value = initParameters.Value.FaLeistungID ?? 0;
                    }

                    dynamicView.InitViewAndViewModel(value);
                }
                else
                {
                    dynamicView.InitViewAndViewModel();
                }
            }
            catch (SqlException)
            {
                if (retryIfFailed)
                {
                    return CreateWpfView(type, initParameters, false);
                }
                throw;
            }
            catch (TargetInvocationException ex)
            {
                // Damit wir im Fehlerdialog eine aussagekräftigere Fehlermeldung anzeigen können.
                var innerException = ex.InnerException;

                if (innerException != null)
                {
                    if (retryIfFailed)
                    {
                        return CreateWpfView(type, initParameters, false);
                    }
                    throw innerException;
                }
                throw;
            }
            ctl.SetKissControl(view as UIElement);
            return ctl;
        }

        /// <summary>
        /// Überprüft, ob ein Eintrag in der Tabelle "XClass" eine WPF Maske ist.
        /// </summary>
        /// <returns></returns>
        public static bool IsWpfView(Type type)
        {
            if (type != null && (typeof(CtlWpfMask).IsAssignableFrom(type) || typeof(UIElement).IsAssignableFrom(type)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Überprüft, ob ein Eintrag in der Tabelle "XClass" eine WPF Maske ist.
        /// </summary>
        /// <returns></returns>
        public static bool IsWpfView(string typeName)
        {
            var type = AssemblyLoader.GetType(typeName);
            return IsWpfView(type);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialisiert die KissView und zeigt sie an.
        /// </summary>
        /// <param name="kissView">Instanz einer Subklasse von KissView</param>
        private void SetKissControl(UIElement kissView)
        {
            elementHost.Child = kissView;
            _wpfControl = kissView as IKissDataNavigator;
        }

        private TInterface GetChildControlInterface<TInterface>()
            where TInterface : class
        {
            var result = _wpfControl as TInterface;
            if (result != null)
            {
                return result;
            }

            return null;
        }

        #endregion

        #endregion
    }
}