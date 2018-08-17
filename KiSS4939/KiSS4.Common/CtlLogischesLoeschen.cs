using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Control für logisches löschen.
    /// Folgende Elemente sind enthalten:
    /// - Control CtlCreationModification (Info, wer den Datensatz erstellt und modifiziert hat).
    /// - CheckBox, ob der Datensatz gelöscht ist.
    /// - Button zum wiederherstellen des Datensatztes.
    /// </summary>
    public partial class CtlLogischesLoeschen : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_ISDELETED = "IsDeleted";

        #endregion

        #endregion

        #region Constructors

        public CtlLogischesLoeschen()
        {
            InitializeComponent();
            if(!IsLogischesLoeschen)
            {
                btnRestoreDocument.Visible = false;
            }
        }

        #endregion

        #region Events

        public event EventHandler RestoreClick;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the active SQL query.
        /// </summary>
        /// <value>The active SQL query.</value>
        public override SqlQuery ActiveSQLQuery
        {
            get { return base.ActiveSQLQuery; }
            set
            {
                ctlCreatorModifier.ActiveSQLQuery = value;
                base.ActiveSQLQuery = value;
                base.ActiveSQLQuery.PositionChanged += ActiveSQLQuery_PositionChanged;
                base.ActiveSQLQuery.AfterFill += ActiveSQLQuery_AfterFill;
            }
        }

        /// <summary>
        /// Property, ob logisch gelöscht werden soll.
        /// Siehe: System\Fallfuehrung\LogischesLoeschen
        /// </summary>
        public bool IsLogischesLoeschen
        {
            get
            {
                bool result = DBUtil.GetConfigBool(@"System\Fallfuehrung\LogischesLoeschen", false);
                return result;
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Der User hat eine neue Row im GridView angewählt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ActiveSQLQuery_PositionChanged(object sender, EventArgs e)
        {
            if (ActiveSQLQuery.Count > 0)
            {
                if (Utils.ConvertToBool(ActiveSQLQuery[COL_ISDELETED]))
                {
                    btnRestoreDocument.Enabled = true;
                }
                else
                {
                    btnRestoreDocument.Enabled = false;
                }
            }
            else
            {
                btnRestoreDocument.Enabled = false;
            }
        }

        /// <summary>
        /// Bei Displayproblemen.
        /// Erneuert das Enabled/Disabled vom Restore-Buttom.
        /// </summary>
        public void RefreshState()
        {
            ActiveSQLQuery_PositionChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Die Daten wurden von der Datenbank in
        /// das ActiveSQLQuery geladen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveSQLQuery_AfterFill(object sender, EventArgs e)
        {
            ActiveSQLQuery_PositionChanged(this, EventArgs.Empty);
        }

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            if(RestoreClick != null)
            {
               RestoreClick(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}