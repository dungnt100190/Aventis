using System;
using System.ComponentModel;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.IBE
{
    public partial class CtlBaPerson : KissUserControl
    {
        private const string CLASS_NAME = "CtlBaPerson";

        private int _baPersonID;
        private int _ftPersonID;

        public CtlBaPerson()
        {
            InitializeComponent();
        }

        public int BaPersonID
        {
            get
            {
                return _baPersonID;
            }

            set
            {
                _baPersonID = value;
                ctlBaPersonAdresse.BaPersonID = _baPersonID;
            }
        }

        public override KissUserControl DetailControl
        {
            get
            {
                if (tabPerson.SelectedTab == tabWohnsituation)
                {
                    return ctlBaPersonAdresse;
                }

                if (tabPerson.SelectedTab.Controls.Count == 1 && tabPerson.SelectedTab.Controls[0] is KissUserControl)
                {
                    return (KissUserControl)tabPerson.SelectedTab.Controls[0];
                }

                return base.DetailControl;
            }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                case "BAPERSONID":
                    return qryBaPerson[DBO.BaPerson.BaPersonID];
            }

            return base.GetContextValue(fieldName);
        }

        public DateTime? GetDatumWegzug()
        {
            return edtWegzugDatum.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugGemeinde()
        {
            return edtZuzugGdeDatum.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugKt()
        {
            return edtZuzugKtDatum.EditValue as DateTime?;
        }

        public void Init(string titleName, Image titleImage, int personID, int ftPersonID, bool isFallTraeger)
        {
            lblTitel.Text = titleName;
            picTitle.Image = titleImage;

            BaPersonID = personID;
            _ftPersonID = ftPersonID;

            tabPerson.SelectedTabIndex = 0;

            OpenData(BaPersonID);

            var setDossiertraeger = DBUtil.GetConfigBool(@"System\Basis\DossiertraegerSetzen", false);
            if (setDossiertraeger)
            {
                SetDossiertraegerIfEmpty();
            }
        }

        public void OpenData(int personID)
        {
            BaPersonID = personID;

            //Personalien
            qryBaPerson.Fill(BaPersonID);

            // Zahlungsweg anzeigen:
            ctlZahlungsweg.BaPersonID = BaPersonID;

            // Kopfquote anzeigen:
            qryKopfquote.Fill(BaPersonID);

            // EditMode von Haushaltvers.-Nr. setzen
            if (!qryBaPerson.IsEmpty)
            {
                bool userHasRightEditHaushaltVersicherungsNr = DBUtil.UserHasRight("CtlBaPerson_EditHaushaltVersicherungsNr");
                bool canEdit = qryBaPerson.CanUpdate;
                edtHaushaltVersicherungsNr.EditMode = canEdit && userHasRightEditHaushaltVersicherungsNr
                                                          ? EditModeType.Normal
                                                          : EditModeType.ReadOnly;
            }

            HandleRequiredFieldsOfQuote();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            var resultBase = base.ReceiveMessage(parameters);

            var result = BaUtils.ReceiveMessageBaPerson(parameters, tabPerson, tabWohnsituation, ctlBaPersonAdresse);

            return resultBase && result;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var dlg = new DlgDemographieH();
            dlg.Init("", picTitle.Image, BaPersonID, _ftPersonID, false);
            dlg.ShowDialog(Session.MainForm);
        }

        private void chkAktiveQuote_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAktiveQuote.Checked)
            {
                chkPassiveQuote.Checked = false;

                if (chkPassiveQuote.UserModified)
                {
                    SetQuoteVonBisToNull();
                }
            }

            HandleRequiredFieldsOfQuote();
        }

        private void chkPassiveQuote_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassiveQuote.Checked)
            {
                chkAktiveQuote.Checked = false;

                if (chkPassiveQuote.UserModified)
                {
                    SetQuoteVonBisToNull();
                }
            }

            HandleRequiredFieldsOfQuote();
        }

        private void CtlBaDemographie_AddData(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Insert();
            }
        }

        private void CtlBaDemographie_DeleteData(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Delete();
            }
        }

        private void CtlBaDemographie_MoveFirst(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.First();
            }
        }

        private void CtlBaDemographie_MoveLast(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Last();
            }
        }

        private void CtlBaDemographie_MoveNext(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Last();
            }
        }

        private void CtlBaDemographie_MovePrevious(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Previous();
            }
        }

        private void CtlBaDemographie_RefreshData(object sender, EventArgs e)
        {
            if (!qryBaPerson.Post())
            {
                return;
            }

            if (!qryKopfquote.Post())
            {
                return;
            }

            qryBaPerson.Refresh();
            qryKopfquote.Refresh();
            ctlZahlungsweg.qryBaZahlungsweg.Refresh();
        }

        private void CtlBaDemographie_SaveData(object sender, EventArgs e)
        {
            if (!qryBaPerson.Post())
            {
                return;
            }

            if (!qryKopfquote.Post())
            {
                return;
            }
        }

        private void CtlBaDemographie_UndoDataChanges(object sender, EventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 3)
            {
                qryKopfquote.Cancel();
            }
        }

        private void CtlBaPerson_Load(object sender, EventArgs e)
        {
            edtZuzugGde.GetDatum = GetDatumZuzugGemeinde;
            edtZuzugKt.GetDatum = GetDatumZuzugKt;
            edtWegzug.GetDatum = GetDatumWegzug;
        }

        private void edtBaPersonID_Dossiertraeger_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtBaPersonID_Dossiertraeger.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    // Falls Eingabefeld leer ist, dann soll beim Mausklick alles angezeigt werden:
                    searchString = "%";
                }
                else
                {
                    // sonst soll aktuelle Eingabe gelöscht werden:
                    qryBaPerson[DBO.BaPerson.BaPersonID_Dossiertraeger] = DBNull.Value;
                    qryBaPerson["Dossiertraeger"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();

            if (searchString == ".")
            {
                // Klientensystem anzeigen
                e.Cancel = !dlg.SearchData(@"
                    DECLARE @BaPersonID INT;
                    SET @BaPersonID = {1};

                    SELECT *
                    FROM (SELECT BaPersonID = BaPersonID_2,
                                 Name       = PRS.NameVorname
                          FROM dbo.BaPerson_Relation      BRE WITH (READUNCOMMITTED)
                            INNER JOIN dbo.vwPersonSimple PRS ON PRS.BaPersonID = BRE.BaPersonID_2
                          WHERE BRE.BaPersonID_1 = @BaPersonID

                          UNION

                          SELECT BaPersonID = BaPersonID_1,
                                 Name       = PRS.NameVorname
                          FROM dbo.BaPerson_Relation      BRE WITH (READUNCOMMITTED)
                            INNER JOIN dbo.vwPersonSimple PRS ON PRS.BaPersonID = BRE.BaPersonID_1
                          WHERE BRE.BaPersonID_2 = @BaPersonID

                          UNION

                          SELECT BaPersonID = BaPersonID,
                                 Name       = PRS.NameVorname
                          FROM dbo.vwPersonSimple PRS
                          WHERE PRS.BaPersonID = @BaPersonID
                         ) TMP
                    ORDER BY CASE WHEN BaPersonID = {2} THEN 0 ELSE 1 END, Name;",
                    searchString,
                    e.ButtonClicked,
                    _baPersonID,
                    _ftPersonID);
            }
            else
            {
                // Dialog anzeigen:
                e.Cancel = !dlg.SearchData(@"
                    SELECT Code = BaPersonID,
                           Text = NameVorname
                    FROM dbo.vwPersonSimple PRS
                    WHERE PRS.NameVorname LIKE '%' + {0} + '%'
                    ORDER BY 2;",
                    searchString,
                    e.ButtonClicked);
            }

            if (!e.Cancel)
            {
                qryBaPerson[DBO.BaPerson.BaPersonID_Dossiertraeger] = dlg[0];
                qryBaPerson["Dossiertraeger"] = dlg[1];
            }
        }

        private void edtKopfquote_BaInstitutionID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtKopfquote_BaInstitutionID.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            SaveKopfquoteValuesBeforeRefresh();

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    // Falls Eingabefeld leer ist, dann soll beim Mausklick alles angezeigt werden:
                    searchString = "%";
                }
                else
                {
                    // sonst soll aktuelle Eingabe gelöscht werden:
                    qryBaPerson[DBO.BaPerson.Kopfquote_BaInstitutionID] = DBNull.Value;
                    qryBaPerson["KopfquoteInstitution"] = DBNull.Value;
                    return;
                }
            }

            // Dialog anzeigen:
            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$ = I.BaInstitutionID,
                       Institution = I.Name,
                       Strasse = A.Strasse + IsNull(' '+A.HausNr,''),
                       Ort = IsNull(A.PLZ,'') + IsNull(' '+A.Ort,'')
                FROM dbo.BaInstitution I WITH (READUNCOMMITTED)
                  LEFT OUTER JOIN dbo.BaAdresse A WITH (READUNCOMMITTED) ON A.BaInstitutionID = I.BaInstitutionID
                WHERE I.Name LIKE '%' + {0} + '%'
                ORDER BY I.Name;",
                searchString,
                e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBaPerson[DBO.BaPerson.Kopfquote_BaInstitutionID] = dlg[0];
                qryBaPerson["KopfquoteInstitution"] = dlg[1];
            }
        }

        private void HandleRequiredFieldsOfQuote()
        {
            EditModeType editMode;
            if (chkAktiveQuote.Checked || chkPassiveQuote.Checked)
            {
                editMode = EditModeType.Required;
            }
            else
            {
                editMode = EditModeType.ReadOnly;
                if (chkPassiveQuote.UserModified || chkAktiveQuote.UserModified)
                {
                    SetQuoteVonBisToNull();
                }
            }

            edtQuoteVon.EditMode = editMode;
            edtQuoteBis.EditMode = editMode;
        }

        private void qryBaPerson_AfterPost(object sender, EventArgs e)
        {
            if (!qryKopfquote.Post())
            {
                throw new KissCancelException();
            }
        }

        private void qryBaPerson_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryBaPerson_BeforePost(object sender, EventArgs e)
        {
            edtWegzug.DoValidate();
            edtUntWohnsitz.DoValidate();
            edtZuzugKt.DoValidate();
            edtZuzugGde.DoValidate();

            DBUtil.NewHistoryVersion();
            DBUtil.CheckNotNullField(edtName, "Name");
            DBUtil.CheckNotNullField(edtVorname, "Vorname");

            if (!edtVersichertennummer.ValidateVersNr(true, false))
            {
                // set focus
                edtVersichertennummer.Focus();

                // cancel, message already shown
                throw new KissCancelException(string.Empty);
            }

            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.Sterbedatum]) && (DateTime)qryBaPerson[DBO.BaPerson.Sterbedatum] > DateTime.Today)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "SterbedatumInZukunft",
                        "Das Sterbedatum liegt in der Zukunft!",
                        KissMsgCode.MsgInfo),
                    edtSterbeDatum);
            }

            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.Geburtsdatum]) && (DateTime)qryBaPerson[DBO.BaPerson.Geburtsdatum] > DateTime.Today)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "GeburtsdatumInZukunft",
                        "Das Geburtsdatum liegt in der Zukunft!",
                        KissMsgCode.MsgInfo),
                    edtGeburtstag);
            }

            // Adressen
            if (!Utils.isAddressEmpty(qryBaPerson,
              edtUntWohnsitz.EdtPLZ.DataMember,
              edtUntWohnsitz.EdtOrt.DataMember,
              edtUntWohnsitz.EdtKanton.DataMember))
            {
                DBUtil.CheckNotNullField(
                    edtUntWohnsitz.EdtOrt,
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "Unterstuetzungswohnsitz",
                        "Unterstützungswohnsitz - Ort"));
            }

            //InCHSeit
            if (!DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.InCHSeitGeburt]) && (bool)qryBaPerson[DBO.BaPerson.InCHSeitGeburt])
            {
                qryBaPerson[DBO.BaPerson.InCHSeit] = DBNull.Value;
            }

            if (chkAktiveQuote.Checked || chkPassiveQuote.Checked)
            {
                DBUtil.CheckNotNullField(edtQuoteVon, lblQuoteAb.Text);
                DBUtil.CheckNotNullField(edtQuoteBis, tabZUG.Title + " " + lblQuoteBis.Text);
            }
        }

        private void qryKopfquote_AfterInsert(object sender, EventArgs e)
        {
            qryKopfquote[DBO.BaKopfquote.BaPersonID] = BaPersonID;
        }

        private void qryKopfquote_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtRechnungDatum, lblRechnungDatum.Text);
        }

        private void SaveKopfquoteValuesBeforeRefresh()
        {
            qryBaPerson["AktiveKopfQuote"] = chkAktiveQuote.Checked;
            qryBaPerson["PassiveKopfQuote"] = chkPassiveQuote.Checked;
            qryBaPerson["KopfquoteAbDatum"] = edtQuoteVon.EditValue;
            qryBaPerson["KopfquoteBisDatum"] = edtQuoteBis.EditValue;
        }

        private void SetDossiertraegerIfEmpty()
        {
            if (DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.BaPersonID_Dossiertraeger]))
            {
                qryBaPerson[DBO.BaPerson.BaPersonID_Dossiertraeger] = _ftPersonID;
                var qryDossiertraeger = DBUtil.OpenSQL(@"
                    SELECT NameVorname = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
                           PRS.AktiveKopfQuote
                    FROM dbo.BaPerson PRS
                    WHERE BaPersonID = {0}",
                    _ftPersonID);

                qryBaPerson["Dossiertraeger"] = qryDossiertraeger["NameVorname"];

                if (qryDossiertraeger[DBO.BaPerson.AktiveKopfQuote] as bool? ?? false)
                {
                    KissMsg.ShowInfo(
                        CLASS_NAME,
                        "FalltraegerHatAktiveKopfquoteDossiertraegerPruefen",
                        "Bitte kontrollieren Sie das Feld 'Dossierträger' in der Maske 'Kopfquote'");
                }
            }
        }

        private void SetQuoteVonBisToNull()
        {
            edtQuoteVon.EditValue = null;
            edtQuoteBis.EditValue = null;
        }

        private void tabPerson_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabPerson.SelectedTabIndex == 2)
            {
                ActiveSQLQuery = ctlZahlungsweg.qryBaZahlungsweg;
            }
            else if (tabPerson.SelectedTabIndex == 3)
            {
                ActiveSQLQuery = null;
            }
            else
            {
                ActiveSQLQuery = qryBaPerson;
            }
        }

        private void tabPerson_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabPerson.SelectedTabIndex == 0)
            {
                e.Cancel = !qryBaPerson.Post();
            }
            else if (tabPerson.SelectedTabIndex == 2)
            {
                e.Cancel = !ctlZahlungsweg.qryBaZahlungsweg.Post();
            }
            else if (tabPerson.SelectedTabIndex == 3)
            {
                e.Cancel = !qryBaPerson.Post();
                if (e.Cancel)
                {
                    return;
                }

                e.Cancel = !qryKopfquote.Post();
            }
        }
    }
}