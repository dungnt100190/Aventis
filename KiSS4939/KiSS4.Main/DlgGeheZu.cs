using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Main
{
	/// <summary>
	/// Summary description for DlgGeheZu.
	/// </summary>
	public class DlgGeheZu
		:
		KiSS4.Gui.KissDialog
	{
		private KiSS4.Gui.KissLabel lblFinanzplan;
		private KiSS4.Gui.KissLabel lblEinzelzahlung;
		private KiSS4.Gui.KissLabel lblFaLeistung;
		private KiSS4.Gui.KissLabel lblTitel;
		private KiSS4.Gui.KissLabel lblSozialhilfe;
		private KiSS4.Gui.KissLabel lblLeistung;
		private KiSS4.Gui.KissLabel lblAsyl;
		private KiSS4.Gui.KissButton btnGeheZu;
		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.Gui.KissCalcEdit edtFaLeistung;
		private KiSS4.Gui.KissCalcEdit edtWhFinanzplan;
		private KiSS4.Gui.KissCalcEdit edtWhEinzelzahlung;
		private KiSS4.Gui.KissCalcEdit edtAyFinanzplan;
		private KiSS4.Gui.KissCalcEdit edtAyEinzelzahlung;

		private string Context = "SFP";
		private KissCalcEdit edtWhFinanzplanSIL;
		private KissLabel lblFinanzplanSIL;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="DlgGeheZu"/> class.
		/// </summary>
		public DlgGeheZu()
		{
			//Required for Windows Form Designer support
			InitializeComponent();

            //Überprüfen, welche Module lizenziert sind und GUIs enabled/disablen.         
            //Sozialhilfe
            bool isLicModuleS = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Sozialhilfe");

            if (!isLicModuleS)
            {
                this.edtWhFinanzplan.EditMode = EditModeType.ReadOnly;
                this.edtWhEinzelzahlung.EditMode = EditModeType.ReadOnly;
                this.edtWhFinanzplanSIL.EditMode = EditModeType.ReadOnly;
            }

		    //Asyl
            bool isLicModuleA = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Asyl");

            if (!isLicModuleA)
            {
                this.edtAyFinanzplan.EditMode = EditModeType.ReadOnly; ;
                this.edtAyEinzelzahlung.EditMode = EditModeType.ReadOnly; ;
            }

            //Fallführung
            bool isLicModuleF = KiSS4.Common.Utils.IsModuleLicensed("KiSS4.Fallfuehrung");
            if(!isLicModuleF)
            {
                this.edtFaLeistung.EditMode = EditModeType.ReadOnly;       
            }            
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnGeheZu = new KiSS4.Gui.KissButton();
            this.lblFinanzplan = new KiSS4.Gui.KissLabel();
            this.edtFaLeistung = new KiSS4.Gui.KissCalcEdit();
            this.edtWhFinanzplan = new KiSS4.Gui.KissCalcEdit();
            this.lblEinzelzahlung = new KiSS4.Gui.KissLabel();
            this.edtWhEinzelzahlung = new KiSS4.Gui.KissCalcEdit();
            this.edtAyFinanzplan = new KiSS4.Gui.KissCalcEdit();
            this.edtAyEinzelzahlung = new KiSS4.Gui.KissCalcEdit();
            this.lblFaLeistung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblSozialhilfe = new KiSS4.Gui.KissLabel();
            this.lblLeistung = new KiSS4.Gui.KissLabel();
            this.lblAsyl = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.edtWhFinanzplanSIL = new KiSS4.Gui.KissCalcEdit();
            this.lblFinanzplanSIL = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhFinanzplan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAyFinanzplan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAyEinzelzahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialhilfe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAsyl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhFinanzplanSIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplanSIL)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeheZu
            // 
            this.btnGeheZu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeheZu.Location = new System.Drawing.Point(222, 230);
            this.btnGeheZu.Name = "btnGeheZu";
            this.btnGeheZu.Size = new System.Drawing.Size(88, 24);
            this.btnGeheZu.TabIndex = 15;
            this.btnGeheZu.Text = "Gehe zu";
            this.btnGeheZu.UseVisualStyleBackColor = false;
            this.btnGeheZu.Click += new System.EventHandler(this.btnGeheZu_Click);
            // 
            // lblFinanzplan
            // 
            this.lblFinanzplan.Location = new System.Drawing.Point(8, 65);
            this.lblFinanzplan.Name = "lblFinanzplan";
            this.lblFinanzplan.Size = new System.Drawing.Size(82, 24);
            this.lblFinanzplan.TabIndex = 2;
            this.lblFinanzplan.Text = "Finanzplan Nr.";
            // 
            // edtFaLeistung
            // 
            this.edtFaLeistung.Location = new System.Drawing.Point(110, 186);
            this.edtFaLeistung.Name = "edtFaLeistung";
            this.edtFaLeistung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaLeistung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaLeistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistung.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFaLeistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaLeistung.Size = new System.Drawing.Size(88, 24);
            this.edtFaLeistung.TabIndex = 13;
            // 
            // edtWhFinanzplan
            // 
            this.edtWhFinanzplan.Location = new System.Drawing.Point(110, 65);
            this.edtWhFinanzplan.Name = "edtWhFinanzplan";
            this.edtWhFinanzplan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWhFinanzplan.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhFinanzplan.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhFinanzplan.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhFinanzplan.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhFinanzplan.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhFinanzplan.Properties.Appearance.Options.UseFont = true;
            this.edtWhFinanzplan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWhFinanzplan.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhFinanzplan.Size = new System.Drawing.Size(88, 24);
            this.edtWhFinanzplan.TabIndex = 3;
            // 
            // lblEinzelzahlung
            // 
            this.lblEinzelzahlung.Location = new System.Drawing.Point(8, 95);
            this.lblEinzelzahlung.Name = "lblEinzelzahlung";
            this.lblEinzelzahlung.Size = new System.Drawing.Size(96, 24);
            this.lblEinzelzahlung.TabIndex = 4;
            this.lblEinzelzahlung.Text = "EZ oder ZL Nr.";
            // 
            // edtWhEinzelzahlung
            // 
            this.edtWhEinzelzahlung.Location = new System.Drawing.Point(110, 95);
            this.edtWhEinzelzahlung.Name = "edtWhEinzelzahlung";
            this.edtWhEinzelzahlung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWhEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhEinzelzahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhEinzelzahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhEinzelzahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhEinzelzahlung.Properties.Appearance.Options.UseFont = true;
            this.edtWhEinzelzahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWhEinzelzahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhEinzelzahlung.Size = new System.Drawing.Size(88, 24);
            this.edtWhEinzelzahlung.TabIndex = 5;
            // 
            // edtAyFinanzplan
            // 
            this.edtAyFinanzplan.Location = new System.Drawing.Point(222, 65);
            this.edtAyFinanzplan.Name = "edtAyFinanzplan";
            this.edtAyFinanzplan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAyFinanzplan.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAyFinanzplan.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAyFinanzplan.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAyFinanzplan.Properties.Appearance.Options.UseBackColor = true;
            this.edtAyFinanzplan.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAyFinanzplan.Properties.Appearance.Options.UseFont = true;
            this.edtAyFinanzplan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAyFinanzplan.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAyFinanzplan.Size = new System.Drawing.Size(88, 24);
            this.edtAyFinanzplan.TabIndex = 9;
            // 
            // edtAyEinzelzahlung
            // 
            this.edtAyEinzelzahlung.Location = new System.Drawing.Point(222, 95);
            this.edtAyEinzelzahlung.Name = "edtAyEinzelzahlung";
            this.edtAyEinzelzahlung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAyEinzelzahlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAyEinzelzahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAyEinzelzahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAyEinzelzahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAyEinzelzahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAyEinzelzahlung.Properties.Appearance.Options.UseFont = true;
            this.edtAyEinzelzahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAyEinzelzahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAyEinzelzahlung.Size = new System.Drawing.Size(88, 24);
            this.edtAyEinzelzahlung.TabIndex = 10;
            // 
            // lblFaLeistung
            // 
            this.lblFaLeistung.Location = new System.Drawing.Point(8, 186);
            this.lblFaLeistung.Name = "lblFaLeistung";
            this.lblFaLeistung.Size = new System.Drawing.Size(82, 24);
            this.lblFaLeistung.TabIndex = 12;
            this.lblFaLeistung.Text = "Fall Nr.";
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitel.Location = new System.Drawing.Point(8, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(144, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Direktsprung zu ...";
            // 
            // lblSozialhilfe
            // 
            this.lblSozialhilfe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSozialhilfe.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSozialhilfe.Location = new System.Drawing.Point(107, 40);
            this.lblSozialhilfe.Name = "lblSozialhilfe";
            this.lblSozialhilfe.Size = new System.Drawing.Size(64, 16);
            this.lblSozialhilfe.TabIndex = 1;
            this.lblSozialhilfe.Text = "Sozialhilfe";
            // 
            // lblLeistung
            // 
            this.lblLeistung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblLeistung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLeistung.Location = new System.Drawing.Point(107, 167);
            this.lblLeistung.Name = "lblLeistung";
            this.lblLeistung.Size = new System.Drawing.Size(88, 16);
            this.lblLeistung.TabIndex = 11;
            this.lblLeistung.Text = "Fallführung";
            // 
            // lblAsyl
            // 
            this.lblAsyl.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAsyl.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAsyl.Location = new System.Drawing.Point(219, 40);
            this.lblAsyl.Name = "lblAsyl";
            this.lblAsyl.Size = new System.Drawing.Size(64, 16);
            this.lblAsyl.TabIndex = 8;
            this.lblAsyl.Text = "Asyl";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(110, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // edtWhFinanzplanSIL
            // 
            this.edtWhFinanzplanSIL.Location = new System.Drawing.Point(110, 125);
            this.edtWhFinanzplanSIL.Name = "edtWhFinanzplanSIL";
            this.edtWhFinanzplanSIL.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWhFinanzplanSIL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhFinanzplanSIL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhFinanzplanSIL.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhFinanzplanSIL.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhFinanzplanSIL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhFinanzplanSIL.Properties.Appearance.Options.UseFont = true;
            this.edtWhFinanzplanSIL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWhFinanzplanSIL.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhFinanzplanSIL.Size = new System.Drawing.Size(88, 24);
            this.edtWhFinanzplanSIL.TabIndex = 7;
            // 
            // lblFinanzplanSIL
            // 
            this.lblFinanzplanSIL.Location = new System.Drawing.Point(8, 125);
            this.lblFinanzplanSIL.Name = "lblFinanzplanSIL";
            this.lblFinanzplanSIL.Size = new System.Drawing.Size(82, 24);
            this.lblFinanzplanSIL.TabIndex = 6;
            this.lblFinanzplanSIL.Text = "Finanzplan SIL";
            // 
            // DlgGeheZu
            // 
            this.AcceptButton = this.btnGeheZu;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(322, 266);
            this.Controls.Add(this.lblFinanzplanSIL);
            this.Controls.Add(this.edtWhFinanzplanSIL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAsyl);
            this.Controls.Add(this.lblLeistung);
            this.Controls.Add(this.lblSozialhilfe);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtAyEinzelzahlung);
            this.Controls.Add(this.lblFaLeistung);
            this.Controls.Add(this.edtAyFinanzplan);
            this.Controls.Add(this.edtWhEinzelzahlung);
            this.Controls.Add(this.edtWhFinanzplan);
            this.Controls.Add(this.lblEinzelzahlung);
            this.Controls.Add(this.edtFaLeistung);
            this.Controls.Add(this.lblFinanzplan);
            this.Controls.Add(this.btnGeheZu);
            this.Name = "DlgGeheZu";
            this.Text = "Gehe zu ...";
            this.Activated += new System.EventHandler(this.DlgGeheZu_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhFinanzplan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAyFinanzplan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAyEinzelzahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSozialhilfe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAsyl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhFinanzplanSIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplanSIL)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnGeheZu_Click(object sender, System.EventArgs e)
		{
			bool ItemFound = true;
			KissMainForm main = (KissMainForm)Session.MainForm;
			int key = 0;
			string Target1 = null;
			string Target2 = null;

			SqlQuery qry;
			try
			{
				if (!DBUtil.IsEmpty(edtWhFinanzplan.EditValue))
				{
					key = Convert.ToInt32(edtWhFinanzplan.EditValue);
					qry = DBUtil.OpenSQL(@"SELECT FLE.BaPersonID
                                           FROM BgFinanzplan       BFP
                                             INNER JOIN FaLeistung FLE ON FLE.FaLeistungID = BFP.FaLeistungID
                                           WHERE BgFinanzplanID = {0}", key);
					Context = "SFP";
					Target1 = "Der Sozialhilfe-Finanzplan";
					Target2 = "des Sozialhilfe-Finanzplans";
					ItemFound = FormController.OpenForm("FrmFall", "Action", "JumpToPath",
						"BaPersonID", qry["BaPersonID"],
						"ModulID", 3,
						"TreeNodeID", string.Format("CtlWhFinanzplan{0}", key));
				}
				else if (!DBUtil.IsEmpty(edtWhFinanzplanSIL.EditValue))
				{
					key = Convert.ToInt32(edtWhFinanzplanSIL.EditValue);
					qry = DBUtil.OpenSQL(@"
                            SELECT FLE.BaPersonID, BFP.BgFinanzplanID, BBG.BgBudgetID, BBG.MasterBudget, POA.BgGruppeCode, LOV.Value1
                            FROM BgPosition              BPO
                              INNER JOIN BgPositionsart  POA ON POA.BgPositionsartID = BPO.BgPositionsartID
                              INNER JOIN BgBudget        BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                              INNER JOIN BgFinanzplan    BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
                              INNER JOIN FaLeistung      FLE ON FLE.FaLeistungID = BFP.FaLeistungID
                              LEFT  JOIN XLOVCode        LOV ON LOV.LOVName = 'BgGruppe' AND LOV.Code = POA.BgGruppeCode
                            WHERE BgPositionID = {0}", key);

					Context = "SIL";
					Target1 = "Die SIL";
					Target2 = "der SIL";
					// Position öffnen
					FormController.OpenForm("FrmFall", "Action", "JumpToPath",
						 "BaPersonID", qry["BaPersonID"],
						 "ModulID", 3,
						 "TreeNodeID", string.Format("CtlWhFinanzplan{0}/CtlBgUebersicht/SIL/{1}", qry["BgFinanzplanID"], qry["Value1"]),
						 "ActiveSQLQuery.Find", string.Format("BgPositionID = {0}", key));
				}
				else if (!DBUtil.IsEmpty(edtWhEinzelzahlung.EditValue))
				{
					key = Convert.ToInt32(edtWhEinzelzahlung.EditValue);
					qry = DBUtil.OpenSQL(@"SELECT FLE.BaPersonID, BFP.BgFinanzplanID, BBG.BgBudgetID
                                           FROM BgPosition            BPO
                                             INNER JOIN BgBudget      BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                                             INNER JOIN BgFinanzplan  BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
                                             INNER JOIN FaLeistung    FLE ON FLE.FaLeistungID = BFP.FaLeistungID
                                           WHERE BgPositionID = {0}", key);

					Context = "SEZ";
					Target1 = "Die Sozialhilfe-Einzelzahlung";
					Target2 = "der Sozialhilfe-Einzelzahlung";
					ItemFound = FormController.OpenForm("FrmFall", "Action", "JumpToPath",
						 "BaPersonID", qry["BaPersonID"],
						 "ModulID", 3,
						 "TreeNodeID", string.Format("CtlWhFinanzplan{0}\\BBG{1}", qry["BgFinanzplanID"], qry["BgBudgetID"]),
						 "ActiveSQLQuery.Find", string.Format("BgPositionID = {0}", key));
				}

				// TODO
				else if (!DBUtil.IsEmpty(edtAyFinanzplan.EditValue))
				{
					Context = "AFP";
					key = Convert.ToInt32(edtAyFinanzplan.EditValue);
					Target1 = "Der Asyl-Finanzplan";
					Target2 = "des Asyl-Finanzplans";
                    ItemFound = main.ShowItem(ModulID.A, Context, key);
				}

				// TODO
				else if (!DBUtil.IsEmpty(edtAyEinzelzahlung.EditValue))
				{
					Context = "AEZ";
					key = Convert.ToInt32(edtAyEinzelzahlung.EditValue);
					Target1 = "Die Asyl-Einzelzahlung";
					Target2 = "der Asyl-Einzelzahlung";
                    ItemFound = main.ShowItem(ModulID.A, Context, key);
				}

				// TODO: je nach ModulID Ctl bestimmen! / ModulID mitgeben
				else if (!DBUtil.IsEmpty(edtFaLeistung.EditValue))
				{
					key = Convert.ToInt32(edtFaLeistung.EditValue);
					qry = DBUtil.OpenSQL(@"SELECT BaPersonID, FaLeistungID
                                           FROM FaLeistung
                                           WHERE FaLeistungID = {0} AND ModulID = 2", key);

					Context = "FAL";
					Target1 = "Die Fallführung";
					Target2 = "der Fallführung";
					ItemFound = FormController.OpenForm("FrmFall", "Action", "JumpToPath",
						"BaPersonID", qry["BaPersonID"],
						"ModulID", 2,
						"TreeNodeID", string.Format("CtlFaBeratungsperiode{0}", qry["FaLeistungID"]));
				}

				if (ItemFound)
				{
					this.Close();
				}
				else
				{
					KissMsg.ShowInfo(
						"DlgGeheZu",
						"NrNichtGefunden",
						"{0} mit der Nummer {1} konnte nicht gefunden werden.",
						0,
						0,
						Target1,
						key);
					SetFocusToContext();
				}
			}
			catch (Exception ex)
			{
				KissMsg.ShowError("DlgGeheZu", "FehlerBeiAufrufNummer", "Beim beim Aufruf {0} mit der Nummer {1} ist ein Fehler aufgetreten.", null, ex, 0, 0, Target2, key);
			}
		}

		private void SetFocusToContext()
		{
			if (DBUtil.IsEmpty(this.Context))
			{
				return;
			}

			switch (this.Context)
			{
				case "SFP": edtWhFinanzplan.Focus(); break;
				case "SIL": edtWhFinanzplanSIL.Focus(); break;
				case "SEZ": edtWhEinzelzahlung.Focus(); break;

				case "AFP": edtAyFinanzplan.Focus(); break;
				case "AEZ": edtAyEinzelzahlung.Focus(); break;

				case "FAL": edtFaLeistung.Focus(); break;
			}
		}

		/// <summary>
		/// Stores the window's Left, Top, Width, Hight properties, then raises the GettingLayout event.
		/// </summary>
		/// <param name="e"></param>
		/// <remarks>Note to inheritors: base implementation must be called.</remarks>
		protected override void OnGettingLayout(
			KissLayoutEventArgs e)
		{
			base.OnGettingLayout(e);

			KissControlLayout cl1 = new KissControlLayout("Context");
			e.Layout.ControlLayouts.Add(cl1);
			SimpleProperty p1 = new SimpleProperty("Value", Context);
			try { cl1.Properties.Add(p1); }
			catch (Exception ex) { e.Errors.Add(new LayoutError(p1, ex)); }
		}

		/// <summary>
		/// Stores the window's Left, Top, Width, Hight properties, then raises the SettingLayout event.
		/// </summary>
		/// <param name="e"></param>
		/// <remarks>Note to inheritors: base implementation must be called.</remarks>
		protected override void OnSettingLayout(
			KissLayoutEventArgs e)
		{
			base.OnSettingLayout(e);

			KissControlLayout cl1;
			SimpleProperty p1;

			try
			{
				cl1 = e.Layout.ControlLayouts["Context"];
			}
			catch
			{
				cl1 = null;
			}

			if (cl1 != null)
			{
				try
				{
					p1 = (SimpleProperty)cl1.Properties["Value"];
					try { this.Context = (string)p1.Value; }
					catch (Exception ex) { e.Errors.Add(new LayoutError(p1, ex)); }
				}
				catch
				{
				}
			}
		}

		private void DlgGeheZu_Activated(object sender, System.EventArgs e)
		{
			SetFocusToContext();
		}
	}
}
