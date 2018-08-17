using System;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for IKissContext.
    /// </summary>
    internal class KissContext : IKissContext
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IKissActiveSQLQuery _container;

        #endregion

        #endregion

        #region Constructors

        internal KissContext(IKissActiveSQLQuery container)
        {
            _container = container;
        }

        #endregion

        #region Events

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler onPrint;

        #endregion

        #region EventHandlers

        public static IKissContext GetParent_IKissContext(IKissActiveSQLQuery ctl)
        {
            if (ctl.Parent == null)
                return null;
            if (ctl.Parent is IKissContext)
                return (IKissContext)ctl.Parent;

            return GetParent_IKissContext(ctl.Parent);
        }

        public static IKissContext GetParent_IKissContext(Control ctl)
        {
            if (ctl.Parent == null)
                return null;
            if (ctl.Parent is IKissContext)
                return (IKissContext)ctl.Parent;

            return GetParent_IKissContext(ctl.Parent);
        }

        #endregion

        #region Methods

        #region Public Methods

        public string GetContextName()
        {
            return _container.GetType().Name;
        }

        public object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    // get current user
                    return Session.User.UserID;

                case "LANGUAGECODE":
                    // get current selected langugage
                    return Session.User.LanguageCode;

                default:
                    // get value from activesqlquery if defined and query contains desired column
                    if (_container.ActiveSQLQuery != null && _container.ActiveSQLQuery.DataTable.Columns.Contains(fieldName))
                    {
                        if (_container.ActiveSQLQuery.Count == 0)
                        {
                            return DBNull.Value;
                        }

                        return _container.ActiveSQLQuery[fieldName];
                    }

                    // get value from context defined in container-control
                    IKissContext parent = GetParent_IKissContext(_container);
                    if (parent != null)
                    {
                        return parent.GetContextValue(fieldName);
                    }

                    return DBNull.Value;
            }
        }

        public void PrintReport()
        {
            try
            {
                if (_container.ActiveControl is IKissContext)
                    ((IKissContext)_container.ActiveControl).PrintReport();
                else if (_container != _container.DetailControl && _container.DetailControl != null)
                    ((IKissContext)_container.DetailControl).PrintReport();
                else
                {
                    try { ((IKissDataNavigator)_container).SaveData(); }
                    catch { }
                    if (onPrint != null)
                        onPrint(this, EventArgs.Empty);
                    else
                        KissForm.GetKissMainForm().ContextPrint((IKissContext)_container, null);
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("IKissContext", "FehlerDrucken", "Fehler beim Drucken.", ex);
            }
        }

        #endregion

        #endregion
    }
}