using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    public class CtlZahlungsweg : KissComplexControl,
        IKissBindableEdit
        ,
        IKissEditable
        ,
        IBelegleser
    {
        protected SqlQuery qryBaZahlungsweg;
        private Belegleser belegLeser;
        private KiSS4.Gui.KissButtonEdit btnEditSearch;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private System.ComponentModel.IContainer components = null;
        private String dataMember;
        private SqlQuery dataSource;
        private KiSS4.Gui.KissMemoEdit edtKreditor;
        private KiSS4.Gui.KissMemoEdit edtZahlungsweg;
        private int layoutNr = 1;
        private KiSS4.Gui.KissLabel lblKreditor;
        private KiSS4.Gui.KissLabel lblSuchbegriff;
        private KiSS4.Gui.KissLabel lblZahlungsweg;
        private ModulID modul = ModulID.S;

        public CtlZahlungsweg()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public event System.EventHandler BaZahlungswegIDChanged;

        //Delegate
        private event DevExpress.XtraEditors.Controls.ButtonPressedEventHandler ButtonPressedDelegate;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object BaZahlungswegID
        {
            get
            {
                if (this.qryBaZahlungsweg.Count == 0)
                    return DBNull.Value;

                return this.qryBaZahlungsweg["BaZahlungswegID"];
            }
            set
            {
                belegLeser = null;
                LoadData(value);
            }
        }

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return this.dataMember; }
            set { this.dataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return this.btnEditSearch.EditMode; }
            set { this.btnEditSearch.EditMode = value; }
        }

        /// <summary>
        /// Gets the esr teilnehmer.
        /// </summary>
        /// <value>The esr teilnehmer.</value>
        public string EsrTeilnehmer
        {
            get
            {
                if (qryBaZahlungsweg.Count == 0)
                    return null;
                else if (!DBUtil.IsEmpty(qryBaZahlungsweg["PostKontoNummer"]))
                    return (string)qryBaZahlungsweg["PostKontoNummer"];
                else
                    return (string)qryBaZahlungsweg["BankPCKontoNr"] as string;
            }
        }

        /// <summary>
        /// Gets or sets the layout nr.
        /// </summary>
        /// <value>The layout nr.</value>
        [DefaultValue(1)]
        [Browsable(true)]
        public int LayoutNr
        {
            get
            {
                return this.layoutNr;
            }
            set
            {
                this.SuspendLayout();

                switch (value)
                {
                    case 2:
                        lblSuchbegriff.Location = new Point(0, 0);
                        btnEditSearch.Location = new Point(80, 0);
                        btnEditSearch.Size = new Size(this.Width - 80, 24);

                        lblKreditor.Location = new Point(0, 30);
                        edtKreditor.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right));
                        edtKreditor.Location = new Point(80, 30);
                        edtKreditor.Size = new Size(this.Width - 80, 70);

                        lblZahlungsweg.Location = new Point(0, 106);
                        edtZahlungsweg.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right));
                        edtZahlungsweg.Location = new Point(80, 106);
                        edtZahlungsweg.Size = new Size(this.Width - 80, 110);
                        break;

                    default:
                        value = 1;

                        lblSuchbegriff.Location = new Point(0, 0);
                        btnEditSearch.Location = new Point(68, 0);
                        btnEditSearch.Size = new Size(this.Width - 68, 24);

                        lblKreditor.Location = new Point(0, 30);
                        edtKreditor.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left));
                        edtKreditor.Location = new Point(0, 44);

                        lblZahlungsweg.Location = new Point(311, 28);
                        edtZahlungsweg.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left));
                        edtZahlungsweg.Location = new Point(311, 44);
                        break;
                }

                this.ResumeLayout();
                this.layoutNr = value;
                CtlZahlungsweg_Resize(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the modul.
        /// </summary>
        /// <value>The modul.</value>
        [Browsable(true)]
        [DefaultValue(ModulID.S)]
        public ModulID Modul
        {
            get { return this.modul; }
            set { this.modul = value; }
        }

        /// <summary>
        /// Gets the referenz nummer.
        /// </summary>
        /// <value>The referenz nummer.</value>
        public string ReferenzNummer
        {
            get { return belegLeser == null ? null : belegLeser.ReferenzNummer; }
        }

        /// <summary>
        /// Gets the verguetungs betrag.
        /// </summary>
        /// <value>The verguetungs betrag.</value>
        public double VerguetungsBetrag
        {
            get { return belegLeser == null ? (double)0 : (double)belegLeser.Betrag; }
        }

        [Obsolete("Use IBelegleser")]
        public void BelegleserKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) { }

        [Obsolete("Use IBelegleser")]
        public void F11KeyPress() { }

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (btnEditSearch.Properties.ReadOnly) return;

            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            dlg.SucheBaZahlungsweg(beleg);
            switch (dlg.Count)
            {
                case 0: KissMsg.ShowInfo(Name, "KeinKreditorEintraege", "Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    return;

                case 1:
                    // set ZahlungsWeg Informations
                    belegLeser = beleg;
                    LoadData(dlg.BaZahlungswegID);
                    break;

                default:
                    if (dlg.ShowDialog(this) == DialogResult.OK) goto case 1;
                    break;
            }

            dlg.Dispose();
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlZahlungsweg));
            this.edtKreditor = new KiSS4.Gui.KissMemoEdit();
            this.qryBaZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.edtZahlungsweg = new KiSS4.Gui.KissMemoEdit();
            this.btnEditSearch = new KiSS4.Gui.KissButtonEdit();
            this.lblSuchbegriff = new KiSS4.Gui.KissLabel();
            this.lblKreditor = new KiSS4.Gui.KissLabel();
            this.lblZahlungsweg = new KiSS4.Gui.KissLabel();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // edtKreditor
            //
            this.edtKreditor.DataMember = "KreditorMehrZeilig";
            this.edtKreditor.DataSource = this.qryBaZahlungsweg;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditor.Location = new System.Drawing.Point(0, 44);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditor.Properties.ReadOnly = true;
            this.edtKreditor.Size = new System.Drawing.Size(308, 96);
            this.edtKreditor.TabIndex = 3;
            this.edtKreditor.TabStop = false;
            //
            // qryBaZahlungsweg
            //
            this.qryBaZahlungsweg.HostControl = this;
            this.qryBaZahlungsweg.SelectStatement = "SELECT\r\n  BaZahlungswegID,\r\n  Kreditor,\r\n  KreditorMehrZeilig,\r\n  ZahlungswegMehr" +
                "Zeilig,\r\n  BankPCKontoNr, PostKontoNummer,\r\n  IsActive\r\nFROM vwKreditor\r\nWHERE B" +
                "aZahlungswegID = {0}";
            //
            // edtZahlungsweg
            //
            this.edtZahlungsweg.DataMember = "ZahlungswegMehrZeilig";
            this.edtZahlungsweg.DataSource = this.qryBaZahlungsweg;
            this.edtZahlungsweg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZahlungsweg.Location = new System.Drawing.Point(307, 44);
            this.edtZahlungsweg.Name = "edtZahlungsweg";
            this.edtZahlungsweg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZahlungsweg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsweg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsweg.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsweg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsweg.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsweg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungsweg.Properties.ReadOnly = true;
            this.edtZahlungsweg.Size = new System.Drawing.Size(309, 96);
            this.edtZahlungsweg.TabIndex = 5;
            this.edtZahlungsweg.TabStop = false;
            //
            // btnEditSearch
            //
            this.btnEditSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSearch.CausesValidation = false;
            this.btnEditSearch.Location = new System.Drawing.Point(68, 0);
            this.btnEditSearch.Name = "btnEditSearch";
            this.btnEditSearch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.btnEditSearch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.btnEditSearch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnEditSearch.Properties.Appearance.Options.UseBackColor = true;
            this.btnEditSearch.Properties.Appearance.Options.UseBorderColor = true;
            this.btnEditSearch.Properties.Appearance.Options.UseFont = true;
            this.btnEditSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.btnEditSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Delete", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.btnEditSearch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEditSearch.SearchStringMinLength = 3;
            this.btnEditSearch.Size = new System.Drawing.Size(548, 24);
            this.btnEditSearch.TabIndex = 1;
            this.btnEditSearch.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.btnEditSearch_UserModifiedFld);
            //
            // lblSuchbegriff
            //
            this.lblSuchbegriff.Location = new System.Drawing.Point(0, 0);
            this.lblSuchbegriff.Name = "lblSuchbegriff";
            this.lblSuchbegriff.Size = new System.Drawing.Size(60, 24);
            this.lblSuchbegriff.TabIndex = 0;
            this.lblSuchbegriff.Text = "Suchbegriff";
            //
            // lblKreditor
            //
            this.lblKreditor.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblKreditor.Location = new System.Drawing.Point(0, 28);
            this.lblKreditor.Name = "lblKreditor";
            this.lblKreditor.Size = new System.Drawing.Size(100, 16);
            this.lblKreditor.TabIndex = 2;
            this.lblKreditor.Text = "Kreditor";
            //
            // lblZahlungsweg
            //
            this.lblZahlungsweg.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblZahlungsweg.Location = new System.Drawing.Point(307, 28);
            this.lblZahlungsweg.Name = "lblZahlungsweg";
            this.lblZahlungsweg.Size = new System.Drawing.Size(100, 16);
            this.lblZahlungsweg.TabIndex = 4;
            this.lblZahlungsweg.Text = "Zahlungsweg";
            //
            // chkAktiv
            //
            this.chkAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAktiv.DataMember = "IsActive";
            this.chkAktiv.DataSource = this.qryBaZahlungsweg;
            this.chkAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkAktiv.Location = new System.Drawing.Point(568, 28);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "aktiv";
            this.chkAktiv.Properties.ReadOnly = true;
            this.chkAktiv.Size = new System.Drawing.Size(52, 19);
            this.chkAktiv.TabIndex = 6;
            this.chkAktiv.TabStop = false;
            //
            // CtlZahlungsweg
            //
            this.Controls.Add(this.btnEditSearch);
            this.Controls.Add(this.edtZahlungsweg);
            this.Controls.Add(this.edtKreditor);
            this.Controls.Add(this.lblZahlungsweg);
            this.Controls.Add(this.lblSuchbegriff);
            this.Controls.Add(this.lblKreditor);
            this.Controls.Add(this.chkAktiv);
            this.Name = "CtlZahlungsweg";
            this.Size = new System.Drawing.Size(616, 140);
            this.Resize += new System.EventHandler(this.CtlZahlungsweg_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:BaZahlungswegIDChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnBaZahlungswegIDChanged(EventArgs e)
        {
            if (BaZahlungswegIDChanged != null) BaZahlungswegIDChanged(this, e);
        }

        private void btnEditSearch_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.btnEditSearch.Properties.ReadOnly) return;

            if (e.Button.Caption == "Delete")
                ReinitializeControl();
        }

        private void btnEditSearch_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            if (!SucheBaZahlungsweg(btnEditSearch.Text))
                e.Cancel = true;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="baZahlungswegID">The ba zahlungsweg ID.</param>
        private void LoadData(object baZahlungswegID)
        {
            this.qryBaZahlungsweg.Fill(baZahlungswegID);
            if (qryBaZahlungsweg.Count == 0)
            {
                this.btnEditSearch.EditValue = DBNull.Value;
            }
            else
            {
                this.btnEditSearch.EditValue = qryBaZahlungsweg["Kreditor"];
            }

            this.OnBaZahlungswegIDChanged(EventArgs.Empty);
        }

        private void ReinitializeControl()
        {
            this.BaZahlungswegID = null;
        }

        private bool SucheBaZahlungsweg(string SearchParam)
        {
            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
            dlg.SucheBaZahlungsweg(SearchParam);
            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // set ZahlungsWeg Informations
                    this.BaZahlungswegID = dlg.BaZahlungswegID;
                    return true;
                }
            }
            finally
            {
                dlg.Dispose();
            }
            return false;
        }

        #region IKissBindableEdit Functions

        void IKissBindableEdit.AllowEdit(bool value)
        {
            ((IKissBindableEdit)this.btnEditSearch).AllowEdit(value);

            if (ButtonPressedDelegate == null)
                ButtonPressedDelegate = new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnEditSearch_Click);

            this.btnEditSearch.ButtonClick -= ButtonPressedDelegate;
            if (this.btnEditSearch.Enabled)
                this.btnEditSearch.ButtonClick += ButtonPressedDelegate;
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "BaZahlungswegID";
        }

        private void CtlZahlungsweg_Resize(object sender, System.EventArgs e)
        {
            this.SuspendLayout();

            switch (this.layoutNr)
            {
                case 2:
                    edtKreditor.Height = this.Height / 2 - edtKreditor.Top - 3;

                    lblZahlungsweg.Top = this.Height / 2;
                    edtZahlungsweg.Top = lblZahlungsweg.Top;
                    edtZahlungsweg.Height = this.Height / 2;
                    break;

                default:
                    edtKreditor.Width = this.Width / 2;
                    edtKreditor.Height = this.Height - edtKreditor.Top;

                    lblZahlungsweg.Left = this.Width / 2 - 1;
                    edtZahlungsweg.Left = this.Width / 2 - 1;
                    edtZahlungsweg.Width = this.Width / 2 + 1;
                    edtZahlungsweg.Height = this.Height - edtZahlungsweg.Top;
                    break;
            }

            this.ResumeLayout();
        }

        #endregion
    }
}