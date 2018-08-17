using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissTree.
    /// </summary>
    public class KissTree : DevExpress.XtraTreeList.TreeList
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private bool _allowSortTree; // flag to allow sorting tree globaly for all columns
        private Dictionary<TreeListColumn, bool> _columnsDefaultSortBehaviour;
        private ArrayList _expandedNodes = new ArrayList();
        private int _lastTopVisibleNodeIndex = -1;
        private object _saveFocusedNode;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissTree"/> class.
        /// </summary>
        public KissTree()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // apply default properties
            AllowSortTree = true;

            // apply default layout
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                LookAndFeel.UseDefaultLookAndFeel = false;
                LookAndFeel.Style = LookAndFeelStyle.UltraFlat;
            }

            OptionsView.EnableAppearanceEvenRow = true;
            OptionsView.EnableAppearanceOddRow = true;
            Appearance.OddRow.BackColor = GuiConfig.colBack04; // Color.FromArgb(236, 227, 215);
            Appearance.EvenRow.BackColor = GuiConfig.colBack05; // Color.FromArgb(242, 236, 215);
            Appearance.HorzLine.BackColor = GuiConfig.colBack06; // Color.FromArgb(230, 216, 174);
            Appearance.TreeLine.BackColor = Color.Gray;
            Appearance.TreeLine.Options.UseBackColor = true;
            TreeLineStyle = LineStyle.Percent50;
            OptionsView.ShowIndicator = false;

            // the following three members get a design-time default.
            ImageIndexFieldName = "IconID";
            KeyFieldName = "ID"; // don't enforce this at runtime, DB-field not always called "ID".
            ParentFieldName = "ParentID";
        }

        public void Recolor()
        {
            Appearance.OddRow.BackColor = GuiConfig.colBack03; // Color.FromArgb(236, 227, 215);
            Appearance.EvenRow.BackColor = GuiConfig.colBack04; // Color.FromArgb(242, 236, 215);
            Appearance.HorzLine.BackColor = GuiConfig.colBack02; // Color.FromArgb(230, 216, 174);
            Appearance.Empty.BackColor = GuiConfig.PanelColor; // System.Drawing.Color.Transparent;
            Appearance.HeaderPanel.BackColor = GuiConfig.colBack06; // System.Drawing.Color.Tan;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            //
            // KissTree
            //
            this.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Empty.Options.UseBackColor = true;
            this.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.Appearance.EvenRow.Options.UseBackColor = true;
            this.Appearance.EvenRow.Options.UseForeColor = true;
            this.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.Appearance.FooterPanel.Options.UseBackColor = true;
            this.Appearance.FooterPanel.Options.UseFont = true;
            this.Appearance.FooterPanel.Options.UseForeColor = true;
            this.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.Appearance.GroupButton.Options.UseBackColor = true;
            this.Appearance.GroupButton.Options.UseFont = true;
            this.Appearance.GroupButton.Options.UseForeColor = true;
            this.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.Appearance.GroupFooter.Options.UseBackColor = true;
            this.Appearance.GroupFooter.Options.UseForeColor = true;
            this.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.Appearance.HeaderPanel.Options.UseFont = true;
            this.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.Appearance.HideSelectionRow.Options.UseFont = true;
            this.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.Appearance.HorzLine.Options.UseBackColor = true;
            this.Appearance.HorzLine.Options.UseForeColor = true;
            this.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.Appearance.OddRow.Options.UseBackColor = true;
            this.Appearance.OddRow.Options.UseFont = true;
            this.Appearance.OddRow.Options.UseForeColor = true;
            this.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Preview.Options.UseBackColor = true;
            this.Appearance.Preview.Options.UseFont = true;
            this.Appearance.Preview.Options.UseForeColor = true;
            this.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Row.Options.UseBackColor = true;
            this.Appearance.Row.Options.UseFont = true;
            this.Appearance.Row.Options.UseForeColor = true;
            this.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.Appearance.SelectedRow.Options.UseForeColor = true;
            this.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.Appearance.TreeLine.Options.UseBackColor = true;
            this.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.Appearance.VertLine.Options.UseBackColor = true;
            this.Appearance.VertLine.Options.UseForeColor = true;
            this.Appearance.VertLine.Options.UseTextOptions = true;
            this.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.OptionsBehavior.AutoSelectAllInEditor = false;
            this.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.OptionsBehavior.Editable = false;
            this.OptionsBehavior.KeepSelectedOnClick = false;
            this.OptionsBehavior.MoveOnEdit = false;
            this.OptionsMenu.EnableColumnMenu = false;
            this.OptionsMenu.EnableFooterMenu = false;
            this.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.OptionsView.AutoWidth = false;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

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

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate required as a parameter to findNode. You must implement your own method
        /// that complies with the signature of this delegate and pass that method reference
        /// as the second parameter of findNode
        /// </summary>
        public delegate bool delegateCompareNode(TreeListNode nodeInTree, object[] searchValue);

        #endregion

        #region Properties

        /// <summary>
        /// Get and set flag to allow sorting tree globaly for all columns
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("true")]
        [Description("Get and set flag to allow sorting tree globaly for all columns.")]
        public bool AllowSortTree
        {
            get { return _allowSortTree; }
            set
            {
                // apply member
                _allowSortTree = value;

                // init new list if empty
                if (_columnsDefaultSortBehaviour == null)
                {
                    _columnsDefaultSortBehaviour = new Dictionary<TreeListColumn, bool>();
                }

                // lock all columns for sorting
                foreach (TreeListColumn col in Columns)
                {
                    // add column to dictionary if not existing
                    if (!_columnsDefaultSortBehaviour.ContainsKey(col))
                    {
                        _columnsDefaultSortBehaviour.Add(col, col.OptionsColumn.AllowSort);
                    }

                    // setup column sorting behaviour depending on current flag
                    if (_allowSortTree)
                    {
                        // apply value from dictionary if existing and different
                        if (_columnsDefaultSortBehaviour.ContainsKey(col) &&
                            col.OptionsColumn.AllowSort != _columnsDefaultSortBehaviour[col])
                        {
                            // reapply default sort value
                            col.OptionsColumn.AllowSort = _columnsDefaultSortBehaviour[col];
                        }
                    }
                    else
                    {
                        // prevent sorting for all columns if different
                        if (col.OptionsColumn.AllowSort)
                        {
                            col.OptionsColumn.AllowSort = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the object used as the data source for the current <see cref="T:DevExpress.XtraTreeList.TreeList"/> control.
        /// </summary>
        /// <value>The object used as the data source.</value>
        [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Category("Data")]
        public new object DataSource
        {
            get { return base.DataSource; }
            set { base.DataSource = value; }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Finds the first matching node by scanning the tree recursively, starting with the specified
        /// parentNodes. You define yourself what a "match" is by writing a method that complies with
        /// the signature of the delegateCompareNode delegate.
        /// </summary>
        /// <param name="parentNodes">Starting nodes for recursive search. Use myTree.Nodes to search entire tree.</param>
        /// <param name="searchValue">Used in your implementation of delegateCompareNode to match a node.</param>
        /// <param name="matchMethod">Your implementation of a method that has the same signature like delegateCompareNode.</param>
        /// <returns>First TreeListNode that matches, otherwise null</returns>
        public static TreeListNode FindNode(TreeListNodes parentNodes, object[] searchValue, delegateCompareNode matchMethod)
        {
            foreach (TreeListNode node in parentNodes)
            {
                if (matchMethod(node, searchValue))
                {
                    return node;
                }

                if (node.HasChildren)
                {
                    TreeListNode n = FindNode(node.Nodes, searchValue, matchMethod);

                    if (n != null && matchMethod(n, searchValue))
                    {
                        return n;
                    }
                }
            }

            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <param name="valueMember">The value member.</param>
        /// <param name="displayMember">The display member.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(DB.SqlQuery qry, string valueMember, string displayMember)
        {
            RepositoryItemLookUpEdit LOVLookUpEdit = UtilsGui.GetLOVLookUpEdit(qry, valueMember, displayMember);
            this.RepositoryItems.Add(LOVLookUpEdit);

            return LOVLookUpEdit;
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(DB.SqlQuery qry)
        {
            return GetLOVLookUpEdit(qry, "Code", "Text");
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="lovName">Name of the LOV.</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(string lovName)
        {
            return GetLOVLookUpEdit(lovName, false);
        }

        /// <summary>
        /// Gets the LOV look up edit.
        /// </summary>
        /// <param name="LOVName">Name of the LOV.</param>
        /// <param name="allowNull">if set to <c>true</c> [allow null].</param>
        /// <returns></returns>
        public RepositoryItemLookUpEdit GetLOVLookUpEdit(string LOVName, bool allowNull)
        {
            return GetLOVLookUpEdit(DBUtil.GetLOVQuery(LOVName, allowNull));
        }

        /// <summary>
        /// Loads the state.
        /// </summary>
        public void LoadState()
        {
            foreach (object expandedNode in _expandedNodes)
            {
                try
                {
                    this.FindNodeByKeyID(expandedNode).Expanded = true;
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Debug(ex);
                }
            }

            try
            {
                this.FocusedNode = this.FindNodeByKeyID(this._saveFocusedNode);

                if (_lastTopVisibleNodeIndex > -1)
                {
                    this.TopVisibleNodeIndex = _lastTopVisibleNodeIndex;
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.Debug(ex);
            }
        }

        /// <summary>
        /// Saves the state.
        /// </summary>
        public void SaveState()
        {
            try
            {
                _saveFocusedNode = this.FocusedNode.GetValue(this.KeyFieldName);
                _lastTopVisibleNodeIndex = this.TopVisibleNodeIndex;

                _expandedNodes.Clear();
                this.ReadNodeState(this.Nodes);
            }
            catch (Exception ex)
            {
                // logging
                _logger.Debug(ex);

                _saveFocusedNode = null;
                _lastTopVisibleNodeIndex = -1;
                _expandedNodes.Clear();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Finds the next node.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="node">The node.</param>
        /// <param name="keyString">The key string.</param>
        /// <returns></returns>
        protected TreeListNode FindNextNode(TreeListNode rootNode, TreeListNode node, string keyString)
        {
            return FindNextNode(rootNode, node, keyString, false);
        }

        /// <summary>
        /// Finds the next node.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <param name="node">The node.</param>
        /// <param name="keyString">The key string.</param>
        /// <param name="foundNode">if set to <c>true</c> [found node].</param>
        /// <returns></returns>
        protected TreeListNode FindNextNode(TreeListNode rootNode, TreeListNode node, string keyString, bool foundNode)
        {
            TreeListColumn firstVisibleCol = this.GetFirstVisibleColumn();

            if (firstVisibleCol == null)
            {
                return null;
            }

            if (!foundNode)
            {
                foundNode = rootNode.Equals(node);
            }

            foreach (TreeListNode tlNode in rootNode.Nodes)
            {
                if (!foundNode)
                {
                    foundNode = tlNode.Equals(node);
                }
                else
                {
                    // get display text of node
                    string nodeDisplayText = tlNode.GetDisplayText(this.GetFirstVisibleColumn());

                    // logging
                    _logger.DebugFormat("tlNode.GetDisplayText(...)='{0}'", nodeDisplayText);

                    // check if node has any display text and fits with key
                    if (!string.IsNullOrEmpty(nodeDisplayText) && nodeDisplayText.Substring(0, keyString.Length).ToLower() == keyString.ToLower())
                    {
                        return tlNode;
                    }
                }

                if (tlNode.HasChildren && tlNode.Expanded)
                {
                    TreeListNode findNode = this.FindNextNode(tlNode, node, keyString, foundNode);

                    if (findNode != null)
                    {
                        return findNode;
                    }
                }
            }

            return null;
        }

        protected override AccessibleObject GetAccessibilityObjectById(int objectId)
        {
            // Methode überschreiben und Try-Catch einbauen da es in der DevExpress-Überschreibung zu einer NullReferenceException führt. (nur wenn JAWS Screen Reading Software am laufen ist)
            try
            {
                return base.GetAccessibilityObjectById(objectId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the first visible column.
        /// </summary>
        /// <returns></returns>
        protected TreeListColumn GetFirstVisibleColumn()
        {
            foreach (TreeListColumn col in this.Columns)
            {
                if (col.VisibleIndex == 0)
                {
                    return col;
                }
            }

            return null;
        }

        /// <summary>
        /// Raises the <see cref="E:KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (this.FocusedNode != null && e.Modifiers == Keys.None && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                this.FocusedNode = this.FindNextNode(this.FocusedNode.RootNode, this.FocusedNode, Convert.ToString(e.KeyCode));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // right MouseClick: if user clicked a cell, set focus to that TreeNode
            if (e.Button == MouseButtons.Right)
            {
                TreeListHitInfo hInfo = this.CalcHitInfo(new Point(e.X, e.Y));

                if (hInfo.HitInfoType == HitInfoType.Cell)
                {
                    this.FocusedNode = hInfo.Node;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Reads the state of the node.
        /// </summary>
        /// <param name="parentNodes">The parent nodes.</param>
        private void ReadNodeState(TreeListNodes parentNodes)
        {
            foreach (TreeListNode node in parentNodes)
            {
                if (node.HasChildren && node.Expanded)
                {
                    _expandedNodes.Add(node.GetValue(this.KeyFieldName));
                    ReadNodeState(node.Nodes);
                }
            }
        }

        #endregion

        #endregion
    }
}