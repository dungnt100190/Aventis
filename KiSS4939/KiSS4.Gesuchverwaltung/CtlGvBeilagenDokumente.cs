using System;
using System.Data;
using Kiss.Infrastructure.Constant;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvBeilagenDokumente : GvBaseControl
    {
        private const string CLASS_NAME = "CtlGvBeilagenDokumente";
        private const string QRY_GV_DOCUMENT_ADRESSAT = "Adressat";
        private const string QRY_GV_DOCUMENT_AUTOR = "Autor";
        private const string QRY_GV_DOCUMENT_DOK_VORHANDEN = "DokVorhanden";

        private const string SQL_ADRESSAT = @"
            SELECT ID$      = ADR.ID,
                   TypCode$ = ADR.TypCode,
                   Typ      = ADR.Typ,
                   Name     = ADR.Name,
                   Strasse  = ADR.Strasse,
                   Ort      = ADR.Ort
            FROM (SELECT ID      = BaPersonID,
                         TypCode = 1,
                         Typ     = {1},
                         Name    = NameVorname,
                         Strasse = WohnsitzStrasseHausNr,
                         Ort     = WohnsitzPLZOrt
                  FROM dbo.vwPerson WITH (READUNCOMMITTED)
                  WHERE Name LIKE '%' + {0} + '%'

                  UNION ALL

                  SELECT ID      = BaInstitutionID,
                         TypCode = 2,
                         Typ     = {2},
                         Name    = NameVorname,
                         Strasse = StrasseHausNr,
                         Ort     = PLZOrt
                  FROM dbo.vwInstitution WITH (READUNCOMMITTED)
                  WHERE Name LIKE '%' + {0} + '%') ADR
            ORDER BY ADR.Name;";

        private readonly string _institutionMlText;
        private readonly string _personMlText;

        public CtlGvBeilagenDokumente(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();

            // ML-Texte für Lookup-Dialog (Adressat)
            _personMlText = KissMsg.GetMLMessage(CLASS_NAME, "PersonInDialog", "Person");
            _institutionMlText = KissMsg.GetMLMessage(CLASS_NAME, "InstitutionInDialog", "Institution");

            SetupFieldNames();
            SetupDataMembers();
        }

        public override bool OnDeleteData()
        {
            if (_gvStatusCode > LOVsGenerated.GvStatus.InErfassung && qryGvDocument.CurrentRowState != DataRowState.Added)
            {
                KissMsg.ShowInfo(CLASS_NAME, "MutierenNichtErlaubt", "Dokumente dürfen ab Status 'in Bearbeitung' nicht mehr mutiert werden.");
                return true;
            }

            return base.OnDeleteData();
        }

        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                qryGvDocument.Fill(_gvGesuchId);
                qryGvDocument.Last();
            }

            UpdateGui();
        }

        protected override void UpdateGui()
        {
            // Ab Status In Bearbeitung dürfen Dokumente zwar hinzugefügt, aber nicht mehr verändert werden..
            if (!qryGvDocument.IsEmpty
                && (_gvStatusCode == LOVsGenerated.GvStatus.InErfassung
                    || (_gvStatusCode == LOVsGenerated.GvStatus.InBearbeitung && (HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2))
                    || (_gvStatusCode == LOVsGenerated.GvStatus.InPruefung && (HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2))
                    || qryGvDocument.CurrentRowState == DataRowState.Added))
            {
                qryGvDocument.EnableBoundFields(true);
            }
            else
            {
                qryGvDocument.EnableBoundFields(false);

                // Wenn noch kein Dokument erfasst ist, darf es hinzugefügt werden
                if (DBUtil.IsEmpty(qryGvDocument[DBO.GvDocument.DocumentID]) && !qryGvDocument.IsEmpty)
                {
                    edtDokument.AllowEdit(true);
                }
            }

            EnableDisableButtons();
        }

        private void btnBearbeitungAbschliessen_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InPruefung, LOVsGenerated.GvBewilligung.BearbeitungAbschliessen);
        }

        private void btnBearbeitungAbschlussAufheben_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InBearbeitung, LOVsGenerated.GvBewilligung.AbschlussAufheben);
        }

        private void btnBearbeitungGesuchZurueckweisen_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InErfassung, LOVsGenerated.GvBewilligung.GesuchZurueckweisen);
        }

        private void btnErfassungAbschliessen_Click(object sender, EventArgs e)
        {
            if (!OnSaveData())
            {
                return;
            }

            var ohneDokCount = Utils.ConvertToInt(
                DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.GvDocument
                    WHERE GvGesuchID = {0}
                      AND DocumentID IS NULL;",
                    _gvGesuchId));

            if (ohneDokCount > 0 && !KissMsg.ShowQuestion(CLASS_NAME, "ErfassungAbschliessenOhneDokument", "Es gibt Einträge ohne hinterlegtes Dokument. Möchten Sie trotzdem fortfahren?"))
            {
                return;
            }

            StatusWechsel(LOVsGenerated.GvStatus.InBearbeitung, LOVsGenerated.GvBewilligung.ErfassungAbschliessen);
        }

        private void btnErfassungAbschlussAufheben_Click(object sender, EventArgs e)
        {
            StatusWechsel(LOVsGenerated.GvStatus.InErfassung, LOVsGenerated.GvBewilligung.AbschlussAufheben);
        }

        private void CtlGvBeilagenDokumente_Load(object sender, EventArgs e)
        {
            edtErfassungAbgeschlossen.DataMember = DBO.GvGesuch.ErfassungAbgeschlossen;
            edtErfassungAbgeschlossen.DataSource = _qryGvGesuch;

            BindControls();
        }

        private void DisableAllButtons()
        {
            // alle Buttons des Bewilligungsverfahrens deaktivieren
            btnErfassungAbschliessen.Enabled = false;
            btnErfassungAbschlussAufheben.Enabled = false;

            btnBearbeitungAbschliessen.Enabled = false;
            btnBearbeitungAbschlussAufheben.Enabled = false;
            btnBearbeitungGesuchZurueckweisen.Enabled = false;
        }

        private void edtAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                var search = KissLookupDialog.PrepareSearchString(edtAdressat.Text);
                e.Cancel = !dlg.SearchData(SQL_ADRESSAT, search, e.ButtonClicked, _personMlText, _institutionMlText);

                if (!e.Cancel)
                {
                    qryGvDocument[QRY_GV_DOCUMENT_ADRESSAT] = dlg["Name"];

                    var typCode = Utils.ConvertToInt(dlg["TypCode$"]);

                    if (typCode == 1)
                    {
                        // Person
                        qryGvDocument[DBO.GvDocument.BaPersonID] = dlg["ID$"];
                        qryGvDocument[DBO.GvDocument.BaInstitutionID] = null;
                    }
                    else if (typCode == 2)
                    {
                        // Institution
                        qryGvDocument[DBO.GvDocument.BaInstitutionID] = dlg["ID$"];
                        qryGvDocument[DBO.GvDocument.BaPersonID] = null;
                    }
                }
            }
        }

        private void EnableDisableButtons()
        {
            DisableAllButtons();

            // Buttons je nach Status aktivieren
            switch (_gvStatusCode)
            {
                case LOVsGenerated.GvStatus.InErfassung:
                    btnErfassungAbschliessen.Enabled = true;
                    break;

                case LOVsGenerated.GvStatus.InBearbeitung:
                    btnErfassungAbschlussAufheben.Enabled = true;

                    btnBearbeitungAbschliessen.Enabled = HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2;
                    btnBearbeitungGesuchZurueckweisen.Enabled = HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2;
                    break;

                case LOVsGenerated.GvStatus.InPruefung:
                    btnBearbeitungAbschlussAufheben.Enabled = HasKompetenzstufe0 || HasKompetenzstufe1 || HasKompetenzstufe2;
                    break;
            }
        }

        private void qryGvDocument_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction != null)
            {
                Session.Commit();
            }
        }

        private void qryGvDocument_AfterInsert(object sender, EventArgs e)
        {
            qryGvDocument[DBO.GvDocument.UserID] = Session.User.UserID;
            qryGvDocument[QRY_GV_DOCUMENT_AUTOR] = Session.User.LastFirstName;
            qryGvDocument[DBO.GvDocument.Datum] = DateTime.Now;
            qryGvDocument[DBO.GvDocument.GvGesuchID] = _gvGesuchId;
        }

        private void qryGvDocument_BeforeDelete(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();

                DBUtil.ExecSQL(@"
                    DELETE FROM dbo.XDocument
                    WHERE DocumentID = {0};",
                    qryGvDocument[DBO.GvDocument.DocumentID]);
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryGvDocument_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtStichworte, lblStichworte.Text);
        }

        private void qryGvDocument_PositionChanged(object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void SetupDataMembers()
        {
            edtDatum.DataMember = DBO.GvDocument.Datum;
            edtStichworte.DataMember = DBO.GvDocument.Stichworte;
            edtDokument.DataMember = DBO.GvDocument.DocumentID;
            edtBemerkungen.DataMember = DBO.GvDocument.Bemerkungen;
            edtAdressat.DataMember = QRY_GV_DOCUMENT_ADRESSAT;
            edtAutor.DataMember = QRY_GV_DOCUMENT_AUTOR;
        }

        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.GvDocument.Datum;
            colAutor.FieldName = QRY_GV_DOCUMENT_AUTOR;
            colStichworte.FieldName = DBO.GvDocument.Stichworte;
            colBemerkungen.FieldName = DBO.GvDocument.Bemerkungen;
            colDokVorhanden.FieldName = QRY_GV_DOCUMENT_DOK_VORHANDEN;
        }
    }
}