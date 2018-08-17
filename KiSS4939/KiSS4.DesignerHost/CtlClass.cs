using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlClass.
    /// </summary>
    public class CtlClass : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string nsProject = "http://schemas.microsoft.com/developer/msbuild/2003";

        #endregion

        #region Private Fields

        private KissButton btnCheckIn;
        private KissButton btnCheckOut;
        private KiSS4.Gui.KissButton btnCopy;
        private KiSS4.Gui.KissButton btnExport;
        private KissButton btnExportAll;
        private KissButton btnExportCS;
        private KissButton btnExportVSProject;
        private KissButton btnImportCSFix;
        private KissButton btnImportCSRule;
        private KissButton btnImportDLL;
        private KissButton btnRemoveFix;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseType;
        private DevExpress.XtraGrid.Columns.GridColumn colBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colBuildNr;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckOut;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDesigner;
        private DevExpress.XtraGrid.Columns.GridColumn colMaskName;
        private DevExpress.XtraGrid.Columns.GridColumn colModulID;
        private DevExpress.XtraGrid.Columns.GridColumn colNamespaceExtension;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissComboBox edtBaseType;
        private KissTextEdit edtCheckOut_Date;
        private KissTextEdit edtCheckOut_User;
        private KiSS4.Gui.KissTextEdit edtClassName;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private KiSS4.Gui.KissTextEdit edtMaskName;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KissTextEdit edtNamespaceExtension;
        private KiSS4.Gui.KissComboBox edtSearchBaseType;
        private KiSS4.Gui.KissTextEdit edtSearchClassName;
        private KissTextEdit edtSearchDescription;
        private KissLookUpEdit edtSearchDesigner;
        private KiSS4.Gui.KissLookUpEdit edtSearchModulID;
        private KissTextEdit edtSearchNamespaceExtension;
        private KissLookUpEdit edtWebVersion;
        private KiSS4.Gui.KissGrid grdXClass;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXClass;
        private KiSS4.Gui.KissLabel lblBaseType;
        private KissLabel lblCheckOut;
        private KiSS4.Gui.KissLabel lblClassName;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblMaskName;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblSearchBaseType;
        private KiSS4.Gui.KissLabel lblSearchClassName;
        private KissLabel lblSearchDescription;
        private KissLabel lblSearchDesigner;
        private KiSS4.Gui.KissLabel lblSearchModulID;
        private KissLabel lblSearchNamespaceExtension;
        private object ModulID = DBNull.Value;
        private string oldClassName = string.Empty;
        private System.Windows.Forms.Panel panControls;
        private KiSS4.DB.SqlQuery qryXClass;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlClass()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            this.colModulID.ColumnEdit = this.grdXClass.GetLOVLookUpEdit("Modul");

            // New KissUserControl
            foreach (DataRow row in DBUtil.OpenSQL(@"
                        SELECT Value1
                        FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                        WHERE LOVName = 'Class' AND
                              Code >= 1000
                        ORDER BY SortKey").DataTable.Rows)
            {
                this.edtBaseType.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(row["Value1"] as string));
            }

            this.edtSearchBaseType.Properties.Items.AddRange(this.edtBaseType.Properties.Items);

            if (DBUtil.ExecuteScalarSQL("SELECT TOP 1 Designer FROM dbo.XClass WITH (READUNCOMMITTED)") is Boolean)
            {
                this.btnImportCSFix.Visible = false;
                this.btnRemoveFix.Visible = false;
            }
            else
            {
                this.colDesigner.ColumnEdit = this.grdXClass.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                        SELECT Code = CONVERT(INT, 0),
                               Text = '--'
                        UNION ALL
                        SELECT Code = CONVERT(INT, 1),
                               Text = 'Design'
                        UNION ALL
                        SELECT Code = CONVERT(INT, 2),
                               Text = 'Fix'"));
            }

            edtWebVersion.Visible = false;
        }

        public CtlClass(int modulID)
            : this()
        {
            this.ModulID = modulID;

            this.edtModulID.LOVFilter = string.Format("(ModulID > 0 OR ModulID = {0})", ModulID);
            this.edtModulID.LOVName = this.edtModulID.LOVName;

            if (qryXClass.Count > 0)
            {
                this.NewSearch();
                ((IKissDataNavigator)this).Search();
            }
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlClass));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtBaseType = new KiSS4.Gui.KissComboBox();
            this.qryXClass = new KiSS4.DB.SqlQuery(this.components);
            this.edtClassName = new KiSS4.Gui.KissTextEdit();
            this.lblClassName = new KiSS4.Gui.KissLabel();
            this.lblBaseType = new KiSS4.Gui.KissLabel();
            this.lblSearchClassName = new KiSS4.Gui.KissLabel();
            this.lblSearchBaseType = new KiSS4.Gui.KissLabel();
            this.edtSearchBaseType = new KiSS4.Gui.KissComboBox();
            this.edtSearchClassName = new KiSS4.Gui.KissTextEdit();
            this.grdXClass = new KiSS4.Gui.KissGrid();
            this.grvXClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNamespaceExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuildNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesigner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCheckOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panControls = new System.Windows.Forms.Panel();
            this.edtNamespaceExtension = new KiSS4.Gui.KissTextEdit();
            this.btnRemoveFix = new KiSS4.Gui.KissButton();
            this.btnImportCSFix = new KiSS4.Gui.KissButton();
            this.edtWebVersion = new KiSS4.Gui.KissLookUpEdit();
            this.btnExportVSProject = new KiSS4.Gui.KissButton();
            this.btnCheckIn = new KiSS4.Gui.KissButton();
            this.btnCheckOut = new KiSS4.Gui.KissButton();
            this.lblCheckOut = new KiSS4.Gui.KissLabel();
            this.edtCheckOut_User = new KiSS4.Gui.KissTextEdit();
            this.edtCheckOut_Date = new KiSS4.Gui.KissTextEdit();
            this.btnImportCSRule = new KiSS4.Gui.KissButton();
            this.btnImportDLL = new KiSS4.Gui.KissButton();
            this.btnExportCS = new KiSS4.Gui.KissButton();
            this.btnExportAll = new KiSS4.Gui.KissButton();
            this.btnCopy = new KiSS4.Gui.KissButton();
            this.btnExport = new KiSS4.Gui.KissButton();
            this.edtMaskName = new KiSS4.Gui.KissTextEdit();
            this.lblMaskName = new KiSS4.Gui.KissLabel();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.edtSearchModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblSearchModulID = new KiSS4.Gui.KissLabel();
            this.edtSearchDescription = new KiSS4.Gui.KissTextEdit();
            this.lblSearchDescription = new KiSS4.Gui.KissLabel();
            this.lblSearchNamespaceExtension = new KiSS4.Gui.KissLabel();
            this.edtSearchNamespaceExtension = new KiSS4.Gui.KissTextEdit();
            this.edtSearchDesigner = new KiSS4.Gui.KissLookUpEdit();
            this.lblSearchDesigner = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaseType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBaseType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBaseType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWebVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWebVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut_User.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchNamespaceExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchNamespaceExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDesigner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDesigner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDesigner)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(970, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(994, 335);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdXClass);
            this.tpgListe.Size = new System.Drawing.Size(982, 297);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSearchDesigner);
            this.tpgSuchen.Controls.Add(this.edtSearchModulID);
            this.tpgSuchen.Controls.Add(this.lblSearchModulID);
            this.tpgSuchen.Controls.Add(this.lblSearchDesigner);
            this.tpgSuchen.Controls.Add(this.lblSearchDescription);
            this.tpgSuchen.Controls.Add(this.lblSearchClassName);
            this.tpgSuchen.Controls.Add(this.lblSearchNamespaceExtension);
            this.tpgSuchen.Controls.Add(this.lblSearchBaseType);
            this.tpgSuchen.Controls.Add(this.edtSearchBaseType);
            this.tpgSuchen.Controls.Add(this.edtSearchDescription);
            this.tpgSuchen.Controls.Add(this.edtSearchNamespaceExtension);
            this.tpgSuchen.Controls.Add(this.edtSearchClassName);
            this.tpgSuchen.Size = new System.Drawing.Size(982, 297);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchClassName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchNamespaceExtension, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchBaseType, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchBaseType, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchNamespaceExtension, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchClassName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDescription, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchDesigner, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchModulID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchDesigner, 0);
            //
            // edtBaseType
            //
            this.edtBaseType.DataMember = "BaseType";
            this.edtBaseType.DataSource = this.qryXClass;
            this.edtBaseType.Location = new System.Drawing.Point(112, 98);
            this.edtBaseType.Name = "edtBaseType";
            this.edtBaseType.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaseType.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaseType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaseType.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaseType.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaseType.Properties.Appearance.Options.UseFont = true;
            this.edtBaseType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaseType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaseType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaseType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaseType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaseType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaseType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaseType.Size = new System.Drawing.Size(356, 24);
            this.edtBaseType.TabIndex = 7;
            //
            // qryXClass
            //
            this.qryXClass.CanDelete = true;
            this.qryXClass.CanInsert = true;
            this.qryXClass.CanUpdate = true;
            this.qryXClass.HostControl = this;
            this.qryXClass.SelectStatement = resources.GetString("qryXClass.SelectStatement");
            this.qryXClass.TableName = "XClass";
            this.qryXClass.BeforePost += new System.EventHandler(this.qryXClass_BeforePost);
            this.qryXClass.PositionChanged += new System.EventHandler(this.qryXClass_PositionChanged);
            this.qryXClass.AfterInsert += new System.EventHandler(this.qryXClass_AfterInsert);
            this.qryXClass.BeforeDeleteQuestion += new System.EventHandler(this.qryXClass_BeforeDeleteQuestion);
            this.qryXClass.AfterPost += new System.EventHandler(this.qryXClass_AfterPost);
            this.qryXClass.AfterDelete += new System.EventHandler(this.qryXClass_AfterDelete);
            //
            // edtClassName
            //
            this.edtClassName.DataMember = "ClassName";
            this.edtClassName.DataSource = this.qryXClass;
            this.edtClassName.Location = new System.Drawing.Point(206, 38);
            this.edtClassName.Name = "edtClassName";
            this.edtClassName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClassName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClassName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClassName.Properties.Appearance.Options.UseBackColor = true;
            this.edtClassName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClassName.Properties.Appearance.Options.UseFont = true;
            this.edtClassName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClassName.Size = new System.Drawing.Size(260, 24);
            this.edtClassName.TabIndex = 3;
            //
            // lblClassName
            //
            this.lblClassName.Location = new System.Drawing.Point(8, 39);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(100, 23);
            this.lblClassName.TabIndex = 2;
            this.lblClassName.Text = "Ns-Ext. / Klasse";
            //
            // lblBaseType
            //
            this.lblBaseType.Location = new System.Drawing.Point(8, 99);
            this.lblBaseType.Name = "lblBaseType";
            this.lblBaseType.Size = new System.Drawing.Size(100, 23);
            this.lblBaseType.TabIndex = 6;
            this.lblBaseType.Text = "Basis";
            //
            // lblSearchClassName
            //
            this.lblSearchClassName.Location = new System.Drawing.Point(31, 130);
            this.lblSearchClassName.Name = "lblSearchClassName";
            this.lblSearchClassName.Size = new System.Drawing.Size(100, 23);
            this.lblSearchClassName.TabIndex = 4;
            this.lblSearchClassName.Text = "Klasse";
            //
            // lblSearchBaseType
            //
            this.lblSearchBaseType.Location = new System.Drawing.Point(31, 70);
            this.lblSearchBaseType.Name = "lblSearchBaseType";
            this.lblSearchBaseType.Size = new System.Drawing.Size(100, 23);
            this.lblSearchBaseType.TabIndex = 2;
            this.lblSearchBaseType.Text = "Basis";
            //
            // edtSearchBaseType
            //
            this.edtSearchBaseType.Location = new System.Drawing.Point(137, 70);
            this.edtSearchBaseType.Name = "edtSearchBaseType";
            this.edtSearchBaseType.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBaseType.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBaseType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBaseType.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBaseType.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBaseType.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBaseType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchBaseType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBaseType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchBaseType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchBaseType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSearchBaseType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSearchBaseType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchBaseType.Size = new System.Drawing.Size(356, 24);
            this.edtSearchBaseType.TabIndex = 3;
            //
            // edtSearchClassName
            //
            this.edtSearchClassName.Location = new System.Drawing.Point(137, 130);
            this.edtSearchClassName.Name = "edtSearchClassName";
            this.edtSearchClassName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchClassName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchClassName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchClassName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchClassName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchClassName.Properties.Appearance.Options.UseFont = true;
            this.edtSearchClassName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchClassName.Size = new System.Drawing.Size(356, 24);
            this.edtSearchClassName.TabIndex = 5;
            //
            // grdXClass
            //
            this.grdXClass.DataSource = this.qryXClass;
            this.grdXClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXClass.EmbeddedNavigator.Name = "";
            this.grdXClass.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXClass.Location = new System.Drawing.Point(0, 0);
            this.grdXClass.MainView = this.grvXClass;
            this.grdXClass.Name = "grdXClass";
            this.grdXClass.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdXClass.Size = new System.Drawing.Size(982, 297);
            this.grdXClass.TabIndex = 1;
            this.grdXClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXClass});
            this.grdXClass.DoubleClick += new System.EventHandler(this.grdXClass_DoubleClick);
            //
            // grvXClass
            //
            this.grvXClass.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXClass.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.Empty.Options.UseBackColor = true;
            this.grvXClass.Appearance.Empty.Options.UseFont = true;
            this.grvXClass.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.EvenRow.Options.UseFont = true;
            this.grvXClass.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXClass.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXClass.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXClass.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXClass.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXClass.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXClass.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXClass.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXClass.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXClass.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXClass.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXClass.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXClass.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXClass.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXClass.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXClass.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXClass.Appearance.GroupRow.Options.UseFont = true;
            this.grvXClass.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXClass.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXClass.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXClass.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXClass.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXClass.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXClass.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXClass.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXClass.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXClass.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXClass.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXClass.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXClass.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXClass.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXClass.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.OddRow.Options.UseFont = true;
            this.grvXClass.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXClass.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.Row.Options.UseBackColor = true;
            this.grvXClass.Appearance.Row.Options.UseFont = true;
            this.grvXClass.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXClass.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXClass.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXClass.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXClass.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNamespaceExtension,
            this.colClassName,
            this.colBranch,
            this.colBuildNr,
            this.colMaskName,
            this.colDesigner,
            this.colCheckOut,
            this.colSystem,
            this.colBaseType,
            this.colModulID,
            this.colDescription});
            this.grvXClass.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXClass.GridControl = this.grdXClass;
            this.grvXClass.Name = "grvXClass";
            this.grvXClass.OptionsBehavior.Editable = false;
            this.grvXClass.OptionsCustomization.AllowFilter = false;
            this.grvXClass.OptionsFilter.AllowFilterEditor = false;
            this.grvXClass.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXClass.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXClass.OptionsNavigation.UseTabKey = false;
            this.grvXClass.OptionsView.ColumnAutoWidth = false;
            this.grvXClass.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXClass.OptionsView.ShowGroupPanel = false;
            this.grvXClass.OptionsView.ShowIndicator = false;
            //
            // colNamespaceExtension
            //
            this.colNamespaceExtension.Caption = "Ns-Ext.";
            this.colNamespaceExtension.FieldName = "NamespaceExtension";
            this.colNamespaceExtension.Name = "colNamespaceExtension";
            this.colNamespaceExtension.Visible = true;
            this.colNamespaceExtension.VisibleIndex = 0;
            this.colNamespaceExtension.Width = 50;
            //
            // colClassName
            //
            this.colClassName.Caption = "Klasse";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 1;
            this.colClassName.Width = 250;
            //
            // colBranch
            //
            this.colBranch.Caption = "Branch";
            this.colBranch.FieldName = "Branch";
            this.colBranch.Name = "colBranch";
            this.colBranch.Visible = true;
            this.colBranch.VisibleIndex = 2;
            this.colBranch.Width = 200;
            //
            // colBuildNr
            //
            this.colBuildNr.Caption = "Build-Nr.";
            this.colBuildNr.FieldName = "BuildNr";
            this.colBuildNr.Name = "colBuildNr";
            this.colBuildNr.Visible = true;
            this.colBuildNr.VisibleIndex = 3;
            this.colBuildNr.Width = 70;
            //
            // colMaskName
            //
            this.colMaskName.Caption = "Rechte-Name";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            this.colMaskName.Visible = true;
            this.colMaskName.VisibleIndex = 4;
            this.colMaskName.Width = 240;
            //
            // colDesigner
            //
            this.colDesigner.Caption = "Designer";
            this.colDesigner.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDesigner.FieldName = "Designer";
            this.colDesigner.Name = "colDesigner";
            this.colDesigner.Visible = true;
            this.colDesigner.VisibleIndex = 5;
            this.colDesigner.Width = 65;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // colCheckOut
            //
            this.colCheckOut.Caption = "Check-Out";
            this.colCheckOut.FieldName = "CheckOut_LogonName";
            this.colCheckOut.Name = "colCheckOut";
            this.colCheckOut.Visible = true;
            this.colCheckOut.VisibleIndex = 6;
            this.colCheckOut.Width = 82;
            //
            // colSystem
            //
            this.colSystem.Caption = "System";
            this.colSystem.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 7;
            this.colSystem.Width = 54;
            //
            // colBaseType
            //
            this.colBaseType.Caption = "Basis";
            this.colBaseType.FieldName = "BaseType";
            this.colBaseType.Name = "colBaseType";
            this.colBaseType.Visible = true;
            this.colBaseType.VisibleIndex = 8;
            this.colBaseType.Width = 250;
            //
            // colModulID
            //
            this.colModulID.Caption = "Modul";
            this.colModulID.FieldName = "ModulID";
            this.colModulID.Name = "colModulID";
            this.colModulID.Visible = true;
            this.colModulID.VisibleIndex = 9;
            this.colModulID.Width = 200;
            //
            // colDescription
            //
            this.colDescription.Caption = "Beschreibung";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 10;
            this.colDescription.Width = 240;
            //
            // panControls
            //
            this.panControls.Controls.Add(this.edtNamespaceExtension);
            this.panControls.Controls.Add(this.btnRemoveFix);
            this.panControls.Controls.Add(this.btnImportCSFix);
            this.panControls.Controls.Add(this.edtWebVersion);
            this.panControls.Controls.Add(this.btnExportVSProject);
            this.panControls.Controls.Add(this.btnCheckIn);
            this.panControls.Controls.Add(this.btnCheckOut);
            this.panControls.Controls.Add(this.lblCheckOut);
            this.panControls.Controls.Add(this.edtCheckOut_User);
            this.panControls.Controls.Add(this.edtCheckOut_Date);
            this.panControls.Controls.Add(this.btnImportCSRule);
            this.panControls.Controls.Add(this.btnImportDLL);
            this.panControls.Controls.Add(this.btnExportCS);
            this.panControls.Controls.Add(this.btnExportAll);
            this.panControls.Controls.Add(this.btnCopy);
            this.panControls.Controls.Add(this.btnExport);
            this.panControls.Controls.Add(this.edtMaskName);
            this.panControls.Controls.Add(this.lblMaskName);
            this.panControls.Controls.Add(this.lblDescription);
            this.panControls.Controls.Add(this.edtDescription);
            this.panControls.Controls.Add(this.edtModulID);
            this.panControls.Controls.Add(this.lblModulID);
            this.panControls.Controls.Add(this.edtClassName);
            this.panControls.Controls.Add(this.edtBaseType);
            this.panControls.Controls.Add(this.lblClassName);
            this.panControls.Controls.Add(this.lblBaseType);
            this.panControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panControls.Location = new System.Drawing.Point(0, 336);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(1000, 264);
            this.panControls.TabIndex = 1;
            //
            // edtNamespaceExtension
            //
            this.edtNamespaceExtension.DataMember = "NamespaceExtension";
            this.edtNamespaceExtension.DataSource = this.qryXClass;
            this.edtNamespaceExtension.Location = new System.Drawing.Point(112, 38);
            this.edtNamespaceExtension.Name = "edtNamespaceExtension";
            this.edtNamespaceExtension.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNamespaceExtension.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNamespaceExtension.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNamespaceExtension.Properties.Appearance.Options.UseBackColor = true;
            this.edtNamespaceExtension.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNamespaceExtension.Properties.Appearance.Options.UseFont = true;
            this.edtNamespaceExtension.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNamespaceExtension.Size = new System.Drawing.Size(88, 24);
            this.edtNamespaceExtension.TabIndex = 29;
            //
            // btnRemoveFix
            //
            this.btnRemoveFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFix.Location = new System.Drawing.Point(857, 98);
            this.btnRemoveFix.Name = "btnRemoveFix";
            this.btnRemoveFix.Size = new System.Drawing.Size(110, 24);
            this.btnRemoveFix.TabIndex = 26;
            this.btnRemoveFix.Text = "Remove Fix";
            this.btnRemoveFix.UseVisualStyleBackColor = false;
            this.btnRemoveFix.Click += new System.EventHandler(this.btnRemoveFix_Click);
            //
            // btnImportCSFix
            //
            this.btnImportCSFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSFix.Location = new System.Drawing.Point(741, 98);
            this.btnImportCSFix.Name = "btnImportCSFix";
            this.btnImportCSFix.Size = new System.Drawing.Size(110, 24);
            this.btnImportCSFix.TabIndex = 25;
            this.btnImportCSFix.Text = "Import C# (Fix)";
            this.btnImportCSFix.UseVisualStyleBackColor = false;
            this.btnImportCSFix.Click += new System.EventHandler(this.btnImportCSFix_Click);
            //
            // edtWebVersion
            //
            this.edtWebVersion.Location = new System.Drawing.Point(741, 38);
            this.edtWebVersion.Name = "edtWebVersion";
            this.edtWebVersion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWebVersion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWebVersion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWebVersion.Properties.Appearance.Options.UseBackColor = true;
            this.edtWebVersion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWebVersion.Properties.Appearance.Options.UseFont = true;
            this.edtWebVersion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWebVersion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWebVersion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWebVersion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWebVersion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtWebVersion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtWebVersion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWebVersion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Branch", "", 90, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BuildNr")});
            this.edtWebVersion.Properties.DisplayMember = "Text";
            this.edtWebVersion.Properties.NullText = "";
            this.edtWebVersion.Properties.ShowFooter = false;
            this.edtWebVersion.Properties.ShowHeader = false;
            this.edtWebVersion.Properties.ValueMember = "RepositoryID";
            this.edtWebVersion.Size = new System.Drawing.Size(226, 24);
            this.edtWebVersion.TabIndex = 22;
            //
            // btnExportVSProject
            //
            this.btnExportVSProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportVSProject.Location = new System.Drawing.Point(486, 98);
            this.btnExportVSProject.Name = "btnExportVSProject";
            this.btnExportVSProject.Size = new System.Drawing.Size(110, 24);
            this.btnExportVSProject.TabIndex = 18;
            this.btnExportVSProject.Text = "Export CS-Proj";
            this.btnExportVSProject.UseVisualStyleBackColor = false;
            this.btnExportVSProject.Click += new System.EventHandler(this.btnExportCSProj_Click);
            //
            // btnCheckIn
            //
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Location = new System.Drawing.Point(602, 128);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(110, 24);
            this.btnCheckIn.TabIndex = 21;
            this.btnCheckIn.Text = "Check-In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            //
            // btnCheckOut
            //
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Location = new System.Drawing.Point(486, 128);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(110, 24);
            this.btnCheckOut.TabIndex = 20;
            this.btnCheckOut.Text = "Check-Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            //
            // lblCheckOut
            //
            this.lblCheckOut.Location = new System.Drawing.Point(8, 128);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(100, 23);
            this.lblCheckOut.TabIndex = 8;
            this.lblCheckOut.Text = "Check-Out";
            //
            // edtCheckOut_User
            //
            this.edtCheckOut_User.DataMember = "CheckOut_User";
            this.edtCheckOut_User.DataSource = this.qryXClass;
            this.edtCheckOut_User.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckOut_User.Location = new System.Drawing.Point(262, 128);
            this.edtCheckOut_User.Name = "edtCheckOut_User";
            this.edtCheckOut_User.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckOut_User.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckOut_User.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckOut_User.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckOut_User.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckOut_User.Properties.Appearance.Options.UseFont = true;
            this.edtCheckOut_User.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCheckOut_User.Properties.ReadOnly = true;
            this.edtCheckOut_User.Size = new System.Drawing.Size(206, 24);
            this.edtCheckOut_User.TabIndex = 10;
            //
            // edtCheckOut_Date
            //
            this.edtCheckOut_Date.DataMember = "CheckOut_Date";
            this.edtCheckOut_Date.DataSource = this.qryXClass;
            this.edtCheckOut_Date.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCheckOut_Date.Location = new System.Drawing.Point(112, 128);
            this.edtCheckOut_Date.Name = "edtCheckOut_Date";
            this.edtCheckOut_Date.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCheckOut_Date.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCheckOut_Date.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCheckOut_Date.Properties.Appearance.Options.UseBackColor = true;
            this.edtCheckOut_Date.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCheckOut_Date.Properties.Appearance.Options.UseFont = true;
            this.edtCheckOut_Date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCheckOut_Date.Properties.ReadOnly = true;
            this.edtCheckOut_Date.Size = new System.Drawing.Size(144, 24);
            this.edtCheckOut_Date.TabIndex = 9;
            //
            // btnImportCSRule
            //
            this.btnImportCSRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSRule.Location = new System.Drawing.Point(602, 68);
            this.btnImportCSRule.Name = "btnImportCSRule";
            this.btnImportCSRule.Size = new System.Drawing.Size(110, 24);
            this.btnImportCSRule.TabIndex = 17;
            this.btnImportCSRule.Text = "Import C# (Rule)";
            this.btnImportCSRule.UseVisualStyleBackColor = false;
            this.btnImportCSRule.Click += new System.EventHandler(this.btnImportCSRule_Click);
            //
            // btnImportDLL
            //
            this.btnImportDLL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportDLL.Location = new System.Drawing.Point(602, 98);
            this.btnImportDLL.Name = "btnImportDLL";
            this.btnImportDLL.Size = new System.Drawing.Size(110, 24);
            this.btnImportDLL.TabIndex = 19;
            this.btnImportDLL.Text = "Import DLL";
            this.btnImportDLL.UseVisualStyleBackColor = false;
            this.btnImportDLL.Click += new System.EventHandler(this.btnImportDLL_Click);
            //
            // btnExportCS
            //
            this.btnExportCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCS.Location = new System.Drawing.Point(486, 68);
            this.btnExportCS.Name = "btnExportCS";
            this.btnExportCS.Size = new System.Drawing.Size(110, 24);
            this.btnExportCS.TabIndex = 16;
            this.btnExportCS.Text = "Export CS-Datei";
            this.btnExportCS.UseVisualStyleBackColor = false;
            this.btnExportCS.Click += new System.EventHandler(this.btnExportCS_Click);
            //
            // btnExportAll
            //
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Location = new System.Drawing.Point(602, 38);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(110, 24);
            this.btnExportAll.TabIndex = 15;
            this.btnExportAll.Text = "alle exportieren";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            //
            // btnCopy
            //
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(486, 8);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(110, 24);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "kopieren";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            //
            // btnExport
            //
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(486, 38);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 24);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "exportieren";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // edtMaskName
            //
            this.edtMaskName.DataMember = "MaskName";
            this.edtMaskName.DataSource = this.qryXClass;
            this.edtMaskName.Location = new System.Drawing.Point(112, 68);
            this.edtMaskName.Name = "edtMaskName";
            this.edtMaskName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMaskName.Size = new System.Drawing.Size(356, 24);
            this.edtMaskName.TabIndex = 5;
            //
            // lblMaskName
            //
            this.lblMaskName.Location = new System.Drawing.Point(8, 69);
            this.lblMaskName.Name = "lblMaskName";
            this.lblMaskName.Size = new System.Drawing.Size(100, 23);
            this.lblMaskName.TabIndex = 4;
            this.lblMaskName.Text = "Rechte-Name";
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(8, 158);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Beschreibung";
            //
            // edtDescription
            //
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryXClass;
            this.edtDescription.Location = new System.Drawing.Point(112, 158);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(880, 98);
            this.edtDescription.TabIndex = 12;
            //
            // edtModulID
            //
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryXClass;
            this.edtModulID.Location = new System.Drawing.Point(112, 8);
            this.edtModulID.LOVFilter = "(ModulID > 0 OR ModulID IN (-1, -7))";
            this.edtModulID.LOVFilterWhereAppend = true;
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(356, 24);
            this.edtModulID.TabIndex = 1;
            //
            // lblModulID
            //
            this.lblModulID.Location = new System.Drawing.Point(8, 8);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(104, 24);
            this.lblModulID.TabIndex = 0;
            this.lblModulID.Text = "Modul";
            //
            // edtSearchModulID
            //
            this.edtSearchModulID.Location = new System.Drawing.Point(137, 40);
            this.edtSearchModulID.LOVName = "Modul";
            this.edtSearchModulID.Name = "edtSearchModulID";
            this.edtSearchModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchModulID.Properties.Appearance.Options.UseFont = true;
            this.edtSearchModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSearchModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSearchModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchModulID.Properties.NullText = "";
            this.edtSearchModulID.Properties.ShowFooter = false;
            this.edtSearchModulID.Properties.ShowHeader = false;
            this.edtSearchModulID.Size = new System.Drawing.Size(356, 24);
            this.edtSearchModulID.TabIndex = 1;
            //
            // lblSearchModulID
            //
            this.lblSearchModulID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchModulID.Location = new System.Drawing.Point(31, 40);
            this.lblSearchModulID.Name = "lblSearchModulID";
            this.lblSearchModulID.Size = new System.Drawing.Size(100, 24);
            this.lblSearchModulID.TabIndex = 0;
            this.lblSearchModulID.Text = "Modul";
            //
            // edtSearchDescription
            //
            this.edtSearchDescription.Location = new System.Drawing.Point(137, 160);
            this.edtSearchDescription.Name = "edtSearchDescription";
            this.edtSearchDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDescription.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchDescription.Size = new System.Drawing.Size(356, 24);
            this.edtSearchDescription.TabIndex = 7;
            //
            // lblSearchDescription
            //
            this.lblSearchDescription.Location = new System.Drawing.Point(31, 160);
            this.lblSearchDescription.Name = "lblSearchDescription";
            this.lblSearchDescription.Size = new System.Drawing.Size(100, 23);
            this.lblSearchDescription.TabIndex = 6;
            this.lblSearchDescription.Text = "Beschreibung";
            //
            // lblSearchNamespaceExtension
            //
            this.lblSearchNamespaceExtension.Location = new System.Drawing.Point(31, 103);
            this.lblSearchNamespaceExtension.Name = "lblSearchNamespaceExtension";
            this.lblSearchNamespaceExtension.Size = new System.Drawing.Size(100, 23);
            this.lblSearchNamespaceExtension.TabIndex = 2;
            this.lblSearchNamespaceExtension.Text = "Namespace Ext.";
            //
            // edtSearchNamespaceExtension
            //
            this.edtSearchNamespaceExtension.Location = new System.Drawing.Point(137, 100);
            this.edtSearchNamespaceExtension.Name = "edtSearchNamespaceExtension";
            this.edtSearchNamespaceExtension.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchNamespaceExtension.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchNamespaceExtension.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchNamespaceExtension.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchNamespaceExtension.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchNamespaceExtension.Properties.Appearance.Options.UseFont = true;
            this.edtSearchNamespaceExtension.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchNamespaceExtension.Size = new System.Drawing.Size(127, 24);
            this.edtSearchNamespaceExtension.TabIndex = 5;
            //
            // edtSearchDesigner
            //
            this.edtSearchDesigner.Location = new System.Drawing.Point(137, 190);
            this.edtSearchDesigner.LOVName = "Designer";
            this.edtSearchDesigner.Name = "edtSearchDesigner";
            this.edtSearchDesigner.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchDesigner.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchDesigner.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDesigner.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchDesigner.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchDesigner.Properties.Appearance.Options.UseFont = true;
            this.edtSearchDesigner.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSearchDesigner.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchDesigner.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSearchDesigner.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSearchDesigner.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSearchDesigner.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSearchDesigner.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchDesigner.Properties.NullText = "";
            this.edtSearchDesigner.Properties.ShowFooter = false;
            this.edtSearchDesigner.Properties.ShowHeader = false;
            this.edtSearchDesigner.Size = new System.Drawing.Size(127, 24);
            this.edtSearchDesigner.TabIndex = 11;
            //
            // lblSearchDesigner
            //
            this.lblSearchDesigner.Location = new System.Drawing.Point(31, 190);
            this.lblSearchDesigner.Name = "lblSearchDesigner";
            this.lblSearchDesigner.Size = new System.Drawing.Size(100, 23);
            this.lblSearchDesigner.TabIndex = 6;
            this.lblSearchDesigner.Text = "Designer";
            //
            // CtlClass
            //
            this.ActiveSQLQuery = this.qryXClass;
            this.Controls.Add(this.panControls);
            this.Name = "CtlClass";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.CtlClass_Load);
            this.Controls.SetChildIndex(this.panControls, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBaseType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBaseType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBaseType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNamespaceExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWebVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWebVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCheckOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut_User.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCheckOut_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchNamespaceExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchNamespaceExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDesigner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchDesigner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchDesigner)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            this.qryXClass["CheckOut"] = false;
            this.qryXClass["CheckOut_UserID"] = null;
            this.qryXClass["CheckOut_LogonName"] = null;
            this.qryXClass["CheckOut_User"] = null;
            this.qryXClass["CheckOut_Date"] = null;
            this.qryXClass.Post();

            qryXClass_PositionChanged(this.qryXClass, EventArgs.Empty);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            this.qryXClass["CheckOut"] = true;
            this.qryXClass["CheckOut_UserID"] = Session.User.UserID;
            this.qryXClass["CheckOut_LogonName"] = Session.User.LogonName;
            this.qryXClass["CheckOut_User"] = string.Format("{0} {1}", Session.User.FirstName, Session.User.LastName);
            this.qryXClass["CheckOut_Date"] = DateTime.Now;

            if (this.qryXClass.Post())
                grdXClass_DoubleClick(sender, e);
            else
                qryXClass_PositionChanged(this.qryXClass, EventArgs.Empty);
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            string ClassName = DBUtil.ExecuteScalarSQL(@"

            DECLARE @Index      INT,
            @ClassName  VARCHAR(100),
            @XRuleID    INT
            SET @Index = 2

            WHILE EXISTS (SELECT TOP 1 1 FROM XClass WHERE ClassName = {0} + CONVERT(varchar, @Index))
              SET @Index = @Index + 1

            SET @ClassName = {0} + CONVERT(varchar, @Index)

            INSERT INTO dbo.XClass (ClassName, ModulID, MaskName, BaseType, PropertiesXML, Designer, BuildNr)
              SELECT @ClassName, ModulID, MaskName, BaseType, PropertiesXML, 1, BuildNr
              FROM dbo.XClass
              WHERE ClassName = {0}

            INSERT INTO dbo.XClassReference (ClassName, ClassName_Ref)
              SELECT @ClassName, ClassName_Ref
              FROM dbo.XClassReference
              WHERE ClassName = {0}

            INSERT INTO dbo.XClassControl (ClassName, ControlName, ParentControl, TypeName, DataMember, DataSource, LOVName, TabIndex, X, Y, Width, Height, PropertiesXML)
              SELECT @ClassName, ControlName, ParentControl, TypeName, DataMember, DataSource, LOVName, TabIndex, X, Y, Width, Height, PropertiesXML
              FROM dbo.XClassControl
              WHERE ClassName = {0}

            INSERT INTO dbo.XClassComponent (ClassName, ComponentName, TypeName, SelectStatement, TableName, PropertiesXML)
              SELECT @ClassName, ComponentName, TypeName, SelectStatement, TableName, PropertiesXML
              FROM dbo.XClassComponent
              WHERE ClassName = {0}

            DECLARE @XRule TABLE (
              ID       INT IDENTITY(1, 1),
              XRuleID  INT
            )

            INSERT INTO @XRule (XRuleID)
              SELECT XRuleID
              FROM dbo.XRule RUL
              WHERE PublicRule = 0
            AND EXISTS (SELECT TOP 1 1 FROM dbo.XClassRule WHERE ClassName = {0} AND XRuleID = RUL.XRuleID AND Active = 1)

            SELECT @XRuleID = MAX(XRuleID)
            FROM dbo.XRule

            INSERT INTO dbo.XRule (XRuleID, RuleCode, RuleName, RuleDescription, csCode)
              SELECT TMP.ID + @XRuleID, RuleCode, RuleName, RuleDescription, csCode
              FROM @XRule         TMP
            INNER JOIN dbo.XRule RUL ON RUL.XRuleID = TMP.XRuleID

            INSERT INTO dbo.XClassRule (ClassName, ControlName, ComponentName, XRuleID, SortKey)
              SELECT @ClassName, ControlName, ComponentName, IsNull(RUL.ID + @XRuleID, CLR.XRuleID), SortKey
              FROM dbo.XClassRule CLR
            LEFT JOIN @XRule RUL ON RUL.XRuleID = CLR.XRuleID
              WHERE ClassName = {0} AND Active = 1

            SELECT @ClassName", this.qryXClass["ClassName"]) as string;

            this.RenameReference(ClassName, (string)qryXClass["ClassName"], ClassName);

            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
            this.qryXClass.Refresh();
            this.qryXClass.Find(string.Format("ClassName = '{0}'", ClassName));
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (this.qryXClass.Count == 0)
                return;

            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = string.Format("{0}.sql", this.qryXClass["ClassName"]);
                dlg.DefaultExt = "sql";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                using (StreamWriter sw = new StreamWriter(dlg.FileName, false, System.Text.Encoding.Default))
                {
                    ExportXClass((string)this.qryXClass["ClassName"], sw);
                    sw.Close();
                }

                Cursor.Current = Cursors.Default;
                KissMsg.ShowInfo("CtlClass", "ExportAbgeschlossen", "Export abgeschlossen!");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                KissMsg.ShowError("CtlClass", "FehlerExport", "Fehler beim Export!", ex);
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            if (this.qryXClass.Count == 0)
            {
                return;
            }

            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                foreach (DataRow row in this.qryXClass.DataTable.Rows)
                {
                    using (StreamWriter sw = new StreamWriter(string.Format("{0}\\{1}.sql", dlg.SelectedPath, row["ClassName"]), false, System.Text.Encoding.Default))
                    {
                        ExportXClass((string)row["ClassName"], sw);
                        sw.Close();
                    }
                }

                Cursor.Current = Cursors.Default;
                KissMsg.ShowInfo("CtlClass", "ExportAbgeschlossen", "Export abgeschlossen!");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                KissMsg.ShowError("CtlClass", "FehlerExport", "Fehler beim Export!", ex);
            }
        }

        private void btnExportCS_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = string.Format("{0}.cs", this.qryXClass["ClassName"]);
            dlg.DefaultExt = "cs";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ExportCS(new DataRow[] { this.qryXClass.Row }, new FileInfo(dlg.FileName).DirectoryName);
        }

        private void btnExportCSProj_Click(object sender, EventArgs e)
        {
            if (this.qryXClass.Count == 0)
            {
                return;
            }

            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ExportCS(this.qryXClass.DataTable.Select("Designer = 1", "ModulID"), dlg.SelectedPath);
        }

        private void btnImportCSFix_Click(object sender, EventArgs e)
        {
            if (ImportCS(qryXClass, 2))
            {
                this.qryXClass["Designer"] = 2;
                this.qryXClass["Branch"] = Session.Connection.Database;
                this.qryXClass["BuildNr"] = int.Parse(DateTime.Today.ToString("yyyyMMdd"));

                this.qryXClass.Post();

                DlgProgressLog.Show(
                    KissMsg.GetMLMessage("FrmDesigner", "Compile", "Fortschritt: Compile"),
                    new ProgressEventHandler(StartCompile),
                    new ProgressEventHandler(EndCompile),
                    Session.MainForm);

                this.qryXClass.Refresh();
                FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
            }
        }

        private void btnImportCSRule_Click(object sender, EventArgs e)
        {
            if (ImportCS(qryXClass, 1))
            {
                if (this.qryXClass["Designer"] is bool)
                {
                    this.qryXClass["Designer"] = true;
                }
                else
                {
                    this.qryXClass["Designer"] = 1;
                }

                this.qryXClass.Post();
                FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");

                this.btnCheckOut_Click(sender, e);
            }
        }

        private void btnImportDLL_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgFile = new OpenFileDialog();
            dlgFile.Filter = "Application (*.exe,*.dll)|KiSS4.EXE;KiSS4.*.DLL";
            dlgFile.Multiselect = true;

            if (dlgFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                foreach (string fileName in dlgFile.FileNames)
                {
                    Assembly asm = Assembly.LoadFile(fileName);

                    foreach (Type type in asm.GetTypes())
                    {
                        if (type.IsAbstract)
                        {
                            continue;
                        }

                        if (typeof(KissComplexControl).IsAssignableFrom(type) || typeof(KissForm).IsAssignableFrom(type))
                        {
                            DBUtil.ExecSQL(KissTranslation.SQL_INSERT_X_CLASS + @"--SQLCHECK_IGNORE--
                            UPDATE dbo.XClass
                            SET System = 1
                            WHERE ClassName = @ClassName AND
                                    ModulID = @ModulID

                            IF EXISTS (SELECT TOP 1 1 FROM dbo.XClass WHERE ClassName = @ClassName AND Designer = 0) BEGIN
                              UPDATE dbo.XClass
                              SET System      = 1,
                                  ModulID       = IsNull(@ModulID, ModulID),
                                  BaseType      = {2},
                                  ClassCode     = IsNull(@ClassCode, ClassCode),
                                  PropertiesXML = {3}
                              WHERE ClassName = @ClassName

                              DELETE dbo.XClassRule      WHERE ClassName = @ClassName
                              DELETE dbo.XClassControl   WHERE ClassName = @ClassName AND ControlTID IS NULL
                              DELETE dbo.XClassComponent WHERE ClassName = @ClassName AND ComponentTID IS NULL
                            END", type.Name, type.Namespace, type.BaseType.FullName, null);

                            AssemblyLoader.UpdateAssembly(type);
                        }

                        ShowPreview(type);
                    }

                    SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT CLS.*
                        FROM dbo.XClass CLS
                          INNER JOIN dbo.XModul MOD ON MOD.ModulID = CLS.ModulID
                        WHERE CLS.Designer = 0
                          AND MOD.NameSpace = CASE WHEN {0} = 'KiSS4.EXE' THEN 'KiSS4.Main'
                                                   WHEN {0} LIKE '%.DLL'  THEN LEFT({0}, LEN({0}) - 4)
                                              END", (new FileInfo(fileName)).Name);

                    qry.DeleteQuestion = string.Empty;
                    while (qry.Count > 0)
                    {
                        if (AssemblyLoader.GetType((string)qry["ClassName"]) == null && qry.Delete("XClass"))
                        {
                            continue;
                        }
                        else if (!qry.Next())
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlClass", "FehlerImportDLL", "Import Fehlgeschlagen", ex);
            }

            qryXClass.Refresh();
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void btnRemoveFix_Click(object sender, EventArgs e)
        {
            this.qryXClass["Designer"] = 0;
            this.qryXClass["Branch"] = null;
            this.qryXClass["BuildNr"] = 0;

            AssemblyLoader.Remove((string)qryXClass["ClassName"]);

            DeleteXRules((string)qryXClass["ClassName"]);

            this.qryXClass.Post();

            DBUtil.ExecSQL("UPDATE dbo.XClass SET Assembly = NULL WHERE ClassName = {0}", qryXClass["ClassName"]);

            this.qryXClass.Refresh();
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void CtlClass_Load(object sender, EventArgs e)
        {
            this.NewSearch();
            ((IKissDataNavigator)this).Search();
        }

        private void grdXClass_DoubleClick(object sender, EventArgs e)
        {
            // show designer of current selected class
            if (!DBUtil.IsEmpty(qryXClass["ClassName"]))
            {
                FormController.SendMessage("FrmDesigner", "Action", "OpenChildDesigner",
                                                          "ClassName", qryXClass["ClassName"] as string);
            }
        }

        private void qryXClass_AfterDelete(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXClass_AfterInsert(object sender, System.EventArgs e)
        {
            this.qryXClass["ModulID"] = this.ModulID;
            this.qryXClass["Branch"] = Session.Connection.Database;

            if (btnImportCSFix.Visible)
            {
                this.qryXClass["Designer"] = 1;
            }
            else
            {
                this.qryXClass["Designer"] = true;
            }

            this.qryXClass["BaseType"] = typeof(Gui.KissUserControl).FullName;

            this.qryXClass["CheckOut"] = true;
            this.qryXClass["CheckOut_UserID"] = Session.User.UserID;
            this.qryXClass["CheckOut_LogonName"] = Session.User.LogonName;
            this.qryXClass["CheckOut_User"] = string.Format("{0} {1}", Session.User.FirstName, Session.User.LastName);
            this.qryXClass["CheckOut_Date"] = DateTime.Now;

            this.qryXClass.RefreshDisplay();

            if (DBUtil.IsEmpty(this.ModulID))
            {
                this.edtModulID.Focus();
            }
            else
            {
                this.edtClassName.Focus();
            }
        }

        private void qryXClass_AfterPost(object sender, System.EventArgs e)
        {
            this.RenameReference((string)qryXClass["ClassName"], oldClassName, (string)qryXClass["ClassName"]);

            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXClass_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            if (qryXClass["System"].Equals(true))
            {
                throw new KiSS4.DB.KissCancelException();
            }
        }

        private void qryXClass_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtModulID, lblModulID.Text);
            DBUtil.CheckNotNullField(edtClassName, lblClassName.Text);
            DBUtil.CheckNotNullField(edtBaseType, lblBaseType.Text);

            if (qryXClass.Row.HasVersion(DataRowVersion.Original))
            {
                oldClassName = qryXClass["ClassName", DataRowVersion.Original] as string;
            }
            else
            {
                oldClassName = qryXClass["ClassName"] as string;
            }
        }

        private void qryXClass_PositionChanged(object sender, EventArgs e)
        {
            this.btnImportCSRule.Enabled = false;
            this.btnImportCSFix.Enabled = false;
            this.btnRemoveFix.Enabled = false;
            this.btnCheckOut.Enabled = false;
            this.btnCheckIn.Enabled = false;

            if (qryXClass.Count == 0)
                return;

            this.edtModulID.EditMode = (bool)qryXClass["System"] ? EditModeType.ReadOnly : EditModeType.Normal;
            this.edtClassName.EditMode = (bool)qryXClass["System"] ? EditModeType.ReadOnly : EditModeType.Normal;
            this.edtBaseType.EditMode = (bool)qryXClass["System"] ? EditModeType.ReadOnly : EditModeType.Normal;

            this.btnExportCS.Enabled = (qryXClass["Designer"] is bool && (bool)qryXClass["Designer"]) || (qryXClass["Designer"] is int && (int)qryXClass["Designer"] == 1);

            if (!((qryXClass["Designer"] is bool && (bool)qryXClass["Designer"]) || (qryXClass["Designer"] is int && (int)qryXClass["Designer"] > 0)))
            {
                this.btnImportCSRule.Enabled = true;
                this.btnImportCSFix.Enabled = true;
            }
            else if (!(bool)qryXClass["CheckOut"])
            {
                this.btnImportCSRule.Enabled = true;
                this.btnImportCSFix.Enabled = true;
                this.btnRemoveFix.Enabled = this.btnRemoveFix.Visible && (int)qryXClass["Designer"] == 2;
                this.btnCheckOut.Enabled = (qryXClass["Designer"] is bool || (int)qryXClass["Designer"] == 1);
            }
            else if (Session.User.UserID.Equals(qryXClass["CheckOut_UserID"]))
            {
                this.btnCheckIn.Enabled = true;
            }

            this.btnImportCSRule.Enabled = this.btnImportCSRule.Enabled || this.btnCheckOut.Enabled || this.btnCheckIn.Enabled;
            this.btnImportCSFix.Enabled = this.btnImportCSFix.Enabled || this.btnCheckOut.Enabled || this.btnCheckIn.Enabled;

            qryXClass.EnableBoundFields();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void ExportXClass(string className, StreamWriter sw)
        {
            SqlQuery qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClass WHERE ClassName = {0}", className);

            sw.WriteLine("/*");
            sw.WriteLine("  KiSS 4.0");
            sw.WriteLine("  --------");
            sw.WriteLine("  Maske    : {0}", className);
            sw.WriteLine("  Branch   : {0}", qryExport["Branch"]);
            sw.WriteLine("  BuildNr  : {0}", qryExport["BuildNr"]);
            sw.WriteLine("  Datum    : {0:dd.MM.yyyy HH:mm}", DateTime.Now);
            sw.WriteLine("*/");
            sw.WriteLine();
            sw.WriteLine(@"
                -- Save TID
                DECLARE @TID TABLE (
                  ComponentName  varchar(255) COLLATE DATABASE_DEFAULT PRIMARY KEY,
                  TID int
                )

                INSERT INTO @TID
                  SELECT ComponentName, ComponentTID FROM dbo.XClassComponent WHERE ClassName = {0}
                  UNION ALL
                  SELECT ControlName, ControlTID     FROM dbo.XClassControl   WHERE ClassName = {0}

                -- Delete All
                DECLARE @XRule TABLE (XRuleID int)
                INSERT INTO @XRule
                  SELECT CLR.XRuleID
                  FROM dbo.XClassRule CLR
                  WHERE CLR.ClassName = {0}
                    AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XRule WHERE XRuleID = CLR.XRuleID AND PublicRule = 1)
                    AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XClassRule WHERE XRuleID = CLR.XRuleID AND ClassName <> {0})

                DELETE FROM dbo.XClassRule       WHERE ClassName = {0}

                DELETE FROM dbo.XRule            WHERE XRuleID IN (SELECT XRuleID FROM @XRule)
                DELETE FROM dbo.XClassReference  WHERE ClassName = {0}

                DELETE FROM dbo.XClassComponent  WHERE ClassName = {0}
                DELETE FROM dbo.XClassControl    WHERE ClassName = {0}

                ", DBUtil.SqlLiteral(className));

            bool firstColumn = true;

            #region Class

            qryExport.TableName = "XClass";
            sw.WriteLine(@"-- XClass
                IF NOT EXISTS (SELECT TOP 1 1 FROM dbo.XClass WHERE ClassName = {0})
                  INSERT INTO dbo.XClass (ClassName, ModulID, BaseType) VALUES ({0}, {1}, {2})

                ALTER TABLE dbo.XClassReference NOCHECK CONSTRAINT FK_XClassReference_XClassRef
                ALTER TABLE dbo.XClassRule      NOCHECK CONSTRAINT FK_XClassRule_XClassComponent
                ALTER TABLE dbo.XClassRule      NOCHECK CONSTRAINT FK_XClassRule_XClassControl

                UPDATE dbo.XClass
                SET ClassName = {0}
                WHERE ClassName = {0}

                ALTER TABLE dbo.XClassReference CHECK CONSTRAINT FK_XClassReference_XClassRef
                ALTER TABLE dbo.XClassRule      CHECK CONSTRAINT ALL
                ", DBUtil.SqlLiteral(className), DBUtil.SqlLiteral(qryExport["ModulID"]), DBUtil.SqlLiteral(qryExport["BaseType"]));

            sw.WriteLine(@"--SQLCHECK_IGNORE--
                UPDATE XClass SET ");

            foreach (DataColumn col in qryExport.DataTable.Columns)
            {
                switch (col.ColumnName.ToUpper())
                {
                    case "CLASSNAME":
                    case "CLASSTID":
                    case "ASSEMBLY":
                    case "XCLASSTS":
                        break;

                    default:
                        if (!firstColumn)
                        {
                            sw.WriteLine(",");
                        }
                        sw.Write("  [{0}] = {1}", col.ColumnName, DBUtil.SqlLiteral(qryExport[col.ColumnName]));
                        firstColumn = false;
                        break;
                }
            }
            sw.WriteLine("\r\nWHERE ClassName = {0}\r\n\r\n", DBUtil.SqlLiteral(className));

            qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClassControl WHERE ClassName = {0}", className);
            qryExport.TableName = "XClassControl";
            qryExport.ExportDataToSqlScript(sw, string.Format("-- {0}", qryExport.TableName), false, false);

            qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClassComponent WHERE ClassName = {0}", className);
            qryExport.TableName = "XClassComponent";
            qryExport.ExportDataToSqlScript(sw, string.Format("-- {0}", qryExport.TableName), false, false);

            sw.WriteLine(@"
                --SQLCHECK_IGNORE--
                -- Restore TID
                UPDATE CTL
                SET ControlTID = TID.TID
                FROM dbo.XClassControl CTL
                  LEFT JOIN @TID TID ON TID.ComponentName = CTL.ControlName
                WHERE CTL.ClassName = {0}

                UPDATE CMP
                SET ComponentTID = TID.TID
                FROM dbo.XClassComponent CMP
                  LEFT JOIN @TID TID ON TID.ComponentName = CMP.ComponentName
                WHERE CMP.ClassName = {0}

                ", DBUtil.SqlLiteral(className));

            #endregion

            #region Rule

            qryExport = DBUtil.OpenSQL(@"
                SELECT RUL.*
                FROM dbo.XRule RUL
                WHERE EXISTS (SELECT TOP 1 1 FROM dbo.XClassRule WHERE ClassName = {0} AND XRuleID = RUL.XRuleID)", className);
            qryExport.TableName = "XRule";

            if (qryExport.Count > 0)
            {
                sw.WriteLine(@"
            -- Update XRule
            SELECT *
            INTO #XRule
            FROM dbo.XRule
            WHERE 1 = 0
            ");

                using (MemoryStream ms = new MemoryStream())
                {
                    StreamWriter s = new StreamWriter(ms);
                    qryExport.ExportDataToSqlScript(s, string.Empty, false, false);
                    s.Flush();

                    ms.Position = 0;
                    StreamReader sr = new StreamReader(ms);

                    string oldValue = "--SQLCHECK_IGNORE--\r\ninsert [XRule](["; //marked to make SqlSyntaxCheck happy
                    oldValue = oldValue.Replace("--SQLCHECK_IGNORE--", ""); //remove the mark
                    string newValue = "--SQLCHECK_IGNORE--\r\ninsert [#XRule](["; //marked to make SqlSyntaxCheck happy
                    newValue = newValue.Replace("--SQLCHECK_IGNORE--", ""); //remove the mark

                    sw.Write(sr.ReadToEnd().Replace(oldValue, newValue));
                }

                ArrayList alColumns = new ArrayList();
                foreach (DataColumn col in qryExport.DataTable.Columns)
                {
                    if (col.ColumnName.ToUpper() != "XRULETS")
                        alColumns.Add(col.ColumnName);
                }

                sw.WriteLine(string.Format(@"
            DELETE TMP
            FROM #XRule TMP
              INNER JOIN dbo.XRule RUL ON RUL.XRuleID = TMP.XRuleID
            WHERE TMP.PublicRule = RUL.PublicRule AND TMP.RuleCode = RUL.RuleCode
              AND dbo.fnXCompareTEXT(TMP.csCode, RUL.csCode) = 1

            DECLARE @XRuleID      INT,
            @XRuleID_New  INT

            DECLARE cRule CURSOR FAST_FORWARD FOR
              SELECT TMP.XRuleID
              FROM #XRule TMP
            INNER JOIN dbo.XRule RUL ON RUL.XRuleID = TMP.XRuleID

            OPEN cRule
            WHILE (1 = 1) BEGIN
              FETCH NEXT FROM cRule INTO @XRuleID
              IF @@FETCH_STATUS < 0 BREAK

              SELECT @XRuleID_New = MAX(XRuleID) + 1 FROM XRule
              UPDATE dbo.XRule       SET XRuleID = @XRuleID_New  WHERE XRuleID = @XRuleID
              UPDATE dbo.XClassRule  SET XRuleID = @XRuleID_New  WHERE XRuleID = @XRuleID
            END
            DEALLOCATE cRule

            INSERT INTO XRule ([{0}])
              SELECT [{0}]
              FROM #XRule

            DROP TABLE #XRule
            ",
                    string.Join("], [", (string[])alColumns.ToArray(typeof(string)))
                    ));
            }

            qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClassRule WHERE ClassName = {0}", className);
            qryExport.TableName = "XClassRule";
            qryExport.ExportDataToSqlScript(sw, string.Format("-- {0}", qryExport.TableName), false, false);

            #endregion

            #region XRight

            qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XRight WHERE ClassName = {0}", className);
            qryExport.TableName = "XRight";

            if (qryExport.Count > 0)
            {
                sw.WriteLine(@"
            -- Update XRight
            SELECT *
            INTO #XRight
            FROM dbo.XRight
            WHERE 1 = 0
            ");

                using (MemoryStream ms = new MemoryStream())
                {
                    StreamWriter s = new StreamWriter(ms);
                    qryExport.ExportDataToSqlScript(s, string.Empty, false, false);
                    s.Flush();

                    ms.Position = 0;
                    StreamReader sr = new StreamReader(ms);

                    string oldValue = "--SQLCHECK_IGNORE--\r\ninsert [XRight](["; //marked to make SqlSyntaxCheck happy
                    oldValue = oldValue.Replace("--SQLCHECK_IGNORE--", ""); //remove the mark
                    string newValue = "--SQLCHECK_IGNORE--\r\ninsert [#XRight](["; //marked to make SqlSyntaxCheck happy
                    newValue = newValue.Replace("--SQLCHECK_IGNORE--", ""); //remove the mark

                    sw.Write(sr.ReadToEnd().Replace(oldValue, newValue));
                }

                ArrayList alColumns = new ArrayList();
                foreach (DataColumn col in qryExport.DataTable.Columns)
                {
                    if (col.ColumnName.ToUpper() != "XRIGHTTS")
                        alColumns.Add(col.ColumnName);
                }

                sw.Write(string.Format(@"
            SET IDENTITY_INSERT [XRight] ON
            INSERT INTO XRight ([{0}])
              SELECT [{0}]
              FROM #XRight  RGT
              WHERE NOT EXISTS (SELECT TOP 1 1 FROM dbo.XRight WHERE ClassName = RGT.ClassName AND RightName = RGT.RightName)
            AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XRight WHERE RightID = RGT.RightID)
            SET IDENTITY_INSERT [XRight] OFF", string.Join("], [", (string[])alColumns.ToArray(typeof(string)))));

                alColumns.RemoveAt(0);
                sw.Write(string.Format(@"

            INSERT INTO XRight ([{0}])
              SELECT [{0}]
              FROM #XRight  RGT
              WHERE NOT EXISTS (SELECT TOP 1 1 FROM dbo.XRight WHERE ClassName = RGT.ClassName AND RightName = RGT.RightName)

            DROP TABLE #XRight", string.Join("], [", (string[])alColumns.ToArray(typeof(string)))));
            }

            #endregion

            #region XClassReference

            qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClassReference WHERE ClassName = {0}", className);
            qryExport.TableName = "XClassReference";
            qryExport.ExportDataToSqlScript(sw, string.Format("-- {0}", qryExport.TableName), false, false);

            #endregion
        }

        #endregion

        #region Internal Static Methods

        internal static SqlQuery DeleteXRules(string className)
        {
            return DBUtil.OpenSQL(@"
                DECLARE @XRule TABLE (XRuleID INT)

                INSERT INTO @XRule
                  SELECT CLR.XRuleID
                  FROM dbo.XClassRule CLR
                  WHERE CLR.ClassName = {0}
                    AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XRule      WHERE XRuleID = CLR.XRuleID AND (RuleCode IN (1) OR PublicRule = 1))
                    AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XClassRule WHERE XRuleID = CLR.XRuleID AND ClassName <> {0})

                SELECT *
                FROM dbo.XRule
                WHERE XRuleID IN (SELECT XRuleID FROM @XRule)

                DELETE FROM dbo.XClassRule
                WHERE ClassName = {0}

                DELETE FROM dbo.XRule
                WHERE XRuleID IN (SELECT XRuleID FROM @XRule)", className);
        }

        internal static void ExportCS(DataRow[] rows, string path)
        {
            if (rows.Length == 0)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string nameSpace = DBUtil.ExecuteScalarSQL("SELECT NameSpace FROM dbo.XModul WHERE ModulID = {0}", rows[0]["ModulID"]) as string;
                string projectFile = string.Format("{0}\\{1}.csproj", path, nameSpace);

                XmlDocument xmlProject = new XmlDocument();
                bool projectModified = false;
                if (File.Exists(projectFile))
                {
                    xmlProject.Load(projectFile);
                }
                else
                {
                    projectModified = true;

                    xmlProject.LoadXml(string.Format(@"
            <Project DefaultTargets=""Build"" xmlns=""{0}"">
              <PropertyGroup>
            <ProjectType>Local</ProjectType>
            <ProductVersion>8.0.50727</ProductVersion>
            <SchemaVersion>2.0</SchemaVersion>
            <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
            <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
            <AssemblyName>{1}</AssemblyName>
            <OutputType>Library</OutputType>
            <RootNamespace>{1}</RootNamespace>
              </PropertyGroup>
              <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
            <OutputPath>bin\Debug\</OutputPath>
            <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
            <BaseAddress>285212672</BaseAddress>
            <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
            <ConfigurationOverrideFile />
            <DefineConstants>DEBUG;TRACE</DefineConstants>
            <DocumentationFile />
            <DebugSymbols>true</DebugSymbols>
            <FileAlignment>4096</FileAlignment>
            <NoStdLib>false</NoStdLib>
            <NoWarn />
            <Optimize>false</Optimize>
            <RegisterForComInterop>false</RegisterForComInterop>
            <RemoveIntegerChecks>false</RemoveIntegerChecks>
            <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
            <WarningLevel>4</WarningLevel>
            <DebugType>full</DebugType>
            <ErrorReport>prompt</ErrorReport>
              </PropertyGroup>
              <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
            <OutputPath>bin\Release\</OutputPath>
            <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
            <BaseAddress>285212672</BaseAddress>
            <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
            <ConfigurationOverrideFile />
            <DefineConstants>TRACE</DefineConstants>
            <DocumentationFile />
            <DebugSymbols>false</DebugSymbols>
            <FileAlignment>4096</FileAlignment>
            <NoStdLib>false</NoStdLib>
            <NoWarn />
            <Optimize>true</Optimize>
            <RegisterForComInterop>false</RegisterForComInterop>
            <RemoveIntegerChecks>false</RemoveIntegerChecks>
            <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
            <WarningLevel>4</WarningLevel>
            <DebugType>none</DebugType>
            <ErrorReport>prompt</ErrorReport>
              </PropertyGroup>
              <ItemGroup>
            <Reference Include=""System"">
              <Name>System</Name>
            </Reference>
            <Reference Include=""System.Data"">
              <Name>System.Data</Name>
            </Reference>
            <Reference Include=""System.Design"">
              <Name>System.Design</Name>
            </Reference>
            <Reference Include=""System.Drawing"">
              <Name>System.Drawing</Name>
            </Reference>
            <Reference Include=""System.Windows.Forms"">
              <Name>System.Windows.Forms</Name>
            </Reference>
            <Reference Include=""System.Xml"">
              <Name>System.XML</Name>
            </Reference>
              </ItemGroup>
              <ItemGroup>
              </ItemGroup>
              <Import Project=""$(MSBuildBinPath)\Microsoft.CSharp.targets"" />
            </Project>", nsProject, nameSpace));
                }

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlProject.NameTable);
                nsmgr.AddNamespace(string.Empty, nsProject);
                nsmgr.AddNamespace("pr", nsProject);

                foreach (DataRow row in rows)
                {
                    SqlQuery qryExport = DBUtil.OpenSQL(@"SELECT * FROM dbo.XClass WHERE ClassName = {0}", row["ClassName"]);

                    if (DBUtil.IsEmpty(qryExport["CodeGenerated"]))
                        continue;

                    File.WriteAllText(string.Format("{0}\\{1}.cs", path, qryExport["ClassName"]), (string)qryExport["CodeGenerated"], Encoding.Default);
                    projectModified = AddFileCS(xmlProject, nsmgr, (string)qryExport["ClassName"]) | projectModified;

                    if (!DBUtil.IsEmpty(qryExport["Resource"]))
                    {
                        System.Resources.ResourceReader resReader = new System.Resources.ResourceReader(new MemoryStream((byte[])qryExport["Resource"]));

                        System.Resources.ResXResourceWriter resXWriter = new System.Resources.ResXResourceWriter(string.Format("{0}\\{1}.resx", path, qryExport["ClassName"]));
                        foreach (DictionaryEntry resItem in resReader)
                            resXWriter.AddResource((string)resItem.Key, resItem.Value);

                        resReader.Close();
                        resXWriter.Close();

                        projectModified = AddFileResX(xmlProject, nsmgr, (string)qryExport["ClassName"]) | projectModified;
                    }

                    SqlQuery qryRule = DBUtil.OpenSQL(@"
                        SELECT RUL.*
                        FROM dbo.XClassRule CLR
                          INNER JOIN dbo.XRule RUL ON RUL.XRuleID = CLR.XRuleID AND RuleCode = 1
                        WHERE CLR.ClassName = {0}", qryExport["ClassName"]);

                    foreach (DataRow rowRule in qryRule.DataTable.Rows)
                    {
                        File.WriteAllText(string.Format("{0}\\{1}.cs", path, rowRule["RuleName"]), (string)rowRule["csCode"], Encoding.Default);
                        projectModified = AddFileCS(xmlProject, nsmgr, (string)rowRule["RuleName"]) | projectModified;
                    }
                }

                if (projectModified)
                    xmlProject.Save(string.Format(projectFile));

                Cursor.Current = Cursors.Default;
                KissMsg.ShowInfo("CtlClass", "ExportAbgeschlossen", "Export abgeschlossen!");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                KissMsg.ShowError("CtlClass", "FehlerExport", "Fehler beim Export!", ex);
            }
        }

        internal static bool ImportCS(SqlQuery qryXClass, int designerCode)
        {
            OpenFileDialog dlgFile = new OpenFileDialog();
            dlgFile.Filter = "C# Source (*.cs)|*.CS";
            dlgFile.FileName = string.Format("{0}.cs", qryXClass["ClassName"]);

            if (dlgFile.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            try
            {
                FileInfo fi = new FileInfo(dlgFile.FileName);
                StreamReader sr = new StreamReader(fi.OpenRead(), GetFileEncoding(fi));
                string csFile = sr.ReadToEnd();
                sr.Close();

                if (csFile.IndexOf(string.Format("class {0}", qryXClass["ClassName"])) == -1
                    || (designerCode == 1 && csFile.IndexOf("// Begin Rule") == -1))
                {
                    throw new KissInfoException("Die angegebene Datei entspricht nicht den Vorgaben und kann deshalb nicht importiert werden.");
                }

                #region Regex

                Regex rxNamespace = new Regex(@"namespace\s+KiSS4\.(?<Modul>\w+)(?:\.(?<NamespaceExtension>\w+))?");

                Regex rxRule = new Regex(@"(?<Ident>(\x20|\t)*)//\sBegin\sRule\r\n(?<Header>(\s*//\s*\w+\s*:.*?\r\n)?)(?<Code>.*?)\s*//\sEnd\sRule", RegexOptions.IgnoreCase | RegexOptions.Singleline);

                Regex rxControlName = new Regex(@"//\s.*ControlName\s*:\s*(?<Value>\w*)", RegexOptions.IgnoreCase);
                Regex rxComponentName = new Regex(@"//\s.*ComponentName\s*:\s*(?<Value>\w*)", RegexOptions.IgnoreCase);
                Regex rxRuleType = new Regex(@"//\s.*RuleType\s*:\s*(?<Value>\w*)", RegexOptions.IgnoreCase);
                Regex rxSortKey = new Regex(@"//\s.*SortKey\s*:\s*(?<Value>\d*)", RegexOptions.IgnoreCase);
                Regex rxRuleName = new Regex(@"//\s.*RuleName\s*:\s*(?<Value>.*?)\s*\r\n", RegexOptions.IgnoreCase);

                #endregion

                #region SqlQuery

                SqlQuery qryXOldRule = DeleteXRules((string)qryXClass["ClassName"]);

                if (designerCode == 1 && !((qryXClass["Designer"] is bool && (bool)qryXClass["Designer"]) || (qryXClass["Designer"] is int && (int)qryXClass["Designer"] == 1)))
                {
                    Type type = AssemblyLoader.GetType((string)qryXClass["ClassName"]);

                    Session.BeginTransaction();

                    try
                    {
                        // remove propertiesxml, controls and components of desired class
                        DBUtil.ExecSQLThrowingException(@"
                                UPDATE dbo.XClass
                                SET PropertiesXML = NULL
                                WHERE ClassName = {0}

                                DELETE FROM dbo.XClassControl
                                WHERE ClassName = {0}

                                DELETE FROM dbo.XClassComponent
                                WHERE ClassName = {0}", qryXClass["ClassName"]);

                        // check if we have a valid type and ShowPreview can reinsert deleted entries properly (using translation mode)
                        if (type == null || !ShowPreview(type))
                        {
                            // do not continue, something wrong
                            throw new InvalidOperationException();
                        }

                        // save changes
                        Session.Commit();
                    }
                    catch
                    {
                        // check if we still have an open transaction (possibly closed by ShowPreview() call while loading desired control)
                        if (Session.Transaction != null)
                        {
                            // undo changes
                            Session.Rollback();
                        }
                    }

                    // refresh display
                    qryXClass.Refresh();
                }

                SqlQuery qryXSysRule = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.XRule
                    WHERE ISNULL(ModulID, {0}) = {0} AND
                          (PublicRule = 1 OR RuleCode IN (1))", qryXClass["ModulID"]);

                SqlQuery qryXRule = DBUtil.OpenSQL("SELECT * FROM dbo.XRule WHERE 1 = 0");
                qryXRule.TableName = "XRule";
                qryXRule.DeleteQuestion = string.Empty;
                qryXRule.CanInsert = true;
                qryXRule.CanDelete = true;

                SqlQuery qryXClassRule = DBUtil.OpenSQL("SELECT * FROM dbo.XClassRule WHERE 1 = 0");
                qryXClassRule.TableName = "XClassRule";
                qryXClassRule.CanInsert = true;

                #endregion

                foreach (Match mRule in rxRule.Matches(csFile))
                {
                    string header = mRule.Groups["Header"].Value;
                    int ruleCode = 3;
                    Match m = rxRuleType.Match(header);
                    if (m.Success)
                    {
                        // ClassReference
                        if (m.Groups["Value"].Value == "ClassReference")
                        {
                            Match ruleName = rxRuleName.Match(header);
                            if (ruleName.Success)
                            {
                                DBUtil.ExecSQLThrowingException(@"
                                    IF EXISTS (SELECT TOP 1 1 FROM dbo.XClass WHERE ClassName = {1})
                                      AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.XClassReference WHERE ClassName = {0} AND ClassName_Ref = {1})
                                    BEGIN
                                      INSERT INTO dbo.XClassReference (ClassName, ClassName_Ref)
                                        VALUES ({0}, {1})
                                    END", qryXClass["ClassName"], ruleName.Groups["Value"].Value);

                                continue;
                            }
                        }

                        ruleCode = (int)DBUtil.ExecuteScalarSQL(
                            "SELECT Code FROM dbo.XLOVCode WHERE LOVName = 'Rule' AND Text = {0} UNION ALL SELECT {1}"
                            , m.Groups["Value"].Value, ruleCode);
                    }

                    if (designerCode == 2 && ruleCode != 1) // Fix, RuleCode: Class
                    {
                        continue;
                    }

                    #region XClassRule

                    qryXClassRule.Insert();
                    qryXClassRule["ClassName"] = qryXClass["ClassName"];

                    m = rxControlName.Match(header);
                    if (m.Success)
                    {
                        qryXClassRule["ControlName"] = m.Groups["Value"].Value;
                    }

                    m = rxComponentName.Match(header);
                    if (m.Success)
                    {
                        qryXClassRule["ComponentName"] = m.Groups["Value"].Value;
                    }

                    #region XRule

                    qryXRule.Insert();
                    qryXRule["RuleCode"] = ruleCode;

                    m = rxRuleName.Match(header);
                    if (m.Success)
                    {
                        qryXRule["RuleName"] = m.Groups["Value"].Value;
                    }

                    string csCode = string.Empty;
                    SqlQuery qryPlaceHolder;

                    if (ruleCode == 1) // Class
                    {
                        foreach (FileInfo fiClass in fi.Directory.GetFiles(string.Format("{0}.cs", qryXRule["RuleName"])))
                        {
                            sr = new System.IO.StreamReader(fiClass.OpenRead(), GetFileEncoding(fiClass));
                            csCode = sr.ReadToEnd();
                            sr.Close();
                        }

                        qryPlaceHolder = DBUtil.OpenSQL(@"SELECT ClassName = NULL");
                    }
                    else
                    {
                        string ident = mRule.Groups["Ident"].Value.Replace("    ", "\t");
                        csCode = mRule.Groups["Code"].Value;
                        csCode = csCode.Replace(Environment.NewLine + ident, Environment.NewLine);
                        csCode = csCode.Replace(Environment.NewLine + ident.Replace("\t", "    "), Environment.NewLine);

                        qryPlaceHolder = DBUtil.OpenSQL(@"
                            SELECT CLS.ClassName, ControlName, DataSource, DataMember, ComponentName
                            FROM dbo.XClass CLS
                              LEFT JOIN dbo.XClassControl   CTL ON CTL.ClassName = CLS.ClassName AND CTL.ControlName = {1}
                              LEFT JOIN dbo.XClassComponent CMP ON CMP.ClassName = CLS.ClassName AND CMP.ComponentName = {2}
                            WHERE CLS.ClassName = {0}", qryXClassRule["ClassName"], qryXClassRule["ControlName"], qryXClassRule["ComponentName"]);
                    }
                    csCode = csCode.Trim();

                    // System Rule
                    foreach (DataRow row in qryXSysRule.DataTable.Rows)
                    {
                        if (row["RuleCode"].Equals(qryXRule["RuleCode"])
                            && csCode.Equals(MyCodeDomDesignerLoader.ReplacePlaceholder(qryPlaceHolder.Row, (string)row["csCode"])))
                        {
                            qryXClassRule["XRuleID"] = row["XRuleID"];
                            if (!DBUtil.IsEmpty(row["DefaultSortKey"]))
                                qryXClassRule["SortKey"] = row["DefaultSortKey"];
                            qryXRule.Delete();
                            break;
                        }
                    }

                    // Duplicate Rule
                    if (DBUtil.IsEmpty(qryXClassRule["XRuleID"]))
                    {
                        foreach (DataRow row in qryXRule.DataTable.Rows)
                        {
                            if (!DBUtil.IsEmpty(row["XRuleID"]) && row["RuleCode"].Equals(qryXRule["RuleCode"])
                                && csCode.Equals(MyCodeDomDesignerLoader.ReplacePlaceholder(qryPlaceHolder.Row, (string)row["csCode"])))
                            {
                                qryXClassRule["XRuleID"] = row["XRuleID"];
                                qryXRule.Delete();
                                break;
                            }
                        }
                    }

                    if (DBUtil.IsEmpty(qryXClassRule["XRuleID"]))
                    {
                        // Replace Placeholder
                        foreach (DataColumn col in qryPlaceHolder.DataTable.Columns)
                        {
                            if (!DBUtil.IsEmpty(qryPlaceHolder[col.ColumnName]))
                            {
                                switch (col.ColumnName)
                                {
                                    case "DataMember":
                                        csCode = csCode.Replace(string.Format("[\"{0}\"]", qryPlaceHolder[col.ColumnName]), "[\"<DataMember>\"]");
                                        break;

                                    default:
                                        csCode = Regex.Replace(csCode, string.Format(@"(?<=(\W|^)){0}(?=(\W|$))", qryPlaceHolder[col.ColumnName]), string.Format("<{0}>", col.ColumnName));
                                        break;
                                }
                            }
                        }
                        qryXRule["csCode"] = csCode;
                    }

                    // Get old RuleID
                    if (DBUtil.IsEmpty(qryXClassRule["XRuleID"]))
                    {
                        // Generate new RuleID
                        qryXRule["XRuleID"] = DBUtil.ExecuteScalarSQL(@"
                            SELECT ISNULL(MAX(XRuleID), 1000) + 1
                            FROM dbo.XRule
                            WHERE XRuleID > 1000");

                        // Get old RuleID
                        foreach (DataRow row in qryXOldRule.DataTable.Rows)
                        {
                            if (row["RuleCode"].Equals(qryXRule["RuleCode"]) && row["csCode"].Equals(qryXRule["csCode"]))
                            {
                                qryXRule["XRuleID"] = row["XRuleID"];
                                qryXRule["RuleDescription"] = row["RuleDescription"];
                                break;
                            }
                        }

                        qryXRule.Post();
                        qryXClassRule["XRuleID"] = qryXRule["XRuleID"];
                    }

                    #endregion

                    m = rxSortKey.Match(header);
                    if (m.Success)
                    {
                        qryXClassRule["SortKey"] = int.Parse(m.Groups["Value"].Value);
                    }

                    if (!qryXClassRule.Post())
                    {
                        qryXClassRule.DataTable.RejectChanges();
                        qryXClassRule.RowModified = false;
                        qryXClassRule.Last();
                    }

                    #endregion
                }

                #region Import Fix (.Designer.cs, .resx)

                if (designerCode == 2)
                {
                    try
                    {
                        string fileName = fi.FullName.Replace(fi.Extension, ".Designer.cs");
                        FileInfo designerCS = new FileInfo(fileName);

                        if (designerCS.Exists)
                        {
                            sr = new StreamReader(designerCS.OpenRead(), GetFileEncoding(designerCS));

                            qryXClassRule.Insert();
                            qryXClassRule["ClassName"] = qryXClass["ClassName"];

                            qryXRule.Insert();
                            qryXRule["RuleCode"] = 1; // Class
                            qryXRule["RuleName"] = string.Format("{0}.Designer", qryXClass["ClassName"]); // Class
                            qryXRule["csCode"] = sr.ReadToEnd();

                            sr.Close();

                            // Generate new RuleID
                            qryXRule["XRuleID"] = DBUtil.ExecuteScalarSQL(@"
                                    SELECT ISNULL(MAX(XRuleID), 1000) + 1
                                    FROM dbo.XRule
                                    WHERE XRuleID > 1000");

                            // Get old RuleID
                            foreach (DataRow row in qryXOldRule.DataTable.Rows)
                            {
                                if (row["RuleCode"].Equals(qryXRule["RuleCode"]) && row["csCode"].Equals(qryXRule["csCode"]))
                                {
                                    qryXRule["XRuleID"] = row["XRuleID"];
                                    qryXRule["RuleDescription"] = row["RuleDescription"];
                                    break;
                                }
                            }

                            qryXRule.Post();

                            qryXClassRule["XRuleID"] = qryXRule["XRuleID"];
                            qryXClassRule.Post();
                        }
                    }
                    catch
                    {
                    }

                    byte[] resource = null;
                    try
                    {
                        string fileName = fi.FullName.Replace(fi.Extension, ".resx");

                        using (System.Resources.ResXResourceReader resReader = new System.Resources.ResXResourceReader(fileName))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                System.Resources.ResourceWriter resWriter = new System.Resources.ResourceWriter(ms);
                                foreach (DictionaryEntry resItem in resReader)
                                {
                                    resWriter.AddResource((string)resItem.Key, resItem.Value);
                                }

                                resWriter.Generate();
                                resource = ms.ToArray();
                                resWriter.Close();
                                ms.Close();
                            }
                            resReader.Close();
                        }
                    }
                    catch
                    {
                    }

                    Match m = rxNamespace.Match(csFile);

                    DBUtil.ExecSQLThrowingException(@"
                            UPDATE dbo.XClass
                            SET CodeGenerated = {1}, Resource = {2}, NamespaceExtension = {3}
                            WHERE ClassName = {0}", qryXClass["ClassName"], csFile, resource, m.Groups["NamespaceExtension"].Value);

                    qryXClass.Refresh();
                }

                #endregion

                try
                {
                    XmlDocument xmlResource = new XmlDocument();
                    xmlResource.Load(fi.FullName.Replace(fi.Extension, ".resx"));

                    foreach (XmlNode node in xmlResource.SelectNodes("/root/data"))
                    {
                        if (node.Attributes["name"].Value.EndsWith(".SelectStatement"))
                        {
                            string ComponentName = node.Attributes["name"].Value.Replace(".SelectStatement", string.Empty);
                            foreach (XmlNode child in node.ChildNodes)
                            {
                                if (child.FirstChild is XmlText)
                                {
                                    DBUtil.ExecSQL(@"
                                            UPDATE dbo.XClassComponent
                                            SET SelectStatement = {2}
                                            WHERE ClassName = {0} AND
                                                  ComponentName = {1}", qryXClass["ClassName"], ComponentName, child.FirstChild.Value);
                                }
                            }
                        }
                    }
                }
                catch { }

                Regex rxInitializeComponent = new Regex(@"(?<=\r\n\s*#region (Designer generated code)|(Windows Form Designer generated code)|(Component Designer generated code))(?<csCode>.*?)(?=\r\n\s*#endregion\r)", RegexOptions.Singleline);
                Regex rxSelectStatement = new Regex(@"(?<=\n\s*this\.)(?<ComponentName>\w*)\.SelectStatement\s*=\s*(?<SelectStatement>"".*?"")(?=;\r)", RegexOptions.Singleline);
                Regex rxTableName = new Regex(@"(?<=\n\s*this\.)(?<ComponentName>\w*)\.TableName\s*=\s*""(?<TableName>.*?)(?="";\r)", RegexOptions.Singleline);
                Regex rxDataSource = new Regex(@"(?<=\n\s*this\.)(?<ControlName>\w*)\.DataSource\s*=\s*this\.(?<DataSource>.*?)(?=;\r)", RegexOptions.Singleline);
                Regex rxDataMember = new Regex(@"(?<=\n\s*this\.)(?<ControlName>\w*)\.DataMember\s*=\s*""(?<DataMember>.*?)(?="";\r)", RegexOptions.Singleline);

                foreach (Match m in rxInitializeComponent.Matches(csFile))
                {
                    foreach (Match match in rxSelectStatement.Matches(m.Value))
                    {
                        string[] SelectStatement = match.Groups["SelectStatement"].Value.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        for (int i = 0; i < SelectStatement.Length; i++)
                        {
                            SelectStatement[i] = SelectStatement[i].Substring(SelectStatement[i].IndexOf('"') + 1);
                            SelectStatement[i] = SelectStatement[i].Substring(0, SelectStatement[i].LastIndexOf('"'));
                        }

                        DBUtil.ExecSQL(@"
                                UPDATE dbo.XClassComponent
                                SET SelectStatement = {2}
                                WHERE ClassName = {0} AND
                                      ComponentName = {1}", qryXClass["ClassName"], match.Groups["ComponentName"].Value, string.Join(string.Empty, SelectStatement).Replace(@"\r\n", "\r\n"));
                    }

                    foreach (Match match in rxTableName.Matches(m.Value))
                    {
                        DBUtil.ExecSQL(@"
                                UPDATE dbo.XClassComponent
                                SET TableName = {2}
                                WHERE ClassName = {0} AND
                                      ComponentName = {1}", qryXClass["ClassName"], match.Groups["ComponentName"].Value, match.Groups["TableName"].Value);
                    }

                    foreach (Match match in rxDataSource.Matches(m.Value))
                    {
                        DBUtil.ExecSQL(@"
                                UPDATE XClassControl
                                SET DataSource = {2}
                                WHERE ClassName = {0} AND
                                      ControlName = {1}", qryXClass["ClassName"], match.Groups["ControlName"].Value, match.Groups["DataSource"].Value);
                    }

                    foreach (Match match in rxDataMember.Matches(m.Value))
                    {
                        DBUtil.ExecSQL(@"
                                UPDATE XClassControl
                                SET DataMember = {2}
                                WHERE ClassName = {0} AND
                                      ControlName = {1}", qryXClass["ClassName"], match.Groups["ControlName"].Value, match.Groups["DataMember"].Value);
                    }
                }
                return true;
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                // show message
                new KissErrorException("Import fehlgeschlagen.", ex).ShowMessage();
            }
            return false;
        }

        #endregion

        #region Internal Methods

        internal void FindClassName(string className)
        {
            this.qryXClass.Find(string.Format("ClassName = '{0}'", className));
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            this.edtSearchModulID.EditValue = ModulID;

            if (DBUtil.IsEmpty(this.ModulID))
            {
                this.edtSearchModulID.Focus();
            }
            else
            {
                edtSearchBaseType.Focus();
            }
        }

        #endregion

        #region Private Static Methods

        private static bool AddFileCS(XmlDocument xmlProject, XmlNamespaceManager nsmgr, string ClassName)
        {
            XmlNode node = xmlProject.SelectSingleNode(string.Format("/pr:Project/pr:ItemGroup/pr:Compile[@Include='{0}.cs']", ClassName), nsmgr);
            if (node != null)
                return false;

            node = xmlProject.CreateElement("Compile", nsProject);
            xmlProject.SelectSingleNode("/pr:Project/pr:ItemGroup[position()=2]", nsmgr).AppendChild(node);

            XmlAttribute xmlAttr = xmlProject.CreateAttribute("Include");
            xmlAttr.Value = string.Format("{0}.cs", ClassName);
            node.Attributes.Append(xmlAttr);

            XmlElement xmlElem = xmlProject.CreateElement("SubType", nsProject);
            xmlElem.InnerText = "Code";
            node.AppendChild(xmlElem);

            return true;
        }

        private static bool AddFileResX(XmlDocument xmlProject, XmlNamespaceManager nsmgr, string ClassName)
        {
            XmlNode node = xmlProject.SelectSingleNode(string.Format("/pr:Project/pr:ItemGroup/pr:EmbeddedResource[@Include='{0}.resx']", ClassName), nsmgr);
            if (node != null)
                return false;

            node = xmlProject.CreateElement("EmbeddedResource", nsProject);
            xmlProject.SelectSingleNode("/pr:Project/pr:ItemGroup[position()=2]", nsmgr).AppendChild(node);

            XmlAttribute xmlAttr = xmlProject.CreateAttribute("Include");
            xmlAttr.Value = string.Format("{0}.resx", ClassName);
            node.Attributes.Append(xmlAttr);

            XmlElement xmlElem = xmlProject.CreateElement("DependentUpon", nsProject);
            xmlElem.InnerText = string.Format("{0}.cs", ClassName);
            node.AppendChild(xmlElem);

            xmlElem = xmlProject.CreateElement("SubType", nsProject);
            xmlElem.InnerText = "Designer";
            node.AppendChild(xmlElem);

            return true;
        }

        private static Encoding GetFileEncoding(FileInfo file)
        {
            Encoding result = null;
            FileStream fs = null;
            try
            {
                fs = file.OpenRead();

                Encoding[] UnicodeEncodings = { Encoding.BigEndianUnicode, Encoding.Unicode, Encoding.UTF8 };
                for (int i = 0; result == null && i < UnicodeEncodings.Length; i++)
                {
                    fs.Position = 0;

                    byte[] Preamble = UnicodeEncodings[i].GetPreamble();
                    bool PreamblesAreEqual = true;

                    for (int j = 0; PreamblesAreEqual && j < Preamble.Length; j++)
                        PreamblesAreEqual = Preamble[j] == fs.ReadByte();

                    if (PreamblesAreEqual)
                        result = UnicodeEncodings[i];
                }
            }
            catch (IOException)
            { }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            if (result == null)
            {
                return Encoding.Default;
            }

            return result;
        }

        private static bool ShowPreview(Type type)
        {
            ConstructorInfo ctor = type.GetConstructor(new Type[] { });

            if (ctor == null)
            {
                return false;
            }

            try
            {
                object instance = ctor.Invoke(new object[] { });
                if (instance is KissUserControl)
                {
                    DlgKissUserControl dlg = new DlgKissUserControl("Vorschau", (KissUserControl)instance);
                    dlg.Show();
                    dlg.Close();
                }
                else if (instance is KissChildForm)
                {
                    KissChildForm frm = (KissChildForm)instance;
                    frm.MdiParent = Session.MainForm;
                    frm.Show();
                    frm.Close();
                }
                else if (instance is KissForm)
                {
                    KissForm frm = (KissForm)instance;
                    frm.Show();
                    frm.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Private Methods

        private void EndCompile()
        {
        }

        private String GetClassSqlScript(string classname)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);

            CtlClass.ExportXClass(classname, sw);
            sw.Flush();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private void RenameReference(string className, string oldName, string newName)
        {
            if (newName.Equals(oldName))
                return;

            DBUtil.ExecSQL(string.Format(@"
                UPDATE dbo.XClassControl
                SET PropertiesXML = REPLACE(CONVERT(varchar(8000), PropertiesXML), '<Reference name=""{1}"" />', '<Reference name=""{2}"" />')
                WHERE ClassName = {0} AND
                      DATALENGTH(PropertiesXML) < 7900 AND
                      PropertiesXML LIKE '%<Reference name=""{1}"" />%'

                UPDATE dbo.XClassComponent
                SET PropertiesXML = REPLACE(CONVERT(varchar(8000), PropertiesXML), '<Reference name=""{1}"" />', '<Reference name=""{2}"" />')
                WHERE ClassName = {0} AND
                      DATALENGTH(PropertiesXML) < 7900 AND
                      PropertiesXML LIKE '%<Reference name=""{1}"" />%'", "{0}", oldName, newName), className);
        }

        private void StartCompile()
        {
            AssemblyLoader.LoadProgramAssembly();

            try
            {
                SqlQuery qryXClass_Build = DBUtil.OpenSQL(string.Format(CtlDesignerLayout.SelectClassReference, @"--SQLCHECK_IGNORE--
                    INSERT INTO @XClass (ClassName) VALUES ({0})"), qryXClass["ClassName"]);

                qryXClass_Build.TableName = "XClass";
                qryXClass_Build.CanUpdate = true;

                while (qryXClass_Build.Count > 0)
                {
                    CtlDesignerLayout.Build(qryXClass_Build);

                    if (!qryXClass_Build.Next())
                        break;
                }

                DlgProgressLog.AddLine(KissMsg.GetMLMessage("FrmDesigner", "BuildComplete", "Build abgeschlossen"));
            }
            catch (CancelledByUserException)
            {
                try
                {
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("FrmDesigner", "BuildAbgebrochen", "Build abgebrochen durch Benutzer/-in"));
                }
                catch { };
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        #endregion

        #endregion
    }
}