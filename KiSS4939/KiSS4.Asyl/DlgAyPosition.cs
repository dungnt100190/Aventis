using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
	public class DlgAyPosition : KiSS4.Gui.KissDialog
	{
		private KiSS4.DB.SqlQuery qryBgPosition;
		private System.ComponentModel.IContainer components = null;
		private KiSS4.DB.SqlQuery qryBgZalungsmodus;
		private KiSS4.DB.SqlQuery qryBgAuszahlungPerson;
		private KiSS4.Gui.KissLabel lblVerrechnungGanzeUe;
		private KiSS4.Gui.KissLabel lblVerrechnungPerson;
		private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
		private KiSS4.Gui.KissRadioGroup optVerrechnung;
		private KiSS4.Gui.KissMemoEdit edtBemerkung;
		private KiSS4.Gui.KissCheckEdit edtVerwaltungSD;
		private System.Windows.Forms.Panel panZahlungsmodus;
		private KiSS4.Gui.KissLookUpEdit edtBgZahlungsmodusID;
		private KiSS4.Gui.KissLabel lblBgZahlungsmodusID;
		private KiSS4.Gui.KissLabel lblReferenzNummer;
		private KiSS4.Common.KissReferenzNrEdit edtReferenzNummer;
		private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID1;
		private KiSS4.Gui.KissLabel lblBgSpezkontoID1;
		private KiSS4.Gui.KissRadioGroup optZahlungsmodus;
		private KiSS4.Gui.KissGrid grdBgAuszahlungPerson;
		private DevExpress.XtraGrid.Views.Grid.GridView grvBgAuszahlungPerson;
		private DevExpress.XtraGrid.Columns.GridColumn colZahlungsmodus;
		private System.Windows.Forms.Panel panZahlungsmodusGrid;
		private System.Windows.Forms.Panel panAusgabekonto;
		private System.Windows.Forms.Panel panButton;
		private KiSS4.Gui.KissButton btnDelete;
		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.Gui.KissButton btnOK;
		private System.Windows.Forms.Panel panPosition;
		private KiSS4.Gui.KissLabel lblBgPositionsartID;
		private KiSS4.Gui.KissLabel lblBgGruppeCode;
		private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
		private KiSS4.Gui.KissLookUpEdit edtBgGruppeCode;
		private System.Windows.Forms.Panel panMain;
		private System.Windows.Forms.Panel panSpezkonto;
		private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID;
		private KiSS4.Gui.KissLabel lblBgSpezkontoID;
		private System.Windows.Forms.Panel panBuchungstext;
		private KiSS4.Gui.KissLabel lblBuchungstext;
		private KiSS4.Gui.KissTextEdit edtBuchungstext;
		private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
		private KiSS4.Gui.KissCalcEdit edtBetragRechnung;
		private KiSS4.Gui.KissLabel lblBetragBudget;
		private KiSS4.Gui.KissCalcEdit edtBetragBudget;
		private KiSS4.Gui.KissLabel lblBgPositionsartID2;
		private System.Windows.Forms.Panel panUnkosten;
		private System.Windows.Forms.Panel panTop;
		private System.Windows.Forms.Panel panBetrag;
		private KiSS4.Gui.KissTabControlEx tabBgPosition;
		private SharpLibrary.WinControls.TabPageEx tpgZahlungsmodus;
		private SharpLibrary.WinControls.TabPageEx tpgVerrechnung;
		private SharpLibrary.WinControls.TabPageEx tpgBemerkung;
		private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID2;
		private KiSS4.Gui.KissLabel lblSteuer;
		private KiSS4.Gui.KissCalcEdit edtReduktion;
		private SqlQuery qryBgBudget;
		private SqlQuery qryBgFinanzplan_BaPerson;
		private SqlQuery qryBgGruppe;
		private SqlQuery qryBgPositionsart;

		private int BgBudgetID;
		private BgKategorie BgKategorieCode;
		private int EditMask = 0;
		private bool closing = false;
		private bool filling = false;

		public DlgAyPosition()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		private const string sqlBgGruppeCode = @"
			SELECT SPT.BgKategorieCode, SPT.BgGruppeCode AS Code, XLC.Text, XLC.Value3
			FROM dbo.AyPositionsart    SPT
              INNER JOIN dbo.BgBudget  BDG ON BDG.BgBudgetID = {1}
			  LEFT JOIN XLOVCode  XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
			WHERE SPT.BgKategorieCode = {0}
			  AND NOT BgPositionsartCode BETWEEN 60005 AND 60009
              AND NOT BgPositionsartCode BETWEEN 60011 AND 60017
              AND ISNULL(SPT.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) 
              AND ISNULL(SPT.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
			GROUP BY SPT.BgKategorieCode, SPT.BgGruppeCode, XLC.Text, XLC.Value3, XLC.SortKey
			ORDER BY XLC.SortKey";

		private const string sqlBgPositionsart = @"
			SELECT SPT.*
			FROM dbo.AyPositionsart  SPT
            INNER JOIN dbo.BgBudget  BDG ON BDG.BgBudgetID = {1}
			WHERE SPT.BgKategorieCode = {0}
			  AND NOT BgPositionsartCode BETWEEN 60005 AND 60009
              AND NOT BgPositionsartCode BETWEEN 60011 AND 60017
              AND ISNULL(SPT.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) 
              AND ISNULL(SPT.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))";

		public DlgAyPosition(int bgBudgetID, BgKategorie bgKategorieCode)
			: this()
		{
            this.BgKategorieCode = bgKategorieCode;
            this.BgBudgetID = bgBudgetID;

            switch (BgKategorieCode)
            {
                case BgKategorie.Einnahmen:
                    this.Text = "Budget - Einnahmen";
                    this.panSpezkonto.Visible = false;
                    this.tpgZahlungsmodus.HideTab = true;
                    this.tabBgPosition.SelectedTabIndex = 0;

                    this.optVerrechnung.Properties.Items[0].Description = string.Format(this.optVerrechnung.Properties.Items[0].Description, "Die Einnahme wird");
                    this.optVerrechnung.Properties.Items[1].Description = string.Format(this.optVerrechnung.Properties.Items[1].Description, "Die Einnahme wird");

                    this.edtBgPositionsartID2.LoadQuery(DBUtil.OpenSQL(@"
						SELECT POA.BgPositionsartID, POA.Name, POA.SortKey
						FROM dbo.AyPositionsart POA
						INNER JOIN BgBudget BDG ON BDG.BgBudgetID = {0}
                        WHERE (POA.BgPositionsartCode BETWEEN 60005 AND 60009
                               OR POA.BgPositionsartCode BETWEEN 60011 AND 60017) 
                              AND ISNULL(POA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) 
                              AND ISNULL(POA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1))
                      UNION ALL
						SELECT NULL, '', 99999
						ORDER BY POA.SortKey", bgBudgetID), "BgPositionsartID", "Name");
                    break;

                case BgKategorie.Ausgaben:
                    this.Text = "Budget - Ausgaben";
                    this.panSpezkonto.Visible = false;
                    this.edtVerwaltungSD.Enabled = false;

                    this.optVerrechnung.Properties.Items[0].Description = string.Format(this.optVerrechnung.Properties.Items[0].Description, "Die Ausgabe wird");
                    this.optVerrechnung.Properties.Items[1].Description = string.Format(this.optVerrechnung.Properties.Items[1].Description, "Die Ausgabe wird");
                    break;

                case BgKategorie.Abzahlung:
                    this.Text = "Budget - Abzahlung";
                    this.panPosition.Visible = false;
                    this.panBuchungstext.Visible = false;
                    this.tpgVerrechnung.HideTab = true;
                    this.tpgZahlungsmodus.HideTab = true;
                    this.tabBgPosition.SelectedTabIndex = 2;
                    this.edtVerwaltungSD.Enabled = false;

                    this.qryBgPosition.CanDelete = false;
                    this.btnDelete.Visible = false;
                    break;

                case BgKategorie.Vorabzug:
                    this.Text = "Budget - Vorabzug";
                    this.panPosition.Visible = false;
                    this.panBuchungstext.Visible = false;
                    this.tpgVerrechnung.HideTab = true;
                    this.tpgZahlungsmodus.HideTab = true;
                    this.tabBgPosition.SelectedTabIndex = 2;
                    this.edtVerwaltungSD.Enabled = false;
                    break;

                case BgKategorie.Kuerzung:
                    this.Text = "Budget - Kürzung";
                    this.panPosition.Visible = false;
                    this.panSpezkonto.Visible = false;
                    this.tpgVerrechnung.HideTab = true;
                    this.tpgZahlungsmodus.HideTab = true;
                    this.tabBgPosition.SelectedTabIndex = 2;
                    this.edtVerwaltungSD.Enabled = false;

                    this.optVerrechnung.Properties.Items[0].Description = string.Format(this.optVerrechnung.Properties.Items[0].Description, "Die Kürzung wird");
                    this.optVerrechnung.Properties.Items[1].Description = string.Format(this.optVerrechnung.Properties.Items[1].Description, "Die Kürzung wird");
                    break;

                case BgKategorie.Vermoegen:
                    break;
            }

            qryBgGruppe = DBUtil.OpenSQL(sqlBgGruppeCode, (int)BgKategorieCode, BgBudgetID);
            edtBgGruppeCode.Properties.DataSource = qryBgGruppe;

            qryBgPositionsart = DBUtil.OpenSQL(sqlBgPositionsart, (int)BgKategorieCode, BgBudgetID);
            edtBgPositionsartID.Properties.DataSource = qryBgPositionsart;

            qryBgBudget.Fill(BgBudgetID);

			if ((int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Gesperrt
				|| (!(bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt))
			{
				AyUtil.SqlQueryEditOff(qryBgPosition);
				AyUtil.SqlQueryEditOff(qryBgAuszahlungPerson);
			}

			this.btnDelete.Enabled = this.qryBgPosition.CanDelete;
			this.btnOK.Enabled = this.qryBgPosition.CanUpdate || this.qryBgPosition.CanInsert;

			switch (bgKategorieCode)
			{
				case BgKategorie.Abzahlung:
					this.edtBgSpezkontoID.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Abzahlungskonto), "BgSpezkontoID", "DisplayText");
					break;

				case BgKategorie.Vorabzug:
					this.edtBgSpezkontoID.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Vorabzugkonto), "BgSpezkontoID", "DisplayText");
					break;
			}

			// Ausgabekonto
			this.edtBgSpezkontoID1.LoadQuery(AyUtil.GetSpezKonto(bgBudgetID, BgSpezkontoTyp.Ausgabekonto), "BgSpezkontoID", "DisplayText");

			// Zahlungsmodus
			qryBgZalungsmodus = AyUtil.GetZahlungsmodus(bgBudgetID);
			this.edtBgZahlungsmodusID.LoadQuery(qryBgZalungsmodus, "BgZahlungsmodusID", "NameZahlungsmodus");
			this.colZahlungsmodus.ColumnEdit = this.grdBgAuszahlungPerson.GetLOVLookUpEdit(
				qryBgZalungsmodus, "BgZahlungsmodusID", "NameZahlungsmodus");

			this.qryBgAuszahlungPerson.Fill(DBNull.Value);

			// Verrechnung
			qryBgFinanzplan_BaPerson = AyUtil.GetPersonen_Unterstuetzt(bgBudgetID);
			this.edtBaPersonID.LoadQuery(qryBgFinanzplan_BaPerson, "BaPersonID", "NameVorname");
			this.colBaPersonID.ColumnEdit = this.grdBgAuszahlungPerson.GetLOVLookUpEdit(
				qryBgFinanzplan_BaPerson, "BaPersonID", "NameVorname");

			this.qryBgPosition.Fill(0);
		}

		public DlgAyPosition(int bgBudgetID, BgKategorie bgKategorieCode, int bgPositionID)
			: this(bgBudgetID, bgKategorieCode)
		{
			filling = true;
			this.qryBgPosition.Fill(bgPositionID);
			filling = false;
			this.qryBgPosition.CanInsert = false;

			switch (bgKategorieCode)
			{
				case BgKategorie.Abzahlung:
				case BgKategorie.Vorabzug:
					this.edtBgSpezkontoID.EditMode = EditModeType.ReadOnly;
					break;

				case BgKategorie.Kuerzung:
					if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]))
						this.panPosition.Visible = true;
					break;
			}

			if (DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID_GUI"]))
			{
				this.qryBgAuszahlungPerson.Fill(this.qryBgPosition["BgPositionID_GUI"]);

				if (!DBUtil.IsEmpty(qryBgAuszahlungPerson["BaPersonID"]))
				{
					this.qryBgPosition["AuszahlungsArt"] = 1;
					this.qryBgPosition.Row.AcceptChanges();
					this.qryBgPosition.RefreshDisplay();
				}

				optZahlungsmodus_EditValueChanged(null, EventArgs.Empty);
			}

			this.qryBgPosition.Row.AcceptChanges();
			this.qryBgPosition.RowModified = false;
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAyPosition));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgAuszahlungPerson = new KiSS4.DB.SqlQuery(this.components);
            this.panZahlungsmodusGrid = new System.Windows.Forms.Panel();
            this.grdBgAuszahlungPerson = new KiSS4.Gui.KissGrid();
            this.grvBgAuszahlungPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsmodus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panZahlungsmodus = new System.Windows.Forms.Panel();
            this.edtBgZahlungsmodusID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgZahlungsmodusID = new KiSS4.Gui.KissLabel();
            this.lblReferenzNummer = new KiSS4.Gui.KissLabel();
            this.edtReferenzNummer = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.panAusgabekonto = new System.Windows.Forms.Panel();
            this.edtBgSpezkontoID1 = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSpezkontoID1 = new KiSS4.Gui.KissLabel();
            this.optZahlungsmodus = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtVerwaltungSD = new KiSS4.Gui.KissCheckEdit();
            this.lblVerrechnungGanzeUe = new KiSS4.Gui.KissLabel();
            this.lblVerrechnungPerson = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.optVerrechnung = new KiSS4.Gui.KissRadioGroup(this.components);
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.panButton = new System.Windows.Forms.Panel();
            this.btnDelete = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.panPosition = new System.Windows.Forms.Panel();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.lblBgGruppeCode = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgGruppeCode = new KiSS4.Gui.KissLookUpEdit();
            this.panMain = new System.Windows.Forms.Panel();
            this.tabBgPosition = new KiSS4.Gui.KissTabControlEx();
            this.tpgZahlungsmodus = new SharpLibrary.WinControls.TabPageEx();
            this.tpgVerrechnung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgBemerkung = new SharpLibrary.WinControls.TabPageEx();
            this.panSpezkonto = new System.Windows.Forms.Panel();
            this.lblBgSpezkontoID = new KiSS4.Gui.KissLabel();
            this.edtBgSpezkontoID = new KiSS4.Gui.KissLookUpEdit();
            this.panTop = new System.Windows.Forms.Panel();
            this.panBuchungstext = new System.Windows.Forms.Panel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.panBetrag = new System.Windows.Forms.Panel();
            this.edtReduktion = new KiSS4.Gui.KissCalcEdit();
            this.lblSteuer = new KiSS4.Gui.KissLabel();
            this.edtBetragRechnung = new KiSS4.Gui.KissCalcEdit();
            this.lblBetragBudget = new KiSS4.Gui.KissLabel();
            this.edtBetragBudget = new KiSS4.Gui.KissCalcEdit();
            this.panUnkosten = new System.Windows.Forms.Panel();
            this.edtBgPositionsartID2 = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgPositionsartID2 = new KiSS4.Gui.KissLabel();
            this.qryBgFinanzplan_BaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgPositionsart = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgBudget = new KiSS4.DB.SqlQuery(this.components);
            this.qryBgGruppe = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).BeginInit();
            this.panZahlungsmodusGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgAuszahlungPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgAuszahlungPerson)).BeginInit();
            this.panZahlungsmodus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgZahlungsmodusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).BeginInit();
            this.panAusgabekonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZahlungsmodus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungGanzeUe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optVerrechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            this.panButton.SuspendLayout();
            this.panPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).BeginInit();
            this.panMain.SuspendLayout();
            this.tabBgPosition.SuspendLayout();
            this.tpgZahlungsmodus.SuspendLayout();
            this.tpgVerrechnung.SuspendLayout();
            this.tpgBemerkung.SuspendLayout();
            this.panSpezkonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).BeginInit();
            this.panBuchungstext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            this.panBetrag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragRechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).BeginInit();
            this.panUnkosten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan_BaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgGruppe)).BeginInit();
            this.SuspendLayout();
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.AutoApplyUserRights = false;
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
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            // 
            // qryBgAuszahlungPerson
            // 
            this.qryBgAuszahlungPerson.AutoApplyUserRights = false;
            this.qryBgAuszahlungPerson.BatchUpdate = true;
            this.qryBgAuszahlungPerson.CanUpdate = true;
            this.qryBgAuszahlungPerson.HostControl = this;
            this.qryBgAuszahlungPerson.SelectStatement = "SELECT *\r\nFROM BgAuszahlungPerson\r\nWHERE BgPositionID = {0}";
            this.qryBgAuszahlungPerson.TableName = "BgAuszahlungPerson";
            this.qryBgAuszahlungPerson.AfterInsert += new System.EventHandler(this.qryBgAuszahlungPerson_AfterInsert);
            this.qryBgAuszahlungPerson.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBeleg_ColumnChanged);
            // 
            // panZahlungsmodusGrid
            // 
            this.panZahlungsmodusGrid.Controls.Add(this.grdBgAuszahlungPerson);
            this.panZahlungsmodusGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZahlungsmodusGrid.Location = new System.Drawing.Point(0, 66);
            this.panZahlungsmodusGrid.Name = "panZahlungsmodusGrid";
            this.panZahlungsmodusGrid.Size = new System.Drawing.Size(428, 54);
            this.panZahlungsmodusGrid.TabIndex = 2;
            // 
            // grdBgAuszahlungPerson
            // 
            this.grdBgAuszahlungPerson.DataSource = this.qryBgAuszahlungPerson;
            this.grdBgAuszahlungPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBgAuszahlungPerson.EmbeddedNavigator.Name = "";
            this.grdBgAuszahlungPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgAuszahlungPerson.Location = new System.Drawing.Point(0, 0);
            this.grdBgAuszahlungPerson.MainView = this.grvBgAuszahlungPerson;
            this.grdBgAuszahlungPerson.Name = "grdBgAuszahlungPerson";
            this.grdBgAuszahlungPerson.Size = new System.Drawing.Size(428, 54);
            this.grdBgAuszahlungPerson.TabIndex = 0;
            this.grdBgAuszahlungPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgAuszahlungPerson});
            // 
            // grvBgAuszahlungPerson
            // 
            this.grvBgAuszahlungPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgAuszahlungPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.Empty.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgAuszahlungPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgAuszahlungPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgAuszahlungPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgAuszahlungPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgAuszahlungPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgAuszahlungPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgAuszahlungPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgAuszahlungPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgAuszahlungPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.Appearance.Row.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgAuszahlungPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgAuszahlungPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgAuszahlungPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgAuszahlungPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgAuszahlungPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBaPersonID,
            this.colZahlungsmodus});
            this.grvBgAuszahlungPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgAuszahlungPerson.GridControl = this.grdBgAuszahlungPerson;
            this.grvBgAuszahlungPerson.Name = "grvBgAuszahlungPerson";
            this.grvBgAuszahlungPerson.OptionsBehavior.Editable = false;
            this.grvBgAuszahlungPerson.OptionsCustomization.AllowFilter = false;
            this.grvBgAuszahlungPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgAuszahlungPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgAuszahlungPerson.OptionsNavigation.UseTabKey = false;
            this.grvBgAuszahlungPerson.OptionsView.ColumnAutoWidth = false;
            this.grvBgAuszahlungPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgAuszahlungPerson.OptionsView.ShowGroupPanel = false;
            this.grvBgAuszahlungPerson.OptionsView.ShowIndicator = false;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Person";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 0;
            this.colBaPersonID.Width = 177;
            // 
            // colZahlungsmodus
            // 
            this.colZahlungsmodus.Caption = "Zahlungsmodus";
            this.colZahlungsmodus.FieldName = "BgZahlungsmodusID";
            this.colZahlungsmodus.Name = "colZahlungsmodus";
            this.colZahlungsmodus.Visible = true;
            this.colZahlungsmodus.VisibleIndex = 1;
            this.colZahlungsmodus.Width = 224;
            // 
            // panZahlungsmodus
            // 
            this.panZahlungsmodus.Controls.Add(this.edtBgZahlungsmodusID);
            this.panZahlungsmodus.Controls.Add(this.lblBgZahlungsmodusID);
            this.panZahlungsmodus.Controls.Add(this.lblReferenzNummer);
            this.panZahlungsmodus.Controls.Add(this.edtReferenzNummer);
            this.panZahlungsmodus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panZahlungsmodus.Location = new System.Drawing.Point(0, 120);
            this.panZahlungsmodus.Name = "panZahlungsmodus";
            this.panZahlungsmodus.Size = new System.Drawing.Size(428, 64);
            this.panZahlungsmodus.TabIndex = 3;
            // 
            // edtBgZahlungsmodusID
            // 
            this.edtBgZahlungsmodusID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBgZahlungsmodusID.DataMember = "BgZahlungsmodusID";
            this.edtBgZahlungsmodusID.DataSource = this.qryBgAuszahlungPerson;
            this.edtBgZahlungsmodusID.Location = new System.Drawing.Point(0, 16);
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBgZahlungsmodusID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBgZahlungsmodusID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgZahlungsmodusID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameZahlungsmodus")});
            this.edtBgZahlungsmodusID.Properties.DisplayMember = "NameZahlungsmodus";
            this.edtBgZahlungsmodusID.Properties.NullText = "";
            this.edtBgZahlungsmodusID.Properties.ShowFooter = false;
            this.edtBgZahlungsmodusID.Properties.ShowHeader = false;
            this.edtBgZahlungsmodusID.Properties.ValueMember = "BgZahlungsmodusID";
            this.edtBgZahlungsmodusID.Size = new System.Drawing.Size(428, 24);
            this.edtBgZahlungsmodusID.TabIndex = 1;
            this.edtBgZahlungsmodusID.EditValueChanged += new System.EventHandler(this.edtBgZahlungsmodusID_EditValueChanged);
            // 
            // lblBgZahlungsmodusID
            // 
            this.lblBgZahlungsmodusID.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBgZahlungsmodusID.Location = new System.Drawing.Point(0, 0);
            this.lblBgZahlungsmodusID.Name = "lblBgZahlungsmodusID";
            this.lblBgZahlungsmodusID.Size = new System.Drawing.Size(336, 16);
            this.lblBgZahlungsmodusID.TabIndex = 0;
            this.lblBgZahlungsmodusID.Text = "Zahlungsmodus";
            // 
            // lblReferenzNummer
            // 
            this.lblReferenzNummer.Location = new System.Drawing.Point(0, 39);
            this.lblReferenzNummer.Name = "lblReferenzNummer";
            this.lblReferenzNummer.Size = new System.Drawing.Size(48, 24);
            this.lblReferenzNummer.TabIndex = 2;
            this.lblReferenzNummer.Text = "Ref-Nr.:";
            // 
            // edtReferenzNummer
            // 
            this.edtReferenzNummer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtReferenzNummer.DataMember = "ReferenzNummer";
            this.edtReferenzNummer.DataSource = this.qryBgAuszahlungPerson;
            this.edtReferenzNummer.Location = new System.Drawing.Point(48, 39);
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
            this.edtReferenzNummer.Size = new System.Drawing.Size(380, 24);
            this.edtReferenzNummer.TabIndex = 3;
            // 
            // panAusgabekonto
            // 
            this.panAusgabekonto.Controls.Add(this.edtBgSpezkontoID1);
            this.panAusgabekonto.Controls.Add(this.lblBgSpezkontoID1);
            this.panAusgabekonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.panAusgabekonto.Location = new System.Drawing.Point(0, 24);
            this.panAusgabekonto.Name = "panAusgabekonto";
            this.panAusgabekonto.Size = new System.Drawing.Size(428, 42);
            this.panAusgabekonto.TabIndex = 1;
            // 
            // edtBgSpezkontoID1
            // 
            this.edtBgSpezkontoID1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBgSpezkontoID1.DataMember = "BgSpezkontoID_GUI";
            this.edtBgSpezkontoID1.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID1.Location = new System.Drawing.Point(0, 16);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgSpezkontoID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgSpezkontoID1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSpezkonto")});
            this.edtBgSpezkontoID1.Properties.DisplayMember = "NameSpezkonto";
            this.edtBgSpezkontoID1.Properties.NullText = "";
            this.edtBgSpezkontoID1.Properties.ShowFooter = false;
            this.edtBgSpezkontoID1.Properties.ShowHeader = false;
            this.edtBgSpezkontoID1.Properties.ValueMember = "BgSpezkontoID";
            this.edtBgSpezkontoID1.Size = new System.Drawing.Size(428, 24);
            this.edtBgSpezkontoID1.TabIndex = 1;
            // 
            // lblBgSpezkontoID1
            // 
            this.lblBgSpezkontoID1.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBgSpezkontoID1.Location = new System.Drawing.Point(-1, 0);
            this.lblBgSpezkontoID1.Name = "lblBgSpezkontoID1";
            this.lblBgSpezkontoID1.Size = new System.Drawing.Size(336, 16);
            this.lblBgSpezkontoID1.TabIndex = 0;
            this.lblBgSpezkontoID1.Text = "Ausgabekonto";
            // 
            // optZahlungsmodus
            // 
            this.optZahlungsmodus.Cursor = System.Windows.Forms.Cursors.Default;
            this.optZahlungsmodus.DataMember = "AuszahlungsArt";
            this.optZahlungsmodus.DataSource = this.qryBgPosition;
            this.optZahlungsmodus.Dock = System.Windows.Forms.DockStyle.Top;
            this.optZahlungsmodus.Location = new System.Drawing.Point(0, 0);
            this.optZahlungsmodus.Name = "optZahlungsmodus";
            this.optZahlungsmodus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optZahlungsmodus.Properties.Appearance.Options.UseBackColor = true;
            this.optZahlungsmodus.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.optZahlungsmodus.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.optZahlungsmodus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optZahlungsmodus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Für ganze UE"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Pro Person"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Ausgabekonto")});
            this.optZahlungsmodus.Size = new System.Drawing.Size(428, 24);
            this.optZahlungsmodus.TabIndex = 0;
            this.optZahlungsmodus.EditValueChanged += new System.EventHandler(this.optZahlungsmodus_EditValueChanged);
            // 
            // edtVerwaltungSD
            // 
            this.edtVerwaltungSD.DataMember = "VerwaltungSD";
            this.edtVerwaltungSD.DataSource = this.qryBgPosition;
            this.edtVerwaltungSD.Location = new System.Drawing.Point(16, 16);
            this.edtVerwaltungSD.Name = "edtVerwaltungSD";
            this.edtVerwaltungSD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerwaltungSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD.Properties.Caption = "Abtretung an Asylkordinationsstelle";
            this.edtVerwaltungSD.Size = new System.Drawing.Size(400, 19);
            this.edtVerwaltungSD.TabIndex = 0;
            // 
            // lblVerrechnungGanzeUe
            // 
            this.lblVerrechnungGanzeUe.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblVerrechnungGanzeUe.Location = new System.Drawing.Point(32, 64);
            this.lblVerrechnungGanzeUe.Name = "lblVerrechnungGanzeUe";
            this.lblVerrechnungGanzeUe.Size = new System.Drawing.Size(368, 16);
            this.lblVerrechnungGanzeUe.TabIndex = 2;
            this.lblVerrechnungGanzeUe.Text = "gleichmässig verrechnet";
            // 
            // lblVerrechnungPerson
            // 
            this.lblVerrechnungPerson.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblVerrechnungPerson.Location = new System.Drawing.Point(32, 104);
            this.lblVerrechnungPerson.Name = "lblVerrechnungPerson";
            this.lblVerrechnungPerson.Size = new System.Drawing.Size(368, 16);
            this.lblVerrechnungPerson.TabIndex = 3;
            this.lblVerrechnungPerson.Text = "Unterstützungseinheit verrechnet:";
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(40, 128);
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(376, 24);
            this.edtBaPersonID.TabIndex = 4;
            // 
            // optVerrechnung
            // 
            this.optVerrechnung.DataMember = "Verrechnung";
            this.optVerrechnung.DataSource = this.qryBgPosition;
            this.optVerrechnung.EditValue = false;
            this.optVerrechnung.Location = new System.Drawing.Point(16, 32);
            this.optVerrechnung.Name = "optVerrechnung";
            this.optVerrechnung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.optVerrechnung.Properties.Appearance.Options.UseBackColor = true;
            this.optVerrechnung.Properties.Appearance.Options.UseTextOptions = true;
            this.optVerrechnung.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.optVerrechnung.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.optVerrechnung.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.optVerrechnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.optVerrechnung.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "{0} allen Personen aus der Unterstützungseinheit"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "{0} nur der folgenden Person aus der")});
            this.optVerrechnung.Size = new System.Drawing.Size(392, 88);
            this.optVerrechnung.TabIndex = 1;
            this.optVerrechnung.EditValueChanged += new System.EventHandler(this.optVerrechnung_EditValueChanged);
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
            this.edtBemerkung.Size = new System.Drawing.Size(428, 184);
            this.edtBemerkung.TabIndex = 0;
            // 
            // panButton
            // 
            this.panButton.Controls.Add(this.btnDelete);
            this.panButton.Controls.Add(this.btnCancel);
            this.panButton.Controls.Add(this.btnOK);
            this.panButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButton.Location = new System.Drawing.Point(0, 376);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(458, 40);
            this.panButton.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(8, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 24);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(354, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(250, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panPosition
            // 
            this.panPosition.Controls.Add(this.lblBgPositionsartID);
            this.panPosition.Controls.Add(this.lblBgGruppeCode);
            this.panPosition.Controls.Add(this.edtBgPositionsartID);
            this.panPosition.Controls.Add(this.edtBgGruppeCode);
            this.panPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPosition.Location = new System.Drawing.Point(0, 8);
            this.panPosition.Name = "panPosition";
            this.panPosition.Size = new System.Drawing.Size(458, 48);
            this.panPosition.TabIndex = 1;
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Location = new System.Drawing.Point(8, 23);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(120, 24);
            this.lblBgPositionsartID.TabIndex = 2;
            this.lblBgPositionsartID.Text = "Typ";
            // 
            // lblBgGruppeCode
            // 
            this.lblBgGruppeCode.Location = new System.Drawing.Point(8, 0);
            this.lblBgGruppeCode.Name = "lblBgGruppeCode";
            this.lblBgGruppeCode.Size = new System.Drawing.Size(120, 24);
            this.lblBgGruppeCode.TabIndex = 0;
            this.lblBgGruppeCode.Text = "Gruppe";
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(128, 23);
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.edtBgPositionsartID.Properties.DisplayMember = "Name";
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Properties.ValueMember = "BgPositionsartID";
            this.edtBgPositionsartID.Size = new System.Drawing.Size(320, 24);
            this.edtBgPositionsartID.TabIndex = 3;
            this.edtBgPositionsartID.EditValueChanged += new System.EventHandler(this.edtBgPositionsartID_EditValueChanged);
            // 
            // edtBgGruppeCode
            // 
            this.edtBgGruppeCode.DataMember = "BgGruppeCode";
            this.edtBgGruppeCode.DataSource = this.qryBgPosition;
            this.edtBgGruppeCode.Location = new System.Drawing.Point(128, 0);
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBgGruppeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBgGruppeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgGruppeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgGruppeCode.Properties.DisplayMember = "Text";
            this.edtBgGruppeCode.Properties.NullText = "";
            this.edtBgGruppeCode.Properties.ShowFooter = false;
            this.edtBgGruppeCode.Properties.ShowHeader = false;
            this.edtBgGruppeCode.Properties.ValueMember = "Code";
            this.edtBgGruppeCode.Size = new System.Drawing.Size(320, 24);
            this.edtBgGruppeCode.TabIndex = 1;
            this.edtBgGruppeCode.EditValueChanged += new System.EventHandler(this.edtBgGruppeCode_EditValueChanged);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.tabBgPosition);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 154);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(458, 222);
            this.panMain.TabIndex = 6;
            // 
            // tabBgPosition
            // 
            this.tabBgPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBgPosition.Controls.Add(this.tpgZahlungsmodus);
            this.tabBgPosition.Controls.Add(this.tpgVerrechnung);
            this.tabBgPosition.Controls.Add(this.tpgBemerkung);
            this.tabBgPosition.Location = new System.Drawing.Point(8, 0);
            this.tabBgPosition.Name = "tabBgPosition";
            this.tabBgPosition.SelectedTabIndex = 1;
            this.tabBgPosition.ShowFixedWidthTooltip = true;
            this.tabBgPosition.Size = new System.Drawing.Size(440, 222);
            this.tabBgPosition.TabIndex = 1;
            this.tabBgPosition.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZahlungsmodus,
            this.tpgVerrechnung,
            this.tpgBemerkung});
            this.tabBgPosition.TabsLineColor = System.Drawing.Color.Black;
            this.tabBgPosition.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabBgPosition.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBgPosition.Text = "kissTabControlEx1";
            // 
            // tpgZahlungsmodus
            // 
            this.tpgZahlungsmodus.Controls.Add(this.panZahlungsmodusGrid);
            this.tpgZahlungsmodus.Controls.Add(this.panZahlungsmodus);
            this.tpgZahlungsmodus.Controls.Add(this.panAusgabekonto);
            this.tpgZahlungsmodus.Controls.Add(this.optZahlungsmodus);
            this.tpgZahlungsmodus.Location = new System.Drawing.Point(6, 32);
            this.tpgZahlungsmodus.Name = "tpgZahlungsmodus";
            this.tpgZahlungsmodus.Size = new System.Drawing.Size(428, 184);
            this.tpgZahlungsmodus.TabIndex = 0;
            this.tpgZahlungsmodus.Title = "Zahlungsmodus";
            // 
            // tpgVerrechnung
            // 
            this.tpgVerrechnung.Controls.Add(this.edtVerwaltungSD);
            this.tpgVerrechnung.Controls.Add(this.lblVerrechnungGanzeUe);
            this.tpgVerrechnung.Controls.Add(this.lblVerrechnungPerson);
            this.tpgVerrechnung.Controls.Add(this.edtBaPersonID);
            this.tpgVerrechnung.Controls.Add(this.optVerrechnung);
            this.tpgVerrechnung.Location = new System.Drawing.Point(6, 32);
            this.tpgVerrechnung.Name = "tpgVerrechnung";
            this.tpgVerrechnung.Size = new System.Drawing.Size(428, 184);
            this.tpgVerrechnung.TabIndex = 1;
            this.tpgVerrechnung.Title = "Verrechnung";
            // 
            // tpgBemerkung
            // 
            this.tpgBemerkung.Controls.Add(this.edtBemerkung);
            this.tpgBemerkung.Location = new System.Drawing.Point(6, 32);
            this.tpgBemerkung.Name = "tpgBemerkung";
            this.tpgBemerkung.Size = new System.Drawing.Size(428, 184);
            this.tpgBemerkung.TabIndex = 2;
            this.tpgBemerkung.Title = "Bemerkungen";
            // 
            // panSpezkonto
            // 
            this.panSpezkonto.Controls.Add(this.lblBgSpezkontoID);
            this.panSpezkonto.Controls.Add(this.edtBgSpezkontoID);
            this.panSpezkonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.panSpezkonto.Location = new System.Drawing.Point(0, 56);
            this.panSpezkonto.Name = "panSpezkonto";
            this.panSpezkonto.Size = new System.Drawing.Size(458, 24);
            this.panSpezkonto.TabIndex = 2;
            // 
            // lblBgSpezkontoID
            // 
            this.lblBgSpezkontoID.Location = new System.Drawing.Point(8, 0);
            this.lblBgSpezkontoID.Name = "lblBgSpezkontoID";
            this.lblBgSpezkontoID.Size = new System.Drawing.Size(120, 24);
            this.lblBgSpezkontoID.TabIndex = 0;
            this.lblBgSpezkontoID.Text = "Konto";
            // 
            // edtBgSpezkontoID
            // 
            this.edtBgSpezkontoID.DataMember = "BgSpezkontoID_GUI";
            this.edtBgSpezkontoID.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID.Location = new System.Drawing.Point(128, 0);
            this.edtBgSpezkontoID.Name = "edtBgSpezkontoID";
            this.edtBgSpezkontoID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgSpezkontoID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBgSpezkontoID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameSpezkonto", "", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID.Properties.DisplayMember = "NameSpezkonto";
            this.edtBgSpezkontoID.Properties.NullText = "";
            this.edtBgSpezkontoID.Properties.ShowFooter = false;
            this.edtBgSpezkontoID.Properties.ShowHeader = false;
            this.edtBgSpezkontoID.Properties.ValueMember = "BgSpezkontoID";
            this.edtBgSpezkontoID.Size = new System.Drawing.Size(320, 24);
            this.edtBgSpezkontoID.TabIndex = 1;
            // 
            // panTop
            // 
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(458, 8);
            this.panTop.TabIndex = 0;
            // 
            // panBuchungstext
            // 
            this.panBuchungstext.Controls.Add(this.lblBuchungstext);
            this.panBuchungstext.Controls.Add(this.edtBuchungstext);
            this.panBuchungstext.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBuchungstext.Location = new System.Drawing.Point(0, 80);
            this.panBuchungstext.Name = "panBuchungstext";
            this.panBuchungstext.Size = new System.Drawing.Size(458, 25);
            this.panBuchungstext.TabIndex = 3;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(8, 0);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(120, 24);
            this.lblBuchungstext.TabIndex = 0;
            this.lblBuchungstext.Text = "Buchungstext";
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.Location = new System.Drawing.Point(128, 0);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(320, 24);
            this.edtBuchungstext.TabIndex = 1;
            // 
            // panBetrag
            // 
            this.panBetrag.Controls.Add(this.edtReduktion);
            this.panBetrag.Controls.Add(this.lblSteuer);
            this.panBetrag.Controls.Add(this.edtBetragRechnung);
            this.panBetrag.Controls.Add(this.lblBetragBudget);
            this.panBetrag.Controls.Add(this.edtBetragBudget);
            this.panBetrag.Dock = System.Windows.Forms.DockStyle.Top;
            this.panBetrag.Location = new System.Drawing.Point(0, 105);
            this.panBetrag.Name = "panBetrag";
            this.panBetrag.Size = new System.Drawing.Size(458, 24);
            this.panBetrag.TabIndex = 4;
            // 
            // edtReduktion
            // 
            this.edtReduktion.DataMember = "Reduktion";
            this.edtReduktion.DataSource = this.qryBgPosition;
            this.edtReduktion.Location = new System.Drawing.Point(336, 0);
            this.edtReduktion.Name = "edtReduktion";
            this.edtReduktion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtReduktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtReduktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtReduktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtReduktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtReduktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtReduktion.Properties.Appearance.Options.UseFont = true;
            this.edtReduktion.Properties.Appearance.Options.UseTextOptions = true;
            this.edtReduktion.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtReduktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtReduktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtReduktion.Properties.DisplayFormat.FormatString = "n2";
            this.edtReduktion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtReduktion.Properties.EditFormat.FormatString = "n2";
            this.edtReduktion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtReduktion.Size = new System.Drawing.Size(112, 24);
            this.edtReduktion.TabIndex = 4;
            this.edtReduktion.Visible = false;
            // 
            // lblSteuer
            // 
            this.lblSteuer.Location = new System.Drawing.Point(256, 0);
            this.lblSteuer.Name = "lblSteuer";
            this.lblSteuer.Size = new System.Drawing.Size(80, 24);
            this.lblSteuer.TabIndex = 3;
            this.lblSteuer.Text = "Quellensteuer";
            this.lblSteuer.Visible = false;
            // 
            // edtBetragRechnung
            // 
            this.edtBetragRechnung.DataMember = "BetragRechnung";
            this.edtBetragRechnung.DataSource = this.qryBgPosition;
            this.edtBetragRechnung.Location = new System.Drawing.Point(416, 0);
            this.edtBetragRechnung.Name = "edtBetragRechnung";
            this.edtBetragRechnung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragRechnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragRechnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragRechnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragRechnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragRechnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragRechnung.Properties.Appearance.Options.UseFont = true;
            this.edtBetragRechnung.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBetragRechnung.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBetragRechnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragRechnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragRechnung.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragRechnung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragRechnung.Properties.EditFormat.FormatString = "n2";
            this.edtBetragRechnung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragRechnung.Size = new System.Drawing.Size(40, 24);
            this.edtBetragRechnung.TabIndex = 2;
            this.edtBetragRechnung.Visible = false;
            // 
            // lblBetragBudget
            // 
            this.lblBetragBudget.Location = new System.Drawing.Point(8, 0);
            this.lblBetragBudget.Name = "lblBetragBudget";
            this.lblBetragBudget.Size = new System.Drawing.Size(120, 24);
            this.lblBetragBudget.TabIndex = 0;
            this.lblBetragBudget.Text = "Betrag";
            // 
            // edtBetragBudget
            // 
            this.edtBetragBudget.DataMember = "BetragBudget";
            this.edtBetragBudget.DataSource = this.qryBgPosition;
            this.edtBetragBudget.Location = new System.Drawing.Point(128, 0);
            this.edtBetragBudget.Name = "edtBetragBudget";
            this.edtBetragBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragBudget.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragBudget.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragBudget.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragBudget.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragBudget.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragBudget.Properties.Appearance.Options.UseFont = true;
            this.edtBetragBudget.Properties.Appearance.Options.UseTextOptions = true;
            this.edtBetragBudget.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtBetragBudget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragBudget.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragBudget.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBudget.Properties.EditFormat.FormatString = "n2";
            this.edtBetragBudget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBudget.Size = new System.Drawing.Size(120, 24);
            this.edtBetragBudget.TabIndex = 1;
            // 
            // panUnkosten
            // 
            this.panUnkosten.Controls.Add(this.edtBgPositionsartID2);
            this.panUnkosten.Controls.Add(this.lblBgPositionsartID2);
            this.panUnkosten.Dock = System.Windows.Forms.DockStyle.Top;
            this.panUnkosten.Location = new System.Drawing.Point(0, 129);
            this.panUnkosten.Name = "panUnkosten";
            this.panUnkosten.Size = new System.Drawing.Size(458, 25);
            this.panUnkosten.TabIndex = 5;
            this.panUnkosten.Visible = false;
            // 
            // edtBgPositionsartID2
            // 
            this.edtBgPositionsartID2.DataMember = "BgPositionsartID_2";
            this.edtBgPositionsartID2.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID2.Location = new System.Drawing.Point(128, 1);
            this.edtBgPositionsartID2.Name = "edtBgPositionsartID2";
            this.edtBgPositionsartID2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID2.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID2.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBgPositionsartID2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBgPositionsartID2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.edtBgPositionsartID2.Properties.DisplayMember = "Name";
            this.edtBgPositionsartID2.Properties.NullText = "";
            this.edtBgPositionsartID2.Properties.ShowFooter = false;
            this.edtBgPositionsartID2.Properties.ShowHeader = false;
            this.edtBgPositionsartID2.Properties.ValueMember = "BgPositionsartID";
            this.edtBgPositionsartID2.Size = new System.Drawing.Size(320, 24);
            this.edtBgPositionsartID2.TabIndex = 4;
            // 
            // lblBgPositionsartID2
            // 
            this.lblBgPositionsartID2.Location = new System.Drawing.Point(8, -1);
            this.lblBgPositionsartID2.Name = "lblBgPositionsartID2";
            this.lblBgPositionsartID2.Size = new System.Drawing.Size(120, 24);
            this.lblBgPositionsartID2.TabIndex = 0;
            this.lblBgPositionsartID2.Text = "Erwerbsunkosten";
            // 
            // qryBgBudget
            // 
            this.qryBgBudget.HostControl = this;
            this.qryBgBudget.SelectStatement = "SELECT * FROM BgBudget WHERE BgbudgetID = {0}";
            // 
            // DlgAyPosition
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.ClientSize = new System.Drawing.Size(458, 416);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panUnkosten);
            this.Controls.Add(this.panBetrag);
            this.Controls.Add(this.panButton);
            this.Controls.Add(this.panBuchungstext);
            this.Controls.Add(this.panSpezkonto);
            this.Controls.Add(this.panPosition);
            this.Controls.Add(this.panTop);
            this.Name = "DlgAyPosition";
            this.Text = "Budget Position";
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgAuszahlungPerson)).EndInit();
            this.panZahlungsmodusGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgAuszahlungPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgAuszahlungPerson)).EndInit();
            this.panZahlungsmodus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgZahlungsmodusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgZahlungsmodusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReferenzNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtReferenzNummer.Properties)).EndInit();
            this.panAusgabekonto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optZahlungsmodus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungGanzeUe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrechnungPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optVerrechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            this.panButton.ResumeLayout(false);
            this.panPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgGruppeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgGruppeCode)).EndInit();
            this.panMain.ResumeLayout(false);
            this.tabBgPosition.ResumeLayout(false);
            this.tpgZahlungsmodus.ResumeLayout(false);
            this.tpgVerrechnung.ResumeLayout(false);
            this.tpgBemerkung.ResumeLayout(false);
            this.panSpezkonto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).EndInit();
            this.panBuchungstext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            this.panBetrag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtReduktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragRechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).EndInit();
            this.panUnkosten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan_BaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPositionsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgGruppe)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.userCancel = false;
			if (this.qryBgPosition.Post())
			{
				closing = true;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (this.qryBgPosition.Count > 0)
			{
				this.qryBgPosition.Row.AcceptChanges();
				this.qryBgPosition.RowModified = false;
			}
			closing = true;
			this.Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (this.qryBgPosition.Delete())
			{
				this.userCancel = false;
				closing = true;
				this.Close();
			}
		}

		#region qryBgPosition_Insert (ActiveSqlQuery)
		private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
		{
			this.qryBgPosition["BgBudgetID"] = this.BgBudgetID;
			this.qryBgPosition["BgKategorieCode"] = (int)this.BgKategorieCode;
			this.qryBgPosition["BetragBudget"] = (decimal)0;
			this.qryBgPosition["BetragBudget_2"] = (decimal)0;

			this.qryBgPosition["AuszahlungsArt"] = 0;
			this.qryBgPosition["Verrechnung"] = false;

			if ((bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt)
			{
				this.qryBgPosition["DatumVon"] = new DateTime(1900, 1, 2);
			}

			string editMaskFilter = "{0} AND (SPT.";

			if ((bool)qryBgBudget["MasterBudget"])
				editMaskFilter += "Masterbudget_EditMask";
			else
				editMaskFilter += "Monatsbudget_EditMask";

			if ((int)qryBgBudget["BgBewilligungStatusCode"] < (int)BgBewilligungStatus.Erteilt)
				editMaskFilter += " & 0x8) = 0x8";
			else
				editMaskFilter += " & 0x8000) = 0x8000";


            qryBgGruppe.Fill(string.Format(sqlBgGruppeCode, editMaskFilter, BgBudgetID), (int)BgKategorieCode);
            qryBgPositionsart.Fill(string.Format(sqlBgPositionsart, editMaskFilter, BgBudgetID), (int)BgKategorieCode);

			this.qryBgAuszahlungPerson.Fill(DBNull.Value);
		}
		#endregion

		#region qryBgPosition_Post (ActiveSqlQuery)
		private SqlQuery ParentChildCopy(object BgPositionID)
		{
			return DBUtil.OpenSQL(@"
				SELECT DISTINCT BgPositionID AS Pk, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
				INTO #BgPosition
				FROM dbo.BgPosition WHERE BgPositionID = {0} OR BgPositionID_Parent = {0}

				EXECUTE dbo.spXParentChildCopy '#BgPosition', 
				                           'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
				                           'BgPositionID_CopyOf, DatumVon, DatumBis', 'BgPositionID, ''19000102'', DatumBis', 'DatumBis, OldID'

				SELECT BPO.*, TMP.Pk
				FROM #BgPosition           TMP
				  INNER JOIN dbo.vwBgPosition  BPO ON BPO.BgPositionID = TMP.KeyNew
				ORDER BY CASE WHEN Pk = {0} THEN 0 ELSE 1 END

				DROP TABLE #BgPosition"
                , BgPositionID);
		}

		private decimal GetBetragBudget(object BgPositionID)
		{
			return (decimal)DBUtil.ExecuteScalarSQL(@"
				DECLARE @BgPositionID int,
				        @Betrag       money
				SET @BgPositionID = {0}

				WHILE ( @Betrag IS NULL AND EXISTS (SELECT * FROM BgPosition WHERE BgPositionID = @BgPositionID) ) BEGIN
				  SELECT @BgPositionID = BPO.BgPositionID_CopyOf,
				         @Betrag = CASE
				                     WHEN BBG.MasterBudget = 0        THEN NULL
				                     WHEN BPO.DatumVon   < '19010101' THEN NULL
				                     ELSE SUM(BPO.BetragBudget)
				                   END
				  FROM dbo.vwBgPosition      BPO
				    INNER JOIN dbo.BgBudget  BBG ON BBG.BgBudgetID = BPO.BgBudgetID
				  WHERE BPO.BgPositionID = @BgPositionID
				  GROUP BY BBG.MasterBudget, BPO.DatumVon, BPO.BgPositionID_CopyOf
				END
				SELECT IsNull(@Betrag, $0.0000)"
                , BgPositionID);
		}

		private Hashtable ht = new Hashtable();
		private SqlQuery qryCopy;

		private bool BgPositionsartID_Modified = false;
		private bool SaveBgAuszahlungPerson = false;

		private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
		{
			SaveBgAuszahlungPerson = false;

			if (closing)
			{
				qryBgPosition.Row.AcceptChanges();
				qryBgPosition.RowModified = false;
				return;
			}

			if (this.panPosition.Visible)
				DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);

            if (this.panSpezkonto.Visible)
            {
                DBUtil.CheckNotNullField(edtBgSpezkontoID, lblBgSpezkontoID.Text);
            }

			DBUtil.CheckNotNullField(edtBetragBudget, lblBetragBudget.Text);
			if ((decimal)this.qryBgPosition["BetragBudget"] <= (decimal)0)
				throw new KissInfoException(KissMsg.GetMLMessage("DlgAyPosition", "BetragZuKlein", "Der Betrag muss grösser Fr. 0.00 sein", KissMsgCode.MsgInfo), this.edtBetragBudget);

			if (this.edtBetragRechnung.Visible && !qryBgPosition.ColumnModified("BetragRechnung"))
			{
				if (this.qryBgPosition.Row.HasVersion(DataRowVersion.Original))
				{
					if (this.qryBgPosition["BetragBudget", DataRowVersion.Original].Equals(this.qryBgPosition["BetragRechnung", DataRowVersion.Original]))
						this.qryBgPosition["BetragRechnung"] = this.qryBgPosition["BetragBudget"];
				}
				else
					this.qryBgPosition["BetragRechnung"] = this.qryBgPosition["BetragBudget"];
			}

			if (this.qryBgPosition.Row.HasVersion(DataRowVersion.Original))
			{
				decimal ReduktionMod = (decimal)this.qryBgPosition["BetragRechnung", DataRowVersion.Original] - (decimal)this.qryBgPosition["BetragRechnung"];
				decimal AbzugMod = (decimal)this.qryBgPosition["BetragBudget", DataRowVersion.Original] - (decimal)this.qryBgPosition["BetragBudget"];

				if (this.edtBetragRechnung.Visible)
				{
					this.qryBgPosition["Reduktion"] = (decimal)this.qryBgPosition["Reduktion", DataRowVersion.Original] + ReduktionMod;
					this.qryBgPosition["Abzug"] = (decimal)this.qryBgPosition["Abzug", DataRowVersion.Original] - ReduktionMod + AbzugMod;
				}
				else if (this.edtReduktion.Visible)
				{
					this.qryBgPosition["Betrag"] = (decimal)this.qryBgPosition["Betrag", DataRowVersion.Original]
						- AbzugMod + (decimal)this.qryBgPosition["Abzug"] - (decimal)this.qryBgPosition["Abzug", DataRowVersion.Original];
				}
				else
					this.qryBgPosition["Betrag"] = (decimal)this.qryBgPosition["Betrag", DataRowVersion.Original] - AbzugMod;
			}
			else
				this.qryBgPosition["Betrag"] = this.qryBgPosition["BetragBudget"];

			decimal BetragBudget = 0;
			if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionID"]))
			{
				int BgPositionID_CopyOf = DBUtil.IsEmpty(this.qryBgPosition["BgPositionID_CopyOf"]) ? (int)this.qryBgPosition["BgPositionID"] : (int)this.qryBgPosition["BgPositionID_CopyOf"];
				BetragBudget = this.GetBetragBudget(BgPositionID_CopyOf);
			}

			if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]))
			{
				SqlQuery qry = AyUtil.GetRichtlinie((int)this.qryBgPosition["BgPositionsartID"], this.BgBudgetID);
				if (qry.Count == 1 && this.edtBetragBudget.EditMode != EditModeType.ReadOnly)
				{
					if (!DBUtil.IsEmpty(qry["PR_MIN"]) && (decimal)this.qryBgPosition["Betrag"] < (decimal)qry["PR_MIN"])
						throw new KissInfoException(KissMsg.GetMLMessage("DlgAyPosition", "MinBetrag", "Der Betrag muss mindestens Fr. {0:n2} betragen", KissMsgCode.MsgInfo, qry["PR_MIN"]), this.edtBetragBudget);
					else if (!DBUtil.IsEmpty(qry["PR_MAX"]) && (decimal)this.qryBgPosition["Betrag"] > (decimal)qry["PR_MAX"] && (decimal)this.qryBgPosition["Betrag"] > BetragBudget)
						throw new KissInfoException(KissMsg.GetMLMessage("DlgAyPosition", "MaxBetrag", "Der Betrag kann maximal Fr. {0:n2} betragen", KissMsgCode.MsgInfo, Math.Max(BetragBudget, (decimal)qry["PR_MAX"])), this.edtBetragBudget);
				}
			}

			if ((this.EditMask & 0x6) != 0x6 && (this.EditMask & 0x6) != 0 && !DBUtil.IsEmpty(this.qryBgPosition["BgPositionID"]))
			{
				if ((this.EditMask & 0x2) != 0x2)
				{
					if (Convert.ToDecimal(this.qryBgPosition["BetragBudget"]) < BetragBudget)
						throw new KissInfoException(KissMsg.GetMLMessage("DlgAyPosition", "BetragMussGroesserSein", "Der Betrag muss grösser oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein", KissMsgCode.MsgInfo, BetragBudget));
				}
				else
				{
					if (Convert.ToDecimal(this.qryBgPosition["BetragBudget"]) > BetragBudget)
						throw new KissInfoException(KissMsg.GetMLMessage("DlgAyPosition", "BetragMussKleinerSein", "Der Betrag muss kleiner oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein", KissMsgCode.MsgInfo, BetragBudget));
				}
			}

			DBUtil.CheckNotNullField(optVerrechnung, KissMsg.GetMLMessage("DlgAyPosition", "Verrechnung", "Verrechnung"));
			if ((bool)qryBgPosition["Verrechnung"])
				DBUtil.CheckNotNullField(edtBaPersonID, KissMsg.GetMLMessage("DlgAyPosition", "VerrechnungPerson", "Verrechnung - Person"));

			if (!this.edtBgPositionsartID2.Visible)
				this.qryBgPosition["BgPositionsartID_2"] = DBNull.Value;

			BgPositionsartID_Modified = this.qryBgPosition.ColumnModified("BgPositionsartID")
				|| (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID_2"]) && this.qryBgPosition.ColumnModified("BgPositionsartID_2"));

			if (!((bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.InVorbereitung))
			{
				if (!(this.tpgZahlungsmodus.HideTab || ((BgKategorie)qryBgPosition["BgKategorieCode"] == BgKategorie.Einnahmen && DBUtil.IsEmpty(qryBgPosition["BgPositionsartID_2"]))))
				{
					SaveBgAuszahlungPerson = true;
					this.qryBgAuszahlungPerson.EndCurrentEdit();

					switch ((int)qryBgPosition["AuszahlungsArt"])
					{
						case 0:  // Für ganze UE
						case 1:  // Pro Person
							DBUtil.CheckNotNullField(edtBgZahlungsmodusID, lblBgZahlungsmodusID.Text);
							qryBgPosition["BgSpezkontoID_GUI"] = DBNull.Value;
							break;

						case 2: // Ausgabekonto
                            DBUtil.CheckNotNullField(edtBgSpezkontoID1, lblBgSpezkontoID1.Text);
							break;
					}
				}

				switch ((BgKategorie)qryBgPosition["BgKategorieCode"])
				{
					case BgKategorie.Einnahmen:
					case BgKategorie.Kuerzung:
						qryBgPosition["BgSpezkontoID"] = DBNull.Value;
						break;

					case BgKategorie.Ausgaben:
						this.qryBgPosition["BgSpezkontoID"] = this.qryBgPosition["BgSpezkontoID_GUI"];
						break;

					case BgKategorie.Abzahlung:
					case BgKategorie.Vorabzug:
						this.qryBgPosition["BgSpezkontoID"] = this.qryBgPosition["BgSpezkontoID_GUI"];
						break;
				}
			}

			if ((bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt
				&& this.qryBgPosition["DatumVon"] == DBNull.Value)
			{
				Array Noncritical = new string[] { "BgPositionID_GUI", "Buchungstext", "BgSpezkontoID", "BgSpezkontoID_GUI", "AuszahlungsArt", "Betrag", "Reduktion", "Abzug", "BetragRechnung", "DatumBis" };

				bool ColumnChanged = false;
				foreach (DataColumn col in this.qryBgPosition.DataTable.Columns)
				{
					if (this.qryBgPosition.ColumnModified(col.ColumnName) && Array.IndexOf(Noncritical, col.ColumnName) == -1)
					{
						ColumnChanged = true;
						break;
					}
				}

				if (ColumnChanged)
				{
					ht = new Hashtable(this.qryBgPosition.DataTable.Columns.Count);
					foreach (DataColumn col in this.qryBgPosition.DataTable.Columns)
						ht.Add(col.ColumnName, this.qryBgPosition[col.ColumnName]);

					this.qryBgPosition.Row.RejectChanges();

					if (Session.Transaction == null) Session.BeginTransaction();
					this.qryCopy = this.ParentChildCopy(this.qryBgPosition["BgPositionID"]);

					this.qryBgPosition["Buchungstext"] = ht["Buchungstext"];
					this.qryBgPosition["BgPositionID_GUI"] = ht["BgPositionID_GUI"];
					this.qryBgPosition["BgSpezkontoID"] = ht["BgSpezkontoID"];
					this.qryBgPosition["BgSpezkontoID_GUI"] = ht["BgSpezkontoID_GUI"];
					this.qryBgPosition["DatumBis"] = new DateTime(1900, 1, 1);
				}
			}

			if (Session.Transaction == null) Session.BeginTransaction();
		}

		private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
		{
			SqlQuery qry = DBUtil.OpenSQL(@"
                --SQLCHECK_IGNORE--
				SELECT * FROM dbo.vwBgPosition
				WHERE BgPositionID = {0} OR BgPositionID_Parent = {0}
				ORDER BY CASE WHEN BgPositionID = {0} THEN 0 ELSE 1 END"
                , this.qryBgPosition["BgPositionID"]);

			bool loop = true;
			do
			{
				#region Save 2nd Record
				qry.First();
				// Unkosten
				if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID_2"]))
				{
					if (qry.Count == 1)
					{
						qry.Insert(qryBgPosition.TableName);

						qry["BgBudgetID"] = this.BgBudgetID;
						qry["BgKategorieCode"] = (int)BgKategorie.Ausgaben;
						qry["BgPositionID_Parent"] = this.qryBgPosition["BgPositionID"];

						qry["BetragBudget"] = (decimal)0;

						qry["DatumVon"] = this.qryBgPosition["DatumVon"];
					}
					else
						qry.Next();

					if (!DBUtil.IsEmpty(this.qryBgPosition["BetragBudget_2"]))
						qry["Betrag"] = (decimal)qry["Betrag"] - (decimal)qry["BetragBudget"] + (decimal)this.qryBgPosition["BetragBudget_2"];

					qry["BgSpezkontoID"] = this.qryBgPosition["BgSpezkontoID_GUI"];
					qry["DatumBis"] = this.qryBgPosition["DatumBis"];
					qry["BgPositionsartID"] = this.qryBgPosition["BgPositionsartID_2"];

					qry.Post(qryBgPosition.TableName);
					this.qryBgPosition["BgPositionID_2"] = qry["BgPositionID"];
				}
				else
					DBUtil.ExecSQLThrowingException("DELETE FROM BgPosition WHERE BgPositionID = {0}", this.qryBgPosition["BgPositionID_2"]);
				#endregion

				if (ht.Keys.Count == 0)
					loop = false;
				else
				{
					qry = this.qryCopy;
					this.qryBgPosition["BgPositionID"] = qry["BgPositionID"];
					if (qry.Next()) this.qryBgPosition["BgPositionID_2"] = qryCopy["BgPositionID"];
					qry.First();
					this.qryBgPosition.Row.AcceptChanges();

					#region Restore changes from HashTable
					foreach (object key in ht.Keys)
					{
						switch (key.ToString())
						{
							case "BgPositionID":
							case "BgPositionID_2":
								break;

							default:
								this.qryBgPosition[key.ToString()] = ht[key];
								break;
						}
					}
					ht.Clear();
					#endregion

					#region Save 1st Record to Database (only Masterbudget History)
					foreach (DataColumn col in qry.DataTable.Columns)
					{
						switch (col.ColumnName)
						{
							case "BgPositionID_CopyOf":
							case "BgPositionID_Parent":
							case "DatumVon":
							case "DatumBis":
							case "OldID":
							case "BgPositionTS":
								break;

							case "Pk":
								break;

							default:
								qry[col.ColumnName] = this.qryBgPosition[col.ColumnName];
								break;
						}
					}
					qry.Post("BgPosition");

					foreach (DataColumn col in qry.DataTable.Columns)
						if (col.ColumnName != "Pk")
							this.qryBgPosition[col.ColumnName] = qry[col.ColumnName];
					#endregion
				}
			} while (loop);

			if (SaveBgAuszahlungPerson)
			{
				if ((BgKategorie)qryBgPosition["BgKategorieCode"] == BgKategorie.Ausgaben)
					qryBgPosition["BgPositionID_GUI"] = this.qryBgPosition["BgPositionID"];
				else
					qryBgPosition["BgPositionID_GUI"] = this.qryBgPosition["BgPositionID_2"];

				switch ((int)qryBgPosition["AuszahlungsArt"])
				{
					case 0:  // Für ganze UE
						#region Save and Update Teilzahlungen
						if (this.qryBgAuszahlungPerson.RowModified || this.qryBgPosition.ColumnModified("AuszahlungsArt"))
						{
							DBUtil.ExecSQL(@"
								DELETE dbo.BgAuszahlungPerson WHERE BgPositionID = {0}",
								qryBgPosition["BgPositionID_GUI"]);

							DBUtil.ExecSQL(@"
								INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, BaPersonID, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer)
								  SELECT {0}, NULL, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, IsNull({2}, ReferenzNummer)
								  FROM dbo.BgZahlungsmodus
								  WHERE BgZahlungsmodusID = {1}",
								qryBgPosition["BgPositionID_GUI"],
								qryBgAuszahlungPerson["BgZahlungsmodusID"],
								qryBgAuszahlungPerson["ReferenzNummer"]);
						}
						#endregion
						break;

					case 1:  // Pro Person
						#region Save and Update Teilzahlungen
						if (this.qryBgAuszahlungPerson.RowModified || this.qryBgPosition.ColumnModified("AuszahlungsArt"))
						{
							DBUtil.ExecSQL(@"
								DELETE BgAuszahlungPerson WHERE BgPositionID = {0}",
								qryBgPosition["BgPositionID_GUI"]);

							foreach (DataRow row in qryBgAuszahlungPerson.DataTable.Rows)
							{
								DBUtil.ExecSQL(@"
									INSERT INTO BgAuszahlungPerson (BgPositionID, BaPersonID, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer)
									  SELECT {0}, {3}, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, IsNull({2}, ReferenzNummer)
									  FROM BgZahlungsmodus
									  WHERE BgZahlungsmodusID = {1}",
									qryBgPosition["BgPositionID_GUI"],
									qryBgAuszahlungPerson["BgZahlungsmodusID"],
									qryBgAuszahlungPerson["ReferenzNummer"],
									qryBgAuszahlungPerson["BaPersonID"]);
							}
						}
						#endregion
						break;

					case 2: // Ausgabekonto
						DBUtil.ExecSQL(@"
							DELETE dbo.BgAuszahlungPerson WHERE BgPositionID = {0}",
							qryBgPosition["BgPositionID_GUI"]);
						break;
				}
				DBUtil.ExecSQLThrowingException(@"
					DECLARE @BgPositionID  int  SET @BgPositionID = {1}

					WHILE 1 = 1 BEGIN
					  SET @BgPositionID = (SELECT TOP 1 BgPositionID FROM BgPosition WHERE BgBudgetID = {0} AND BgKategorieCode = 2 AND BgPositionID_CopyOf = @BgPositionID)
					  IF @BgPositionID IS NULL BREAK

					  UPDATE dbo.BgPosition SET BgSpezkontoID = {2} WHERE BgPositionID = @BgPositionID
					  IF {2} IS NOT NULL BEGIN
					    DELETE BgAuszahlungPerson WHERE BgPositionID = @BgPositionID
					  END
					END

					SELECT @BgPositionID = BgPositionID_CopyOf FROM BgPosition WHERE BgBudgetID = {0} AND BgKategorieCode = 2 AND BgPositionID = {1}
					WHILE @BgPositionID IS NOT NULL BEGIN
					  UPDATE dbo.BgPosition SET BgSpezkontoID = {2} WHERE BgPositionID = @BgPositionID AND BgBudgetID = {0}
					  IF {2} IS NOT NULL BEGIN
					    DELETE BgAuszahlungPerson WHERE BgPositionID = @BgPositionID
					  END

					  SET @BgPositionID = (SELECT BgPositionID_CopyOf FROM BgPosition WHERE BgBudgetID = {0} AND BgKategorieCode = 2 AND BgPositionID = @BgPositionID)
					END"
                    , this.qryBgPosition["BgBudgetID"], qryBgPosition["BgPositionID_GUI"]
					, this.qryBgPosition["BgSpezkontoID_GUI"]);
			}
			Session.Commit();

			if (BgPositionsartID_Modified)
			{
				if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]) &&
					(int)this.qryBgPosition["BgPositionsartID"] > 60000 && (int)this.qryBgPosition["BgPositionsartID"] <= 60017)
				{
					DBUtil.ExecSQL("EXECUTE spAyBudget_Update {0}, 0, 0, 0, {1}"
						, this.qryBgPosition["BgBudgetID"], this.qryBgPosition["BgPositionID"]);
				}
				else if (!DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID_2"]) &&
					(int)this.qryBgPosition["BgPositionsartID_2"] > 60000 && (int)this.qryBgPosition["BgPositionsartID_2"] <= 60017)
				{
					DBUtil.ExecSQL("EXECUTE spAyBudget_Update {0}, 0, 0, 0, {1}"
						, this.qryBgPosition["BgBudgetID"], this.qryBgPosition["BgPositionID_2"]);
				}
				this.qryBgPosition.Row.AcceptChanges();
				this.qryBgPosition.RowModified = false;
				if (!closing) this.qryBgPosition.Fill(this.qryBgPosition["BgPositionID"]);
			}
			this.qryBgPosition.Row.AcceptChanges();
			this.qryBgPosition.RowModified = false;
		}
		#endregion

		#region qryBgPosition_Delete (ActiveSqlQuery)
		private void qryBgPosition_BeforeDelete(object sender, System.EventArgs e)
		{
			if ((bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] >= (int)BgBewilligungStatus.Erteilt
				&& DBUtil.IsEmpty(this.qryBgPosition["DatumVon"]))
			{
				this.qryBgPosition.Row.RejectChanges();
				this.qryBgPosition["DatumBis"] = new DateTime(1900, 1, 1);
				this.qryBgPosition.Post();
			}
			else
			{
				Session.BeginTransaction();
				DBUtil.ExecSQLThrowingException("DELETE FROM BgPosition WHERE BgPositionID = {0}", this.qryBgPosition["BgPositionID_2"]);
			}
		}

		private void qryBgPosition_AfterDelete(object sender, System.EventArgs e)
		{
			if (Session.Transaction != null)
			{
				Session.Commit();
			}
		}
		#endregion

		private void qryBgPosition_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
		{
			if (e.ProposedValue.Equals(e.Row[e.Column, DataRowVersion.Current])) return;

			if (e.Column.ColumnName == "BgGruppeCode" && !DBUtil.IsEmpty(e.Row[e.Column]))
			{
				DataRow[] rows = qryBgPositionsart.DataTable.Select(string.Format("BgGruppeCode = {0}", e.Row[e.Column]));
				if (rows.Length == 1)
					e.Row["BgPositionsartID"] = rows[0]["BgPositionsartID"];
				else if (!DBUtil.IsEmpty(e.Row["BgPositionsartID"]))
				{
					rows = qryBgPositionsart.DataTable.Select(string.Format("BgGruppeCode = {0} AND BgPositionsartID = {1}"
						, e.Row[e.Column], (int)e.Row[e.Column] + ((int)e.Row["BgPositionsartID"] % 10)));
					if (rows.Length == 1)
						e.Row["BgPositionsartID"] = rows[0]["BgPositionsartID"];
				}
			}
			else if (e.Column.ColumnName == "BgPositionsartID" && !DBUtil.IsEmpty(e.Row[e.Column]))
			{
				DataRow[] rows = qryBgPositionsart.DataTable.Select(string.Format("BgPositionsartID = {0}", e.Row[e.Column]));
				if (rows.Length > 0)
				{
					e.Row["BgKategorieCode"] = rows[0]["BgKategorieCode"];

					SqlQuery qry = AyUtil.GetRichtlinie(rows[0]["sqlRichtlinie"], this.BgBudgetID);
					if (qry.Count == 1)
					{
						if (DBUtil.IsEmpty(e.Row["BaPersonID"]))
							e.Row["BetragBudget"] = DBUtil.IsEmpty(qry["UE_DEF"]) ? qry["UE_MIN"] : qry["UE_DEF"];
						else
							e.Row["BetragBudget"] = DBUtil.IsEmpty(qry["PR_DEF"]) ? qry["PR_MIN"] : qry["PR_DEF"];
					}
				}
			}
			else if (e.Column.ColumnName == optVerrechnung.DataMember && !DBUtil.IsEmpty(e.Row[e.Column]))
			{
				if (!(bool)e.Row[e.Column])
					e.Row["BaPersonID"] = DBNull.Value;
			}

			this.qryBgPosition.RefreshDisplay();
		}

		private void SetMaskEdit(DataRow[] rows)
		{
			try
			{
				if (rows.Length == 0) return;

				if ((bool)qryBgBudget["MasterBudget"])
					EditMask = (int)(rows[0]["Masterbudget_EditMask"]);
				else
					EditMask = (int)(rows[0]["Monatsbudget_EditMask"]);

				if ((int)qryBgBudget["BgBewilligungStatusCode"] < (int)BgBewilligungStatus.Erteilt)
				{
					EditMask = (EditMask & 0xFFF);
				}
				else
				{
					EditMask = (EditMask & 0xFFF000) / 0x1000;
				}

				this.edtBetragBudget.EditMode = (EditMask & 0x6) > 0 ? EditModeType.Normal : EditModeType.ReadOnly;

				if ((bool)rows[0]["ProPerson"] != (bool)rows[0]["ProUE"])
				{
					this.optVerrechnung.EditMode = EditModeType.ReadOnly;
				}
				else
				{
					this.optVerrechnung.EditMode = (EditMask & 0x80) > 0 ? EditModeType.Normal : EditModeType.ReadOnly;
				}
				
                //this.edtBaPersonID.EditMode = this.optVerrechnung.EditMode;
                if ((EditMask & 0x80) > 0 && (bool)this.optVerrechnung.EditValue && this.qryBgPosition.CanUpdate)
                {
                    this.edtBaPersonID.EditMode = EditModeType.Normal;
                }
                else
                {
                    this.edtBaPersonID.EditMode = EditModeType.ReadOnly;
                }
			}
			finally
			{
				this.qryBgPosition.EnableBoundFields();
			}
		}

		private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
		{
			edtBgGruppeCode_EditValueChanged(sender, EventArgs.Empty);
			edtBgPositionsartID_EditValueChanged(sender, EventArgs.Empty);

			optZahlungsmodus_EditValueChanged(sender, EventArgs.Empty);
			optVerrechnung_EditValueChanged(sender, EventArgs.Empty);

			DataRow[] rows = this.qryBgPositionsart.DataTable.Select("BgPositionsartID = " + DBUtil.SqlLiteral(this.qryBgPosition["BgPositionsartID"]));
			if (rows.Length == 0)
				return;

			this.SetMaskEdit(rows);



			/*  EditMask
			 *  --------
			 *  0x1:	Löschen
			 *  0x2:	Betrag ändern -
			 *  0x4:	Betrag ändern +
			 *  0x8:	Neu
			 * 
			 *  0x10:	Position Gruppe
			 *  0x20:	Position TypID
			 *  0x40:	Buchungstext
			 *  0x80:	Verrechnung
			 * 
			 *  0x100:	Bemerkungen
			 *  0x200:	Betrag Rechnung ändern
			 *  0x400:  Position Gruppe (Filter)
			 *  0x800:
			 */

			bool verfuegtVisible = ((int)(rows[0]["Masterbudget_EditMask"]) & 0x200000) > 0 ||
				((int)(rows[0]["Monatsbudget_EditMask"]) & 0x200200) > 0;

			this.qryBgPosition.CanDelete = (EditMask & 0x1) > 0 ? this.qryBgPosition.CanUpdate : false;
			this.btnDelete.Enabled = (EditMask & 0x1) > 0 ? this.qryBgPosition.CanUpdate : false;

			this.edtBetragRechnung.Visible = verfuegtVisible;
			this.edtBetragRechnung.EditMode = (EditMask & 0x200) > 0 ? EditModeType.Normal : EditModeType.ReadOnly;

			this.edtBgGruppeCode.EditMode = (EditMask & 0x410) > 0 && !DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]) ? EditModeType.Normal : EditModeType.ReadOnly;
			this.edtBgPositionsartID.EditMode = (EditMask & 0x430) > 0 && !DBUtil.IsEmpty(this.qryBgPosition["BgPositionsartID"]) ? EditModeType.Normal : EditModeType.ReadOnly;
			this.edtBuchungstext.EditMode = (EditMask & 0x40) > 0 ? EditModeType.Normal : EditModeType.ReadOnly;

			this.edtBemerkung.EditMode = (EditMask & 0x100) > 0 ? EditModeType.Normal : EditModeType.ReadOnly;


			if ((EditMask & 0x400) == 0x400 && !DBUtil.IsEmpty(qryBgPosition["BgGruppeFilter"]))
			{
				rows = qryBgGruppe.DataTable.Select(string.Format("Value3 = '{0}'", qryBgPosition["BgGruppeFilter"]));

				if (rows.Length > 0)
				{
					this.edtBgGruppeCode.EditMode = EditModeType.Normal;
					this.edtBgPositionsartID.EditMode = EditModeType.Normal;
					qryBgGruppe.DataTable.DefaultView.RowFilter = string.Format("Value3 = '{0}'", qryBgPosition["BgGruppeFilter"]);
				}
			}
			else
				qryBgGruppe.DataTable.DefaultView.RowFilter = string.Format("BgKategorieCode = {0}", (int)this.BgKategorieCode);

			this.qryBgPosition.EnableBoundFields();
		}


		private void qryBeleg_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
		{
			this.qryBgPosition.RowModified = true;
		}

		#region Runtime Layout
		private void edtBgGruppeCode_EditValueChanged(object sender, System.EventArgs e)
		{
			int BgKategorieCode = (int)this.BgKategorieCode;
			object BgGruppeCode;

			if (sender == this.edtBgGruppeCode)
				BgGruppeCode = this.edtBgGruppeCode.EditValue;
			else
				BgGruppeCode = this.qryBgPosition["BgGruppeCode"];

			if (DBUtil.IsEmpty(BgGruppeCode)) return;

			DataRow[] rows = qryBgGruppe.DataTable.Select(string.Format("Code = 0{0}", BgGruppeCode));
			if (rows.Length > 0)
				BgKategorieCode = (int)rows[0]["BgKategorieCode"];

			qryBgPositionsart.DataTable.DefaultView.RowFilter = string.Format("BgKategorieCode = {0} AND BgGruppeCode = 0{1}", BgKategorieCode, BgGruppeCode);
			rows = qryBgPositionsart.DataTable.Select(qryBgPositionsart.DataTable.DefaultView.RowFilter);
			this.edtBgPositionsartID.Properties.DropDownRows = Math.Min(rows.Length, 10);

			if (edtBgGruppeCode.UserModified)
			{
				if (!BgKategorieCode.Equals(qryBgPosition["BgKategorieCode"]))
				{
					this.tpgZahlungsmodus.HideTab = BgKategorieCode != (int)BgKategorie.Ausgaben;
					this.tabBgPosition.SelectedTabIndex = BgKategorieCode == (int)BgKategorie.Ausgaben ? 0 : 1;
				}

				edtBgGruppeCode.UserModified = false;
				qryBgPosition[edtBgGruppeCode.DataMember] = edtBgGruppeCode.EditValue;
			}
		}

		private void edtBgPositionsartID_EditValueChanged(object sender, System.EventArgs e)
		{
			object BgPositionsartID;

			try
			{
				if (sender == this.edtBgPositionsartID)
					BgPositionsartID = this.edtBgPositionsartID.EditValue;
				else
					BgPositionsartID = this.qryBgPosition["BgPositionsartID"];

				DataRow[] rows = this.qryBgPositionsart.DataTable.Select("BgPositionsartID = " + DBUtil.SqlLiteral(BgPositionsartID));

				this.SetMaskEdit(rows);
				if (rows.Length > 0)
					this.edtBgSpezkontoID1.Properties.DataSource = AyUtil.GetSpezKonto(
						this.BgBudgetID, BgSpezkontoTyp.Ausgabekonto, rows[0]["BgKostenartID"]);

				if (this.BgKategorieCode == BgKategorie.Einnahmen)
				{
					// Enable disable Unkosten
					if (BgPositionsartID != null &&
						(BgPositionsartID.Equals((int)AyPositionsartID.Nettolohn) ||
						BgPositionsartID.Equals((int)AyPositionsartID.ALVTaggelder) ||
						BgPositionsartID.Equals((int)AyPositionsartID.ALVNachzahlung)))
					{
						this.lblSteuer.Visible = true;
						this.edtReduktion.Visible = true;
						this.panUnkosten.Visible = true;
						this.tpgZahlungsmodus.HideTab = false;

						if (filling)
                            this.edtBgPositionsartID2.EditValue = 60017; // 60005; #4083 Korrektur Positionsarten!  // Asyl: Eff. Erwerbsunkosten

						this.edtBgSpezkontoID1.Properties.DataSource = AyUtil.GetSpezKonto(
							this.BgBudgetID, BgSpezkontoTyp.Ausgabekonto
							, DBUtil.ExecuteScalarSQL(@"SELECT MIN(BgKostenartID) FROM BgPositionsart WHERE BgPositionsartID = {0}", this.edtBgPositionsartID2.EditValue));
					}
					else
					{
						this.lblSteuer.Visible = false;
						this.edtReduktion.Visible = false;
						this.panUnkosten.Visible = false;
						this.tpgZahlungsmodus.HideTab = true;
						this.tabBgPosition.SelectedTabIndex = 1;
						this.edtBgPositionsartID2.EditValue = DBNull.Value;
					}
				}

				if (!(sender is IKissUserModified && ((IKissUserModified)sender).UserModified)) return;
				((IKissUserModified)sender).UserModified = false;

                if (rows.Length > 0 || (bool)rows[0]["ProPerson"] != (bool)rows[0]["ProUE"])
                {
                    this.qryBgPosition["Verrechnung"] = (bool)rows[0]["ProPerson"];
                }

				this.qryBgPosition["BgPositionsartID"] = BgPositionsartID;
			}
			catch { }
		}

		private void optZahlungsmodus_EditValueChanged(object sender, System.EventArgs e)
		{
			int AuszahlungsArt = 0;
            int? ausz;

            if (sender == this.optZahlungsmodus)
            {
                ausz = this.optZahlungsmodus.EditValue as int?;
            }
            else
            {
                ausz = this.qryBgPosition[optZahlungsmodus.DataMember] as int?;
            }

            if (ausz.HasValue)
            {
                AuszahlungsArt = ausz.Value;
            }
            else
            {
                optZahlungsmodus.EditValue = AuszahlungsArt;
            }

			switch (AuszahlungsArt)
			{
				case 0:  // 1 Teilzahlung
					this.panAusgabekonto.Visible = false;
					this.panZahlungsmodusGrid.Visible = false;

					this.panZahlungsmodus.Dock = DockStyle.Top;
					this.panZahlungsmodus.Visible = true;
					if (qryBgAuszahlungPerson.Count == 0)
					{
						qryBgAuszahlungPerson.Insert(qryBgAuszahlungPerson.TableName);
						qryBgAuszahlungPerson["BaPersonID"] = null;

						qryBgAuszahlungPerson.Post(qryBgAuszahlungPerson.TableName);
						qryBgAuszahlungPerson.RefreshDisplay();
						qryBgAuszahlungPerson.RowModified = true;
					}
					break;

				case 1: // 1+ Teilzahlungen
					this.panAusgabekonto.Visible = false;
					this.panZahlungsmodusGrid.Visible = true;

					this.panZahlungsmodus.Dock = DockStyle.Bottom;
					this.panZahlungsmodus.Visible = true;

					if (qryBgAuszahlungPerson.Count == 0 || DBUtil.IsEmpty(qryBgAuszahlungPerson["BaPersonID"]))
					{
						foreach (DataRow row in qryBgFinanzplan_BaPerson.DataTable.Rows)
						{
							if (DBUtil.IsEmpty(row["BaPersonID"])) continue;
							if (!DBUtil.IsEmpty(qryBgAuszahlungPerson["BaPersonID"]))
								qryBgAuszahlungPerson.Insert(qryBgAuszahlungPerson.TableName);

							qryBgAuszahlungPerson["BaPersonID"] = row["BaPersonID"];
							qryBgAuszahlungPerson.Post(qryBgAuszahlungPerson.TableName);
						}
						qryBgAuszahlungPerson.RefreshDisplay();
						qryBgAuszahlungPerson.RowModified = true;
					}
					break;

				case 2:  // Ausgabekonto
					this.panAusgabekonto.Visible = true;
					this.panZahlungsmodusGrid.Visible = false;
					this.panZahlungsmodus.Visible = false;
					break;
			}
		}

		private void edtBgZahlungsmodusID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (this.edtBgZahlungsmodusID.UserModified)
			{
				DataRow[] rows = this.qryBgZalungsmodus.DataTable.Select("BgZahlungsmodusID = " + DBUtil.SqlLiteral(this.edtBgZahlungsmodusID.EditValue));
				if (rows.Length > 0)
					this.edtReferenzNummer.EditValue = rows[0]["ReferenzNummer"];
			}
		}

		private void optVerrechnung_EditValueChanged(object sender, System.EventArgs e)
		{
			bool Verrechnung = false;
            bool? ver;

            if (sender == this.optVerrechnung)
            {
                ver = this.optVerrechnung.EditValue as bool?;
            }
            else
            {
                ver = this.qryBgPosition[this.optVerrechnung.DataMember] as bool?;
            }

            if (ver.HasValue)
            {
                Verrechnung = ver.Value;
            }
            else
            {
                this.optVerrechnung.EditValue = Verrechnung;
            }

			if (Verrechnung && this.qryBgPosition.CanUpdate)
			{
				this.edtBaPersonID.EditMode = EditModeType.Normal;
			}
			else
			{
				this.edtBaPersonID.EditMode = EditModeType.ReadOnly;
			}
		}
		#endregion

		private void qryBgAuszahlungPerson_AfterInsert(object sender, System.EventArgs e)
		{

			if (qryBgAuszahlungPerson.Count == 1)
			{
				// TODO
			}
			else
			{
				foreach (DataColumn col in qryBgAuszahlungPerson.DataTable.Columns)
				{
					switch (col.ColumnName)
					{
						case "BgAuszahlungPersonID":
						case "BgAuszahlungPersonTS":
							break;

						default:
							qryBgAuszahlungPerson[col.ColumnName] = qryBgAuszahlungPerson.DataTable.Rows[0][col.ColumnName];
							break;
					}
				}
			}
		}
	}
}
