using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    public partial class CtlKesMassnahme : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "KesMassnahme";
        private const string QRY_ABSATZ = "Absatz";
        private const string QRY_ARTIKEL = "Artikel";
        private const string QRY_ARTIKEL_BEZEICHNUNG_M = "ArtikelBezeichnung_M";
        private const string QRY_ARTIKEL_BEZEICHNUNG_N = "ArtikelBezeichnung_N";
        private const string QRY_ARTIKEL_M = "Artikel_M";
        private const string QRY_ARTIKEL_N = "Artikel_N";
        private const string QRY_AUFGABENBEREICH = "Aufgabenbereich";
        private const string QRY_BEISTAND = "Beistand";
        private const string QRY_BEZEICHNUNG = "Bezeichnung";
        private const string QRY_BEZEICHNUNG_M = "Bezeichnung_M";
        private const string QRY_BEZEICHNUNG_N = "Bezeichnung_N";
        private const string QRY_GUELTIG_AB = "GueltigAb";
        private const string QRY_GUELTIG_BIS = "GueltigBis";
        private const string QRY_PLATZIERUNG_BAINSTITUTIONNAME = "Platzierung_BaInstitutionName";
        private const string QRY_ZIFFER = "Ziffer";

        #endregion

        #region Private Fields

        private int _newKesMassnahmeTypCode;
        private int? _originalMassnahmeId;

        #endregion

        #endregion

        #region Constructors

        public CtlKesMassnahme()
        {
            InitializeComponent();

            SetupDataSource();
            SetupDataMembers();
            SetupFieldNames();
            SetupContext();

            EnableDisableButtonMassnahmeKopieren();
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Klick auf Button für das Kopieren der Massnahme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMassnahmeKopieren_Click(object sender, EventArgs e)
        {
            if (!qryKesMassnahme.Post())
            {
                return;
            }

            // Original MassnahmeId setzen, um die Massnahme kopieren zu können.
            _originalMassnahmeId = qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeBSSID] as int?;
            var aenderumgVom = qryKesMassnahme[DBO.KesMassnahmeBSS.AenderungVom];
            var aufhebungVom = qryKesMassnahme[DBO.KesMassnahmeBSS.AufhebungVom];
            var bemerkung = qryKesMassnahme[DBO.KesMassnahmeBSS.Bemerkung];
            var errichtungVom = qryKesMassnahme[DBO.KesMassnahmeBSS.ErrichtungVom];
            var faLeistungId = qryKesMassnahme[DBO.KesMassnahmeBSS.FaLeistungID];
            var kanton = qryKesMassnahme[DBO.KesMassnahmeBSS.Kanton];
            var aenderungsCode = qryKesMassnahme[DBO.KesMassnahmeBSS.KesAenderungsgrundCode];
            var massnahmegebundeneGeschaefte = qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_MassnahmegebundeneGeschaefte];
            var nichtMassnahmegebundeneGeschaefte = qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_NichtMassnahmegebundeneGeschaefte];
            var aufgabenbereich = qryKesMassnahme[DBO.KesMassnahmeBSS.KesAufgabenbereichCodes];
            var aufhebungsgrund = qryKesMassnahme[DBO.KesMassnahmeBSS.KesAufhebungsgrundCode];
            var kesbDokumentID = qryKesMassnahme[DBO.KesMassnahmeBSS.KESBDocumentID];
            var euDokumentID = qryKesMassnahme[DBO.KesMassnahmeBSS.DocumentID_Urkunde];
            var beistandsart = qryKesMassnahme[DBO.KesMassnahmeBSS.KesBeistandsartCode];
            var gefaehrdungsmeldungDurch = qryKesMassnahme[DBO.KesMassnahmeBSS.KesGefaehrdungsmeldungDurchCode];
            var indikation = qryKesMassnahme[DBO.KesMassnahmeBSS.KesIndikationCodes];
            var massnahmeTyp = qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeTypCode];
            var ort = qryKesMassnahme[DBO.KesMassnahmeBSS.Ort];
            var ortschaft = qryKesMassnahme[DBO.KesMassnahmeBSS.OrtschaftCode];
            var plz = qryKesMassnahme[DBO.KesMassnahmeBSS.PLZ];
            var uebernahmeVon = qryKesMassnahme[DBO.KesMassnahmeBSS.UebernahmeVom];
            var beistandswechsel = qryKesMassnahme[DBO.KesMassnahmeBSS.Beistandswechsel];
            var uebertragungVom = qryKesMassnahme[DBO.KesMassnahmeBSS.UebertragungVom];
            var beistand = qryKesMassnahme[QRY_BEISTAND];
            var userID = qryKesMassnahme[DBO.KesMassnahmeBSS.UserID];
            var vmPriMaID = qryKesMassnahme[DBO.KesMassnahmeBSS.VmPriMaID];
            var baInstitutionID = qryKesMassnahme[DBO.KesMassnahmeBSS.BaInstitutionID];
            var elterlicheSorgeCode = qryKesMassnahme[DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_ElterlicheSorge];
            var obhutCode = qryKesMassnahme[DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_Obhut];
            var artikelM = qryKesMassnahme[QRY_ARTIKEL_M];
            var bezeichnungM = qryKesMassnahme[QRY_BEZEICHNUNG_M];
            var artikelBezeichnungM = qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_M];
            var artikelN = qryKesMassnahme[QRY_ARTIKEL_N];
            var bezeichnungN = qryKesMassnahme[QRY_BEZEICHNUNG_N];
            var artikelBezeichnungN = qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_N];
            var platzierung = qryKesMassnahme[DBO.KesMassnahmeBSS.Platzierung_BaInstitutionID];
            var baInstitutionName = qryKesMassnahme[QRY_PLATZIERUNG_BAINSTITUTIONNAME];
            var fuersorgerischeUnterbringung = qryKesMassnahme[DBO.KesMassnahmeBSS.FuersorgerischeUnterbringung];
            var berichtsgenehmigungVom = qryKesMassnahme[DBO.KesMassnahmeBSS.BerichtsgenehmigungVom];
            var kesGrundlageCode = qryKesMassnahme[DBO.KesMassnahmeBSS.KesGrundlageCode];

            // Fügt einen neuen Datensatz ins Grid hinzu
            if (OnAddData())
            {
                qryKesMassnahme[DBO.KesMassnahmeBSS.AenderungVom] = aenderumgVom;
                qryKesMassnahme[DBO.KesMassnahmeBSS.AufhebungVom] = aufhebungVom;
                qryKesMassnahme[DBO.KesMassnahmeBSS.Bemerkung] = bemerkung;
                qryKesMassnahme[DBO.KesMassnahmeBSS.ErrichtungVom] = errichtungVom;
                qryKesMassnahme[DBO.KesMassnahmeBSS.FaLeistungID] = faLeistungId;
                qryKesMassnahme[DBO.KesMassnahmeBSS.Kanton] = kanton;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesAenderungsgrundCode] = aenderungsCode;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_MassnahmegebundeneGeschaefte] = massnahmegebundeneGeschaefte;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_NichtMassnahmegebundeneGeschaefte] = nichtMassnahmegebundeneGeschaefte;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesAufgabenbereichCodes] = aufgabenbereich;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesAufhebungsgrundCode] = aufhebungsgrund;
                qryKesMassnahme[DBO.KesMassnahmeBSS.DocumentID_Urkunde] = euDokumentID;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KESBDocumentID] = kesbDokumentID;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesBeistandsartCode] = beistandsart;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesGefaehrdungsmeldungDurchCode] = gefaehrdungsmeldungDurch;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesIndikationCodes] = indikation;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeTypCode] = massnahmeTyp;
                qryKesMassnahme[DBO.KesMassnahmeBSS.Ort] = ort;
                qryKesMassnahme[DBO.KesMassnahmeBSS.OrtschaftCode] = ortschaft;
                qryKesMassnahme[DBO.KesMassnahmeBSS.PLZ] = plz;
                qryKesMassnahme[DBO.KesMassnahmeBSS.UebernahmeVom] = uebernahmeVon;
                qryKesMassnahme[DBO.KesMassnahmeBSS.Beistandswechsel] = beistandswechsel;
                qryKesMassnahme[DBO.KesMassnahmeBSS.UebertragungVom] = uebertragungVom;
                qryKesMassnahme[QRY_BEISTAND] = beistand;
                qryKesMassnahme[DBO.KesMassnahmeBSS.UserID] = userID;
                qryKesMassnahme[DBO.KesMassnahmeBSS.VmPriMaID] = vmPriMaID;
                qryKesMassnahme[DBO.KesMassnahmeBSS.BaInstitutionID] = baInstitutionID;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_ElterlicheSorge] = elterlicheSorgeCode;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_Obhut] = obhutCode;
                qryKesMassnahme[QRY_ARTIKEL_M] = artikelM;
                qryKesMassnahme[QRY_BEZEICHNUNG_M] = bezeichnungM;
                qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_M] = artikelBezeichnungM;
                qryKesMassnahme[QRY_ARTIKEL_N] = artikelN;
                qryKesMassnahme[QRY_BEZEICHNUNG_N] = bezeichnungN;
                qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_N] = artikelBezeichnungN;

                qryKesMassnahme[DBO.KesMassnahmeBSS.Platzierung_BaInstitutionID] = platzierung;
                qryKesMassnahme[QRY_PLATZIERUNG_BAINSTITUTIONNAME] = baInstitutionName;
                qryKesMassnahme[DBO.KesMassnahmeBSS.FuersorgerischeUnterbringung] = fuersorgerischeUnterbringung;
                qryKesMassnahme[DBO.KesMassnahmeBSS.BerichtsgenehmigungVom] = berichtsgenehmigungVom;
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesGrundlageCode] = kesGrundlageCode;
            }

            qryKesMassnahme.Post();
        }

        private void edtAenderungsgrund_EditValueChanged(object sender, EventArgs e)
        {
            edtDatumAenderung.EditMode = !DBUtil.IsEmpty(edtAenderungsgrund.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtArtikelMassnahmegebundeneGeschaefte_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SearchDialogArtikel(e, edtArtikelMassnahmegebundeneGeschaefte, true);
        }

        private void edtArtikelNichtMassnahmegebundeneGeschaefte_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            SearchDialogArtikel(e, edtArtikelNichtMassnahmegebundeneGeschaefte, false);
        }

        private void edtAufhebungsgrund_EditValueChanged(object sender, EventArgs e)
        {
            edtDatumAufhebung.EditMode = !DBUtil.IsEmpty(edtAufhebungsgrund.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtDatumAenderung_EditValueChanged(object sender, EventArgs e)
        {
            edtAenderungsgrund.EditMode = !DBUtil.IsEmpty(edtDatumAenderung.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtDatumAufhebung_EditValueChanged(object sender, EventArgs e)
        {
            edtAufhebungsgrund.EditMode = !DBUtil.IsEmpty(edtDatumAufhebung.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtDatumUebertragung_EditValueChanged(object sender, EventArgs e)
        {
            edtPlzOrt.EditMode = !DBUtil.IsEmpty(edtDatumUebertragung.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtEsKs_EditValueChanged(object sender, EventArgs e)
        {
            int kesMassnahmeTypCode = Utils.ConvertToInt(edtEsKs.EditValue);
            SetupLOVsForMassnahmeTypCode(kesMassnahmeTypCode);
            SetupFuersorgerischeUnterbringungFU(kesMassnahmeTypCode);
        }

        private void edtMassnahmefuehrender_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            var kesBeistandsartCode = qryKesMassnahme[DBO.KesMassnahmeBSS.KesBeistandsartCode] as int?;

            e.Cancel = !dlg.MassnahmefuehrenderSuchen(edtMassnahmefuehrender.Text, kesBeistandsartCode, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryKesMassnahme[QRY_BEISTAND] = dlg["Name"];
                qryKesMassnahme[DBO.KesMassnahmeBSS.UserID] = dlg["UserID$"];
                qryKesMassnahme[DBO.KesMassnahmeBSS.VmPriMaID] = dlg["VmPriMaID$"];
                qryKesMassnahme[DBO.KesMassnahmeBSS.BaInstitutionID] = dlg["BaInstitutionID$"];
                qryKesMassnahme[DBO.KesMassnahmeBSS.KesBeistandsartCode] = dlg["KesBeistandsartCode$"];
            }
        }

        private void edtPlzOrt_EditValueChanged(object sender, EventArgs e)
        {
            edtDatumUebertragung.EditMode = !DBUtil.IsEmpty(edtPlzOrt.EditValue) ? EditModeType.Required : EditModeType.Normal;
        }

        private void edtSearchZGB_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dialogAuswahl = new DlgAuswahl())
            {
                var searchString = edtSearchZGB.Text;

                if (DBUtil.IsEmpty(searchString) && !e.ButtonClicked)
                {
                    //empty field
                    edtSearchZGB.EditValue = null;
                    edtSearchZGB.LookupID = null;

                    // done
                    e.Cancel = true;
                    return;
                }

                e.Cancel = !dialogAuswahl.SearchKesArtikel(searchString, null, null, e.ButtonClicked);

                if (!e.Cancel)
                {
                    edtSearchZGB.EditValue = dialogAuswahl["ArtikelGesetzBezeichnung$"];
                    edtSearchZGB.LookupID = dialogAuswahl["KesArtikelID$"];
                }
            }
        }

        private void qryKesMassnahme_AfterFill(object sender, EventArgs e)
        {
            grvKesMassnahme.BestFitColumns();
        }

        private void qryKesMassnahme_AfterInsert(object sender, EventArgs e)
        {
            qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeTypCode] = _newKesMassnahmeTypCode;
            qryKesMassnahme[DBO.KesMassnahmeBSS.FaLeistungID] = _faLeistungId;
            qryKesMassnahme[DBO.KesMassnahmeBSS.ErrichtungVom] = GetEldestErrichtungVom();
        }

        private void qryKesMassnahme_AfterPost(object sender, EventArgs e)
        {
            try
            {
                // Massnahme kopieren
                if (_originalMassnahmeId.HasValue)
                {
                    _originalMassnahmeId = null;
                }

                Session.Commit();
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryKesMassnahme_BeforeInsert(object sender, EventArgs e)
        {
            // Beim Kopieren muss keine Auswahl für den Massnahmetyp getätigt werden.
            if (_originalMassnahmeId.HasValue)
            {
                return;
            }

            //Benutzer fragen, ob ES oder KS
            using (var dlg = new KissLookupDialog("Erwachsenenschutz oder Kindesschutz"))
            {
                dlg.Height = 200;

                bool cancel = !dlg.SearchData(@"
                    SELECT Code$ = Code,
                           Text  = Text
                    FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                    WHERE LOVName = 'KesMassnahmeTyp'
                    ORDER BY SortKey;",
                    "",
                    true);

                if (cancel)
                {
                    throw new KissCancelException();
                }

                _newKesMassnahmeTypCode = Convert.ToInt32(dlg["Code$"]);
            }
        }

        /// <summary>
        /// Validierung der Mussfelder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryKesMassnahme_BeforePost(object sender, EventArgs e)
        {
            edtPlzOrt.DoValidate();

            DBUtil.CheckNotNullField(edtMassnahmefuehrender, lblMassnahmefuehrender.Text);
            DBUtil.CheckNotNullField(edtBeistandsart, lblBeistandsart.Text);
            DBUtil.CheckNotNullField(edtIndikationCodes, lblIndikation.Text);
            DBUtil.CheckNotNullField(edtDatumErrichtung, lblDatumErrichtung.Text);

            // Datumfelder und zugehörige Begründung validieren
            if (!DBUtil.IsEmpty(edtDatumAenderung.EditValue))
            {
                DBUtil.CheckNotNullField(edtAenderungsgrund, lblAenderungsgrund.Text);
            }

            if (!DBUtil.IsEmpty(edtAenderungsgrund.EditValue))
            {
                DBUtil.CheckNotNullField(edtDatumAenderung, lblDatumAenderung.Text);
            }

            if (!DBUtil.IsEmpty(edtDatumUebertragung.EditValue))
            {
                DBUtil.CheckNotNullField(edtPlzOrt, lblUebertragungAn.Text);
            }

            if (!DBUtil.IsEmpty(edtPlzOrt.EditValue))
            {
                DBUtil.CheckNotNullField(edtDatumUebertragung, lblDatumUebertragung.Text);
            }

            if (!DBUtil.IsEmpty(edtDatumAufhebung.EditValue))
            {
                DBUtil.CheckNotNullField(edtAufhebungsgrund, lblAufhebungsgrund.Text);
            }

            if (!DBUtil.IsEmpty(edtAufhebungsgrund.EditValue))
            {
                DBUtil.CheckNotNullField(edtDatumAufhebung, lblDatumAufhebung.Text);
            }

            Session.BeginTransaction();
            try
            {
                if (_originalMassnahmeId.HasValue)
                {
                    // Verfügung KESB
                    var documentId = qryKesMassnahme[DBO.KesMassnahmeBSS.KESBDocumentID] as int?;

                    if (documentId.HasValue)
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.KESBDocumentID] = CopyDokument(documentId.Value);
                    }

                    // Ernennungsurkunde
                    documentId = qryKesMassnahme[DBO.KesMassnahmeBSS.DocumentID_Urkunde] as int?;

                    if (documentId.HasValue)
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.DocumentID_Urkunde] = CopyDokument(documentId.Value);
                    }
                }
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        /// <summary>
        /// Button Massnahme Kopieren enablen oder disablen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryKesMassnahme_PositionChanged(object sender, EventArgs e)
        {
            EnableDisableButtonMassnahmeKopieren();
        }

        private void qryKesMassnahme_PostCompleted(object sender, EventArgs e)
        {
            EnableDisableButtonMassnahmeKopieren();
            if (!qryKesMassnahme.IsSilentPostingFromXDocument)
            {
                qryKesMassnahme.Refresh();
            }
        }

        private void SetupFuersorgerischeUnterbringungFU(int kesMassnahmeTypCode)
        {
            if (kesMassnahmeTypCode == 1) //1: ES
            {
                edtFuersorgerischeUnterbringungFU.Visible = true;
            }
            else if (kesMassnahmeTypCode == 2) //2: KS
            {
                edtFuersorgerischeUnterbringungFU.Visible = false;
            }
            else
            {
                //unbekannter KesMassnahmeTypCode
                throw new ArgumentException("Unbekannter KesMassnahmeTypCode: " + kesMassnahmeTypCode);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Init(string maskName, Image maskImage, int personID, int leistungID)
        {
            base.Init(maskName, maskImage, personID, leistungID);
            lblTitel.Text = maskName;
            picTitel.Image = maskImage;

            tabControlSearch.SelectedTabIndex = 0;

            NewSearchAndRun();

            colAenderungsgrund.ColumnEdit = grdKesMassnahme.GetLOVLookUpEdit("KesAenderungsgrund");

            // Spalte für logisches Löschen ausblenden
            colGeloescht.Visible = IsLogischesLoeschen;

            //Testrückmeldung - erste Zeile selektieren (anstelle standardmässig letzter Zeile)
            qryKesMassnahme.First();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //{0}: FaLeistungID
            //{1}: LogischesLoeschen (0: alle, 1: nur aktive, 2: nur gelöschte)
            kissSearch.SelectParameters = new[] { _faLeistungId, editVal, edtSearchZGB.LookupID };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private object CopyDokument(int documentIdSource)
        {
            var documentIdNew = DBUtil.ExecuteScalarSQL(@"
                DECLARE @DocumentID INT;
                DECLARE @CreatorModifier VARCHAR(255);
                DECLARE @UserID INT;

                SET @UserID = {0};
                SET @DocumentID = {1};

                SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);

                IF (@DocumentID IS NULL)
                BEGIN
                  RETURN;
                END;

                INSERT INTO dbo.XDocument (
                        UserID_Creator,
                        UserID_LastSave,
                        FileBinary,
                        DocFormatCode,
                        FileExtension,
                        DocReadOnly,
                        DocTemplateID,
                        DocTypeCode,
                        DocTemplateName
                        )
                  SELECT
                    UserID_Creator = @UserID,
                    UserID_LastSave = @UserID,
                    FileBinary,
                    DocFormatCode,
                    FileExtension,
                    DocReadOnly,
                    DocTemplateID,
                    DocTypeCode,
                    DocTemplateName
                  FROM XDocument
                  WHERE DocumentID = @DocumentID;

                SELECT DocumentID = SCOPE_IDENTITY();",
                Session.User.UserID,
                documentIdSource);

            return documentIdNew;
        }

        private void edtPlatzierung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtPlatzierung.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();

            if (e.ButtonClicked || !DBUtil.IsEmpty(searchString))
            {
                if (DBUtil.IsEmpty(searchString))
                {
                    searchString = "%";
                }

                e.Cancel = !dlg.SearchData(string.Format(@"
                    SELECT BainstitutionID,
                           Name  = INS.NameVorname,
                           Typen = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {1}, {2}),
                           Telefon,
                           Strasse,
                           Ort
                           PLZ,
                           Bemerkung,
                           Aktiv,
                           Anrede,
                           Homepage,
                           Debitor,
                           Kreditor,
                           Aktiv
                    FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                    WHERE INS.NameVorname LIKE '%' + {0} + '%';", DBUtil.SqlLiteral(searchString), Session.User.UserID, Session.User.LanguageCode),
                                           searchString,
                                           e.ButtonClicked);
            }

            if (!e.Cancel)
            {
                qryKesMassnahme[DBO.KesMassnahmeBSS.Platzierung_BaInstitutionID] = dlg["BainstitutionID"];
                qryKesMassnahme[QRY_PLATZIERUNG_BAINSTITUTIONNAME] = dlg["Name"];
            }
        }

        /// <summary>
        /// Button Massnahme Kopieren enablen oder disablen
        /// </summary>
        private void EnableDisableButtonMassnahmeKopieren()
        {
            var massnahmeId = qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeBSSID] as int?;
            btnMassnahmeKopieren.Enabled = massnahmeId.HasValue;
        }

        private DateTime? GetEldestErrichtungVom()
        {
            return DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 ErrichtungVom
                FROM dbo.KesMassnahmeBSS
                WHERE FaLeistungID = {0}
                    AND AufhebungVom IS NULL
                    AND UebertragungVom IS NULL
                    AND ErrichtungVom IS NOT NULL
                    AND IsDeleted = 0
                ORDER BY ErrichtungVom ASC;",
                _faLeistungId) as DateTime?;
        }

        private void SearchDialogArtikel(UserModifiedFldEventArgs e, KissButtonEdit artikelButton, bool isMassnahmegebunden)
        {
            using (var dialogAuswahl = new DlgAuswahl())
            {
                int massnahmeTyp = Convert.ToInt32(qryKesMassnahme[DBO.KesMassnahmeBSS.KesMassnahmeTypCode]);

                var searchString = artikelButton.Text;
                if (DBUtil.IsEmpty(searchString) && !e.ButtonClicked)
                {
                    //empty field
                    artikelButton.EditValue = null;
                    artikelButton.LookupID = null;

                    if (isMassnahmegebunden)
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_MassnahmegebundeneGeschaefte] = null;
                        qryKesMassnahme[QRY_ARTIKEL_M] = null;
                        qryKesMassnahme[QRY_BEZEICHNUNG_M] = null;
                        qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_M] = null;
                    }
                    else
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_NichtMassnahmegebundeneGeschaefte] = null;
                        qryKesMassnahme[QRY_ARTIKEL_N] = null;
                        qryKesMassnahme[QRY_BEZEICHNUNG_N] = null;
                        qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_N] = null;
                    }

                    // done
                    return;
                }

                e.Cancel = !dialogAuswahl.SearchKesArtikel(
                    searchString,
                    massnahmeTyp,
                    isMassnahmegebunden,
                    e.ButtonClicked);

                if (!e.Cancel)
                {
                    if (isMassnahmegebunden)
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_MassnahmegebundeneGeschaefte] = dialogAuswahl["KesArtikelID$"];
                        qryKesMassnahme[QRY_ARTIKEL_M] = dialogAuswahl["ArtikelGesetz$"];
                        qryKesMassnahme[QRY_BEZEICHNUNG_M] = dialogAuswahl["Bezeichnung"];
                        qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_M] = dialogAuswahl["ArtikelGesetzBezeichnung$"];
                    }
                    else
                    {
                        qryKesMassnahme[DBO.KesMassnahmeBSS.KesArtikelID_NichtMassnahmegebundeneGeschaefte] = dialogAuswahl["KesArtikelID$"];
                        qryKesMassnahme[QRY_ARTIKEL_N] = dialogAuswahl["ArtikelGesetz$"];
                        qryKesMassnahme[QRY_BEZEICHNUNG_N] = dialogAuswahl["Bezeichnung"];
                        qryKesMassnahme[QRY_ARTIKEL_BEZEICHNUNG_N] = dialogAuswahl["ArtikelGesetzBezeichnung$"];
                    }
                }
            }
        }

        private void SetupContext()
        {
            edtDokumentKESB.Context = CONTEXT_DOC;
            edtDokumentEU.Context = CONTEXT_DOC;
        }

        private void SetupDataMembers()
        {
            edtEsKs.DataMember = DBO.KesMassnahmeBSS.KesMassnahmeTypCode;

            edtMassnahmefuehrender.DataMember = QRY_BEISTAND;
            edtDatumErrichtung.DataMember = DBO.KesMassnahmeBSS.ErrichtungVom;
            edtDatumAenderung.DataMember = DBO.KesMassnahmeBSS.AenderungVom;
            edtDatumUebernahme.DataMember = DBO.KesMassnahmeBSS.UebernahmeVom;
            edtDatumUebertragung.DataMember = DBO.KesMassnahmeBSS.UebertragungVom;
            edtDatumAufhebung.DataMember = DBO.KesMassnahmeBSS.AufhebungVom;
            edtDatumBeistandswechsel.DataMember = DBO.KesMassnahmeBSS.Beistandswechsel;

            edtDokumentEU.DataMember = DBO.KesMassnahmeBSS.DocumentID_Urkunde;
            edtDokumentKESB.DataMember = DBO.KesMassnahmeBSS.KESBDocumentID;
            edtBeistandsart.DataMember = DBO.KesMassnahmeBSS.KesBeistandsartCode;
            edtGefaehrdungsmeldungDurch.DataMember = DBO.KesMassnahmeBSS.KesGefaehrdungsmeldungDurchCode;
            edtAenderungsgrund.DataMember = DBO.KesMassnahmeBSS.KesAenderungsgrundCode;
            edtPlzOrt.DataMember = DBO.KesMassnahmeBSS.OrtschaftCode;
            edtPlzOrt.DataMemberPLZ = DBO.KesMassnahmeBSS.PLZ;
            edtPlzOrt.DataMemberOrt = DBO.KesMassnahmeBSS.Ort;
            edtPlzOrt.DataMemberKanton = DBO.KesMassnahmeBSS.Kanton;
            edtPlzOrt.DataMemberLand = null;
            edtAufhebungsgrund.DataMember = DBO.KesMassnahmeBSS.KesAufhebungsgrundCode;

            edtArtikelMassnahmegebundeneGeschaefte.DataMember = QRY_ARTIKEL_BEZEICHNUNG_M;
            edtArtikelNichtMassnahmegebundeneGeschaefte.DataMember = QRY_ARTIKEL_BEZEICHNUNG_N;
            edtAufgabenbereichCodes.DataMember = DBO.KesMassnahmeBSS.KesAufgabenbereichCodes;

            edtIndikationCodes.DataMember = DBO.KesMassnahmeBSS.KesIndikationCodes;
            edtBemerkungen.DataMember = DBO.KesMassnahmeBSS.Bemerkung;

            edtElterlicheSorge.DataMember = DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_ElterlicheSorge;
            edtObhut.DataMember = DBO.KesMassnahmeBSS.KesElterlicheSorgeObhutCode_Obhut;
            edtGrundlage.DataMember = DBO.KesMassnahmeBSS.KesGrundlageCode;

            edtPlatzierung.DataMember = QRY_PLATZIERUNG_BAINSTITUTIONNAME;
            edtFuersorgerischeUnterbringungFU.DataMember = DBO.KesMassnahmeBSS.FuersorgerischeUnterbringung;
            edtDatumBerichtsgenehmigungVom.DataMember = DBO.KesMassnahmeBSS.BerichtsgenehmigungVom;
        }

        private void SetupDataSource()
        {
            edtEsKs.DataSource = qryKesMassnahme;

            edtMassnahmefuehrender.DataSource = qryKesMassnahme;
            edtDatumErrichtung.DataSource = qryKesMassnahme;
            edtDatumAenderung.DataSource = qryKesMassnahme;
            edtDatumUebernahme.DataSource = qryKesMassnahme;
            edtDatumUebertragung.DataSource = qryKesMassnahme;
            edtDatumAufhebung.DataSource = qryKesMassnahme;
            edtDatumBeistandswechsel.DataSource = qryKesMassnahme;

            edtDokumentEU.DataSource = qryKesMassnahme;
            edtDokumentKESB.DataSource = qryKesMassnahme;
            edtBeistandsart.DataSource = qryKesMassnahme;
            edtGefaehrdungsmeldungDurch.DataSource = qryKesMassnahme;
            edtAenderungsgrund.DataSource = qryKesMassnahme;
            edtPlzOrt.DataSource = qryKesMassnahme;
            edtAufhebungsgrund.DataSource = qryKesMassnahme;

            edtArtikelMassnahmegebundeneGeschaefte.DataSource = qryKesMassnahme;
            edtArtikelNichtMassnahmegebundeneGeschaefte.DataSource = qryKesMassnahme;
            edtAufgabenbereichCodes.DataSource = qryKesMassnahme;

            edtIndikationCodes.DataSource = qryKesMassnahme;
            edtBemerkungen.DataSource = qryKesMassnahme;

            edtElterlicheSorge.DataSource = qryKesMassnahme;
            edtObhut.DataSource = qryKesMassnahme;
            edtGrundlage.DataSource = qryKesMassnahme;

            edtPlatzierung.DataSource = qryKesMassnahme;
            edtFuersorgerischeUnterbringungFU.DataSource = qryKesMassnahme;
            edtDatumBerichtsgenehmigungVom.DataSource = qryKesMassnahme;
        }

        private void SetupFieldNames()
        {
            colAbsatz.FieldName = QRY_ABSATZ;
            colAenderungsgrund.FieldName = DBO.KesMassnahmeBSS.KesAenderungsgrundCode;
            colArtikel.FieldName = QRY_ARTIKEL;
            colAufgabenbereich.FieldName = QRY_AUFGABENBEREICH;
            colBeistand.FieldName = QRY_BEISTAND;
            colBemerkungen.FieldName = DBO.KesMassnahmeBSS.Bemerkung;
            colBezeichnung.FieldName = QRY_BEZEICHNUNG;
            colGeloescht.FieldName = DBO.KesMassnahmeBSS.IsDeleted;
            colGueltigAb.FieldName = QRY_GUELTIG_AB;
            colGueltigBis.FieldName = QRY_GUELTIG_BIS;
            colZiffer.FieldName = QRY_ZIFFER;
        }

        private void SetupLOVsForMassnahmeTypCode(int kesMassnahmeTypCode)
        {
            if (kesMassnahmeTypCode == 1) //1: ES
            {
                edtAufgabenbereichCodes.LOVName = "KesAufgabenbereichES";
                edtAufgabenbereichCodes.EditMode = EditModeType.Normal;

                edtAufhebungsgrund.LOVName = "KesAufhebungsgrundES";
                edtGefaehrdungsmeldungDurch.LOVName = "KesGefaehrdungsmeldungDurchES";
                edtIndikationCodes.LOVName = "KesIndikationES";

                edtElterlicheSorge.EditMode = EditModeType.ReadOnly;
                edtObhut.EditMode = EditModeType.ReadOnly;
                edtGrundlage.EditMode = EditModeType.ReadOnly;
            }
            else if (kesMassnahmeTypCode == 2) //2: KS
            {
                edtAufgabenbereichCodes.LOVName = null; //Nicht unterstützt bei KS
                edtAufgabenbereichCodes.EditMode = EditModeType.ReadOnly;

                edtAufhebungsgrund.LOVName = "KesAufhebungsgrundKS";
                edtGefaehrdungsmeldungDurch.LOVName = "KesGefaehrdungsmeldungDurchKS";
                edtIndikationCodes.LOVName = "KesIndikationKS";

                edtElterlicheSorge.EditMode = EditModeType.Normal;
                edtObhut.EditMode = EditModeType.Normal;
                edtGrundlage.EditMode = EditModeType.Normal;
            }
            else
            {
                //unbekannter KesMassnahmeTypCode
                throw new ArgumentException("Unbekannter KesMassnahmeTypCode: " + kesMassnahmeTypCode);
            }

            edtBeistandsart.LOVName = "KesBeistandsart";
            edtAenderungsgrund.LOVName = "KesAenderungsgrund";
        }

        #endregion

        #endregion
    }
}