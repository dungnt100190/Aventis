using System;
using System.Collections.Generic;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Favoriten.Controller;
using KiSS4.Favoriten.Interface;
using KiSS4.Favoriten.Model;
using KiSS4.Gui;

using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Favoriten.UI
{
    /// <summary>
    /// Form, used to manage search favorites
    /// </summary>
    public class FavoritesView : KissChildForm
    {
        #region Enumerations

        private enum FavoriteType
        {
            Folder = 0,
            Item = 1,
            ItemAutosearch = 2
        }

        #endregion

        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _deletingNode;
        private bool _displayAllFavorites = true;
        private IDictionary<int, Favorite> _favorites = new Dictionary<int, Favorite>();
        private bool _formLoading;
        private KissButton btnCancel;
        private KissButton btnCollapse;
        private KissButton btnDelete;
        private KissButton btnExpand;
        private KissButton btnMoveDown;
        private KissButton btnMoveUp;
        private KissButton btnNewFolder;
        private KissButton btnOK;
        private KissCheckEdit chkRunSearch;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFavorites;
        private System.ComponentModel.IContainer components;
        private KissLabel lblFavoriteName;
        private Panel panBottom;
        private Panel panButtons;
        private Panel panFill;
        private Panel panTree;
        private Panel panTreeDetails;
        private KissTree treFavorites;
        private ToolTip ttpButtons;
        private KissTextEdit txtFavoriteName;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoritesView"/> class.
        /// </summary>
        public FavoritesView()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // setup controls
            kissDataNavigator.PrefereDetailControl = true;

            // image list to tree
            ImageList imgList = new ImageList();
            imgList.Images.Add(KissImageList.GetSmallImage(Favorite.FOLDER_XICONID));               // folder
            imgList.Images.Add(KissImageList.GetSmallImage(Favorite.ITEM_XICONID));                 // item
            imgList.Images.Add(KissImageList.GetSmallImage(Favorite.ITEM_XICONID_AUTOSEARCH));      // item with autosearch
            treFavorites.SelectImageList = imgList;

            // add tooltips
            ttpButtons.SetToolTip(btnMoveUp, KissMsg.GetMLMessage(this.Name, "ToolTipMoveUp", "Favorit nach oben bewegen"));
            ttpButtons.SetToolTip(btnMoveDown, KissMsg.GetMLMessage(this.Name, "ToolTipMoveDown", "Favorit nach unten bewegen"));
            ttpButtons.SetToolTip(btnNewFolder, KissMsg.GetMLMessage(this.Name, "ToolTipNewFolder", "Neuer Ordner erstellen"));
            ttpButtons.SetToolTip(btnDelete, KissMsg.GetMLMessage(this.Name, "ToolTipDelete", "Favorit löschen"));
            ttpButtons.SetToolTip(btnExpand, KissMsg.GetMLMessage(this.Name, "ToolTipExpand", "Alle Einträge erweitern"));
            ttpButtons.SetToolTip(btnCollapse, KissMsg.GetMLMessage(this.Name, "ToolTipCollapse", "Alle Einträge reduzieren"));
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
            this.panFill = new System.Windows.Forms.Panel();
            this.panTree = new System.Windows.Forms.Panel();
            this.treFavorites = new KiSS4.Gui.KissTree();
            this.colFavorites = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panTreeDetails = new System.Windows.Forms.Panel();
            this.chkRunSearch = new KiSS4.Gui.KissCheckEdit();
            this.lblFavoriteName = new KiSS4.Gui.KissLabel();
            this.txtFavoriteName = new KiSS4.Gui.KissTextEdit();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnNewFolder = new KiSS4.Gui.KissButton();
            this.btnCollapse = new KiSS4.Gui.KissButton();
            this.btnExpand = new KiSS4.Gui.KissButton();
            this.btnDelete = new KiSS4.Gui.KissButton();
            this.btnMoveDown = new KiSS4.Gui.KissButton();
            this.btnMoveUp = new KiSS4.Gui.KissButton();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.ttpButtons = new System.Windows.Forms.ToolTip(this.components);
            this.panFill.SuspendLayout();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treFavorites)).BeginInit();
            this.panTreeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRunSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFavoriteName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFavoriteName.Properties)).BeginInit();
            this.panButtons.SuspendLayout();
            this.panBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // panFill
            //
            this.panFill.Controls.Add(this.panTree);
            this.panFill.Controls.Add(this.panTreeDetails);
            this.panFill.Controls.Add(this.panButtons);
            this.panFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panFill.Location = new System.Drawing.Point(0, 0);
            this.panFill.Name = "panFill";
            this.panFill.Size = new System.Drawing.Size(592, 426);
            this.panFill.TabIndex = 0;
            //
            // panTree
            //
            this.panTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTree.Controls.Add(this.treFavorites);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Padding = new System.Windows.Forms.Padding(1);
            this.panTree.Size = new System.Drawing.Size(545, 362);
            this.panTree.TabIndex = 0;
            //
            // treFavorites
            //
            this.treFavorites.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treFavorites.Appearance.Empty.Options.UseBackColor = true;
            this.treFavorites.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treFavorites.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.EvenRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.EvenRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treFavorites.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treFavorites.Appearance.FooterPanel.Options.UseFont = true;
            this.treFavorites.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treFavorites.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treFavorites.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treFavorites.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.GroupButton.Options.UseBackColor = true;
            this.treFavorites.Appearance.GroupButton.Options.UseFont = true;
            this.treFavorites.Appearance.GroupButton.Options.UseForeColor = true;
            this.treFavorites.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treFavorites.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treFavorites.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treFavorites.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treFavorites.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treFavorites.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treFavorites.Appearance.HeaderPanel.Options.UseFont = true;
            this.treFavorites.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treFavorites.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treFavorites.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treFavorites.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treFavorites.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treFavorites.Appearance.HorzLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.HorzLine.Options.UseForeColor = true;
            this.treFavorites.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treFavorites.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.OddRow.Options.UseBackColor = true;
            this.treFavorites.Appearance.OddRow.Options.UseFont = true;
            this.treFavorites.Appearance.OddRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treFavorites.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.Preview.Options.UseBackColor = true;
            this.treFavorites.Appearance.Preview.Options.UseFont = true;
            this.treFavorites.Appearance.Preview.Options.UseForeColor = true;
            this.treFavorites.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treFavorites.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treFavorites.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treFavorites.Appearance.Row.Options.UseBackColor = true;
            this.treFavorites.Appearance.Row.Options.UseFont = true;
            this.treFavorites.Appearance.Row.Options.UseForeColor = true;
            this.treFavorites.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treFavorites.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treFavorites.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treFavorites.Appearance.TreeLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treFavorites.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treFavorites.Appearance.VertLine.Options.UseBackColor = true;
            this.treFavorites.Appearance.VertLine.Options.UseForeColor = true;
            this.treFavorites.Appearance.VertLine.Options.UseTextOptions = true;
            this.treFavorites.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treFavorites.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treFavorites.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFavorites});
            this.treFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treFavorites.ImageIndexFieldName = "IconID";
            this.treFavorites.KeyFieldName = "";
            this.treFavorites.Location = new System.Drawing.Point(1, 1);
            this.treFavorites.Name = "treFavorites";
            this.treFavorites.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treFavorites.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treFavorites.OptionsBehavior.Editable = false;
            this.treFavorites.OptionsBehavior.KeepSelectedOnClick = false;
            this.treFavorites.OptionsBehavior.MoveOnEdit = false;
            this.treFavorites.OptionsBehavior.ShowToolTips = false;
            this.treFavorites.OptionsBehavior.SmartMouseHover = false;
            this.treFavorites.OptionsMenu.EnableColumnMenu = false;
            this.treFavorites.OptionsMenu.EnableFooterMenu = false;
            this.treFavorites.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treFavorites.OptionsView.AutoWidth = false;
            this.treFavorites.OptionsView.EnableAppearanceEvenRow = true;
            this.treFavorites.OptionsView.EnableAppearanceOddRow = true;
            this.treFavorites.OptionsView.ShowIndicator = false;
            this.treFavorites.OptionsView.ShowVertLines = false;
            this.treFavorites.ParentFieldName = "";
            this.treFavorites.RootValue = "-1";
            this.treFavorites.Size = new System.Drawing.Size(541, 358);
            this.treFavorites.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treFavorites.TabIndex = 0;
            this.treFavorites.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treFavorites_BeforeFocusNode);
            //
            // colFavorites
            //
            this.colFavorites.Caption = "Favoriten";
            this.colFavorites.FieldName = "Caption";
            this.colFavorites.MinWidth = 27;
            this.colFavorites.Name = "colFavorites";
            this.colFavorites.OptionsColumn.AllowSort = false;
            this.colFavorites.VisibleIndex = 0;
            this.colFavorites.Width = 400;
            //
            // panTreeDetails
            //
            this.panTreeDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTreeDetails.Controls.Add(this.chkRunSearch);
            this.panTreeDetails.Controls.Add(this.lblFavoriteName);
            this.panTreeDetails.Controls.Add(this.txtFavoriteName);
            this.panTreeDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTreeDetails.Location = new System.Drawing.Point(0, 362);
            this.panTreeDetails.Name = "panTreeDetails";
            this.panTreeDetails.Size = new System.Drawing.Size(545, 64);
            this.panTreeDetails.TabIndex = 1;
            //
            // chkRunSearch
            //
            this.chkRunSearch.EditValue = false;
            this.chkRunSearch.Location = new System.Drawing.Point(117, 39);
            this.chkRunSearch.Name = "chkRunSearch";
            this.chkRunSearch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkRunSearch.Properties.Appearance.Options.UseBackColor = true;
            this.chkRunSearch.Properties.Caption = "  Suche sofort ausführen";
            this.chkRunSearch.Size = new System.Drawing.Size(226, 19);
            this.chkRunSearch.TabIndex = 2;
            //
            // lblFavoriteName
            //
            this.lblFavoriteName.Location = new System.Drawing.Point(9, 9);
            this.lblFavoriteName.Margin = new System.Windows.Forms.Padding(9, 9, 3, 0);
            this.lblFavoriteName.Name = "lblFavoriteName";
            this.lblFavoriteName.Size = new System.Drawing.Size(102, 24);
            this.lblFavoriteName.TabIndex = 0;
            this.lblFavoriteName.Text = "Favorit Name";
            //
            // txtFavoriteName
            //
            this.txtFavoriteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFavoriteName.Location = new System.Drawing.Point(117, 9);
            this.txtFavoriteName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.txtFavoriteName.Name = "txtFavoriteName";
            this.txtFavoriteName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFavoriteName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtFavoriteName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtFavoriteName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFavoriteName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtFavoriteName.Properties.Appearance.Options.UseFont = true;
            this.txtFavoriteName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFavoriteName.Size = new System.Drawing.Size(414, 24);
            this.txtFavoriteName.TabIndex = 1;
            //
            // panButtons
            //
            this.panButtons.AutoScroll = true;
            this.panButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panButtons.Controls.Add(this.btnNewFolder);
            this.panButtons.Controls.Add(this.btnCollapse);
            this.panButtons.Controls.Add(this.btnExpand);
            this.panButtons.Controls.Add(this.btnDelete);
            this.panButtons.Controls.Add(this.btnMoveDown);
            this.panButtons.Controls.Add(this.btnMoveUp);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panButtons.Location = new System.Drawing.Point(545, 0);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(47, 426);
            this.panButtons.TabIndex = 2;
            //
            // btnNewFolder
            //
            this.btnNewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewFolder.IconID = 166;
            this.btnNewFolder.Location = new System.Drawing.Point(9, 287);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(28, 24);
            this.btnNewFolder.TabIndex = 3;
            this.btnNewFolder.UseVisualStyleBackColor = false;
            this.btnNewFolder.Visible = false;
            //
            // btnCollapse
            //
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Image = global::KiSS4.Favoriten.Properties.Resources.collapse;
            this.btnCollapse.Location = new System.Drawing.Point(9, 389);
            this.btnCollapse.Margin = new System.Windows.Forms.Padding(9, 3, 9, 9);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(28, 24);
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            //
            // btnExpand
            //
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Image = global::KiSS4.Favoriten.Properties.Resources.expand;
            this.btnExpand.Location = new System.Drawing.Point(9, 359);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(28, 24);
            this.btnExpand.TabIndex = 1;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.IconID = 4;
            this.btnDelete.Location = new System.Drawing.Point(9, 323);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 24);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnMoveDown
            //
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.IconID = 17;
            this.btnMoveDown.Location = new System.Drawing.Point(9, 39);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(28, 24);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Visible = false;
            //
            // btnMoveUp
            //
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.IconID = 16;
            this.btnMoveUp.Location = new System.Drawing.Point(9, 9);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(28, 24);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Visible = false;
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnCancel);
            this.panBottom.Controls.Add(this.btnOK);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 426);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(592, 43);
            this.panBottom.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(483, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(377, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // FavoritesView
            //
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(592, 469);
            this.Controls.Add(this.panFill);
            this.Controls.Add(this.panBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "FavoritesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Favoritenverwaltung";
            this.Load += new System.EventHandler(this.FavoritesView_Load);
            this.Activated += new System.EventHandler(this.FavoritesView_Activated);
            this.panFill.ResumeLayout(false);
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treFavorites)).EndInit();
            this.panTreeDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkRunSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFavoriteName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFavoriteName.Properties)).EndInit();
            this.panButtons.ResumeLayout(false);
            this.panBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Set flag to display all favorites
        /// </summary>
        public bool DisplayAllFavorites
        {
            set { _displayAllFavorites = value; }
        }

        /// <summary>
        /// Set favorites
        /// </summary>
        public IDictionary<int, Favorite> Favorites
        {
            set { _favorites = value; }
        }

        #endregion

        #region EventHandlers

        private void FavoritesView_Activated(object sender, EventArgs e)
        {
            txtFavoriteName.Focus();
        }

        private void FavoritesView_Load(object sender, EventArgs e)
        {
            try
            {
                _formLoading = true;

                TreeListNode nodeToFocus = null;
                TreeListNode rootNode = null;
                Favorite previousFavorite = null;

                foreach (Favorite favorite in _favorites.Values)
                {
                    // setup icon
                    FavoriteType iconId = favorite.ClassName != null ? FavoriteType.Item : FavoriteType.Folder;

                    if (iconId == FavoriteType.Item)
                    {
                        // set item or autosearch item
                        iconId = favorite.SearchImmediately ? FavoriteType.ItemAutosearch : iconId;
                    }

                    // create new node
                    TreeListNode newNode;

                    // check if need to display folder structure
                    if (_displayAllFavorites)
                    {
                        // check if we already have a root node
                        if (rootNode == null)
                        {
                            // create and setup root node
                            rootNode = CreateTreeNode(favorite.ClassUserText, FavoriteType.Folder);
                        }
                        else if (favorite.ClassName != null && previousFavorite != null)
                        {
                            if (favorite.ClassName.Equals(previousFavorite.ClassName) == false)
                            {
                                rootNode = CreateTreeNode(favorite.ClassUserText, FavoriteType.Folder);
                            }
                        }
                    }

                    if (rootNode != null)
                    {
                        newNode = CreateTreeNode(favorite.Name, iconId, rootNode.Id);
                    }
                    else
                    {
                        newNode = CreateTreeNode(favorite.Name, iconId);
                    }

                    newNode.Tag = favorite;

                    if (favorite.SetFocus)
                    {
                        if (_favorites.Count == 1)
                        {
                            favorite.SortKey = 0;
                            favorite.XSearchControlTemplateId = -1;
                            nodeToFocus = newNode;
                        }
                        else
                        {
                            treFavorites.Text = _favorites[0].ClassUserText;
                            favorite.SortKey = _favorites.Count;
                            favorite.XSearchControlTemplateId = favorite.SortKey * -1;
                            nodeToFocus = newNode;
                        }
                    }

                    previousFavorite = favorite;
                } // [foreach]

                // show all nodes if not showing all favorites
                if (!_displayAllFavorites)
                {
                    treFavorites.ExpandAll();
                }

                if (nodeToFocus != null)
                {
                    treFavorites.Columns[0].Caption = ((Favorite)nodeToFocus.Tag).ClassUserText;
                    chkRunSearch.Enabled = true;
                    chkRunSearch.Checked = ((Favorite)nodeToFocus.Tag).SearchImmediately;

                    treFavorites.SetFocusedNode(nodeToFocus);

                    ////////UpdateMoveUpButtonStatus(nodeToFocus);
                    ////////UpdateMoveDownButtonStatus(nodeToFocus);
                }
                else
                {
                    if (treFavorites.Nodes != null && treFavorites.Nodes.Count > 0)
                    {
                        if (treFavorites.Nodes.Count > 1)
                        {
                            ////////UpdateMoveUpButtonStatus(_treeFavorites.Nodes[0]);
                            ////////UpdateMoveDownButtonStatus(_treeFavorites.Nodes[0]);
                        }
                        else
                        {
                            btnMoveUp.Enabled = false;
                            btnMoveDown.Enabled = false;
                        }

                        txtFavoriteName.Text = treFavorites.Selection[0].GetValue(@"Caption").ToString();
                        Favorite favorite = (Favorite)treFavorites.Selection[0].Tag;

                        if (favorite != null && !string.IsNullOrEmpty(favorite.ClassName))
                        {
                            btnDelete.Enabled = true;
                            txtFavoriteName.Enabled = true;
                            chkRunSearch.Enabled = true;
                            chkRunSearch.Checked = ((Favorite)treFavorites.Selection[0].Tag).SearchImmediately;
                        }
                        else
                        {
                            btnDelete.Enabled = false;
                            txtFavoriteName.Enabled = false;
                            chkRunSearch.Enabled = false;
                            chkRunSearch.Checked = false;
                        }
                    }
                    else
                    {
                        btnMoveUp.Enabled = false;
                        btnMoveDown.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorLoadingForm", "Es ist ein Fehler beim Laden des Fensters aufgetreten.", ex);
            }
            finally
            {
                // setup tree
                treFavorites.BestFitColumns(true);

                _formLoading = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if (!ApplyNewFavoriteName())
            {
                // failed applying new name, cancel collapsing
                return;
            }

            // set focus to parent (if any)
            if (treFavorites.FocusedNode != null && treFavorites.Nodes.Count > 0)
            {
                // select root node (otherwise if childnode is selected, the childnode gets the name of its parent)
                treFavorites.FocusedNode = treFavorites.FocusedNode.RootNode;

                // collapse
                treFavorites.CollapseAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _deletingNode = true;

                if (treFavorites.Selection != null && treFavorites.Selection.Count > 0)
                {
                    Favorite selectedFavorite = (Favorite)treFavorites.Selection[0].Tag;
                    selectedFavorite.HasBeenDeleted = true;

                    // Look for relevant child nodes that also need to be marked as deleted.
                    foreach (Favorite favorite in _favorites.Values)
                    {
                        if (favorite.ParentXSearchControlTemplateId == selectedFavorite.XSearchControlTemplateId)
                        {
                            favorite.HasBeenDeleted = true;
                        }
                    }

                    TreeListNode nodeToDelete = treFavorites.Selection[0];

                    // Sets the focus to the first node.
                    if (treFavorites.Nodes != null && treFavorites.Nodes.Count > 1)
                    {
                        treFavorites.SetFocusedNode(treFavorites.Nodes[0]);
                    }
                    else
                    {
                        // Resets the GUI controls to default values;
                        txtFavoriteName.Text = string.Empty;
                        chkRunSearch.Checked = false;
                    }

                    // Remove the selected node.
                    treFavorites.DeleteNode(nodeToDelete);

                    // Re-assign the "SortKey" to all the relevant items in the collection.
                    int count = 0;
                    ReApplySortKeys(ref count, treFavorites.Nodes);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorDeleteFavorite", "Es ist ein Fehler beim Löschen eines Favoriten aufgetreten.", ex);
            }
            finally
            {
                _deletingNode = false;
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            treFavorites.ExpandAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ApplyNewFavoriteName())
            {
                int count = 0;
                ReApplySortKeys(ref count, treFavorites.Nodes);

                SaveFavorites();
                Close();
            }
        }

        private void treFavorites_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (!ApplyNewFavoriteName())
            {
                // failed applying new name, cancel changing focus
                e.CanFocus = false;
                return;
            }

            try
            {
                // setup cursor
                Cursor = Cursors.WaitCursor;

                if (e.Node != null)
                {
                    // Sets the textbox to the caption's value of the selected node.
                    if (e.Node.GetValue(@"Caption") != null)
                    {
                        txtFavoriteName.Text = e.Node.GetValue(@"Caption").ToString();
                        btnDelete.Enabled = false;
                    }

                    Favorite favorite = (Favorite)e.Node.Tag;

                    if (favorite != null && !string.IsNullOrEmpty(favorite.ClassName))
                    {
                        btnDelete.Enabled = true;
                        txtFavoriteName.Enabled = true;
                        chkRunSearch.Enabled = true;
                        chkRunSearch.Checked = ((Favorite)e.Node.Tag).SearchImmediately;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        txtFavoriteName.Enabled = false;
                        chkRunSearch.Enabled = false;
                        chkRunSearch.Checked = false;
                    }

                    ////////UpdateMoveUpButtonStatus(e.Node);
                    ////////UpdateMoveDownButtonStatus(e.Node);
                }
                else
                {
                    btnDelete.Enabled = false;
                }

                // setup cursor
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _logger.ErrorFormat("Error in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, "Error in BeforeFocusNode of treFavorites occured.", ex.Message);

                KissMsg.ShowError(this.Name, "ErrorFocusNode", "Es ist ein Fehler beim Auswählen aufgetreten.", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool ApplyNewFavoriteName()
        {
            try
            {
                if (_deletingNode == false && _formLoading == false)
                {
                    if (treFavorites.Nodes != null && treFavorites.Selection != null && treFavorites.Selection[0] != null)
                    {
                        // validate name
                        DBUtil.CheckNotNullField(txtFavoriteName, lblFavoriteName.Text);

                        string newNodeCaption = txtFavoriteName.Text;
                        Favorite favorite = (Favorite)treFavorites.Selection[0].Tag;

                        if (favorite != null)
                        {
                            favorite.Name = newNodeCaption;
                            favorite.SearchImmediately = chkRunSearch.Checked;
                            favorite.HasBeenModified = true;

                            treFavorites.Selection[0].SetValue(@"Caption", newNodeCaption);
                        }
                    }
                }

                return true;
            }
            catch (KissInfoException ex)
            {
                // show info message
                ex.ShowMessage();
                return false;
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(this.Name, "ErrorSavingData", "Es ist ein Fehler beim Speichern der Daten aufgetreten.", ex);
                return false;
            }
        }

        private TreeListNode CreateTreeNode(string caption, FavoriteType imageType)
        {
            return CreateTreeNode(caption, imageType, -1);
        }

        private TreeListNode CreateTreeNode(string caption, FavoriteType imageType, int parentNodeId)
        {
            // create node
            TreeListNode node = treFavorites.AppendNode(null, parentNodeId);
            int imageIndex = Convert.ToInt32(imageType);

            // setup node
            node.ImageIndex = imageIndex;
            node.SelectImageIndex = imageIndex;
            node.SetValue(@"Caption", caption);

            // return node
            return node;
        }

        private void ReApplySortKeys(ref int overallCount, TreeListNodes nodes)
        {
            for (int count = 0; count < nodes.Count; count++)
            {
                Favorite favorite = (Favorite)nodes[count].Tag;

                if (favorite != null)
                {
                    favorite.HasBeenModified = true;
                    favorite.SortKey = overallCount;
                }

                if (nodes[count].LastNode != null)
                {
                    if (favorite != null)
                    {
                        overallCount++;
                        ReApplySortKeys(ref overallCount, nodes[count].Nodes);
                        overallCount--;
                    }
                    else
                    {
                        ReApplySortKeys(ref overallCount, nodes[count].Nodes);
                    }
                }

                if (favorite != null)
                {
                    if (nodes[count].ParentNode != null)
                    {
                        Favorite parentFavorite = (Favorite)nodes[count].ParentNode.Tag;
                        if (parentFavorite != null)
                        {
                            favorite.ParentXSearchControlTemplateId = parentFavorite.XSearchControlTemplateId;
                        }
                    }
                    else
                    {
                        favorite.ParentXSearchControlTemplateId = null;
                    }

                    overallCount++;
                }
            }
        }

        private void SaveFavorites()
        {
            try
            {
                FavoriteController controller = new FavoriteController();
                IResult result = controller.Save(_favorites, Session.User.UserID);

                // validate
                if (!result.WasOperationSuccessful)
                {
                    // failed
                    throw new InvalidOperationException("Failed save operation on favorite controller.");
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "SaveFavorites_v01", "Es ist ein Fehler beim Speichern der Favoriten aufgetreten.", ex);
            }
        }

        #endregion

        #endregion
    }
}