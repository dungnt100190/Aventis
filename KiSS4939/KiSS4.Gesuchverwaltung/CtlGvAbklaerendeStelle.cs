using System;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Gesuchverwaltung
{
    public partial class CtlGvAbklaerendeStelle : GvBaseControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlGvAbklaerendeStelle";

        #endregion

        #region Private Fields

        private bool _hasKompetenzstufe;
        private bool _hasSpezialrechtAuswahlKgsUneingeschraenkt;
        private bool _hasSpezialrechtAuswahlKstUneingeschraenkt;
        private bool _hasSpezialrechtAuswahlSarUneingeschraenkt;
        private bool _isLoading;

        #endregion

        #endregion

        #region Constructors

        public CtlGvAbklaerendeStelle(SqlQuery qryGvGesuch, bool hasKompetenzstufe0, bool hasKompetenzstufe1, bool hasKompetenzstufe2)
            : base(qryGvGesuch, hasKompetenzstufe0, hasKompetenzstufe1, hasKompetenzstufe2)
        {
            InitializeComponent();
            SetupDataMembers();
            _hasKompetenzstufe = hasKompetenzstufe0 || hasKompetenzstufe1 || hasKompetenzstufe2;
        }

        #endregion

        #region Properties

        public int GvGesuchId
        {
            get { return (int)_qryGvGesuch[DBO.GvGesuch.GvGesuchID]; }
        }

        #endregion

        #region EventHandlers

        public override bool OnAddData()
        {
            qryAbklaerendeStelle.Refresh();
            if (!qryAbklaerendeStelle.IsEmpty)
            {
                KissMsg.ShowInfo(CLASS_NAME, "AbklaerendeStelleVorhanden", "Die Abklärende Stelle ist bereits vorhanden.");
                return false;
            }

            var result = base.OnAddData();
            if (result)
            {
                qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.GvGesuchID] = _gvGesuchId;
            }

            return result;
        }

        private void CtlGvAbklaerendeStelle_Load(object sender, EventArgs e)
        {
            ActiveSQLQuery = qryAbklaerendeStelle;

            // depending on rights, the user can see just his mandant or all
            _hasSpezialrechtAuswahlKgsUneingeschraenkt = DBUtil.UserHasRight(CtlGvGesuchverwaltung.SPEZIALRECHT_AUSWAHLKGS_UNEINGESCHRAENKT) ||
                                                         DBUtil.UserHasRight("AuswahlKGSUneingeschraenkt"); ;
            _hasSpezialrechtAuswahlKstUneingeschraenkt = DBUtil.UserHasRight("AuswahlKSTUneingeschraenkt");
            _hasSpezialrechtAuswahlSarUneingeschraenkt = DBUtil.UserHasRight("AuswahlSARUneingeschraenkt");

            // all mandanten the user can see
            SqlQuery qryMandanten =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = ORG.Mandantennummer,
                           [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Mandantennummer, -1)) + '   ' + ORG.ItemName
                    FROM dbo.XOrgUnit ORG
                    WHERE ORG.Mandantennummer IS NOT NULL
                      AND (1 = ISNULL({0}, 0) OR ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({1})) -- only special can select all
                    ORDER BY [Code], [Text];",
                    _hasSpezialrechtAuswahlKgsUneingeschraenkt,
                    Session.User.UserID);

            // setup edtSucheGeschaeftsbereich
            edtGeschaeftsbereich.EditMode = _hasSpezialrechtAuswahlKgsUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGeschaeftsbereich.Properties.DropDownRows = Math.Min(qryMandanten.Count, 14);
            edtGeschaeftsbereich.Properties.DataSource = qryMandanten;

            // setup edtKostenstelle
            edtKostenstelle.EditMode = _hasSpezialrechtAuswahlKstUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;

            // setup edtSARName
            edtSARName.EditMode = _hasSpezialrechtAuswahlSarUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = DBUtil.IsEmpty(edtKreditor.EditValue) ? string.Empty : edtKreditor.EditValue.ToString();
            searchString = KissLookupDialog.PrepareSearchString(searchString);

            if (searchString == ".")
            {
                using (var dlg = new DlgAuswahl())
                {
                    var faFallId = Utils.ConvertToInt(_qryGvGesuch[DBO.GvGesuch.BaPersonID]);
                    var result = dlg.SearchKreditor(faFallId, null, searchString, e.ButtonClicked);

                    if (result)
                    {
                        qryAbklaerendeStelle[DBO.GvAuszahlungPosition.BaZahlungswegID] = dlg["ID$"];
                        qryAbklaerendeStelle[DBO.vwKreditor.Kreditor] = dlg["Kreditor$"];
                        qryAbklaerendeStelle[DBO.vwKreditor.ZusatzInfo] = dlg["ZusatzInfo$"];
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                using (var dlg = new DlgAuswahlBaZahlungsweg())
                {
                    dlg.SucheBaZahlungsweg(searchString);

                    var transfer = false;

                    switch (dlg.Count)
                    {
                        case 0:
                            KissMsg.ShowInfo(CLASS_NAME, "Kreditor_KeineEinträge", "Keine zutreffenden Kreditor-Einträge gefunden!");
                            break;

                        case 1:
                            transfer = true;
                            break;

                        default:
                            transfer = dlg.ShowDialog(this) == DialogResult.OK;
                            break;
                    }

                    if (transfer)
                    {
                        qryAbklaerendeStelle[DBO.GvAuszahlungPosition.BaZahlungswegID] = dlg[DBO.BaZahlungsweg.BaZahlungswegID];
                        qryAbklaerendeStelle[DBO.vwKreditor.Kreditor] = dlg[DBO.vwKreditor.Kreditor];
                        qryAbklaerendeStelle[DBO.vwKreditor.ZusatzInfo] = dlg[DBO.vwKreditor.ZusatzInfo];
                        qryAbklaerendeStelle[DBO.vwKreditor.ReferenzNummer] = dlg[DBO.vwKreditor.ReferenzNummer];
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

            UpdateGui();
        }

        private void edtSARName_EditValueChanged(object sender, EventArgs e)
        {
            _qryGvGesuch["Autor"] = DBUtil.ExecuteScalarSQLThrowingException(
                @"SELECT dbo.fnGetLastFirstName({0}, NULL, NULL);",
                edtSARName.EditValue);
            _qryGvGesuch[DBO.GvGesuch.XUserID_Autor] = edtSARName.EditValue;
            qryAbklaerendeStelle.RowModified = true;
        }

        private void edtSucheGeschaeftsbereich_EditValueChanged(object sender, EventArgs e)
        {
            // fill other lookupedits depending on mandantennummer
            SetupLookupEditsForKostenstelle(edtGeschaeftsbereich.EditValue);
        }

        private void edtSucheKostenstelle_EditValueChanged(object sender, EventArgs e)
        {
            SetupLookupEditForSAR(edtKostenstelle.EditValue);
        }

        private void qryAbklaerendeStelle_BeforePost(object sender, EventArgs e)
        {
            if (!_isLoading)
            {
                edtPLZWohnsitz.DoValidate();
                DBUtil.CheckNotNullField(edtSARName, lblSAR.Text);
                _qryGvGesuch.Post();
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void LoadData(bool refresh)
        {
            if (refresh)
            {
                try
                {
                    _isLoading = true;
                    qryAbklaerendeStelle.Fill(GvGesuchId);
                    if (qryAbklaerendeStelle.IsEmpty)
                    {
                        // Insert in GvAbklaerendeStelle
                        qryAbklaerendeStelle.Insert();
                        qryAbklaerendeStelle[DBO.GvAbklaerendeStelle.GvGesuchID] = GvGesuchId;
                        qryAbklaerendeStelle.SetCreator();
                        qryAbklaerendeStelle.SetModifierModified();
                        qryAbklaerendeStelle.Post();
                    }

                    int mandantenummer = GetMandantennummer();
                    int kostenstelle = GetKostenstelle();

                    edtGeschaeftsbereich.EditValue = mandantenummer;
                    SetupLookupEditsForKostenstelle(mandantenummer);
                    edtKostenstelle.EditValue = kostenstelle;
                    edtSARName.EditValue = _qryGvGesuch[DBO.GvGesuch.XUserID_Autor];

                    SetFieldValuesDependingOnGvFondType();
                    SetEditMode();
                    UpdateGui();
                }
                finally
                {
                    _isLoading = false;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Holt die Kostenstelle vom Autor des Gesuchs.
        /// </summary>
        /// <returns></returns>
        private int GetKostenstelle()
        {
            int userIdAuthor = (int)_qryGvGesuch[DBO.GvGesuch.XUserID_Autor];
            int mandantennummer = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                    SELECT
                      ORG.Kostenstelle
                    FROM dbo.XUser                 USR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                             AND OUU.OrgUnitMemberCode = 2
                      INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE USR.UserID = {0};",
                    userIdAuthor), -1);
            return mandantennummer;
        }

        /// <summary>
        /// Holt die Mandantennummer vom Autor des Gesuchs
        /// </summary>
        /// <returns></returns>
        private int GetMandantennummer()
        {
            int userIdAuthor = (int)_qryGvGesuch[DBO.GvGesuch.XUserID_Autor];
            int mandantennummer = (int)DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnOrgUnitOfUserMandantenNr({0});", userIdAuthor);
            return mandantennummer;
        }

        private void SetEditMode()
        {
            // Solange Gesuch noch nicht abgeschlossen, dürfen Benutzer mit Kompetenzstufe 0, 1 oder 2
            // die Felder Beantragende Stelle, Kontaktperson,Strasse, Nr,Zusatz,PLZ,Ort, Kt.,Postfach, ohne Nr.,Region Amtsbezirk,Telefon,E-Mail
            //bearbeiten
            bool gesuchNochNichtAbgeschlossen = _gvStatusCode < LOVsGenerated.GvStatus.Abgeschlossen;

            //Benutzer mit Spezialrecht dürfen KGS, KST und SAR ändern, solange Prüfung noch nicht abgeschlossen wurde
            bool pruefungNochNichtAbgeschlossen = _gvStatusCode < LOVsGenerated.GvStatus.Beurteilt;

            edtKostenstelle.EditMode = pruefungNochNichtAbgeschlossen && _hasSpezialrechtAuswahlKstUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGeschaeftsbereich.EditMode = pruefungNochNichtAbgeschlossen && _hasSpezialrechtAuswahlKgsUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSARName.EditMode = pruefungNochNichtAbgeschlossen && _hasSpezialrechtAuswahlSarUneingeschraenkt ? EditModeType.Normal : EditModeType.ReadOnly;

            edtBeantragendeStelle.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtKontaktperson.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtStrasse.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtNr.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtZusatz.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtPLZWohnsitz.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtPostfach.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            chkPostfachOhneNr.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtRegionAmtsbezirk.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtTelefon.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;
            edtEMail.EditMode = gesuchNochNichtAbgeschlossen && _hasKompetenzstufe ? EditModeType.Normal : EditModeType.ReadOnly;

            //Kreditor / Refnr -> Keine Anpassungen
            if (!IsExternerFonds)
            {
                edtInfoKreditor.EditMode = EditModeType.ReadOnly;
                edtRefNr.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtInfoKreditor.EditMode = EditModeType.Normal;
                edtRefNr.EditMode = EditModeType.Normal;
            }
        }

        private void SetFieldValuesDependingOnGvFondType()
        {
            if (!IsExternerFonds)
            {
                qryAbklaerendeStelle.Fill(GvGesuchId);
            }
        }

        private void SetupDataMembers()
        {
            edtBeantragendeStelle.DataMember = DBO.GvAbklaerendeStelle.BeantragendeStelle;
            edtKontaktperson.DataMember = DBO.GvAbklaerendeStelle.Kontaktperson;
            edtStrasse.DataMember = DBO.GvAbklaerendeStelle.Strasse;
            edtNr.DataMember = DBO.GvAbklaerendeStelle.HausNr;
            edtZusatz.DataMember = DBO.GvAbklaerendeStelle.Zusatz;
            edtPLZWohnsitz.DataMemberPLZ = DBO.GvAbklaerendeStelle.PLZ;
            edtPLZWohnsitz.DataMemberOrt = DBO.GvAbklaerendeStelle.Ort;
            edtPLZWohnsitz.DataMemberKanton = DBO.GvAbklaerendeStelle.Kanton;
            edtPostfach.DataMember = DBO.GvAbklaerendeStelle.Postfach;
            chkPostfachOhneNr.DataMember = DBO.GvAbklaerendeStelle.PostfachOhneNr;
            edtRegionAmtsbezirk.DataMember = DBO.GvAbklaerendeStelle.Region;
            edtTelefon.DataMember = DBO.GvAbklaerendeStelle.Telefon;
            edtEMail.DataMember = DBO.GvAbklaerendeStelle.Email;
            editBemerkungRTF.DataMember = DBO.GvAbklaerendeStelle.Bemerkungen;
            edtZahlungsinstruktionen.DataMember = DBO.GvAbklaerendeStelle.Zahlungsinstruktion;
            edtKreditor.DataMember = DBO.vwKreditor.Kreditor;
            edtInfoKreditor.DataMember = DBO.vwKreditor.ZusatzInfo;
            edtRefNr.DataMember = DBO.vwKreditor.ReferenzNummer;
        }

        /// <summary>
        /// Sucht für das Feld SAR alle Benutzer einer Kostenstelle
        /// und stellt dieses zur Auswahl.
        /// </summary>
        /// <param name="kostenstelle">Nummer der kostenstelle (int) oder DbNull</param>
        private void SetupLookupEditForSAR(object kostenstelle)
        {
            var qryUsers =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION
                    SELECT [Code] = USR.UserID,
                           [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', '')
                    FROM dbo.XUser                 USR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                             AND OUU.OrgUnitMemberCode = 2
                      INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE ORG.Kostenstelle = {0}
                      AND {0} IS NOT NULL
                    ORDER BY [Text], [Code];",
                    kostenstelle);
            edtSARName.LoadQuery(qryUsers);
        }

        /// <summary>
        /// Sucht für das Feld Kostenstelle alle Kostenstelle eines Geschäftsbereichs (Mandanten)
        /// und stellt diese zur Auswahl.
        /// </summary>
        /// <param name="mandantenNr">Die Mandantennummer, auch als Geschäftsbereich bekannt</param>
        private void SetupLookupEditsForKostenstelle(object mandantenNr)
        {
            // all kostenstellen within mandantennummer
            SqlQuery qryKostenstellen =
                DBUtil.OpenSQL(
                    @"
                    SELECT [Code] = NULL,
                            [Text] = ''
                    UNION
                    SELECT [Code] = ISNULL(ORG.Kostenstelle, -1),
                            [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Kostenstelle, -1)) + '   ' + ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ISNULL({0}, -1) < 0 OR ORG.OrgUnitID IN (SELECT OrgUnitID
                                                                   FROM dbo.fnGetMandantOrgUnits({0}))
                    ORDER BY [Text], [Code];",
                    mandantenNr);

            // setup edtSucheKostenstelle
            edtKostenstelle.Properties.DataSource = null;
            edtKostenstelle.Properties.DropDownRows = Math.Min(qryKostenstellen.Count, 14);
            edtKostenstelle.Properties.DataSource = qryKostenstellen;
            edtKostenstelle.EditValue = null;

            SetupLookupEditForSAR(edtKostenstelle.EditValue);
        }

        #endregion

        #endregion
    }
}