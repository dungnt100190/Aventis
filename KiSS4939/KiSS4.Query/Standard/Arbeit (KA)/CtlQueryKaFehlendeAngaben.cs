using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryKaFehlendeAngaben : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbbrALV;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colALK;
        private DevExpress.XtraGrid.Columns.GridColumn colAnweisungtyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAustritt;
        private DevExpress.XtraGrid.Columns.GridColumn colBeschftigungsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumbis;
        private DevExpress.XtraGrid.Columns.GridColumn colEintrsichtbarSD;
        private DevExpress.XtraGrid.Columns.GridColumn colErlernterBeruf;
        private DevExpress.XtraGrid.Columns.GridColumn colFachbereich;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colGesprch;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNichtersch;
        private DevExpress.XtraGrid.Columns.GridColumn colNiveauSEMO;
        private DevExpress.XtraGrid.Columns.GridColumn colPerssichtbarSD;
        private DevExpress.XtraGrid.Columns.GridColumn colSARPB;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusWartelisteSEMO;
        private DevExpress.XtraGrid.Columns.GridColumn colVorbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnort;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigKA;
        private DevExpress.XtraGrid.Columns.GridColumn colZuweiser;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtEinsatzPlatzID;
        private KiSS4.Gui.KissLookUpEdit edtProfilCode;
        private KiSS4.Gui.KissLookUpEdit edtZusatzCode;
        private KiSS4.Gui.KissButtonEdit edtZustKaID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAPVNummer;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblDatumvon;
        private KiSS4.Gui.KissLabel lblProfilnummer;
        private KiSS4.Gui.KissLabel lblZusatz;
        private KiSS4.Gui.KissLabel lblZustKAID;
        #endregion

        #region Constructors

        public CtlQueryKaFehlendeAngaben()
        {
            this.InitializeComponent();

            edtEinsatzPlatzID.LoadQuery(DBUtil.OpenSQL(@"
                            SELECT Code = null, Text = null
                    UNION
                    SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                    FROM KaEinsatzplatz2
                    WHERE DatumBis Is Null OR DatumBis >= GETDATE()
                    ORDER BY Text"));
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaFehlendeAngaben));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblProfilnummer = new KiSS4.Gui.KissLabel();
            this.edtProfilCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblAPVNummer = new KiSS4.Gui.KissLabel();
            this.edtEinsatzPlatzID = new KiSS4.Gui.KissLookUpEdit();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.edtZusatzCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblZustKAID = new KiSS4.Gui.KissLabel();
            this.edtZustKaID = new KiSS4.Gui.KissButtonEdit();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.colAbbrALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnweisungtyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeschftigungsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEintrsichtbarSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErlernterBeruf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFachbereich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesprch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNichtersch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNiveauSEMO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerssichtbarSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusWartelisteSEMO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuweiser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfilnummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfilCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfilCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKAID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustKaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Controls.Add(this.edtZustKaID);
            this.tpgSuchen.Controls.Add(this.lblZustKAID);
            this.tpgSuchen.Controls.Add(this.edtZusatzCode);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.edtEinsatzPlatzID);
            this.tpgSuchen.Controls.Add(this.lblAPVNummer);
            this.tpgSuchen.Controls.Add(this.edtProfilCode);
            this.tpgSuchen.Controls.Add(this.lblProfilnummer);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProfilnummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtProfilCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAPVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzPlatzID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZusatzCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZustKAID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZustKaID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            // 
            // lblProfilnummer
            // 
            this.lblProfilnummer.Location = new System.Drawing.Point(11, 38);
            this.lblProfilnummer.Name = "lblProfilnummer";
            this.lblProfilnummer.Size = new System.Drawing.Size(130, 24);
            this.lblProfilnummer.TabIndex = 1;
            this.lblProfilnummer.Text = "Profilnummer";
            this.lblProfilnummer.UseCompatibleTextRendering = true;
            // 
            // edtProfilCode
            // 
            this.edtProfilCode.Location = new System.Drawing.Point(151, 38);
            this.edtProfilCode.LOVName = "KaProfil";
            this.edtProfilCode.Name = "edtProfilCode";
            this.edtProfilCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfilCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProfilCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfilCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtProfilCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProfilCode.Properties.Appearance.Options.UseFont = true;
            this.edtProfilCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtProfilCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfilCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtProfilCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtProfilCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtProfilCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtProfilCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProfilCode.Properties.NullText = "";
            this.edtProfilCode.Properties.ShowFooter = false;
            this.edtProfilCode.Properties.ShowHeader = false;
            this.edtProfilCode.Size = new System.Drawing.Size(250, 24);
            this.edtProfilCode.TabIndex = 2;
            // 
            // lblAPVNummer
            // 
            this.lblAPVNummer.Location = new System.Drawing.Point(11, 72);
            this.lblAPVNummer.Name = "lblAPVNummer";
            this.lblAPVNummer.Size = new System.Drawing.Size(130, 24);
            this.lblAPVNummer.TabIndex = 3;
            this.lblAPVNummer.Text = "APV-Nummer";
            this.lblAPVNummer.UseCompatibleTextRendering = true;
            // 
            // edtEinsatzPlatzID
            // 
            this.edtEinsatzPlatzID.Location = new System.Drawing.Point(151, 72);
            this.edtEinsatzPlatzID.Name = "edtEinsatzPlatzID";
            this.edtEinsatzPlatzID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzPlatzID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzPlatzID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinsatzPlatzID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtEinsatzPlatzID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzPlatzID.Properties.NullText = "";
            this.edtEinsatzPlatzID.Properties.ShowFooter = false;
            this.edtEinsatzPlatzID.Properties.ShowHeader = false;
            this.edtEinsatzPlatzID.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatzPlatzID.TabIndex = 4;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(11, 102);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(130, 24);
            this.lblZusatz.TabIndex = 5;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // edtZusatzCode
            // 
            this.edtZusatzCode.Location = new System.Drawing.Point(151, 102);
            this.edtZusatzCode.LOVName = "KaAPVZusatz";
            this.edtZusatzCode.Name = "edtZusatzCode";
            this.edtZusatzCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzCode.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtZusatzCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzCode.Properties.NullText = "";
            this.edtZusatzCode.Properties.ShowFooter = false;
            this.edtZusatzCode.Properties.ShowHeader = false;
            this.edtZusatzCode.Size = new System.Drawing.Size(250, 24);
            this.edtZusatzCode.TabIndex = 6;
            // 
            // lblZustKAID
            // 
            this.lblZustKAID.Location = new System.Drawing.Point(11, 133);
            this.lblZustKAID.Name = "lblZustKAID";
            this.lblZustKAID.Size = new System.Drawing.Size(130, 24);
            this.lblZustKAID.TabIndex = 7;
            this.lblZustKAID.Text = "Zuständig KA";
            this.lblZustKAID.UseCompatibleTextRendering = true;
            // 
            // edtZustKaID
            // 
            this.edtZustKaID.Location = new System.Drawing.Point(151, 133);
            this.edtZustKaID.LookupSQL = "select ID = BaPersonID, Person = NameVorname\r\nfrom   vwPerson\r\nwhere NameVorname " +
                "like {0} + \'%\'\r\norder by Person";
            this.edtZustKaID.Name = "edtZustKaID";
            this.edtZustKaID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustKaID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustKaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustKaID.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustKaID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustKaID.Properties.Appearance.Options.UseFont = true;
            this.edtZustKaID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtZustKaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtZustKaID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustKaID.Size = new System.Drawing.Size(250, 24);
            this.edtZustKaID.TabIndex = 8;
            this.edtZustKaID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustKaID_UserModifiedFld);
            // 
            // lblDatumvon
            // 
            this.lblDatumvon.Location = new System.Drawing.Point(11, 163);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumvon.TabIndex = 9;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(151, 163);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 10;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(271, 163);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(24, 24);
            this.lblbis.TabIndex = 11;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(301, 163);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 12;
            // 
            // colAbbrALV
            // 
            this.colAbbrALV.Name = "colAbbrALV";
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colALK
            // 
            this.colALK.Name = "colALK";
            // 
            // colAnweisungtyp
            // 
            this.colAnweisungtyp.Name = "colAnweisungtyp";
            // 
            // colAustritt
            // 
            this.colAustritt.Name = "colAustritt";
            // 
            // colBeschftigungsgrad
            // 
            this.colBeschftigungsgrad.Name = "colBeschftigungsgrad";
            // 
            // colDatumbis
            // 
            this.colDatumbis.Name = "colDatumbis";
            // 
            // colEintrsichtbarSD
            // 
            this.colEintrsichtbarSD.Name = "colEintrsichtbarSD";
            // 
            // colErlernterBeruf
            // 
            this.colErlernterBeruf.Name = "colErlernterBeruf";
            // 
            // colFachbereich
            // 
            this.colFachbereich.Name = "colFachbereich";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colGesprch
            // 
            this.colGesprch.Name = "colGesprch";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colNichtersch
            // 
            this.colNichtersch.Name = "colNichtersch";
            // 
            // colNiveauSEMO
            // 
            this.colNiveauSEMO.Name = "colNiveauSEMO";
            // 
            // colPerssichtbarSD
            // 
            this.colPerssichtbarSD.Name = "colPerssichtbarSD";
            // 
            // colSARPB
            // 
            this.colSARPB.Name = "colSARPB";
            // 
            // colStatusWartelisteSEMO
            // 
            this.colStatusWartelisteSEMO.Name = "colStatusWartelisteSEMO";
            // 
            // colVorbildung
            // 
            this.colVorbildung.Name = "colVorbildung";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colWohnort
            // 
            this.colWohnort.Name = "colWohnort";
            // 
            // colZustndigKA
            // 
            this.colZustndigKA.Name = "colZustndigKA";
            // 
            // colZuweiser
            // 
            this.colZuweiser.Name = "colZuweiser";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKaFehlendeAngaben
            // 
            this.Name = "CtlQueryKaFehlendeAngaben";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblProfilnummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfilCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfilCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKAID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustKaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Private Methods

        private void edtZustKaID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtZustKaID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtZustKaID.EditValue = null;
                    edtZustKaID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtZustKaID.EditValue = dlg["Name"];
                edtZustKaID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}