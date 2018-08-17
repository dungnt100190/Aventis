using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace KiSS4.Vormundschaft.ZH
{
    public partial class CtlKgSollstellungen : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private bool _baInsititutionIDAnpassen;
        private bool _baInsititutionIDAnpassen2;
        private bool _buchungDatumAnpassen;
        private KgBuchungstext _buchungstext;
        private bool _buchungTextAnpassen;
        private bool _buchungTextAnpassen2;
        private bool _documentImporting;
        private bool _filling;
        private bool _kontoNrAnpassen;
        private bool _kontoNrAnpassen2;
        private bool _zuweisenClicking;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlKgSollstellungen()
        {
            InitializeComponent();
            qryKgDokumente2.Fill();
        }

        #endregion Constructors

        #region Properties

        private bool Entsperrt
        {
            get
            {
                return edtEntsperren.Visible && edtEntsperren.Checked;
            }
        }

        private bool Entsperrt2
        {
            get
            {
                return edtEntsperren2.Visible && edtEntsperren2.Checked;
            }
        }

        #endregion Properties

        #region EventHandlers

        private void btnAenderungenUebernehmen2_Click(object sender, EventArgs e)
        {
            qryKgPosition2.Post();
        }

        private void btnAlle_Click(object sender, EventArgs e)
        {
            SelectAllOrNothing(true);
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            DocumentImport();
        }

        private void btnDokZuweisen_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtStichwort2.EditValue))
            {
                edtStichwort2.Focus();
                KissMsg.ShowInfo("Das Feld Stichwort darf nicht leer bleiben!");

                return;
            }

            if (DBUtil.IsEmpty(qryKgDokumente2["DocumentID"]))
            {
                edtDokument2.Focus();
                KissMsg.ShowInfo("Das Feld Dokument darf nicht leer bleiben!");
                return;
            }

            if (qryKgPosition2.Count == 0)
            {
                KissMsg.ShowInfo("Es ist keine betragsgleiche Position ausgewählt!");
                return;
            }

            try
            {
                qryKgDokumente2["Stichwort"] = edtStichwort2.EditValue;
                _zuweisenClicking = true;
                try
                {
                    qryKgDokumente2.Post();
                }
                finally
                {
                    _zuweisenClicking = false;
                }
                /*DBUtil.ExecSQLThrowingException(
                    "insert KgDokument (KgPositionID,KgDokumentTypCode,DocumentID,Stichwort) values ({0},1,{1},{2})",
                    qryKgPosition2["KgPositionID"],
                    qryKgDokumente2["DocumentID"],
                    edtStichwort2.EditValue);*/

                //begonnene Erfassung abbrechen und neu KgPosition einfügen
                qryKgDokumente2.Fill();
                edtStichwort2.EditValue = null;
                qryKgPosition.RowModified = false;
                qryKgPosition.Insert();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlKgSollstellungen", "Dokument zuweisen", "Beim Versuch, das Dokument zuzuweisen, ist ein Fehler aufgetreten", ex);
            }
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            SelectAllOrNothing(false);
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryMonatsbudget.Count == 0 || qryKgPosition.Count == 0) return;

            if (DBUtil.IsEmpty(qryKgPosition["KgPositionID"]))
            {
                //Sprung ins Monatsbudget
                string pfad = String.Format(@"CtlKgLeistung{0}\Masterbudget{1}\Monatsbudget{2}",
                                 qryMonatsbudget["FaLeistungID"], qryMonatsbudget["MasterbudgetID"], qryMonatsbudget["KgBudgetID"]);

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
        }

        private void btnPositionenLoeschen_Click(object sender, EventArgs e)
        {
            KgMassenverarbeitungsHelper helper = new KgMassenverarbeitungsHelper(qryKgPosition, "KgPositionID", KgMassenverarbeitungsHelper.DeleteKgPositionen);
            helper.MsgKeineAuswahl = "Es wurde keine Position ausgewählt.";
            helper.MsgEineAuswahl = "Soll 1 graue Position gelöscht werden?";
            helper.MsgMehrereAuswahl = "Sollen {0} graue Positionen gelöscht werden?";
            helper.MsgTitle = "Löschen";
            helper.MsgBeginnVerarbeitung = "Löschen beginnt...";
            helper.MsgVerarbeiten = "Löschen von Position {0} von {1}";
            helper.MsgFehlerVerarbeitung = "Fehler beim Löschen der Position: ";
            helper.MsgEndeVerarbeitung = "{0} von {1} Positionen konnten gelöscht werden.";
            helper.starteVerarbeitung();
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (qryKgPosition.IsEmpty || !qryKgPosition.Post())
            {
                return;
            }

            try
            {
                int budgetStatus = (int)qryMonatsbudget["KgBewilligungCode"];

                if (budgetStatus != 5 && budgetStatus != 9)
                {
                    return;
                }

                int positionStatus = (int)qryKgPosition["Status"];

                if (positionStatus != 2 && positionStatus != 5)
                {
                    return;
                }

                // grüne oder "Zahlauftrag fehlerhaft" Position auf grau stellen -> KgBuchung Eintrag löschen
                DBUtil.ExecSQLThrowingException(@"
                    delete KgBuchung
                    where  KgPositionID = {0} and
                           KgBuchungStatusCode in (2,5)",
                        qryKgPosition["KgPositionID"]);
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryKgPosition["Status"] = 1; //grau
            qryKgPosition["Sel"] = false;
            qryKgPosition.RowModified = false;
            qryKgPosition.Row.AcceptChanges();
            qryKgPosition_PositionChanged(null, null);
        }

        private void CtlKgSollstellungen_Load(object sender, EventArgs e)
        {
            btnDocument.Image = XDokument.BmpImportDoc;

            //Budgetstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBewilligung' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' and Code in (1,2,3,5,6,7,8,10) order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            colPosStatus2.ColumnEdit = repositoryItemImageComboBox2;

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", null, -1));  //empty entry
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            foreach (DevExpress.XtraEditors.Controls.ImageComboBoxItem item in repositoryItemImageComboBox2.Items)
                edtSucheStatus.Properties.Items.Add(item);

            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("KgDokumentTyp");

            qryKgPosition.PostCompleted += qryKgPosition_PostCompleted;
            qryKgDokumente.PostCompleted += qryKgDokumente_PostCompleted;

            //qryDocDummy.Fill();

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

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            UserModifiedFld(qryKgPosition, searchString, e);
        }

        private void edtDebitor2_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtDebitor2.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            UserModifiedFld(qryKgPosition2, searchString, e);
        }

        private void edtDokument2_DocumentImported(object sender, EventArgs e)
        {
            _documentImporting = false;
        }

        private void edtDokument2_DocumentImporting(object sender, CancelEventArgs e)
        {
            _documentImporting = true;
        }

        private void edtEntsperren_CheckedChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void edtEntsperren2_CheckedChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void edtKonto_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKonto.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            konto_userModifiedFld(searchString, qryKgPosition, e);

            if (!e.Cancel)
            {
                _buchungstext.LoadBuchungstext(qryKgPosition["KontoNr"], true);
            }
        }

        private void edtKonto2_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKonto2.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            konto_userModifiedFld(searchString, qryKgPosition2, e);
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
                    qryKgPosition["FaLeistungID"] = null;
                    qryKgPeriode.DataTable.Clear();
                    qryMonatsbudget.DataTable.Rows.Clear();
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
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
                     FaLeistungID     = LEI.FaLeistungID
              FROM   vwPerson PRS
                     INNER JOIN FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID AND
                                                  LEI.FaProzessCode = 500
                     INNER JOIN KgPeriode PER on PER.FaLeistungID = LEI.FaLeistungID
                                             and PER.KgPeriodeStatusCode = 1 --Aktiv
                     INNER JOIN BaZahlungsweg ZAH on ZAH.BaZahlungswegID = PER.BaZahlungswegID
                                                 and ISNULL({1}, GETDATE()) BETWEEN ZAH.DatumVon AND ISNULL(ZAH.DatumBis, '99991231') -- ZKB DataLink muss zum Zeitpunkt des Erfassungsdatums aktiv sein, da es sich um die Buchungsmaske handelt
              WHERE  PRS.NameVorname_AI LIKE '%' + {0} + '%'
                     OR LEI.FaFallID = @suchID OR PRS.BaPersonID = @suchID
              ORDER BY PRS.NameVorname",
              searchString,
              e.ButtonClicked, edtErfassungDatum.DateTime, null, null);

            if (!e.Cancel)
            {
                qryKgPosition["Mandant"] = dlg["Name"];
                qryKgPosition["BaPersonID"] = dlg["BaPersonID$"];
                qryKgPosition["Adresse"] = dlg["Adresse"];
                qryKgPosition["MT"] = dlg["Beist. oder Vorm."];
                qryKgPosition["FaLeistungID"] = dlg["FaLeistungID"];
                qryKgPeriode.Fill(qryKgPosition["FaLeistungID"]);

                qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
                while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                       Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                {
                    if (!qryMonatsbudget.Next()) break;
                }
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

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
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

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
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

        private void grvEinzelzahlung_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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

        private void grvEinzelzahlung_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvEinzelzahlung.GetRowCellValue(e.RowHandle, e.Column)))
                    e.RepositoryItem = repositoryItemTextEdit1;
                else
                    e.RepositoryItem = repositoryItemCheckEdit1;
            }
        }

        private void konto_userModifiedFld(string searchString, SqlQuery qryKgPos, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKgPos["KontoNr"] = DBNull.Value;
                    qryKgPos["Konto"] = DBNull.Value;
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

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT distinct
                     Konto   = KTO.KontoNr,
                     Name    = KTO.KontoName,
                     Klasse  = KLA.Text,
                     Konto$  = KTO.KontoNr + ' ' + KTO.KontoName
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
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKgPos["KontoNr"] = dlg["Konto"];
                qryKgPos["Konto"] = dlg["Konto$"];
                qryKgPos["Buchungstext"] = dlg["Name"];
            }
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
            catch { }
        }

        private void qryKgDokumente_AfterInsert(object sender, EventArgs e)
        {
            string stichwort = "";
            if (!DBUtil.IsEmpty(qryKgPosition["Konto"]))
                stichwort = qryKgPosition["Konto"].ToString();
            if (stichwort.Contains(" "))
            {
                qryKgDokumente["Stichwort"] = stichwort.Substring(stichwort.IndexOf(" "));
            }

            qryKgDokumente["KgDokumentTypCode"] = 1;
            edtDokumentTyp.Focus();
        }

        private void qryKgDokumente_BeforeInsert(object sender, EventArgs e)
        {
            if (qryKgPosition.Row.RowState == DataRowState.Added)
            {
                KissMsg.ShowInfo("Ein Dokument kann erst nach dem Speichern der Position hinzugefügt werden.");
                throw new KissCancelException();
            }
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

        private void qryKgDokumente_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //qryKgPosition.RowModified = true;
        }

        private void qryKgDokumente_PostCompleted(object sender, EventArgs e)
        {
            UpdateDocCount();
            qryKgDokumente.Refresh();
        }

        private void qryKgDokumente2_BeforePost(object sender, EventArgs e)
        {
            // Eintrag wird nicht mehr benötigt
            if (!_zuweisenClicking && !_documentImporting)
            {
                throw new KissCancelException(); // alternativ: qry.cancel()
            }
            if (qryKgPosition2.Position < 0)
            {
                throw new KissCancelException("Keine Position zum Zuweisen ausgewählt.");
            }

            qryKgDokumente2["Stichwort"] = edtStichwort2.EditValue;
        }

        private void qryKgPosition_AfterDelete(object sender, EventArgs e)
        {
            grbEinnahmen.Visible = false;
        }

        private void qryKgPosition_AfterFill(object sender, EventArgs e)
        {
            lblRowCount.Text = qryKgPosition.Count.ToString();
        }

        private void qryKgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryKgPosition["KgPositionsKategorieCode"] = 3;  //Einnahmen
            qryKgPosition["KgAuszahlungsTerminCode"] = 4; //Valuta
            qryKgPosition["Doc"] = false;
            qryKgPosition["BuchungDatum"] = DateTime.Today;
            qryKgPosition["Status"] = 1;

            ctlErfassungMutation1.ShowInfo();

            qryKgPosition2.Fill(-1, -1);
            edtStichwort2.EditValue = null;

            qryKgDokumente2["DocumentID"] = null;
            if (qryKgDokumente2.Count > 0 && qryKgDokumente2.Row.RowState == DataRowState.Added)
            {
                qryKgDokumente2.RowModified = false;
                qryKgDokumente2.Cancel();
            }

            _buchungstext.LoadBuchungstext(null, false);

            grbEinnahmen.Visible = true;

            edtMandant.Focus();
        }

        private void qryKgPosition_AfterPost(object sender, EventArgs e)
        {
            //Save ValutaDatum in KgPositionValuta
            DBUtil.ExecSQL(@"
                DELETE KgPositionValuta where KGPOSITIONID = {0}
                INSERT KgPositionValuta (KgPositionID,Datum) VALUES ({0},{1})",
                qryKgPosition["KgPositionID"],
                qryKgPosition["FaelligAm"]);

            if (Entsperrt)
            {
                if (_buchungDatumAnpassen)
                {
                    KgBuchungshelper.buchungsDatumAnpassen((int)qryKgPosition["KgPositionID"], null, (DateTime)edtErfassungDatum.EditValue);
                }
                if (_buchungTextAnpassen)
                {
                    KgBuchungshelper.buchungstextAnpassen((int)qryKgPosition["KgPositionID"], null, edtBuchungstext.Text);
                }
                if (_kontoNrAnpassen)
                {
                    KgBuchungshelper.kontoAnpassen((int)qryKgPosition["KgPositionID"], null, null, (string)qryKgPosition["KontoNr"]);
                }
                if (_baInsititutionIDAnpassen)
                {
                    KgBuchungshelper.debitorAnpassen((int)qryKgPosition["KgPositionID"], qryKgPosition["BaInstitutionID"] as int?);
                }
            }

            edtEntsperren.Checked = false;
        }

        private void qryKgPosition_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(@"
                delete KgPositionValuta where KgPositionID = {0}
                delete KgDokument where KgPositionID = {0}",
                qryKgPosition["KgPositionID"]);
        }

        private void qryKgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            int positionStatus = (int)qryKgPosition["Status"];

            if (positionStatus != 1)
            {
                throw new KissInfoException("nur graue Positionen können gelöscht werden!");
            }
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

            DBUtil.CheckNotNullField(edtFaelligAm, lblFaelligAm.Text);
            DBUtil.CheckNotNullField(edtDebitor, lblDebitor.Text);

            if (qryMonatsbudget.Count == 0)
            {
                throw new KissInfoException("Es gibt keine verfügbaren Budgets für diesen Mandanten!");
            }

            if ((int)qryMonatsbudget["KgBewilligungCode"] == 1)
            {
                throw new KissInfoException("in dieser Maske kann eine Einnahme nicht in ein graues Monatsbudget erfasst werden!");
            }

            qryKgPosition["KgBudgetID"] = qryMonatsbudget["KgBudgetID"];
            qryKgPosition["MA"] = Session.User.LogonName;

            ctlErfassungMutation1.SetFields();

            if (Entsperrt)
            {
                _buchungDatumAnpassen = qryKgPosition.ColumnModified("BuchungDatum");
                _buchungTextAnpassen = qryKgPosition.ColumnModified("Buchungstext");
                _kontoNrAnpassen = qryKgPosition.ColumnModified("KontoNr");
                _baInsititutionIDAnpassen = qryKgPosition.ColumnModified("BaInstitutionID");
            }
        }

        private void qryKgPosition_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Betrag" || e.Column.ColumnName == "BaPersonID")
            {
                qryKgPosition2.Fill(qryKgPosition["BaPersonID"], qryKgPosition["Betrag"]);
            }
            _documentImporting = false;
        }

        private void qryKgPosition_PositionChanged(object sender, EventArgs e)
        {
            ctlErfassungMutation1.ShowInfo();

            grbEinnahmen.Visible = (qryKgPosition.Row != null && qryKgPosition.Row.RowState == DataRowState.Added);

            int status = 0;

            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
            {
                status = (int)qryKgPosition["Status"];
            }

            _filling = true;

            switch (status)
            {
                case 0: qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
                    try
                    {
                        while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                               Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                        {
                            if (!qryMonatsbudget.Next()) break;
                        }
                    }
                    catch
                    {
                        Debugger.Break();
                    }
                    break;

                case 1: qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], null);
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

                default: qryMonatsbudget.Fill(qryKgPosition["BaPersonID"], qryKgPosition["KgBudgetID"]);
                    break;
            }
            _filling = false;

            qryKgDokumente.Fill(qryKgPosition["KgPositionID"]);
            qryKgPeriode.Fill(qryKgPosition["FaLeistungID"]);

            _buchungstext.LoadBuchungstext(qryKgPosition["KontoNr"], false);

            SetEditMode();
        }

        private void qryKgPosition_PostCompleted(object sender, EventArgs e)
        {
            //Group Box mit den betragsgleichen Einnahmen ausblenden
            grbEinnahmen.Visible = false;

            UpdateDocCount();
            //Update Anzahl Dokumente

            //automatisches Grünstellen einer grauen Einnahme in grünem Budget
            if (!DBUtil.IsEmpty(qryKgPosition["KgPositionID"]))  //nur falls Post erfolgreich
            {
                qryKgPosition["Sel"] = false;
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();

                int budgetStatus = (int)qryMonatsbudget["KgBewilligungCode"];
                if (budgetStatus == 1)
                {
                    return;  //graues Budget
                }
                int positionStatus = (int)qryKgPosition["Status"];
                if (positionStatus != 1)
                {
                    return;  //nicht graue Position
                }

                try
                {
                    Session.BeginTransaction();
                    // graue Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE spKgBudget_KgBuchung_Create {0}, {1}, {2}, 0",
                        qryMonatsbudget["KgBudgetID"],
                        qryKgPosition["KgPositionID"],
                        Session.User.UserID);
                    Session.Commit();
                }
                catch (KissCancelException ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }
                    ex.ShowMessage();
                    return;
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }
                    KissMsg.ShowError(ex.Message);
                    return;
                }
                qryKgPosition["Status"] = 2; //grün
                qryKgPosition["Sel"] = null;
                qryKgPosition.RowModified = false;
                qryKgPosition.Row.AcceptChanges();
                qryKgPosition_PositionChanged(null, null);
            }
        }

        private void qryKgPosition2_AfterFill(object sender, EventArgs e)
        {
            if (qryKgPosition2.Count == 0)
            {
                edtStichwort2.EditValue = null;
                if (qryKgDokumente2.Count > 0 && qryKgDokumente2.Row.RowState == DataRowState.Added)
                {
                    qryKgDokumente2.RowModified = false;
                    qryKgDokumente2.Cancel();
                }
                edtDokument2.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtDokument2.EditMode = EditModeType.Normal;
            }
        }

        private void qryKgPosition2_AfterPost(object sender, EventArgs e)
        {
            if (Entsperrt2)
            {
                if (_buchungTextAnpassen2)
                {
                    KgBuchungshelper.buchungstextAnpassen((int)qryKgPosition2["KgPositionID"], (int)qryKgPosition2["KgBuchungID"], edtBuchungstext2.Text);
                }
                if (_kontoNrAnpassen2)
                {
                    KgBuchungshelper.kontoAnpassen((int)qryKgPosition2["KgPositionID"], (int)qryKgPosition2["KgBuchungID"], null, (string)qryKgPosition2["KontoNr"]);
                }
                if (_baInsititutionIDAnpassen2)
                {
                    KgBuchungshelper.debitorAnpassen((int)qryKgPosition2["KgPositionID"], qryKgPosition2["BaInstitutionID"] as int?);
                }
            }

            edtEntsperren2.Checked = false;
        }

        private void qryKgPosition2_BeforePost(object sender, EventArgs e)
        {
            if (Entsperrt2)
            {
                _buchungTextAnpassen2 = qryKgPosition2.ColumnModified("Buchungstext");
                _kontoNrAnpassen2 = qryKgPosition2.ColumnModified("KontoNr");
                _baInsititutionIDAnpassen2 = qryKgPosition2.ColumnModified("BaInstitutionID");
            }
        }

        private void qryKgPosition2_PositionChanged(object sender, EventArgs e)
        {
            edtStichwort2.EditValue = qryKgPosition2["KontoBez"];

            if (qryKgPosition2.Position >= 0)
            {
                edtDokument2.EditMode = EditModeType.Normal;
                if (qryKgDokumente2.Count == 0)
                    qryKgDokumente2.Insert();
                qryKgDokumente2["KgPositionID"] = qryKgPosition2["KgPositionID"];
                qryKgDokumente2["KgDokumentTypCode"] = 1;
                qryKgDokumente2["Stichwort"] = edtStichwort2.EditValue;
            }
            else
            {
                // Eintrag wird nicht mehr benötigt
                if (qryKgDokumente2.Count > 0 && qryKgDokumente2.Row.RowState == DataRowState.Added)
                {
                    qryKgDokumente2.RowModified = false;
                    qryKgDokumente2.Cancel();
                }
                edtDokument2.EditMode = EditModeType.ReadOnly;
            }
            edtEntsperren2.Checked = false;
            SetEditMode();
        }

        private void qryMonatsbudget_PositionChanged(object sender, EventArgs e)
        {
            if (_filling) return;
            qryKgPosition.RowModified = true;
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            btnAlle.Visible = (page == tpgListe);
            btnKeine.Visible = (page == tpgListe);
            btnPositionenLoeschen.Visible = (page == tpgListe);
        }

        private void tabKgPosition_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
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

        public override bool OnKeyDownKiss(KeyEventArgs e)
        {
            var keys = DBUtil.GetConfigShortcut(@"System\Allgemein\NeuesDokumentShortcut", "Control+N");

            if (e.KeyData == keys.KeyData)
            {
                DocumentImport();
            }

            return base.OnKeyDownKiss(e);
        }

        public override bool OnSaveData()
        {
            if (tabKgPosition.SelectedTab == tpgDokumente)
            {
                return qryKgDokumente.Post();
            }

            if (qryKgPosition.Count == 0)
            {
                return true;
            }

            bool ok = qryKgPosition.Post();

            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
            {
                int positionStatus = (int)qryKgPosition["Status"];

                if (positionStatus == 1) //falls keine Änderung am Datensatz und Position immer noch grau
                {
                    qryKgPosition_PostCompleted(null, null);
                }
            }

            if (qryKgPosition2.CanUpdate)
            {
                edtEntsperren2.Checked = false;
                qryKgPosition2.Row.AcceptChanges();
                qryKgPosition2.RowModified = false;
                qryKgPosition2.CanUpdate = false;
                qryKgPosition2.Refresh();
            }

            return ok;
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

        private void PresetSearchFields()
        {
            edtSucheErfassungMA.LookupID = Session.User.UserID;
            edtSucheErfassungMA.EditValue = Session.User.LogonName;
            edtSucheErfassungVon.EditValue = DateTime.Today;
            edtSucheErfassungBis.EditValue = DateTime.Today;
            edtSucheStatus.EditValue = 2;
        }

        /// <summary>
        /// (De-)selects all entries
        /// </summary>
        /// <param name="select">Selects all if true, deselects all if false</param>
        private void SelectAllOrNothing(bool select)
        {
            // zuerst speichern, damit wir nach der Selektionsänderung die Zeile als unverändert markieren können
            if (!qryKgPosition.Post())
            {
                return;
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (DataRow row in qryKgPosition.DataTable.Rows)
                {
                    if (DBUtil.IsEmpty(row["MaxBuchungStatusCode"]))
                    {
                        row["Sel"] = select;
                        row.AcceptChanges();
                    }
                }
                qryKgPosition.RowModified = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetEditMode()
        {
            edtBuchungstext2.EditMode = EditModeType.ReadOnly;
            edtKonto2.EditMode = EditModeType.ReadOnly;
            edtDebitor2.EditMode = EditModeType.ReadOnly;
            qryKgPosition2.CanUpdate = false;
            btnAenderungenUebernehmen2.Enabled = false;
            int? positionsStatus = qryKgPosition["Status"] as int?;
            int? positionsStatus2 = qryKgPosition2["Status"] as int?;
            int? kgPeriodeStatusCode = qryKgPosition["KgPeriodeStatusCode"] as int?;
            int? kgPeriodeStatusCode2 = qryKgPosition2["KgPeriodeStatusCode"] as int?;
            int status = 0;
            if (!DBUtil.IsEmpty(qryKgPosition["Status"]))
            {
                status = (int)qryKgPosition["Status"];
            }

            bool editable = (status <= 1);

            qryKgPosition.EnableBoundFields(editable);

            bool nachtraeglichAendernErlaubt =
                positionsStatus.HasValue &&
                (
                    positionsStatus.Value == 3 || /*ZahlauftragErstellt*/
                //PositionStatus.Value == 4 || /*ausgedruckt*/
                    positionsStatus.Value == 5 || /*ZahlauftragFehlerhaft*/
                    positionsStatus.Value == 6 || /*ausgeglichen*/
                //PositionStatus.Value == 7 || /*gesperrt*/
                    positionsStatus.Value == 9 || /*Rückläufer*/
                    positionsStatus.Value == 10 || /*teilweise ausgeglichen*/
                    positionsStatus.Value == 11 || /*Barbezug*/
                    positionsStatus.Value == 16)   /*Rückläufer korrigiert*/
                    && DBUtil.UserHasRight("CtlKgBudget_BuchungenAendern")
                    && (kgPeriodeStatusCode.HasValue && kgPeriodeStatusCode.Value <= 1);

            edtEntsperren.Visible = nachtraeglichAendernErlaubt;

            if (nachtraeglichAendernErlaubt && edtEntsperren.Checked)
            {
                qryKgPosition.CanUpdate = true;
                edtErfassungDatum.EditMode = EditModeType.Normal;
                edtBuchungstext.EditMode = EditModeType.Normal;
                edtKonto.EditMode = EditModeType.Normal;
                edtDebitor.EditMode = EditModeType.Normal;
            }
            btnPositionGrau.Visible = positionsStatus.HasValue && (positionsStatus.Value == 2 || positionsStatus.Value == 5);

            bool nachtraeglichAendernErlaubt2 =
                positionsStatus2.HasValue &&
                (
                    positionsStatus2.Value == 3 || /*ZahlauftragErstellt*/
                //PositionStatus2.Value == 4 || /*ausgedruckt*/
                    positionsStatus2.Value == 5 || /*ZahlauftragFehlerhaft*/
                    positionsStatus2.Value == 6 || /*ausgeglichen*/
                //PositionStatus2.Value == 7 || /*gesperrt*/
                    positionsStatus2.Value == 9 || /*Rückläufer*/
                    positionsStatus2.Value == 10 || /*teilweise ausgeglichen*/
                    positionsStatus2.Value == 11 || /*Barbezug*/
                    positionsStatus2.Value == 16)   /*Rückläufer korrigiert*/
                    && DBUtil.UserHasRight("CtlKgBudget_BuchungenAendern")
                    && (kgPeriodeStatusCode2.HasValue && kgPeriodeStatusCode2.Value <= 1);
            if (nachtraeglichAendernErlaubt2 && edtEntsperren2.Checked)
            {
                qryKgPosition2.CanUpdate = true;
                edtKonto2.EditMode = EditModeType.Normal;
                edtBuchungstext2.EditMode = EditModeType.Normal;
                edtDebitor2.EditMode = EditModeType.Normal;
                btnAenderungenUebernehmen2.Enabled = true;
            }

            edtEntsperren2.Visible = nachtraeglichAendernErlaubt2;
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

        private void UserModifiedFld(SqlQuery qry, string searchString, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qry["BaInstitutionID"] = DBNull.Value;
                    qry["Debitor"] = DBNull.Value;
                    qry["ZusatzInfo"] = DBNull.Value;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.Adresse,
                     Typ                 = INS.Typ
              FROM   vwInstitution INS
              WHERE  INS.BaFreigabeStatusCode = 2 AND
                     INS.Name LIKE '%' + {0} + '%' AND
                     INS.Debitor = 1
              ORDER BY INS.Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qry["BaInstitutionID"] = dlg["ID$"];
                qry["Debitor"] = dlg["Institution"];
                qry["ZusatzInfo"] = dlg["Adresse"];
            }
        }

        #endregion Private Methods

        private void tpgEinzelzahlung_PropertyChanged(SharpLibrary.WinControls.TabPageEx page, SharpLibrary.WinControls.TabPageExProperty property)
        {
        }

        #endregion Methods
    }
}