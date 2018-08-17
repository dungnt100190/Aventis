using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public class DlgBfsNeuesDossier : KiSS4.Gui.KissDialog
    {
        #region Fields

        private bool bStichtag;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissTextEdit edtAntragstellerNeu;
        private KiSS4.Gui.KissCalcEdit edtJahrNeu;
        private KiSS4.Gui.KissLookUpEdit edtLeistungArtNeu;
        private KiSS4.Gui.KissButtonEdit edtMitarbeiterNeu;
        private KiSS4.Gui.KissCheckEdit edtStichtagNeu;
        private int iJahr;
        private int iLeistungsart;
        private int iMitarbeiter;
        private int iGemeinde;
        private KiSS4.Gui.KissLabel lblAntragstellerNeu;
        private KiSS4.Gui.KissLabel lblJahrNeu;
        private KiSS4.Gui.KissLabel lblLeistungArtNeu;
        private KiSS4.Gui.KissLabel lblMitarbeiterNeu;
        private KissLabel lblZustaendigeGemeinde;
        private KissLookUpEdit edtZustaendigeGemeinde;
        private string sAntragsteller;

        #endregion

        #region Constructors

        public DlgBfsNeuesDossier()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtJahrNeu = new KiSS4.Gui.KissCalcEdit();
            this.edtStichtagNeu = new KiSS4.Gui.KissCheckEdit();
            this.edtLeistungArtNeu = new KiSS4.Gui.KissLookUpEdit();
            this.edtAntragstellerNeu = new KiSS4.Gui.KissTextEdit();
            this.edtMitarbeiterNeu = new KiSS4.Gui.KissButtonEdit();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.lblLeistungArtNeu = new KiSS4.Gui.KissLabel();
            this.lblMitarbeiterNeu = new KiSS4.Gui.KissLabel();
            this.lblJahrNeu = new KiSS4.Gui.KissLabel();
            this.lblAntragstellerNeu = new KiSS4.Gui.KissLabel();
            this.lblZustaendigeGemeinde = new KiSS4.Gui.KissLabel();
            this.edtZustaendigeGemeinde = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahrNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtagNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungArtNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungArtNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragstellerNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungArtNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahrNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragstellerNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtJahrNeu
            // 
            this.edtJahrNeu.Location = new System.Drawing.Point(94, 11);
            this.edtJahrNeu.Name = "edtJahrNeu";
            this.edtJahrNeu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahrNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahrNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahrNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahrNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahrNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahrNeu.Properties.Appearance.Options.UseFont = true;
            this.edtJahrNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahrNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahrNeu.Properties.Mask.EditMask = "####";
            this.edtJahrNeu.Size = new System.Drawing.Size(63, 24);
            this.edtJahrNeu.TabIndex = 0;
            // 
            // edtStichtagNeu
            // 
            this.edtStichtagNeu.EditValue = true;
            this.edtStichtagNeu.Location = new System.Drawing.Point(173, 14);
            this.edtStichtagNeu.Name = "edtStichtagNeu";
            this.edtStichtagNeu.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtStichtagNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichtagNeu.Properties.Caption = "Stichtag";
            this.edtStichtagNeu.Size = new System.Drawing.Size(75, 19);
            this.edtStichtagNeu.TabIndex = 1;
            // 
            // edtLeistungArtNeu
            // 
            this.edtLeistungArtNeu.Location = new System.Drawing.Point(94, 41);
            this.edtLeistungArtNeu.Name = "edtLeistungArtNeu";
            this.edtLeistungArtNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistungArtNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungArtNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungArtNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistungArtNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistungArtNeu.Properties.Appearance.Options.UseFont = true;
            this.edtLeistungArtNeu.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLeistungArtNeu.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungArtNeu.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLeistungArtNeu.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLeistungArtNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLeistungArtNeu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLeistungArtNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistungArtNeu.Properties.NullText = "";
            this.edtLeistungArtNeu.Properties.ShowFooter = false;
            this.edtLeistungArtNeu.Properties.ShowHeader = false;
            this.edtLeistungArtNeu.Size = new System.Drawing.Size(304, 24);
            this.edtLeistungArtNeu.TabIndex = 2;
            // 
            // edtAntragstellerNeu
            // 
            this.edtAntragstellerNeu.Location = new System.Drawing.Point(94, 71);
            this.edtAntragstellerNeu.Name = "edtAntragstellerNeu";
            this.edtAntragstellerNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAntragstellerNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAntragstellerNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAntragstellerNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtAntragstellerNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAntragstellerNeu.Properties.Appearance.Options.UseFont = true;
            this.edtAntragstellerNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAntragstellerNeu.Size = new System.Drawing.Size(304, 24);
            this.edtAntragstellerNeu.TabIndex = 3;
            // 
            // edtMitarbeiterNeu
            // 
            this.edtMitarbeiterNeu.Location = new System.Drawing.Point(94, 101);
            this.edtMitarbeiterNeu.Name = "edtMitarbeiterNeu";
            this.edtMitarbeiterNeu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitarbeiterNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiterNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiterNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiterNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiterNeu.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiterNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtMitarbeiterNeu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtMitarbeiterNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMitarbeiterNeu.Size = new System.Drawing.Size(304, 24);
            this.edtMitarbeiterNeu.TabIndex = 4;
            this.edtMitarbeiterNeu.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMitarbeiterNeu_UserModifiedFld);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(212, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 24);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(308, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblLeistungArtNeu
            // 
            this.lblLeistungArtNeu.Location = new System.Drawing.Point(6, 41);
            this.lblLeistungArtNeu.Name = "lblLeistungArtNeu";
            this.lblLeistungArtNeu.Size = new System.Drawing.Size(85, 24);
            this.lblLeistungArtNeu.TabIndex = 25;
            this.lblLeistungArtNeu.Text = "Leistungsart";
            this.lblLeistungArtNeu.UseCompatibleTextRendering = true;
            // 
            // lblMitarbeiterNeu
            // 
            this.lblMitarbeiterNeu.Location = new System.Drawing.Point(6, 101);
            this.lblMitarbeiterNeu.Name = "lblMitarbeiterNeu";
            this.lblMitarbeiterNeu.Size = new System.Drawing.Size(82, 24);
            this.lblMitarbeiterNeu.TabIndex = 26;
            this.lblMitarbeiterNeu.Text = "Mitarbeiter/in";
            this.lblMitarbeiterNeu.UseCompatibleTextRendering = true;
            // 
            // lblJahrNeu
            // 
            this.lblJahrNeu.Location = new System.Drawing.Point(6, 11);
            this.lblJahrNeu.Name = "lblJahrNeu";
            this.lblJahrNeu.Size = new System.Drawing.Size(85, 24);
            this.lblJahrNeu.TabIndex = 27;
            this.lblJahrNeu.Text = "Jahr";
            this.lblJahrNeu.UseCompatibleTextRendering = true;
            // 
            // lblAntragstellerNeu
            // 
            this.lblAntragstellerNeu.Location = new System.Drawing.Point(6, 71);
            this.lblAntragstellerNeu.Name = "lblAntragstellerNeu";
            this.lblAntragstellerNeu.Size = new System.Drawing.Size(85, 24);
            this.lblAntragstellerNeu.TabIndex = 32;
            this.lblAntragstellerNeu.Text = "Antragsteller";
            this.lblAntragstellerNeu.UseCompatibleTextRendering = true;
            // 
            // lblZustaendigeGemeinde
            // 
            this.lblZustaendigeGemeinde.Location = new System.Drawing.Point(6, 131);
            this.lblZustaendigeGemeinde.Name = "lblZustaendigeGemeinde";
            this.lblZustaendigeGemeinde.Size = new System.Drawing.Size(85, 24);
            this.lblZustaendigeGemeinde.TabIndex = 33;
            this.lblZustaendigeGemeinde.Text = "Zust. Gemeinde";
            this.lblZustaendigeGemeinde.UseCompatibleTextRendering = true;
            // 
            // edtZustaendigeGemeinde
            // 
            this.edtZustaendigeGemeinde.Location = new System.Drawing.Point(94, 131);
            this.edtZustaendigeGemeinde.Name = "edtZustaendigeGemeinde";
            this.edtZustaendigeGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigeGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtZustaendigeGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeinde.Properties.NullText = "";
            this.edtZustaendigeGemeinde.Properties.ShowFooter = false;
            this.edtZustaendigeGemeinde.Properties.ShowHeader = false;
            this.edtZustaendigeGemeinde.Size = new System.Drawing.Size(304, 24);
            this.edtZustaendigeGemeinde.TabIndex = 5;
            // 
            // DlgBfsNeuesDossier
            // 
            this.ClientSize = new System.Drawing.Size(407, 206);
            this.Controls.Add(this.edtZustaendigeGemeinde);
            this.Controls.Add(this.lblZustaendigeGemeinde);
            this.Controls.Add(this.lblAntragstellerNeu);
            this.Controls.Add(this.lblJahrNeu);
            this.Controls.Add(this.lblMitarbeiterNeu);
            this.Controls.Add(this.lblLeistungArtNeu);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.edtMitarbeiterNeu);
            this.Controls.Add(this.edtAntragstellerNeu);
            this.Controls.Add(this.edtLeistungArtNeu);
            this.Controls.Add(this.edtStichtagNeu);
            this.Controls.Add(this.edtJahrNeu);
            this.Name = "DlgBfsNeuesDossier";
            this.Text = "Neues Dossier";
            this.Load += new System.EventHandler(this.DlgBfsNeuesDossier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtJahrNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtagNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungArtNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungArtNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAntragstellerNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiterNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungArtNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahrNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAntragstellerNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Public Properties

        public string Antragsteller
        {
            get {return sAntragsteller;}
            set {sAntragsteller = value;}
        }

        public int Jahr
        {
            get {return iJahr;}
            set
            {
                iJahr = value;
                edtJahrNeu.EditValue = iJahr;
            }
        }

        public int Leistungsart
        {
            get {return iLeistungsart;}
            set {iLeistungsart = value;}
        }

        public int Mitarbeiter
        {
            get {return iMitarbeiter;}
            set {iMitarbeiter = value;}
        }

        public bool Stichtag
        {
            get {return bStichtag;}
            set {bStichtag = value;}
        }

        public int Gemeinde
        {
            get { return iGemeinde; }
            set { iGemeinde = value; }
        }


        #endregion

        #region Private Methods

        private void DlgBfsNeuesDossier_Load(object sender, System.EventArgs e)
        {
            edtMitarbeiterNeu.LookupSQL = @"
            ----
            SELECT Code = LastName + isNull(', ' + FirstName, '') FROM XUser WHERE UserID = {0}";

            SqlQuery qry = DBUtil.OpenSQL(@"SELECT Code, Text, *
                               FROM dbo.BFSLOVCode LOV WITH (READUNCOMMITTED)
                               WHERE LOV.LOVName = 'BFSLeistungsart'");
            edtLeistungArtNeu.LoadQuery(qry);

            qry = DBUtil.OpenSQL(@"SELECT Code, Text FROM dbo.BFSLOVCode LOV WITH (READUNCOMMITTED) WHERE LOV.LOVName = 'BFSGemeindeSozialdienst'");
            edtZustaendigeGemeinde.LoadQuery(qry);
        }

        private bool IsValidDossier()
        {
            return 0 >= (int) DBUtil.ExecuteScalarSQL(@"SELECT COUNT(*)
                                    FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)
                                      LEFT  JOIN dbo.BFSDossierPerson PRS WITH (READUNCOMMITTED) ON PRS.BFSDossierID = DOS.BFSDossierID
                                    WHERE DOS.Jahr = {0}
                                 	  AND DOS.Stichtag = {1}
                                 	  AND DOS.BFSLeistungsartCode = {2}
                                 	  AND PRS.PersonName = {3}",
                        (int)edtJahrNeu.EditValue, edtStichtagNeu.Checked,
                        (int)edtLeistungArtNeu.EditValue, (string)edtAntragstellerNeu.EditValue);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(edtJahrNeu.EditValue))
                KissMsg.ShowError("DlgBfsNeuesDossier", "JahrLeer", "Jahr darf nicht leer sein!");
            else if (DBUtil.IsEmpty(edtLeistungArtNeu.EditValue))
                KissMsg.ShowError("DlgBfsNeuesDossier", "LeistungsartLeer", "Leistungsart darf nicht leer sein!");
            else if (DBUtil.IsEmpty(edtAntragstellerNeu.EditValue))
                KissMsg.ShowError("DlgBfsNeuesDossier", "AntragstellerLeer", "Antragsteller darf nicht leer sein!");
            else if (DBUtil.IsEmpty(edtMitarbeiterNeu.EditValue))
                KissMsg.ShowError("DlgBfsNeuesDossier", "MitarbeiterLeer", "Mitarbeiter darf nicht leer sein!");
            if (DBUtil.IsEmpty(edtZustaendigeGemeinde.EditValue))
                KissMsg.ShowError("DlgBfsNeuesDossier", "GemeindeLeer", "Gemeinde darf nicht leer sein!");
            else if (!this.IsValidDossier())
                KissMsg.ShowError("DlgBfsNeuesDossier", "DossierUneindeutig", "Es existiert bereits ein Dossier für diesen Antragsteller!");

            else
            {
                Jahr = (int)edtJahrNeu.EditValue;
                Stichtag = edtStichtagNeu.Checked;
                Leistungsart = (int)edtLeistungArtNeu.EditValue;
                Antragsteller = (string)edtAntragstellerNeu.EditValue;
                Mitarbeiter = (int)edtMitarbeiterNeu.LookupID;
                Gemeinde = (int)edtZustaendigeGemeinde.EditValue;

                DialogResult = DialogResult.OK;
            }
        }

        private void edtMitarbeiterNeu_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtMitarbeiterNeu.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtMitarbeiterNeu.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}