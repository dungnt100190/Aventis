using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPersonKrankenkasse : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlBaPersonKrankenkasse";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private bool _personIdChanged;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPersonKrankenkasse()
        {
            InitializeComponent();

            // Letzte Bearbeitung
            // 31.07.2007 : sozheo : neu erstellt
            // 18.09.2007 : sozheo : Auswahl Krankenkasse korrigiert
            // ---------------------------------------------------------------------
            // In Design-Mode this throws an exception, and I couldn't fix it with checking for DesignMode (not sure why)
            try
            {
                colGesetzesGrundlageCode.ColumnEdit = grdBaKrankenversicherung.GetLOVLookUpEdit("BaKVGVVG");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("CtlBaPersonKrankenkasse.CtlBaPersonKrankenkasse(): " + ex.Message);
            }
        }

        #endregion

        #region Properties

        [DefaultValue(0)]
        public int BaPersonID
        {
            set
            {
                if (_baPersonID != value)
                {
                    _personIdChanged = true;
                }

                _baPersonID = value;

                qryBaKrankenversicherung.Fill(value);
                if (qryBaKrankenversicherung.Count == 0 && qryBaKrankenversicherung.CanInsert)
                {
                    qryBaKrankenversicherung.Insert();
                }

                qryBaPraemienverbilligung.Fill(value);
                qryBaPraemienuebernahme.Fill(value);
            }

            get
            {
                return _baPersonID;
            }
        }

        #endregion

        #region EventHandlers

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string[] fieldNames = {
                "GesetzesGrundlageCode",
                "BaInstitutionID",
                "InstitutionName",
                "MitgliedNr",
                "GanzeSchweiz",
                "UnfallEinschluss",
                "Zahnversicherung",
                "Taggeldversicherung",
                "TaggeldversicherungBetrag",
            };

            DBUtil.CopyDataRow_IncludingFields(qryBaKrankenversicherung, fieldNames, false);
        }

        private void CtlBaPersonKrankenkasse_Load(object sender, EventArgs e)
        {
            qryBaPraemienverbilligung.Last();
            qryBaPraemienuebernahme.Last();
        }

        private void dlgInstitution_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = dlgInstitution.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaKrankenversicherung["BaInstitutionID"] = DBNull.Value;
                    qryBaKrankenversicherung["InstitutionName"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$                 = INS.BaInstitutionID,
                       Institution         = INS.Name,
                       Adresse             = INS.Adresse,
                       Typ                 = INS.Typ,
                       InstitutionTypCode$ = INS.InstitutionTypCode,
                       OrtStrasse$         = INS.OrtStrasse,
                       InstitutionName$    = INS.Name + isNull(', ' + INS.PLZOrt,'')
                FROM dbo.vwInstitution INS
                WHERE INS.BaFreigabeStatusCode = 2
                  AND INS.Name + ISNULL(', ' + INS.PLZOrt,'') LIKE '%' + {0} + '%'
                  AND INS.InstitutionTypCode = 10
                ORDER BY INS.Name",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qryBaKrankenversicherung["BaInstitutionID"] = dlg[0];
                qryBaKrankenversicherung["InstitutionName"] = dlg["InstitutionName$"];
            }
        }

        private void qryBaKrankenversicherung_AfterFill(object sender, EventArgs e)
        {
            // Kopieren nur möglich, wenn Zeile vorhanden
            btnCopy.Enabled = (qryBaKrankenversicherung.Count > 0 && qryBaKrankenversicherung.CanInsert);
        }

        private void qryBaKrankenversicherung_AfterInsert(object sender, EventArgs e)
        {
            qryBaKrankenversicherung["BaPersonID"] = _baPersonID;
            rgrGesetz.Focus();
        }

        private void qryBaKrankenversicherung_AfterPost(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["KVGPraemienVerbillBetrag"]))
            {
                //Eintrag ins Fallverlaufsprotokoll
                InsertFVProtokoll(qryBaKrankenversicherung["BaPersonID"], "Mutation Prämienverbilligung");
            }

            // Kopieren nur möglich, wenn Zeile vorhanden
            btnCopy.Enabled = (qryBaKrankenversicherung.Count > 0 && qryBaKrankenversicherung.CanInsert);
        }

        private void qryBaKrankenversicherung_BeforePost(object sender, EventArgs e)
        {
            // Kontrollieren, dass KVG / VVG erfasst ist:
            if (DBUtil.IsEmpty(qryBaKrankenversicherung["GesetzesGrundlageCode"]))
            {
                edtPraemie.Focus();
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "GesetzesGrundlageLeer",
                    "Wählen Sie zuerst zwischen der Gesetzesgrundlage KVG oder VVG.",
                    520,
                    120);
                throw new KissCancelException();
            }

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["DatumVon"]) && !DBUtil.IsEmpty(qryBaKrankenversicherung["DatumBis"]))
            {
                if ((DateTime)qryBaKrankenversicherung["DatumVon"] >= (DateTime)qryBaKrankenversicherung["DatumBis"])
                {
                    edtDatumVon.Focus();
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "DatumsFehler",
                        "Das Von-Datum muss kleiner sein als das Bis-Datum.",
                        520,
                        120);
                    throw new KissCancelException();
                }
            }

            // Kontrollieren, dass Pämie erfasst ist:
            if (DBUtil.IsEmpty(qryBaKrankenversicherung["Praemie"]))
            {
                edtPraemie.Focus();
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "PraemieLeer",
                    "Erfassen Sie zuerst eine Prämie.",
                    520,
                    120);
                throw new KissCancelException();
            }

            // Beträge auf 5 Rappen runden:
            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["Praemie"]))
            {
                qryBaKrankenversicherung["Praemie"] = Utils.RoundMoney_CH((decimal)qryBaKrankenversicherung["Praemie"]);
            }

            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["Franchise"]))
            {
                qryBaKrankenversicherung["Franchise"] = Utils.RoundMoney_CH((decimal)qryBaKrankenversicherung["Franchise"]);
            }

            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["TaggeldversicherungBetrag"]))
            {
                qryBaKrankenversicherung["TaggeldversicherungBetrag"] = Utils.RoundMoney_CH((decimal)qryBaKrankenversicherung["TaggeldversicherungBetrag"]);
            }

            if (!DBUtil.IsEmpty(qryBaKrankenversicherung["KVGPraemienVerbillBetrag"]))
            {
                qryBaKrankenversicherung["KVGPraemienVerbillBetrag"] = Utils.RoundMoney_CH((decimal)qryBaKrankenversicherung["KVGPraemienVerbillBetrag"]);
            }
        }

        private void qryBaKrankenversicherung_PositionChanged(object sender, EventArgs e)
        {
            if (qryBaKrankenversicherung.CanUpdate && qryBaKrankenversicherung.Count > 0
                && qryBaKrankenversicherung.Row.RowState != DataRowState.Added
                && !DBUtil.UserHasRight("CtlBaPersonKrankenkasse_Bearbeiten"))
            {
                qryBaKrankenversicherung.EnableBoundFields(false);
                ((IKissBindableEdit)edtDatumBis).AllowEdit(true);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Activate()
        {
            edtDatumVon.Focus();
            if (_personIdChanged)
            {
                qryBaPraemienverbilligung.Last();
                qryBaPraemienuebernahme.Last();
                _personIdChanged = false;
            }
        }

        public void Init(string titleName, Image titleImage, int baPersonID)
        {
            //this.picTitle.Image = TitleImage;
            BaPersonID = baPersonID;
            SetRights(true);
        }

        public void RefreshQueries()
        {
            qryBaKrankenversicherung.Refresh();
            qryBaPraemienverbilligung.Refresh();
            qryBaPraemienuebernahme.Refresh();
        }

        public void SetRights(bool hasEditRights)
        {
            qryBaKrankenversicherung.CanUpdate = hasEditRights;
            qryBaKrankenversicherung.CanInsert = hasEditRights;
            qryBaKrankenversicherung.CanDelete = hasEditRights;

            qryBaKrankenversicherung.ApplyUserRights();
        }

        #endregion

        #region Private Methods

        // Aufruf für BaPersonID, Text
        private bool InsertFVProtokoll(object fvBaPersonID, string fvText)
        {
            return InsertFVProtokoll(DBNull.Value, DBNull.Value, fvBaPersonID, Session.User.UserID, 1, fvText);
        }

        // Aufruf für FaFallID, BaPersonID, Text
        private bool InsertFVProtokoll(object fvFaFallID, object fvBaPersonID, string fvText)
        {
            return InsertFVProtokoll(fvFaFallID, DBNull.Value, fvBaPersonID, Session.User.UserID, 1, fvText);
        }

        // Aufruf für FaFallID, FaLeistungID, BaPersonID, Text
        private bool InsertFVProtokoll(object fvFaFallID, object fvFaLeistungID, object fvBaPersonID, string fvText)
        {
            return InsertFVProtokoll(fvFaFallID, fvFaLeistungID, fvBaPersonID, Session.User.UserID, 1, fvText);
        }

        // Werte in die Datenbank in FaJournal einfügen
        private bool InsertFVProtokoll(object fvFaFallID, object fvFaLeistungID, object fvBaPersonID, int fvUserID, int fvFaJournalCode, string fvText)
        {
            // Einen neuen Eintrag im Fallverlaufsprotokoll einfügen
            // -----------------------------------------------------
            // Parameter der sp:  {0}=FaFallID, {1}=FaLeistungID, {2}=BaPersonID, {3}=UserID, {4}=FaJournalCode, {5}=Text
            // Info:              Wenn FaFallID NULL ist, wird versucht (1.) via FaLeistungID oder (2.) via BaPersonID die FaFallID zu setzen.
            //                    Wenn BaPersonID NULL ist, wird versucht (1.) via FaLeistungID oder (2.) via FaFallID die BaPersonID zu setzen.
            // Rückgabewert:      Eingefügte FaJournalID des neuen Eintrags - zum Ändern von zusätzlichen Werten verwendbar
            int faJournalID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                EXEC spFaInsertFVProtokoll {0}, {1}, {2}, {3}, {4}, {5}", fvFaFallID, fvFaLeistungID, fvBaPersonID, fvUserID, fvFaJournalCode, fvText));

            // return if valid new id (< 1 = invalid)
            return faJournalID > 0;
        }

        #endregion

        #endregion
    }
}