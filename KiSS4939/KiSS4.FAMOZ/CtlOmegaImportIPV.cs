using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Kiss.BusinessLogic.Ba;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using KiSS4.DB;
using KiSS4.Messages;

namespace KiSS4.Administration.ZH
{
    public class CtlOmegaImportIPV : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnStartImport;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit edtSuchePersonenK;
        private KiSS4.Gui.KissCheckEdit edtSuchePersonenW;
        private KiSS4.Gui.KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;

        #endregion

        #region Constructors

        public CtlOmegaImportIPV()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlOmegaImportIPV));
            this.btnStartImport = new KiSS4.Gui.KissButton();
            this.edtSuchePersonenW = new KiSS4.Gui.KissCheckEdit();
            this.edtSuchePersonenK = new KiSS4.Gui.KissCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenK.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(633, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(469, 397);
            this.ctlGotoFall.Visible = false;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnStartImport);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnStartImport, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSuchePersonenK);
            this.tpgSuchen.Controls.Add(this.edtSuchePersonenW);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePersonenW, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePersonenK, 0);
            //
            // btnStartImport
            //
            this.btnStartImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartImport.Location = new System.Drawing.Point(3, 397);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(99, 24);
            this.btnStartImport.TabIndex = 3;
            this.btnStartImport.Text = "Start Import";
            this.btnStartImport.UseCompatibleTextRendering = true;
            this.btnStartImport.UseVisualStyleBackColor = false;
            this.btnStartImport.Click += new System.EventHandler(this.btnStartImport_Click);
            //
            // edtSuchePersonenW
            //
            this.edtSuchePersonenW.EditValue = true;
            this.edtSuchePersonenW.Location = new System.Drawing.Point(44, 55);
            this.edtSuchePersonenW.Name = "edtSuchePersonenW";
            this.edtSuchePersonenW.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSuchePersonenW.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePersonenW.Properties.Caption = "Importiere IPV für alle Personen mit aktivem oder inaktivem W";
            this.edtSuchePersonenW.Size = new System.Drawing.Size(347, 19);
            this.edtSuchePersonenW.TabIndex = 1;
            //
            // edtSuchePersonenK
            //
            this.edtSuchePersonenK.EditValue = true;
            this.edtSuchePersonenK.Location = new System.Drawing.Point(44, 90);
            this.edtSuchePersonenK.Name = "edtSuchePersonenK";
            this.edtSuchePersonenK.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSuchePersonenK.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePersonenK.Properties.Caption = "Importiere IPV für alle Personen mit aktivem oder inaktivem K";
            this.edtSuchePersonenK.Size = new System.Drawing.Size(347, 19);
            this.edtSuchePersonenK.TabIndex = 2;
            //
            // panel1
            //
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 35);
            this.panel1.TabIndex = 1001;
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(475, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Omega Import IPV";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRowCount.Location = new System.Drawing.Point(740, 6);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(94, 24);
            this.lblRowCount.TabIndex = 1002;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRowCount.UseCompatibleTextRendering = true;
            //
            // CtlOmegaImportIPV
            //
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.panel1);
            this.Name = "CtlOmegaImportIPV";
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePersonenK.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSuchePersonenW.Checked = true;
            edtSuchePersonenK.Checked = true;
        }

        #endregion

        #region Private Methods

        private static IServiceResult ImportOmegaPersonIPV(string einwohnerregisterId, int baPersonId)
        {
            var einwohnerregisterService = Kiss.Infrastructure.IoC.Container.Resolve<BaEinwohnerregisterService>();

            var result = einwohnerregisterService.GetPersonDetails(einwohnerregisterId);

            if (!result.IsOk)
            {
                return result;
            }

            var personDto = result.Result;

            if (personDto != null)
            {
                IDictionary<string, string> changes;
                result.Add(einwohnerregisterService.ImportPersonKrankenkasse(baPersonId, personDto, out changes));
            }

            return result;
        }

        private void btnStartImport_Click(object sender, System.EventArgs e)
        {
            if (qryQuery.Count == 0) return;

            DlgProgressLog.Show("Omega IPV Import", 700, 500, new ProgressEventHandler(ProgressStart), new ProgressEventHandler(ProgressEnd), Session.MainForm);
        }

        private void ProgressEnd()
        {
        }

        private void ProgressStart()
        {
            Cursor = Cursors.WaitCursor;
            ApplicationFacade.DoEvents();

            DlgProgressLog.AddLine("Start des Omega IPV Imports");
            ApplicationFacade.DoEvents();
            int successCount = 0;
            int failureCount = 0;
            int count = 1;
            int total = qryQuery.DataTable.Rows.Count;
            bool lastLineUpdateable = false;

            try
            {
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    try
                    {
                        var userText = string.Format("{2} von {3}: Person {0}, PID {1}", row["Person"], row["PID"], count, total);

                        // Die folgende Logik stellt sicher, dass alle 100 Records eine neue Zeile angefügt wird, die dann jeweils 99 mal updated wird
                        if (lastLineUpdateable)
                        {
                            DlgProgressLog.UpdateLastLine(userText + ": empfange IPV von Omega ... ");
                        }
                        else
                        {
                            DlgProgressLog.AddLine(userText + ": empfange IPV von Omega ... ");
                            lastLineUpdateable = true;
                        }

                        // alle 100 Zeilen die Belegzeile stehen lassen (für Fortschrittshistory)
                        if (count % 100 == 0)
                        {
                            lastLineUpdateable = false;
                        }

                        // Importiere die IPV für diese Person
                        var result = ImportOmegaPersonIPV(row["EinwohnerregisterID$"].ToString(), (int)row["PNr."]);
                        if (!result.IsOk)
                        {
                            // Import ist schiefgelaufen
                            failureCount++;
                            DlgProgressLog.AddLine("Import von PID=" + row["PID"] + " / PersonenID=" + row["PNr."] + " war nicht erfolgreich: ");
                            DlgProgressLog.AddError(result.GetTechnicalDetails());
                            continue;
                        }

                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        // Import ist schiefgelaufen
                        failureCount++;
                        DlgProgressLog.AddLine("Import von PID=" + row["PID"] + " / PersonenID=" + row["PNr."] + " war nicht erfolgreich: " + ex.Message);

                        lastLineUpdateable = false;
                    }

                    count++;
                }

                DlgProgressLog.AddLine("Ende der Omega IPV Übertragung");
                DlgProgressLog.AddLine(string.Format("- {0} Person(en) erfolgreich mit aktuellen IPV Daten aktualisiert", successCount));
                DlgProgressLog.AddLine(string.Format("- {0} Person(en) konnten nicht mit aktuellen IPV Daten aktualisiert werden", failureCount));
            }
            catch (CancelledByUserException)
            {
                KissMsg.ShowInfo("Abbruch durch Benutzer/in\r\n\r\n" +
                                 string.Format("- {0} Person(en) erfolgreich mit aktuellen IPV Daten aktualisiert", successCount) + "\r\n" +
                                 string.Format("- {0} Person(en) konnten nicht mit aktuellen IPV Daten aktualisiert werden", failureCount));
            }
            finally
            {
                Cursor = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            lblRowCount.Text = qryQuery.Count.ToString();
        }

        #endregion
    }
}