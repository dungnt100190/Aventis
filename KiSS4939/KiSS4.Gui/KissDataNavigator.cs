using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui.Properties;

using DevExpress.XtraEditors;

namespace KiSS4.Gui
{
    /// <summary>
    /// Implementation of IKissDataNavigator.
    /// </summary>
    public class KissDataNavigator : IKissDataNavigator
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Send event to DetailControl if one exists
        /// </summary>
        public bool PrefereDetailControl;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly IKissActiveSQLQuery _container;

        //for  message dialogs
        private const string DATA_NAVIGATOR = "IKissDataNavigator";

        //default message for message dialgos
        private const string DEFAULT_MESSAGE_ERROR_NAVIGATING = "Fehler beim Navigieren.";

        //for message dialogs
        private const string ERROR_NAVIGATING = "FehlerNavigieren";

        #endregion

        #region Private Fields

        private IKissDataNavigator _activeIKissDataNavigator;

        #endregion

        #endregion

        #region Constructors

        internal KissDataNavigator(IKissActiveSQLQuery container)
        {
            _container = container;
        }

        #endregion

        #region Events

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onAddData;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onDeleteData;

        /// <summary>
        ///  Eventhandler which is triggered when the user presses a shortcut. 
        /// </summary>
        public event KeyEventHandler onKeyDownKiss;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onMoveFirst;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onMoveLast;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onMoveNext;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onMovePrevious;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onRefreshData;

        /// <summary>
        ///  Eventhandler which is triggered when the user
        ///  wants to restore a logical deleted row. 
        /// </summary>
        public event EventHandler onResotreData;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onSaveData;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onSearch;

        /// <summary>
        /// TODO
        /// </summary>
        public event EventHandler onUndoDataChanges;

        #endregion

        #region Properties

        public IKissDataNavigator ActiveIKissDataNavigator
        {
            get
            {
                if (_activeIKissDataNavigator != null)
                {
                    return _activeIKissDataNavigator;
                }

                if (PrefereDetailControl && _container.DetailControl != null)
                {
                    return _container.DetailControl;
                }

                var kdn = GetActiveIKissDataNavigator(_container.ActiveControl as ContainerControl);

                return kdn ?? _container.DetailControl;
            }
            set { _activeIKissDataNavigator = value; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool AddData()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    return ActiveIKissDataNavigator.AddData();
                }

                if (_container.ActiveSQLQuery != null)
                {
                    return (_container.ActiveSQLQuery.Insert() != null);
                }

                if (onAddData != null)
                {
                    onAddData(this, EventArgs.Empty);
                }

                return true;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerDatensatzEinfuegen", "Datensatz kann nicht eingefügt werden.", ex);
            }

