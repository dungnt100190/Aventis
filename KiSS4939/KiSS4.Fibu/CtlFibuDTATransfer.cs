using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Defines the FiBu UserControl for DTA Transfer.
    /// </summary>
    public class CtlFibuDTATransfer : KiSS4.Gui.KissUserControl
    {
        private KiSS4.Gui.KissButton btnAlleAuswaehlen;
        private KiSS4.Gui.KissButton btnAlleEntfernen;
        private KiSS4.Gui.KissButton btnBezahlt;
        private KiSS4.Gui.KissButton btnFehlerhaft;
        private KiSS4.Gui.KissLookUpEdit cboErsteller;
        private KiSS4.Gui.KissLookUpEdit cboEZugang;
        private KiSS4.Gui.KissLookUpEdit cboStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAuswaehlen;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colErsteller;
        private DevExpress.XtraGrid.Columns.GridColumn colJournalStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCanEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsgrund;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit editBelegNr;
        private KiSS4.Gui.KissCalcEdit editBetrag;
        private KiSS4.Gui.KissButtonEdit editMandantSearch;
        private KiSS4.Gui.KissDateEdit editTransferDatumBisX;
        private KiSS4.Gui.KissDateEdit editTransferDatumVonX;
        private KiSS4.Gui.KissDateEdit editValutaDatumBis;
        private KiSS4.Gui.KissDateEdit editValutaDatumVon;
        private KiSS4.Gui.KissGrid grdFbDTABuchung;
        private KiSS4.Gui.KissGrid grdFbDTAJournal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbDTABuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbDTAJournal;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblBank;
        private KiSS4.Gui.KissLabel lblFilePath;
        private KiSS4.Gui.KissLabel lblPostKontoNr;
        private int MandantSearchId;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.DB.SqlQuery qryFbDTABuchung;
        private KiSS4.DB.SqlQuery qryFbDTAJournal;
        private KiSS4.DB.SqlQuery qryZuUebermitteln;

        private string sql_Buchungen_Joins = @"
              LEFT  JOIN FbDTABuchung FDB ON FDJ.FbDTAJournalID = FDB.FbDTAJournalID
              INNER JOIN FbBuchung FBB ON FBB.FbBuchungID = FDB.FbBuchungID
              INNER JOIN FbPeriode FBP ON FBP.FbPeriodeID = FBB.FbPeriodeID ";

        private string sqlDTATransferedSearch = @"
			SELECT	DISTINCT FDJ.FbDTAJournalID, FDJ.FbDTAZugangID, FDJ.FilePath, FDJ.TotalBetrag, FDJ.TransferDatum,
					Name =  CASE WHEN FDZ.FbDTAZugangID IS NULL
							THEN (SELECT TOP 1 Z.VertragNr
								  from	 FbDTABuchung            D
										 INNER JOIN FbBuchung    B ON B.FbBuchungID = D.FbBuchungID
										 INNER JOIN FbKonto      K ON B.HabenKtoNr = K.KontoNr and B.FbPeriodeID = K.FbPeriodeID
										 INNER JOIN FbDtaZugang  Z ON Z.FbDTAZugangID = K.FbDTAZugangID
								  WHERE  D.FbDTAJournalID = FDJ.FbDTAJournalID)
							ELSE FDZ.Name
							END,
					FDZ.VertragNr, FDZ.VertragNr, FDZ.KontoNr, FDZ.BaBankID,
					Ersteller     = USR.Firstname + ' ' + USR.Lastname,
					JournalStatus = CASE
									  WHEN EXISTS (SELECT * FROM FbDTABuchung WHERE FbDTAJournalID = FDJ.FbDTAJournalID AND Status = 2) THEN 'pendent'
									  WHEN EXISTS (SELECT * FROM FbDTABuchung WHERE FbDTAJournalID = FDJ.FbDTAJournalID AND Status = 4) THEN 'abgeschlossen mit Fehler'
									  ELSE 'abgeschlossen ohne Fehler'
									END,
					ValutaDatum   = (SELECT MIN(ValutaDatum)
									 FROM FbBuchung
			                           INNER JOIN FbDTABuchung ON FbBuchung.FbBuchungID = FbDTABuchung.FbBuchungID
			                         WHERE FbDTABuchung.FbDTAJournalID = FDJ.FbDTAJournalID)
			FROM	     FbDTAJournal FDJ
			  LEFT  JOIN FbDTAZugang  FDZ ON FDJ.FbDTAZugangID  = FDZ.FbDTAZugangID
			  INNER JOIN XUser        USR ON FDJ.UserID         = USR.UserID ";

        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuDTATransfer"/> class.
        /// </summary>
        public CtlFibuDTATransfer()
        {
            // --- Required for Windows Form Designer support
            InitializeComponent();

            colValutaDatum.Visible = false;

            this.grdFbDTAJournal.View.Columns["KontoNr"].DisplayFormat.Format =
                new GridColumnPCKontoFormatter();
            this.colStatus.ColumnEdit =
                this.grdFbDTABuchung.GetLOVLookUpEdit("FbBuchungDTAStatus");

            SqlQuery ezugang = DBUtil.OpenSQL(@"
				SELECT DISTINCT FbDTAZugangID, Name, KontoNr, '' AS Text
				FROM FbDTAZugang
				UNION SELECT 0, NULL, NULL, NULL");

            foreach (DataRow dr in ezugang.DataTable.Rows)
            {
                if (dr["Name"] != DBNull.Value)
                {
                    dr["Text"] = dr["Name"].ToString() + " - " + Utils.FormatPCKontoNummerToUserFormat(dr["KontoNr"].ToString());
                    dr.AcceptChanges();
                }
            }

            cboEZugang.LoadQuery(ezugang, "FbDTAZugangID", "Text");

            cboErsteller.LoadQuery(
                DBUtil.OpenSQL(@"
					SELECT UserID,
					  Ersteller = FirstName + ' ' + Lastname
					FROM XUser
					WHERE UserID IN (SELECT DISTINCT UserID FROM FbDTAJournal)
					UNION SELECT 0, NULL
					ORDER BY 2"),
                "UserID", "Ersteller");

            cboStatus.LoadQuery(
                DBUtil.OpenSQL("SELECT * FROM XLOVCode WHERE LOVName = 'FbBuchungDTAStatus' AND CODE <> {0}", (int)BuchungDTAStatus.Generiert),
                "Code", "Text");

            this.tabControlSearch.SelectedTabIndex = tabControlSearch.TabPages.IndexOf(this.tpgSuchen);

            SetupGrid();
        }

        /// <summary>
        /// Gets the name of this context.
        /// </summary>
        /// <returns></returns>
        public override string GetContextName()
        {
            return "VmFibu";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Handles the Click event of the btnAlle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAlle_Click(
            object sender,
            System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qryFbDTABuchung.First();
                do
                {
                    int FbDTAJournalID = (int)DBUtil.ExecuteScalarSQL(@"
						SELECT	MAX(FbDTAJournalID)
						FROM	FbDTABuchung
						WHERE	FbBuchungID = {0}",
                        qryFbDTABuchung["FbBuchungID"]);

                    if (FbDTAJournalID == (int)(qryFbDTABuchung["FbDTAJournalID"]))
                    {
                        qryFbDTABuchung["Auswaehlen"] = (sender == btnAlleAuswaehlen);
                        qryFbDTABuchung.Row.AcceptChanges();
                    }
                } while (qryFbDTABuchung.Next());

                qryFbDTABuchung.RefreshDisplay();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    "CtlFibuDTATransfer",
                    "FehlerAuswaehlenEntfernen",
                    "Beim Auswählen/Entfernen aller Buchungen ist ein Fehler aufgetreten",
                    ex);
            }
            finally
            {
                // --- reset the cursor.
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnBezahltFehlerhaft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnBezahltFehlerhaft_Click(
            object sender,
            System.EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qryFbDTABuchung.First();

                do
                {
                    if (Convert.ToBoolean(qryFbDTABuchung.Row["Auswaehlen"]) == true)
                    {
                        if (sender == btnBezahlt)
                            qryFbDTABuchung["Status"] = BuchungDTAStatus.Bezahlt;
                        else
                            qryFbDTABuchung["Status"] = BuchungDTAStatus.Fehlerhaft;

                        qryFbDTABuchung.Post();
                    }
                } while (qryFbDTABuchung.Next());
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlFibuDTATransfer", "FehlerSetzenStati", "Beim Setzen der Stati aller ausgewählten Zeilen ist ein Fehler aufgetreten", ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCopyPfad control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCopyPfad_Click(
            object sender,
            System.EventArgs e)
        {
            Clipboard.SetDataObject(this.qryZuUebermitteln["FilePath"].ToString(), true);
        }

        /// <summary>
        /// Handles the Load event of the CtlFibuDTATransfer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuDTATransfer_Load(
            object sender,
            System.EventArgs e)
        {
            //qryFbDTAJournal.Fill(sqlDTATransfered);
            //qryFbDTAJournal.Last();
        }

        /// <summary>
        /// Handles the Search event of the CtlFibuDTATransfer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuDTATransfer_Search(
            object sender,
            System.EventArgs e)
        {
            if (this.tabControlSearch.SelectedTabIndex == 0)
            {
                if (this.ActiveSQLQuery.Post())
                {
                    this.tabControlSearch.SelectedTabIndex = 1;
                    NeueSuche();
                }
            }
            else
            {
                Suchen();
            }
        }

        /// <summary>
        /// Handles the UserModifiedFld event of the editMandantSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KiSS4.Gui.UserModifiedFldEventArgs"/> instance containing the event data.</param>
        private void editMandantSearch_UserModifiedFld(
            object sender,
            KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            if (editMandantSearch.Text == "")
            {
                this.MandantSearchId = 0;
                e.Cancel = true;
                return;
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(editMandantSearch.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                this.MandantSearchId = (int)dlg["BaPersonID"];
                editMandantSearch.Text = dlg["Mandant"].ToString();
            }
        }

        /// <summary>
        /// Handles the Enter event of the gridDTABuchungen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void gridDTABuchungen_Enter(
            object sender,
            System.EventArgs e)
        {
            this.ActiveSQLQuery = qryFbDTABuchung;
        }

        /// <summary>
        /// Handles the Enter event of the gridDTAJournalTransfered control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void gridDTAJournalTransfered_Enter(
            object sender,
            System.EventArgs e)
        {
            this.ActiveSQLQuery = qryFbDTAJournal;
        }

        /// <summary>
        /// Starts a new search.
        /// </summary>
        private void NeueSuche()
        {
            this.cboEZugang.EditValue = DBNull.Value;
            this.cboErsteller.EditValue = DBNull.Value;
            this.editTransferDatumBisX.EditValue = DBNull.Value;
            this.editTransferDatumVonX.EditValue = DBNull.Value;
            this.editValutaDatumBis.EditValue = DBNull.Value;
            this.editValutaDatumVon.EditValue = DBNull.Value;
            this.editBelegNr.EditValue = DBNull.Value;
            this.editMandantSearch.EditValue = DBNull.Value;
            this.cboStatus.EditValue = DBNull.Value;
            this.editBetrag.EditValue = DBNull.Value;
            this.cboEZugang.Focus();
        }

        /// <summary>
        /// Handles the AfterFill event of the qryDTATransfered control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFbDTAJournal_AfterFill(
            object sender,
            System.EventArgs e)
        {
            if (this.qryFbDTAJournal.Count == 0)
            {
                qryFbDTABuchung.Fill(DBNull.Value);
            }
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryDTATransfer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryFbDTAJournal_PositionChanged(
            object sender,
            System.EventArgs e)
        {
            if (qryFbDTAJournal.Count > 0)
            {
                bool dta = qryFbDTAJournal["BaBankID"] is int;
                colValuta.Visible = !dta;
                colBuchungsdatum.Visible = !dta;
                colValutaDatum.Visible = dta;

                qryFbDTABuchung.Fill(qryFbDTAJournal["FbDTAJournalID"]);
            }
        }

        /// <summary>
        /// Handles the Click event of the repositoryItemCheckEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void repositoryItemCheckEdit1_Click(
            object sender,
            System.EventArgs e)
        {
            // Check if user is trying to modify the status of a "Buchung" which exists in a more recent "DTAAuftrag"
            // User can only modify the status of the buchung in the last DTAJOurnal
            int LastJournalId = Convert.ToInt32(DBUtil.ExecuteScalarSQL("SELECT MAX(FbDTAJournalID) from FbDTABuchung WHERE FbBuchungID = {0}", qryFbDTABuchung["FbBuchungID"]));

            if (LastJournalId != Convert.ToInt32(qryFbDTABuchung["FbDTAJournalID"]))
            {
                KissMsg.ShowInfo("CtlFibuDTATransfer", "StatusAendernNichtMoeglich", "Status für diese Buchung kann nicht geändert werden, weil sie bereits in einem neueren Zahlungslauf steht");
                return;
            }
            else
            {
                qryFbDTABuchung.Row.AcceptChanges();
            }
        }

        /// <summary>
        /// Handles the CloseUp event of the repositoryItemLookUpEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.CloseUpEventArgs"/> instance containing the event data.</param>
        private void repositoryItemLookUpEdit1_CloseUp(
            object sender,
            DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            this.qryFbDTABuchung.Row.EndEdit();
        }

        private void SetupColumn(GridColumn gridColumn, bool editable)
        {
            var backColor = editable ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;

            gridColumn.AppearanceCell.BackColor = backColor;
            gridColumn.AppearanceCell.Options.UseBackColor = true;

            gridColumn.OptionsColumn.AllowEdit = editable;
            gridColumn.OptionsColumn.AllowFocus = editable;
            gridColumn.OptionsColumn.ReadOnly = !editable;
        }

        private void SetupGrid()
        {
            SetupColumn(colMandant, false);
            SetupColumn(colKontoNr, false);
            SetupColumn(colBuchungsdatum, false);
            SetupColumn(colValutaDatum, false);
            SetupColumn(colBetrag, false);
            SetupColumn(colBelegNr, false);
            SetupColumn(colKreditor, false);
            SetupColumn(colZahlungsgrund, false);
            SetupColumn(colStatus, false);
            SetupColumn(colAuswaehlen, true);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuDTATransfer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colStatusCanEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryFbDTABuchung = new KiSS4.DB.SqlQuery(this.components);
            this.qryFbDTAJournal = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAlleEntfernen = new KiSS4.Gui.KissButton();
            this.lblFilePath = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.grdFbDTAJournal = new KiSS4.Gui.KissGrid();
            this.grvFbDTAJournal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJournalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdFbDTABuchung = new KiSS4.Gui.KissGrid();
            this.grvFbDTABuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuswaehlen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBezahlt = new KiSS4.Gui.KissButton();
            this.btnAlleAuswaehlen = new KiSS4.Gui.KissButton();
            this.btnFehlerhaft = new KiSS4.Gui.KissButton();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.editBelegNr = new KiSS4.Gui.KissTextEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.cboErsteller = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.editValutaDatumVon = new KiSS4.Gui.KissDateEdit();
            this.editValutaDatumBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.lblPostKontoNr = new KiSS4.Gui.KissLabel();
            this.cboStatus = new KiSS4.Gui.KissLookUpEdit();
            this.editBetrag = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.cboEZugang = new KiSS4.Gui.KissLookUpEdit();
            this.editTransferDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.editTransferDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblBank = new KiSS4.Gui.KissLabel();
            this.editMandantSearch = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.qryZuUebermitteln = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTABuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAJournal)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTAJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTAJournal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTABuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTABuchung)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErsteller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErsteller.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editValutaDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editValutaDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuUebermitteln)).BeginInit();
            this.SuspendLayout();
            //
            // colStatusCanEdit
            //
            this.colStatusCanEdit.Caption = "colStatusCanEdit";
            this.colStatusCanEdit.FieldName = "DTAStatusEdit";
            this.colStatusCanEdit.Name = "colStatusCanEdit";
            this.colStatusCanEdit.OptionsColumn.AllowEdit = false;
            this.colStatusCanEdit.OptionsColumn.ReadOnly = true;
            //
            // qryFbDTABuchung
            //
            this.qryFbDTABuchung.CanUpdate = true;
            this.qryFbDTABuchung.HostControl = this;
            this.qryFbDTABuchung.IsIdentityInsert = false;
            this.qryFbDTABuchung.FillTimeOut = 120;
            this.qryFbDTABuchung.SelectStatement = "SELECT *,\r\n  Auswaehlen = CONVERT(bit, 0)\r\nFROM viewDTAFbBuchungen\r\nWHERE FbDTAJo" +
    "urnalID = {0}";
            this.qryFbDTABuchung.TableName = "FbDTABuchung";
            //
            // qryFbDTAJournal
            //
            this.qryFbDTAJournal.CanUpdate = true;
            this.qryFbDTAJournal.HostControl = this;
            this.qryFbDTAJournal.IsIdentityInsert = false;
            this.qryFbDTAJournal.FillTimeOut = 120;
            this.qryFbDTAJournal.TableName = "FbDTAJournal";
            this.qryFbDTAJournal.AfterFill += new System.EventHandler(this.qryFbDTAJournal_AfterFill);
            this.qryFbDTAJournal.PositionChanged += new System.EventHandler(this.qryFbDTAJournal_PositionChanged);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(830, 545);
            this.tabControlSearch.TabIndex = 18;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.xTabControl1_SelectedTabChanged);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.panel3);
            this.tpgListe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(818, 507);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            //
            // panel3
            //
            this.panel3.Controls.Add(this.btnAlleEntfernen);
            this.panel3.Controls.Add(this.lblFilePath);
            this.panel3.Controls.Add(this.kissLabel13);
            this.panel3.Controls.Add(this.kissLabel12);
            this.panel3.Controls.Add(this.kissLabel9);
            this.panel3.Controls.Add(this.grdFbDTAJournal);
            this.panel3.Controls.Add(this.grdFbDTABuchung);
            this.panel3.Controls.Add(this.btnBezahlt);
            this.panel3.Controls.Add(this.btnAlleAuswaehlen);
            this.panel3.Controls.Add(this.btnFehlerhaft);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(818, 507);
            this.panel3.TabIndex = 21;
            //
            // btnAlleEntfernen
            //
            this.btnAlleEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleEntfernen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAlleEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleEntfernen.Location = new System.Drawing.Point(437, 479);
            this.btnAlleEntfernen.Name = "btnAlleEntfernen";
            this.btnAlleEntfernen.Size = new System.Drawing.Size(125, 24);
            this.btnAlleEntfernen.TabIndex = 3;
            this.btnAlleEntfernen.Text = "Alle entfernen";
            this.btnAlleEntfernen.UseVisualStyleBackColor = false;
            this.btnAlleEntfernen.Click += new System.EventHandler(this.btnAlle_Click);
            //
            // lblFilePath
            //
            this.lblFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilePath.DataMember = "FilePath";
            this.lblFilePath.DataSource = this.qryFbDTAJournal;
            this.lblFilePath.Location = new System.Drawing.Point(308, 200);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(499, 24);
            this.lblFilePath.TabIndex = 29;
            //
            // kissLabel13
            //
            this.kissLabel13.Location = new System.Drawing.Point(265, 200);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(40, 24);
            this.kissLabel13.TabIndex = 28;
            this.kissLabel13.Text = "Datei";
            //
            // kissLabel12
            //
            this.kissLabel12.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel12.Location = new System.Drawing.Point(5, 224);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(84, 16);
            this.kissLabel12.TabIndex = 27;
            this.kissLabel12.Text = "Buchungen";
            //
            // kissLabel9
            //
            this.kissLabel9.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel9.Location = new System.Drawing.Point(5, 4);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(256, 16);
            this.kissLabel9.TabIndex = 26;
            this.kissLabel9.Text = "Übermittelte Zahlungsläufe";
            //
            // grdFbDTAJournal
            //
            this.grdFbDTAJournal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbDTAJournal.DataSource = this.qryFbDTAJournal;
            //
            //
            //
            this.grdFbDTAJournal.EmbeddedNavigator.Name = "";
            this.grdFbDTAJournal.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbDTAJournal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbDTAJournal.Location = new System.Drawing.Point(5, 24);
            this.grdFbDTAJournal.MainView = this.grvFbDTAJournal;
            this.grdFbDTAJournal.Name = "grdFbDTAJournal";
            this.grdFbDTAJournal.Size = new System.Drawing.Size(806, 176);
            this.grdFbDTAJournal.TabIndex = 0;
            this.grdFbDTAJournal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbDTAJournal});
            //
            // grvFbDTAJournal
            //
            this.grvFbDTAJournal.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbDTAJournal.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.Empty.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbDTAJournal.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDTAJournal.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbDTAJournal.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbDTAJournal.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDTAJournal.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbDTAJournal.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbDTAJournal.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAJournal.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDTAJournal.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbDTAJournal.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAJournal.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAJournal.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTAJournal.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTAJournal.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbDTAJournal.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbDTAJournal.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbDTAJournal.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTAJournal.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbDTAJournal.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbDTAJournal.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTAJournal.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbDTAJournal.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDTAJournal.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbDTAJournal.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.OddRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDTAJournal.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.Row.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.Row.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbDTAJournal.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAJournal.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbDTAJournal.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbDTAJournal.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbDTAJournal.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbDTAJournal.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDTAJournal.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbDTAJournal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbDTAJournal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colTransferDatum,
            this.colValuta,
            this.colErsteller,
            this.gridColumn7,
            this.colTotalBetrag,
            this.colJournalStatus});
            this.grvFbDTAJournal.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbDTAJournal.GridControl = this.grdFbDTAJournal;
            this.grvFbDTAJournal.Name = "grvFbDTAJournal";
            this.grvFbDTAJournal.OptionsBehavior.Editable = false;
            this.grvFbDTAJournal.OptionsCustomization.AllowFilter = false;
            this.grvFbDTAJournal.OptionsCustomization.AllowGroup = false;
            this.grvFbDTAJournal.OptionsFilter.AllowFilterEditor = false;
            this.grvFbDTAJournal.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbDTAJournal.OptionsMenu.EnableColumnMenu = false;
            this.grvFbDTAJournal.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbDTAJournal.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbDTAJournal.OptionsNavigation.UseTabKey = false;
            this.grvFbDTAJournal.OptionsView.ColumnAutoWidth = false;
            this.grvFbDTAJournal.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbDTAJournal.OptionsView.ShowGroupPanel = false;
            this.grvFbDTAJournal.OptionsView.ShowIndicator = false;
            //
            // colName
            //
            this.colName.Caption = "E-Zugang Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 153;
            //
            // colTransferDatum
            //
            this.colTransferDatum.Caption = "Transfer";
            this.colTransferDatum.FieldName = "TransferDatum";
            this.colTransferDatum.Name = "colTransferDatum";
            this.colTransferDatum.Visible = true;
            this.colTransferDatum.VisibleIndex = 1;
            //
            // colValuta
            //
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 2;
            //
            // colErsteller
            //
            this.colErsteller.Caption = "Ersteller";
            this.colErsteller.FieldName = "Ersteller";
            this.colErsteller.Name = "colErsteller";
            this.colErsteller.Visible = true;
            this.colErsteller.VisibleIndex = 3;
            this.colErsteller.Width = 143;
            //
            // gridColumn7
            //
            this.gridColumn7.Caption = "Konto Nr";
            this.gridColumn7.FieldName = "KontoNr";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 124;
            //
            // colTotalBetrag
            //
            this.colTotalBetrag.Caption = "Total Betrag";
            this.colTotalBetrag.DisplayFormat.FormatString = "N2";
            this.colTotalBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalBetrag.FieldName = "TotalBetrag";
            this.colTotalBetrag.Name = "colTotalBetrag";
            this.colTotalBetrag.Visible = true;
            this.colTotalBetrag.VisibleIndex = 5;
            this.colTotalBetrag.Width = 101;
            //
            // colJournalStatus
            //
            this.colJournalStatus.Caption = "Status";
            this.colJournalStatus.FieldName = "JournalStatus";
            this.colJournalStatus.Name = "colJournalStatus";
            this.colJournalStatus.Visible = true;
            this.colJournalStatus.VisibleIndex = 6;
            this.colJournalStatus.Width = 189;
            //
            // grdFbDTABuchung
            //
            this.grdFbDTABuchung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbDTABuchung.DataSource = this.qryFbDTABuchung;
            //
            //
            //
            this.grdFbDTABuchung.EmbeddedNavigator.Name = "";
            this.grdFbDTABuchung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdFbDTABuchung.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbDTABuchung.Location = new System.Drawing.Point(5, 248);
            this.grdFbDTABuchung.MainView = this.grvFbDTABuchung;
            this.grdFbDTABuchung.Name = "grdFbDTABuchung";
            this.grdFbDTABuchung.Size = new System.Drawing.Size(806, 222);
            this.grdFbDTABuchung.TabIndex = 1;
            this.grdFbDTABuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbDTABuchung});
            //
            // grvFbDTABuchung
            //
            this.grvFbDTABuchung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbDTABuchung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.Empty.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvFbDTABuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbDTABuchung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbDTABuchung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbDTABuchung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTABuchung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDTABuchung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbDTABuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTABuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTABuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTABuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTABuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbDTABuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbDTABuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbDTABuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTABuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbDTABuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTABuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbDTABuchung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbDTABuchung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbDTABuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.Row.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvFbDTABuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTABuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbDTABuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbDTABuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbDTABuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbDTABuchung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvFbDTABuchung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbDTABuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbDTABuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMandant,
            this.colKontoNr,
            this.colBuchungsdatum,
            this.colValutaDatum,
            this.colBetrag,
            this.colBelegNr,
            this.colKreditor,
            this.colZahlungsgrund,
            this.colStatus,
            this.colAuswaehlen,
            this.colStatusCanEdit});
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Gray;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colStatusCanEdit;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = 0;
            this.grvFbDTABuchung.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
            this.grvFbDTABuchung.GridControl = this.grdFbDTABuchung;
            this.grvFbDTABuchung.Name = "grvFbDTABuchung";
            this.grvFbDTABuchung.OptionsCustomization.AllowFilter = false;
            this.grvFbDTABuchung.OptionsCustomization.AllowGroup = false;
            this.grvFbDTABuchung.OptionsFilter.AllowFilterEditor = false;
            this.grvFbDTABuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbDTABuchung.OptionsMenu.EnableColumnMenu = false;
            this.grvFbDTABuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbDTABuchung.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbDTABuchung.OptionsView.ColumnAutoWidth = false;
            this.grvFbDTABuchung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbDTABuchung.OptionsView.ShowGroupPanel = false;
            //
            // colMandant
            //
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.OptionsColumn.ReadOnly = true;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 0;
            this.colMandant.Width = 89;
            //
            // colKontoNr
            //
            this.colKontoNr.Caption = "Kto-Nr.";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.OptionsColumn.AllowEdit = false;
            this.colKontoNr.OptionsColumn.ReadOnly = true;
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 1;
            this.colKontoNr.Width = 56;
            //
            // colBuchungsdatum
            //
            this.colBuchungsdatum.Caption = "Datum";
            this.colBuchungsdatum.FieldName = "Buchungsdatum";
            this.colBuchungsdatum.Name = "colBuchungsdatum";
            this.colBuchungsdatum.OptionsColumn.AllowEdit = false;
            this.colBuchungsdatum.OptionsColumn.ReadOnly = true;
            this.colBuchungsdatum.Visible = true;
            this.colBuchungsdatum.VisibleIndex = 2;
            //
            // colValutaDatum
            //
            this.colValutaDatum.Caption = "Valuta";
            this.colValutaDatum.FieldName = "ValutaDatum";
            this.colValutaDatum.Name = "colValutaDatum";
            this.colValutaDatum.OptionsColumn.AllowEdit = false;
            this.colValutaDatum.OptionsColumn.ReadOnly = true;
            this.colValutaDatum.Visible = true;
            this.colValutaDatum.VisibleIndex = 3;
            this.colValutaDatum.Width = 72;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.OptionsColumn.ReadOnly = true;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 67;
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "Beleg Nr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.AllowEdit = false;
            this.colBelegNr.OptionsColumn.ReadOnly = true;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 5;
            //
            // colKreditor
            //
            this.colKreditor.Caption = "Beguenstigter";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.OptionsColumn.ReadOnly = true;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 6;
            this.colKreditor.Width = 145;
            //
            // colZahlungsgrund
            //
            this.colZahlungsgrund.Caption = "Zahlungsgrund";
            this.colZahlungsgrund.FieldName = "Zahlungsgrund";
            this.colZahlungsgrund.Name = "colZahlungsgrund";
            this.colZahlungsgrund.OptionsColumn.AllowEdit = false;
            this.colZahlungsgrund.OptionsColumn.ReadOnly = true;
            this.colZahlungsgrund.Visible = true;
            this.colZahlungsgrund.VisibleIndex = 7;
            this.colZahlungsgrund.Width = 156;
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.ReadOnly = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            this.colStatus.Width = 94;
            //
            // colAuswaehlen
            //
            this.colAuswaehlen.Caption = "ausg.";
            this.colAuswaehlen.FieldName = "Auswaehlen";
            this.colAuswaehlen.Name = "colAuswaehlen";
            this.colAuswaehlen.Visible = true;
            this.colAuswaehlen.VisibleIndex = 9;
            this.colAuswaehlen.Width = 41;
            //
            // btnBezahlt
            //
            this.btnBezahlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBezahlt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBezahlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBezahlt.Location = new System.Drawing.Point(580, 479);
            this.btnBezahlt.Name = "btnBezahlt";
            this.btnBezahlt.Size = new System.Drawing.Size(110, 24);
            this.btnBezahlt.TabIndex = 4;
            this.btnBezahlt.Text = "Bezahlt";
            this.btnBezahlt.UseVisualStyleBackColor = false;
            this.btnBezahlt.Click += new System.EventHandler(this.btnBezahltFehlerhaft_Click);
            //
            // btnAlleAuswaehlen
            //
            this.btnAlleAuswaehlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlleAuswaehlen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAlleAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleAuswaehlen.Location = new System.Drawing.Point(302, 479);
            this.btnAlleAuswaehlen.Name = "btnAlleAuswaehlen";
            this.btnAlleAuswaehlen.Size = new System.Drawing.Size(125, 24);
            this.btnAlleAuswaehlen.TabIndex = 2;
            this.btnAlleAuswaehlen.Text = "Alle auswählen";
            this.btnAlleAuswaehlen.UseVisualStyleBackColor = false;
            this.btnAlleAuswaehlen.Click += new System.EventHandler(this.btnAlle_Click);
            //
            // btnFehlerhaft
            //
            this.btnFehlerhaft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFehlerhaft.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFehlerhaft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFehlerhaft.Location = new System.Drawing.Point(700, 479);
            this.btnFehlerhaft.Name = "btnFehlerhaft";
            this.btnFehlerhaft.Size = new System.Drawing.Size(110, 24);
            this.btnFehlerhaft.TabIndex = 5;
            this.btnFehlerhaft.Text = "Fehlerhaft";
            this.btnFehlerhaft.UseVisualStyleBackColor = false;
            this.btnFehlerhaft.Click += new System.EventHandler(this.btnBezahltFehlerhaft_Click);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.editBelegNr);
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.cboErsteller);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.editValutaDatumVon);
            this.tpgSuchen.Controls.Add(this.editValutaDatumBis);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel11);
            this.tpgSuchen.Controls.Add(this.lblPostKontoNr);
            this.tpgSuchen.Controls.Add(this.cboStatus);
            this.tpgSuchen.Controls.Add(this.editBetrag);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.cboEZugang);
            this.tpgSuchen.Controls.Add(this.editTransferDatumVonX);
            this.tpgSuchen.Controls.Add(this.editTransferDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBank);
            this.tpgSuchen.Controls.Add(this.editMandantSearch);
            this.tpgSuchen.Controls.Add(this.kissLabel8);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(818, 507);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Title = "Suchen";
            //
            // editBelegNr
            //
            this.editBelegNr.EditValue = "";
            this.editBelegNr.Location = new System.Drawing.Point(107, 205);
            this.editBelegNr.Name = "editBelegNr";
            this.editBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.editBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editBelegNr.Properties.Appearance.Options.UseFont = true;
            this.editBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editBelegNr.Size = new System.Drawing.Size(260, 24);
            this.editBelegNr.TabIndex = 6;
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(16, 3);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 388;
            //
            // cboErsteller
            //
            this.cboErsteller.Location = new System.Drawing.Point(107, 150);
            this.cboErsteller.Name = "cboErsteller";
            this.cboErsteller.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErsteller.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErsteller.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErsteller.Properties.Appearance.Options.UseBackColor = true;
            this.cboErsteller.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErsteller.Properties.Appearance.Options.UseFont = true;
            this.cboErsteller.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErsteller.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErsteller.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErsteller.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErsteller.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.cboErsteller.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.cboErsteller.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErsteller.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ersteller", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.cboErsteller.Properties.DisplayMember = "Text";
            this.cboErsteller.Properties.NullText = "";
            this.cboErsteller.Properties.ShowFooter = false;
            this.cboErsteller.Properties.ShowHeader = false;
            this.cboErsteller.Properties.ValueMember = "Code";
            this.cboErsteller.Size = new System.Drawing.Size(260, 24);
            this.cboErsteller.TabIndex = 5;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(11, 150);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(60, 24);
            this.kissLabel6.TabIndex = 386;
            this.kissLabel6.Text = "Ersteller";
            //
            // editValutaDatumVon
            //
            this.editValutaDatumVon.EditValue = null;
            this.editValutaDatumVon.Location = new System.Drawing.Point(107, 120);
            this.editValutaDatumVon.Name = "editValutaDatumVon";
            this.editValutaDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editValutaDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editValutaDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editValutaDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editValutaDatumVon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editValutaDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.editValutaDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.editValutaDatumVon.Properties.Appearance.Options.UseFont = true;
            this.editValutaDatumVon.Properties.Appearance.Options.UseForeColor = true;
            this.editValutaDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editValutaDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editValutaDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editValutaDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editValutaDatumVon.Properties.NullDate = "-";
            this.editValutaDatumVon.Properties.ShowToday = false;
            this.editValutaDatumVon.Size = new System.Drawing.Size(106, 24);
            this.editValutaDatumVon.TabIndex = 3;
            //
            // editValutaDatumBis
            //
            this.editValutaDatumBis.EditValue = "";
            this.editValutaDatumBis.Location = new System.Drawing.Point(261, 120);
            this.editValutaDatumBis.Name = "editValutaDatumBis";
            this.editValutaDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editValutaDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editValutaDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editValutaDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editValutaDatumBis.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editValutaDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.editValutaDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.editValutaDatumBis.Properties.Appearance.Options.UseFont = true;
            this.editValutaDatumBis.Properties.Appearance.Options.UseForeColor = true;
            this.editValutaDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.editValutaDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editValutaDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.editValutaDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editValutaDatumBis.Properties.ShowToday = false;
            this.editValutaDatumBis.Size = new System.Drawing.Size(106, 24);
            this.editValutaDatumBis.TabIndex = 4;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(11, 120);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(85, 24);
            this.kissLabel3.TabIndex = 382;
            this.kissLabel3.Text = "Valutadatum";
            //
            // kissLabel11
            //
            this.kissLabel11.Location = new System.Drawing.Point(231, 120);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(7, 24);
            this.kissLabel11.TabIndex = 385;
            this.kissLabel11.Text = "-";
            //
            // lblPostKontoNr
            //
            this.lblPostKontoNr.Location = new System.Drawing.Point(11, 205);
            this.lblPostKontoNr.Name = "lblPostKontoNr";
            this.lblPostKontoNr.Size = new System.Drawing.Size(70, 24);
            this.lblPostKontoNr.TabIndex = 380;
            this.lblPostKontoNr.Text = "BelegNr";
            //
            // cboStatus
            //
            this.cboStatus.Location = new System.Drawing.Point(107, 295);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboStatus.Properties.Appearance.Options.UseBackColor = true;
            this.cboStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.cboStatus.Properties.Appearance.Options.UseFont = true;
            this.cboStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.cboStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.cboStatus.Properties.DisplayMember = "Text";
            this.cboStatus.Properties.NullText = "";
            this.cboStatus.Properties.ShowFooter = false;
            this.cboStatus.Properties.ShowHeader = false;
            this.cboStatus.Properties.ValueMember = "Code";
            this.cboStatus.Size = new System.Drawing.Size(260, 24);
            this.cboStatus.TabIndex = 9;
            //
            // editBetrag
            //
            this.editBetrag.Location = new System.Drawing.Point(107, 265);
            this.editBetrag.Name = "editBetrag";
            this.editBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.editBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.editBetrag.Properties.Appearance.Options.UseFont = true;
            this.editBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBetrag.Size = new System.Drawing.Size(260, 24);
            this.editBetrag.TabIndex = 8;
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(11, 60);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(60, 24);
            this.kissLabel2.TabIndex = 372;
            this.kissLabel2.Text = "E-Zugang";
            //
            // cboEZugang
            //
            this.cboEZugang.Location = new System.Drawing.Point(107, 60);
            this.cboEZugang.Name = "cboEZugang";
            this.cboEZugang.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboEZugang.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboEZugang.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboEZugang.Properties.Appearance.Options.UseBackColor = true;
            this.cboEZugang.Properties.Appearance.Options.UseBorderColor = true;
            this.cboEZugang.Properties.Appearance.Options.UseFont = true;
            this.cboEZugang.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboEZugang.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboEZugang.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboEZugang.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEZugang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.cboEZugang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.cboEZugang.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboEZugang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.cboEZugang.Properties.DisplayMember = "Text";
            this.cboEZugang.Properties.NullText = "";
            this.cboEZugang.Properties.ShowFooter = false;
            this.cboEZugang.Properties.ShowHeader = false;
            this.cboEZugang.Properties.ValueMember = "Code";
            this.cboEZugang.Size = new System.Drawing.Size(260, 24);
            this.cboEZugang.TabIndex = 0;
            //
            // editTransferDatumVonX
            //
            this.editTransferDatumVonX.EditValue = null;
            this.editTransferDatumVonX.Location = new System.Drawing.Point(107, 90);
            this.editTransferDatumVonX.Name = "editTransferDatumVonX";
            this.editTransferDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTransferDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTransferDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTransferDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTransferDatumVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseForeColor = true;
            this.editTransferDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editTransferDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editTransferDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editTransferDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTransferDatumVonX.Properties.NullDate = "-";
            this.editTransferDatumVonX.Properties.ShowToday = false;
            this.editTransferDatumVonX.Size = new System.Drawing.Size(106, 24);
            this.editTransferDatumVonX.TabIndex = 1;
            //
            // editTransferDatumBisX
            //
            this.editTransferDatumBisX.EditValue = "";
            this.editTransferDatumBisX.Location = new System.Drawing.Point(261, 90);
            this.editTransferDatumBisX.Name = "editTransferDatumBisX";
            this.editTransferDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTransferDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTransferDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTransferDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTransferDatumBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseForeColor = true;
            this.editTransferDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editTransferDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editTransferDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editTransferDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTransferDatumBisX.Properties.ShowToday = false;
            this.editTransferDatumBisX.Size = new System.Drawing.Size(106, 24);
            this.editTransferDatumBisX.TabIndex = 2;
            //
            // lblBank
            //
            this.lblBank.Location = new System.Drawing.Point(11, 235);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(60, 24);
            this.lblBank.TabIndex = 361;
            this.lblBank.Text = "Mandant";
            //
            // editMandantSearch
            //
            this.editMandantSearch.Location = new System.Drawing.Point(107, 235);
            this.editMandantSearch.Name = "editMandantSearch";
            this.editMandantSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMandantSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantSearch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandantSearch.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantSearch.Properties.Appearance.Options.UseFont = true;
            this.editMandantSearch.Properties.Appearance.Options.UseForeColor = true;
            this.editMandantSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editMandantSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editMandantSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMandantSearch.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editMandantSearch.Size = new System.Drawing.Size(260, 24);
            this.editMandantSearch.TabIndex = 7;
            this.editMandantSearch.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandantSearch_UserModifiedFld);
            //
            // kissLabel8
            //
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel8.Location = new System.Drawing.Point(11, 182);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(100, 16);
            this.kissLabel8.TabIndex = 358;
            this.kissLabel8.Text = "Buchung";
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(11, 90);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(85, 24);
            this.kissLabel4.TabIndex = 351;
            this.kissLabel4.Text = "Transferdatum";
            //
            // kissLabel1
            //
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel1.Location = new System.Drawing.Point(11, 34);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(130, 16);
            this.kissLabel1.TabIndex = 335;
            this.kissLabel1.Text = "Zahlungsauftrag";
            //
            // kissLabel10
            //
            this.kissLabel10.Location = new System.Drawing.Point(229, 90);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(7, 24);
            this.kissLabel10.TabIndex = 366;
            this.kissLabel10.Text = "-";
            //
            // kissLabel7
            //
            this.kissLabel7.Location = new System.Drawing.Point(11, 295);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(60, 24);
            this.kissLabel7.TabIndex = 378;
            this.kissLabel7.Text = "Status";
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(11, 265);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(60, 24);
            this.kissLabel5.TabIndex = 376;
            this.kissLabel5.Text = "Betrag";
            //
            // qryZuUebermitteln
            //
            this.qryZuUebermitteln.CanUpdate = true;
            this.qryZuUebermitteln.HostControl = this;
            this.qryZuUebermitteln.IsIdentityInsert = false;
            this.qryZuUebermitteln.TableName = "FbDTAJournal";
            //
            // CtlFibuDTATransfer
            //
            this.ActiveSQLQuery = this.qryFbDTAJournal;
            this.AutoRefresh = false;
            this.Controls.Add(this.tabControlSearch);
            this.Name = "CtlFibuDTATransfer";
            this.Size = new System.Drawing.Size(830, 545);
            this.Search += new System.EventHandler(this.CtlFibuDTATransfer_Search);
            this.Load += new System.EventHandler(this.CtlFibuDTATransfer_Load);
            this.Click += new System.EventHandler(this.btnBezahltFehlerhaft_Click);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTABuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAJournal)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTAJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTAJournal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTABuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTABuchung)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErsteller.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErsteller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editValutaDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editValutaDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEZugang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuUebermitteln)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Search for ... .
        /// </summary>
        private void Suchen()
        {
            string sql = this.sqlDTATransferedSearch;
            //müssen wir noch JOINS anhängen für FbBuchung?
            if (this.editValutaDatumVon.EditValue != null && this.editValutaDatumVon.EditValue.ToString() != ""
                || this.editValutaDatumBis.EditValue != null && this.editValutaDatumBis.EditValue.ToString() != ""
                || this.editBelegNr.EditValue != null && this.editBelegNr.EditValue.ToString() != ""
                || this.MandantSearchId != 0
                || this.editBetrag.EditValue != null && this.editBetrag.EditValue.ToString() != ""
                || this.cboStatus.Text != "")
            {
                sql += sql_Buchungen_Joins;
            }

            // --- FbDTAJournal
            if (this.cboEZugang.Text != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FDJ.FbDTAZugangId = " + DBUtil.SqlLiteral(cboEZugang.EditValue);
            if (this.editTransferDatumVonX.EditValue != null && this.editTransferDatumVonX.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " TransferDatum >= " + DBUtil.SqlLiteral(this.editTransferDatumVonX.DateTime);
            if (this.editTransferDatumBisX.EditValue != null && this.editTransferDatumBisX.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " TransferDatum <= " + DBUtil.SqlLiteral(this.editTransferDatumBisX.DateTime);
            if (this.cboErsteller.Text != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FDJ.UserId = " + DBUtil.SqlLiteral(cboErsteller.EditValue);

            // --- FbBuchung
            if (this.editValutaDatumVon.EditValue != null && this.editValutaDatumVon.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FBB.ValutaDatum >= " + DBUtil.SqlLiteral(this.editValutaDatumVon.DateTime);
            if (this.editValutaDatumBis.EditValue != null && this.editValutaDatumBis.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FBB.ValutaDatum <= " + DBUtil.SqlLiteral(this.editValutaDatumBis.DateTime);
            if (this.editBelegNr.EditValue != null && this.editBelegNr.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FBB.BelegNr = " + DBUtil.SqlLiteral(this.editBelegNr.Text);
            if (this.MandantSearchId != 0)
                sql += FibuUtilities.AndOrWhere(sql) + " FBP.BaPersonId = " + DBUtil.SqlLiteral(this.MandantSearchId);
            if (this.editBetrag.EditValue != null && this.editBetrag.EditValue.ToString() != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FBB.Betrag = " + DBUtil.SqlLiteral(Convert.ToDecimal(this.editBetrag.Text));
            if (this.cboStatus.Text != "")
                sql += FibuUtilities.AndOrWhere(sql) + " FDB.Status = " + DBUtil.SqlLiteral(cboStatus.EditValue);

            sql += FibuUtilities.AndOrWhere(sql) + " FDJ.Transferiert = 1 ORDER BY TransferDatum, 9, FDJ.FbDTAZugangID";

            this.qryFbDTAJournal.SelectStatement = sql;
            this.qryFbDTAJournal.Fill();

            this.grdFbDTAJournal.DataSource = this.qryFbDTAJournal;

            this.tabControlSearch.SelectedTabIndex = tabControlSearch.TabPages.IndexOf(this.tpgListe);
            qryFbDTAJournal.RefreshDisplay();
        }

        /// <summary>
        /// Handles the SelectedTabChanged event from xTabControl1.
        /// </summary>
        /// <param name="page">The page.</param>
        private void xTabControl1_SelectedTabChanged(
            SharpLibrary.WinControls.TabPageEx page)
        {
            if (this.ActiveSQLQuery.Post())
            {
                if (this.tabControlSearch.SelectedTabIndex == 0)
                    this.ActiveSQLQuery = qryZuUebermitteln;
                else
                {
                    if (this.ActiveSQLQuery == qryZuUebermitteln)
                    {
                        this.ActiveSQLQuery = qryFbDTAJournal;
                        this.ActiveSQLQuery.Refresh();
                    }
                    else
                    {
                        this.ActiveSQLQuery = qryFbDTAJournal;
                    }
                }
            }
        }
    }
}