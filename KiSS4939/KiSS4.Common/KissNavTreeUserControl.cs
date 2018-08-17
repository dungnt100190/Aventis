using System;
using System.Collections.Specialized;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Common
{
    /// <summary>
    /// Summary description for KissNavTreeUserControl.
    /// </summary>
    public partial class KissNavTreeUserControl : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissNavTreeUserControl"/> class.
        /// </summary>
        public KissNavTreeUserControl()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            kissDataNavigator.PrefereDetailControl = true;

            navTree.SelectImageList = KissImageList.SmallImageList;

            navTree.BeforeFocusNode += navTree_BeforeFocusNode;
            navTree.AfterFocusNode += navTree_AfterFocusNode;

            navTree.DataSource = null;
            navTree.ImageIndexFieldName = "ImageIndex";
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the AfterFocusNode event of the navTree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.NodeEventArgs"/> instance containing the event data.</param>
        protected virtual void navTree_AfterFocusNode(object sender, NodeEventArgs e)
        {
            try
            {
                picTitle.Image = ((ImageList)navTree.SelectImageList).Images[int.Parse(e.Node.GetValue("ImageIndex").ToString())];
            }
            catch
            {
                picTitle.Image = null;
            }

            lblTitle.Visible = true;
            lblTitle.Text = e.Node.GetDisplayText(navTree.Columns[0]);
        }

        /// <summary>
        /// Handles the BeforeFocusNode event of the navTree control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.BeforeFocusNodeEventArgs"/> instance containing the event data.</param>
        protected virtual void navTree_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (DetailControl != null)
            {
                try
                {
                    e.CanFocus = ((IKissDataNavigator)DetailControl).SaveData();
                }
                catch
                {
                    e.CanFocus = false;
                }
            }
        }

        private void qryTree_AfterFill(object sender, EventArgs e)
        {
            if (!qryTree.DataTable.Columns.Contains("ImageIndex"))
            {
                qryTree.DataTable.Columns.Add("ImageIndex", typeof(int));
            }

            foreach (DataRow row in qryTree.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["IconID"]))
                {
                    row["ImageIndex"] = KissImageList.GetImageIndex((int)row["IconID"]);
                }
            }

            navTree.DataSource = sender;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            switch (parameters["Action"] as string)
            {
                case "RefreshTree":
                    Refresh();
                    return true;

                case "JumpToPath":
                    if (parameters.Contains("TreeNodeID"))
                    {
                        navTree.FocusedNode = navTree.FindNodeByKeyID(parameters["TreeNodeID"]);
                    }

                    if (DetailControl != null)
                    {
                        FormController.SendMessage(DetailControl, parameters);
                    }

                    return true;
            }

            return base.ReceiveMessage(parameters);
        }

        /// <summary>
        /// Forces the control to invalidate its client area and immediately redraw itself and any child controls.
        /// </summary>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override void Refresh()
        {
            object saveFocusedNode = "";
            object saveFocusedNodeParent = null;

            // Save FocusedNode
            if (navTree.FocusedNode != null)
            {
                saveFocusedNode = navTree.FocusedNode.GetValue(navTree.KeyFieldName);

                if (navTree.FocusedNode.ParentNode != null)
                {
                    saveFocusedNodeParent = navTree.FocusedNode.ParentNode.GetValue(navTree.KeyFieldName);
                }
            }

            // Refresh Data
            navTree.BeforeFocusNode -= navTree_BeforeFocusNode;
            navTree.AfterFocusNode -= navTree_AfterFocusNode;

            navTree.SaveState();
            navTree.DataSource = null;
            qryTree.Refresh();
            navTree.LoadState();

            navTree.BeforeFocusNode += navTree_BeforeFocusNode;
            navTree.AfterFocusNode += navTree_AfterFocusNode;

            // Force Event if last FocusedNode doesn't exist
            if (navTree.Nodes.Count == 0)
            {
                ActivateUserControl(null, panDetail);
            }
            else if (navTree.FocusedNode == null)
            {
                // logging
                _log.Info("navTree.FocusedNoe is null, this often occures when refreshing while changing focused node.");

                // try to refocus last focused node
                navTree.FocusedNode = navTree.FindNodeByKeyID(saveFocusedNode);

                // TODO: in all probability, the focused node will not be highlited afterwards.
                //       this should not occure and iritates the user!
            }
            else if (saveFocusedNode.ToString() != navTree.FocusedNode.GetValue(navTree.KeyFieldName).ToString())
            {
                navTree.FocusedNode = null;
                navTree.MoveFirst();

                // set Position to Parent if it is possible
                navTree.FocusedNode = navTree.FindNodeByKeyID(saveFocusedNodeParent);
            }
        }

        public override object ReturnMessage(HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "GetJumpToPath":
                    var dic = base.ReturnMessage(parameters) as HybridDictionary;

                    if (navTree.FocusedNode != null)
                    {
                        if (dic == null)
                        {
                            dic = new HybridDictionary();
                        }

                        dic["TreeNodeID"] = navTree.FocusedNode.GetValue(navTree.KeyFieldName);
                    }

                    return dic;
            }

            return base.ReturnMessage(parameters);
        }

        #endregion

        #endregion
    }
}