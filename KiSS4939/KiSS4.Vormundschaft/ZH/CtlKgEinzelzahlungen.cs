using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Vormundschaft.ZH
{
    #region Enumerations

    public enum KgBewilligung
    {
        Erstellt = 6,
        PositionZurZahlungFreigegeben = 7,
        FreigabeDerZahlungAufgehoben = 8,
        Rotgestellt = 9,
    }

    #endregion Enumerations

    public partial class CtlKgEinzelzahlungen : KissSearchUserControl, IBelegleser
    {
        #region Fields

        #region Private Fields

        private KgBuchungstext _buchungstext;
        private bool _filling;
        private bool _isNewPosition;
        private DataRow _saveRow;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlKgEinzelzahlungen()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            if (!qryKgPosition.Post()) return;

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryKgPosition.DataTable.Rows)
            {
                if ((int)row["Status"] == 1)
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                }
            }
            qryKgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            DocumentImport();
        }

        private void btnEinzelzahlungenGruenstellen_Click(object sender, EventArgs e)
        {
            var helper = new KgMassenverarbeitungsHelper(qryKgPosition, "KgPositionID", Gruenstellen)
                         {
                             MsgKeineAuswahl = @"Es wurde keine Position ausgewählt.",
                             MsgEineAuswahl = "Soll 1 graue Einzelzahlung auf grün gestellt werden?",
                             MsgMehrereAuswahl = "Sollen {0} graue Einzelzahlungen auf grün gestellt werden?",
                             MsgTitle = "Grünstellen",
                             MsgBeginnVerarbeitung = "Grünstellen beginnt...",
                             MsgVerarbeiten = "Grünstellen von Beleg {0} von {1}",
                             MsgFehlerVerarbeitung = "Fehler beim Grünstellen des Belegs: ",
                             MsgEndeVerarbeitung = "{0} von {1} Positionen konnten grüngestellt werden."
                         };
            helper.starteVerarbeitung();
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            if (!qryKgPosition.Post()) return;

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryKgPosition.DataTable.Rows)
            {
                if ((int)row["Status"] == 1)
                {
                    row["Sel"] = false;
                    row.AcceptChanges();
                }
            }
            qryKgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryMonatsbudget.Count == 0 || qryKgPosition.Count == 0) return;

            if (DBUtil.IsEmpty(qryKgPosition["KgPositionID"]))
            {
                //Sprung ins Monatsbudget
                string pfad = String.Format(@"CtlKgLeistung{0}\Masterbudget{1}\Monatsbudget{2}",
                                            qryMonatsbudget["FaLeistungID"], qryMonatsbudget["MasterbudgetID"],
                                            qryMonatsbudget["KgBudgetID"]);

                FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                                        "BaPersonID", qryMonatsbudget["FallBaPersonID"],
                                        "ModulID", 5,
                                        "FieldValue", pfad);
            }
            else
            {
                //Sprung direkt zur Position im Monatsbudget
                string pfad2 = string.Format(
                    "ClassName=FrmFall;" +
                    "BaPersonID={0};" +
                    "ModulID=5;" +
                    "TreeNodeID=CtlKgLeistung{1}\\Masterbudget{2}\\Monatsbudget{3};" +
                    "ActiveSQLQuery.Find=KgPositionID = {4};",
                    qryMonatsbudget["FallBaPersonID"],
                    qryMonatsbudget["FaLeistungID"],
                    qryMonatsbudget["MasterbudgetID"],
                    qryMonatsbudget["KgBudgetID"],
                    qryKgPosition["KgPositionID"]);

                HybridDictionary dic = FormController.ConvertToDictionary(pfad2);
                FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
            }

            /*
            string pfad = String.Format(@"CtlKgLeistung{0}\Masterbudget{1}\Monatsbudget{2}",
                             qryMonatsbudget["FaLeistungID"],qryMonatsbudget["MasterbudgetID"],qryMonatsbudget["KgBudgetID"]);

            FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                        "BaPersonID", qryKgPosition["FallBaPersonID"],
                        "ModulID", 5,
                        "FieldValue",pfad);
            */
        }

        private void btnPositionenLoeschen_Click(object sender, EventArgs e)
        {
            var helper = new KgMassenverarbeitungsHelper(qryKgPosition, "KgPositionID", KgMassenverarbeitungsHelper.DeleteKgPositionen)
                         {
                             MsgKeineAuswahl = "Es wurde keine Position ausgewählt.",
                             MsgEineAuswahl = "Soll 1 graue Einzelzahlung gelöscht werden?",
                             MsgMehrereAuswahl = "Sollen {0} graue Einzelzahlungen gelöscht werden?",
                             MsgTitle = "Löschen",
                             MsgBeginnVerarbeitung = "Löschen beginnt...",
                             MsgVerarbeiten = "Löschen von Position {0} von {1}",
                             MsgFehlerVerarbeitung = "Fehler beim Löschen der Position: ",
                             MsgEndeVerarbeitung = "{0} von {1} Positionen konnten gelöscht werden."
                         };
            helper.starteVerarbeitung();
        }

        private void CtlKgEinzelzahlungen_Load(object sender, EventArgs e)
        {
            btnDocument.Image = XDokument.BmpImportDoc;

            //Budgetstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBewilligung' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem(
                                                           row["Text"].ToString(),
                                                           (int)row["Code"],
                                                           KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(new ImageComboBoxItem(
                                                           row["Text"].ToString(),
                                                           (int)row["Code"],
                                                           KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new ImageComboBoxItem("", null, -1)); //empty entry

            foreach (ImageComboBoxItem item in repositoryItemImageComboBox2.Items)
            {
                edtSucheStatus.Properties.Items.Add(item);
            }

            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("KgDokumentTyp");
            colKgBewilligungCode.ColumnEdit = grdBewilligung.GetLOVLookUpEdit("KgBewilligung");

            grvEinzelzahlung.CustomRowCellEdit += grvEinzelzahlung_CustomRowCellEdit;
            grvEinzelzahlung.CellValueChanging += grvEinzelzahlung_CellValueChanging;

            btnEinzelzahlungenGruenstellen.Enabled = DBUtil.UserHasRight("CtlKgEinzelzahlungen_EinzelzahlungenFreigeben");
            btnAlle.Enabled = btnEinzelzahlungenGruenstellen.Enabled;
            btnKeine.Enabled = btnEinzelzahlungenGruenstellen.Enabled;
            colSelektion.OptionsColumn.AllowEdit = btnEinzelzahlungenGruenstellen.Enabled;

            _buchungstext = new KgBuchungstext(edtBuchungstext, qryKgPosition);

            tabKgPosition.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;

            PresetSearchFields();
            OnSearch();
        }

        private void edtBuchungstext_Enter(object sender, EventArgs e)
        {
            edtBuchungstext.SelectAll();
        }

        private void edtBuchungstext_TextChanged(object sender, EventArgs e)
        {
            if (edtBuchungstext.UserModified && edtBuchungstext.EditValue != null)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void edtKonto_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKonto.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgPosition["KontoNr"] = DBNull.Value;
                    qryKgPosition["Konto"] = DBNull.Value;
                    UpdateGrbAusgaben();
                    return;
                }
            }

            try
            {
                DBUtil.CheckNotNullField(edtMandant, lblMandant.Text);
            }
            catch
            {
                KissMsg.ShowInfo("Bitte zuerst einen Mandanten auswählen.");
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT distinct
                       Konto       = KTO.KontoNr,
                       Name        = KTO.KontoName,
                       Klasse      = KLA.Text,
                       Konto$      = KTO.KontoNr + ' ' + KTO.KontoName,
                       LeistungID$ = LEI.FaLeistungID
                FROM   FaLeistung LEI
                       INNER JOIN KgPeriode    PER ON PER.FaLeistungID = LEI.FaLeistungID AND
                                                      PER.KgPeriodeStatusCode = 1 --Aktiv
                       INNER JOIN KgKonto      KTO ON KTO.KgPeriodeID = PER.KgPeriodeID AND
                                                      KTO.KontoGruppe = 0 AND
                                                      KTO.KgKontoKlasseCode in (3,4)
                       LEFT  JOIN XLOVCode     KLA ON KLA.LOVName = 'KgKontoKlasse' AND
                                                      KLA.Code = KTO.KgKontoKlasseCode
                WHERE  LEI.FaLeistungID = " + qryKgPosition["FaLeistungID"] + @"  AND
                       KTO.KgKontoklasseCode in (3,4) AND
                       (KTO.KontoName like '%' + {0} + '%' OR
                       KTO.KontoNr like {0} + '%')
                ORDER BY KTO.KontoNr",
                searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKgPosition["KontoNr"] = dlg["Konto"];
                qryKgPosition["Konto"] = dlg["Konto$"];
                qryKgPosition["Buchungstext"] = dlg["Name"];
                UpdateGrbAusgaben();

                _buchungstext.LoadBuchungstext(qryKgPosition["KontoNr"], true);
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKreditor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryKgPosition["Kreditor"] = DBNull.Value;
                    qryKgPosition["ZusatzInfo"] = DBNull.Value;
                    qryKgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    return;
                }
            }

            var dlg2 = new DlgKgAuswahlZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg2.SucheBaZahlungsweg(searchString);
            switch (dlg2.Count)
            {
                case 0:
                    KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryKgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                qryKgPosition["Kreditor"] = dlg2["Kreditor"];
                qryKgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                qryKgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
            }

            qryKgPosition.RefreshDisplay();
            SetEditMode();
        }

        private void edtMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtMandant.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgPosition["Mandant"] = null;
                    qryKgPosition["BaPersonID"] = null;
                    qryKgPosition["Adresse"] = null;
                    qryKgPosition["MT"] = null;
                    qryMonatsbudget.DataTable.Rows.Clear();
                    UpdateGrbAusgaben();
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel =
                !dlg.SearchData(
                    @"
              DECLARE @suchID INT
              IF ISNUMERIC({0}) = 1 AND CHARINDEX('.', {0}) = 0 AND CHARINDEX(',', {0}) = 0 BEGIN
                SELECT @suchID =  CONVERT(int, {0})
              END
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Personen-Nr.]   = PRS.BaPersonID,
                     Name             = PRS.NameVorname,
                     Geburtsdatum     = PRS.Geburtsdatum,
                     [Alter]          = PRS.[Alter],
                     Adresse          = PRS.Wohnsitz,
                     [Beist. oder Vorm.] = dbo.fnVmGetMTName(PRS.BaPersonID),
                     FaLeistungID$    = LEI.FaLeistungID
              FROM   vwPerson PRS
                     inner join FaLeistung LEI on LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 500
                     inner join KgPeriode PER on PER.FaLeistungID = LEI.FaLeistungID
                                             and PER.KgPeriodeStatusCode = 1 --Aktiv
                     inner join BaZahlungsweg ZAH on ZAH.BaZahlungswegID = PER.BaZahlungswegID
                                                 and ISNULL({1}, GETDATE()) BETWEEN ZAH.DatumVon AND ISNULL(ZAH.DatumBis, '99991231') -- ZKB DataLink muss zum Zeitpunkt des Erfassungsdatums aktiv sein, da es sich um die Buchungsmaske handelt
              WHERE  PRS.NameVorname_AI LIKE '%' + {0} + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID
              ORDER BY PRS.NameVorname",
                    searchString,
                    e.ButtonClicked, edtErfassungDatum.DateTime, null, null);

            if (edtErfassungDatum.EditValue != null && !DBUtil.IsEmpty(dlg["FaLeistungID$"]))
            {
                e.Cancel = KgValidierungsHelper.KgCheckVerkehrskonto((int)dlg["FaLeistungID$"],
                                                                     edtErfassungDatum.DateTime);
                if (e.Cancel)
                {
                    KissMsg.ShowInfo(KgValidierungsHelper.ErrorMsg_Verkehrskonto_ungueltig);
                }
            }
            if (!e.Cancel)
            {
                SetMandant(dlg["Name"].ToString(), (int)dlg["BaPersonID$"], dlg["Adresse"].ToString(),
                           dlg["Beist. oder Vorm."].ToString(), (int)dlg["FaLeistungID$"]);
            }
        }

        private void edtSucheErfassungMA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheErfassungMA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                    searchString = "%";
                else
                {
                    edtSucheErfassungMA.LookupID = DBNull.Value;
                    edtSucheErfassungMA.EditValue = DBNull.Value;
                    edtSucheErfassungMA.ToolTip = "";
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel =
                !dlg.SearchData(
                    @"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%'
              ORDER BY NameVorname",
                    searchString,
                    e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheErfassungMA.LookupID = dlg["ID$"];
                edtSucheErfassungMA.EditValue = dlg["Kürzel"];
                edtSucheErfassungMA.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private void edtSucheMutationMA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheMutationMA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                    searchString = "%";
                else
                {
                    edtSucheMutationMA.LookupID = DBNull.Value;
                    edtSucheMutationMA.EditValue = DBNull.Value;
                    edtSucheMutationMA.ToolTip = "";
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel =
                !dlg.SearchData(
                    @"
              SELECT ID$ = UserID,
                [Kürzel] = LogonName,
                [Mitarbeiter/in] = NameVorname,
                [Org.Einheit] = OrgUnit,
                DisplayText$ = DisplayText
              FROM   vwUser
              WHERE  DisplayText LIKE '%' + {0} + '%'
              ORDER BY NameVorname",
                    searchString,
                    e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtSucheMutationMA.LookupID = dlg["ID$"];
                edtSucheMutationMA.EditValue = dlg["Kürzel"];
                edtSucheMutationMA.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private void edtValutaDatum_Validated(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtValutaDatum.EditValue) && !DBUtil.IsEmpty(qryKgPosition["FaLeistungID"]))
            {
                if (KgValidierungsHelper.KgCheckVerkehrskonto((int)qryKgPosition["FaLeistungID"],
                                                              edtValutaDatum.DateTime))
                {
                    KissMsg.ShowInfo(KgValidierungsHelper.ErrorMsg_Verkehrskonto_ungueltig);
                    edtValutaDatum.EditValue = null;
                }
            }
        }

        private void grvEinzelzahlung_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
            {
                return;
            }
            bool rowModified = qryKgPosition.RowModified;
            grvEinzelzahlung.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
            if (!rowModified)
            {
                qryKgPosition.Row.AcceptChanges();
                qryKgPosition.RowModified = false;
            }
        }

        private void grvEinzelzahlung_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvEinzelzahlung.GetRowCellValue(e.RowHandle, e.Column)))
                    e.RepositoryItem = repositoryItemTextEdit1;
                else
                    e.RepositoryItem = repositoryItemCheckEdit1;
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (!(sender is KissLabel)) return;

            var lbl = (KissLabel)sender;
            lbl.Font = new Font(GuiConfig.LabelFontName,
                                GuiConfig.LabelFontSize,
                                lbl.Font.Underline ? FontStyle.Regular : FontStyle.Underline | FontStyle.Bold,
                                GuiConfig.LabelFontGraphicUnit);
        }

        private void qryKgDokumente_AfterDelete(object sender, EventArgs e)
        {
            UpdateDocCount();
            // try to delete XDocument
            try
            {
                var documentID = (int?)qryKgDokumente["DocumentID"];
                if (documentID.HasValue)
                {
                    DBUtil.ExecSQL("DELETE FROM XDocument WHERE DocumentID = {0}", documentID.Value);
                }
            }
            catch
            {
            }
        }

        private void qryKgDokumente_AfterInsert(object sender, EventArgs e)
        {
            if (qryKgPosition.IsEmpty)
            {
                return;
            }

            string stichwort = qryKgPosition["Konto"].ToString();
            var index = stichwort.IndexOf(" ");

            if (index >= 0)
            {
                qryKgDokumente["Stichwort"] = stichwort.Substring(index);
            }

            qryKgDokumente["KgDokumentTypCode"] = 1;
            edtDokumentTyp.Focus();
        }

        private void qryKgDokumente_BeforePost(object sender, EventArgs e)
        {
            if (qryKgPosition.Row.RowState == DataRowState.Added)
            {
                throw new KissCancelException("Dokumente können erst nach dem Speichern der Position hinzugefügt werden.");
            }

            if (!qryKgDokumente.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryKgDokumente["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }

            if ((int)qryKgDokumente["KgDokumentTypCode"] == 1)
            {
                qryKgDokumente["KgPositionID"] = qryKgPosition["KgPositionID"];
                qryKgDokumente["KgBudgetID"] = DBNull.Value;
            }
            else
            {
                qryKgDokumente["KgPositionID"] = DBNull.Value;
                qryKgDokumente["KgBudgetID"] = qryKgPosition["KgBudgetID"];
            }

            if (DBUtil.IsEmpty(qryKgDokumente["Stichwort"])) qryKgDokumente["Stichwort"] = "-";
        }

        private void qryKgDokumente_PostCompleted(object sender, EventArgs e)
        {
            UpdateDocCount();
            qryKgDokumente.Refresh();
        }

        private void qryKgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryKgPosition["KgPositionsKategorieCode"] = 2;
            qryKgPosition["Doc"] = false;
            qryKgPosition["KgAuszahlungsArtCode"] = 101; //elektronisch
            qryKgPosition["KgAuszahlungsTerminCode"] = 4; //Valuta
            qryKgPosition["BuchungDatum"] = DateTime.Today;
            qryKgPosition["Status"] = 1;

            SetFieldsAndTabStop();
            FocusFirstNotFixedField();

            ctlErfassungMutation1.ShowInfo();

            UpdateGrbAusgaben();
        }

        private void qryKgPosition_AfterPost(object sender, EventArgs e)
        {
            //Save ValutaDatum in KgPositionValuta
            DBUtil.ExecSQL(@"
                DELETE dbo.KgPositionValuta WHERE KgPositionID = {0};
                INSERT dbo.KgPositionValuta (KgPositionID, Datum) VALUES ({0}, {1});",
                qryKgPosition["KgPositionID"],
                qryKgPosition["ValutaDatum"]);

            if (_isNewPosition)
            {
                InsertPositionVerlaufEintrag(KgBewilligung.Erstellt, (int)qryKgPosition["KgPositionID"]);
            }

            Session.Commit();

            if (qryKgPosition["Status"] as int? == 1)
            {
                qryKgPosition["Sel"] = false;
            }
            SetSaveRow();
            qryKgPosition.RefreshDisplay();
        }

        private void qryKgPosition_BeforeDelete(object sender, EventArgs e)
        {
            var positionStatus = (int)qryKgPosition["Status"];

            if (positionStatus != 1)
            {
                throw new KissInfoException("nur graue Positionen können gelöscht werden!");
            }

            DBUtil.ExecSQL(@"
                DELETE dbo.KgPositionValuta WHERE KgPositionID = {0};
                DELETE dbo.KgDokument WHERE KgPositionID = {0};",
                qryKgPosition["KgPositionID"]);
        }

        private void qryKgPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtErfassungDatum, lblErfassungDatum.Text);
            DBUtil.CheckNotNullField(edtMandant, lblMandant.Text);
            DBUtil.CheckNotNullField(edtKonto, lblKonto.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryKgPosition["Betrag"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);
            DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);

            if (edtReferenzNummer.EditMode == EditModeType.Normal)
            {
                DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);
            }

            if (qryKgPosition.CurrentRowState == DataRowState.Added || qryKgPosition.TreatRowAsInserted)
            {
                //ValutaDatum
                if ((DateTime)qryKgPosition["ValutaDatum"] < DateTime.Today)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "ValutadatumdarfNichtinderVergangheit", "Das Valutadatum darf nicht in der Vergangenheit liegen"));
                }
            }

            if (qryMonatsbudget.Count == 0)
            {
                throw new KissInfoException("Es gibt keine verfügbaren Budgets für diesen Mandanten!");
            }

            if ((int)qryMonatsbudget["KgBewilligungCode"] == 1)
            {
                throw new KissInfoException(
                    "in dieser Maske kann eine Einzelzahlung nicht in ein graues Monatsbudget erfasst werden!");
            }

            KgValidierungsHelper.KgCheckVerkehrskontoThrowsException((int)qryKgPosition["FaLeistungID"],
                                                                     edtValutaDatum.DateTime);

            qryKgPosition["KgBudgetID"] = qryMonatsbudget["KgBudgetID"];
            qryKgPosition["BudgetKgBewilligungCode"] = qryMonatsbudget["KgBewilligungCode"];
            qryKgPosition["MA"] = Session.User.LogonName;
            //TODO PSL: TEST if necessary
            LoadFreigabe();

            ctlErfassungMutation1.SetFields();

            _isNewPosition = qryKgPosition.CurrentRowState == DataRowState.Added;

            Session.BeginTransaction();
        }

        private void qryKgPosition_PositionChanged(object sender, EventArgs e)
        {
            ctlErfassungMutation1.ShowInfo();

            int status = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
                status = (int)qryKgPosition["Status"];

            _filling = true;
            switch (status)
            {
                case 0:
                    qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
                    try
                    {
                        int? year = qryMonatsbudget["Jahr"] as int?;
                        int? month = qryMonatsbudget["Monat"] as int?;

                        while ((year.HasValue && year.Value != DateTime.Now.Year) ||
                               (month.HasValue && month.Value != DateTime.Now.Month))
                        {
                            if (!qryMonatsbudget.Next()) break;
                            year = qryMonatsbudget["Jahr"] as int?;
                            month = qryMonatsbudget["Monat"] as int?;
                        }
                    }
                    catch
                    {
                        Debugger.Break();
                    }
                    break;

                case 1:
                    qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
                    if (qryMonatsbudget.IsEmpty)
                    {
                        qryKgPosition["KgBudgetID"] = DBNull.Value;
                        break;
                    }

                    if (DBUtil.IsEmpty(qryKgPosition["KgBudgetID"]))
                    {
                        break;
                    }

                    try
                    {
                        while ((int)qryKgPosition["KgBudgetID"] != (int)qryMonatsbudget["KgBudgetID"])
                        {
                            if (!qryMonatsbudget.Next()) break;
                        }
                    }
                    catch
                    {
                        Debugger.Break();
                    }

                    break;

                default:
                    qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], qryKgPosition["KgBudgetID"]);
                    break;
            }

            _filling = false;

            qryKgDokumente.Fill(qryKgPosition["KgPositionID"]);
            qryKgBewilligung.Fill(qryKgPosition["KgPositionID"]);

            _buchungstext.LoadBuchungstext(qryKgPosition["KontoNr"], false);

            LoadFreigabe();

            SetEditMode();
        }

        private void qryKgPosition_PositionChanging(object sender, EventArgs e)
        {
            SetSaveRow();
        }

        private void qryKgPosition_PostCompleted(object sender, EventArgs e)
        {
            UpdateDocCount();
            qryKgPosition_PositionChanged(null, null);
        }

        private void qryMonatsbudget_PositionChanged(object sender, EventArgs e)
        {
            if (_filling) return;
            qryKgPosition.RowModified = true;
        }

        private void splitterTreeControl_SplitterCollapsed(object sender, EventArgs e)
        {
            //this.tabKgPosition.Height -= grbAusgaben.Height;
        }

        private void splitterTreeControl_SplitterExpanded(object sender, EventArgs e)
        {
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            bool visible = page == tpgListe;
            btnAlle.Visible = visible;
            btnKeine.Visible = visible;
            btnEinzelzahlungenGruenstellen.Visible = visible;
            btnPositionenLoeschen.Visible = visible;
            SetEditMode();
        }

        private void tabKgPosition_SelectedTabChanged(TabPageEx page)
        {
            if (tabKgPosition.SelectedTab == tpgDokumente)
            {
                ActiveSQLQuery = qryKgDokumente;
            }
            else
            {
                ActiveSQLQuery = qryKgPosition;
            }
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            int status = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
                status = (int)qryKgPosition["Status"];

            if (status > 1)
            {
                KissMsg.ShowInfo(
                    "Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            var dlg = new DlgKgAuswahlZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);
            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    if (beleg.Betrag > 0)
                        qryKgPosition["Betrag"] = beleg.Betrag;
                    qryKgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
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
                qryKgPosition["BaZahlungswegID"] = dlg["BaZahlungswegID"];
                qryKgPosition["Kreditor"] = dlg["Kreditor"];
                qryKgPosition["ZusatzInfo"] = dlg["ZusatzInfo"];
                if (beleg.Betrag > 0)
                    qryKgPosition["Betrag"] = beleg.Betrag;
                qryKgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                qryKgPosition["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];
            }

            qryKgPosition.RefreshDisplay();
            SetEditMode();
        }

        public override bool OnKeyDownKiss(KeyEventArgs e)
        {
            KeyEventArgs keys = DBUtil.GetConfigShortcut(@"System\Allgemein\NeuesDokumentShortcut", "Control+N");

            if (e.KeyData == keys.KeyData)
            {
                DocumentImport();
            }

            return base.OnKeyDownKiss(e);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            PresetSearchFields();
            edtSucheErfassungMA.Focus();
        }

        protected override void RunSearch()
        {
            base.RunSearch();
            qryKgPosition.Last();
        }

        #endregion Protected Methods

        #region Private Methods

        private void DocumentImport()
        {
            if (!qryKgPosition.IsEmpty && qryKgPosition.Post())
            {
                tabKgPosition.SelectTab(tpgDokumente);
                qryKgDokumente.Insert();
                edtDocument.Focus();
                edtDocument.ImportDoc();
            }
        }

        private void FocusFirstNotFixedField()
        {
            SelectNextControl(edtMandant, true, true, true, true);
        }

        /// <summary>
        /// Stellt eine einzelne Position auf grün.
        /// Hinweis:
        /// Wird vom  KgMassenverarbeitungsHelper aus aufgerufen.
        /// </summary>
        /// <param name="row"></param>
        private void Gruenstellen(DataRow row)
        {
            // Die Transaktion wird durch den KgMassenverarbeitungsHelper sichergestellt
            if (row["BudgetKgBewilligungCode"] as int? != 5)
            {
                throw new Exception("Nur Positionen in einem bewilligten Budget können grüngestellt werden.");
            }

            //Als KliBu Sachbearbeiter kann ich in der Maske "Kreditoren" eine graue Position (EZ oder ZL)
            //nur dann grünstellen, wenn ich die Position nicht efasst habe und
            //über ein Spezialrecht verfüge (dann kann ich den Button schon gar nicht drücken wird in CtlKgEinzelzahlungen_Load gemacht)
            if (Session.User.UserID == (int)row["ErstelltUserID"])
            {
                string message = KissMsg.GetMLMessage(GetType().Name, "FreigabeDurchErfasserNichtMoeglich",
                                               "Freigabe durch Erfasser nicht möglich");
                throw new Exception(message);
            }

            //Position nun Grünstellen.
            DBUtil.ExecSQLThrowingException(@"
                EXECUTE spKgBudget_KgBuchung_Create {0}, {1}, {2}, 0",
                                            row["KgBudgetID"],
                                            row["KgPositionID"],
                                            Session.User.UserID);

            //Eintrag in KgBewilligung
            InsertPositionVerlaufEintrag(KgBewilligung.PositionZurZahlungFreigegeben,
                                         Utils.ConvertToInt(row["KgPositionID"]));
        }

        private void InsertPositionVerlaufEintrag(KgBewilligung kgBewilligungCode, int kgPositionId)
        {
            qryKgBewilligung.CanInsert = true;
            qryKgBewilligung.Fill(kgPositionId);

            qryKgBewilligung.Insert();
            qryKgBewilligung["KgPositionID"] = kgPositionId;
            qryKgBewilligung["UserID"] = Session.User.UserID;
            qryKgBewilligung["ClassName"] = Name;
            qryKgBewilligung["Datum"] = DateTime.Now;
            qryKgBewilligung["KgBewilligungCode"] = (int)kgBewilligungCode;
            qryKgBewilligung.Post();
            qryKgBewilligung.CanInsert = false;
            qryKgBewilligung.Fill(kgPositionId);
        }

        /// <summary>
        /// Berechnet den Inhalt des Feldes Freigabe.
        /// </summary>
        private void LoadFreigabe()
        {
            //Das Feld Freigabe:
            //In diesem Feld wird die User-ID, desjenigen MA eingetragen,
            //welcher die Position in den Status „grün“ gesetzt hat.
            //Wird die Position wieder grau gestellt, dann werden die Werte dieses Feldes wieder zurückgesetzt.

            SqlQuery qry = DBUtil.OpenSQL(@"
                ;WITH TmpCte AS
                (
                  SELECT TOP 1
                    UserID = USR.UserID,
                    Name   = USR.LogonName,
                    Datum  = CONVERT(VARCHAR(10), KGB.Datum, 104),
                    KgBewilligungCode = KGB.KgBewilligungCode
                  FROM dbo.KgPosition            POS
                    INNER JOIN dbo.KgBewilligung KGB ON KGB.KgPositionID = POS.KgPositionID
                    INNER JOIN dbo.XUser         USR ON USR.UserID = KGB.UserID
                  WHERE POS.KgPositionID = {0}
                    AND KGB.KgBewilligungCode in (7,8) -- Position zur Zahlung freigegeben, Freigabe der Zahlung aufgehoben
                  ORDER BY KGB.Datum DESC
                )

                -- Bei grauen Positionen muss das Kontrolle Feld leer sein
                SELECT *
                FROM TmpCte
                WHERE KgBewilligungCode <> 8; -- Freigabe der Zahlung aufgehoben",
                qryKgPosition["KgPositionID"]);

            if (qry.IsEmpty)
            {
                lblFreigabeInhalt.Text = "---";
            }
            else
            {
                lblFreigabeInhalt.Text = string.Format("{0}, {1}", qry["Name"], qry["Datum"]);
            }
        }

        private void PresetSearchFields()
        {
            edtSucheErfassungMA.LookupID = Session.User.UserID;
            edtSucheErfassungMA.EditValue = Session.User.LogonName;
            edtSucheErfassungVon.EditValue = DateTime.Today;
            edtSucheErfassungBis.EditValue = DateTime.Today;
            edtSucheStatus.EditValue = 1;
        }

        private void SetEditMode()
        {
            int status = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
            {
                status = (int)qryKgPosition["Status"];
            }

            bool editable = (status <= 1) && qryKgPosition.Count > 0;

            qryKgPosition.EnableBoundFields(editable);

            int es = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["EinzahlungsscheinCode"]))
            {
                es = (int)qryKgPosition["EinzahlungsscheinCode"];
            }

            edtReferenzNummer.EditMode = (es == 1) && editable ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile1.EditMode = ((es == 2) || (es == 3) || (es == 4) || (es == 5)) && editable
                                               ? EditModeType.Normal
                                               : EditModeType.ReadOnly;
            edtMitteilungZeile2.EditMode = edtMitteilungZeile1.EditMode;
            edtMitteilungZeile3.EditMode = edtMitteilungZeile1.EditMode;
            UpdateGrbAusgaben();
        }

        private void SetFieldsAndTabStop()
        {
            //Mandant
            if (lblMandant.Font.Underline && _saveRow != null)
            {
                qryKgPosition["Mandant"] = _saveRow["Mandant"];
                edtMandant.TabStop = false;
                SetMandant(
                    _saveRow["Mandant"].ToString(),
                    (int)_saveRow["BaPersonID"],
                    _saveRow["Adresse"].ToString(),
                    _saveRow["MT"].ToString(),
                    (int)_saveRow["FaLeistungID"]);
            }
            else
            {
                edtMandant.TabStop = true;
            }

            //Konto
            if (lblKonto.Font.Underline && _saveRow != null)
            {
                qryKgPosition["Konto"] = _saveRow["Konto"];
                qryKgPosition["KontoNr"] = _saveRow["KontoNr"];
                edtKonto.TabStop = false;
            }
            else
            {
                edtKonto.TabStop = true;
            }

            //Buchungstext
            if (lblBuchungstext.Font.Underline && _saveRow != null)
            {
                qryKgPosition["Buchungstext"] = _saveRow["Buchungstext"];
                edtBuchungstext.TabStop = false;
            }
            else
            {
                edtBuchungstext.TabStop = true;
            }

            _buchungstext.LoadBuchungstext(qryKgPosition["KontoNr"], false);
            if (edtBuchungstext.EditValue != null)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }

            SetMonatsBudget();

            //Valuta
            if (lblValutaDatum.Font.Underline && _saveRow != null)
            {
                qryKgPosition["ValutaDatum"] = _saveRow["ValutaDatum"];
                edtValutaDatum.TabStop = false;
            }
            else
            {
                edtValutaDatum.TabStop = true;
            }

            //Mitteilung
            if (lblZahlungsgrund.Font.Underline && _saveRow != null)
            {
                qryKgPosition["MitteilungZeile1"] = _saveRow["MitteilungZeile1"];
                qryKgPosition["MitteilungZeile2"] = _saveRow["MitteilungZeile2"];
                qryKgPosition["MitteilungZeile3"] = _saveRow["MitteilungZeile3"];
                edtMitteilungZeile1.TabStop = false;
                edtMitteilungZeile2.TabStop = false;
                edtMitteilungZeile3.TabStop = false;
            }
            else
            {
                edtMitteilungZeile1.TabStop = true;
                edtMitteilungZeile2.TabStop = true;
                edtMitteilungZeile3.TabStop = true;
            }
        }

        private void SetMandant(string name, int baPersonID, string adresse, string mandantTraeger, int faLeistungID)
        {
            qryKgPosition["Mandant"] = name;
            qryKgPosition["BaPersonID"] = baPersonID;
            qryKgPosition["Adresse"] = adresse;
            qryKgPosition["MT"] = mandantTraeger;
            qryKgPosition["FaLeistungID"] = faLeistungID;

            UpdateGrbAusgaben();
            qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
            while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                   Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
            {
                if (!qryMonatsbudget.Next()) break;
            }

            qryKgPosition["KgBudgetID"] = qryMonatsbudget["KgBudgetID"];

            SetMonatsBudget();
        }

        private void SetMonatsBudget()
        {
            //Monatsbudget
            if (kissLabel1.Font.Underline && _saveRow != null)
            {
                qryMonatsbudget.Find(string.Format("Monat={0} AND Jahr={1}", _saveRow["Monat"], _saveRow["Jahr"]));
                qryKgPosition["KgBudgetID"] = qryMonatsbudget["KgBudgetID"];
                grdMonatsbudget.TabStop = false;
            }
            else
            {
                grdMonatsbudget.TabStop = true;
            }
        }

        private void SetSaveRow()
        {
            DataTable tmpTable = qryKgPosition.DataTable.Clone();
            tmpTable.Columns.Add("Monat");
            tmpTable.Columns.Add("Jahr");

            //only save the current row if we have one
            if (!qryKgPosition.IsEmpty)
            {
                _saveRow = tmpTable.NewRow();
                _saveRow.ItemArray = (object[])qryKgPosition.Row.ItemArray.Clone();
                _saveRow["Monat"] = qryMonatsbudget["Monat"];
                _saveRow["Jahr"] = qryMonatsbudget["Jahr"];
            }
            else
            {
                _saveRow = null;
            }
        }

        private void UpdateDocCount()
        {
            bool modified = qryKgPosition.RowModified;

            if (qryKgDokumente.Count > 0)
                qryKgPosition["Doc"] = qryKgDokumente.Count;
            else
                qryKgPosition["Doc"] = null;

            if (!modified)
            {
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();
            }
        }

        private void UpdateGrbAusgaben()
        {
            bool visible = qryKgPosition.Count > 0 && tabControlSearch.SelectedTab == tpgListe;
            //&& !DBUtil.IsEmpty(qryKgPosition["BaPersonID"]) && !DBUtil.IsEmpty(qryKgPosition["KontoNr"]);
            grbAusgaben.Visible = visible;
            if (visible)
            {
                qryKgBuchung.Fill(qryKgPosition["BaPersonID"], qryKgPosition["KontoNr"]);
                if (DBUtil.IsEmpty(qryKgPosition["KontoNr"]))
                {
                    grbAusgaben.Text = "Buchungen des Mandanten";
                }
                else
                {
                    grbAusgaben.Text = string.Format("Buchungen des Mandanten auf Konto {0}", qryKgPosition["KontoNr"]);
                }
                decimal saldo = Decimal.Zero;
                for (int t = qryKgBuchung.DataTable.Rows.Count - 1; t >= 0; t--)
                {
                    DataRow row = qryKgBuchung.DataTable.Rows[t];
                    if (row.RowState != DataRowState.Deleted)
                    {
                        saldo += (decimal)row["BetragSoll"] - (decimal)row["BetragHaben"];
                        if (row["BetragHaben"].Equals(decimal.Zero))
                        {
                            row["BetragHaben"] = DBNull.Value;
                        }
                        if (row["BetragSoll"].Equals(decimal.Zero))
                        {
                            row["BetragSoll"] = DBNull.Value;
                        }
                        row["Saldo"] = saldo;
                        row.AcceptChanges();
                    }
                }
            }
            qryKgBuchung.RowModified = false;
            //tabKgPosition.Height = visible ? 535 : 385;
            //panel2.Top = visible ? Height - 535 - 50 : Height - 385 - 50;

            ////grdEinzelzahlung.Height = visible ? this.Height - 535 - 50 : this.Height - 385 - 50;
            //tabControlSearch.Height = visible ? Height - 535 - 50 : Height - 385 - 50;
        }

        #endregion Private Methods

        private void label10_Click(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}