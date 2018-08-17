using System;
using System.ComponentModel;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryAdmBenutzergruppenRechte : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBenutzer;
        private DevExpress.XtraGrid.Columns.GridColumn colZugeteilteGruppe;
        private KiSS4.Gui.KissLookUpEdit edtRightID;
        private KiSS4.Gui.KissLookUpEdit edtUserGroupID;
        private KiSS4.Common.KissMitarbeiterButtonEdit edtUserID;
        private KiSS4.Gui.KissLabel lblBenutzer;
        private KiSS4.Gui.KissLabel lblBenutzergruppe;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private SharpLibrary.WinControls.TabPageEx tpgListe3;
        private KissGrid grdListe2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2;
        private IContainer components;
        private KissGrid grdListe3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe3;
        private KiSS4.Gui.KissLabel lblRecht;

        #endregion

        #region Constructors

        public CtlQueryAdmBenutzergruppenRechte()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"SELECT *
                                  FROM(SELECT Code = convert(varchar, RightID),
                                              Text = UserText
                                       FROM XRight
                                       UNION ALL
                                       SELECT Code = Maskname,
                                              Text = 'EM ' +
                                                      CASE MSK.ModulID
                                                           WHEN 2 THEN
                                                                    CASE MSK.FaPhaseCode
                                                                         WHEN 1 THEN 'FF-INT-'
                                                                         WHEN 2 THEN 'FF-BER-'
                                                                         ELSE 'FF-DOK-'
                                                                    END
                                                            WHEN 5 THEN
                                                                     CASE MSK.VmProzessCode
                                                                          WHEN 1 THEN 'VM-MAS-'
                                                                          WHEN 2 THEN 'VM-VAT-'
                                                                          WHEN 3 THEN 'VM-EA-'
                                                                          WHEN 31 THEN 'VM-EA-SIE-'
                                                                          WHEN 32 THEN 'VM-EA-TES-'
                                                                          WHEN 33 THEN 'VM-EA-ERB-'
                                                                          WHEN 4 THEN 'VM-PFL-'
                                                                     ELSE 'VM-'
                                                            END
                                                      ELSE ''
                                               END +MSK.DisplayText
                                    FROM DynaMask MSK) TMP
                                    ORDER BY 2");
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtRightID.Properties.Columns.Clear();
            edtRightID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtRightID.Properties.ShowFooter = false;
            edtRightID.Properties.ShowHeader = false;
            edtRightID.Properties.DisplayMember = "Text";
            edtRightID.Properties.ValueMember = "Code";
            edtRightID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtRightID.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"SELECT Code = UserGroupID,
                                        Text = UserGroupName
                                FROM XUserGroup
                                ORDER BY UserGroupName");
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtUserGroupID.Properties.Columns.Clear();
            edtUserGroupID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtUserGroupID.Properties.ShowFooter = false;
            edtUserGroupID.Properties.ShowHeader = false;
            edtUserGroupID.Properties.DisplayMember = "Text";
            edtUserGroupID.Properties.ValueMember = "Code";
            edtUserGroupID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtUserGroupID.Properties.DataSource = qry;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmBenutzergruppenRechte));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBenutzer = new KiSS4.Gui.KissLabel();
            this.lblBenutzergruppe = new KiSS4.Gui.KissLabel();
            this.lblRecht = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.edtRightID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserGroupID = new KiSS4.Gui.KissLookUpEdit();
            this.colBenutzer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugeteilteGruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe2 = new KiSS4.Gui.KissGrid();
            this.grvListe2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgListe3 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe3 = new KiSS4.Gui.KissGrid();
            this.grvListe3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzergruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupID.Properties)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).BeginInit();
            this.tpgListe3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3)).BeginInit();
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
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.Controls.Add(this.tpgListe3);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2,
            this.tpgListe3});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe3, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtUserGroupID);
            this.tpgSuchen.Controls.Add(this.edtRightID);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblRecht);
            this.tpgSuchen.Controls.Add(this.lblBenutzergruppe);
            this.tpgSuchen.Controls.Add(this.lblBenutzer);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBenutzer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBenutzergruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblRecht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtRightID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserGroupID, 0);
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.Location = new System.Drawing.Point(10, 40);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(130, 24);
            this.lblBenutzer.TabIndex = 1;
            this.lblBenutzer.Text = "Benutzer";
            this.lblBenutzer.UseCompatibleTextRendering = true;
            // 
            // lblBenutzergruppe
            // 
            this.lblBenutzergruppe.Location = new System.Drawing.Point(10, 70);
            this.lblBenutzergruppe.Name = "lblBenutzergruppe";
            this.lblBenutzergruppe.Size = new System.Drawing.Size(130, 24);
            this.lblBenutzergruppe.TabIndex = 1;
            this.lblBenutzergruppe.Text = "Benutzergruppe";
            this.lblBenutzergruppe.UseCompatibleTextRendering = true;
            // 
            // lblRecht
            // 
            this.lblRecht.Location = new System.Drawing.Point(10, 100);
            this.lblRecht.Name = "lblRecht";
            this.lblRecht.Size = new System.Drawing.Size(130, 24);
            this.lblRecht.TabIndex = 1;
            this.lblRecht.Text = "Recht";
            this.lblRecht.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.IsSearchField = true;
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(220, 24);
            this.edtUserID.TabIndex = 20;
            // 
            // edtRightID
            // 
            this.edtRightID.Location = new System.Drawing.Point(150, 100);
            this.edtRightID.Name = "edtRightID";
            this.edtRightID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRightID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRightID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRightID.Properties.Appearance.Options.UseBackColor = true;
            this.edtRightID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRightID.Properties.Appearance.Options.UseFont = true;
            this.edtRightID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtRightID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtRightID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtRightID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtRightID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRightID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRightID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRightID.Properties.NullText = "";
            this.edtRightID.Properties.ShowFooter = false;
            this.edtRightID.Properties.ShowHeader = false;
            this.edtRightID.Size = new System.Drawing.Size(220, 24);
            this.edtRightID.TabIndex = 22;
            // 
            // edtUserGroupID
            // 
            this.edtUserGroupID.Location = new System.Drawing.Point(150, 70);
            this.edtUserGroupID.Name = "edtUserGroupID";
            this.edtUserGroupID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserGroupID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserGroupID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserGroupID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtUserGroupID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserGroupID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserGroupID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserGroupID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserGroupID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserGroupID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserGroupID.Properties.NullText = "";
            this.edtUserGroupID.Properties.ShowFooter = false;
            this.edtUserGroupID.Properties.ShowHeader = false;
            this.edtUserGroupID.Size = new System.Drawing.Size(220, 24);
            this.edtUserGroupID.TabIndex = 22;
            // 
            // colBenutzer
            // 
            this.colBenutzer.Name = "colBenutzer";
            // 
            // colZugeteilteGruppe
            // 
            this.colZugeteilteGruppe.Name = "colZugeteilteGruppe";
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.grdListe2);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Liste 2";
            // 
            // grdListe2
            // 
            this.grdListe2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdListe2.EmbeddedNavigator.Name = "";
            this.grdListe2.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2.Location = new System.Drawing.Point(3, 16);
            this.grdListe2.MainView = this.grvListe2;
            this.grdListe2.Name = "grdListe2";
            this.grdListe2.Size = new System.Drawing.Size(766, 392);
            this.grdListe2.TabIndex = 10;
            this.grdListe2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe2});
            // 
            // grvListe2
            // 
            this.grvListe2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2.Appearance.Empty.Options.UseFont = true;
            this.grvListe2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2.Appearance.Row.Options.UseFont = true;
            this.grvListe2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2.GridControl = this.grdListe2;
            this.grvListe2.Name = "grvListe2";
            this.grvListe2.OptionsBehavior.Editable = false;
            this.grvListe2.OptionsCustomization.AllowFilter = false;
            this.grvListe2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2.OptionsNavigation.UseTabKey = false;
            this.grvListe2.OptionsView.ColumnAutoWidth = false;
            this.grvListe2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2.OptionsView.ShowGroupPanel = false;
            this.grvListe2.OptionsView.ShowIndicator = false;
            // 
            // tpgListe3
            // 
            this.tpgListe3.Controls.Add(this.grdListe3);
            this.tpgListe3.Location = new System.Drawing.Point(6, 6);
            this.tpgListe3.Name = "tpgListe3";
            this.tpgListe3.Size = new System.Drawing.Size(772, 424);
            this.tpgListe3.TabIndex = 2;
            this.tpgListe3.Title = "Liste 3";
            // 
            // grdListe3
            // 
            this.grdListe3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe3.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdListe3.EmbeddedNavigator.Name = "";
            this.grdListe3.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe3.Location = new System.Drawing.Point(3, 16);
            this.grdListe3.MainView = this.grvListe3;
            this.grdListe3.Name = "grdListe3";
            this.grdListe3.Size = new System.Drawing.Size(766, 392);
            this.grdListe3.TabIndex = 10;
            this.grdListe3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe3});
            // 
            // grvListe3
            // 
            this.grvListe3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe3.Appearance.Empty.Options.UseFont = true;
            this.grvListe3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe3.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe3.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe3.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.OddRow.Options.UseFont = true;
            this.grvListe3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.Row.Options.UseBackColor = true;
            this.grvListe3.Appearance.Row.Options.UseFont = true;
            this.grvListe3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe3.GridControl = this.grdListe3;
            this.grvListe3.Name = "grvListe3";
            this.grvListe3.OptionsBehavior.Editable = false;
            this.grvListe3.OptionsCustomization.AllowFilter = false;
            this.grvListe3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe3.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe3.OptionsNavigation.UseTabKey = false;
            this.grvListe3.OptionsView.ColumnAutoWidth = false;
            this.grvListe3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe3.OptionsView.ShowGroupPanel = false;
            this.grvListe3.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryAdmBenutzergruppenRechte
            // 
            this.Name = "CtlQueryAdmBenutzergruppenRechte";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzergruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRightID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserGroupID)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2)).EndInit();
            this.tpgListe3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            this.grdListe2.DataSource = qryQuery.DataSet.Tables[1];
            this.grdListe3.DataSource = qryQuery.DataSet.Tables[2];
        }
    }
}