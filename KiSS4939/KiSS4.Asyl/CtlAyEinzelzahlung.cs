using System;
using System.Data;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
	public class CtlAyEinzelzahlung : KiSS4.Gui.KissUserControl
	{
		private System.ComponentModel.IContainer components = null;
		private KiSS4.Gui.KissLookUpEdit edtBgZahlungsmodusID;
		private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
		private KiSS4.Gui.KissCalcEdit edtBetrag;
		private KiSS4.Gui.KissDateEdit edtValutaDatum;
		private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
		private KiSS4.DB.SqlQuery qryBgPosition;
		private KiSS4.Gui.KissLabel lblReferenzNummer;
		private KiSS4.Gui.KissLabel lblBgZahlungsmodusID;
		private KiSS4.Gui.KissLabel lblBetrag;
		private KiSS4.Gui.KissLabel lblValutaDatum;
		private KiSS4.Gui.KissRadioGroup optFinanzierung;
		private KiSS4.Gui.KissRadioGroup optVerrechnung;
		private KiSS4.Gui.KissLabel lblVerrechnungGanzeUe;
		private KiSS4.Gui.KissLabel lblVerrechnungPerson;
		private KiSS4.Gui.KissLabel lblFinanzierung;
		private KiSS4.DB.SqlQuery qryBgZalungsmodus;
		private KiSS4.Gui.KissButton btnBgSpezkonto2;
		private KiSS4.Gui.KissButton btnBgSpezkonto3;
		private KiSS4.Gui.KissLabel edtBgPositionID;
		private KiSS4.Gui.KissLabel lblBgPositionID;
		public KiSS4.Common.CtlZahlungsweg ctlZahlungsweg;
		private KiSS4.Gui.KissLabel lblRechnungDatum;
		private KiSS4.Gui.KissDateEdit edtRechnungDatum;
		private KiSS4.Gui.KissTabControlEx TabContainer;
		private SharpLibrary.WinControls.TabPageEx tpgFinanzierung;
		private SharpLibrary.WinControls.TabPageEx tpgVerrechnung;
		private SharpLibrary.WinControls.TabPageEx tpgBemerkung;
		private SharpLibrary.WinControls.TabPageEx tpgZahnarzt;
		private KiSS4.Gui.KissMemoEdit edtBemerkung;
		private KiSS4.Gui.KissLabel lblValue3;
		private KiSS4.Gui.KissLabel lblValue2;
		private KiSS4.Gui.KissLabel lblBgPositionsartID;
		private KiSS4.Gui.KissLabel lblBgGruppeCode;
		private KiSS4.Gui.KissLabel lblBuchungstext;
		private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
		private KiSS4.Gui.KissLookUpEdit edtBgGruppeCode;
		private KiSS4.Gui.KissTextEdit edtBuchungstext;
		private KiSS4.Gui.KissDateEdit edtValue3;
		private KiSS4.Gui.KissDateEdit edtValue2;
		private KiSS4.Gui.KissLabel lblValue1;
		private KiSS4.Gui.KissTextEdit edtValue1;
		private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID1;
		private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID3;
		private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID2;
		private SqlQuery qryBgBudget;
		private SqlQuery qryBgPositionsart;
		private SqlQuery qryBgAuszahlungPerson;
		private SqlQuery qryBgAuszahlungPersonTermin;

		private int BgBudgetID;
		bool loaded = false;

		public CtlAyEinzelzahlung()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent call
			this.TabContainer.SelectedTabIndex = 0;
			this.tpgZahnarzt.HideTab = false;

			// Gruppe
			edtBgGruppeCode.LoadQuery(DBUtil.OpenSQL(@"
				SELECT
				  Code = SPT.BgGruppeCode,
				  Text = MIN(XLC.Text)
				FROM dbo.AyPositionsart   SPT
				  LEFT JOIN dbo.XLOVCode  XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
				WHERE SPT.BgKategorieCode = {0}
				GROUP BY SPT.BgGruppeCode, XLC.SortKey
				ORDER BY XLC.SortKey"
                , (int)BgKategorie.Ausgaben));
		}

		public CtlAyEinzelzahlung(int bgBudgetID) : this()
		{
			this.InitData(bgBudgetID);
		}

		public CtlAyEinzelzahlung(int bgBudgetID, int bgPositionID) : this()
		{
			this.InitData(bgBudgetID, bgPositionID);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		public void InitPermission(int bgBudgetID)
		{
			this.qryBgPosition.CanInsert = true;
			this.qryBgPosition.CanUpdate = true;
			this.qryBgPosition.CanDelete = true;

			this.qryBgPosition.ApplyUserRights();

			qryBgBudget.Fill(bgBudgetID);
			if ((int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Gesperrt)
				AyUtil.SqlQueryEditOff(this.qryBgPosition);

			this.BgBudgetID = bgBudgetID;

			qryBgZalungsmodus = AyUtil.GetZahlungsmodus(this.BgBudgetID, true);
			this.edtBgZahlungsmodusID.LoadQuery(qryBgZalungsmodus, "BgZahlungsmodusID", "NameZahlungsmodus");

			this.edtBaPersonID.LoadQuery(AyUtil.GetPersonen_Unterstuetzt(bgBudgetID), "BaPersonID", "NameVorname");
		}

		public void InitData(int bgBudgetID)
		{
			if (!this.qryBgPosition.Post()) return;
			this.InitPermission(bgBudgetID);

			this.edtBgSpezkontoID3.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Abzahlungskonto), "BgSpezkontoID", "DisplayText");
			this.edtBgSpezkontoID1.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Ausgabekonto), "BgSpezkontoID", "DisplayText");
			this.edtBgSpezkontoID2.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Vorabzugkonto), "BgSpezkontoID", "DisplayText");

			this.qryBgPosition.Fill(0);

			UpdateZahnarztMode();
		}

		public void InitData(int bgBudgetID, int bgPositionID)
		{
			if (!this.qryBgPosition.Post()) return;
			this.InitPermission(bgBudgetID);

			AyUtil.ApplyKbBuchungStatusCodeToSqlQuery_SEZ(this.qryBgPosition, bgPositionID);

			this.edtBgSpezkontoID3.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Abzahlungskonto), "BgSpezkontoID", "DisplayText");
			this.edtBgSpezkontoID1.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Ausgabekonto), "BgSpezkontoID", "DisplayText");
			this.edtBgSpezkontoID2.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Vorabzugkonto), "BgSpezkontoID", "DisplayText");

			this.qryBgPosition.Fill(bgPositionID);

			// Check KbBuchung exists
			if ((int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt)
			{
				SqlQuery qry = DBUtil.OpenSQL(@"
					SELECT FLB.Betrag
					FROM dbo.KbBuchung                   FLB
					  INNER JOIN dbo.KbBuchungKostenart  FLS ON FLS.KbBuchungID = FLB.KbBuchungID
					WHERE FLB.BgBudgetID = {0} AND FLS.BgPositionID = {1} AND FLB.KbBuchungStatusCode <> 1"
                    , this.qryBgPosition["BgBudgetID"], this.qryBgPosition["BgPositionID"]);

				if ((int)this.qryBgPosition["Finanzierung"] == 0)
				{
					this.qryBgPosition.CanUpdate = false;
					this.qryBgPosition.CanDelete = false;
					this.qryBgPosition.EnableBoundFields(false);
				}
				else if (qry.Count == 0)
				{
					if (!DBUtil.IsEmpty(this.qryBgPosition["BgSpezkontoID"]) || (int)this.qryBgPosition["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt)
						this.qryBgPosition.RowModified = true;
				}
				else if ((decimal)this.qryBgPosition["Betrag"] > (decimal)qry["Betrag"])
				{  // Einzelzahlung gekürzt für auszahlung Budget
					this.qryBgPosition.CanUpdate = false;
					this.qryBgPosition.CanDelete = false;
					this.qryBgPosition.EnableBoundFields(false);
				}
			}
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyEinzelzahlung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.btnBgSpezkonto3 = new KiSS4.Gui.KissButton();
            this.btnBgSpezkonto2 = new KiSS4.Gui.KissButton();
            this.lblFinanzierung = new KiSS4.Gui.KissLabel();
            this.edtBgSpezkontoID1 = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgSpezkontoID3 = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgSpezkontoID2 = new KiSS4.Gui.KissLookUpEdit();
            this.optFinanzierung = new KiSS4.Gui.KissRadioGroup(this.components);
            this.lblVerrechnungGanzeUe = new KiSS4.Gui.KissLabel();
            this.lblVerrechnungPerson = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.optVerrechnung = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtBgZahlungsmodusID = new KiSS4.Gui.KissLookUpEdit();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.lblBgZahlungsmodusID = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtValutaDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblValutaDatum = new KiSS4.Gui.KissLabel();
            this.edtBgPositionID = new KiSS4.Gui.KissLabel();
            this.lblBgPositionID = new KiSS4.Gui.KissLabel();
            this.lblRechnungDatum = new KiSS4.Gui.KissLabel();
            this.edtRechnungDatum = new KiSS4.Gui.KissDateEdit();
            this.TabContainer = new KiSS4.Gui.KissTabControlEx();
            this.tpgFinanzierung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgVerrechnung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgBemerkung = new SharpLibrary.WinControls.TabPageEx();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.tpgZahnarzt = new SharpLibrary.WinControls.TabPageEx();
            this.lblValue1 = new KiSS4.Gui.KissLabel();
            this.edtValue1 = new KiSS4.Gui.KissTextEdit();
            this.edtValue3 = new KiSS4.Gui.KissDateEdit();
            this.lblValue3 = new KiSS4.Gui.KissLabel();
            this.lblValue2 = new KiSS4.Gui.KissLabel();
            this.edtValue2 = new KiSS4.Gui.KissDateEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.lblBgGruppeCode = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgGruppeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.qryBgAuszahlungPerson = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgAuszahlungPersonTermin = new KiSS4.DB.SqlQuery(this.components);
            this.ctlZahlungsweg = new KiSS4.Common.CtlZahlungsweg();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.qryBgBudget = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optFinanzierung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungGanzeUe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optVerrechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgZahlungsmodusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungDatum.Properties)).BeginInit();
            this.TabContainer.SuspendLayout();
            this.tpgFinanzierung.SuspendLayout();
            this.tpgVerrechnung.SuspendLayout();
            this.tpgBemerkung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            this.tpgZahnarzt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            this.SuspendLayout();
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            // 
            // btnBgSpezkonto3
            // 
            this.btnBgSpezkonto3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgSpezkonto3.IconID = 1;
            this.btnBgSpezkonto3.Location = new System.Drawing.Point(400, 75);
            this.btnBgSpezkonto3.Name = "btnBgSpezkonto3";
            this.btnBgSpezkonto3.Size = new System.Drawing.Size(24, 24);
            this.btnBgSpezkonto3.TabIndex = 8;
            this.btnBgSpezkonto3.UseVisualStyleBackColor = false;
            this.btnBgSpezkonto3.Click += new System.EventHandler(this.btnBgSpezkonto3_Click);
            // 
            // btnBgSpezkonto2
            // 
            this.btnBgSpezkonto2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgSpezkonto2.IconID = 1;
            this.btnBgSpezkonto2.Location = new System.Drawing.Point(400, 52);
            this.btnBgSpezkonto2.Name = "btnBgSpezkonto2";
            this.btnBgSpezkonto2.Size = new System.Drawing.Size(24, 24);
            this.btnBgSpezkonto2.TabIndex = 7;
            this.btnBgSpezkonto2.UseVisualStyleBackColor = false;
            this.btnBgSpezkonto2.Click += new System.EventHandler(this.btnBgSpezkonto2_Click);
            // 
            // lblFinanzierung
            // 
            this.lblFinanzierung.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFinanzierung.Location = new System.Drawing.Point(0, 0);
            this.lblFinanzierung.Name = "lblFinanzierung";
            this.lblFinanzierung.Size = new System.Drawing.Size(428, 24);
            this.lblFinanzierung.TabIndex = 0;
            this.lblFinanzierung.Text = "Finanzierung der Einzelzahlung durch Belastung:";
            // 
            // edtBgSpezkontoID1
            // 
            this.edtBgSpezkontoID1.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID1.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID1.Location = new System.Drawing.Point(136, 98);
            this.edtBgSpezkontoID1.Name = "edtBgSpezkontoID1";
            this.edtBgSpezkontoID1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID1.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID1.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgSpezkontoID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgSpezkontoID1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSpezkonto", "", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "", 20, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID1.Properties.DisplayMember = "DisplayText";
            this.edtBgSpezkontoID1.Properties.NullText = "";
            this.edtBgSpezkontoID1.Properties.ShowFooter = false;
            this.edtBgSpezkontoID1.Properties.ShowHeader = false;
            this.edtBgSpezkontoID1.Properties.ValueMember = "BgSpezkontoID";
            this.edtBgSpezkontoID1.Size = new System.Drawing.Size(256, 24);
            this.edtBgSpezkontoID1.TabIndex = 5;
            // 
            // edtBgSpezkontoID3
            // 
            this.edtBgSpezkontoID3.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID3.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID3.Location = new System.Drawing.Point(136, 75);
            this.edtBgSpezkontoID3.Name = "edtBgSpezkontoID3";
            this.edtBgSpezkontoID3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID3.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID3.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID3.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID3.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID3.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID3.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgSpezkontoID3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgSpezkontoID3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSpezkonto", "", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "", 20, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID3.Properties.DisplayMember = "DisplayText";
            this.edtBgSpezkontoID3.Properties.NullText = "";
            this.edtBgSpezkontoID3.Properties.ShowFooter = false;
            this.edtBgSpezkontoID3.Properties.ShowHeader = false;
            this.edtBgSpezkontoID3.Properties.ValueMember = "BgSpezkontoID";
            this.edtBgSpezkontoID3.Size = new System.Drawing.Size(256, 24);
            this.edtBgSpezkontoID3.TabIndex = 4;
            // 
            // edtBgSpezkontoID2
            // 
            this.edtBgSpezkontoID2.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID2.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID2.Location = new System.Drawing.Point(136, 52);
            this.edtBgSpezkontoID2.Name = "edtBgSpezkontoID2";
            this.edtBgSpezkontoID2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID2.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID2.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgSpezkontoID2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgSpezkontoID2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSpezkonto", "", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "", 20, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID2.Properties.DisplayMember = "DisplayText";
            this.edtBgSpezkontoID2.Properties.NullText = "";
            this.edtBgSpezkontoID2.Properties.ShowFooter = false;
            this.edtBgSpezkontoID2.Properties.ShowHeader = false;
            this.edtBgSpezkontoID2.Properties.ValueMember = "BgSpezkontoID";
            this.edtBgSpezkontoID2.Size = new System.Drawing.Size(256, 24);
            this.edtBgSpezkontoID2.TabIndex = 3;
            // 
            // optFinanzierung
            // 
            this.optFinanzierung.DataMember = "Finanzierung";
            this.optFinanzierung.DataSource = this.qryBgPosition;
            this.optFinanzierung.EditValue = 1;
            this.optFinanzierung.Location = new System.Drawing.Point(0, 20);
            this.optFinanzierung.Name = "optFinanzierung";
            this.optFinanzierung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optFinanzierung.Properties.Appearance.Options.UseBackColor = true;
            this.optFinanzierung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.optFinanzierung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.optFinanzierung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optFinanzierung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "als zusätzliche Leistung"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "eines Vorabzugskonto"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "eines Abzahlungskonto"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "eines Ausgabekonto")});
            this.optFinanzierung.Size = new System.Drawing.Size(152, 112);
            this.optFinanzierung.TabIndex = 1;
            this.optFinanzierung.EditValueChanged += new System.EventHandler(this.optFinanzierung_EditValueChanged);
            // 
            // lblVerrechnungGanzeUe
            // 
            this.lblVerrechnungGanzeUe.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblVerrechnungGanzeUe.Location = new System.Drawing.Point(35, 30);
            this.lblVerrechnungGanzeUe.Name = "lblVerrechnungGanzeUe";
            this.lblVerrechnungGanzeUe.Size = new System.Drawing.Size(368, 16);
            this.lblVerrechnungGanzeUe.TabIndex = 2;
            this.lblVerrechnungGanzeUe.Text = "gleichmässig verrechnet";
            // 
            // lblVerrechnungPerson
            // 
            this.lblVerrechnungPerson.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblVerrechnungPerson.Location = new System.Drawing.Point(35, 70);
            this.lblVerrechnungPerson.Name = "lblVerrechnungPerson";
            this.lblVerrechnungPerson.Size = new System.Drawing.Size(368, 16);
            this.lblVerrechnungPerson.TabIndex = 3;
            this.lblVerrechnungPerson.Text = "Unterstützungseinheit verrechnet:";
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(39, 93);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(376, 24);
            this.edtBaPersonID.TabIndex = 0;
            // 
            // optVerrechnung
            // 
            this.optVerrechnung.DataMember = "Verrechnung";
            this.optVerrechnung.DataSource = this.qryBgPosition;
            this.optVerrechnung.EditValue = false;
            this.optVerrechnung.Location = new System.Drawing.Point(16, 0);
            this.optVerrechnung.Name = "optVerrechnung";
            this.optVerrechnung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optVerrechnung.Properties.Appearance.Options.UseBackColor = true;
            this.optVerrechnung.Properties.Appearance.Options.UseTextOptions = true;
            this.optVerrechnung.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.optVerrechnung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.optVerrechnung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.optVerrechnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optVerrechnung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Die Einzelzahlung wird allen Personen aus der Unterstützungseinheit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Die Einzelzahlung wird nur der folgenden Person aus der")});
            this.optVerrechnung.Size = new System.Drawing.Size(392, 88);
            this.optVerrechnung.TabIndex = 1;
            this.optVerrechnung.EditValueChanged += new System.EventHandler(this.optVerrechnung_EditValueChanged);
            // 
            // edtBgZahlungsmodusID
            // 
            this.edtBgZahlungsmodusID.DataMember = "BgZahlungsmodusID";
            this.edtBgZahlungsmodusID.DataSource = this.qryBgPosition;
            this.edtBgZahlungsmodusID.Location = new System.Drawing.Point(80, 118);
            this.edtBgZahlungsmodusID.Name = "edtBgZahlungsmodusID";
            this.edtBgZahlungsmodusID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgZahlungsmodusID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgZahlungsmodusID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgZahlungsmodusID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgZahlungsmodusID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgZahlungsmodusID.Properties.Appearance.Options.UseFont = true;
            this.edtBgZahlungsmodusID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgZahlungsmodusID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgZahlungsmodusID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgZahlungsmodusID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgZahlungsmodusID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtBgZahlungsmodusID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtBgZahlungsmodusID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgZahlungsmodusID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameZahlungsmodus")});
            this.edtBgZahlungsmodusID.Properties.DisplayMember = "NameZahlungsmodus";
            this.edtBgZahlungsmodusID.Properties.NullText = "";
            this.edtBgZahlungsmodusID.Properties.ShowFooter = false;
            this.edtBgZahlungsmodusID.Properties.ShowHeader = false;
            this.edtBgZahlungsmodusID.Properties.ValueMember = "BgZahlungsmodusID";
            this.edtBgZahlungsmodusID.Size = new System.Drawing.Size(360, 24);
            this.edtBgZahlungsmodusID.TabIndex = 13;
            this.edtBgZahlungsmodusID.EditValueChanged += new System.EventHandler(this.edtBgZahlungsmodusID_EditValueChanged);
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Location = new System.Drawing.Point(0, 307);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(72, 24);
            this.lblReferenzNummer.TabIndex = 15;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            // 
            // lblBgZahlungsmodusID
            // 
            this.lblBgZahlungsmodusID.Location = new System.Drawing.Point(0, 118);
            this.lblBgZahlungsmodusID.Name = "lblBgZahlungsmodusID";
            this.lblBgZahlungsmodusID.Size = new System.Drawing.Size(88, 24);
            this.lblBgZahlungsmodusID.TabIndex = 12;
            this.lblBgZahlungsmodusID.Text = "Zahlungsmodus";
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(80, 5);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtBetrag.TabIndex = 0;
            // 
            // edtValutaDatum
            // 
            this.edtValutaDatum.DataMember = "ValutaDatum";
            this.edtValutaDatum.DataSource = this.qryBgPosition;
            this.edtValutaDatum.EditValue = null;
            this.edtValutaDatum.Location = new System.Drawing.Point(352, 5);
            this.edtValutaDatum.Name = "edtValutaDatum";
            this.edtValutaDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValutaDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValutaDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValutaDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValutaDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValutaDatum.Properties.Appearance.Options.UseFont = true;
            this.edtValutaDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtValutaDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValutaDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtValutaDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValutaDatum.Properties.ShowToday = false;
            this.edtValutaDatum.Size = new System.Drawing.Size(90, 24);
            this.edtValutaDatum.TabIndex = 2;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(0, 5);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(40, 24);
            this.lblBetrag.TabIndex = 2;
            this.lblBetrag.Text = "Betrag";
            // 
            // lblValutaDatum
            // 
            this.lblValutaDatum.Location = new System.Drawing.Point(313, 5);
            this.lblValutaDatum.Name = "lblValutaDatum";
            this.lblValutaDatum.Size = new System.Drawing.Size(32, 24);
            this.lblValutaDatum.TabIndex = 4;
            this.lblValutaDatum.Text = "Valuta";
            // 
            // edtBgPositionID
            // 
            this.edtBgPositionID.DataMember = "BgPositionID";
            this.edtBgPositionID.DataSource = this.qryBgPosition;
            this.edtBgPositionID.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtBgPositionID.Location = new System.Drawing.Point(488, 9);
            this.edtBgPositionID.Name = "edtBgPositionID";
            this.edtBgPositionID.Size = new System.Drawing.Size(84, 16);
            this.edtBgPositionID.TabIndex = 18;
            // 
            // lblBgPositionID
            // 
            this.lblBgPositionID.Location = new System.Drawing.Point(448, 5);
            this.lblBgPositionID.Name = "lblBgPositionID";
            this.lblBgPositionID.Size = new System.Drawing.Size(84, 24);
            this.lblBgPositionID.TabIndex = 17;
            this.lblBgPositionID.Text = "Beleg:";
            // 
            // lblRechnungDatum
            // 
            this.lblRechnungDatum.Location = new System.Drawing.Point(168, 5);
            this.lblRechnungDatum.Name = "lblRechnungDatum";
            this.lblRechnungDatum.Size = new System.Drawing.Size(48, 24);
            this.lblRechnungDatum.TabIndex = 3;
            this.lblRechnungDatum.Text = "R-Datum";
            // 
            // edtRechnungDatum
            // 
            this.edtRechnungDatum.DataMember = "RechnungDatum";
            this.edtRechnungDatum.DataSource = this.qryBgPosition;
            this.edtRechnungDatum.EditValue = null;
            this.edtRechnungDatum.Location = new System.Drawing.Point(216, 5);
            this.edtRechnungDatum.Name = "edtRechnungDatum";
            this.edtRechnungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechnungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtRechnungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechnungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtRechnungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungDatum.Properties.ShowToday = false;
            this.edtRechnungDatum.Size = new System.Drawing.Size(90, 24);
            this.edtRechnungDatum.TabIndex = 1;
            // 
            // TabContainer
            // 
            this.TabContainer.Controls.Add(this.tpgFinanzierung);
            this.TabContainer.Controls.Add(this.tpgVerrechnung);
            this.TabContainer.Controls.Add(this.tpgBemerkung);
            this.TabContainer.Controls.Add(this.tpgZahnarzt);
            this.TabContainer.Location = new System.Drawing.Point(448, 29);
            this.TabContainer.Name = "TabContainer";
            this.TabContainer.ShowFixedWidthTooltip = true;
            this.TabContainer.Size = new System.Drawing.Size(440, 302);
            this.TabContainer.TabIndex = 20;
            this.TabContainer.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgFinanzierung,
            this.tpgVerrechnung,
            this.tpgBemerkung,
            this.tpgZahnarzt});
            this.TabContainer.TabsLineColor = System.Drawing.Color.Black;
            this.TabContainer.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.TabContainer.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.TabContainer.Text = "kissTabControlEx1";
            // 
            // tpgFinanzierung
            // 
            this.tpgFinanzierung.Controls.Add(this.lblFinanzierung);
            this.tpgFinanzierung.Controls.Add(this.btnBgSpezkonto3);
            this.tpgFinanzierung.Controls.Add(this.btnBgSpezkonto2);
            this.tpgFinanzierung.Controls.Add(this.edtBgSpezkontoID1);
            this.tpgFinanzierung.Controls.Add(this.edtBgSpezkontoID3);
            this.tpgFinanzierung.Controls.Add(this.edtBgSpezkontoID2);
            this.tpgFinanzierung.Controls.Add(this.optFinanzierung);
            this.tpgFinanzierung.Location = new System.Drawing.Point(6, 32);
            this.tpgFinanzierung.Name = "tpgFinanzierung";
            this.tpgFinanzierung.Size = new System.Drawing.Size(428, 264);
            this.tpgFinanzierung.TabIndex = 0;
            this.tpgFinanzierung.Title = "Finanzierung";
            // 
            // tpgVerrechnung
            // 
            this.tpgVerrechnung.Controls.Add(this.lblVerrechnungGanzeUe);
            this.tpgVerrechnung.Controls.Add(this.lblVerrechnungPerson);
            this.tpgVerrechnung.Controls.Add(this.edtBaPersonID);
            this.tpgVerrechnung.Controls.Add(this.optVerrechnung);
            this.tpgVerrechnung.Location = new System.Drawing.Point(6, 32);
            this.tpgVerrechnung.Name = "tpgVerrechnung";
            this.tpgVerrechnung.Size = new System.Drawing.Size(428, 264);
            this.tpgVerrechnung.TabIndex = 1;
            this.tpgVerrechnung.Title = "Verrechnung";
            // 
            // tpgBemerkung
            // 
            this.tpgBemerkung.Controls.Add(this.edtBemerkung);
            this.tpgBemerkung.Location = new System.Drawing.Point(6, 32);
            this.tpgBemerkung.Name = "tpgBemerkung";
            this.tpgBemerkung.Size = new System.Drawing.Size(428, 264);
            this.tpgBemerkung.TabIndex = 2;
            this.tpgBemerkung.Title = "Bemerkung";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtBemerkung.Location = new System.Drawing.Point(0, 0);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(428, 264);
            this.edtBemerkung.TabIndex = 1;
            // 
            // tpgZahnarzt
            // 
            this.tpgZahnarzt.Controls.Add(this.lblValue1);
            this.tpgZahnarzt.Controls.Add(this.edtValue1);
            this.tpgZahnarzt.Controls.Add(this.edtValue3);
            this.tpgZahnarzt.Controls.Add(this.lblValue3);
            this.tpgZahnarzt.Controls.Add(this.lblValue2);
            this.tpgZahnarzt.Controls.Add(this.edtValue2);
            this.tpgZahnarzt.Location = new System.Drawing.Point(6, 32);
            this.tpgZahnarzt.Name = "tpgZahnarzt";
            this.tpgZahnarzt.Size = new System.Drawing.Size(428, 264);
            this.tpgZahnarzt.TabIndex = 0;
            this.tpgZahnarzt.Title = "Zahnarzt";
            // 
            // lblValue1
            // 
            this.lblValue1.Location = new System.Drawing.Point(8, 8);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(96, 24);
            this.lblValue1.TabIndex = 0;
            this.lblValue1.Text = "Zahnarzt/-in";
            // 
            // edtValue1
            // 
            this.edtValue1.DataMember = "Value1";
            this.edtValue1.DataSource = this.qryBgPosition;
            this.edtValue1.Location = new System.Drawing.Point(112, 8);
            this.edtValue1.Name = "edtValue1";
            this.edtValue1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValue1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValue1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValue1.Properties.Appearance.Options.UseBackColor = true;
            this.edtValue1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValue1.Properties.Appearance.Options.UseFont = true;
            this.edtValue1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtValue1.Size = new System.Drawing.Size(304, 24);
            this.edtValue1.TabIndex = 1;
            // 
            // edtValue3
            // 
            this.edtValue3.DataMember = "Value3";
            this.edtValue3.DataSource = this.qryBgPosition;
            this.edtValue3.EditValue = null;
            this.edtValue3.Location = new System.Drawing.Point(240, 40);
            this.edtValue3.Name = "edtValue3";
            this.edtValue3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValue3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValue3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValue3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValue3.Properties.Appearance.Options.UseBackColor = true;
            this.edtValue3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValue3.Properties.Appearance.Options.UseFont = true;
            this.edtValue3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtValue3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValue3.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtValue3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValue3.Properties.ShowToday = false;
            this.edtValue3.Size = new System.Drawing.Size(96, 24);
            this.edtValue3.TabIndex = 5;
            // 
            // lblValue3
            // 
            this.lblValue3.Location = new System.Drawing.Point(216, 40);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(23, 24);
            this.lblValue3.TabIndex = 4;
            this.lblValue3.Text = "bis";
            // 
            // lblValue2
            // 
            this.lblValue2.Location = new System.Drawing.Point(8, 40);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(96, 24);
            this.lblValue2.TabIndex = 2;
            this.lblValue2.Text = "Behandlungsdauer";
            // 
            // edtValue2
            // 
            this.edtValue2.DataMember = "Value2";
            this.edtValue2.DataSource = this.qryBgPosition;
            this.edtValue2.EditValue = null;
            this.edtValue2.Location = new System.Drawing.Point(112, 40);
            this.edtValue2.Name = "edtValue2";
            this.edtValue2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtValue2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtValue2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtValue2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtValue2.Properties.Appearance.Options.UseBackColor = true;
            this.edtValue2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtValue2.Properties.Appearance.Options.UseFont = true;
            this.edtValue2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtValue2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtValue2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtValue2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtValue2.Properties.ShowToday = false;
            this.edtValue2.Size = new System.Drawing.Size(96, 24);
            this.edtValue2.TabIndex = 3;
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Location = new System.Drawing.Point(0, 58);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(88, 24);
            this.lblBgPositionsartID.TabIndex = 8;
            this.lblBgPositionsartID.Text = "Typ";
            // 
            // lblBgGruppeCode
            // 
            this.lblBgGruppeCode.Location = new System.Drawing.Point(0, 35);
            this.lblBgGruppeCode.Name = "lblBgGruppeCode";
            this.lblBgGruppeCode.Size = new System.Drawing.Size(88, 24);
            this.lblBgGruppeCode.TabIndex = 6;
            this.lblBgGruppeCode.Text = "Gruppe";
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(0, 88);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(88, 24);
            this.lblBuchungstext.TabIndex = 10;
            this.lblBuchungstext.Text = "Buchungstext";
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(80, 58);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.edtBgPositionsartID.Properties.DisplayMember = "Name";
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Properties.ValueMember = "BgPositionsartID";
            this.edtBgPositionsartID.Size = new System.Drawing.Size(360, 24);
            this.edtBgPositionsartID.TabIndex = 9;
            this.edtBgPositionsartID.EditValueChanged += new System.EventHandler(this.edtBgPositionsartID_EditValueChanged);
            // 
            // edtBgGruppeCode
            // 
            this.edtBgGruppeCode.DataMember = "BgGruppeCode";
            this.edtBgGruppeCode.DataSource = this.qryBgPosition;
            this.edtBgGruppeCode.Location = new System.Drawing.Point(80, 35);
            this.edtBgGruppeCode.Name = "edtBgGruppeCode";
            this.edtBgGruppeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgGruppeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgGruppeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgGruppeCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgGruppeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgGruppeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgGruppeCode.Properties.DisplayMember = "Text";
            this.edtBgGruppeCode.Properties.NullText = "";
            this.edtBgGruppeCode.Properties.ShowFooter = false;
            this.edtBgGruppeCode.Properties.ShowHeader = false;
            this.edtBgGruppeCode.Properties.ValueMember = "Code";
            this.edtBgGruppeCode.Size = new System.Drawing.Size(360, 24);
            this.edtBgGruppeCode.TabIndex = 7;
            this.edtBgGruppeCode.EditValueChanged += new System.EventHandler(this.edtBgGruppeCode_EditValueChanged);
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(80, 88);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(360, 24);
            this.edtBuchungstext.TabIndex = 11;
            // 
            // qryBgAuszahlungPerson
            // 
            this.qryBgAuszahlungPerson.CanDelete = true;
            this.qryBgAuszahlungPerson.CanInsert = true;
            this.qryBgAuszahlungPerson.CanUpdate = true;
            this.qryBgAuszahlungPerson.HostControl = this;
            this.qryBgAuszahlungPerson.SelectStatement = "SELECT *\r\nFROM BgAuszahlungPerson\r\nWHERE BgPositionID = {0}";
            this.qryBgAuszahlungPerson.TableName = "BgAuszahlungPerson";
            // 
            // qryBgAuszahlungPersonTermin
            // 
            this.qryBgAuszahlungPersonTermin.CanDelete = true;
            this.qryBgAuszahlungPersonTermin.CanInsert = true;
            this.qryBgAuszahlungPersonTermin.CanUpdate = true;
            this.qryBgAuszahlungPersonTermin.HostControl = this;
            this.qryBgAuszahlungPersonTermin.SelectStatement = "SELECT *\r\nFROM BgAuszahlungPersonTermin\r\nWHERE BgAuszahlungPersonID = {0}";
            this.qryBgAuszahlungPersonTermin.TableName = "BgAuszahlungPersonTermin";
            // 
            // ctlZahlungsweg
            // 
            this.ctlZahlungsweg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlZahlungsweg.DataMember = "BaZahlungswegID";
            this.ctlZahlungsweg.DataSource = this.qryBgPosition;
            this.ctlZahlungsweg.LayoutNr = 2;
            this.ctlZahlungsweg.Location = new System.Drawing.Point(0, 145);
            this.ctlZahlungsweg.Modul = KiSS4.Gui.ModulID.A;
            this.ctlZahlungsweg.Name = "ctlZahlungsweg";
            this.ctlZahlungsweg.Size = new System.Drawing.Size(440, 160);
            this.ctlZahlungsweg.TabIndex = 14;
            this.ctlZahlungsweg.BaZahlungswegIDChanged += new System.EventHandler(this.ctlZahlungsweg_ZahlungswegIDChanged);
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryBgPosition;
            this.edtReferenzNummer.Location = new System.Drawing.Point(80, 307);
            this.edtReferenzNummer.Name = "edtReferenzNummer";
            this.edtReferenzNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReferenzNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReferenzNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReferenzNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseFont = true;
            this.edtReferenzNummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReferenzNummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReferenzNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReferenzNummer.Size = new System.Drawing.Size(360, 24);
            this.edtReferenzNummer.TabIndex = 16;
            // 
            // qryBgBudget
            // 
            this.qryBgBudget.SelectStatement = "SELECT * FROM BgBudget WHERE BgbudgetID = {0}";
            // 
            // CtlAyEinzelzahlung
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.edtBgGruppeCode);
            this.Controls.Add(this.edtBuchungstext);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.lblBgGruppeCode);
            this.Controls.Add(this.lblBuchungstext);
            this.Controls.Add(this.TabContainer);
            this.Controls.Add(this.lblRechnungDatum);
            this.Controls.Add(this.edtRechnungDatum);
            this.Controls.Add(this.edtBgPositionID);
            this.Controls.Add(this.lblBgPositionID);
            this.Controls.Add(this.ctlZahlungsweg);
            this.Controls.Add(this.edtBgZahlungsmodusID);
            this.Controls.Add(this.lblValutaDatum);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.edtValutaDatum);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBgZahlungsmodusID);
            this.Controls.Add(this.lblReferenzNummer);
            this.Controls.Add(this.edtReferenzNummer);
            this.Name = "CtlAyEinzelzahlung";
            this.Size = new System.Drawing.Size(888, 335);
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optFinanzierung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungGanzeUe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optVerrechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgZahlungsmodusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValutaDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValutaDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungDatum.Properties)).EndInit();
            this.TabContainer.ResumeLayout(false);
            this.tpgFinanzierung.ResumeLayout(false);
            this.tpgVerrechnung.ResumeLayout(false);
            this.tpgBemerkung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            this.tpgZahnarzt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPersonTermin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
		{
			optFinanzierung_EditValueChanged(sender, EventArgs.Empty);
			optVerrechnung_EditValueChanged(sender, EventArgs.Empty);
		}

		#region Runtime Layout
		private void optFinanzierung_EditValueChanged(object sender, System.EventArgs e)
		{
			int Finanzierung = 0;

            int? finanz;
            if (sender == this.optFinanzierung)
            {
                finanz = this.optFinanzierung.EditValue as int?;
            }
            else
            {
                finanz = this.qryBgPosition[this.optFinanzierung.DataMember] as int?;
            }

            if (finanz.HasValue)
            {
                Finanzierung = finanz.Value;
            }
            else
            {
                this.optFinanzierung.EditValue = 0;
            }

			this.edtBgSpezkontoID2.EditMode = EditModeType.ReadOnly;
			this.btnBgSpezkonto2.Enabled = false;
			this.edtBgSpezkontoID3.EditMode = EditModeType.ReadOnly;
			this.btnBgSpezkonto3.Enabled = false;
			this.edtBgSpezkontoID1.EditMode = EditModeType.ReadOnly;

			if (!this.qryBgPosition.CanUpdate) return;

			switch (Finanzierung)
			{
				case 2:
					this.edtBgSpezkontoID2.EditMode = EditModeType.Normal;
					this.btnBgSpezkonto2.Enabled = this.qryBgPosition.CanUpdate;
					this.btnBgSpezkonto2.BringToFront();
					break;

				case 3:
					this.edtBgSpezkontoID3.EditMode = EditModeType.Normal;
					this.btnBgSpezkonto3.Enabled = this.qryBgPosition.CanUpdate;
					this.btnBgSpezkonto3.BringToFront();
					break;

				case 4:
					this.edtBgSpezkontoID1.EditMode = EditModeType.Normal;
					break;
			}
		}

		private void optVerrechnung_EditValueChanged(object sender, System.EventArgs e)
		{
			bool Verrechnung = false;

			try
			{
				if (sender == this.optVerrechnung)
					Verrechnung = (bool)this.optVerrechnung.EditValue;
				else
					Verrechnung = (bool)this.qryBgPosition[this.optVerrechnung.DataMember];
			}
			catch (Exception)
			{
				this.optVerrechnung.EditValue = false;
			}

			if (!Verrechnung)
			{
				this.edtBaPersonID.EditValue = DBNull.Value;
				this.edtBaPersonID.EditMode = EditModeType.ReadOnly;
			}
			else if (this.qryBgPosition.CanUpdate)
				this.edtBaPersonID.EditMode = EditModeType.Normal;
			else
				this.edtBaPersonID.EditMode = EditModeType.ReadOnly;
		}
		#endregion

		#region ctlZahlungsweg
		private void ctlZahlungsweg_ZahlungswegIDChanged(object sender, System.EventArgs e)
		{
			this.edtReferenzNummer.EditValue = ctlZahlungsweg.ReferenzNummer;

			if (ctlZahlungsweg.VerguetungsBetrag != 0)
				this.edtBetrag.EditValue = Convert.ToDecimal(ctlZahlungsweg.VerguetungsBetrag);
		}
		#endregion

		#region qryBgPosition_Insert
		private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
		{
			this.qryBgPosition["BgBudgetID"] = this.BgBudgetID;
			this.qryBgPosition["Finanzierung"] = 1;
			this.qryBgPosition["Verrechnung"] = 0;

			this.qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Erteilt;

			this.edtRechnungDatum.Focus();
		}
		#endregion

		#region qryBgPosition_Post
		private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
		{
			DBUtil.CheckNotNullField(edtRechnungDatum, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Rechnungsdatum", "Rechnungsdatum"));

			DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
			if ((decimal)this.qryBgPosition["Betrag"] <= (decimal)0)
				throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "BetragZuKlein", "Der Betrag muss grösser als Fr. 0.00 sein.", KissMsgCode.MsgInfo), this.edtBetrag);

			if (this.edtValutaDatum.EditMode != EditModeType.ReadOnly)
				DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);

			DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);

			if (DBUtil.IsEmpty(this.qryBgPosition["BgZahlungsmodusID"]) && DBUtil.IsEmpty(this.qryBgPosition["BaZahlungswegID"]))
				throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "ZahlungsmodusLeer", "Das Feld 'Zahlungsmodus' darf nicht leer bleiben !", KissMsgCode.MsgInfo), this.edtBgZahlungsmodusID);

			if (edtReferenzNummer.EditMode == EditModeType.Normal && !DBUtil.IsEmpty(this.qryBgPosition["ReferenzNummer"])
				&& !this.edtReferenzNummer.ValidateReferenzNummer(this.ctlZahlungsweg.EsrTeilnehmer))
			{
				this.edtReferenzNummer.Focus();
				throw new KissCancelException();
			}

			if ((int)this.qryBgPosition["BgPositionsartID"] == (int)AyPositionsartID.Zahnarzt)
			{
                DBUtil.CheckNotNullField(optVerrechnung, tpgVerrechnung.Title);

				DBUtil.CheckNotNullField(edtValue1, lblValue1.Text);
				DBUtil.CheckNotNullField(edtValue2, lblValue2.Text);
				DBUtil.CheckNotNullField(edtValue3, lblValue2.Text);
			}

            DBUtil.CheckNotNullField(optFinanzierung, tpgFinanzierung.Title);
		
            #region Check - Finanzierung

			if ((int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt && this.qryBgPosition.ColumnModified("Finanzierung") && this.qryBgPosition["Finanzierung"].Equals(0))
				throw new KissErrorException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "BudgetBereitsFreigegeben", "Das Monatbudget wurde bereits freigegeben. Einzelzahlungen vom Grundbedarf sind nicht mehr möglich", KissMsgCode.MsgError), this.optFinanzierung);

			SqlQuery qry;
			DataRow[] rows;

			switch ((int)this.qryBgPosition["Finanzierung"])
			{
				case 0:
					this.qryBgPosition["BgKategorieCode"] = (int)BgKategorie.Einzelzahlung;
					this.qryBgPosition["BgSpezkontoID"] = null;
					this.qryBgPosition["BgPositionsartID"] = null;
					break;

				case 1:
					DBUtil.CheckNotNullField(edtBgPositionsartID, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Finanzierung", "Finanzierung"));
					this.qryBgPosition["BgKategorieCode"] = (int)BgKategorie.ZusaetzlicheLeistung;
					this.qryBgPosition["BgSpezkontoID"] = null;
					break;

				case 2:
                    DBUtil.CheckNotNullField(edtBgSpezkontoID2, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Vorabzugskonto", "Vorabzugskonto"));

					qry = (SqlQuery)this.edtBgSpezkontoID2.Properties.DataSource;
					rows = qry.DataTable.Select("BgSpezkontoID = " + DBUtil.SqlLiteral(this.edtBgSpezkontoID2.EditValue));
					if (rows.Length > 0 && (decimal)this.qryBgPosition["Betrag"] > (decimal)rows[0]["Saldo"])
						throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "DeckungNichtAusreichendVorabzug", "Die Einzelzahlung kann nicht von diesem Vorabzugskonto abgebucht werden, da die Deckung des Vorabzugskontos nicht ausreicht.", KissMsgCode.MsgInfo));

					this.qryBgPosition["BgKategorieCode"] = (int)BgKategorie.Einzelzahlung;
					break;

				case 3:
                    DBUtil.CheckNotNullField(edtBgSpezkontoID3, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Abzahlungskonto", "Abzahlungskonto"));

					qry = (SqlQuery)this.edtBgSpezkontoID3.Properties.DataSource;
					rows = qry.DataTable.Select("BgSpezkontoID = " + DBUtil.SqlLiteral(this.edtBgSpezkontoID3.EditValue));
					if (rows.Length > 0 && (decimal)this.qryBgPosition["Betrag"] > (decimal)rows[0]["Saldo"])
						throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "DeckungNichtAusreichendAbzahlung", "Die Einzelzahlung kann nicht von diesem Abzahlungskonto abgebucht werden, da die Deckung des Abzahlungskontos nicht ausreicht.", KissMsgCode.MsgInfo));

					this.qryBgPosition["BgKategorieCode"] = (int)BgKategorie.Einzelzahlung;
					break;

				case 4:
                    DBUtil.CheckNotNullField(edtBgSpezkontoID1, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Ausgabenkonto", "Ausgabenkonto"));

					qry = (SqlQuery)this.edtBgSpezkontoID1.Properties.DataSource;
					rows = qry.DataTable.Select("BgSpezkontoID = " + DBUtil.SqlLiteral(this.edtBgSpezkontoID1.EditValue));
					if (rows.Length > 0 && (decimal)this.qryBgPosition["Betrag"] > (decimal)rows[0]["Saldo"])
						throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "DeckungNichtAusreichendAusgabe", "Die Einzelzahlung kann nicht von diesem Ausgabenkonto abgebucht werden, da die Deckung des Ausgabenkontos nicht ausreicht.", KissMsgCode.MsgInfo));

					this.qryBgPosition["BgKategorieCode"] = (int)BgKategorie.Einzelzahlung;
					break;
			}
			#endregion

			DBUtil.CheckNotNullField(optVerrechnung, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "Verrechnung", "Verrechnung"));
			if ((bool)qryBgPosition["Verrechnung"])
				DBUtil.CheckNotNullField(edtBaPersonID, KissMsg.GetMLMessage("CtlAyEinzelzahlung", "VerrechnungPerson", "Verrechnung - Person"));

			Session.BeginTransaction();
		}

		private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
		{

            try
            {
                qryBgAuszahlungPerson.Fill(qryBgPosition["BgPositionID"]);
                if (qryBgAuszahlungPerson.Count == 0)
                {
                    qryBgAuszahlungPerson.Insert();
                    qryBgAuszahlungPerson["BgPositionID"] = qryBgPosition["BgPositionID"];
                }

                qryBgAuszahlungPerson["BgZahlungsmodusID"] = qryBgPosition["BgZahlungsmodusID"];
                if (DBUtil.IsEmpty(qryBgAuszahlungPerson["BgZahlungsmodusID"]))
                {
                    qryBgAuszahlungPerson["KbAuszahlungsArtCode"] = 101;
                }
                else
                {
                    DataRow[] rows = qryBgZalungsmodus.DataTable.Select(string.Format("BgZahlungsmodusID = {0}", qryBgAuszahlungPerson["BgZahlungsmodusID"]));
                    if (rows.Length == 1)
                    {
                        qryBgAuszahlungPerson["KbAuszahlungsArtCode"] = rows[0]["KbAuszahlungsArtCode"];
                    }
                }

                qryBgAuszahlungPerson["BaZahlungswegID"] = qryBgPosition["BaZahlungswegID"];
                qryBgAuszahlungPerson["ReferenzNummer"] = qryBgPosition["ReferenzNummer"];
                qryBgAuszahlungPerson.Post();

                qryBgAuszahlungPersonTermin.Fill(qryBgAuszahlungPerson["BgAuszahlungPersonID"]);
                if (qryBgAuszahlungPersonTermin.Count == 0)
                {
                    qryBgAuszahlungPersonTermin.Insert();
                    qryBgAuszahlungPersonTermin["BgAuszahlungPersonID"] = qryBgAuszahlungPerson["BgAuszahlungPersonID"];
                }
                qryBgAuszahlungPersonTermin["Datum"] = qryBgPosition["ValutaDatum"];
                qryBgAuszahlungPersonTermin.Post();

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }

			if ((int)this.qryBgPosition["Finanzierung"] == 1 && (int)this.qryBgPosition["BgBewilligungStatusCode"] != (int)BgBewilligungStatus.Erteilt)
			{
				if ((int)this.qryBgPosition["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.InVorbereitung)
					KissMsg.ShowInfo("CtlAyEinzelzahlung", "EinzelzahlBewilligungspflichtig", "Diese Einzelzahlung ist bewilligungspflichtig\r\n\r\nSie müssen deshalb die Einzelzahlung bewilligen lassen, bevor sie ausbezahlt werden kann!");

				DBUtil.ExecSQL(@"
					DELETE KBU
					FROM dbo.KbBuchung                   KBU
					  INNER JOIN dbo.KbBuchungKostenart  KBK ON KBK.KbBuchungID = KBU.KbBuchungID
					WHERE KBU.BgBudgetID = {0} AND KBK.BgPositionID = {1}
					  AND KBU.KbBuchungStatusCode IN (1, 7)",
					qryBgPosition["BgBudgetID"], qryBgPosition["BgPositionID"]);
			}
			else if ((BgBewilligungStatus)this.qryBgBudget["BgBewilligungStatusCode"] == BgBewilligungStatus.Erteilt)
			{
				DBUtil.ExecSQL("EXECUTE dbo.spAyEinzelzahlung_CreateKbBuchung {0}, {1}, 2, {2}", 
                    qryBgPosition["BgBudgetID"], 
                    qryBgPosition["BgPositionID"],
                    Session.User.UserID);
			}
		}
		#endregion

		#region qryBgPosition_Delete
		private void qryBgPosition_BeforeDeleteQuestion(object sender, System.EventArgs e)
		{
			if (0 < (int)DBUtil.ExecuteScalarSQL(@"
				SELECT Count(*)
				FROM dbo.KbBuchung                   KBU
				  INNER JOIN dbo.KbBuchungKostenart  KBK ON KBK.KbBuchungID = KBU.KbBuchungID
				WHERE KBU.BgBudgetID = {0} AND KBK.BgPositionID = {1}
				  AND KBU.KbBuchungStatusCode NOT IN (1, 2, 7)",
				this.qryBgPosition["BgBudgetID"],
				this.qryBgPosition["BgPositionID"]))
			{
				throw new KissInfoException(KissMsg.GetMLMessage("CtlAyEinzelzahlung", "EinzelzahlungBereitsGebucht", "Diese Einzelzahlung ist bereits verbucht in der Buchhaltung und kannn deshalb nicht gelöscht werden", KissMsgCode.MsgInfo));
			}
		}

		private void qryBgPosition_BeforeDelete(object sender, System.EventArgs e)
		{
			if (qryBgPosition.Row.RowState != DataRowState.Detached)
			{
                DBUtil.ExecSQLThrowingException("EXECUTE dbo.spAyEinzelzahlung_Delete {0}", this.qryBgPosition["BgPositionID"]);
				this.qryBgPosition.Row.AcceptChanges();
			}
		}
		#endregion

		private void edtBgZahlungsmodusID_EditValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				int BgZahlungsmodusID = (int)this.edtBgZahlungsmodusID.EditValue;

				DataRow[] rows = qryBgZalungsmodus.DataTable.Select("BgZahlungsmodusID = " + DBUtil.SqlLiteral(BgZahlungsmodusID));
				if (rows.Length > 0)
				{
					this.ctlZahlungsweg.BaZahlungswegID = rows[0]["BaZahlungswegID"];
					this.ctlZahlungsweg.EditMode = EditModeType.ReadOnly;

					this.edtReferenzNummer.EditValue = rows[0]["ReferenzNummer"];
					this.edtReferenzNummer.EditMode = EditModeType.ReadOnly;

					if (rows[0]["Periodizitaet"].Equals(1))
						this.edtValutaDatum.EditMode = EditModeType.Normal;
					else
					{
						this.edtValutaDatum.EditMode = EditModeType.ReadOnly;
						if (!rows[0]["BgZahlungsmodusID"].Equals(this.qryBgPosition["BgZahlungsmodusID"]))
							KissMsg.ShowInfo("CtlAyEinzelzahlung", "ZahlungsmodusMehrmals", "Dieser Zahlungsmodus wird an mehreren Daten im Monat ausbezahlt\r\n\r\nDiese Daten gelten ebenfalls für diese Einzelzahlung");

					}
				}
			}
			catch
			{
				this.ctlZahlungsweg.EditMode = EditModeType.Normal;
				this.edtReferenzNummer.EditMode = EditModeType.Normal;
				this.edtValutaDatum.EditMode = EditModeType.Normal;
			}
			this.qryBgPosition.EnableBoundFields();
		}

		#region btnBgSpezkonto?_Click
		private void btnBgSpezkonto2_Click(object sender, System.EventArgs e)
		{
			CtlAySpezialkonto ctlAySpezialkonto = new CtlAySpezialkonto(BgSpezkontoTyp.Vorabzugkonto,
																		AyUtil.GetFaLeistungID_of_BgBudgetID(this.BgBudgetID),
																		this.edtBuchungstext.EditValue,
																		null,
																		null);

			DlgKissUserControl dlg = new DlgKissUserControl("Neues Vorabzugskonto erstellen", ctlAySpezialkonto);

			dlg.ShowDialog();
			if (dlg.UserCancel) return;

			((SqlQuery)this.edtBgSpezkontoID3.Properties.DataSource).Refresh();
			this.edtBgSpezkontoID2.EditValue = ctlAySpezialkonto.ActiveSQLQuery["BgSpezkontoID"];
		}

		private void btnBgSpezkonto3_Click(object sender, System.EventArgs e)
		{
			CtlAySpezialkonto ctlAySpezialkonto = new CtlAySpezialkonto(BgSpezkontoTyp.Abzahlungskonto,
																		AyUtil.GetFaLeistungID_of_BgBudgetID(this.BgBudgetID),
																		edtBuchungstext.EditValue,
																		edtBetrag.EditValue,
																		edtBetrag.EditValue);

			DlgKissUserControl dlg = new DlgKissUserControl("Neues Abzahlungskonto erstellen", ctlAySpezialkonto);

			dlg.ShowDialog();
			if (dlg.UserCancel) return;

			((SqlQuery)this.edtBgSpezkontoID3.Properties.DataSource).Refresh();
			this.edtBgSpezkontoID3.EditValue = ctlAySpezialkonto.ActiveSQLQuery["BgSpezkontoID"];
		}
		#endregion

		#region Runtime Layout

		private void UpdateZahnarztMode()
		{
			object BgPositionsartID = this.edtBgPositionsartID.EditValue;

			this.tpgZahnarzt.HideTab = DBUtil.IsEmpty(BgPositionsartID) ||
				((int)BgPositionsartID != (int)AyPositionsartID.Zahnarzt);
		}

		private void edtBgGruppeCode_EditValueChanged(object sender, System.EventArgs e)
		{
			qryBgPositionsart = DBUtil.OpenSQL(@"
				SELECT SPT.BgPositionsartID, SPT.Name, SPT.BgKostenartID, SPT.Masterbudget_EditMask, SPT.Monatsbudget_EditMask
				FROM dbo.AyPositionsart  SPT
                INNER JOIN dbo.BgBudget  BDG ON BDG.BgBudgetID = {2}
				WHERE SPT.BgKategorieCode = {0} AND SPT.BgGruppeCode = {1}
                    AND ISNULL(SPT.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) 
                    AND ISNULL(SPT.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
				ORDER BY SPT.SortKey"
                , (int)BgKategorie.Ausgaben, this.edtBgGruppeCode.EditValue, this.BgBudgetID);

			this.edtBgPositionsartID.LoadQuery(qryBgPositionsart, "BgPositionsartID", "Name");

			if (loaded)
				edtBgPositionsartID.EditValue = DBNull.Value;
		}

		private void edtBgPositionsartID_EditValueChanged(object sender, System.EventArgs e)
		{
			// Filter Ausgabekonto
			try
			{
				DataRow[] rows = this.qryBgPositionsart.DataTable.Select("BgPositionsartID = " + DBUtil.SqlLiteral(this.edtBgPositionsartID.EditValue));
				if (rows.Length > 0)
				{
					this.edtBgSpezkontoID1.Properties.DataSource = AyUtil.GetSpezKonto(
						this.BgBudgetID, BgSpezkontoTyp.Ausgabekonto, rows[0]["BgKostenartID"]);
				}
			}
			catch { }

			UpdateZahnarztMode();
		}
		#endregion

		private void qryBgPosition_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
		{
			try
			{
				switch (e.Column.ColumnName)
				{
					case "BgBewilligungStatusCode":
						this.qryBgPosition["BgBewilligungStatus"] = DBUtil.GetLOVText("BgBewilligungStatus", (int)e.Row[e.Column]);
						break;

					case "BgGruppeCode":
						break;
				}
			}
			catch { }
		}

		protected override void OnLoad(System.EventArgs e)
		{
			base.OnLoad(e);
			loaded = true;
		}
	}
}