using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Gui
{
    #region Enumerations

    /// <summary>
    /// Modul ID.
    /// </summary>
    public enum ModulID
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Basis.
        /// </summary>
        B = 1,

        /// <summary>
        /// Fallführung.
        /// </summary>
        F = 2,

        /// <summary>
        /// Sozialhilfe.
        /// </summary>
        S = 3,

        /// <summary>
        /// Inkasso.
        /// </summary>
        I = 4,

        /// <summary>
        /// Vormundschaft.
        /// </summary>
        V = 5,

        /// <summary>
        /// Asyl.
        /// </summary>
        A = 6,

        /// <summary>
        /// Arbeit.
        /// </summary>
        K = 7,

        /// <summary>
        /// Fallsteuerung
        /// </summary>
        Fs = 26,

        /// <summary>
        /// Kindes- und Erwachsenenschutz
        /// </summary>
        Kes = 29
    }

    #endregion

    /// <summary>
    /// Interface for a persistent object.
    /// </summary>
    public interface IKissPersistentObject
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the object could be released.
        /// </summary>
        bool ObjectDisposed
        {
            get;
        }

        /// <summary>
        /// Infos about the object.
        /// </summary>
        string ObjectName
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether changes are pending.
        /// </summary>
        /// <value><c>true</c> if [pending changes]; otherwise, <c>false</c>.</value>
        bool PendingChanges
        {
            get;
        }

        #endregion
    }

    /// <summary>
    /// Base class for the main form.
    /// </summary>
    public class KissMainForm : KissForm
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// List of persistent objects.
        /// </summary>
        /// TODO: replace this with a list that is really readonly.
        public readonly ArrayList PersistentObjects = Session.PersistentObjects;

        #endregion

        #region Private Static Fields

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "KissMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// When overridden in a derived class, prints the context.
        /// </summary>
        /// <param name="cp">The cp.</param>
        /// <param name="queryName">Name of the query.</param>
        public virtual void ContextPrint(IKissContext cp, string queryName)
        {
            return;
        }

        /// <summary>
        /// Gets the child form.
        /// </summary>
        /// <param name="childFormType">Type of the child form.</param>
        /// <returns></returns>
        public KissChildForm GetChildForm(Type childFormType)
        {
            if (childFormType == null)
            {
                throw new ArgumentNullException("childFormType");
            }

            if (!childFormType.IsSubclassOf(typeof(KissChildForm)))
            {
                throw new ArgumentException(string.Format("'{0}' is not a subclass of KissChildForm.", childFormType));
            }

            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == childFormType)
                {
                    return (KissChildForm)frm;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the Fallverlauf tree.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use FormController instead")]
        public object GetTreeFall()
        {
            return FormController.GetMessage("FrmFall", false, "Action", "CurrentModulTree");
        }

        /// <summary>
        /// Check if className is type of FrmDataExplorer (inherited)
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from FrmDataExplorer, otherwise false</returns>
        public virtual bool IsClassTypeOfFrmDataExplorer(string className)
        {
            return false;
        }

        /// <summary>
        /// Check if className is type of IContainerForm
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if class implements IContainerForm, otherwise false</returns>
        public virtual bool IsClassTypeOfIContainerForm(string className)
        {
            return false;
        }

        /// <summary>
        /// Check if className is type of NavBarForm (inherited)
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from NavBarForm, otherwise false</returns>
        public virtual bool IsClassTypeOfNavBarForm(string className)
        {
            return false;
        }

        /// <summary>
        /// When overridden in a derived class, loads menu items.
        /// </summary>
        public virtual void LoadMenuItems()
        {
            return;
        }

        /// <summary>
        /// Opens a <see cref="KissChildForm"/>) of a given Type or activates it if it is already instantiated.
        /// </summary>
        /// <returns></returns>
        public KissChildForm OpenChildForm(Type childFormType)
        {
            KissChildForm frm = GetChildForm(childFormType);

            if (frm != null)
            {
                frm.Activate();
                return frm;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // get parameterleess ConstructorInfo
                ConstructorInfo ci = childFormType.GetConstructor(new Type[0]);

                if (ci == null)
                {
                    throw new ArgumentException(childFormType + " has no public parameterless instance constructor.");
                }

                // create new instance
                frm = (KissChildForm)ci.Invoke(new object[0]);
                frm.MdiParent = this;

                // init flag
                bool wasFromClosingDisabled = false;

                try
                {
                    // disable closing of form and get flag
                    wasFromClosingDisabled = UtilsGui.DisableCloseForm(frm);

                    // show form
                    frm.Show();
                }
                finally
                {
                    // enable closing again
                    UtilsGui.EnableCloseFrom(frm, wasFromClosingDisabled);
                }

                return frm;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("KissMainForm", "FensterLadenNichtMoeglich", "Dieses Fenster kann nicht geladen werden", ex);
                return null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Opens a dialog to correct duplicated organisation entries.
        /// </summary>
        /// <param name="baInstitutionID_A">The BaInstitutionID of first institution</param>
        /// <param name="baInstitutionID_B">The BaInstitutionID of second institution</param>
        /// <returns></returns>
        [Obsolete("Use FormController instead")]
        public virtual bool ShowDoubleOrganisation(int baInstitutionID_A, int baInstitutionID_B)
        {
            return FormController.OpenForm("FrmDataCorrection",
                                           "Action", "ShowDoubleOrganisation",
                                           "BaInstitutionID_A", baInstitutionID_A,
                                           "BaInstitutionID_B", baInstitutionID_B);
        }

        /// <summary>
        /// Opens a dialog to correct duplicated person entries.
        /// </summary>
        /// <param name="baPersonID_A">The BaPersonID of first person</param>
        /// <param name="baPersonID_B">The BaPersonID of second person</param>
        /// <returns></returns>
        [Obsolete("Use FormController instead")]
        public virtual bool ShowDoublePerson(int baPersonID_A, int baPersonID_B)
        {
            return FormController.OpenForm("FrmDataCorrection",
                                           "Action", "ShowDoublePerson",
                                           "BaPersonID_A", baPersonID_A,
                                           "BaPersonID_B", baPersonID_B);
        }

        /// <summary>
        /// Open the case window
        /// </summary>
        /// <param name="baPersonID">The ba person ID.</param>
        /// <param name="modul">The modul.</param>
        /// <returns>True if case was successfully opened</returns>
        [Obsolete("Use FormController instead")]
        public bool ShowFall(int baPersonID, ModulID modul)
        {
            return FormController.OpenForm("FrmFall",
                                           "Action", "ShowFall",
                                           "BaPersonID", baPersonID,
                                           "ModulID", modul);
        }

        /// <summary>
        /// When overridden in a derived class, shows the item.
        /// </summary>
        /// <param name="modul">The modul.</param>
        /// <param name="context">The context.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [Obsolete("Use FormController instead")]
        public virtual bool ShowItem(ModulID modul, string context, int key)
        {
            return false;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!SavePersistentObjects(true))
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        /// <summary>
        /// Saves the persistent objects.
        /// </summary>
        /// <returns></returns>
        protected bool SavePersistentObjects(bool isClosing)
        {
            return ShutdownHelper.SavePersistentObjects(isClosing);
        }

        #endregion

        #endregion
    }
}