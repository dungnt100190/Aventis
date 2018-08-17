using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialhilfe
{
    public class DlgWhPositionAnpassen : KiSS4.Gui.KissDialog
    {
        #region Enumerations

        public enum AnpassungTyp
        {
            Krankenkasse,
            Wohnkosten
        }

        #endregion

        #region Fields

        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnOK;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit edtDatumVon;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblMeldung;
        private KiSS4.DB.SqlQuery qryPosition;

        #endregion

        #region Constructors

        private DlgWhPositionAnpassen(DateTime DatumVon, DateTime DatumBis)
            : this()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT DATEADD(m, TMP.Nr, dbo.fnFirstDayOf({0}))               AS FirstDate,
                  dbo.fnXMonatJahr(DATEADD(m, TMP.Nr, dbo.fnFirstDayOf({0})))  AS Text
                FROM (SELECT  0 AS Nr
                      UNION ALL SELECT  1 AS Nr
                      UNION ALL SELECT  2 AS Nr
                      UNION ALL SELECT  3 AS Nr
                      UNION ALL SELECT  4 AS Nr
                      UNION ALL SELECT  5 AS Nr
                      UNION ALL SELECT  6 AS Nr
                      UNION ALL SELECT  7 AS Nr
                      UNION ALL SELECT  8 AS Nr
                      UNION ALL SELECT  9 AS Nr
                      UNION ALL SELECT 10 AS Nr
                      UNION ALL SELECT 11 AS Nr
                      UNION ALL SELECT 12 AS Nr) TMP
                WHERE DATEADD(m, TMP.Nr, dbo.fnFirstDayOf({0})) >= {0}
                 AND DATEADD(m, TMP.Nr, dbo.fnFirstDayOf({0})) < {1}"
                , DatumVon, DatumBis);

            this.edtDatumVon.Properties.DataSource = qry;

            // Set EditValue
            if(qry.DataTable.Rows.Count < 1)
            {
                KissMsg.ShowInfo("DlgWhPositionAnpassen", "AlleMonatsbudgetsBewilligt", "Sämtliche Monatsbudgets des Finanzplanes sind bereits bewilligt.");
                /// TODO gibt es etwas eleganteres?
                this.btnOK.Enabled = false;
                return;
            }

            foreach (DataRow row in qry.DataTable.Rows)
            {
                this.edtDatumVon.EditValue = row[0];

                if ((DateTime)row[0] > DateTime.Now)
                {
                    break;
                }
            }
        }

        public DlgWhPositionAnpassen(AnpassungTyp typ, DateTime DatumVon, DateTime DatumBis)
            : this(DatumVon, DatumBis)
        {
            switch (typ)
            {
                case AnpassungTyp.Krankenkasse:
                    this.Text = string.Format(this.Text, "KVG- und VVG Prämien");
                    this.lblDatumVon.Text = string.Format(this.lblDatumVon.Text, "Prämien");
                    break;

                case AnpassungTyp.Wohnkosten:
                    this.Text = string.Format(this.Text, "Wohnkosten");
                    this.lblDatumVon.Text = string.Format(this.lblDatumVon.Text, "Wohnkosten");
                    break;
            }
        }

        public DlgWhPositionAnpassen(string Titel, string Meldung, string LabelText, DateTime DatumVon, DateTime DatumBis)
            : this(DatumVon, DatumBis)
        {
            this.Text = Titel;
            this.lblMeldung.Text = Meldung;
            this.lblDatumVon.Text = LabelText;
        }

        public DlgWhPositionAnpassen()
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
            this.components = new System.ComponentModel.Container();
            this.lblMeldung = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.edtDatumVon = new KiSS4.Gui.KissLookUpEdit();
            this.qryPosition = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lblMeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPosition)).BeginInit();
            this.SuspendLayout();
            //
            // lblMeldung
            //
            this.lblMeldung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMeldung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMeldung.Location = new System.Drawing.Point(13, 13);
            this.lblMeldung.Name = "lblMeldung";
            this.lblMeldung.Size = new System.Drawing.Size(423, 46);
            this.lblMeldung.TabIndex = 0;
            this.lblMeldung.Text = "Die neuen Ansätze werden automatisch im Masterbudget sowie in sämtlichen noch nic" +
                "ht freigegebenen Monatsbudgets vom unten stehenden Monat an nachgeführt.";
            this.lblMeldung.UseCompatibleTextRendering = true;
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(13, 59);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(181, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Die neuen Kosten gelten ab";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // btnAbbrechen
            //
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(221, 103);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 4;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            //
            // btnOK
            //
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(317, 103);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // edtDatumVon
            //
            this.edtDatumVon.Location = new System.Drawing.Point(200, 58);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtDatumVon.Properties.DisplayMember = "Text";
            this.edtDatumVon.Properties.NullText = "";
            this.edtDatumVon.Properties.ShowFooter = false;
            this.edtDatumVon.Properties.ShowHeader = false;
            this.edtDatumVon.Properties.ValueMember = "FirstDate";
            this.edtDatumVon.Size = new System.Drawing.Size(207, 24);
            this.edtDatumVon.TabIndex = 6;
            //
            // qryPosition
            //
            this.qryPosition.HostControl = this;
            this.qryPosition.TableName = "BgPosition";
            //
            // DlgWhPositionAnpassen
            //
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(442, 139);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblMeldung);
            this.Name = "DlgWhPositionAnpassen";
            this.Text = "Anpassung {0}";
            ((System.ComponentModel.ISupportInitialize)(this.lblMeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPosition)).EndInit();
            this.ResumeLayout(false);
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

        #region Public Properties

        public DateTime DatumVon
        {
            get { return (DateTime)this.edtDatumVon.EditValue; }
        }

        #endregion

        #region Private Methods

        private void btnAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.userCancel = true;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.userCancel = false;
            this.DialogResult = DialogResult.OK;
        }

        #endregion
    }
}