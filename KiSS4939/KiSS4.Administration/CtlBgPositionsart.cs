using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public partial class CtlBgPositionsart : KissSearchUserControl
    {
        #region Enumerations

        private enum CreationMode
        {
            Empty = 0,
            Clone = 1,
            Folgeposition = 2
        }

        private enum UseCase
        {
            None,
            TerminatePosArtNoSuccessor,
            TerminatePosArtWithSuccessor,
            ImportantFieldModified
        }

        #endregion

        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ModulID _modul;
        private readonly Dictionary<int, bool> _positionsExistCache = new Dictionary<int, bool>();

        #endregion

        #region Private Fields

        private Dictionary<string, Control> _controlList;
        private CreationMode? _creationMode;
        private int _selectedBgPositionsartID;
        private UseCase? _useCase;

        #endregion

        #endregion

        #region Constructors

        public CtlBgPositionsart(ModulID modul)
            : this()
        {
            _modul = modul;
            edtBgGruppeCode.LOVFilter = modul.ToString();

            edtBgGruppeCodeX.LOVFilter = modul.ToString();
        }

        public CtlBgPositionsart()
        {
            InitializeComponent();

            SetupControlList();

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                chkEditMaskMasterLow.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
                chkEditMaskMasterHigh.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
                chkEditMaskMonatLow.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(item.Value));
            }
        }

        #endregion

        #region EventHandlers

        private void chkEditMask_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (qryBgPositionsart.CanUpdate)
            {
                qryBgPositionsart.RowModified = true;
                //qryBgPositionsart.Row.SetModified();
            }
        }

        private void CtlBgPositionsart_Load(object sender, EventArgs e)
        {
            kissSearch.SelectParameters = new object[] { (int)_modul };

            SetupTags();

            colBgKategorieCode.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit("BgKategorie");
            colBgGruppeCode.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit("BgGruppe");

            qryBgKostenart.Fill((int)_modul);
            edtBgKostenartID.LoadQuery(qryBgKostenart, "BgKostenartID", "NrName");
            colBgKostenartID.ColumnEdit = grdBgPositionsart.GetLOVLookUpEdit(qryBgKostenart, "BgKostenartID", "NrName");

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT BgKostenartID = NULL, NrName = NULL, SortKey=NULL
                UNION ALL
                SELECT  BgKostenartID,
                        [Name]=IsNull(KontoNr + ' ', '') + Name,
                        SortKey=CASE WHEN IsNumeric(KontoNr) = 1
                                     THEN CONVERT(decimal, KontoNr)
                                     ELSE NULL
                                END
                FROM   BgKostenart
                WHERE ModulID = {0}
                ORDER BY SortKey", (int)_modul);
            edtBgKostenartIDX.LoadQuery(qry, "BgKostenartID", "NrName");

            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        // ControlName: editReadOnly, ComponentName: qryBgPositionsart
        private void editReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!qryBgPositionsart.Post())
                return;

            qryBgPositionsart.CanDelete = !editReadOnly.Checked;
            qryBgPositionsart.CanInsert = !editReadOnly.Checked;
            qryBgPositionsart.CanUpdate = !editReadOnly.Checked;

            //qryBgPositionsart.Refresh();

            if (Session.User.IsUserBIAGAdmin || editReadOnly.Checked)
            {
                //remove filter on gridview
                grvBgPositionsart.ActiveFilterString = null;
            }
            else
            {
                //filter grid: only display 'Zusätzliche Leistungen'
                grvBgPositionsart.ActiveFilterString = string.Format("{0}={1} OR {0} IS NULL", DBO.BgPositionsart.BgKategorieCode, (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen);
            }

            SetupFields();
        }

        private void edtBFSVariable_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtBFSVariable.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString) && !e.ButtonClicked)
            {
                qryBgPositionsart["VarName"] = DBNull.Value;
                return;
            }

            var dlg = new DlgAuswahl();

            var now = DateTime.Now;

            var bfsFrageKatalogJahr = now.Year;

            var datumVon = Utils.ConvertToDateTime(qryBgPositionsart["DatumVon"], DateTime.Now);
            var datumBis = Utils.ConvertToDateTime(qryBgPositionsart["DatumBis"], DateTime.Now);

            if (now <= datumBis && now >= datumVon)
            {
                //das aktuelle datum ist im gültigkeitsbereich der positionsart
                //--> aktuelles datum
                bfsFrageKatalogJahr = now.Year;
            }
            else if (datumBis < now)
            {
                //das aktuelle datum ist nach dem gültigkeitsbereich der positionsart
                //-> datumBis
                bfsFrageKatalogJahr = datumBis.Year;
            }
            else if (datumVon > now)
            {
                //das aktuelle datum ist vor dem gültigkeitsbereich der positionsart
                //-> datumVon
                bfsFrageKatalogJahr = datumVon.Year;
            }

            e.Cancel = !dlg.SucheBfsVariable(bfsFrageKatalogJahr, LOV.BFSFeldCode.Zahl, edtBFSVariable.Text);

            if (!e.Cancel)
            {
                qryBgPositionsart["VarName"] = dlg["Variable"];
            }
        }

        private void qryBgPositionsart_AfterDelete(object sender, EventArgs e)
        {
            //Query Refresh, damit die Vorgänger-Position auch korrekt dargestellt wird (StoredProcedure hat DatumBis zugewiesen)
            qryBgPositionsart.Refresh();
        }

        private void qryBgPositionsart_AfterInsert(object sender, EventArgs e)
        {
            qryBgPositionsart["ModulID"] = _modul;

            SetupEditModes(Session.User.IsUserBIAGAdmin, editReadOnly.Checked);

            switch (_creationMode)
            {
                case CreationMode.Folgeposition:
                    ClonePositionArt(_selectedBgPositionsartID, true);

                    //set field states
                    edtDatumVon.EditMode = EditModeType.Required;
                    edtDatumBis.EditMode = EditModeType.ReadOnly;
                    break;

                case CreationMode.Clone:
                    ClonePositionArt(_selectedBgPositionsartID, false);

                    //set field states
                    edtDatumVon.EditMode = EditModeType.Normal;
                    edtDatumBis.EditMode = EditModeType.ReadOnly;
                    break;

                case CreationMode.Empty:
                    //set field states
                    edtDatumVon.EditMode = EditModeType.Normal;
                    edtDatumBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    //do nothing
                    break;
            }
        }

        private void qryBgPositionsart_AfterPost(object sender, EventArgs e)
        {
            if (Session.Transaction == null) return;

            try
            {
                ExecuteStoredProcedure(_useCase.Value, false);

                //commit transaction
                Session.Commit();
            }
            catch (Exception)
            {
                //rollback
                Session.Rollback();

                throw;
            }
            //Query Refresh, damit die Vorgänger-Position auch korrekt dargestellt wird (StoredProcedure hat DatumBis zugewiesen)
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            qryBgPositionsart.RowModified = false;
            qryBgPositionsart.Refresh();
        }

        private void qryBgPositionsart_BeforeDelete(object sender, EventArgs e)
        {
            if (CheckPositionsExist())
            {
                KissMsg.ShowInfo("CtlBgPositionsart", "PositionsartKannNichtGeloeschtWerden", "Diese Positionsart wurde bereits verwendet. Sie kann nicht mehr gelöscht werden.\r\nWenn Sie diese Positionsart nicht mehr benötigen, terminieren Sie sie indem Sie ein Datum in [DatumBis] eingeben.");
                throw new KissCancelException();
            }
        }

        private void qryBgPositionsart_BeforeInsert(object sender, EventArgs e)
        {
            if (tabControlSearch.SelectedTab == tpgListe)
            {
                _creationMode = GetCreationModeAction();
                _selectedBgPositionsartID = Convert.ToInt32(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]);
            }
            else
            {
                throw new KissCancelException();
            }
        }

        private void qryBgPositionsart_BeforePost(object sender, EventArgs e)
        {
            CheckNotNullFields();

            var datumVon = Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumVon]);
            if (datumVon != DateTime.MinValue)
            {
                //DatumVon muss der erste eines Monats sein
                if (datumVon.Day != 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgPositionsart",
                                                                     "DatumVonErsterDesMonats",
                                                                     "Das Von-Datum muss auf dem ersten Tag des Monats liegen.",
                                                                     KissMsgCode.MsgInfo),
                                                edtDatumVon);
                }
            }

            var datumBis = Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumBis]);
            if (datumBis != DateTime.MinValue)
            {
                //DatumBis muss der letzte eines Monats sein
                if (datumBis.AddDays(1).Day != 1)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgPositionsart",
                                                                     "DatumBisLetzterDesMonats",
                                                                     "Das Bis-Datum muss auf dem letzten Tag des Monats liegen.",
                                                                     KissMsgCode.MsgInfo),
                                                edtDatumBis);
                }
            }

            if (datumVon != DateTime.MinValue && datumBis != DateTime.MinValue && datumVon > datumBis)
            {
                //welches Datum-Feld ist editierbar?
                if (edtDatumVon.EditMode != EditModeType.ReadOnly)
                {
                    //Von-Datum
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgPositionsart",
                                                                     "DatumVonDarfNichtNachDatumBisLiegen",
                                                                     "Das Von-Datum darf nicht nach dem Bis-Datum liegen.",
                                                                     KissMsgCode.MsgInfo),
                                                    edtDatumVon);
                }
                else
                {
                    //Bis-Datum
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlBgPositionsart",
                                                                     "DatumBisDarfNichtNachDatumVonLiegen",
                                                                     "Das Bis-Datum darf nicht vor dem Von-Datum liegen.",
                                                                     KissMsgCode.MsgInfo),
                                                    edtDatumBis);
                }
            }

            //check modified fields
            _useCase = DetectUseCase();

            if (!ConfirmWithUser(_useCase))
            {
                throw new KissCancelException();
            }

            //mit der StoredProcedure validieren, damit wir sicher sind, dass die Terminierung durchgeführt werden kann.
            try
            {
                SaveEditMask();

                ExecuteStoredProcedure(_useCase.Value, true);

                //wenn wir bis hier durchlaufen, dann müsste das terminieren möglich/erlaubt sein.
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);

                // cancel the Post()
                throw new KissCancelException();
            }

            //Transaktion starten, so dass wir sicherstellen können, dass die Vorgänger-Positionsart auf das eingegebene
            //Datum terminiert wird, andernfalls wird die aktuell eingegebene Positionsart auch rollbacked.

            //ACHTUNG: Unter gewissen Umständen feuert DevExpress aufgrund eines BindingListChanged Events auf dem SqlQuery ein BeforeLeaveRow auf dem
            //Grid, weshalb das KissGrid dann ein erneutes Post() durchführt.
            //Dieses erneute Post() hat grundsätzlich seinen Sinn, wenn wir nicht bereits in einem Post() wären! Leider können wir dies nicht detektieren,
            //weshalb wir hier prüfen müssen, ob wir bereits eine offene Transaktion haben. Wenn ja, müssen wir dieses Post abbrechen (KissCancelException)
            if (Session.Transaction != null)
            {
                //wir sind im zweite, überflüssigen Post()
                throw new KissCancelException();
            }

            Session.BeginTransaction();
        }

        private void qryBgPositionsart_PositionChanged(object sender, EventArgs e)
        {
            if (editReadOnly.Checked)
            {
                SetupReadonlyCheckBox();
            }

            _selectedBgPositionsartID = Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]);

            ReadEditMask();

            SetupEditModes(Session.User.IsUserBIAGAdmin, editReadOnly.Checked);
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool CheckNachfolgePositionsartExist()
        {
            int nbrNachfolgePositionart = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
            SELECT TOP 1 1 FROM BgPositionsart WHERE BgPositionsartID_CopyOf = {0};", _selectedBgPositionsartID));

            return nbrNachfolgePositionart > 0;
        }

        private void CheckNotNullFields()
        {
            // CheckNotNullField for Controls that have their EditMode == Required
            foreach (Control ctl in _controlList.Values)
            {
                if (typeof(IKissEditable).IsAssignableFrom(ctl.GetType()) && typeof(IKissBindableEdit).IsAssignableFrom(ctl.GetType()))
                {
                    if (((IKissEditable)ctl).EditMode == EditModeType.Required)
                    {
                        string text = ctl.Tag == null ? ctl.Name : ctl.Tag.ToString();
                        DBUtil.CheckNotNullField(((IKissBindableEdit)ctl), text);
                    }
                }
                else
                {
                    throw new KissErrorException("The control is not a IKissEditable object.");
                }
            }
        }

        private bool CheckPositionsExist()
        {
            //does it exist in the cache?
            if (!_positionsExistCache.ContainsKey(_selectedBgPositionsartID))
            {
                int nbrPositions = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 1 FROM BgPosition WHERE BgPositionsartID = {0};", _selectedBgPositionsartID));
                //fill the cache
                _positionsExistCache.Add(_selectedBgPositionsartID, nbrPositions > 0);
            }

            return _positionsExistCache[_selectedBgPositionsartID];
        }

        private void ClonePositionArt(int originalPositionArtID, bool makeFolgeposition)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT ModulID, BgKategorieCode, BgGruppeCode, BgPositionsartCode, Name, HilfeText, SortKey, BgKostenartID,
                            NrmKontoCode, VerwaltungSD_Default, Spezkonto, ProPerson, ProUE, Masterbudget_EditMask, Monatsbudget_EditMask,
                            sqlRichtlinie, VarName, ErzeugtBfsDossier, Verrechenbar, Bemerkung, NameTID, System, DatumBis
                        FROM BgPositionsart
                        WHERE BgPositionsartID = {0}", originalPositionArtID);

            qryBgPositionsart[DBO.BgPositionsart.ModulID] = qry[DBO.BgPositionsart.ModulID];
            qryBgPositionsart[DBO.BgPositionsart.BgKategorieCode] = qry[DBO.BgPositionsart.BgKategorieCode];
            qryBgPositionsart[DBO.BgPositionsart.BgGruppeCode] = qry[DBO.BgPositionsart.BgGruppeCode];
            if (makeFolgeposition)
            {
                qryBgPositionsart[DBO.BgPositionsart.BgPositionsartCode] = qry[DBO.BgPositionsart.BgPositionsartCode];
                qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID_CopyOf] = originalPositionArtID;
            }

            qryBgPositionsart[DBO.BgPositionsart.Name] = qry[DBO.BgPositionsart.Name];
            qryBgPositionsart[DBO.BgPositionsart.HilfeText] = qry[DBO.BgPositionsart.HilfeText];
            qryBgPositionsart[DBO.BgPositionsart.SortKey] = qry[DBO.BgPositionsart.SortKey];
            qryBgPositionsart[DBO.BgPositionsart.BgKostenartID] = qry[DBO.BgPositionsart.BgKostenartID];
            qryBgPositionsart[DBO.BgPositionsart.NrmKontoCode] = qry[DBO.BgPositionsart.NrmKontoCode];
            qryBgPositionsart[DBO.BgPositionsart.VerwaltungSD_Default] = qry[DBO.BgPositionsart.VerwaltungSD_Default];
            qryBgPositionsart[DBO.BgPositionsart.Spezkonto] = qry[DBO.BgPositionsart.Spezkonto];
            qryBgPositionsart[DBO.BgPositionsart.ProPerson] = qry[DBO.BgPositionsart.ProPerson];
            qryBgPositionsart[DBO.BgPositionsart.ProUE] = qry[DBO.BgPositionsart.ProUE];
            qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask] = qry[DBO.BgPositionsart.Masterbudget_EditMask];
            qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask] = qry[DBO.BgPositionsart.Monatsbudget_EditMask];
            qryBgPositionsart[DBO.BgPositionsart.sqlRichtlinie] = qry[DBO.BgPositionsart.sqlRichtlinie];
            qryBgPositionsart[DBO.BgPositionsart.VarName] = qry[DBO.BgPositionsart.VarName];
            qryBgPositionsart[DBO.BgPositionsart.ErzeugtBfsDossier] = qry[DBO.BgPositionsart.ErzeugtBfsDossier];
            qryBgPositionsart[DBO.BgPositionsart.Verrechenbar] = qry[DBO.BgPositionsart.Verrechenbar];
            qryBgPositionsart[DBO.BgPositionsart.Bemerkung] = qry[DBO.BgPositionsart.Bemerkung];
            qryBgPositionsart[DBO.BgPositionsart.NameTID] = qry[DBO.BgPositionsart.NameTID];
            qryBgPositionsart[DBO.BgPositionsart.System] = qry[DBO.BgPositionsart.System];

            if (!DBUtil.IsEmpty(qry[DBO.BgPositionsart.DatumBis]))
            {
                //Wenn die VorgängerPosition bereits terminiert ist, dann übernehmen wir dieses Feld (+1 Tag)
                qryBgPositionsart[DBO.BgPositionsart.DatumVon] = Utils.ConvertToDateTime(qry[DBO.BgPositionsart.DatumBis]).AddDays(1);
            }

            qryBgPositionsart.RowModified = true;
        }

        private bool ConfirmWithUser(UseCase? useCase)
        {
            if (!useCase.HasValue)
                return true;

            switch (useCase.Value)
            {
                //ask user if he is sure to terminate the Positionsart
                case UseCase.TerminatePosArtNoSuccessor:
                    return KissMsg.ShowQuestion("CtlBgPositionsart",
                        "PositionsartTerminierenBestaetigung",
                        "Sind Sie sicher, dass Sie die Positionsart: {0} {1}\r\nper {2} terminieren wollen?\r\nDieser Vorgang kann nicht rückgängig gemacht werden.",
                        true,
                        Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]),
                        Utils.ConvertToString(qryBgPositionsart[DBO.BgPositionsart.Name]),
                        Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumBis]).ToShortDateString());

                case UseCase.TerminatePosArtWithSuccessor:
                    return KissMsg.ShowQuestion("CtlBgPositionsart",
                        "NachfolgePositionsartTerminierenBestaetigung",
                        "Sind Sie sicher, dass Sie die Nachfolge-Positionsart: {0}\r\nper {1} einfügen wollen?\r\nDieser Vorgang kann nicht rückgängig gemacht werden.",
                        true,
                        Utils.ConvertToString(qryBgPositionsart[DBO.BgPositionsart.Name]),
                        Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumVon]).ToShortDateString());

                case UseCase.ImportantFieldModified:
                    //do positions exist with this positionsart?
                    if (CheckPositionsExist())
                    {
                        return KissMsg.ShowQuestion(
                            "CtlBgPositionsart",
                            "RelevanteFelderMutierenTrotzPositionenBestaetigung",
                            "Sind Sie sicher, dass Sie Positionsart : {0}\r\nmutieren wollen, obwohl bereits Positionen mit dieser Positionsart existieren?\r\nDieser Vorgang kann unter Umständen zu unerwartetem Verhalten oder fehlerhaften Buchungen führen.",
                            true,
                            Utils.ConvertToString(qryBgPositionsart[DBO.BgPositionsart.Name]));
                    }
                    break;

                default:
                    //do nothing, simply return true;
                    return true;
            }
            return true;
        }

        private UseCase DetectUseCase()
        {
            //date fields
            DateTime? datumVon = null;
            if (!DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.DatumVon]))
            {
                datumVon = Convert.ToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumVon]);
            }
            bool datumVonModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.DatumVon);

            DateTime? datumBis = null;
            if (!DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.DatumBis]))
            {
                datumBis = Convert.ToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumBis]);
            }
            bool datumBisModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.DatumBis);

            //is it a "Nachfolge-Positionsart"?
            int? bgPositionsartIDCopyOf = null;
            if (!DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID_CopyOf]))
            {
                bgPositionsartIDCopyOf = Convert.ToInt32(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID_CopyOf]);
            }

            //bool bgPositionsartIDCopyOfModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.BgPositionsartID_CopyOf);

            //other important fields
            bool bgKategorieCodeModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.BgKategorieCode);
            bool bgGruppeCodeModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.BgGruppeCode);
            bool bgKostenartIDModified = qryBgPositionsart.ColumnModified(DBO.BgPositionsart.BgKostenartID);

            //there are three possible cases:
            //1. datumVon: modified, null -> value; BgPositionsartID_CopyOf: value
            //   a new positionsart was created as a clone of an existing one
            //   (BgPositionsartID_CopyOf & DatumVon are required fields then)
            //   --> Terminate the previous positionsart (the one BgPositionsartID_CopyOf references)
            if (datumVonModified && datumVon.HasValue && bgPositionsartIDCopyOf.HasValue)
            {
                return UseCase.TerminatePosArtWithSuccessor;
            }
            //2. datumBis: modified, null -> value; BgPositionsartID_CopyOf: null
            //   an existing positionsart is terminated (DatumBis is a required field then)
            //   --> Terminate this positionsart (there is no previous positionsart)
            if (datumBisModified && datumBis.HasValue)
            {
                return UseCase.TerminatePosArtNoSuccessor;
            }

            if (bgKategorieCodeModified || bgGruppeCodeModified || bgKostenartIDModified)
            {
                return UseCase.ImportantFieldModified;
            }

            return UseCase.None;
        }

        private void ExecuteStoredProcedure(UseCase useCase, bool preview)
        {
            //execute stored procedure
            switch (useCase)
            {
                case UseCase.TerminatePosArtNoSuccessor:
                    TerminateBgPositionsart(
                        Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]),
                        null,
                        Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumBis]),
                        preview);
                    break;

                case UseCase.TerminatePosArtWithSuccessor:
                    TerminateBgPositionsart(
                        Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID_CopyOf]),
                        Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]),
                        Utils.ConvertToDateTime(qryBgPositionsart[DBO.BgPositionsart.DatumVon]).AddDays(-1),
                        preview);
                    break;

                default:
                    //do nothing
                    break;
            }
        }

        private CreationMode GetCreationModeAction()
        {
            //Which creation options does the user have?
            //this depends on the currently selected positionsart:

            //if the currently selected positionsart already has a Nachfolge-Positionsart, the user is not allowed to create another Nachfolge-Positionsart
            bool noClone = qryBgPositionsart.IsEmpty
                            || (!Session.User.IsUserBIAGAdmin
                                 && Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgKategorieCode]) != (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen);
            bool noFolgeposition = qryBgPositionsart.IsEmpty || CheckNachfolgePositionsartExist();

            if (noClone)
            {
                return CreationMode.Empty;
            }

            KissLookupDialog dlg = new KissLookupDialog();

            bool cancel = !dlg.SearchData(@"
                SELECT Code$ = 0, Text = 'neue (leere) Positionsart erstellen'
                UNION
                SELECT 1, 'selektierte Positionsart kopieren'
                UNION
                SELECT 2, 'selektierte Positionsart mutieren (Folgeposition)' WHERE {1} <> 1
                ", "", true, noFolgeposition, null, null);

            if (cancel)
            {
                throw new KissCancelException();
            }

            return (CreationMode)Convert.ToInt32(dlg["Code$"]);
        }

        private void ReadEditMask()
        {
            int i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterLow.Items)
            {
                int editMask = ((int)(qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) & 0xFFF);
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterHigh.Items)
            {
                int editMask = ((int)(qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) & 0xFFF000) / 0x1000;
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatLow.Items)
            {
                int editMask = ((int)(qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) & 0xFFF);
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                int editMask = ((int)(qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) & 0xFFF000) / 0x1000;
                item.CheckState = (editMask & ((int)Math.Pow(2, i))) > 0 ? CheckState.Checked : CheckState.Unchecked;

                i++;
            }
        }

        private void SaveEditMask()
        {
            int i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterLow.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) | ((int)(Math.Pow(2, i)));
                else
                    qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) & ~((int)(Math.Pow(2, i)));

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMasterHigh.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) | ((int)(Math.Pow(2, i) * 0x1000));
                else
                    qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Masterbudget_EditMask]) & ~((int)(Math.Pow(2, i) * 0x1000));

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatLow.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) | ((int)(Math.Pow(2, i)));
                else
                    qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) & ~((int)(Math.Pow(2, i)));

                i++;
            }

            i = 0;
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in chkEditMaskMonatHigh.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) | ((int)(Math.Pow(2, i) * 0x1000));
                else
                    qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask] = ((int)qryBgPositionsart[DBO.BgPositionsart.Monatsbudget_EditMask]) & ~((int)(Math.Pow(2, i) * 0x1000));

                i++;
            }
        }

        /// <summary>
        /// Liste von Controls die je nach Status aktiviert sein müssen.
        /// </summary>
        private void SetupControlList()
        {
            _controlList = new Dictionary<string, Control>();
            _controlList.Add(edtDatumVon.Name, edtDatumVon);
            _controlList.Add(edtDatumBis.Name, edtDatumBis);
            _controlList.Add(edtName.Name, edtName);
            _controlList.Add(edtSortKey.Name, edtSortKey);
            _controlList.Add(edtBgPositionsartID.Name, edtBgPositionsartID);
            _controlList.Add(edtBgKategorieCode.Name, edtBgKategorieCode);
            _controlList.Add(edtBgKostenartID.Name, edtBgKostenartID);
            _controlList.Add(edtBgGruppeCode.Name, edtBgGruppeCode);
            _controlList.Add(edtBFSVariable.Name, edtBFSVariable);
            _controlList.Add(edtBgPositionsartCode.Name, edtBgPositionsartCode);
            _controlList.Add(edtBemerkung.Name, edtBemerkung);
        }

        private void SetupEditKategorieCode(bool isBiagAdmin)
        {
            if (!isBiagAdmin)
            {
                edtBgKategorieCode.LOVFilter = "Code = 100"; //display only Zusätzliche Leistungen
                edtBgKategorieCode.LOVFilterWhereAppend = true;
                edtBgKategorieCode.ReadLOV();
            }
            else
            {
                edtBgKategorieCode.LOVFilterWhereAppend = false; //don't filter
                edtBgKategorieCode.ReadLOV();
            }
        }

        private void SetupEditModes(bool isBiagAdmin, bool isReadonly)
        {
            bool neuePosition = DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartID]);

            bool datumVonHasValue = !DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.DatumVon]);
            bool datumBisHasValue = !DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.DatumBis]);
            bool bgPositionsartCodeHasValue = !DBUtil.IsEmpty(qryBgPositionsart[DBO.BgPositionsart.BgPositionsartCode]);

            EditModeType alwaysReadonly = EditModeType.ReadOnly;

            EditModeType onlyBiagAdminRequired = !isReadonly && isBiagAdmin ? EditModeType.Required : EditModeType.ReadOnly;
            EditModeType onlyBiagAdminNormal = !isReadonly && isBiagAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            //EditModeType requiredIfNoPositionExists = !isReadonly && !CheckPositionsExist() ? EditModeType.Required : EditModeType.ReadOnly;
            //EditModeType normalIfNoPositionExists = !isReadonly && !CheckPositionsExist() ? EditModeType.Normal : EditModeType.ReadOnly;

            EditModeType requiredIfNoPositionExistsOrBiagAdmin = !isReadonly && (isBiagAdmin || !CheckPositionsExist()) ? EditModeType.Required : EditModeType.ReadOnly;
            EditModeType normalIfNoPositionExistsOrBiagAdmin = !isReadonly && (isBiagAdmin || !CheckPositionsExist()) ? EditModeType.Normal : EditModeType.ReadOnly;

            EditModeType required = !isReadonly ? EditModeType.Required : EditModeType.ReadOnly;
            EditModeType normal = !isReadonly ? EditModeType.Normal : EditModeType.ReadOnly;

            //always readonly
            edtBgPositionsartID.EditMode = alwaysReadonly;

            //if no position exists (or biagadmin)
            edtBgKategorieCode.EditMode = requiredIfNoPositionExistsOrBiagAdmin;
            edtBgKostenartID.EditMode = requiredIfNoPositionExistsOrBiagAdmin;
            edtBgGruppeCode.EditMode = requiredIfNoPositionExistsOrBiagAdmin;
            edtBFSVariable.EditMode = normalIfNoPositionExistsOrBiagAdmin;
            edtErzeugtBfsDossier.EditMode = normalIfNoPositionExistsOrBiagAdmin;

            //only biagadmin
            edtBgPositionsartCode.EditMode = onlyBiagAdminRequired;
            edtProPerson.EditMode = onlyBiagAdminNormal;
            edtProUE.EditMode = onlyBiagAdminNormal;
            edtVerwaltungSD_Default.EditMode = onlyBiagAdminNormal;
            edtSpezkonto.EditMode = onlyBiagAdminNormal;
            edtVerrechenbar.EditMode = onlyBiagAdminNormal;
            edtKreditorEingeschraenkt.EditMode = onlyBiagAdminNormal;
            edtSystem.EditMode = onlyBiagAdminNormal;
            chkEditMaskMasterHigh.EditMode = onlyBiagAdminNormal;
            chkEditMaskMasterLow.EditMode = onlyBiagAdminNormal;
            chkEditMaskMonatHigh.EditMode = onlyBiagAdminNormal;
            chkEditMaskMonatLow.EditMode = onlyBiagAdminNormal;

            //normal
            edtSortKey.EditMode = normal;
            edtBemerkung.EditMode = normal;

            //required
            edtName.EditMode = required;

            if (!bgPositionsartCodeHasValue)
            {
                edtBgPositionsartCode.EditMode = normal;
            }
            else
            {
                edtBgPositionsartCode.EditMode = EditModeType.ReadOnly;
            }

            //only on new records, the Von-Datum can be set
            if (!datumVonHasValue && neuePosition)
            {
                if (_creationMode == CreationMode.Folgeposition)
                {
                    edtDatumVon.EditMode = EditModeType.Required;
                }
                else
                {
                    edtDatumVon.EditMode = normal;
                }
            }
            else
            {
                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }

            //don't modify a set bis-datum
            if (!datumBisHasValue && !neuePosition)
            {
                edtDatumBis.EditMode = normal;
            }
            else
            {
                edtDatumBis.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetupFields()
        {
            SetupEditKategorieCode(Session.User.IsUserBIAGAdmin);

            SetupEditModes(Session.User.IsUserBIAGAdmin, editReadOnly.Checked);
        }

        private void SetupReadonlyCheckBox()
        {
            if (Session.User.IsUserBIAGAdmin)
            {
                editReadOnly.Enabled = true;
                return;
            }

            bool isSystem = Utils.ConvertToBool(qryBgPositionsart[DBO.BgPositionsart.System], false);
            if (isSystem)
            {
                editReadOnly.Enabled = false;
                return;
            }

            int bgKategorieCode = Utils.ConvertToInt(qryBgPositionsart[DBO.BgPositionsart.BgKategorieCode], 0);
            if (bgKategorieCode == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen)
            {
                editReadOnly.Enabled = true;
                return;
            }

            editReadOnly.Enabled = false;
            return;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtDatumVon.Tag = lblDatumVon.Text;
            edtDatumBis.Tag = lblDatumBis.Text;
            edtBgGruppeCode.Tag = lblBgGruppeCode.Text;
            edtBgKategorieCode.Tag = lblBgKategorieCode.Text;
            edtName.Tag = lblName.Text;
            edtSortKey.Tag = lblSortKey.Text;
            edtBgPositionsartID.Tag = lblBgPositionsartID.Text;
            edtBgKostenartID.Tag = lblBgKostenartID.Text;
            edtBFSVariable.Tag = lblBFSVariable.Text;
            edtBgPositionsartCode.Tag = lblBgPositionsartCode.Text;
            edtBemerkung.Tag = lblBemerkung.Text;
        }

        private void TerminateBgPositionsart(int bgPositionsartID, int? nachfolgeBgPositionsartID, DateTime datumBis, bool preview)
        {
            DBUtil.ExecSQLThrowingException(180, "EXECUTE spWhPositionsart_Terminieren {0}, {1}, {2}, {3}, {4}",
                bgPositionsartID, datumBis, nachfolgeBgPositionsartID, preview, Session.User.LanguageCode);
        }

        #endregion

        #endregion
    }
}