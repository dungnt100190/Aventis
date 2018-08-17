using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.BSS
{
    public class CtlQueryVmBerichtsverlauf : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAusgangSC;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichterstellung;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtsperiodebis;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtsperiodevon;
        private DevExpress.XtraGrid.Columns.GridColumn colEingangRevisionen;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmigungerstinstanzlich;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmigungoberinstanzlich;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colMandantin;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstrger;
        private DevExpress.XtraGrid.Columns.GridColumn colRcklaufBelegeSC;
        private DevExpress.XtraGrid.Columns.GridColumn colRcklaufBerichtSC;
        private DevExpress.XtraGrid.Columns.GridColumn colVersand;
        private KiSS4.Gui.KissCheckEdit edtaktuell;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtFbTeamID;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtUserType;
        private KiSS4.Gui.KissLabel lblAbgabedatumbis;
        private KiSS4.Gui.KissLabel lblAbgabedatumvon;
        private KiSS4.Gui.KissLabel lblMandantin;
        private KiSS4.Gui.KissLabel lblMandatstraegerin;
        private KiSS4.Gui.KissLabel lblMandatstraegertyp;
        private KiSS4.Gui.KissLabel lblTeam;

        #endregion

        #region Constructors

        public CtlQueryVmBerichtsverlauf()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"select Code = FbTeamID, Text = Name from FbTeam order by Name");
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtFbTeamID.Properties.Columns.Clear();
            edtFbTeamID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtFbTeamID.Properties.ShowFooter = false;
            edtFbTeamID.Properties.ShowHeader = false;
            edtFbTeamID.Properties.DisplayMember = "Text";
            edtFbTeamID.Properties.ValueMember = "Code";
            edtFbTeamID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtFbTeamID.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"SELECT Code=1, Text = 'amtlich' UNION SELECT Code = 2, Text = 'PriMa'");
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtUserType.Properties.Columns.Clear();
            edtUserType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtUserType.Properties.ShowFooter = false;
            edtUserType.Properties.ShowHeader = false;
            edtUserType.Properties.DisplayMember = "Text";
            edtUserType.Properties.ValueMember = "Code";
            edtUserType.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtUserType.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmBerichtsverlauf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMandatstraegerin = new KiSS4.Gui.KissLabel();
            this.lblMandantin = new KiSS4.Gui.KissLabel();
            this.lblAbgabedatumvon = new KiSS4.Gui.KissLabel();
            this.lblAbgabedatumbis = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegertyp = new KiSS4.Gui.KissLabel();
            this.lblTeam = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtFbTeamID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserType = new KiSS4.Gui.KissLookUpEdit();
            this.edtaktuell = new KiSS4.Gui.KissCheckEdit();
            this.colAusgangSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichterstellung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtsperiodebis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtsperiodevon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingangRevisionen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmigungerstinstanzlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmigungoberinstanzlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandantin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcklaufBelegeSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRcklaufBerichtSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersand = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgabedatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgabedatumbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtaktuell.Properties)).BeginInit();
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.tpgSuchen.Controls.Add(this.edtaktuell);
            this.tpgSuchen.Controls.Add(this.edtUserType);
            this.tpgSuchen.Controls.Add(this.edtFbTeamID);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblTeam);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegertyp);
            this.tpgSuchen.Controls.Add(this.lblAbgabedatumbis);
            this.tpgSuchen.Controls.Add(this.lblAbgabedatumvon);
            this.tpgSuchen.Controls.Add(this.lblMandantin);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerin);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandantin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbgabedatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbgabedatumbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegertyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFbTeamID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserType, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtaktuell, 0);
            //
            // lblMandatstraegerin
            //
            this.lblMandatstraegerin.Location = new System.Drawing.Point(10, 40);
            this.lblMandatstraegerin.Name = "lblMandatstraegerin";
            this.lblMandatstraegerin.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerin.TabIndex = 1;
            this.lblMandatstraegerin.Text = "Mandatstraeger/-in";
            this.lblMandatstraegerin.UseCompatibleTextRendering = true;
            //
            // lblMandantin
            //
            this.lblMandantin.Location = new System.Drawing.Point(10, 70);
            this.lblMandantin.Name = "lblMandantin";
            this.lblMandantin.Size = new System.Drawing.Size(130, 24);
            this.lblMandantin.TabIndex = 2;
            this.lblMandantin.Text = "Mandant/-in";
            this.lblMandantin.UseCompatibleTextRendering = true;
            //
            // lblAbgabedatumvon
            //
            this.lblAbgabedatumvon.Location = new System.Drawing.Point(10, 100);
            this.lblAbgabedatumvon.Name = "lblAbgabedatumvon";
            this.lblAbgabedatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblAbgabedatumvon.TabIndex = 3;
            this.lblAbgabedatumvon.Text = "Abgabedatum von";
            this.lblAbgabedatumvon.UseCompatibleTextRendering = true;
            //
            // lblAbgabedatumbis
            //
            this.lblAbgabedatumbis.Location = new System.Drawing.Point(10, 130);
            this.lblAbgabedatumbis.Name = "lblAbgabedatumbis";
            this.lblAbgabedatumbis.Size = new System.Drawing.Size(130, 24);
            this.lblAbgabedatumbis.TabIndex = 4;
            this.lblAbgabedatumbis.Text = "Abgabedatum bis";
            this.lblAbgabedatumbis.UseCompatibleTextRendering = true;
            //
            // lblMandatstraegertyp
            //
            this.lblMandatstraegertyp.Location = new System.Drawing.Point(10, 160);
            this.lblMandatstraegertyp.Name = "lblMandatstraegertyp";
            this.lblMandatstraegertyp.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegertyp.TabIndex = 5;
            this.lblMandatstraegertyp.Text = "Mandatstraegertyp";
            this.lblMandatstraegertyp.UseCompatibleTextRendering = true;
            //
            // lblTeam
            //
            this.lblTeam.Location = new System.Drawing.Point(10, 190);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(130, 24);
            this.lblTeam.TabIndex = 5;
            this.lblTeam.Text = "Team";
            this.lblTeam.UseCompatibleTextRendering = true;
            //
            // edtUserID
            //
            this.edtUserID.EditValue = "";
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(200, 24);
            this.edtUserID.TabIndex = 20;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.EditValue = "";
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 70);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonID.Size = new System.Drawing.Size(200, 24);
            this.edtBaPersonID.TabIndex = 21;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // edtDatumVon
            //
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 100);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 22;
            //
            // edtDatumBis
            //
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(150, 130);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 23;
            //
            // edtFbTeamID
            //
            this.edtFbTeamID.Location = new System.Drawing.Point(150, 190);
            this.edtFbTeamID.Name = "edtFbTeamID";
            this.edtFbTeamID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFbTeamID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFbTeamID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFbTeamID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFbTeamID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFbTeamID.Properties.Appearance.Options.UseFont = true;
            this.edtFbTeamID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFbTeamID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFbTeamID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFbTeamID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFbTeamID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFbTeamID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFbTeamID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFbTeamID.Properties.NullText = "";
            this.edtFbTeamID.Properties.ShowFooter = false;
            this.edtFbTeamID.Properties.ShowHeader = false;
            this.edtFbTeamID.Size = new System.Drawing.Size(200, 24);
            this.edtFbTeamID.TabIndex = 24;
            //
            // edtUserType
            //
            this.edtUserType.Location = new System.Drawing.Point(150, 160);
            this.edtUserType.Name = "edtUserType";
            this.edtUserType.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserType.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserType.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserType.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserType.Properties.Appearance.Options.UseFont = true;
            this.edtUserType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserType.Properties.NullText = "";
            this.edtUserType.Properties.ShowFooter = false;
            this.edtUserType.Properties.ShowHeader = false;
            this.edtUserType.Size = new System.Drawing.Size(200, 24);
            this.edtUserType.TabIndex = 24;
            //
            // edtaktuell
            //
            this.edtaktuell.EditValue = false;
            this.edtaktuell.Location = new System.Drawing.Point(150, 220);
            this.edtaktuell.Name = "edtaktuell";
            this.edtaktuell.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtaktuell.Properties.Appearance.Options.UseBackColor = true;
            this.edtaktuell.Properties.Caption = "Aktuelle Berichtsperiode";
            this.edtaktuell.Size = new System.Drawing.Size(250, 19);
            this.edtaktuell.TabIndex = 25;
            //
            // colAusgangSC
            //
            this.colAusgangSC.Name = "colAusgangSC";
            //
            // colBerichterstellung
            //
            this.colBerichterstellung.Name = "colBerichterstellung";
            //
            // colBerichtsperiodebis
            //
            this.colBerichtsperiodebis.Name = "colBerichtsperiodebis";
            //
            // colBerichtsperiodevon
            //
            this.colBerichtsperiodevon.Name = "colBerichtsperiodevon";
            //
            // colEingangRevisionen
            //
            this.colEingangRevisionen.Name = "colEingangRevisionen";
            //
            // colGenehmigungerstinstanzlich
            //
            this.colGenehmigungerstinstanzlich.Name = "colGenehmigungerstinstanzlich";
            //
            // colGenehmigungoberinstanzlich
            //
            this.colGenehmigungoberinstanzlich.Name = "colGenehmigungoberinstanzlich";
            //
            // colMahnung
            //
            this.colMahnung.Name = "colMahnung";
            //
            // colMandantin
            //
            this.colMandantin.Name = "colMandantin";
            //
            // colMandatstrger
            //
            this.colMandatstrger.Name = "colMandatstrger";
            //
            // colRcklaufBelegeSC
            //
            this.colRcklaufBelegeSC.Name = "colRcklaufBelegeSC";
            //
            // colRcklaufBerichtSC
            //
            this.colRcklaufBerichtSC.Name = "colRcklaufBerichtSC";
            //
            // colVersand
            //
            this.colVersand.Name = "colVersand";
            //
            // CtlQueryVmBerichtsverlauf
            //
            this.Name = "CtlQueryVmBerichtsverlauf";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgabedatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgabedatumbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFbTeamID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtaktuell.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select distinct ID = PRS.BaPersonID,
                    MandantIn = PRS.NameVorname
                from   vwPerson PRS
                    inner join FaLeistung FAL on FAL.BaPersonID = PRS.BaPersonID
                                        and FAL.ModulID = 5
                where PRS.NameVorname like {0} + '%'
                order by PRS.NameVorname",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select ID = UserID,
                    Mandatstraeger = LastName + isNull(', ' + FirstName,''),
                    [Kuerzel] = LogonName
                from   XUser
                where LastName + isNull(', ' + FirstName,'') like {0} + '%'
                order by Mandatstraeger",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg[1];
                edtUserID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}