            return false;
        }

        public bool DeleteData()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    return ActiveIKissDataNavigator.DeleteData();
                }

                if (_container.ActiveSQLQuery != null)
                {
                    return _container.ActiveSQLQuery.Delete();
                }

                if (onDeleteData != null)
                {
                    onDeleteData(this, EventArgs.Empty);
                }

                return true;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerDatensatzLoeschen", "Datensatz kann nicht gelöscht werden.", ex);
            }

            return false;
        }

        /// <summary>
        /// To handel the KeyDown event in child-controls
        /// </summary>
        /// <param name="keyEvent">the <see cref="KeyEventArgs"/> that the user has pressed</param>
        /// <returns>true if the key could be handeld, else false</returns>
        public bool KeyDownKiss(KeyEventArgs keyEvent)
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    return ActiveIKissDataNavigator.KeyDownKiss(keyEvent);
                }

                if (onKeyDownKiss != null)
                {
                    onKeyDownKiss(this, keyEvent);
                }

                return true;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerKeyDown", "Ein Fehler mit dieser Tastenkombination ist aufgetretten.", ex);
            }

            return false;
        }

        public void MoveFirst()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.MoveFirst();
                    return;
                }

                if (_container.ActiveSQLQuery != null)
                {
                    SpecificPreMoveHandlingForActiveControl(_container.ActiveControl);
                    _container.ActiveSQLQuery.First();
                    return;
                }

                if (onMoveFirst != null)
                {
                    onMoveFirst(this, EventArgs.Empty);
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, ERROR_NAVIGATING, DEFAULT_MESSAGE_ERROR_NAVIGATING, ex);
            }
        }

        public void MoveLast()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.MoveLast();
                    return;
                }

                if (_container.ActiveSQLQuery != null)
                {
                    SpecificPreMoveHandlingForActiveControl(_container.ActiveControl);
                    _container.ActiveSQLQuery.Last();
                    return;
                }

                if (onMoveLast != null)
                {
                    onMoveLast(this, EventArgs.Empty);
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, ERROR_NAVIGATING, DEFAULT_MESSAGE_ERROR_NAVIGATING, ex);
            }
        }

        public void MoveNext()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.MoveNext();
                    return;
                }

                if (_container.ActiveSQLQuery != null)
                {
                    SpecificPreMoveHandlingForActiveControl(_container.ActiveControl);
                    _container.ActiveSQLQuery.Next();
                    return;
                }

                if (onMoveNext != null)
                {
                    onMoveNext(this, EventArgs.Empty);
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, ERROR_NAVIGATING, DEFAULT_MESSAGE_ERROR_NAVIGATING, ex);
            }
        }

        public void MovePrevious()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.MovePrevious();
                    return;
                }

                if (_container.ActiveSQLQuery != null)
                {
                    SpecificPreMoveHandlingForActiveControl(_container.ActiveControl);
                    _container.ActiveSQLQuery.Previous();
                    return;
                }

                if (onMovePrevious != null)
                {
                    onMovePrevious(this, EventArgs.Empty);
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, ERROR_NAVIGATING, DEFAULT_MESSAGE_ERROR_NAVIGATING, ex);
            }
        }

        public void RefreshData()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.RefreshData();
                }
                else
                {
                    if (_container.ActiveSQLQuery != null)
                    {
                        _container.ActiveSQLQuery.Refresh();
                    }
                    else
                    {
                        if (onRefreshData != null)
                        {
                            onRefreshData(this, EventArgs.Empty);
                        }
                    }
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerAktualisieren", "Fehler beim Aktualisieren.", ex);
            }
        }

        /// <summary>
        /// Restores a logical deleted row.
        /// </summary>
        /// <returns>If the row could be restored (success). False in case of failure.</returns>
        public bool RestoreData()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    return ActiveIKissDataNavigator.RestoreData();
                }

                if (onResotreData != null)
                {
                    onResotreData(this, EventArgs.Empty);
                }

                return true;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerDatensatzWiederherstellen", "Datensatz kann nicht wieder hergestellt werden (Logisches Löschen).", ex);
            }

            return false;
        }

        public bool SaveData()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    return ActiveIKissDataNavigator.SaveData();
                }

                if (_container.ActiveSQLQuery != null)
                {
                    SpecificPreSaveHandlingForActiveControl(_container.ActiveControl);
                    return _container.ActiveSQLQuery.Post();
                }

                if (onSaveData != null)
                {
                    onSaveData(this, EventArgs.Empty);
                }

                return true;
            }
            catch (OptimisticConcurrencyException)
            {
                if (KissMsg.ShowButtonDlg(Resources.OptimisticConcurrency_Message, new[] { Resources.Cancel, Resources.Refresh }) == 1)
                {
                    RefreshData();
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerDatensatzSpeichern", "Datensatz kann nicht gespeichert werden.", ex);
            }

            return false;
        }

        public void Search()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.Search();
                }
                else
                {
                    if (onSearch != null)
                    {
                        onSearch(this, EventArgs.Empty);
                    }
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerSuchen", "Fehler beim Suchen.", ex);
            }
        }

        public void UndoDataChanges()
        {
            try
            {
                if (ActiveIKissDataNavigator != null)
                {
                    ActiveIKissDataNavigator.UndoDataChanges();
                }
                else
                {
                    if (_container.ActiveSQLQuery != null)
                    {
                        _container.ActiveSQLQuery.Cancel();
                    }
                    else
                    {
                        if (onUndoDataChanges != null)
                        {
                            onUndoDataChanges(this, EventArgs.Empty);
                        }
                    }
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(DATA_NAVIGATOR, "FehlerUndo", "Fehler beim Rückgängigmachen von Änderungen.", ex);
            }
        }

        #endregion

        #region Private Static Methods

        private static IKissDataNavigator GetActiveIKissDataNavigator(ContainerControl ctl)
        {
            if (ctl == null || ctl is IKissDataNavigator)
            {
                return ctl as IKissDataNavigator;
            }

            return GetActiveIKissDataNavigator(ctl.ActiveControl as ContainerControl);
        }

        private static BaseEdit GetBaseEditInVisualTree(Control ctl)
        {
            if (ctl is BaseEdit)
            {
                return ctl as BaseEdit;
            }

            return ctl.Parent == null ? null : GetBaseEditInVisualTree(ctl.Parent);
        }

        private static void SpecificPreMoveHandlingForActiveControl(Control parentControl)
        {
            ValidateActiveChildControl(parentControl);
        }

        private static void SpecificPreSaveHandlingForActiveControl(Control parentControl)
        {
            ValidateActiveChildControl(parentControl);
        }

        private static void ValidateActiveChildControl(Control parentControl)
        {
            if (parentControl == null)
            {
                return;
            }

            var baseEdit = GetBaseEditInVisualTree(parentControl);

            if (baseEdit != null)
            {
                // due to problem when saving data without moving focus out of control, we need to validate (apply editvalue to datasource) before saving
                // >> problem occures mainly in KissDateEdit (see #8037)
                // >> see KissView for similar WPF version
                baseEdit.DoValidate();
            }
        }

        #endregion

        #endregion
    }
}