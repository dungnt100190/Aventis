using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlIcon.
    /// </summary>
    public class CtlIcon : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _modulID = -1;
        private KissButton btnExportImage;
        private KiSS4.Gui.KissButton btnLoadImage;
        private KissButton btnRefreshIcons;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colXIconID;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
        private KiSS4.Gui.KissCalcEdit edtIconID;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissGrid grdXIcon;
        private DevExpress.XtraGrid.Views.Grid.GridView grvXIcon;
        private KiSS4.Gui.KissLabel lblIcon;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblXIconID;
        private Panel panDetails;
        private System.Windows.Forms.PictureBox picIconLarge;
        private System.Windows.Forms.PictureBox picIconSmall;
        private KiSS4.DB.SqlQuery qryXIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repIconImageCbo;
        private ToolTip ttpToolTip;

        #endregion

        #endregion

        #region Constructors

        public CtlIcon()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //this.grdXIcon.View.Images = Gui.KissImageList.SmallImageList;

            // init combo
            this.repIconImageCbo.NullText = " ";
            InitRepositoryItem();
        }

        public CtlIcon(int modulID)
            : this()
        {
            this._modulID = modulID;

            if (modulID == 0)
            {
                // load only system icons
                this.qryXIcon.SelectStatement = @"
                    SELECT ICO.*
                    FROM dbo.XIcon ICO WITH (READUNCOMMITTED)
                    WHERE ICO.XIconID < 1000";
            }
            else
            {
                // load only modul specific icons
                this.qryXIcon.SelectStatement = @"
                    SELECT ICO.*
                    FROM dbo.XIcon ICO WITH (READUNCOMMITTED)
                    WHERE ICO.XIconID BETWEEN 1000 + (100 * {0}) AND 1099 + (100 * {0})";
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
            this.grdXIcon = new KiSS4.Gui.KissGrid();
            this.qryXIcon = new KiSS4.DB.SqlQuery(this.components);
            this.grvXIcon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repIconImageCbo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colXIconID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblXIconID = new KiSS4.Gui.KissLabel();
            this.edtIconID = new KiSS4.Gui.KissCalcEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.btnLoadImage = new KiSS4.Gui.KissButton();
            this.picIconLarge = new System.Windows.Forms.PictureBox();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.picIconSmall = new System.Windows.Forms.PictureBox();
            this.lblIcon = new KiSS4.Gui.KissLabel();
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnRefreshIcons = new KiSS4.Gui.KissButton();
            this.btnExportImage = new KiSS4.Gui.KissButton();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ttpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdXIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIconImageCbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXIconID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIconID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).BeginInit();
            this.panDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // grdXIcon
            //
            this.grdXIcon.DataSource = this.qryXIcon;
            this.grdXIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXIcon.EmbeddedNavigator.Name = "";
            this.grdXIcon.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXIcon.Location = new System.Drawing.Point(0, 0);
            this.grdXIcon.MainView = this.grvXIcon;
            this.grdXIcon.Name = "grdXIcon";
            this.grdXIcon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repIconImageCbo});
            this.grdXIcon.Size = new System.Drawing.Size(792, 381);
            this.grdXIcon.TabIndex = 0;
            this.grdXIcon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXIcon});
            //
            // qryXIcon
            //
            this.qryXIcon.CanDelete = true;
            this.qryXIcon.CanInsert = true;
            this.qryXIcon.CanUpdate = true;
            this.qryXIcon.HostControl = this;
            this.qryXIcon.TableName = "XIcon";
            this.qryXIcon.BeforePost += new System.EventHandler(this.qryIcon_BeforePost);
            this.qryXIcon.PositionChanged += new System.EventHandler(this.qryIcon_PositionChanged);
            //
            // grvXIcon
            //
            this.grvXIcon.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvXIcon.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.Empty.Options.UseBackColor = true;
            this.grvXIcon.Appearance.Empty.Options.UseFont = true;
            this.grvXIcon.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.EvenRow.Options.UseFont = true;
            this.grvXIcon.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXIcon.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvXIcon.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvXIcon.Appearance.FocusedCell.Options.UseFont = true;
            this.grvXIcon.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvXIcon.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvXIcon.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvXIcon.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvXIcon.Appearance.FocusedRow.Options.UseFont = true;
            this.grvXIcon.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvXIcon.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXIcon.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvXIcon.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvXIcon.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXIcon.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXIcon.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvXIcon.Appearance.GroupRow.Options.UseFont = true;
            this.grvXIcon.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvXIcon.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvXIcon.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvXIcon.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvXIcon.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvXIcon.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvXIcon.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvXIcon.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvXIcon.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvXIcon.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvXIcon.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvXIcon.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvXIcon.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvXIcon.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvXIcon.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.OddRow.Options.UseFont = true;
            this.grvXIcon.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvXIcon.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.Row.Options.UseBackColor = true;
            this.grvXIcon.Appearance.Row.Options.UseFont = true;
            this.grvXIcon.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvXIcon.Appearance.SelectedRow.Options.UseFont = true;
            this.grvXIcon.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvXIcon.Appearance.VertLine.Options.UseBackColor = true;
            this.grvXIcon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvXIcon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIcon,
            this.colXIconID,
            this.colName});
            this.grvXIcon.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvXIcon.GridControl = this.grdXIcon;
            this.grvXIcon.Name = "grvXIcon";
            this.grvXIcon.OptionsBehavior.Editable = false;
            this.grvXIcon.OptionsCustomization.AllowFilter = false;
            this.grvXIcon.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvXIcon.OptionsNavigation.AutoFocusNewRow = true;
            this.grvXIcon.OptionsNavigation.UseTabKey = false;
            this.grvXIcon.OptionsView.ColumnAutoWidth = false;
            this.grvXIcon.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvXIcon.OptionsView.ShowGroupPanel = false;
            this.grvXIcon.OptionsView.ShowIndicator = false;
            //
            // colIcon
            //
            this.colIcon.ColumnEdit = this.repIconImageCbo;
            this.colIcon.FieldName = "XIconID";
            this.colIcon.Name = "colIcon";
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 0;
            this.colIcon.Width = 22;
            //
            // repIconImageCbo
            //
            this.repIconImageCbo.AutoHeight = false;
            this.repIconImageCbo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repIconImageCbo.Name = "repIconImageCbo";
            //
            // colXIconID
            //
            this.colXIconID.Caption = "ID";
            this.colXIconID.FieldName = "XIconID";
            this.colXIconID.Name = "colXIconID";
            this.colXIconID.Visible = true;
            this.colXIconID.VisibleIndex = 1;
            this.colXIconID.Width = 98;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 505;
            //
            // lblXIconID
            //
            this.lblXIconID.Location = new System.Drawing.Point(9, 9);
            this.lblXIconID.Name = "lblXIconID";
            this.lblXIconID.Size = new System.Drawing.Size(100, 23);
            this.lblXIconID.TabIndex = 0;
            this.lblXIconID.Text = "ID";
            //
            // edtIconID
            //
            this.edtIconID.DataMember = "XIconID";
            this.edtIconID.DataSource = this.qryXIcon;
            this.edtIconID.Location = new System.Drawing.Point(115, 9);
            this.edtIconID.Name = "edtIconID";
            this.edtIconID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIconID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIconID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIconID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIconID.Properties.Appearance.Options.UseBackColor = true;
            this.edtIconID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIconID.Properties.Appearance.Options.UseFont = true;
            this.edtIconID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIconID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIconID.Size = new System.Drawing.Size(80, 24);
            this.edtIconID.TabIndex = 1;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(9, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            //
            // edtName
            //
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryXIcon;
            this.edtName.Location = new System.Drawing.Point(115, 39);
            this.edtName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(668, 24);
            this.edtName.TabIndex = 3;
            //
            // btnLoadImage
            //
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.Image = global::KiSS4.DesignerHost.Properties.Resources.OpenFile;
            this.btnLoadImage.Location = new System.Drawing.Point(184, 77);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btnLoadImage.Size = new System.Drawing.Size(24, 24);
            this.btnLoadImage.TabIndex = 5;
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            //
            // picIconLarge
            //
            this.picIconLarge.BackColor = System.Drawing.Color.White;
            this.picIconLarge.Location = new System.Drawing.Point(137, 69);
            this.picIconLarge.Name = "picIconLarge";
            this.picIconLarge.Size = new System.Drawing.Size(32, 32);
            this.picIconLarge.TabIndex = 6;
            this.picIconLarge.TabStop = false;
            //
            // dlgOpenFile
            //
            this.dlgOpenFile.Filter = "Icon (*.ico)|*.ico|Alle Dateien|*.*";
            //
            // picIconSmall
            //
            this.picIconSmall.BackColor = System.Drawing.Color.White;
            this.picIconSmall.Location = new System.Drawing.Point(115, 85);
            this.picIconSmall.Name = "picIconSmall";
            this.picIconSmall.Size = new System.Drawing.Size(16, 16);
            this.picIconSmall.TabIndex = 7;
            this.picIconSmall.TabStop = false;
            //
            // lblIcon
            //
            this.lblIcon.Location = new System.Drawing.Point(9, 78);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(100, 23);
            this.lblIcon.TabIndex = 4;
            this.lblIcon.Text = "Icon";
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.lblXIconID);
            this.panDetails.Controls.Add(this.lblIcon);
            this.panDetails.Controls.Add(this.edtIconID);
            this.panDetails.Controls.Add(this.picIconSmall);
            this.panDetails.Controls.Add(this.lblName);
            this.panDetails.Controls.Add(this.picIconLarge);
            this.panDetails.Controls.Add(this.edtName);
            this.panDetails.Controls.Add(this.btnRefreshIcons);
            this.panDetails.Controls.Add(this.btnExportImage);
            this.panDetails.Controls.Add(this.btnLoadImage);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 381);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(792, 115);
            this.panDetails.TabIndex = 1;
            //
            // btnRefreshIcons
            //
            this.btnRefreshIcons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshIcons.Image = global::KiSS4.DesignerHost.Properties.Resources._0114_Refresh;
            this.btnRefreshIcons.Location = new System.Drawing.Point(253, 77);
            this.btnRefreshIcons.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.btnRefreshIcons.Name = "btnRefreshIcons";
            this.btnRefreshIcons.Padding = new System.Windows.Forms.Padding(0, 0, 3, 1);
            this.btnRefreshIcons.Size = new System.Drawing.Size(24, 24);
            this.btnRefreshIcons.TabIndex = 7;
            this.btnRefreshIcons.UseVisualStyleBackColor = false;
            this.btnRefreshIcons.Click += new System.EventHandler(this.btnRefreshIcons_Click);
            //
            // btnExportImage
            //
            this.btnExportImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportImage.Image = global::KiSS4.DesignerHost.Properties.Resources._0051_Save;
            this.btnExportImage.Location = new System.Drawing.Point(214, 77);
            this.btnExportImage.Name = "btnExportImage";
            this.btnExportImage.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btnExportImage.Size = new System.Drawing.Size(24, 24);
            this.btnExportImage.TabIndex = 6;
            this.btnExportImage.UseVisualStyleBackColor = false;
            this.btnExportImage.Click += new System.EventHandler(this.btnExportImage_Click);
            //
            // dlgSaveFile
            //
            this.dlgSaveFile.Filter = "Icon (*.ico)|*.ico|Alle Dateien|*.*";
            //
            // CtlIcon
            //
            this.ActiveSQLQuery = this.qryXIcon;
            this.Controls.Add(this.grdXIcon);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlIcon";
            this.Size = new System.Drawing.Size(792, 496);
            this.Load += new System.EventHandler(this.CtlIcon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdXIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvXIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIconImageCbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXIconID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIconID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).EndInit();
            this.panDetails.ResumeLayout(false);
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

        private void CtlIcon_Load(object sender, System.EventArgs e)
        {
            // setup title and filter of dialogs
            dlgOpenFile.Title = KissMsg.GetMLMessage("CtlModul", "ImportIconDialogTitle_v01", "Zu importierendes Icon auswählen");
            dlgOpenFile.Filter = string.Format("{0} (*.ico)|*.ico|{1} (*.*)|*.*", KissMsg.GetMLMessage("CtlIcon", "FilterIcons", "Icon Dateien"), KissMsg.GetMLMessage("CtlIcon", "FilterAllFiles", "Alle Dateien"));

            dlgSaveFile.Title = KissMsg.GetMLMessage("CtlModul", "ExportIconDialogTitle_v01", "Datei speichern unter");
            dlgSaveFile.Filter = dlgOpenFile.Filter;

            // setup tooltips
            ttpToolTip.SetToolTip(btnLoadImage, KissMsg.GetMLMessage("CtlIcon", "ToolTipBtnLoadImage", "Icon importieren"));
            ttpToolTip.SetToolTip(btnExportImage, KissMsg.GetMLMessage("CtlIcon", "ToolTipBtnExportImage", "Icon exportieren"));
            ttpToolTip.SetToolTip(btnRefreshIcons, KissMsg.GetMLMessage("CtlIcon", "ToolTipBtnRefreshIcons", "Icons neu aus der Datenbank laden und Cache aktualisieren"));

            // load data
            this.qryXIcon.Fill(this._modulID);
        }

        private void btnExportImage_Click(object sender, EventArgs e)
        {
            // validate first
            if (DBUtil.IsEmpty(qryXIcon["Icon"]))
            {
                // show message and cancel
                KissMsg.ShowInfo("CtlIcon", "NoIconToSaveToFile", "Es ist kein Icon vorhanden, welches gespeichert werden könnte.");
                return;
            }

            // show dialog to select the release file
            if (dlgSaveFile.ShowDialog(this) == DialogResult.OK)
            {
                // save output to given file
                try
                {
                    // get name and path of file to save
                    string saveFileName = dlgSaveFile.FileName;

                    // save file with given content
                    SaveImage(saveFileName, (byte[])qryXIcon["Icon"]);

                    // check file exists
                    if (!FileExists(saveFileName))
                    {
                        // file not written
                        throw new FileNotFoundException("The output file could not be written, file after save not found.", saveFileName);
                    }
                }
                catch (Exception ex)
                {
                    // failed saving, show message
                    KissMsg.ShowError("CtlIcon", "ErrorSavingImageToFile_v01", "Es ist ein Fehler beim Speichern der Datei aufgetreten.", ex);
                }
            }
        }

        private void btnLoadImage_Click(object sender, System.EventArgs e)
        {
            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                // create binary reader and open file
                BinaryReader br = null;

                try
                {
                    br = new BinaryReader(dlgOpenFile.OpenFile());

                    // read image
                    this.qryXIcon["Icon"] = br.ReadBytes(0xFFFF);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("CtlIcon", "ErrorReadingImage", "Es ist ein Fehler beim Lesen der Bilddatei aufgetreten.", ex);
                }
                finally
                {
                    // check we have an instance of the reader
                    if (br != null)
                    {
                        // close reader and clear instance
                        br.Close();
                        br = null;
                    }
                }

                // apply name of image if none defined yet
                if (DBUtil.IsEmpty(this.edtName.EditValue))
                {
                    this.edtName.EditValue = new FileInfo(dlgOpenFile.FileName).Name;
                }

                // show image
                this.DisplayImage();
            }
        }

        private void btnRefreshIcons_Click(object sender, EventArgs e)
        {
            // check if we can save changes
            if (!qryXIcon.Post())
            {
                // cancel
                return;
            }

            try
            {
                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                // reload images from kissimage-list
                KissImageList.LoadImages();

                // refresh repository item
                InitRepositoryItem();

                // refresh grid
                qryXIcon.Refresh();
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError("CtlIcon", "ErrorRefreshingIconCache", "Es ist ein Fehler beim Aktualisieren der Icons aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void qryIcon_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblName.Text);

            if (DBUtil.IsEmpty(qryXIcon["XIconID"]))
            {
                if (this._modulID == -1)
                {
                    this.qryXIcon["XIconID"] = DBUtil.ExecuteScalarSQL(@"
                        SELECT MAX(XIconID) + 1
                        FROM dbo.XIcon");
                }
                else
                {
                    this.qryXIcon["XIconID"] = DBUtil.ExecuteScalarSQL(@"
                        SELECT MAX(XIconID) + 1
                        FROM dbo.XIcon
                        WHERE XIconID < (1099 + (100 * {0}))", this._modulID);

                    if (DBUtil.IsEmpty(qryXIcon["XIconID"]) || (_modulID > 0 && (int)this.qryXIcon["XIconID"] < (1010 + (100 * _modulID))))
                    {
                        this.qryXIcon["XIconID"] = (1010 + (100 * _modulID));
                    }
                }
            }
        }

        private void qryIcon_PositionChanged(object sender, System.EventArgs e)
        {
            this.DisplayImage();
        }

        #endregion

        #region Methods

        #region Private Static Methods

        /// <summary>
        /// Delete file if existing
        /// </summary>
        /// <param name="filePathName">Path to file including filename and fileending</param>
        /// <returns>Boolean: True if successfully deleted file, else false</returns>
        private static bool DeleteFile(string filePathName)
        {
            // validate string
            if (string.IsNullOrEmpty(filePathName))
            {
                // empty filename
                throw new ArgumentNullException("filePathName", "Invalid filename to delete, cannot delete file without valid name.");
            }

            // check file exist
            if (FileExists(filePathName))
            {
                // remove file
                File.Delete(filePathName);

                // check if success
                if (FileExists(filePathName))
                {
                    // error, could not delete file
                    return false;
                }
                else
                {
                    // success, deleted file
                    return true;
                }
            }
            else
            {
                // success, file does not exist
                return true;
            }
        }

        // <summary>
        /// Check if a specific file does exist
        /// </summary>
        /// <param name="filePathName">The filename including path to check if existing</param>
        /// <returns>True if file exists, false if file does not exist</returns>
        private static bool FileExists(string filePathName)
        {
            // validate first
            filePathName = filePathName.Trim();

            if (string.IsNullOrEmpty(filePathName))
            {
                return false;
            }

            // check if file exists
            return File.Exists(filePathName);
        }

        /// <summary>
        /// Save and overwrite file with given filename
        /// </summary>
        /// <param name="fileName">The filename to use for creating new file</param>
        /// <param name="byteStream">The byte content to write to file</param>
        private static void SaveImage(string fileName, byte[] byteStream)
        {
            // check if file already exists
            if (!DeleteFile(fileName))
            {
                // could not delete file
                throw new InvalidOperationException("File could not be deleted before saving new file.");
            }

            // validate content
            if (byteStream == null || byteStream.Length < 1)
            {
                throw new ArgumentOutOfRangeException("byteStream", byteStream, "Bytestream is invalid, cannot write content to file.");
            }

            // create new stream and writer
            FileStream fs = null;
            BinaryWriter bw = null;

            try
            {
                // create filestream to write new file
                fs = new FileStream(fileName, FileMode.Create);

                // create new instance
                bw = new BinaryWriter(fs);

                // write a line of text to the file
                bw.Write(byteStream);
            }
            catch
            {
                // throw exception further on
                throw;
            }
            finally
            {
                // try to close and release file stream
                if (fs != null)
                {
                    // close the stream and clear instance
                    fs.Close();
                    fs = null;
                }

                // try to close and release binarywriter
                if (bw != null)
                {
                    // close the writer and clear instance
                    bw.Close();
                    bw = null;
                }
            }
        }

        #endregion

        #region Private Methods

        private void DisplayImage()
        {
            // clear images
            this.picIconLarge.Image = null;
            this.picIconSmall.Image = null;

            // check if we have an icon set
            if (this.qryXIcon["Icon"] == DBNull.Value)
            {
                return;
            }

            // get memory stream from icon
            using (MemoryStream ms = new MemoryStream((byte[])this.qryXIcon["Icon"], false))
            {
                try
                {
                    // load icon or bitmap depending on image type
                    switch (KissImageList.GetImageTypeFromMemoryStream(ms))
                    {
                        case KissImageList.ImageType.Icon:
                            // icon style
                            Icon ico = new Icon(ms);

                            this.picIconLarge.Image = KissImageList.ResizeIcon(ico, 32, 32);
                            this.picIconSmall.Image = KissImageList.ResizeIcon(ico, 16, 16);
                            break;

                        case KissImageList.ImageType.Bitmap:
                        case KissImageList.ImageType.Jpg:
                        case KissImageList.ImageType.Gif:
                        case KissImageList.ImageType.Png:
                        case KissImageList.ImageType.Tif:
                            // bitmap style
                            this.picIconLarge.Image = new System.Drawing.Bitmap(ms);
                            break;

                        default:
                            ico = new Icon(ms);
                            break;
                    }
                }
                catch
                {
                    // reset position
                    ms.Position = 0;

                    // load as bitmap
                    this.picIconLarge.Image = new System.Drawing.Bitmap(ms);
                }
            }
        }

        private void InitRepositoryItem()
        {
            // setup repository item with icons
            KissImageList.FillIconsIntoComboBox(repIconImageCbo, true, false);
        }

        #endregion

        #endregion
    }
}