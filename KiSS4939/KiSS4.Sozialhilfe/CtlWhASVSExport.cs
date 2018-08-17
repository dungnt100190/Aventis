using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Kiss.Interfaces.DocumentHandling;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlWhASVSExport : KissUserControl
    {
        #region Constructors

        public CtlWhASVSExport()
        {
            InitializeComponent();
            colProblem.Visible = false;
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT Code = OrgUnitID, Text = ItemName FROM XORGUNIT Order BY ItemName");
            DataRow newRow = qry.DataTable.NewRow();
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "",
                    true, DevExpress.Utils.HorzAlignment.Default)
            });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        #region EventHandlers

        private void btnExportieren_Click(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();
                qryASVS[DBO.SstASVSExport.Creator] = Session.User.LogonName;
                qryASVS[DBO.SstASVSExport.Modifier] = Session.User.LogonName;
                qryASVS.RowModified = true;
                qryASVS.Post(); // evt. veränderten Kommentar speichern, ASVSExportID generieren
                DBUtil.ExecuteScalarSQLThrowingException("EXEC spWhASVSExport {0}, {1}, {2}", qryASVS[DBO.SstASVSExport.SstASVSExportID], Session.User.UserID, edtOrgUnitID.EditValue);
                qryDokCorr.Fill(qryASVS[DBO.SstASVSExport.SstASVSExportID]);

                // Der Eintrag muss komprimiert vorliegen, sonst kann in KiSS nicht laden (evt. später in DB-CLR-Funktion auslagern, um sich den Round-Trip zu sparen)
                string filePath = Path.GetTempPath() + "xml_export" + Session.Connection.Database + Session.User.UserID.ToString() + DateTime.Now.Ticks.ToString() + ".xml";

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    byte[] xml = (byte[])qryDokCorr[DBO.XDocument.FileBinary];
                    // Change Encoding from UTF-16 (DB-Default) to UTF-8
                    xml = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, xml);
                    fileStream.Write(xml, 0, xml.Length);
                }

                XDocFileHandler fileHandler = new XDocFileHandler();
                fileHandler.FileToDB(new FileInfo(filePath));
                qryASVS.Refresh();
                qryASVS[DBO.SstASVSExport.DocumentID] = fileHandler.DocumentID;
                qryDokCorr.DeleteQuestion = null;
                qryDokCorr.Delete(); // temporärer Datei-Eintrag wird nicht mehr benutzt
                qryASVS.Post();
                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }
                qryASVS.Refresh();
            }
            SetEditMode();
        }

        private void btnSpeichernUnter_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryASVS[DBO.SstASVSExport.DocumentID]))
            {
                throw new Exception("Dokument konnte nicht gefunden werden");
            }
            XDocFileHandler documentHandler = XDocFileHandler.CreateFileHandler(DokTyp.Dokument, qryASVS[DBO.SstASVSExport.DocumentID], ".xml", false);

            dlgFileSave.FileName = documentHandler.ActualFileName + ".xml";

            if (DialogResult.Cancel == dlgFileSave.ShowDialog(this))
            {
                return;
            }

            try
            {
                documentHandler.DBToFile(false, false, false);

                var file = new FileInfo(dlgFileSave.FileName);

                if (file.Exists)
                {
                    file.IsReadOnly = false;
                }

                File.Copy(documentHandler.ActualFileFullName, dlgFileSave.FileName, true);
                File.SetAttributes(dlgFileSave.FileName, File.GetAttributes(dlgFileSave.FileName) & ~FileAttributes.Hidden);
                File.SetAttributes(dlgFileSave.FileName, File.GetAttributes(dlgFileSave.FileName) & ~FileAttributes.System);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Speichern fehlgeschlagen", ex);
            }

            documentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);
        }

        private void edtOrgUnitID_EditValueChanged(object sender, EventArgs e)
        {
            RefreshEintragListe();
        }

        private void edtOrgUnitID_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            //RefreshEintragListe();
        }

        private void edtOrgUnitID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            //RefreshEintragListe();
        }

        private void qryASVS_AfterInsert(object sender, EventArgs e)
        {
            lblSektion.Visible = true;
            edtOrgUnitID.Visible = true;
            qryASVSEintrag.Fill(0, true, edtOrgUnitID.EditValue);
            colProblem.Visible = true;
            lblExportierteEintraege.Text = "Zu exportierende Einräge";
        }

        private void qryASVS_BeforePost(object sender, EventArgs e)
        {
        }

        private void qryASVS_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();

            if (qryASVS.IsEmpty || qryASVS.Row.RowState != DataRowState.Added)
            {
                int asvsExportId = qryASVS.IsEmpty || DBUtil.IsEmpty(qryASVS[DBO.SstASVSExport.SstASVSExportID]) ? -1 : (int)qryASVS[DBO.SstASVSExport.SstASVSExportID];
                qryASVSEintrag.Fill(asvsExportId, false, edtOrgUnitID.EditValue);
                colProblem.Visible = false;
                lblSektion.Visible = false;
                edtOrgUnitID.Visible = false;
                lblExportierteEintraege.Text = "Exportierte Einträge:";
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnSaveData()
        {
            if (DBUtil.IsEmpty(qryASVS[DBO.SstASVSExport.DatumExport]))
            {
                KissMsg.ShowInfo("Der Datensatz kann erst nach dem Export gespeichert werden. Über den Button 'Neue Einträge exportieren' können sie den Export starten.");
                return false;
            }
            return qryASVS.Post();
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetEditMode();
            qryASVS.Fill();
        }

        #endregion

        #region Private Methods

        private void RefreshEintragListe()
        {
            if (!qryASVS.IsEmpty && qryASVS.Row.RowState == DataRowState.Added)
            {
                qryASVSEintrag.Fill(0, true, edtOrgUnitID.EditValue);
            }
        }

        private void SetEditMode()
        {
            if (qryASVS.IsEmpty)
            {
                edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                btnExportieren.Enabled = false;
                btnSpeichernUnter.Enabled = false;
            }
            else
            {
                edtBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
                btnExportieren.Enabled = DBUtil.IsEmpty(qryASVS[DBO.SstASVSExport.DatumExport]);
                btnSpeichernUnter.Enabled = !DBUtil.IsEmpty(qryASVS[DBO.SstASVSExport.DocumentID]) && (int)qryASVS[DBO.SstASVSExport.DocumentID] != -1;
            }
        }

        #endregion

        #endregion
    }
}