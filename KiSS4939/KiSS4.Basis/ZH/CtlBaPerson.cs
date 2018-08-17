using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.FAMOZ.PSCDServices;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Basis.ZH
{
    public partial class CtlBaPerson : KissUserControl
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string CLASSNAME = "CtlBaPerson";

        #endregion

        #region Private Fields

        private int _baPersonId;
        private int _ftPersonId;
        private bool _hasSpecialRightsAnonym;
        private bool _isIkAuszugInitializing;

        #endregion

        #endregion

        #region Constructors

        public CtlBaPerson()
        {
            InitializeComponent();

            // alle Berufe anzeigen: BaBeruf
            edtErlernterBeruf.LookupSQL = @"
                SELECT ID$ = BaBerufID, Text$ = Beruf, Beruf
                FROM dbo.BaBeruf
                WHERE (Beruf LIKE {0} + '%') OR ({0} IS NULL)
                ORDER BY 1
                ----
                SELECT Beruf
                FROM dbo.BaBeruf
                WHERE BaBerufID = {0}";

            edtJetzigeTaetigkeit.LookupSQL = edtErlernterBeruf.LookupSQL;

            tabStammdaten.SelectedTabChanging += tabStammdaten_SelectedTabChanging;
            tabStammdaten.SelectedTabChanged += tabStammdaten_SelectedTabChanged;

            edtWegzugPLZ.UserModifiedFld += edtWegzug_UserModifiedFld;
            edtWegzugOrt.UserModifiedFld += edtWegzug_UserModifiedFld;

            btnKIS.URL = DBUtil.GetConfigString(@"System\Schnittstellen\KIS\URL", null);

            //Spezialrechte
            btnOmegaImport.Enabled = DBUtil.UserHasRight("CtlBaPerson_AlphaImport");
            btnSendToPscd.Visible = DBUtil.UserHasRight("CtlBaPerson_PscdSenden");
            btnKIS.Enabled = DBUtil.UserHasRight("CtlBaPerson_KIS");
        }

        #endregion

        #region Properties

        public override KissUserControl DetailControl
        {
            get
            {
                if (tabStammdaten.SelectedTab == tbpAdressen)
                {
                    return ctlAdressen;
                }

                if (tabStammdaten.SelectedTab == tbpVersicherungen)
                {
                    return ctlKrankenversicherung;
                }

                if (tabStammdaten.SelectedTab == tbpArbeit)
                {
                    return ctlArbeit;
                }

                if (tabStammdaten.SelectedTab == tbpErsatzeinkommen)
                {
                    return ctlBaPersonErsatzeinkommen;
                }

                if (tabStammdaten.SelectedTab == tbpVermoegen)
                {
                    return ctlBaPersonVermoegen;
                }

                if (tabStammdaten.SelectedTab == tbpZahlweg)
                {
                    return ctlZahlungsweg;
                }

                if (tabStammdaten.SelectedTab == tbpWVCode)
                {
                    return ctlWVCode;
                }

                if (tabStammdaten.SelectedTab == tbpAlteFallNr)
                {
                    return ctlAlteFallNr;
                }

                return base.DetailControl;
            }
        }

        #endregion

        #region EventHandlers

        private void btnAnonymisieren_Click(object sender, EventArgs e)
        {
            // Checks machen:
            SqlQuery qryCheck = DBUtil.OpenSQL("EXEC dbo.spBaPersonAnonymisieren_Checks {0}", _baPersonId);
            string errorText = Utils.ConvertToString(qryCheck["Error"]);
            if (errorText != "")
            {
                KissMsg.ShowInfo(errorText + "\r\n" + "Deshalb kann die Person nicht anonymisiert werden.");
                return;
            }

            if (KissMsg.ShowQuestion(
                String.Format(
                    "Soll {0} {1} anonymisiert werden ?\r\n\r\n" +
                    "Anonymisieren:\r\n" +
                    "Alle Personalien/Stammdaten einer Person werden gelöscht bis auf das Geschlecht und das Geburtsdatum.\r\n" +
                    "Name und Vorname werden mit einem anonymen Wert überschrieben.",
                    edtVorname.Text,
                    edtName.Text)))
            {
                try
                {
                    DBUtil.ExecSQLThrowingException("exec dbo.spBaPersonAnonymisieren {0}", _baPersonId);
                    OpenData(_baPersonId);
                    FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                    ApplicationFacade.DoEvents();
                    KissMsg.ShowInfo("Die Person wurde anonymisiert.");
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError(CLASSNAME, "ErrorAnonymisierung", "Bei der Anonymisierung ist ein Fehler aufgetreten.", ex.Message);
                }
            }
        }

        private void btnHeimatorte_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryBaPerson["HeimatGemeindeCodes"]))
            {
                KissMsg.ShowInfo("Es existieren keine älteren Heimatorte.");
                return;
            }

            var dlg = new KissLookupDialog();
            string strCodes = qryBaPerson["HeimatGemeindeCodes"].ToString();
            // 15.08.2007 : sozheo : PLZs sollen nicht angezeigt werden:
            string strSQL = @"
                SELECT ID$ = BaGemeindeID, GemeindeKanton$ = Name + ISNULL(' '+Kanton, ''), Ort = Name, Kanton
                FROM dbo.BaGemeinde
                WHERE BaGemeindeID IN (" +
                strCodes + @")
                ORDER BY CASE WHEN BaGemeindeID = ISNULL({1}, -1) THEN 0 ELSE 1 END, Name";

            if (dlg.SearchData(strSQL, "%", true, qryBaPerson["HeimatGemeindeCode"]))
            {
                //edtHeimatort.LookupID = dlg[0];
                qryBaPerson["HeimatGemeindeCode"] = dlg[0];
                qryBaPerson["Heimatort"] = dlg[1];
            }
        }

        private void btnOmegaImport_Click(object sender, EventArgs e)
        {
            string einwohnerregisterId;
            var neueEinwohnerregisterId = false;
            if (DBUtil.IsEmpty(qryBaPerson["EinwohnerregisterID"]))
            {
                neueEinwohnerregisterId = true;
                var input = DlgInputBox.GetInput("Omega", "Geben Sie bitte die PID der Person ein.", "");

                if (string.IsNullOrEmpty(input))
                {
                    return;
                }

                einwohnerregisterId = input;
            }
            else
            {
                if (!KissMsg.ShowQuestion(CLASSNAME, "FrageImportEinwohnerregister", "Daten importieren?"))
                {
                    return;
                }

                einwohnerregisterId = qryBaPerson["EinwohnerregisterID"] as string;
            }

            try
            {
                var baPersonId = Utils.ConvertToInt(qryBaPerson[DBO.BaPerson.BaPersonID]);
                BaPerson baPerson;
                BaEinwohnerregisterPersonAnfrageDTO personDto;

                var einwohnerregisterService = Kiss.Infrastructure.IoC.Container.Resolve<BaEinwohnerregisterService>();
                var result = einwohnerregisterService.ValidateAndGetImportPerson(
                    einwohnerregisterId,
                    neueEinwohnerregisterId,
                    baPersonId,
                    out baPerson,
                    out personDto);

                if (result.IsQuestion)
                {
                    if (!KissMsg.ShowResult(result))
                    {
                        return;
                    }

                    result = ServiceResult.Ok();
                }

                if (baPerson != null && personDto != null)
                {
                    IDictionary<string, string> changes;
                    result.Add(einwohnerregisterService.ImportPerson(baPerson, personDto, out changes));
                }

                if (result.IsOk)
                {
                    qryBaPerson.Refresh();
                    ctlAdressen.RefreshQueries();
                    ctlKrankenversicherung.RefreshQueries();
                }
                else
                {
                    KissMsg.ShowResult(result);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnSendToPscd_Click(object sender, EventArgs e)
        {
            try
            {
                PSCDInterface.CreateAndSubmitBusinessPartnerPersonData(_baPersonId);
                KissMsg.ShowInfo("Person erfolgreich an PSCD gesendet");
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void cboNationalitaet_CloseUp(object sender, CloseUpEventArgs e)
        {
            // Wenn eine andere Nationalität gewählt wurde als

            /*
                         Specifies that the dropdown window was closed because an end user:
            ButtonClick  clicked the editor's dropdown button.
            Cancel       pressed the ESC key or clicked the close button
                         (available for LookUpEdit, CalcEdit and PopupContainerEdit controls).
            CloseUpKey   pressed a shortcut used to close the dropdown (the ALT+DOWN ARROW or RepositoryItemPopupBase.CloseUpKey).
            Immediate    clicked outside the editor.
            Normal       selected an option from the editor's dropdown.
            */

            e.AcceptValue = true;
            if (!e.CloseMode.Equals(PopupCloseMode.Normal))
            {
                return;
            }

            if (DBUtil.IsEmpty(e.Value))
            {
                return;
            }

            // Neue Auswahl kontrollieren:
            var newValue = (int)e.Value;
            if (!Utils.isSchweiz(newValue))
            {
                // wenn es nicht die CH ist, dann soll der Heimatort gelöscht werden
                qryBaPerson["HeimatGemeindeCode"] = DBNull.Value;
            }

            // damit das Editieren korrekt gesetzt wird, setzen wir den Wert sofort:
            qryBaPerson["NationalitaetCode"] = newValue;
            SetEditMode_Heimatorte();
        }

        private void chkIKAuszug_CheckedChanged(object sender, EventArgs e)
        {
            if (!_isIkAuszugInitializing)
            {
                qryBaPerson.RowModified = true;
            }

            if (DBUtil.IsEmpty(qryBaPerson["IKAuszugComboboxJahr"]) || (bool)qryBaPerson["IKAuszugComboboxEnabled"])
            {
                // Entweder gabs bisher noch kein IKAuszugs-Anforderung, oder die Combobox ist von der Business Logik her enabled
                edtIKAuszugJahr.EditMode = edtIKAuszug.Checked ? EditModeType.Normal : EditModeType.ReadOnly;
                // Nur wenn die Checkbox checked ist, kann aus der Combobox ausgewählt werden
            }
            else
            {
                edtIKAuszugJahr.EditMode = EditModeType.ReadOnly;
            }
        }

        private void cmbIKAuszugJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isIkAuszugInitializing)
            {
                qryBaPerson.RowModified = true;
            }
        }

        private void CtlBaPerson_Load(object sender, EventArgs e)
        {
            if (DBUtil.UserHasRight("CtlBaPerson_KIS"))
            {
                btnKIS.Enabled = true;
            }

            edtZuzugGdeOrtCode.GetDatum = GetDatumZuzugGdeOrt;
            edtZuzugKtOrtCode.GetDatum = GetDatumZuzugKtOrt;
        }

        private void editInCHSeitGeburt_EditValueChanged(object sender, EventArgs e)
        {
            // Editierfelder einstellen:
            SetEditMode_IstInCHSeit();
        }

        private void edtHeimatort_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = Utils.ConvertToString(edtHeimatort.EditValue).Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBaPerson["HeimatGemeindeCode"] = DBNull.Value;
                    qryBaPerson["Heimatort"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$        = G.BaGemeindeID,
                       [PLZ]      = G.PLZ,
                       [Gemeinde] = G.Name,
                       [Kt.]      = G.Kanton,
                       Anzeige$   = G.Name + ISNULL(' ' + G.Kanton, '')
                FROM dbo.BaGemeinde G
                WHERE G.Name + ISNULL(' ' + G.Kanton, '') LIKE {0} + '%'
                ORDER BY G.Name",
                searchString,
                e.ButtonClicked,
                null,
                null,
                null);

            if (!e.Cancel)
            {
                qryBaPerson["HeimatGemeindeCode"] = dlg[0];
                qryBaPerson["Heimatort"] = dlg[4];
            }
        }

        private void edtWegzug_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var edit = (BaseEdit)sender;
            var qry = ((IKissBindableEdit)sender).DataSource;

            if (!Utils.isSchweiz(qry["WegzugLandCode"]))
            {
                qry[((IKissBindableEdit)sender).DataMember] = edit.Text;
                return;
            }

            if (DBUtil.IsEmpty(edit.Text))
            {
                qry["WegzugPLZ"] = DBNull.Value;
                qry["WegzugOrt"] = DBNull.Value;
                qry["WegzugKanton"] = DBNull.Value;
                qry["WegzugOrtCode"] = DBNull.Value;
                qry.RefreshDisplay();
                return;
            }

            var dlg = new DlgAuswahl();

            if (edit.Name.IndexOf("PLZ") != -1)
            {
                e.Cancel = !dlg.PLZSearch(edit.Text);
            }
            else
            {
                e.Cancel = !dlg.OrtSearch(edit.Text);
            }

            if (!e.Cancel)
            {
                qry["WegzugPLZ"] = dlg["Value1"];
                qry["WegzugOrt"] = dlg["Text"];
                qry["WegzugKanton"] = dlg["Value2"];
                qry["WegzugOrtCode"] = dlg["Code"];

                qry["WegzugLandCode"] = Session.BaLandCodeSchweiz;
                qry.RefreshDisplay();
            }
        }

        private void qryBaPerson_AfterPost(object sender, EventArgs e)
        {
            // Navigator Trees aktualisieren:
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");

            edtHeimtortLand.Text = GetHeimatortLand();

            var containingForm = FindForm();
            if (containingForm != null)
            {
                containingForm.Focus();
            }

            // Titel anzeigen:
            SetTitle();

            // andere Fenster / Controls aktualisieren:
            ctlAdressen.SetNames(qryBaPerson["Vorname"].ToString(), qryBaPerson["Name"].ToString());
            ctlAdressen.SetZipNumber(Utils.ConvertToInt(qryBaPerson["ZIPNr"]), qryBaPerson["EinwohnerregisterAktiv"] as bool?);

            // IK-Auszug
            if (edtIKAuszug.Checked && !(bool)qryBaPerson["IKAuszugCheckboxChecked"])
            {
                // Auszug wurde neu angefordert => Erstelle Eintrag
                DBUtil.ExecSQLThrowingException(
                    string.Format(
                        "EXEC dbo.spSstIKAuszugGeneriereManuelleAnforderung {0}, {1}, {2}", _baPersonId, int.Parse(edtIKAuszugJahr.SelectedItem.ToString()), Session.User.UserID));
            }
            else if (!edtIKAuszug.Checked && (bool)qryBaPerson["IKAuszugCheckboxChecked"])
            {
                // Angeforderter Auszug wurde neu wieder abgewühlt => Lösche Eintrag
                if ((int)qryBaPerson["SstIkAuszugAnforderungCode"] == 4)
                {
                    // Manuelle Anforderungen werden gelöscht
                    DBUtil.ExecSQLThrowingException(string.Format("DELETE FROM SstIKAuszug WHERE SstIKAuszugID = {0}", qryBaPerson["IKAuszugID"]));
                }
                else
                {
                    // Automatische Anforderungen werden nicht gelöscht, sondern deaktiviert
                    DBUtil.ExecSQLThrowingException(string.Format("UPDATE SstIKAuszug SET Deaktiviert = 1 WHERE SstIKAuszugID = {0}", qryBaPerson["IKAuszugID"]));
                }
            }
            else if (!DBUtil.IsEmpty(qryBaPerson["IKAuszugComboboxJahr"]) && edtIKAuszugJahr.SelectedItem.ToString() != (string)qryBaPerson["IKAuszugComboboxJahr"])
            {
                // Das Jahr wurde geändert => Speichere das geänderte Jahr ab
                DBUtil.ExecSQLThrowingException(
                    string.Format("UPDATE SstIKAuszug SET JahrVon = {1} WHERE SstIKAuszugID = {0}", qryBaPerson["IKAuszugID"], edtIKAuszugJahr.SelectedItem));
            }
        }

        private void qryBaPerson_BeforePost(object sender, EventArgs e)
        {
            edtZuzugKtOrtCode.DoValidate();
            edtZuzugGdeOrtCode.DoValidate();

            if (!DBUtil.IsEmpty(qryBaPerson["Name"]) && qryBaPerson.ColumnModified("Name"))
            {
                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT dbo.FaJournal (FaFallID, BaPersonID, UserID, Text, OrgUnitID)
                    SELECT TOP 1 FaFallID, {0}, {1}, {2}, {3}
                    FROM dbo.FaFall
                    WHERE BaPersonID = {0}
                    ORDER BY DatumBis, DatumVon DESC",
                    _baPersonId,
                    Session.User.UserID,
                    "Mutation Name",
                    Session.User["OrgUnitID"]);
            }

            if (!DBUtil.IsEmpty(qryBaPerson["ZivilstandCode"]) && qryBaPerson.ColumnModified("ZivilstandCode"))
            {
                //Eintrag ins Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT dbo.FaJournal (FaFallID, BaPersonID, UserID, Text, OrgUnitID)
                    SELECT TOP 1 FaFallID, {0}, {1}, {2}, {3}
                    FROM dbo.FaFall
                    WHERE BaPersonID = {0}
                    ORDER BY DatumBis, DatumVon DESC",
                    _baPersonId,
                    Session.User.UserID,
                    "Mutation Zivilstand",
                    Session.User["OrgUnitID"]);
            }

            // Der Name darf nicht leer sein:
            DBUtil.CheckNotNullField(edtName, "Name der Person");
            DBUtil.CheckNotNullField(edtVorname, "Vorname der Person");
            DBUtil.CheckNotNullField(edtGeschlecht, "Geschlecht");
            DBUtil.CheckNotNullField(edtGeburtstag, "Geburt");
            if (edtVersichertennummer.EditMode != EditModeType.ReadOnly && !edtVersichertennummer.ValidateVersNr(true, false))
            {
                // set focus
                edtVersichertennummer.Focus();

                // cancel, message already shown
                throw new KissCancelException();
            }

            if ((bool)qryBaPerson["InCHSeitGeburt"])
            {
                qryBaPerson["InCHSeit"] = DBNull.Value;
            }
        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            // Allgemein Felder einstellen:
            SetEditMode_Common();

            // Editierfelder "In CH seit" einstellen:
            SetEditMode_IstInCHSeit();

            // Editierfeld Heimatort einstellen:
            SetEditMode_Heimatorte();

            // KIS-Absprung
            var zipNr = qryBaPerson["ZIPNr"] as int?;
            if (zipNr.HasValue)
            {
                //TODO auf PID ändern?
                btnKIS.URL = string.Format("{0}?ZIP={1}", DBUtil.GetConfigString(@"System\Schnittstellen\KIS\URL", null), zipNr.Value);
            }

            if (DBUtil.UserHasRight("CtlBaPerson_KIS"))
            {
                btnKIS.Enabled = zipNr.HasValue;
            }

            // IK-Auszug
            try
            {
                _isIkAuszugInitializing = true;

                edtIKAuszug.Checked = (bool)qryBaPerson["IKAuszugCheckboxChecked"];

                int minAlter = DBUtil.GetConfigInt(@"System\IKAuszuege\MinimalAlter", 20);
                int maxAlter = DBUtil.GetConfigInt(@"System\IKAuszuege\MaximalAlter", 65);

                if (DBUtil.IsEmpty(qryBaPerson["IKAuszugErsterFinanzplanJahr"]) || DBUtil.IsEmpty(qryBaPerson["Alter"]) || (int)qryBaPerson["Alter"] < minAlter ||
                    (int)qryBaPerson["Alter"] >= maxAlter)
                {
                    // Ohne je Teil eines Finanzplans gewesen zu sein, oder wenn Person zu jung oder alt ist, dann kann diese Checkbox nicht gesetzt werden
                    edtIKAuszug.EditMode = EditModeType.ReadOnly;
                    edtIKAuszugJahr.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    int earliestYear = DBUtil.GetConfigInt("System\\IKAuszuege\\FruehestesAuszugsJahr", 1985);

                    edtIKAuszugJahr.Properties.Items.Clear();

                    if (!DBUtil.IsEmpty(qryBaPerson["IKAuszugErsterFinanzplanJahr"]))
                    {
                        int year;
                        if (int.TryParse((string)qryBaPerson["IKAuszugErsterFinanzplanJahr"], out year))
                        {
                            edtIKAuszugJahr.Properties.Items.Add((year - 2).ToString());
                        }
                    }

                    // Füge noch das erst-mögliche Jahr hinzu als weitere Option
                    edtIKAuszugJahr.Properties.Items.Add(earliestYear.ToString());

                    edtIKAuszug.EditMode = (bool)qryBaPerson["IKAuszugCheckboxEnabled"] ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtIKAuszugJahr.EditMode = (bool)qryBaPerson["IKAuszugComboboxEnabled"] ? EditModeType.Normal : EditModeType.ReadOnly;
                    if (!DBUtil.IsEmpty(qryBaPerson["IKAuszugComboboxJahr"]))
                    {
                        edtIKAuszugJahr.SelectedItem = qryBaPerson["IKAuszugComboboxJahr"];
                    }
                    else
                    {
                        edtIKAuszugJahr.SelectedIndex = 0;
                    }
                }
            }
            finally
            {
                _isIkAuszugInitializing = false;
            }
        }

        private void SetEditMode_Common()
        {
            var editMode = EditModeType.ReadOnly;

            // Allgemeine Felder einstellen:
            bool canEdit = (qryBaPerson.CanUpdate &&
                            qryBaPerson.Count > 0 &&
                            (DBUtil.IsEmpty(qryBaPerson["EinwohnerregisterID"]) ||
                             DBUtil.IsEmpty(qryBaPerson["EinwohnerregisterAktiv"]) ||
                             !Convert.ToBoolean(qryBaPerson["EinwohnerregisterAktiv"])));

            if (canEdit)
            {
                editMode = EditModeType.Normal;
            }

            // Felder bei EinwohnerregisterAktiv = false editierbar;
            edtName.EditMode = editMode;
            edtZivilstand.EditMode = editMode;
            edtZivilstandSeit.EditMode = editMode;
            cboAuslaenderStatus.EditMode = editMode;
            dtpAuslaenderStatusGueltigBis.EditMode = editMode;

            // Wenn eine ZIP-Nummer vorhanden ist, dann sollen folgende Felder nicht editiert werden können:
            if (canEdit && !DBUtil.IsEmpty(qryBaPerson["EinwohnerregisterID"]))
            {
                editMode = EditModeType.ReadOnly;
            }

            edtVorname.EditMode = editMode;
            edtAHVNr.EditMode = editMode;
            edtVersichertennummer.EditMode = editMode;
            edtGeburtstag.EditMode = editMode;
            edtGeschlecht.EditMode = editMode;
            edtNationalitaet.EditMode = editMode;
            edtZemisNummer.EditMode = editMode;
            edtKantRefNummer.EditMode = editMode;
            edtZarNummer.EditMode = editMode;
            btnOmegaImport.Enabled = canEdit || (qryBaPerson.CanUpdate && qryBaPerson.Count > 0 && DBUtil.UserHasRight("CtlBaPerson_AlphaImport"));

            // Wegzug in Stadt ZH
            edtWegzugPLZ.EditMode = editMode;
            edtWegzugOrt.EditMode = editMode;
            edtWegzugLand.EditMode = editMode;
            edtWegzugDatum.EditMode = editMode;

            // Zuzug in Stadt ZH
            edtZuzugGdeOrtCode.EditMode = editMode;
            datZuzugSeit.EditMode = editMode;

            // Anonymisieren:
            btnAnonymisieren.Enabled = (qryBaPerson.CanUpdate && qryBaPerson.Count > 0 && _hasSpecialRightsAnonym);
        }

        private void SetEditMode_Heimatorte()
        {
            // Allgemeine Felder einstellen:
            // Wenn Land = CH oder leer, dann kann Heimatort erfasst werden, sonst nicht:
            bool canEdit = (qryBaPerson.CanUpdate && qryBaPerson.Count > 0 && DBUtil.IsEmpty(qryBaPerson["EinwohnerregisterID"]) &&
                            (DBUtil.IsEmpty(qryBaPerson["NationalitaetCode"]) || Utils.isSchweiz(qryBaPerson["NationalitaetCode"]))
                           );

            var editMode = EditModeType.ReadOnly;
            if (canEdit)
            {
                editMode = EditModeType.Normal;
            }

            edtHeimatort.EditMode = editMode;

            // Der Schalter "Alte Heimatorte wählen" soll nur aktiv sein,
            // wenn es auch etwas auszuwählen gibt:
            var heimatorte = qryBaPerson["HeimatGemeindeCodes"] as string;
            btnHeimatorte.Enabled = !string.IsNullOrEmpty(heimatorte) && heimatorte.IndexOf(',') > 0;
        }

        private void SetEditMode_IstInCHSeit()
        {
            // Editierfelder einstellen:
            var editMode = EditModeType.Normal;
            if (editInCHSeitGeburt.Checked || (!qryBaPerson.CanUpdate))
            {
                editMode = EditModeType.ReadOnly;
            }

            editInCHSeit.EditMode = editMode;
            edtInCHseit2.EditMode = editMode;
        }

        private void tabStammdaten_SelectedTabChanged(TabPageEx page)
        {
            if (page == tbpWVCode)
            {
                edtHeimtortLand.Text = GetHeimatortLand();
                ctlWVCode.Activate();
            }
        }

        private void tabStammdaten_SelectedTabChanged_1(TabPageEx page)
        {
        }

        private void tabStammdaten_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            lastSelectedTab = ((KissTabControlEx)sender).SelectedTab;
            if (!DBUtil.IsEmpty(qryBaPerson["Fiktiv"]) && (bool)qryBaPerson["Fiktiv"])
            {
                e.Cancel = true;
            }

            if (tabStammdaten.SelectedTabIndex == 0)
            {
                e.Cancel = e.Cancel || !qryBaPerson.Post();
            }
            else if (tabStammdaten.SelectedTabIndex == 1)
            {
                e.Cancel = e.Cancel || !ctlAdressen.CtlBaPersonAdresse_CanSaveData();
            }
            else if (tabStammdaten.SelectedTabIndex == 2)
            {
                e.Cancel = e.Cancel || !ctlKrankenversicherung.ActiveSQLQuery.Post();
            }
            else if (tabStammdaten.SelectedTabIndex == 3)
            {
                e.Cancel = e.Cancel || !ctlArbeit.CtlBaPersonArbeit_CanSaveData();
            }
            else if (tabStammdaten.SelectedTabIndex == 4)
            {
                e.Cancel = e.Cancel || !ctlBaPersonErsatzeinkommen.ActiveSQLQuery.Post();
            }
            else if (tabStammdaten.SelectedTabIndex == 5)
            {
                e.Cancel = e.Cancel || !ctlBaPersonVermoegen.ActiveSQLQuery.Post();
            }
            else if (tabStammdaten.SelectedTabIndex == 6)
            {
                e.Cancel = e.Cancel || !ctlZahlungsweg.ActiveSQLQuery.Post();
            }
            else if (tabStammdaten.SelectedTabIndex == 7)
            {
                e.Cancel = e.Cancel || (!ctlWVCode.OnSaveData() && !ctlWVCode.UndoBatchChanges());
            }
            else if (tabStammdaten.SelectedTabIndex == 8)
            {
                e.Cancel = e.Cancel || !ctlAlteFallNr.ActiveSQLQuery.Post();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "USERID":
                    return Session.User.UserID;
                case "BETRPERSONID":
                    return qryBaPerson["BaPersonID"];
                case "FT":
                    return _ftPersonId;
                case "FALLUSERID":
                    return DBUtil.ExecuteScalarSQL(@"
                        SELECT TOP 1 FAL.UserID
                        FROM dbo.FaFall FAL
                        WHERE FAL.BaPersonID = {0}
                        ORDER BY FAL.DatumBis, FAL.DatumVon DESC",
                        _ftPersonId);
                case "FAFALLID":
                    return DBUtil.ExecuteScalarSQL(@"
                        SELECT TOP 1 FAL.FaFallID
                        FROM dbo.FaFall FAL
                        WHERE FAL.BaPersonID = {0}
                        ORDER BY FAL.DatumBis, FAL.DatumVon DESC",
                        _ftPersonId);
                case "ABSENDER":
                    return 0;
            }

            return base.GetContextValue(fieldName);
        }

        public DateTime? GetDatumZuzugGdeOrt()
        {
            return datZuzugSeit.EditValue as DateTime?;
        }

        public DateTime? GetDatumZuzugKtOrt()
        {
            return datZuzugKantonSeit.EditValue as DateTime?;
        }

        public bool HasModifiedData()
        {
            return (
                       qryBaPerson.RowModified ||
                       ctlAdressen.qryBaWohnsitzAdresse.RowModified ||
                       ctlAdressen.qryBaAufenthaltAdresse.RowModified ||
                       ctlArbeit.qryBaArbeit.RowModified ||
                       ctlKrankenversicherung.qryBaKrankenversicherung.RowModified ||
                       ctlZahlungsweg.qryBaZahlungsweg.RowModified
                   );
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int ftPersonID, bool isFallTraeger)
        {
            _baPersonId = baPersonID;
            _ftPersonId = ftPersonID;
            picTitel.Image = titleImage;

            // Spezialrechte für Weiterleitung an Stellenleitung
            _hasSpecialRightsAnonym = DBUtil.UserHasRight("CtlBaPerson_Anonymisieren");

            tabStammdaten.SelectedTabIndex = 0;
            OpenData(baPersonID);

            qryBaPerson.CanUpdate = !(bool)qryBaPerson["Fiktiv"];
            qryBaPerson.ApplyUserRights();

            // EditMode ist abhängig von qryBaPerson.CanUpdate
            SetEditMode_Common();
            // Editierfelder "In CH seit" einstellen:
            SetEditMode_IstInCHSeit();
            // Editierfeld Heimatort einstellen:
            SetEditMode_Heimatorte();
        }

        public override bool OnSaveData()
        {
            return qryBaPerson.Post() && base.OnSaveData();
        }

        public void OpenData(int persID)
        {
            _baPersonId = persID;

            //Personalien
            qryBaPerson.Fill(_baPersonId);
            SetTitle();

            // andere Fenster aktualisieren
            // Zipnummer übergeben
            ctlAdressen.SetZipNumber(Utils.ConvertToInt(qryBaPerson["ZipNr"]), qryBaPerson["EinwohnerregisterAktiv"] as bool?);
            ctlAdressen.BaPersonID = _baPersonId;
            ctlAdressen.SetNames(
                Utils.ConvertToString(qryBaPerson["Vorname"]),
                Utils.ConvertToString(qryBaPerson["Name"])
                );

            ctlArbeit.BaPersonID = _baPersonId;
            ctlKrankenversicherung.BaPersonID = _baPersonId;
            ctlZahlungsweg.BaPersonID = _baPersonId;
            ctlWVCode.BaPersonID = _baPersonId;
            ctlBaPersonErsatzeinkommen.BaPersonID = _baPersonId;
            ctlBaPersonVermoegen.BaPersonID = _baPersonId;
            ctlAlteFallNr.BaPersonID = _baPersonId;
        }

        public bool PostData()
        {
            bool postWasOk = true;
            postWasOk = (postWasOk && qryBaPerson.Post());

            postWasOk = (postWasOk && ctlAdressen.qryBaWohnsitzAdresse.Post());
            postWasOk = (postWasOk && ctlAdressen.qryBaAufenthaltAdresse.Post());
            postWasOk = (postWasOk && ctlArbeit.qryBaArbeit.Post());
            postWasOk = (postWasOk && ctlKrankenversicherung.qryBaKrankenversicherung.Post());
            postWasOk = (postWasOk && ctlZahlungsweg.qryBaZahlungsweg.Post());

            return postWasOk;
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToZahlungsweg":
                    if (param["BaZahlungswegID"] != null)
                    {
                        tabStammdaten.SelectTab(tbpZahlweg);
                        DetailControl.ReceiveMessage(param);
                        return true;
                    }

                    return false;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        #endregion

        #region Private Methods

        private string GetHeimatortLand()
        {
            if ((!DBUtil.IsEmpty(qryBaPerson["NationalitaetCode"])) && Utils.isSchweiz(qryBaPerson["NationalitaetCode"]))
            {
                return Utils.ConvertToString(qryBaPerson["Heimatort"]);
            }

            return edtNationalitaet.Properties.GetDisplayText(edtNationalitaet.EditValue);
        }

        private void SetTitle()
        {
            lblTitel.Text = qryBaPerson["Name"].ToString();
            if (!DBUtil.IsEmpty(qryBaPerson["Vorname"]))
            {
                lblTitel.Text += ", " + qryBaPerson["Vorname"];
            }

            lblTitel.Text += "  (P-Nr. " + qryBaPerson["BaPersonID"] + ")";
        }

        #endregion

        #endregion
    }
}