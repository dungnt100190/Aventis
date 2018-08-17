using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryBaInstitutionKontaktpersonen : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private bool _isAfterRunSearch = false;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBaInstitutionKontaktpersonen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnGotoInsitution_Click(object sender, EventArgs e)
        {
            // validate
            if (qryQuery.IsEmpty)
            {
                return;
            }

            // open Institutionenstamm and select current institution
            FormController.OpenForm("FrmInstitutionenStamm",
                                    "Action", "ShowInstitution",
                                    "BaInstitutionID", qryQuery["ID"]);
        }

        private void chkSucheAuchKontakte_CheckedChanged(object sender, EventArgs e)
        {
            kissSearch.SelectStatement = GetSearchQuery(chkSucheAuchKontakte.Checked);
        }

        private void CtlQueryBaInstitutionKontaktpersonen_Load(object sender, EventArgs e)
        {
            grvQuery1.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(grvQuery1_CustomDrawColumnHeader);
            grvQuery1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(grvQuery1_CustomDrawCell);

            SetupTypenPickList();
            SetupOrgUnitLookupEdit();

            kissSearch.SelectParameters = new object[] { Session.User.UserID, Session.User.LanguageCode };
            kissSearch.SelectStatement = GetSearchQuery(chkSucheAuchKontakte.Checked);

            qryZahlungsweg.SelectStatement = GetSearchStringZahlungsverbindung();
        }

        private void grvQuery1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            PerformFocusHandlingHack();
        }

        private void grvQuery1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e == null || e.Column == null || string.IsNullOrEmpty(e.Column.Caption))
            {
                return;
            }

            if (e.Column.Caption.Substring(e.Column.Caption.Length - 2) == "KP")
            {
                Rectangle rect = e.Bounds;
                rect.Inflate(-1, -1);
                Brush brush = e.Cache.GetGradientBrush(rect, Color.LightYellow, Color.Gold, System.Drawing.Drawing2D.LinearGradientMode.Vertical);

                // Fill column headers with the specified colors.
                e.Graphics.FillRectangle(brush, rect);
                ControlPaint.DrawBorder3D(e.Graphics, e.Bounds, Border3DStyle.RaisedInner);
                e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect);

                // Draw the filter and sort buttons.
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Handled = true;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            if (tabControlSearch.IsTabSelected(tpgSuchen))
            {
                return;
            }

            if (tabControlSearch.IsTabSelected(tpgListe))
            {
                qryQuery.Refresh();
            }

            if (tabControlSearch.IsTabSelected(tpgZahlungsweg))
            {
                qryZahlungsweg.Refresh();
            }
        }

        public override void Translate()
        {
            base.Translate();

            SetupOrgUnitSearchLabel();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtNameX.Focus();
        }

        protected override void RunSearch()
        {
            // remove all visible columns first
            grvQuery1.Columns.Clear();
            qryQuery.DataTable.Columns.Clear();

            base.RunSearch();

            // set flag used by hack in SelectedTabChanged event
            _isAfterRunSearch = true;
        }

        #endregion

        #region Private Methods

        private string GetSearchQuery(bool mitKontaktpersonen)
        {
            StringBuilder selectStatement = new StringBuilder();
            string searchQueryTop = string.Empty;
            string searchQueryKontakt = string.Empty;
            string searchQueryBottom = string.Empty;

            SetupOrgUnitSearchLabel();
            string orgUnitColName = lblSucheOrgEinheit.Text.Replace("]", "");   // remove possible "]" to prevent error

            searchQueryTop = @"
                --SQLCHECK_IGNORE--
                DECLARE @IdList VARCHAR(255);
                DECLARE @IsAND BIT;
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;
                DECLARE @AuchKontakte BIT;

                SET @UserID = {0};
                SET @LanguageCode = {1};

                --- SET @IdList = {pklSucheInstTypen.SelectedIds};
                --- SET @IsAND = {chkSucheInstitutionenMitAllenTypen.Checked};
                --- SET @AuchKontakte = {chkSucheAuchKontakte.Checked};

                SELECT
                  [ID]                 = INS.[BaInstitutionID],
                  [Inst./Fachperson]   = dbo.fnLOVMLText('BaInstitutionArt', INS.[BaInstitutionArtCode], @LanguageCode),
                  [Titel]              = INS.[Titel],
                  [Institution/Name]   = INS.[Name],
                  [Vorname]            = INS.[Vorname],
                  [Geschlecht]         = dbo.fnLOVMLText('Geschlecht', INS.GeschlechtCode, @LanguageCode),
                  [Zusatz]             = ADR.[Zusatz],";

            searchQueryKontakt = @"
                  [Titel KP]           = KTP.[Titel],
                  [Name KP]            = KTP.[Name],
                  [Vorname KP]         = KTP.[Vorname],
                  [Geschlecht KP]      = dbo.fnLOVMLText('Geschlecht', KTP.GeschlechtCode, @LanguageCode),
                  [Telefon KP]         = KTP.[Telefon],
                  [Fax KP]             = KTP.[Fax],
                  [E-Mail KP]          = KTP.[EMail],
                  [Bemerkungen KP]     = KTP.[Bemerkung],
                  [Manuelle Anrede KP] = ISNULL(KTP.[ManuelleAnrede], 0),
                  [Anrede KP]          = dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(KTP.BaInstitutionKontaktID, NULL, @LanguageCode, 'herrfrau', ''),
                  [Briefanrede KP]     = dbo.fnBaGetAnredeAnschriftBaInstitutionKontakt(KTP.BaInstitutionKontaktID, NULL, @LanguageCode, 'geehrte', ''),";

            searchQueryBottom = @"
                  [Strasse]            = ADR.[Strasse],
                  [Nr.]                = ADR.[HausNr],
                  [Postfach]           = dbo.fnBaGetPostfachText(NULL, ADR.[Postfach], ISNULL(ADR.[PostfachOhneNr], 0), @LanguageCode),
                  [Postfach ohne Nr.]  = ISNULL(ADR.[PostfachOhneNr], 0),
                  [PLZ]                = ADR.[PLZ],
                  [Ort]                = ADR.[Ort],
                  [Kt]                 = ADR.[Kanton],
                  [Bezirk]             = ADR.[Bezirk],
                  [Land]               = dbo.fnLandMLText(ADR.BaLandID, @LanguageCode),
                  [Tel 1]              = INS.[Telefon],
                  [Tel 2]              = INS.[Telefon2],
                  [Tel 3]              = INS.[Telefon3],
                  [Fax]                = INS.[Fax],
                  [E-Mail]             = INS.[EMail],
                  [Homepage]           = INS.[Homepage],
                  [Sprache]            = dbo.fnLOVMLText('Sprache', INS.SprachCode, @LanguageCode),
                  [nicht berücksichtigen für Serienbriefe] = INS.[KeinSerienbrief],
                  [aktiv]              = INS.[Aktiv],
                  [Bemerkungen]        = INS.[Bemerkung],
                  [Manuelle Anrede]    = INS.[ManuelleAnrede],
                  [Anrede]             = dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, NULL, @LanguageCode, 'herrfrau', ''),
                  [Briefanrede]        = dbo.fnBaGetAnredeAnschriftBaInstitution(INS.BaInstitutionID, NULL, @LanguageCode, 'geehrte', ''),
                  [Typisierung]        = dbo.fnBaGetBaInstitutionTypen(INS.[BaInstitutionID], 0, '; ', @UserID, @LanguageCode),
                  [" + orgUnitColName + @"] = ORG.ItemName
                FROM dbo.fnGetBaInstitutionByBaInstitutionTypList(@IdList, @IsAND) INS
                  LEFT JOIN dbo.BaAdresse            ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
                  LEFT JOIN dbo.BaInstitutionKontakt KTP WITH (READUNCOMMITTED) ON KTP.BaInstitutionID = INS.BaInstitutionID
                                                                               AND @AuchKontakte = CONVERT(BIT, 1)
                                                                               AND (KTP.Aktiv = {chkSucheNurAktive.Checked} OR KTP.Aktiv = CONVERT(BIT,1))
                  LEFT JOIN dbo.XOrgUnit             ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = INS.OrgUnitID

                WHERE 1 = 1
                  AND (INS.OrgUnitID IS NULL OR INS.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                  FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only institutions the user is allowed to see
                --- AND INS.BaInstitutionID = {edtSucheBaInstitutionId}
                --- AND REPLACE(INS.InstitutionNr, ' ', '') LIKE dbo.fnReplaceWildcard({edtInstitutionNrX})
                --- AND INS.OrgUnitID = {edtSucheOrgEinheit}
                --- AND ((INS.Name LIKE '%' + dbo.fnReplaceWildcard({edtNameX})) OR ((KTP.Name LIKE '%' + dbo.fnReplaceWildcard({edtNameX})) AND (@AuchKontakte = CONVERT(BIT, 1))))
                --- AND INS.EMail LIKE dbo.fnReplaceWildcard({edtEMailX})
                --- AND INS.Telefon LIKE dbo.fnReplaceWildcard({edtTelefonX})
                --- AND INS.InstitutionTypCode = {edtOrganisationTypX}
                --- AND ADR.PLZ LIKE dbo.fnReplaceWildcard({edtPLZX})
                --- AND ADR.Ort LIKE dbo.fnReplaceWildcard({edtOrtX})
                --- AND ((INS.Bemerkung LIKE '%' + dbo.fnReplaceWildcard({edtSucheBemerkung})) OR ((KTP.Bemerkung LIKE '%' + dbo.fnReplaceWildcard({edtSucheBemerkung})) AND (@AuchKontakte = CONVERT(BIT, 1))))
                --- AND (INS.Aktiv = {chkSucheNurAktive.Checked} OR INS.Aktiv = CONVERT(BIT,1) OR EXISTS(SELECT TOP 1 1 FROM dbo.BaInstitutionKontakt WITH (READUNCOMMITTED) WHERE BaInstitutionID = INS.BaInstitutionID AND Aktiv = CONVERT(BIT,1)))
                --- AND (INS.KeinSerienbrief <> {chkSucheSerienbrief} OR {chkSucheSerienbrief} = 0)
                ORDER BY INS.[Name], ADR.[PLZ];";

            selectStatement.Append(searchQueryTop);

            if (chkSucheAuchKontakte.Checked)
            {
                selectStatement.Append(searchQueryKontakt);
            }

            selectStatement.Append(searchQueryBottom);

            return selectStatement.ToString();
        }

        private string GetSearchStringZahlungsverbindung()
        {
            string searchQuery = @"
                --SQLCHECK_IGNORE--
                DECLARE @IdList VARCHAR(255)
                DECLARE @IsAND BIT;
                DECLARE @LanguageCode INT;
                DECLARE @AuchKontakte BIT;
                DECLARE @UserID INT;

                SET @LanguageCode = " + Session.User.LanguageCode + @";
                SET @UserID = " + Session.User.UserID + @";
                --- SET @IdList = {pklSucheInstTypen.SelectedIds};
                --- SET @IsAND = {chkSucheInstitutionenMitAllenTypen.Checked};
                --- SET @AuchKontakte = {chkSucheAuchKontakte.Checked};

                --SQLCHECK_IGNORE--
                SELECT
                  [ID]                = INS.[BaInstitutionID],
                  [Inst./Fachperson]  = INS.[BaInstitutionArtCode],
                  [Titel]             = INS.[Titel],
                  [Institution/Name]  = INS.[Name],
                  [Vorname]           = INS.[Vorname],
                  --
                  [Zusatz]            = ADR.[Zusatz],
                  [Strasse]           = ADR.[Strasse],
                  [Nr.]               = ADR.[HausNr],
                  [Postfach]          = ADR.[Postfach],
                  [Postfach ohne Nr.] = ISNULL(ADR.[PostfachOhneNr], 0),
                  [PLZ]               = ADR.[PLZ],
                  [Ort]               = ADR.[Ort],
                  --
                  [Gültig von]        = BZW.[DatumVon],
                  [Gültig bis]        = BZW.[DatumBis],
                  [Zahlwegtyp]        = dbo.fnLOVMLText('BgEinzahlungsschein', BZW.[EinzahlungsscheinCode], @LanguageCode),
                  [Bank]              = BNK.[Name],
                  [Bankkonto-Nr]      = BZW.[BankKontoNummer],
                  [IBAN]              = BZW.[IBANNummer],
                  [Postkonto-Nr]      = BZW.[PostKontoNummer],
                  [Referenz-Nr]       = BZW.[ReferenzNummer],
                  [Zahlweg Name]      = BZW.[AdresseName],
                  [Zahlweg Zusatz]    = BZW.[AdresseName2],
                  [Zahlweg Strasse]   = BZW.[AdresseStrasse],
                  [Zahlweg Nr]        = BZW.[AdresseHausNr],
                  [Zahlweg PLZ]       = BZW.[AdressePLZ],
                  [Zahlweg Ort]       = BZW.[AdresseOrt]
                FROM dbo.fnGetBaInstitutionByBaInstitutionTypList(@IdList, @IsAND) INS
                  INNER JOIN dbo.BaZahlungsweg        BZW WITH (READUNCOMMITTED) ON BZW.BaInstitutionID = INS.BaInstitutionID
                  LEFT  JOIN dbo.BaBank               BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = BZW.BaBankID
                  LEFT  JOIN dbo.BaAdresse            ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INS.BaInstitutionID, NULL, NULL)
                  LEFT  JOIN dbo.BaInstitutionKontakt KTP WITH (READUNCOMMITTED) ON KTP.BaInstitutionID = INS.BaInstitutionID AND @AuchKontakte = CONVERT(BIT, 1)

                WHERE 1 = 1
                  AND (INS.OrgUnitID IS NULL OR INS.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                  FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only institutions the user is allowed to see
                --- AND INS.BaInstitutionID = {edtSucheBaInstitutionId}
                --- AND REPLACE(INS.InstitutionNr, ' ', '') LIKE dbo.fnReplaceWildcard({edtInstitutionNrX})
                --- AND INS.OrgUnitID = {edtSucheOrgEinheit}
                --- AND ((INS.Name LIKE dbo.fnReplaceWildcard({edtNameX}) + '%') OR ((KTP.Name LIKE dbo.fnReplaceWildcard({edtNameX}) + '%') AND (@AuchKontakte = CONVERT(BIT, 1))))
                --- AND INS.EMail LIKE dbo.fnReplaceWildcard({edtEMailX}) + '%'
                --- AND INS.Telefon LIKE dbo.fnReplaceWildcard({edtTelefonX})
                --- AND INS.InstitutionTypCode = {edtOrganisationTypX}
                --- AND ADR.PLZ LIKE dbo.fnReplaceWildcard({edtPLZX}) + '%'
                --- AND ADR.Ort LIKE dbo.fnReplaceWildcard({edtOrtX}) + '%'
                --- AND INS.Bemerkung LIKE dbo.fnReplaceWildcard({edtSucheBemerkung})
                --- AND (INS.Aktiv = {chkSucheNurAktive.Checked} OR INS.Aktiv = CONVERT(BIT,1))
                --- AND (INS.KeinSerienbrief <> {chkSucheSerienbrief} OR {chkSucheSerienbrief} = 0)
                ORDER BY INS.Name;";

            return searchQuery;
        }

        private void PerformFocusHandlingHack()
        {
            if (_isAfterRunSearch)
            {
                // reset flag to prevent multiple executions after searched data up to next new search
                _isAfterRunSearch = false;

                try
                {
                    // HACK: To prevent having focusing first cell problem and keypress error in devexpress
                    if (!qryQuery.IsEmpty)
                    {
                        grvQuery1.Focus();
                        grvQuery1.FocusedColumn = grvQuery1.Columns[grvQuery1.Columns.Count - 1];
                        grvQuery1.SelectRow(grvQuery1.GetRowHandle(0));
                        grvQuery1.FocusedColumn = grvQuery1.Columns[0];
                        grvQuery1.MakeColumnVisible(grvQuery1.Columns[0]);
                    }
                }
                catch (Exception ex)
                {
                    // log error only
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message, "Error in focus-handling hack.");

                    // break if debugging to remind of the error
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
        }

        private void SetupOrgUnitLookupEdit()
        {
            SqlQuery qryOrgUnit = DBUtil.OpenSQL(@"
                SELECT [Code] = NULL,
                       [Text] = ''

                UNION

                SELECT [Code] = OrgUnitID,
                       [Text] = ItemName
                FROM dbo.fnGetInstStammUserORGList({0});", Session.User.UserID);

            edtSucheOrgEinheit.LoadQuery(qryOrgUnit);
        }

        private void SetupOrgUnitSearchLabel()
        {
            string orgEinheitName = Utils.GetOrgUnitTypNameForInstitutionsTypen();
            lblSucheOrgEinheit.Text = string.IsNullOrEmpty(orgEinheitName) ? lblSucheOrgEinheit.Text : orgEinheitName;
        }

        private void SetupQuerySucheTypenZugeteilt()
        {
            DataTable selectedTypesTable = qrySucheTypenZugeteilt.DataSet.Tables[0];
            selectedTypesTable.Columns.Add(DBO.BaInstitutionTyp.BaInstitutionTypID, typeof(int));
            selectedTypesTable.Columns.Add(DBO.BaInstitutionTyp.Name, typeof(string));
        }

        private void SetupTypenPickList()
        {
            qrySucheTypenVerfuegbar.SelectStatement = @"
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;

                SET @UserID = {0};
                SET @LanguageCode = {1};

                SELECT BaInstitutionTypID = ITY.BaInstitutionTypID,
                       [Name]             = ISNULL(dbo.fnGetMLText(ITY.NameTID, @LanguageCode), ITY.[Name])
                FROM dbo.BaInstitutionTyp ITY
                WHERE ITY.Aktiv = 1
                  AND (ITY.OrgUnitID IS NULL OR ITY.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                  FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only types the user is allowed to see
                ORDER BY [Name];";

            qrySucheTypenVerfuegbar.Fill(Session.User.UserID, Session.User.LanguageCode);

            SetupQuerySucheTypenZugeteilt();

            pklSucheInstTypen.DataSourceOfSourceGrid = qrySucheTypenVerfuegbar;
            pklSucheInstTypen.DataSourceOfTargetGrid = qrySucheTypenZugeteilt;
            pklSucheInstTypen.ColumnsByFieldNameAndCaptionForSourceGrid = new Dictionary<string, string> { { DBO.BaInstitutionTyp.Name, KissMsg.GetMLMessage(this.Name, "InstTypenAuswahlHeader", "Typen-Auswahl") } };
            pklSucheInstTypen.ColumnsByFieldNameAndCaptionForTargetGrid = new Dictionary<string, string> { { DBO.BaInstitutionTyp.Name, KissMsg.GetMLMessage(this.Name, "InstTypenZugeteiltHeader", "Ausgewählte Typen") } };
        }

        #endregion

        #endregion
    }
}