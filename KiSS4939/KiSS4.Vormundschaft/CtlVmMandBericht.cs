using System;
using System.Drawing;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmMandBericht : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        //private const string COL_BERICHT = "VmBerichtstitelCodeText";
        private const string COL_USERNAMEVORNAME = "UserNameVorname";
        private const string COL_VMBERICHTTEXT = "VmBerichtText";
        private const string CONTEXT_DOC = "VmMfBericht";
        private const string LOV_BERICHTSTITEL = "VmBerichtstitel";

        #endregion

        #endregion

        #region Constructors

        public CtlVmMandBericht()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
            SetupContext();
            SetupLogischesLoeschen();
        }

        #endregion

        #region EventHandlers

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }




        private void edtBericht_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (!edtBericht.UserModified)
            {
                return;
            }

            var searchString = edtBericht.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (string.IsNullOrEmpty(searchString))
            {
                qryVmMandBericht[DBO.VmMandBericht.VmBerichtID] = DBNull.Value;
                qryVmMandBericht[COL_VMBERICHTTEXT] = string.Empty;
                return;
            }

            if (searchString.Equals("."))
            {
                searchString = "%";
            }

            var dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(@"
                SELECT ID$             = VBR.VmBerichtID,
                       Mandant         = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                       Berichtsperiode = CONVERT(VARCHAR, VBR.BerichtsperiodeVon, 104) + ' - ' +
                                         CONVERT(VARCHAR, VBR.BerichtsperiodeBis, 104),
                       Erstellung      = VBR.Erstellung
                FROM dbo.FaLeistung        FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.VmBericht VBR WITH (READUNCOMMITTED) ON VBR.FaLeistungID = FAL.FaLeistungID
                  INNER JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
                WHERE FAL.BaPersonID IN (SELECT BaPersonID 
                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                         WHERE FaLeistungID = {1})
                  AND CONVERT(VARCHAR, VBR.BerichtsperiodeVon, 104) + ' - ' + CONVERT(VARCHAR, VBR.BerichtsperiodeVon, 104) LIKE {0} + '%'
                ORDER BY VBR.BerichtsperiodeVon;", searchString, e.ButtonClicked, _faLeistungId, null, null);

            if (e.Cancel)
            {
                return;
            }

            qryVmMandBericht[DBO.VmMandBericht.VmBerichtID] = dlg[0];
            qryVmMandBericht[COL_VMBERICHTTEXT] = dlg[2];
        }

        private void edtZieleWirkung_SelectedIndexChanged(object sender, EventArgs e)
        {
            int editVal = Convert.ToInt32(edtZieleWirkung.EditValue);

            if (Utils.ConvertToInt(qryVmMandBericht[DBO.VmMandBericht.VmZielErreichtCode]) == editVal)
            {
                return;
            }

            if (editVal > 0)
            {
                qryVmMandBericht[DBO.VmMandBericht.VmZielErreichtCode] = editVal;
            }
            else
            {
                qryVmMandBericht[DBO.VmMandBericht.VmZielErreichtCode] = 1;
            }
        }

        private void qryVmMandBericht_AfterInsert(object sender, EventArgs e)
        {
            qryVmMandBericht[DBO.VmMandBericht.FaLeistungID] = _faLeistungId;
            qryVmMandBericht.SetCreator();
        }

        private void qryVmMandBericht_BeforePost(object sender, EventArgs e)
        {
            qryVmMandBericht.SetModifierModified();
        }

        private void qryVmMandBericht_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmMandBericht.IsEmpty)
            {
                tabControlDetail.Enabled = false;
            }
            else
            {
                tabControlDetail.Enabled = true;

                //RadioGrp
                int codeZieleErreicht = Utils.ConvertToInt(qryVmMandBericht[DBO.VmMandBericht.VmZielErreichtCode]);
                if (codeZieleErreicht > 0)
                {
                    //Hässlich
                    edtZieleWirkung.SelectedIndex = codeZieleErreicht - 1;
                }
                else
                {
                    edtZieleWirkung.SelectedIndex = 0;
                }
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmMandBericht.IsEmpty)
            {
                tabControlDetail.Enabled = true;
            }
            else
            {
                tabControlDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);

            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            tabControlDetail.SelectTab(tpgMassnahmeZielsetzung);

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Deaktiviert controls, je nachdem, ob ein Datensatz
        /// logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            //1. Register
            edtBerichtTyp.EditMode = editMode;
            edtBerichtstitel.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtBericht.EditMode = editMode;
            edtPeriodeVom.EditMode = editMode;
            edtPeriodeBis.EditMode = editMode;
            edtGrundMassnahmeText.EditMode = editMode;
            edtAuftragZielsetzung.EditMode = editMode;
            edtZieleWirkung.EditMode = editMode;
            edtVeraenderungInBerichtsperiode.EditMode = editMode;
            edtBegruendung.EditMode = editMode;
            edtNeueZielsetzung.EditMode = editMode;

            //2. Register
            edtWohnen.EditMode = editMode;
            edtSozialeKompetenzen.EditMode = editMode;
            edtVerhalten.EditMode = editMode;
            edtTaetigkeit.EditMode = editMode;
            edtWohnenText.EditMode = editMode;
            edtGesundheitText.EditMode = editMode;
            edtVerhaltenText.EditMode = editMode;
            edtTaetigkeitText.EditMode = editMode;
            edtFamiliaereSituation.EditMode = editMode;
            edtSozialeKompetenzen.EditMode = editMode;
            edtFreizeit.EditMode = editMode;
            edtBesondereResourcen.EditMode = editMode;
            edtFamiliaereSituationText.EditMode = editMode;
            edtSozialeKompetenzenText.EditMode = editMode;
            edtFreizeitText.EditMode = editMode;
            edtBesondereResourcenText.EditMode = editMode;
            edtGesundheit.EditMode = editMode;

            //3. Register
            edtWichtigeAufgabenUndHandlungen.EditMode = editMode;
            edtBesondereSchwierigkeitenText.EditMode = editMode;
            edtKlient.EditMode = editMode;
            edtDritten.EditMode = editMode;
            edtInstitutionen.EditMode = editMode;
            edtKlientText.EditMode = editMode;
            edtDrittenText.EditMode = editMode;
            edtInstitutionenText.EditMode = editMode;
            edtMandatsfuehrung.EditMode = editMode;
            edtAdministrator.EditMode = editMode;
            edtMandatsfuehrungText.EditMode = editMode;
            edtAdministratorText.EditMode = editMode;

            //4. Register
            edtEinnahmen.EditMode = editMode;
            edtVersicherungen.EditMode = editMode;
            edtBesondereAngaben.EditMode = editMode;
            edtEinnahmenBemerkungen.EditMode = editMode;
            edtVersicherungenBemerkungen.EditMode = editMode;
            edtBesondereAngabenBemerkungen.EditMode = editMode;
            edtAbrechnungUnterschrieben.EditMode = editMode;
            edtNimmtAnPassationTeil.EditMode = editMode;
            edtBemerkungen.EditMode = editMode;

            //5. Register
            edtAntragEKSK.EditMode = editMode;
            edtBerichtAntragBegruendung.EditMode = editMode;
            edtBerichtErstellung.EditMode = editMode;
            edtBeilagen.EditMode = editMode;
            edtBerichtAbrechnungUndBelege.EditMode = editMode;
            edtBelegeZurueckVonRevision.EditMode = editMode;
            edtBerichZurueckVonBS.EditMode = editMode;
            edtBereichsart.EditMode = editMode;
            edtAutor.EditMode = editMode;
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...      
        /// </summary>
        protected override void RunSearch()
        {
            bool isDeleted1;
            bool isDeleted2;

            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //Nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

            //Alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

            //Nur gelöschte Dokumente anzeigen
            else
            {
                isDeleted1 = true;
                isDeleted2 = true;
            }

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2 };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            edtDocument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            //1. Register
            edtBerichtTyp.DataMember = DBO.VmMandBericht.VmGrundMassnahmeCode;
            edtBerichtstitel.DataMember = DBO.VmMandBericht.VmBerichtstitelCode;
            edtDocument.DataMember = DBO.VmMandBericht.DocumentID;
            edtBericht.DataMember = COL_VMBERICHTTEXT;
            edtPeriodeVom.DataMember = DBO.VmMandBericht.BerichtDatumVon;
            edtPeriodeBis.DataMember = DBO.VmMandBericht.BerichtDatumBis;
            edtGrundMassnahmeText.DataMember = DBO.VmMandBericht.GrundMassnahmeText;
            edtAuftragZielsetzung.DataMember = DBO.VmMandBericht.AuftragZielsetzungText;
            edtVeraenderungInBerichtsperiode.DataMember = DBO.VmMandBericht.VeraenderungInPeriode;
            edtBegruendung.DataMember = DBO.VmMandBericht.Begruendung;
            edtNeueZielsetzung.DataMember = DBO.VmMandBericht.NeueZieleText;

            //2. Register
            edtWohnen.DataMember = DBO.VmMandBericht.VmWohnenCode;
            edtSozialeKompetenzen.DataMember = DBO.VmMandBericht.VmGesundheitCode;
            edtVerhalten.DataMember = DBO.VmMandBericht.VmVerhaltenCode;
            edtTaetigkeit.DataMember = DBO.VmMandBericht.VmTaetigkeitCode;
            edtWohnenText.DataMember = DBO.VmMandBericht.WohnenText;
            edtGesundheitText.DataMember = DBO.VmMandBericht.GesundheitText;
            edtVerhaltenText.DataMember = DBO.VmMandBericht.VerhaltenText;
            edtTaetigkeitText.DataMember = DBO.VmMandBericht.TaetigkeitText;
            edtFamiliaereSituation.DataMember = DBO.VmMandBericht.FamiliaereSituation;
            edtSozialeKompetenzen.DataMember = DBO.VmMandBericht.SozialeKompetenzen;
            edtFreizeit.DataMember = DBO.VmMandBericht.Freizeit;
            edtBesondereResourcen.DataMember = DBO.VmMandBericht.Resourcen;
            edtFamiliaereSituationText.DataMember = DBO.VmMandBericht.FamSituationText;
            edtSozialeKompetenzenText.DataMember = DBO.VmMandBericht.SozialeKompetenzenText;
            edtFreizeitText.DataMember = DBO.VmMandBericht.FreizeitText;
            edtBesondereResourcenText.DataMember = DBO.VmMandBericht.BesondereRessourcenText;
            edtGesundheit.DataMember = DBO.VmMandBericht.VmGesundheitCode;

            //3. Register
            edtWichtigeAufgabenUndHandlungen.DataMember = DBO.VmMandBericht.HandlungenText;
            edtBesondereSchwierigkeitenText.DataMember = DBO.VmMandBericht.BesondereSchwierigkeitenText;
            edtKlient.DataMember = DBO.VmMandBericht.Klient;
            edtDritten.DataMember = DBO.VmMandBericht.Dritte;
            edtInstitutionen.DataMember = DBO.VmMandBericht.Institutionen;
            edtKlientText.DataMember = DBO.VmMandBericht.KlientText;
            edtDrittenText.DataMember = DBO.VmMandBericht.DritteText;
            edtInstitutionenText.DataMember = DBO.VmMandBericht.InstitutionenText;
            edtMandatsfuehrung.DataMember = DBO.VmMandBericht.VmBerichtBelastungsangabeMCSCCode_Mandat;
            edtAdministrator.DataMember = DBO.VmMandBericht.VmBerichtBelastungsangabeMCSCCode_Admin;
            edtMandatsfuehrungText.DataMember = DBO.VmMandBericht.BelastungMandatText;
            edtAdministratorText.DataMember = DBO.VmMandBericht.BelastungAdminText;

            //4. Register
            edtEinnahmen.DataMember = DBO.VmMandBericht.VmEinnahmenAngabenCodes;
            edtVersicherungen.DataMember = DBO.VmMandBericht.VmBerichtVersicherungenCodes;
            edtBesondereAngaben.DataMember = DBO.VmMandBericht.VmBerichtBesondereAngabenCodes;
            edtEinnahmenBemerkungen.DataMember = DBO.VmMandBericht.EinnahmenBemerkungen;
            edtVersicherungenBemerkungen.DataMember = DBO.VmMandBericht.VersicherungenBemerkungen;
            edtBesondereAngabenBemerkungen.DataMember = DBO.VmMandBericht.BesondereAngabenBemerkungen;
            edtAbrechnungUnterschrieben.DataMember = DBO.VmMandBericht.AbrechnungUnterschrieben;
            edtNimmtAnPassationTeil.DataMember = DBO.VmMandBericht.PassationTeilnahme;
            edtBemerkungen.DataMember = DBO.VmMandBericht.PassationBemerkung;

            //5. Register
            edtAntragEKSK.DataMember = DBO.VmMandBericht.VmAntragBerichtCode;
            edtBerichtAntragBegruendung.DataMember = DBO.VmMandBericht.AntragBegruendung;
            edtBerichtErstellung.DataMember = DBO.VmMandBericht.ErstellungDatum;
            edtBeilagen.DataMember = DBO.VmMandBericht.VmMfBerichtBeilagenCode;
            edtBerichtAbrechnungUndBelege.DataMember = DBO.VmMandBericht.BsDatum;
            edtBelegeZurueckVonRevision.DataMember = DBO.VmMandBericht.BelegeZurueckRevision;
            edtBerichZurueckVonBS.DataMember = DBO.VmMandBericht.ZurueckVomBS;
            edtBereichsart.DataMember = DBO.VmMandBericht.VmBerichtsartCode;
            edtAutor.DataMember = COL_USERNAMEVORNAME;
            edtAutor.DataMemberUserId = DBO.VmMandBericht.UserID;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colBericht.FieldName = DBO.VmMandBericht.VmBerichtstitelCode;
            colBericht.ColumnEdit = grdVmMandBericht.GetLOVLookUpEdit(LOV_BERICHTSTITEL);
            colVon.FieldName = DBO.VmMandBericht.BerichtDatumVon;
            colBis.FieldName = DBO.VmMandBericht.BerichtDatumBis;
            colAutor.FieldName = COL_USERNAMEVORNAME;
            colErstellt.FieldName = DBO.VmMandBericht.ErstellungDatum;
            colIsDeleted.FieldName = DBO.VmMandBericht.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtBerichtTitelSuche.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmMandBericht;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            //1. Register
            edtBerichtTyp.Tag = lblArt.Text;
            edtDocument.Tag = lblBericht.Text;
            edtBericht.Tag = lblPeriodeRegister.Text;
            edtPeriodeVom.Tag = lblBerichtPeriode.Text;
            edtPeriodeBis.Tag = lblBerichtPeriode.Text;
            edtGrundMassnahmeText.Tag = lblGrundMassnahme.Text;
            edtAuftragZielsetzung.Tag = lblAuftragZielsetzung.Text;
            edtZieleWirkung.Tag = lblZieleWirkung.Text;
            edtBegruendung.Tag = lblBegruendung.Text;
            edtNeueZielsetzung.Tag = lblNeueZielsetzung.Text;

            //2. Register
            edtWohnen.Tag = lblWohnen.Text;
            edtVerhalten.Tag = lblVerhalten.Text;
            edtTaetigkeit.Tag = lblTaetigkeit.Text;
            edtWohnenText.Tag = lblWohnen.Text;
            edtGesundheitText.Tag = lblGesundheit.Text;
            edtVerhaltenText.Tag = lblVerhalten.Text;
            edtTaetigkeitText.Tag = lblTaetigkeit.Text;
            edtFamiliaereSituationText.Tag = edtFamiliaereSituation.Text;
            edtSozialeKompetenzenText.Tag = edtSozialeKompetenzen.Text;
            edtFreizeitText.Tag = edtFreizeit.Text;
            edtBesondereResourcenText.Tag = edtBesondereResourcen.Text;
            edtGesundheit.Tag = lblGesundheit.Text;

            //3. Register
            edtWichtigeAufgabenUndHandlungen.Tag = lblWichtigeAufgabenUndHandlungen.Text;
            edtBesondereSchwierigkeitenText.Tag = lblBesondereSchwierigkeiten.Text;
            edtKlientText.Tag = edtKlient.Text;
            edtDrittenText.Tag = edtDritten.Text;
            edtInstitutionenText.Tag = edtInstitutionen.Text;
            edtMandatsfuehrung.Tag = lblMandatsfuehrung.Text;
            edtAdministrator.Tag = lblAdministrator.Text;
            edtMandatsfuehrungText.Tag = lblMandatsfuehrung.Text;
            edtAdministratorText.Tag = lblAdministrator.Text;

            //4. Register
            edtEinnahmen.Tag = lblEinnahmen.Text;
            edtVersicherungen.Tag = lblVericherungen.Text;
            edtBesondereAngaben.Tag = lblBesondereAngaben.Text;
            edtEinnahmenBemerkungen.Tag = lblEinnahmen.Text;
            edtVersicherungenBemerkungen.Tag = lblVericherungen.Text;
            edtBesondereAngabenBemerkungen.Tag = lblBesondereAngaben.Text;
            edtBemerkungen.Tag = lblBemerkungenBottom.Text;

            //5. Register
            edtAntragEKSK.Tag = lblAntragEKSK.Text;
            edtBerichtErstellung.Tag = lblBern.Text;
            edtBeilagen.Tag = lblBeilagen.Text;
            edtAutor.Tag = lblAutor.Text;
            edtBerichtAbrechnungUndBelege.Tag = lblBerichtAbrechnungUndBelege.Text;
            edtBelegeZurueckVonRevision.Tag = lblBelegeZurueckVonRevision.Text;
            edtBerichZurueckVonBS.Tag = lblBerichtZurueckVonBS.Text;
        }

        #endregion

        #endregion
    }
}
