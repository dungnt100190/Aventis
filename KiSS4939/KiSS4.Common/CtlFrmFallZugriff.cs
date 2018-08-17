using System;
using System.Data;
using System.Globalization;

using KiSS.DBScheme;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    public partial class CtlFrmFallZugriff : KissUserControl
    {
        private const string CLASSNAME = "CtlFrmFallZugriff";
        private int _faLeistungID;
        private bool _HasOwnerChanged = false; // flag if owner has changed and therefore tree and detailcontrol have to be refreshed

        private CtlFrmFallZugriff()
        {
            InitializeComponent();
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFrmFallZugriff"/> class.
        /// </summary>
        /// <param name="faLeistungID">The id within table FaLeistung.</param>
        public CtlFrmFallZugriff(int faLeistungID)
        {
            _faLeistungID = faLeistungID;

            // this call is required by the Windows Form Designer.
            InitializeComponent();

            // fill query
            qryFall.Fill(_faLeistungID);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the Load event of the CtlFallZugriff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void CtlFrmFallZugriff_Load(object sender, System.EventArgs e)
        {
            // Mutieren darf: Owner, Admin oder Benutzer mit 'U'-Recht (Update) auf FaLeistungZugriff
            bool canUpdate = Session.User.IsUserAdmin ||
                            (qryFall.Count > 0 && Convert.ToInt32(qryFall["UserID"]) == Session.User.UserID) ||
                            (DBUtil.UserHasRight(CLASSNAME, "U"));

            this.qryFall.CanUpdate = canUpdate;
            this.qryZugeteilt.CanInsert = canUpdate;
            this.qryZugeteilt.CanUpdate = canUpdate;
            this.qryZugeteilt.CanDelete = canUpdate;

            DBUtil.ApplyFallRightsToSqlQuery((int)qryFall["FaLeistungID"], qryZugeteilt);

            btnSetOwner.Visible = qryZugeteilt.CanUpdate;
            btnAdd.Visible = qryZugeteilt.CanUpdate;
            btnRemove.Visible = qryZugeteilt.CanUpdate;
            gridVerfuegbar.Visible = qryZugeteilt.CanUpdate;
            lblFilter.Visible = qryZugeteilt.CanUpdate;
            edtFilter.Visible = qryZugeteilt.CanUpdate;

            if (qryZugeteilt.CanUpdate)
            {
                gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            }
            else
            {
                gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
                lblFB.Left = lblDatumVon.Left;
                editOwnerSAR.Left = edtDatumVon.Left;
                gridZugeteilt.Left = edtDatumVon.Left;
            }

            this.Width = gridZugeteilt.Left + gridZugeteilt.Width + 15;
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (qryFall.Count == 0 || qryKandidaten.Count == 0)
            {
                return;
            }

            if (!qryFall.Post())
            {
                return;
            }

            Session.BeginTransaction();
            qryZugeteilt.Insert();
            qryZugeteilt["FaLeistungID"] = qryFall["FaLeistungID"];
            qryZugeteilt["UserID"] = qryKandidaten["UserID"];
            qryZugeteilt["DarfMutieren"] = false;
            qryZugeteilt["DatumVon"] = FallUtil.GetFaLeistungZugriffNewDatumVon();
            qryZugeteilt["DatumBis"] = FallUtil.GetFaLeistungZugriffNewDatumBis();

            qryZugeteilt.Post();
            UpdateFaLeistungZugriffVerknuepft(Convert.ToInt32(qryZugeteilt["FaLeistungID"]),
                                        Convert.ToInt32(qryZugeteilt["UserID"]),
                                        true, //isInsert
                                        false, //isUpdate
                                        false, //isBool
                                        Convert.ToBoolean(qryZugeteilt["DarfMutieren"]),
                                        Convert.ToDateTime(qryZugeteilt["DatumVon"]),
                                        Convert.ToDateTime(qryZugeteilt["DatumBis"]));
            Session.Commit();

            DisplayAccessUsers();
        }

        /// <summary>
        /// Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (qryZugeteilt.Count == 0)
            {
                return;
            }

            Session.BeginTransaction();

            if (Convert.ToDateTime(qryZugeteilt["DatumVon"]) <= DateTime.Today)
            {
                //Fall : Diese Zuständigkeit war bis heute gültig : DatumBis setzen. Dieser Datensatz wird protokolliert.

                qryZugeteilt["DatumBis"] = DateTime.Today;
                qryZugeteilt.Post();

                UpdateFaLeistungZugriffVerknuepft(Convert.ToInt32(qryZugeteilt["FaLeistungID"]),
                                        Convert.ToInt32(qryZugeteilt["UserID"]),
                                        false, //isInsert
                                        true, //isUpdate
                                        false, //isDelete
                                        Convert.ToBoolean(qryZugeteilt["DarfMutieren"]),  //darfMutieren
                                        Convert.ToDateTime(qryZugeteilt["DatumVon"]),
                                        Convert.ToDateTime(qryZugeteilt["DatumBis"]));
            }
            else
            {
                //Fall : Diese Zuständigkeit war noch nicht gültig, es mach kein Sinn eine Zustängkeit zu behalten, die nie gültig war. Der Datensatz wird dann gelöscht.
                UpdateFaLeistungZugriffVerknuepft(Convert.ToInt32(qryZugeteilt["FaLeistungID"]),
                                        Convert.ToInt32(qryZugeteilt["UserID"]),
                                        false, //isInsert
                                        false, //isUpdate
                                        true, //isDelete
                                        Convert.ToBoolean(qryZugeteilt["DarfMutieren"]), //darfMutieren
                                        Convert.ToDateTime(qryZugeteilt["DatumVon"]),
                                        Convert.ToDateTime(qryZugeteilt["DatumBis"]));
                qryZugeteilt.Delete();
            }

            Session.Commit();

            DisplayAccessUsers();
        }

        /// <summary>
        /// Handles the Click event of the btnSetOwner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSetOwner_Click(object sender, System.EventArgs e)
        {
            if (qryKandidaten.Count == 0)
            {
                return;
            }

            if (qryFall.Count == 0)
            {
                return;
            }

            int newReceiver = Convert.ToInt32(qryKandidaten["UserID"]);
            int oldReceiver = Convert.ToInt32(qryFall["UserID"]);
            int faLeistungID = Convert.ToInt32(qryFall["FaLeistungID"]);

            //Pendenzen umhaengen: Nur offene Pendezen mit altem SAR als Empfaenger werden umgehängt
            //prüfen, ob unerledigte Pendenzen existieren, die umgehaengt werden muessen
            if (DBUtil.GetConfigBool(@"System\Pendenzen\Pendenzenverwaltung\FragenVorWechselLV", false))
            {
                //taskstatuscode 3 = erledigt
                int countUnerledigte = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(*)
                        FROM dbo.XTask WITH(READUNCOMMITTED)
                        WHERE FaLeistungID = {0}
                        AND TaskStatusCode <> 3
                        AND ReceiverID = {1}",
                        faLeistungID, oldReceiver);

                if (countUnerledigte > 0)
                {
                    //Bei Nein im Dialog -> abbrechen
                    if (!KissMsg.ShowQuestion(CLASSNAME, "DlgWechselLeistungsverantwortung", FallUtil.LV_WECHSEL_PENDENZEN_FRAGE))
                    {
                        return;
                    }
                }
            }

            Utils.InsertFaLeistungUserHist(faLeistungID);

            qryFall["UserID"] = qryKandidaten["UserID"];
            qryFall["SAR"] = qryKandidaten["UserName"];
            qryFall.Post();

            // assigns pending tasks to the new SAR
            int assignedTasks = Utils.AssignPendingTasksToNewReceiver(newReceiver, oldReceiver, faLeistungID.ToString(CultureInfo.InvariantCulture));

            if (assignedTasks == 1)
            {
                KissMsg.ShowInfo(CLASSNAME, "OneInfoTaskMoved", "1 offene Pendenz wurde dem neuen SAR zugewiesen.");
            }
            else if (assignedTasks > 1)
            {
                KissMsg.ShowInfo(CLASSNAME, "MultipleInfoTasksMoved", "{0} offene Pendenzen wurden dem neuen SAR zugewiesen.", assignedTasks);
            }

            // set flag
            _HasOwnerChanged = true;
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            string value = "";
            if (!DBUtil.IsEmpty(edtFilter.EditValue))
                value = edtFilter.EditValue.ToString();

            qryKandidaten.DataTable.DefaultView.RowFilter = "UserName LIKE '%" + value + "%'";
        }

        /// <summary>
        /// Handles the DoubleClick event of the gridVerfuegbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void gridVerfuegbar_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.btnAdd.Enabled)
            {
                this.btnAdd.PerformClick();
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the gridVerfuegbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void gridVerfuegbar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar < 'A' || e.KeyChar > 'z')
            {
                return;
            }

            for (int i = 0; i < qryKandidaten.Count; i++)
            {
                string UserName = qryKandidaten.DataTable.Rows[i]["UserName"].ToString();

                if (UserName.ToUpper().StartsWith(e.KeyChar.ToString().ToUpper()))
                {
                    qryKandidaten.Position = i;
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Handles the AfterPost event of the qryFall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFall_AfterPost(object sender, System.EventArgs e)
        {
            Session.Commit();
            qryZugeteilt.Post(); //save pending changes
        }

        /// <summary>
        /// Handles the BeforePost event of the qryFall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFall_BeforePost(object sender, System.EventArgs e)
        {
            // Bei verknüpften Leistungen die andere auch updaten falls CascadeDelete = true ist
            var faLeistungID = Convert.ToInt32(qryFall[DBO.FaLeistung.FaLeistungID]);
            var cascadeUpdateFaLeistung = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                                                    SELECT CascadeUpdate
                                                    FROM dbo.FaRelation WITH(READUNCOMMITTED)
                                                    WHERE FaLeistungID1 = {0}
                                                       OR FaLeistungID2 = {0}",
                                                    faLeistungID));

            Session.BeginTransaction();

            if (cascadeUpdateFaLeistung)
            {
                // andere FaLeistung udaten
                DBUtil.ExecSQL(@"UPDATE FaLeistung SET UserID = {0} WHERE FaLeistungID = (
                                                            SELECT FaLeistungID = CASE
                                                                                    WHEN FaLeistungID1 = {1} THEN FaLeistungID2
                                                                                    ELSE FaLeistungID1
                                                                                  END
                                                            FROM dbo.FaRelation WITH (READUNCOMMITTED)
                                                            WHERE FaLeistungID1 = {1}
                                                            OR FaLeistungID2 = {1});",
                               qryFall[DBO.FaFall.UserID],
                               faLeistungID);
            }

            qryZugeteilt.Post(); //save pending changes
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryFall control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFall_PositionChanged(object sender, System.EventArgs e)
        {
            DisplayAccessUsers();
        }

        /// <summary>
        /// Handles the ColumnChanged event of the qryZugeteilt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Data.DataColumnChangeEventArgs"/> instance containing the event data.</param>
        private void qryZugeteilt_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            qryFall.RowModified = true;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Translate()
        {
            base.Translate();

            // setup title of form
            if (Session.User.IsUserBIAGAdmin)
            {
                Text = string.Format("{0} - FaLeistungID={1}", this.Text, _faLeistungID);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the access users.
        /// </summary>
        private void DisplayAccessUsers()
        {
            //geschlossene Fälle dürfen den Besitzer noch wechseln, archivierte nicht mehr
            bool enable = (qryFall.Count > 0 && !Convert.ToBoolean(qryFall["Archiviert"]));

            btnSetOwner.Enabled = enable;
            btnAdd.Enabled = enable;
            btnRemove.Enabled = enable;

            qryZugeteilt.Fill(qryFall["FaLeistungID"]);
            qryKandidaten.Fill(qryFall["FaLeistungID"]);
        }

        /// <summary>
        /// Leistungen updaten weil via FaRelation mehrere Leistungen upgedated werden müssen
        /// </summary>
        /// <param name="faLeistungID">FaLeistungID welche man schon hat</param>
        /// <param name="userID">UserID des zu berechtigenden Benutzers</param>
        /// <param name="isDelete">Leistungen löschen</param>
        /// <param name="isUpdate">Leistungen mit den Daten in Parameter aktualisieren</param>
        /// <param name="isInsert">Neue Leistungen einfügen</param>
        /// <param name="darfMutieren">Wenn ein Insert, dann muss noch angegeben werden ob man mutieren kann</param>
        /// <param name="datumVon">Anfang der Gültigkeit</param>
        /// <param name="datumBis">End der Gültigkeit</param>
        private void UpdateFaLeistungZugriffVerknuepft(int faLeistungID, int userID, bool isInsert, bool isUpdate, bool isDelete, bool darfMutieren, DateTime datumVon, DateTime datumBis)
        {
            var cascadeUpdateFaLeistung =
                Convert.ToBoolean(
                    DBUtil.ExecuteScalarSQL(
                        @"SELECT CascadeUpdate
                              FROM dbo.FaRelation WITH(READUNCOMMITTED)
                              WHERE FaLeistungID1 = {0}
                                 OR FaLeistungID2 = {0}",
                        faLeistungID));

            if (cascadeUpdateFaLeistung)
            {
                // andere FaLeistung holen
                var id2 = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT FaLeistungID = CASE
                                                                                            WHEN FaLeistungID1 = {0} THEN FaLeistungID2
                                                                                            ELSE FaLeistungID1
                                                                                          END
                                                                    FROM dbo.FaRelation WITH (READUNCOMMITTED)
                                                                    WHERE FaLeistungID1 = {0}
                                                                    OR FaLeistungID2 = {0};",
                                                                    faLeistungID));
                if (isDelete)
                {
                    DBUtil.ExecSQL(@"DELETE FROM FaLeistungZugriff WHERE FaLeistungID = {0} AND UserID = {1};", id2, userID);
                }

                if (isInsert)
                {
                    DBUtil.ExecSQL(@"INSERT INTO FaLeistungZugriff (FaLeistungID, UserID, DarfMutieren, DatumVon, DatumBis) VALUES ({0}, {1}, {2}, {3}, {4})", id2, userID, darfMutieren, datumVon, datumBis);
                }

                if (isUpdate)
                {
                    DBUtil.ExecSQL(@"UPDATE FaLeistungZugriff SET DarfMutieren = {0}, DatumVon = {1}, DatumBis = {2} WHERE FaLeistungID = {3} AND UserID = {4}", darfMutieren, datumVon, datumBis, id2, userID);
                }
            }
        }

        #endregion

        #endregion

        public bool ControlClosing()
        {
            bool isCancel = false;
            qryZugeteilt.EndCurrentEdit(true);
            if (qryZugeteilt.RowModified)
            {
                isCancel = !qryZugeteilt.Post();
            }

            // check if owner has changed
            if (_HasOwnerChanged)
            {
                // refresh tree and detailcontrol (only if CtlFaBeratungsphase)
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                FormController.SendMessage("FrmFall",
                                           "Action", "RefreshControl",
                                           "ControlName", "CtlFaBeratungsperiode");
            }

            return isCancel;
        }

        private void qryZugeteilt_BeforePost(object sender, EventArgs e)
        {
            DateTime? datumVon = DBUtil.IsEmpty(qryZugeteilt[colDatumVon.FieldName])
                ? (DateTime?)null
                : Convert.ToDateTime(qryZugeteilt[colDatumVon.FieldName]);

            DateTime? datumBis = DBUtil.IsEmpty(qryZugeteilt[colDatumBis.FieldName])
                ? (DateTime?)null
                : Convert.ToDateTime(qryZugeteilt[colDatumBis.FieldName]);

            DateTime? datumVonOld = qryZugeteilt.Row.HasVersion(DataRowVersion.Original)
                                    ? DBUtil.IsEmpty(qryZugeteilt[colDatumVon.FieldName, DataRowVersion.Original])
                                        ? (DateTime?)null
                                        : Convert.ToDateTime(qryZugeteilt[colDatumVon.FieldName, DataRowVersion.Original])
                                     : null;

            if (datumVon == null)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridZugeteiltDatumVonLeer", "DatumVon darf nicht leer sein.");
                throw new KissCancelException();
            }
            if (datumVonOld != null && datumVonOld != datumVon && datumVonOld < DateTime.Today)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridZugeteiltDatumVonNichtAendern", "DatumVon darf nicht mehr verändert werden.");
                throw new KissCancelException();
            }
            if (datumVonOld != datumVon && datumVon < DateTime.Today)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridZugeteiltDatumVonKleinerAlsHeute", "DatumVon darf nicht kleiner als heute sein.");
                throw new KissCancelException();
            }
            if (datumBis != null && datumVon > datumBis)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridZugeteiltDatumVonGroesserAlsDatumBis", "DatumVon darf nicht grösser als DatumBis sein.");
                throw new KissCancelException();
            }
            if (datumBis != null && datumBis < DateTime.Today)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridZugeteiltDatumBisKleinerAlsHeute", "DatumBis darf nicht kleiner als heute sein.");
                throw new KissCancelException();
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                            SELECT TOP 1 1
                            FROM dbo.FaLeistungZugriff
                            WHERE 1=1
                            AND FaLeistungZugriffID <> {0}
                            AND FaLeistungID = {1}
                            AND UserID = {2}
                            AND ISNULL(dbo.fnDateOf(DatumBis),'99991231') > dbo.fnDateOf({3})
                            AND dbo.fnDateOf(DatumVon) < dbo.fnDateOf(ISNULL({4},'99991231'));",
                qryZugeteilt["FaLeistungZugriffID"],
                qryZugeteilt["FaLeistungID"],
                qryZugeteilt["UserID"],
                datumVon,
                datumBis);
            if (qry.HasRow)
            {
                KissMsg.ShowInfo(CLASSNAME, "FrmFallZugriffGridPeriodeUeberschneidung", "Es gibt eine Überschneidung mit einer anderen Periode.");
                throw new KissCancelException();
            }
        }
    }
}