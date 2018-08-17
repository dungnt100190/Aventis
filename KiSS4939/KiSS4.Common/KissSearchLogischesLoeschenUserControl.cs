using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// BasisControl für das logische Löschen.
    /// </summary>
    public class KissSearchLogischesLoeschenUserControl : KissSearchUserControl
    {
        #region Enumerations

        /// <summary>
        /// The type of the Adressat (see "vwBaAdressate")
        /// </summary>
        private enum AdressatTyp
        {
            Person = 1,
            Institution = 2,
            PriMa = 3
        }

        #endregion

        #region Fields

        #region Protected Constant/Read-Only Fields

        protected const string DB_COL_IS_DELETED = "IsDeleted";

        #endregion

        #region Protected Fields

        protected int _baPersonId;
        protected int _faLeistungId;
        protected int _ownerUserId;
        protected KissRadioGroup radGrpDeleted;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "KissSearchLogischesLoeschenUserControl";

        #endregion

        #region Private Fields

        private bool _afterFillOnActiveSQLQueryAttached;
        private DevExpress.XtraGrid.Views.Grid.GridView _gridView;

        #endregion

        #endregion

        #region Constructors

        public KissSearchLogischesLoeschenUserControl()
        {
            InitializeComponentKiss();

            //if logical deletion is not supported, the radioGroup (nur aktive ...) and the restore button is invisible.
            if (!IsLogischesLoeschen)
            {
                radGrpDeleted.Visible = false;
            }
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// ACHTUNG, diese Methode ist nur für den Designer.
        /// </summary>
        private void InitializeComponent()
        {
            this.radGrpDeleted = new KiSS4.Gui.KissRadioGroup();
            this.tabControlSearch.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(769, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(793, 261);
            //
            // tpgListe
            //
            this.tpgListe.Size = new System.Drawing.Size(781, 223);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.radGrpDeleted);
            this.tpgSuchen.Size = new System.Drawing.Size(781, 223);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.radGrpDeleted, 0);
            //
            // radGrpDeleted
            //
            this.radGrpDeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radGrpDeleted.EditValue = 1D;
            this.radGrpDeleted.Location = new System.Drawing.Point(614, 54);
            this.radGrpDeleted.Name = "radGrpDeleted";
            this.radGrpDeleted.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.Columns = 1;
            this.radGrpDeleted.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1D, "nur aktive"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2D, "nur gelöschte"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0D, "alle")});
            this.radGrpDeleted.Size = new System.Drawing.Size(101, 86);
            this.radGrpDeleted.TabIndex = 67;
            //
            // KissSearchLogischesLoeschenUserControl
            //
            this.Name = "KissSearchLogischesLoeschenUserControl";
            this.Size = new System.Drawing.Size(799, 499);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).EndInit();
            this.ResumeLayout(false);
        }

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
                base.ActiveSQLQuery = value;
                if (base.ActiveSQLQuery != null)
                {
                    base.ActiveSQLQuery.PositionChanged -= qry_PositionChanged;
                    base.ActiveSQLQuery.PositionChanged += qry_PositionChanged;
                }
            }
        }

        /// <summary>
        /// GridView
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView GridView
        {
            get { return _gridView; }
            set
            {
                _gridView = value;
                if (_gridView != null)
                {
                    _gridView.CustomDrawCell -= gridView_CustomDrawCell;
                    _gridView.CustomDrawCell += gridView_CustomDrawCell;
                }
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
        ///   Hier wird eine Row in der GridView gvwDokumente eingefärbt.
        ///   Die gelöschten Einträge (Dokumente) sollen gemäss Spezifikation
        ///   rötlich eingefärbt werden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;

            if (_gridView.FocusedRowHandle == e.RowHandle)
            {
                return;
            }

            object isDeletedCellValue = _gridView.GetRowCellValue(e.RowHandle, _gridView.Columns[DB_COL_IS_DELETED]);
            bool isDeleted = Utils.ConvertToBool(isDeletedCellValue);

            if (isDeleted)
            {
                e.Appearance.BackColor = GuiConfig.GridRowLogischGeloeschtBackColor;
                e.Appearance.ForeColor = GuiConfig.GridRowLogischGeloeschtForeColor;
            }
            else
            {
                e.Appearance.BackColor = GuiConfig.GridRowEnabledBackColor;
                e.Appearance.ForeColor = GuiConfig.GridRowEnabledForeColor;
            }
        }

        /// <summary>
        /// Nur die nicht gelöschten Dokumente sollten editiert werden können.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void qry_PositionChanged(object sender, EventArgs e)
        {
            EnableFields();
        }

        private void ActiveSQLQuery_AfterFill(object sender, EventArgs e)
        {
            // check if we can do a Last()
            if (ActiveSQLQueryNotEmpty())
            {
                // select last entry (will perform a position changed)
                ActiveSQLQuery.Last();
            }
            EnableFields();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the AddressatID used for bookmarks such as "AdressatAdresseMehrzeilig" calulated from type
        /// </summary>
        /// <param name="qry">The query containing the id and columns</param>
        /// <param name="colNamePerson">The name of the column used for BaPersonID</param>
        /// <param name="colNameInstitution">The name of the column used for BaInstitutionID</param>
        /// <param name="colNamePriMa">The name of the column used for VmPriMaID</param>
        /// <returns>0 if no id was given or the matching AdressatID used for bookmarks</returns>
        public static int GetAdressatID(ref SqlQuery qry, string colNamePerson, string colNameInstitution, string colNamePriMa)
        {
            bool hasBaPersonID = !string.IsNullOrEmpty(colNamePerson) && !DBUtil.IsEmpty(qry[colNamePerson]);
            bool hasBaInstitutionID = !string.IsNullOrEmpty(colNameInstitution) && !DBUtil.IsEmpty(qry[colNameInstitution]);
            bool hasVmPriMaID = !string.IsNullOrEmpty(colNamePriMa) && !DBUtil.IsEmpty(qry[colNamePriMa]);

            if (hasBaPersonID)
            {
                return GetAdressatID(Convert.ToInt32(qry[colNamePerson]), AdressatTyp.Person);
            }

            if (hasBaInstitutionID)
            {
                return GetAdressatID(Convert.ToInt32(qry[colNameInstitution]), AdressatTyp.Institution);
            }

            if (hasVmPriMaID)
            {
                return GetAdressatID(Convert.ToInt32(qry[colNamePriMa]), AdressatTyp.PriMa);
            }

            return 0;
        }

        #endregion

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonId;
                case "FALEISTUNGID":
                    return _faLeistungId;
                case "OWNERUSERID":
                    return _ownerUserId;
            }

            return base.GetContextValue(fieldName);
        }

        public virtual void Init(string title, Image icon, int baPersonId, int faLeistungId)
        {
            _faLeistungId = faLeistungId;
            _baPersonId = baPersonId;

            var userID = DBUtil.ExecuteScalarSQL(@"
                SELECT UserID
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0};",
                faLeistungId);

            if (!DBUtil.IsEmpty(userID))
            {
                _ownerUserId = Utils.ConvertToInt(userID);
            }
        }

        /// <summary>
        /// Löscht einen Datensatz. Beim logischen Löschen wird das Flag "IsDeleted" (DbColumn)
        /// auf true gesetzt.
        /// </summary>
        /// <returns>Ob der Datensatz gelöscht werden konnte</returns>
        public override bool OnDeleteData()
        {
            if (IsLogischesLoeschen)
            {
                //check if the document is already deleted.
                //if yes, tell the user and stop further processing.
                if (Utils.ConvertToBool(ActiveSQLQuery[DB_COL_IS_DELETED]))
                {
                    KissMsg.ShowInfo(CLASSNAME, "RowAlreadyDeleted", "Dieser Datensatz ist bereits gelöscht.");
                    return false;
                }

                // Bei einem neuen Datensatz soll nicht gespeichert werden
                if (ActiveSQLQuery.CurrentRowState == DataRowState.Added)
                {
                    return base.OnDeleteData();
                }

                //User Fragen, ob er wirklich löschen will.
                if (KissMsg.ShowQuestion(CLASSNAME, "ConfirmDeleteRow", "Wollen Sie den Datensatz wirklich löschen?"))
                {
                    ActiveSQLQuery[DB_COL_IS_DELETED] = true;

                    if (ActiveSQLQuery.Post())
                    {
                        ActiveSQLQuery.Refresh();
                        return true;
                    }

                    return false;
                }

                return false;
            }

            return base.OnDeleteData();
        }

        /// <summary>
        ///  Stellt einen Datensatz wieder her.
        /// </summary>
        /// <returns></returns>
        public override bool OnRestoreData()
        {
            if (IsLogischesLoeschen)
            {
                if (!Utils.ConvertToBool(ActiveSQLQuery[DB_COL_IS_DELETED]))
                {
                    KissMsg.ShowInfo(CLASSNAME, "RowAlreadyRestored", "Dieser Datensatz ist bereits wiederhergestellt.");
                    return true;
                }

                ActiveSQLQuery[DB_COL_IS_DELETED] = false;
                ActiveSQLQuery.Refresh();

                return true;
            }

            return false;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// User presses F3 and enters new search values.
        /// </summary>
        protected override void NewSearch()
        {
            base.NewSearch();

            if (radGrpDeleted.EditValue == null)
            {
                // Defaultmässig ist "nur aktive" angewählt.
                radGrpDeleted.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        protected void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        /// <summary>
        /// Abgeleitete Klassen müssen diese Methode überschreiben, um
        /// die Eingabefelder zu Enablen oder zu Disablen.
        /// </summary>
        /// <param name="isActive">Ob der angewählte Datensatz (in der GridView) logisch gelöscht ist oder nicht</param>
        /// <param name="editMode">Ob die Controls Readonly oder Enabled sind (für Convenience)</param>
        protected virtual void OnEnableFields(bool isActive, EditModeType editMode)
        {
        }

        protected override void RunSearch()
        {
            if (!_afterFillOnActiveSQLQueryAttached && ActiveSQLQueryNotEmpty())
            {
                // (re)attach event
                ActiveSQLQuery.AfterFill -= ActiveSQLQuery_AfterFill;
                ActiveSQLQuery.AfterFill += ActiveSQLQuery_AfterFill;

                _afterFillOnActiveSQLQueryAttached = true;
            }

            // let base do search
            base.RunSearch();
        }

        protected void SetupRadioGroup(int rightMargin = 8)
        {
            radGrpDeleted.Left = radGrpDeleted.Parent.Width - radGrpDeleted.Width - rightMargin;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Get the AddressatID used for bookmarks such as "AdressatAdresseMehrzeilig" calulated from type
        /// </summary>
        /// <param name="adressatID">The id of the adressat (Person, Institution, PriMa)</param>
        /// <param name="adressatTyp">The type of the adressat (see "vwBaAdressate")</param>
        /// <returns>The changed AdressatID to fit rules used in bookmarks</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown in case of crossing range with other or invalid adressat-type</exception>
        private static int GetAdressatID(int adressatID, AdressatTyp adressatTyp)
        {
            if (adressatTyp == AdressatTyp.Person)
            {
                // positive (whole range)
                return adressatID;
            }

            if (adressatTyp == AdressatTyp.Institution)
            {
                // ensure valid range as this range is used only for PriMa
                if (adressatID >= 100000 && adressatID <= 199999)
                {
                    throw new ArgumentOutOfRangeException("adressatID", "The id was given as <Institution> and therefore cannot be between 100'000 and 199'999.");
                }

                // negative
                return -adressatID;
            }

            if (adressatTyp == AdressatTyp.PriMa)
            {
                // add 100'000
                adressatID = adressatID + 100000;

                // ensure valid range as only this range is used for PriMa
                if (adressatID < 100000 || adressatID > 199999)
                {
                    throw new ArgumentOutOfRangeException("adressatID", "The id was given as <PriMa> and therefore cannot be between 100'000 and 199'999.");
                }

                // negative
                return -adressatID;
            }

            // this case should never occure
            throw new ArgumentOutOfRangeException("adressatTyp", "The given type is not supported yet and therefore cannot be handled.");
        }

        #endregion

        #region Private Methods

        private bool ActiveSQLQueryNotEmpty()
        {
            return ActiveSQLQuery != null;
        }

        /// <summary>
        /// Stellt die Controls auf ReadOnly oder auf Normal,
        /// je nach dem, ob das Dokument logisch gelöscht worden ist.
        /// </summary>
        private void EnableFields()
        {
            bool isActive;

            if (Utils.ConvertToBool(ActiveSQLQuery[DB_COL_IS_DELETED], true))
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }

            EditModeType editMode;

            if (isActive)
            {
                editMode = EditModeType.Normal;
            }
            else
            {
                editMode = EditModeType.ReadOnly;
            }

            //OnEnableFields wird nur ausgeführt, wenn der
            //User update Rechte auf der Maske hat.
            //Das ActiveSQL Query wird die Felder automatisch disablen, wenn die Reche fehlen.
            if (HasUpdateRight())
            {
                OnEnableFields(isActive, editMode);
            }
        }

        /// <summary>
        /// Überprüft, ob der User Update Berechtigung zur Maske hat.
        /// </summary>
        /// <returns></returns>
        private bool HasUpdateRight()
        {
            string rightName = GetType().Name;
            bool mayRead;
            bool mayInsert;
            bool mayUpdate;
            bool mayDelete;

            Session.GetUserRight(rightName, out mayRead, out mayInsert, out mayUpdate, out mayDelete);

            return mayUpdate;
        }

        /// <summary>
        /// Diese Methode initialisiert UIElemente.
        /// </summary>
        private void InitializeComponentKiss()
        {
            radGrpDeleted = new KissRadioGroup();
            tabControlSearch.SuspendLayout();
            tpgSuchen.SuspendLayout();
            ((ISupportInitialize)(radGrpDeleted.Properties)).BeginInit();
            SuspendLayout();

            // tpgSuchen
            tpgSuchen.Controls.Add(radGrpDeleted);

            // radGrpDeleted
            radGrpDeleted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radGrpDeleted.EditValue = 1D;
            radGrpDeleted.Location = new Point(614, 54);
            radGrpDeleted.Name = "radGrpDeleted";
            radGrpDeleted.Properties.Appearance.BackColor = Color.Transparent;
            radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            radGrpDeleted.Properties.AppearanceDisabled.BackColor = Color.Transparent;
            radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            radGrpDeleted.Properties.Columns = 1;
            radGrpDeleted.Properties.Items.AddRange(new[]
                                                    {
                                                        new RadioGroupItem(1D, "nur aktive"),
                                                        new RadioGroupItem(2D, "nur gelöschte"),
                                                        new RadioGroupItem(0D, "alle")
                                                    });
            radGrpDeleted.Size = new Size(101, 86);
            radGrpDeleted.TabIndex = 67;

            // KissSearchLogischesLoeschenUserControl
            tabControlSearch.ResumeLayout(false);
            tpgSuchen.ResumeLayout(false);

            ((ISupportInitialize)(radGrpDeleted.Properties)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        #endregion
    }
}